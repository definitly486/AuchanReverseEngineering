using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Compression;
using System.Text;
using System.Xml;

namespace System.IO.Packaging;

public sealed class ZipPackage : Package
{
	private sealed class ExtensionEqualityComparer : IEqualityComparer<string>
	{
		bool IEqualityComparer<string>.Equals(string extensionA, string extensionB)
		{
			return string.CompareOrdinal(extensionA.ToUpperInvariant(), extensionB.ToUpperInvariant()) == 0;
		}

		int IEqualityComparer<string>.GetHashCode(string extension)
		{
			return extension.ToUpperInvariant().GetHashCode();
		}
	}

	private class ContentTypeHelper
	{
		private Dictionary<PackUriHelper.ValidatedPartUri, ContentType> _overrideDictionary;

		private Dictionary<string, ContentType> _defaultDictionary;

		private ZipArchive _zipArchive;

		private FileMode _packageFileMode;

		private FileAccess _packageFileAccess;

		private ZipStreamManager _zipStreamManager;

		private ZipArchiveEntry _contentTypeZipArchiveEntry;

		private bool _contentTypeStreamExists;

		private bool _dirty;

		private CompressionLevel _cachedCompressionLevel;

		private static readonly string s_contentTypesFile = "[Content_Types].xml";

		private static readonly string s_contentTypesFileUpperInvariant = "[CONTENT_TYPES].XML";

		private static readonly int s_defaultDictionaryInitialSize = 16;

		private static readonly int s_overrideDictionaryInitialSize = 8;

		private static readonly string s_typesNamespaceUri = "http://schemas.openxmlformats.org/package/2006/content-types";

		private static readonly string s_typesTagName = "Types";

		private static readonly string s_defaultTagName = "Default";

		private static readonly string s_extensionAttributeName = "Extension";

		private static readonly string s_contentTypeAttributeName = "ContentType";

		private static readonly string s_overrideTagName = "Override";

		private static readonly string s_partNameAttributeName = "PartName";

		private static readonly string s_temporaryPartNameWithoutExtension = "/tempfiles/sample.";

		internal static string ContentTypeFileName => s_contentTypesFile;

		internal ContentTypeHelper(ZipArchive zipArchive, FileMode packageFileMode, FileAccess packageFileAccess, ZipStreamManager zipStreamManager)
		{
			_zipArchive = zipArchive;
			_packageFileMode = packageFileMode;
			_packageFileAccess = packageFileAccess;
			_zipStreamManager = zipStreamManager;
			_defaultDictionary = new Dictionary<string, ContentType>(s_defaultDictionaryInitialSize, s_extensionEqualityComparer);
			if (_zipArchive.Mode == ZipArchiveMode.Read || _zipArchive.Mode == ZipArchiveMode.Update)
			{
				ParseContentTypesFile(_zipArchive.Entries);
			}
			_dirty = false;
		}

		internal void AddContentType(PackUriHelper.ValidatedPartUri partUri, ContentType contentType, CompressionLevel compressionLevel)
		{
			if (!_contentTypeStreamExists)
			{
				_cachedCompressionLevel = compressionLevel;
			}
			bool flag = false;
			string partUriExtension = partUri.PartUriExtension;
			if (partUriExtension.Length == 0 || (_defaultDictionary.ContainsKey(partUriExtension) && !(flag = _defaultDictionary[partUriExtension].AreTypeAndSubTypeEqual(contentType))))
			{
				AddOverrideElement(partUri, contentType);
			}
			else if (!flag)
			{
				AddDefaultElement(partUriExtension, contentType);
			}
		}

		internal ContentType GetContentType(PackUriHelper.ValidatedPartUri partUri)
		{
			if (_overrideDictionary != null && _overrideDictionary.ContainsKey(partUri))
			{
				return _overrideDictionary[partUri];
			}
			string partUriExtension = partUri.PartUriExtension;
			if (_defaultDictionary.ContainsKey(partUriExtension))
			{
				return _defaultDictionary[partUriExtension];
			}
			return null;
		}

		internal void DeleteContentType(PackUriHelper.ValidatedPartUri partUri)
		{
			if (_overrideDictionary != null && _overrideDictionary.Remove(partUri))
			{
				_dirty = true;
			}
		}

