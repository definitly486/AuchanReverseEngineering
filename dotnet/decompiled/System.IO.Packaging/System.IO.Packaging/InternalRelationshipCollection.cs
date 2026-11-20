using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace System.IO.Packaging;

internal class InternalRelationshipCollection : IEnumerable<PackageRelationship>, IEnumerable
{
	private static readonly UriKind DotNetRelativeOrAbsolute = ((!(Type.GetType("Mono.Runtime") == null)) ? ((UriKind)300) : UriKind.RelativeOrAbsolute);

	private List<PackageRelationship> _relationships;

	private bool _dirty;

	private Package _package;

	private PackagePart _sourcePart;

	private PackagePart _relationshipPart;

	private Uri _uri;

	private static readonly int s_timestampLength = 16;

	private static readonly string s_relationshipsTagName = "Relationships";

	private static readonly string s_relationshipTagName = "Relationship";

	private static readonly string s_targetAttributeName = "Target";

	private static readonly string s_typeAttributeName = "Type";

	private static readonly string s_idAttributeName = "Id";

	private static readonly string s_xmlBaseAttributeName = "xml:base";

	private static readonly string s_targetModeAttributeName = "TargetMode";

	private static readonly string[] s_relationshipKnownNamespaces = new string[1] { PackagingUtilities.RelationshipNamespaceUri };

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _relationships.GetEnumerator();
	}

	IEnumerator<PackageRelationship> IEnumerable<PackageRelationship>.GetEnumerator()
	{
		return _relationships.GetEnumerator();
	}

	internal InternalRelationshipCollection(PackagePart part)
		: this(part.Package, part)
	{
	}

	internal InternalRelationshipCollection(Package package)
		: this(package, null)
	{
	}

	internal PackageRelationship Add(Uri targetUri, TargetMode targetMode, string relationshipType, string id)
	{
		return Add(targetUri, targetMode, relationshipType, id, parsing: false);
	}

	internal PackageRelationship GetRelationship(string id)
	{
		int relationshipIndex = GetRelationshipIndex(id);
		if (relationshipIndex == -1)
		{
			return null;
		}
		return _relationships[relationshipIndex];
	}

	internal void Clear()
	{
		_relationships.Clear();
		_dirty = true;
	}

	internal void Flush()
	{
		if (!_dirty)
		{
			return;
		}
		if (_relationships.Count == 0)
		{
			if (_package.PartExists(_uri))
			{
				_package.DeletePart(_uri);
			}
			_relationshipPart = null;
		}
		else
		{
			EnsureRelationshipPart();
			WriteRelationshipPart(_relationshipPart);
		}
		_dirty = false;
	}

	internal static void ThrowIfInvalidRelationshipType(string relationshipType)
	{
		if (relationshipType.Trim() == string.Empty)
		{
			throw new ArgumentException(System.SR.InvalidRelationshipType);
		}
	}

	internal static void ThrowIfInvalidXsdId(string id)
	{
		try
		{
			XmlConvert.VerifyNCName(id);
		}
		catch (XmlException innerException)
		{
			throw new XmlException(System.SR.Format(System.SR.NotAValidXmlIdString, id), innerException);
		}
	}

	private InternalRelationshipCollection(Package package, PackagePart part)
	{
		_package = package;
		_sourcePart = part;
		_uri = GetRelationshipPartUri(_sourcePart);
		_relationships = new List<PackageRelationship>(4);
		if ((package.FileOpenAccess == FileAccess.Read || package.FileOpenAccess == FileAccess.ReadWrite) && package.PartExists(_uri))
		{
			_relationshipPart = package.GetPart(_uri);
			ThrowIfIncorrectContentType(_relationshipPart.ValidatedContentType);
			ParseRelationshipPart(_relationshipPart);
		}
		_dirty = false;
	}

	private static Uri GetRelationshipPartUri(PackagePart part)
	{
		Uri partUri = ((part != null) ? part.Uri : PackUriHelper.PackageRootUri);
		return PackUriHelper.GetRelationshipPartUri(partUri);
	}

	private void ParseRelationshipPart(PackagePart part)
	{
		using Stream input = part.GetStream(FileMode.Open, FileAccess.Read);
		using XmlReader xmlReader = XmlReader.Create(input);
		using XmlCompatibilityReader xmlCompatibilityReader = new XmlCompatibilityReader(xmlReader, s_relationshipKnownNamespaces);
		PackagingUtilities.PerformInitialReadAndVerifyEncoding(xmlReader);
		xmlCompatibilityReader.MoveToContent();
		if (xmlCompatibilityReader.NodeType == XmlNodeType.Element && xmlCompatibilityReader.Depth == 0 && string.CompareOrdinal(s_relationshipsTagName, xmlCompatibilityReader.LocalName) == 0 && string.CompareOrdinal(PackagingUtilities.RelationshipNamespaceUri, xmlCompatibilityReader.NamespaceURI) == 0)
		{
			ThrowIfXmlBaseAttributeIsPresent(xmlCompatibilityReader);
			if (PackagingUtilities.GetNonXmlnsAttributeCount(xmlCompatibilityReader) > 0)
			{
				throw new XmlException(System.SR.RelationshipsTagHasExtraAttributes, null, xmlCompatibilityReader.LineNumber, xmlCompatibilityReader.LinePosition);
			}
			while (xmlCompatibilityReader.Read())
			{
				xmlCompatibilityReader.MoveToContent();
				if (xmlCompatibilityReader.NodeType == XmlNodeType.None)
				{
					continue;
				}
				if (xmlCompatibilityReader.NodeType == XmlNodeType.Element && xmlCompatibilityReader.Depth == 1 && string.CompareOrdinal(s_relationshipTagName, xmlCompatibilityReader.LocalName) == 0 && string.CompareOrdinal(PackagingUtilities.RelationshipNamespaceUri, xmlCompatibilityReader.NamespaceURI) == 0)
				{
					ThrowIfXmlBaseAttributeIsPresent(xmlCompatibilityReader);
					int num = 3;
					string attribute = xmlCompatibilityReader.GetAttribute(s_targetModeAttributeName);
					if (attribute != null)
					{
						num++;
					}
					if (PackagingUtilities.GetNonXmlnsAttributeCount(xmlCompatibilityReader) != num)
					{
						throw new XmlException(System.SR.RelationshipTagDoesntMatchSchema, null, xmlCompatibilityReader.LineNumber, xmlCompatibilityReader.LinePosition);
					}
					ProcessRelationshipAttributes(xmlCompatibilityReader);
					if (!xmlCompatibilityReader.IsEmptyElement)
					{
						ProcessEndElementForRelationshipTag(xmlCompatibilityReader);
					}
				}
				else if (string.CompareOrdinal(s_relationshipsTagName, xmlCompatibilityReader.LocalName) != 0 || xmlCompatibilityReader.NodeType != XmlNodeType.EndElement)
				{
					throw new XmlException(System.SR.UnknownTagEncountered, null, xmlCompatibilityReader.LineNumber, xmlCompatibilityReader.LinePosition);
				}
			}
			return;
		}
		throw new XmlException(System.SR.ExpectedRelationshipsElementTag, null, xmlCompatibilityReader.LineNumber, xmlCompatibilityReader.LinePosition);
	}

	private void ProcessRelationshipAttributes(XmlCompatibilityReader reader)
	{
		string attribute = reader.GetAttribute(s_targetModeAttributeName);
		TargetMode targetMode = TargetMode.Internal;
		if (attribute != null)
		{
			try
			{
				targetMode = (TargetMode)Enum.Parse(typeof(TargetMode), attribute, ignoreCase: false);
			}
			catch (ArgumentNullException ex)
			{
				ThrowForInvalidAttributeValue(reader, s_targetModeAttributeName, ex);
			}
			catch (ArgumentException ex2)
			{
				ThrowForInvalidAttributeValue(reader, s_targetModeAttributeName, ex2);
			}
		}
		string attribute2 = reader.GetAttribute(s_targetAttributeName);
		if (string.IsNullOrEmpty(attribute2))
		{
			throw new XmlException(System.SR.Format(System.SR.RequiredRelationshipAttributeMissing, s_targetAttributeName), null, reader.LineNumber, reader.LinePosition);
		}
		Uri targetUri = new Uri(attribute2, DotNetRelativeOrAbsolute);
		string attribute3 = reader.GetAttribute(s_typeAttributeName);
		if (string.IsNullOrEmpty(attribute3))
		{
			throw new XmlException(System.SR.Format(System.SR.RequiredRelationshipAttributeMissing, s_typeAttributeName), null, reader.LineNumber, reader.LinePosition);
		}
		string attribute4 = reader.GetAttribute(s_idAttributeName);
		if (string.IsNullOrEmpty(attribute4))
		{
			throw new XmlException(System.SR.Format(System.SR.RequiredRelationshipAttributeMissing, s_idAttributeName), null, reader.LineNumber, reader.LinePosition);
		}
		Add(targetUri, targetMode, attribute3, attribute4, parsing: true);
	}

	private void ProcessEndElementForRelationshipTag(XmlCompatibilityReader reader)
	{
		reader.Read();
		reader.MoveToContent();
		if (reader.NodeType == XmlNodeType.EndElement && string.CompareOrdinal(s_relationshipTagName, reader.LocalName) == 0)
		{
			return;
		}
		throw new XmlException(System.SR.Format(System.SR.ElementIsNotEmptyElement, s_relationshipTagName), null, reader.LineNumber, reader.LinePosition);
	}

	private PackageRelationship Add(Uri targetUri, TargetMode targetMode, string relationshipType, string id, bool parsing)
	{
		if (targetUri == null)
		{
			throw new ArgumentNullException("targetUri");
		}
		if (relationshipType == null)
		{
			throw new ArgumentNullException("relationshipType");
		}
		ThrowIfInvalidRelationshipType(relationshipType);
		switch (targetMode)
		{
		default:
			throw new ArgumentOutOfRangeException("targetMode");
		case TargetMode.Internal:
			if (targetUri.IsAbsoluteUri)
			{
				throw new ArgumentException(System.SR.RelationshipTargetMustBeRelative, "targetUri");
			}
			break;
		case TargetMode.External:
			break;
		}
		if ((!targetUri.IsAbsoluteUri && targetMode != TargetMode.External) || (targetUri.IsAbsoluteUri && targetUri.Scheme == PackUriHelper.UriSchemePack))
		{
			Uri resolvedTargetUri = GetResolvedTargetUri(targetUri, targetMode);
			if (resolvedTargetUri != null && PackUriHelper.IsRelationshipPartUri(resolvedTargetUri))
			{
				throw new ArgumentException(System.SR.RelationshipToRelationshipIllegal, "targetUri");
			}
		}
		if (id == null)
		{
			id = GenerateUniqueRelationshipId();
		}
		else
		{
			ValidateUniqueRelationshipId(id);
		}
		PackageRelationship packageRelationship = new PackageRelationship(_package, _sourcePart, targetUri, targetMode, relationshipType, id);
		_relationships.Add(packageRelationship);
		_dirty = !parsing;
		return packageRelationship;
	}

	private void WriteRelationshipPart(PackagePart part)
	{
		using Stream stream = part.GetStream();
		using IgnoreFlushAndCloseStream ignoreFlushAndCloseStream = new IgnoreFlushAndCloseStream(stream);
		if (_package.FileOpenAccess != FileAccess.Write)
		{
			ignoreFlushAndCloseStream.SetLength(0L);
		}
		using XmlWriter xmlWriter = XmlWriter.Create(ignoreFlushAndCloseStream, new XmlWriterSettings
		{
			Encoding = Encoding.UTF8
		});
		xmlWriter.WriteStartDocument();
		xmlWriter.WriteStartElement(s_relationshipsTagName, PackagingUtilities.RelationshipNamespaceUri);
		WriteRelationshipsAsXml(xmlWriter, _relationships, alwaysWriteTargetModeAttribute: false);
		xmlWriter.WriteEndElement();
		xmlWriter.WriteEndDocument();
	}

	internal static void WriteRelationshipsAsXml(XmlWriter writer, IEnumerable<PackageRelationship> relationships, bool alwaysWriteTargetModeAttribute)
	{
		foreach (PackageRelationship relationship in relationships)
		{
			writer.WriteStartElement(s_relationshipTagName);
			writer.WriteAttributeString(s_typeAttributeName, relationship.RelationshipType);
			writer.WriteAttributeString(s_targetAttributeName, relationship.TargetUri.OriginalString);
			if (alwaysWriteTargetModeAttribute || relationship.TargetMode == TargetMode.External)
			{
				writer.WriteAttributeString(s_targetModeAttributeName, relationship.TargetMode.ToString());
			}
			writer.WriteAttributeString(s_idAttributeName, relationship.Id);
			writer.WriteEndElement();
		}
	}

	private void EnsureRelationshipPart()
	{
		if (_relationshipPart == null || _relationshipPart.IsDeleted)
		{
			if (_package.PartExists(_uri))
			{
				_relationshipPart = _package.GetPart(_uri);
				ThrowIfIncorrectContentType(_relationshipPart.ValidatedContentType);
			}
			else
			{
				CompressionOption compressionOption = ((_sourcePart == null) ? CompressionOption.NotCompressed : _sourcePart.CompressionOption);
				_relationshipPart = _package.CreatePart(_uri, PackagingUtilities.RelationshipPartContentType.ToString(), compressionOption);
			}
		}
	}

	private Uri GetResolvedTargetUri(Uri target, TargetMode targetMode)
	{
		if (_sourcePart == null)
		{
			return PackUriHelper.ResolvePartUri(PackUriHelper.PackageRootUri, target);
		}
		return PackUriHelper.ResolvePartUri(_sourcePart.Uri, target);
	}

	private void ThrowIfIncorrectContentType(ContentType contentType)
	{
		if (!contentType.AreTypeAndSubTypeEqual(PackagingUtilities.RelationshipPartContentType))
		{
			throw new FileFormatException(System.SR.RelationshipPartIncorrectContentType);
		}
	}

	private void ThrowIfXmlBaseAttributeIsPresent(XmlCompatibilityReader reader)
	{
		string attribute = reader.GetAttribute(s_xmlBaseAttributeName);
		if (attribute != null)
		{
			throw new XmlException(System.SR.Format(System.SR.InvalidXmlBaseAttributePresent, s_xmlBaseAttributeName), null, reader.LineNumber, reader.LinePosition);
		}
	}

	private void ThrowForInvalidAttributeValue(XmlCompatibilityReader reader, string attributeName, Exception ex)
	{
		throw new XmlException(System.SR.Format(System.SR.InvalidValueForTheAttribute, attributeName), ex, reader.LineNumber, reader.LinePosition);
	}

	private string GenerateUniqueRelationshipId()
	{
		string text;
		do
		{
			text = GenerateRelationshipId();
		}
		while (GetRelationship(text) != null);
		return text;
	}

	private string GenerateRelationshipId()
	{
		return "R" + Guid.NewGuid().ToString("N").Substring(0, s_timestampLength);
	}

	private void ValidateUniqueRelationshipId(string id)
	{
		ThrowIfInvalidXsdId(id);
		if (GetRelationshipIndex(id) >= 0)
		{
			throw new XmlException(System.SR.Format(System.SR.NotAUniqueRelationshipId, id));
		}
	}

	private int GetRelationshipIndex(string id)
	{
		for (int i = 0; i < _relationships.Count; i++)
		{
			if (string.Equals(_relationships[i].Id, id, StringComparison.Ordinal))
			{
				return i;
			}
		}
		return -1;
	}
}