		internal void SaveToFile()
		{
			if (!_dirty)
			{
				return;
			}
			if (!_contentTypeStreamExists)
			{
				_contentTypeZipArchiveEntry = _zipArchive.CreateEntry(s_contentTypesFile, _cachedCompressionLevel);
				_contentTypeStreamExists = true;
			}
			else
			{
				string fullName = _contentTypeZipArchiveEntry.FullName;
				ZipArchive archive = _contentTypeZipArchiveEntry.Archive;
				_zipStreamManager.Close(_contentTypeZipArchiveEntry);
				_contentTypeZipArchiveEntry.Delete();
				_contentTypeZipArchiveEntry = archive.CreateEntry(fullName);
			}
			using Stream output = _zipStreamManager.Open(_contentTypeZipArchiveEntry, _packageFileMode, FileAccess.ReadWrite);
			using XmlWriter xmlWriter = XmlWriter.Create(output, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8
			});
			xmlWriter.WriteStartDocument();
			xmlWriter.WriteStartElement(s_typesTagName, s_typesNamespaceUri);
			foreach (string key in _defaultDictionary.Keys)
			{
				WriteDefaultElement(xmlWriter, key, _defaultDictionary[key]);
			}
			if (_overrideDictionary != null)
			{
				foreach (PackUriHelper.ValidatedPartUri key2 in _overrideDictionary.Keys)
				{
					WriteOverrideElement(xmlWriter, key2, _overrideDictionary[key2]);
				}
			}
			xmlWriter.WriteEndElement();
			xmlWriter.WriteEndDocument();
			_dirty = false;
		}

		private void EnsureOverrideDictionary()
		{
			if (_overrideDictionary == null)
			{
				_overrideDictionary = new Dictionary<PackUriHelper.ValidatedPartUri, ContentType>(s_overrideDictionaryInitialSize);
			}
		}

		private void ParseContentTypesFile(ReadOnlyCollection<ZipArchiveEntry> zipFiles)
		{
			Stream stream = OpenContentTypeStream(zipFiles);
			if (stream == null)
			{
				return;
			}
			XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
			xmlReaderSettings.IgnoreWhitespace = true;
			using (stream)
			{
				using XmlReader xmlReader = XmlReader.Create(stream, xmlReaderSettings);
				PackagingUtilities.PerformInitialReadAndVerifyEncoding(xmlReader);
				xmlReader.MoveToContent();
				if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Depth == 0 && string.CompareOrdinal(xmlReader.NamespaceURI, s_typesNamespaceUri) == 0 && string.CompareOrdinal(xmlReader.Name, s_typesTagName) == 0)
				{
					if (PackagingUtilities.GetNonXmlnsAttributeCount(xmlReader) > 0)
					{
						throw new XmlException(System.SR.TypesTagHasExtraAttributes, null, ((IXmlLineInfo)xmlReader).LineNumber, ((IXmlLineInfo)xmlReader).LinePosition);
					}
					while (xmlReader.Read())
					{
						xmlReader.MoveToContent();
						if (xmlReader.NodeType != XmlNodeType.None)
						{
							if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Depth == 1 && string.CompareOrdinal(xmlReader.NamespaceURI, s_typesNamespaceUri) == 0 && string.CompareOrdinal(xmlReader.Name, s_defaultTagName) == 0)
							{
								ProcessDefaultTagAttributes(xmlReader);
							}
							else if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Depth == 1 && string.CompareOrdinal(xmlReader.NamespaceURI, s_typesNamespaceUri) == 0 && string.CompareOrdinal(xmlReader.Name, s_overrideTagName) == 0)
							{
								ProcessOverrideTagAttributes(xmlReader);
							}
							else if (xmlReader.NodeType != XmlNodeType.EndElement || xmlReader.Depth != 0 || string.CompareOrdinal(xmlReader.Name, s_typesTagName) != 0)
							{
								throw new XmlException(System.SR.TypesXmlDoesNotMatchSchema, null, ((IXmlLineInfo)xmlReader).LineNumber, ((IXmlLineInfo)xmlReader).LinePosition);
							}
						}
					}
					return;
				}
				throw new XmlException(System.SR.TypesElementExpected, null, ((IXmlLineInfo)xmlReader).LineNumber, ((IXmlLineInfo)xmlReader).LinePosition);
			}
		}

		private Stream OpenContentTypeStream(ReadOnlyCollection<ZipArchiveEntry> zipFiles)
		{
			foreach (ZipArchiveEntry zipFile in zipFiles)
			{
				if (zipFile.Name.ToUpperInvariant().StartsWith(s_contentTypesFileUpperInvariant, StringComparison.Ordinal) && zipFile.Name.Length == ContentTypeFileName.Length)
				{
					_contentTypeZipArchiveEntry = zipFile;
				}
			}
			if (_contentTypeZipArchiveEntry != null)
			{
				_contentTypeStreamExists = true;
				return _zipStreamManager.Open(_contentTypeZipArchiveEntry, _packageFileMode, FileAccess.ReadWrite);
			}
			return null;
		}

		private void ProcessDefaultTagAttributes(XmlReader reader)
		{
			if (PackagingUtilities.GetNonXmlnsAttributeCount(reader) != 2)
			{
				throw new XmlException(System.SR.DefaultTagDoesNotMatchSchema, null, ((IXmlLineInfo)reader).LineNumber, ((IXmlLineInfo)reader).LinePosition);
			}
			string attribute = reader.GetAttribute(s_extensionAttributeName);
			ValidateXmlAttribute(s_extensionAttributeName, attribute, s_defaultTagName, reader);
			string attribute2 = reader.GetAttribute(s_contentTypeAttributeName);
			ThrowIfXmlAttributeMissing(s_contentTypeAttributeName, attribute2, s_defaultTagName, reader);
			PackUriHelper.ValidatedPartUri validatedPartUri = PackUriHelper.ValidatePartUri(new Uri(s_temporaryPartNameWithoutExtension + attribute, UriKind.Relative));
			_defaultDictionary.Add(validatedPartUri.PartUriExtension, new ContentType(attribute2));
			if (!reader.IsEmptyElement)
			{
				ProcessEndElement(reader, s_defaultTagName);
			}
		}

		private void ProcessOverrideTagAttributes(XmlReader reader)
		{
			if (PackagingUtilities.GetNonXmlnsAttributeCount(reader) != 2)
			{
				throw new XmlException(System.SR.OverrideTagDoesNotMatchSchema, null, ((IXmlLineInfo)reader).LineNumber, ((IXmlLineInfo)reader).LinePosition);
			}
			string attribute = reader.GetAttribute(s_partNameAttributeName);
			ValidateXmlAttribute(s_partNameAttributeName, attribute, s_overrideTagName, reader);
			string attribute2 = reader.GetAttribute(s_contentTypeAttributeName);
			ThrowIfXmlAttributeMissing(s_contentTypeAttributeName, attribute2, s_overrideTagName, reader);
			PackUriHelper.ValidatedPartUri key = PackUriHelper.ValidatePartUri(new Uri(attribute, UriKind.Relative));
			EnsureOverrideDictionary();
			_overrideDictionary.Add(key, new ContentType(attribute2));
			if (!reader.IsEmptyElement)
			{
				ProcessEndElement(reader, s_overrideTagName);
			}
		}

		private void ProcessEndElement(XmlReader reader, string elementName)
		{
			reader.Read();
			reader.MoveToContent();
			if (reader.NodeType == XmlNodeType.EndElement && string.CompareOrdinal(elementName, reader.LocalName) == 0)
			{
				return;
			}
			throw new XmlException(System.SR.Format(System.SR.ElementIsNotEmptyElement, elementName), null, ((IXmlLineInfo)reader).LineNumber, ((IXmlLineInfo)reader).LinePosition);
		}

		private void AddOverrideElement(PackUriHelper.ValidatedPartUri partUri, ContentType contentType)
		{
			DeleteContentType(partUri);
			EnsureOverrideDictionary();
			_overrideDictionary.Add(partUri, contentType);
			_dirty = true;
		}

		private void AddDefaultElement(string extension, ContentType contentType)
		{
			_defaultDictionary.Add(extension, contentType);
			_dirty = true;
		}

		private void WriteOverrideElement(XmlWriter xmlWriter, PackUriHelper.ValidatedPartUri partUri, ContentType contentType)
		{
			xmlWriter.WriteStartElement(s_overrideTagName);
			xmlWriter.WriteAttributeString(s_partNameAttributeName, partUri.PartUriString);
			xmlWriter.WriteAttributeString(s_contentTypeAttributeName, contentType.ToString());
			xmlWriter.WriteEndElement();
		}

		private void WriteDefaultElement(XmlWriter xmlWriter, string extension, ContentType contentType)
		{
			xmlWriter.WriteStartElement(s_defaultTagName);
			xmlWriter.WriteAttributeString(s_extensionAttributeName, extension);
			xmlWriter.WriteAttributeString(s_contentTypeAttributeName, contentType.ToString());
			xmlWriter.WriteEndElement();
		}

		private void ValidateXmlAttribute(string attributeName, string attributeValue, string tagName, XmlReader reader)
		{
			ThrowIfXmlAttributeMissing(attributeName, attributeValue, tagName, reader);
			if (attributeValue == string.Empty)
			{
				throw new XmlException(System.SR.Format(System.SR.RequiredAttributeEmpty, tagName, attributeName), null, ((IXmlLineInfo)reader).LineNumber, ((IXmlLineInfo)reader).LinePosition);
			}
		}

		private void ThrowIfXmlAttributeMissing(string attributeName, string attributeValue, string tagName, XmlReader reader)
		{
			if (attributeValue == null)
			{
				throw new XmlException(System.SR.Format(System.SR.RequiredAttributeMissing, tagName, attributeName), null, ((IXmlLineInfo)reader).LineNumber, ((IXmlLineInfo)reader).LinePosition);
			}
		}
	}

	private ZipArchive _zipArchive;

	private Stream _containerStream;

	private bool _shouldCloseContainerStream;

	private ContentTypeHelper _contentTypeHelper;

	private ZipStreamManager _zipStreamManager;

	private FileAccess _packageFileAccess;

	private FileMode _packageFileMode;

	private static readonly ExtensionEqualityComparer s_extensionEqualityComparer = new ExtensionEqualityComparer();

	protected override PackagePart CreatePartCore(Uri partUri, string contentType, CompressionOption compressionOption)
	{
		partUri = PackUriHelper.ValidatePartUri(partUri);
		if (contentType == null)
		{
			throw new ArgumentNullException("contentType");
		}
		Package.ThrowIfCompressionOptionInvalid(compressionOption);
		GetZipCompressionMethodFromOpcCompressionOption(compressionOption, out var compressionLevel);
		string entryName = ((PackUriHelper.ValidatedPartUri)partUri).PartUriString.Substring(1);
		ZipArchiveEntry zipArchiveEntry = _zipArchive.CreateEntry(entryName, compressionLevel);
		_contentTypeHelper.AddContentType((PackUriHelper.ValidatedPartUri)partUri, new ContentType(contentType), compressionLevel);
		return new ZipPackagePart(this, zipArchiveEntry.Archive, zipArchiveEntry, _zipStreamManager, (PackUriHelper.ValidatedPartUri)partUri, contentType, compressionOption);
	}

	protected override PackagePart GetPartCore(Uri partUri)
	{
		return null;
	}

	protected override void DeletePartCore(Uri partUri)
	{
		partUri = PackUriHelper.ValidatePartUri(partUri);
		string zipItemNameFromOpcName = GetZipItemNameFromOpcName(PackUriHelper.GetStringForPartUri(partUri));
		_zipArchive.GetEntry(zipItemNameFromOpcName)?.Delete();
		_contentTypeHelper.DeleteContentType((PackUriHelper.ValidatedPartUri)partUri);
	}

	protected override PackagePart[] GetPartsCore()
	{
		List<PackagePart> list = new List<PackagePart>(50);
		ReadOnlyCollection<ZipArchiveEntry> entries = _zipArchive.Entries;
		foreach (ZipArchiveEntry item in entries)
		{
			if (!IsZipItemValidOpcPartOrPiece(item.FullName))
			{
				continue;
			}
			Uri partUri = new Uri(GetOpcNameFromZipItemName(item.FullName), UriKind.Relative);
			if (PackUriHelper.TryValidatePartUri(partUri, out var validatedPartUri))
			{
				ContentType contentType = _contentTypeHelper.GetContentType(validatedPartUri);
				if (contentType != null)
				{
					list.Add(new ZipPackagePart(this, item.Archive, item, _zipStreamManager, validatedPartUri, contentType.ToString(), CompressionOption.Normal));
				}
			}
		}
		return list.ToArray();
	}

	protected override void FlushCore()
	{
		_contentTypeHelper.SaveToFile();
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing)
			{
				if (_contentTypeHelper != null)
				{
					_contentTypeHelper.SaveToFile();
				}
				if (_zipStreamManager != null)
				{
					_zipStreamManager.Dispose();
				}
				if (_zipArchive != null)
				{
					_zipArchive.Dispose();
				}
				if (_shouldCloseContainerStream)
				{
					_containerStream.Dispose();
				}
				_containerStream = null;
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	internal ZipPackage(Stream s, FileMode packageFileMode, FileAccess packageFileAccess)
		: base(packageFileAccess)
	{
		ZipArchive zipArchive = null;
		ContentTypeHelper contentTypeHelper = null;
		_packageFileMode = packageFileMode;
		_packageFileAccess = packageFileAccess;
		try
		{
			if (s.CanSeek)
			{
				switch (packageFileMode)
				{
				case FileMode.Open:
					if (s.Length == 0L)
					{
						throw new FileFormatException(System.SR.ZipZeroSizeFileIsNotValidArchive);
					}
					break;
				case FileMode.CreateNew:
					if (s.Length != 0L)
					{
						throw new IOException(System.SR.CreateNewOnNonEmptyStream);
					}
					break;
				case FileMode.Create:
					if (s.Length != 0L)
					{
						s.SetLength(0L);
					}
					break;
				}
			}
			ZipArchiveMode mode = ZipArchiveMode.Update;
			switch (packageFileAccess)
			{
			case FileAccess.Read:
				mode = ZipArchiveMode.Read;
				break;
			case FileAccess.Write:
				mode = ZipArchiveMode.Create;
				break;
			case FileAccess.ReadWrite:
				mode = ZipArchiveMode.Update;
				break;
			}
			zipArchive = new ZipArchive(s, mode, leaveOpen: true, Encoding.UTF8);
			_zipStreamManager = new ZipStreamManager(zipArchive, packageFileMode, packageFileAccess);
			contentTypeHelper = new ContentTypeHelper(zipArchive, packageFileMode, packageFileAccess, _zipStreamManager);
		}
		catch (InvalidDataException)
		{
			throw new FileFormatException("File contains corrupted data.");
		}
		catch
		{
			zipArchive?.Dispose();
			throw;
		}
		_containerStream = s;
		_shouldCloseContainerStream = false;
		_zipArchive = zipArchive;
		_contentTypeHelper = contentTypeHelper;
	}

	internal static string GetZipItemNameFromOpcName(string opcName)
	{
		return opcName.Substring(1);
	}

	internal static string GetOpcNameFromZipItemName(string zipItemName)
	{
		return "/" + zipItemName;
	}

	internal static void GetZipCompressionMethodFromOpcCompressionOption(CompressionOption compressionOption, out CompressionLevel compressionLevel)
	{
		switch (compressionOption)
		{
		default:
			compressionLevel = CompressionLevel.NoCompression;
			break;
		case CompressionOption.Normal:
			compressionLevel = CompressionLevel.Optimal;
			break;
		case CompressionOption.Maximum:
			compressionLevel = CompressionLevel.Optimal;
			break;
		case CompressionOption.Fast:
			compressionLevel = CompressionLevel.Fastest;
			break;
		case CompressionOption.SuperFast:
			compressionLevel = CompressionLevel.Fastest;
			break;
		}
	}

	private bool IsZipItemValidOpcPartOrPiece(string zipItemName)
	{
		if (zipItemName.StartsWith(ContentTypeHelper.ContentTypeFileName, StringComparison.OrdinalIgnoreCase))
		{
			return false;
		}
		if (zipItemName.StartsWith("/", StringComparison.Ordinal))
		{
			return false;
		}
		if (zipItemName.EndsWith("/", StringComparison.Ordinal))
		{
			return false;
		}
		return true;
	}
}
