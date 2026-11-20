using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml.Schema;

namespace System.Xml;

[DefaultMember("Item")]
[DebuggerDisplay("{DebuggerDisplayProxy}")]
[DebuggerDisplay("{DebuggerDisplayProxy}")]
public abstract class XmlReader : IDisposable
{
	[DebuggerDisplay("{ToString()}")]
	private readonly struct XmlReaderDebuggerDisplayProxy
	{
		private readonly XmlReader _reader;

		internal XmlReaderDebuggerDisplayProxy(XmlReader reader)
		{
			_reader = reader;
		}

		public override string ToString()
		{
			XmlNodeType nodeType = _reader.NodeType;
			string text = nodeType.ToString();
			switch (nodeType)
			{
			case XmlNodeType.Element:
			case XmlNodeType.EntityReference:
			case XmlNodeType.EndElement:
			case XmlNodeType.EndEntity:
				text = text + ", Name=\"" + _reader.Name + "\"";
				break;
			case XmlNodeType.Attribute:
			case XmlNodeType.ProcessingInstruction:
				text += $", Name=\"{_reader.Name}\", Value=\"{XmlConvert.EscapeValueForDebuggerDisplay(_reader.Value)}\"";
				break;
			case XmlNodeType.Text:
			case XmlNodeType.CDATA:
			case XmlNodeType.Comment:
			case XmlNodeType.Whitespace:
			case XmlNodeType.SignificantWhitespace:
			case XmlNodeType.XmlDeclaration:
				text = text + ", Value=\"" + XmlConvert.EscapeValueForDebuggerDisplay(_reader.Value) + "\"";
				break;
			case XmlNodeType.DocumentType:
				text = text + ", Name=\"" + _reader.Name + "'";
				text = text + ", SYSTEM=\"" + _reader.GetAttribute("SYSTEM") + "\"";
				text = text + ", PUBLIC=\"" + _reader.GetAttribute("PUBLIC") + "\"";
				text = text + ", Value=\"" + XmlConvert.EscapeValueForDebuggerDisplay(_reader.Value) + "\"";
				break;
			}
			return text;
		}
	}

	public virtual XmlReaderSettings? Settings => null;

	public abstract XmlNodeType NodeType { get; }

	public virtual string Name
	{
		get
		{
			if (Prefix.Length != 0)
			{
				return NameTable.Add(Prefix + ":" + LocalName);
			}
			return LocalName;
		}
	}

	public abstract string LocalName { get; }

	public abstract string NamespaceURI { get; }

	public abstract string Prefix { get; }

	public abstract string Value { get; }

	public abstract int Depth { get; }

	public abstract string BaseURI { get; }

	public abstract bool IsEmptyElement { get; }

	public virtual bool IsDefault => false;

	public virtual char QuoteChar => '"';

	public virtual XmlSpace XmlSpace => XmlSpace.None;

	public virtual string XmlLang => string.Empty;

	public virtual IXmlSchemaInfo? SchemaInfo => this as IXmlSchemaInfo;

	public virtual Type ValueType => typeof(string);

	public abstract int AttributeCount { get; }

	public abstract bool EOF { get; }

	public abstract ReadState ReadState { get; }

	public abstract XmlNameTable NameTable { get; }

	public virtual bool CanResolveEntity => false;

	public virtual bool CanReadBinaryContent => false;

	public virtual bool CanReadValueChunk => false;

	public virtual bool HasAttributes => AttributeCount > 0;

	internal virtual XmlNamespaceManager? NamespaceManager => null;

	internal bool IsDefaultInternal
	{
		get
		{
			if (IsDefault)
			{
				return true;
			}
			return SchemaInfo?.IsDefault ?? false;
		}
	}

	internal virtual IDtdInfo? DtdInfo => null;

	private object DebuggerDisplayProxy => new XmlReaderDebuggerDisplayProxy(this);

	public virtual string ReadContentAsString()
	{
		if (!CanReadContentAs())
		{
			throw CreateReadContentAsException("ReadContentAsString");
		}
		return InternalReadContentAsString();
	}

	public virtual string ReadElementContentAsString()
	{
		if (SetupReadElementContentAsXxx("ReadElementContentAsString"))
		{
			string result = ReadContentAsString();
			FinishReadElementContentAsXxx();
			return result;
		}
		return string.Empty;
	}

	public virtual string ReadElementContentAsString(string localName, string namespaceURI)
	{
		CheckElement(localName, namespaceURI);
		return ReadElementContentAsString();
	}

	public abstract string? GetAttribute(string name);

	public abstract string? GetAttribute(string name, string? namespaceURI);

	public abstract string GetAttribute(int i);

	public abstract bool MoveToAttribute(string name);

	public abstract bool MoveToAttribute(string name, string? ns);

	public virtual void MoveToAttribute(int i)
	{
		ArgumentOutOfRangeException.ThrowIfNegative(i, "i");
		ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(i, AttributeCount, "i");
		MoveToElement();
		MoveToFirstAttribute();
		for (int j = 0; j < i; j++)
		{
			MoveToNextAttribute();
		}
	}

	public abstract bool MoveToFirstAttribute();

	public abstract bool MoveToNextAttribute();

	public abstract bool MoveToElement();

	public abstract bool ReadAttributeValue();

	public abstract bool Read();

	public virtual void Close()
	{
	}

	public virtual void Skip()
	{
		if (ReadState == ReadState.Interactive)
		{
			SkipSubtree();
		}
	}

	public abstract string? LookupNamespace(string prefix);

	public abstract void ResolveEntity();

	public virtual int ReadElementContentAsBase64(byte[] buffer, int index, int count)
	{
		throw new NotSupportedException(System.SR.Format("Xml_ReadBinaryContentNotSupported", "ReadElementContentAsBase64"));
	}

	public virtual int ReadElementContentAsBinHex(byte[] buffer, int index, int count)
	{
		throw new NotSupportedException(System.SR.Format("Xml_ReadBinaryContentNotSupported", "ReadElementContentAsBinHex"));
	}

	public virtual int ReadValueChunk(char[] buffer, int index, int count)
	{
		throw new NotSupportedException("Xml_ReadValueChunkNotSupported");
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual string ReadString()
	{
		if (ReadState != ReadState.Interactive)
		{
			return string.Empty;
		}
		MoveToElement();
		if (NodeType == XmlNodeType.Element)
		{
			if (IsEmptyElement)
			{
				return string.Empty;
			}
			if (!Read())
			{
				throw new InvalidOperationException("Xml_InvalidOperation");
			}
			if (NodeType == XmlNodeType.EndElement)
			{
				return string.Empty;
			}
		}
		string text = string.Empty;
		while (IsTextualNode(NodeType))
		{
			text += Value;
			if (!Read())
			{
				break;
			}
		}
		return text;
	}

	public virtual XmlNodeType MoveToContent()
	{
		do
		{
			switch (NodeType)
			{
			case XmlNodeType.Attribute:
				MoveToElement();
				return NodeType;
			case XmlNodeType.Element:
			case XmlNodeType.Text:
			case XmlNodeType.CDATA:
			case XmlNodeType.EntityReference:
			case XmlNodeType.EndElement:
			case XmlNodeType.EndEntity:
				return NodeType;
			}
		}
		while (Read());
		return NodeType;
	}

	public virtual void ReadStartElement()
	{
		if (MoveToContent() != XmlNodeType.Element)
		{
			throw new XmlException("Xml_InvalidNodeType", NodeType.ToString(), this as IXmlLineInfo);
		}
		Read();
	}

	public virtual void ReadStartElement(string name)
	{
		if (MoveToContent() != XmlNodeType.Element)
		{
			throw new XmlException("Xml_InvalidNodeType", NodeType.ToString(), this as IXmlLineInfo);
		}
		if (Name == name)
		{
			Read();
			return;
		}
		throw new XmlException("Xml_ElementNotFound", name, this as IXmlLineInfo);
	}

	public virtual void ReadStartElement(string localname, string ns)
	{
		if (MoveToContent() != XmlNodeType.Element)
		{
			throw new XmlException("Xml_InvalidNodeType", NodeType.ToString(), this as IXmlLineInfo);
		}
		if (LocalName == localname && NamespaceURI == ns)
		{
			Read();
			return;
		}
		throw new XmlException("Xml_ElementNotFoundNs", new string[2] { localname, ns }, this as IXmlLineInfo);
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual string ReadElementString()
	{
		string result = string.Empty;
		if (MoveToContent() != XmlNodeType.Element)
		{
			throw new XmlException("Xml_InvalidNodeType", NodeType.ToString(), this as IXmlLineInfo);
		}
		if (!IsEmptyElement)
		{
			Read();
			result = ReadString();
			if (NodeType != XmlNodeType.EndElement)
			{
				throw new XmlException("Xml_UnexpectedNodeInSimpleContent", new string[2]
				{
					NodeType.ToString(),
					"ReadElementString"
				}, this as IXmlLineInfo);
			}
			Read();
		}
		else
		{
			Read();
		}
		return result;
	}

	public virtual void ReadEndElement()
	{
		if (MoveToContent() != XmlNodeType.EndElement)
		{
			throw new XmlException("Xml_InvalidNodeType", NodeType.ToString(), this as IXmlLineInfo);
		}
		Read();
	}

	public virtual bool IsStartElement()
	{
		return MoveToContent() == XmlNodeType.Element;
	}

	public virtual bool IsStartElement(string name)
	{
		if (MoveToContent() == XmlNodeType.Element)
		{
			return Name == name;
		}
		return false;
	}

	public virtual bool IsStartElement(string localname, string ns)
	{
		if (MoveToContent() == XmlNodeType.Element && LocalName == localname)
		{
			return NamespaceURI == ns;
		}
		return false;
	}

	public static bool IsName(string str)
	{
		ArgumentNullException.ThrowIfNull(str, "str");
		return ValidateNames.IsNameNoNamespaces(str);
	}

	public virtual string ReadInnerXml()
	{
		if (ReadState != ReadState.Interactive)
		{
			return string.Empty;
		}
		if (NodeType != XmlNodeType.Attribute && NodeType != XmlNodeType.Element)
		{
			Read();
			return string.Empty;
		}
		StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
		using (XmlTextWriter xmlTextWriter = CreateWriterForInnerOuterXml(stringWriter))
		{
			if (NodeType == XmlNodeType.Attribute)
			{
				xmlTextWriter.QuoteChar = QuoteChar;
				WriteAttributeValue(xmlTextWriter);
			}
			if (NodeType == XmlNodeType.Element)
			{
				WriteNode(xmlTextWriter, defattr: false);
			}
		}
		return stringWriter.ToString();
	}

	private void WriteNode(XmlTextWriter xtw, bool defattr)
	{
		int num = ((NodeType == XmlNodeType.None) ? (-1) : Depth);
		while (Read() && num < Depth)
		{
			switch (NodeType)
			{
			case XmlNodeType.Element:
				xtw.WriteStartElement(Prefix, LocalName, NamespaceURI);
				xtw.QuoteChar = QuoteChar;
				xtw.WriteAttributes(this, defattr);
				if (IsEmptyElement)
				{
					xtw.WriteEndElement();
				}
				break;
			case XmlNodeType.Text:
				xtw.WriteString(Value);
				break;
			case XmlNodeType.Whitespace:
			case XmlNodeType.SignificantWhitespace:
				xtw.WriteWhitespace(Value);
				break;
			case XmlNodeType.CDATA:
				xtw.WriteCData(Value);
				break;
			case XmlNodeType.EntityReference:
				xtw.WriteEntityRef(Name);
				break;
			case XmlNodeType.ProcessingInstruction:
			case XmlNodeType.XmlDeclaration:
				xtw.WriteProcessingInstruction(Name, Value);
				break;
			case XmlNodeType.DocumentType:
				xtw.WriteDocType(Name, GetAttribute("PUBLIC"), GetAttribute("SYSTEM"), Value);
				break;
			case XmlNodeType.Comment:
				xtw.WriteComment(Value);
				break;
			case XmlNodeType.EndElement:
				xtw.WriteFullEndElement();
				break;
			}
		}
		if (num == Depth && NodeType == XmlNodeType.EndElement)
		{
			Read();
		}
	}

	private void WriteAttributeValue(XmlTextWriter xtw)
	{
		string name = Name;
		while (ReadAttributeValue())
		{
			if (NodeType == XmlNodeType.EntityReference)
			{
				xtw.WriteEntityRef(Name);
			}
			else
			{
				xtw.WriteString(Value);
			}
		}
		MoveToAttribute(name);
	}

	private XmlTextWriter CreateWriterForInnerOuterXml(StringWriter sw)
	{
		XmlTextWriter xmlTextWriter = new XmlTextWriter(sw);
		SetNamespacesFlag(xmlTextWriter);
		return xmlTextWriter;
	}

	private void SetNamespacesFlag(XmlTextWriter xtw)
	{
		if (this is XmlTextReader xmlTextReader)
		{
			xtw.Namespaces = xmlTextReader.Namespaces;
		}
		else if (this is XmlValidatingReader xmlValidatingReader)
		{
			xtw.Namespaces = xmlValidatingReader.Namespaces;
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing && ReadState != ReadState.Closed)
		{
			Close();
		}
	}

	internal static bool IsTextualNode(XmlNodeType nodeType)
	{
		return (0x6018uL & (ulong)(1 << (int)nodeType)) != 0;
	}

	internal static bool CanReadContentAs(XmlNodeType nodeType)
	{
		return (0x1E1BCuL & (ulong)(1 << (int)nodeType)) != 0;
	}

	internal static bool HasValueInternal(XmlNodeType nodeType)
	{
		return (0x2659CuL & (ulong)(1 << (int)nodeType)) != 0;
	}

	private bool SkipSubtree()
	{
		MoveToElement();
		if (NodeType == XmlNodeType.Element && !IsEmptyElement)
		{
			int depth = Depth;
			while (Read() && depth < Depth)
			{
			}
			if (NodeType == XmlNodeType.EndElement)
			{
				return Read();
			}
			return false;
		}
		return Read();
	}

	internal void CheckElement(string localName, string namespaceURI)
	{
		ArgumentException.ThrowIfNullOrEmpty(localName, "localName");
		ArgumentNullException.ThrowIfNull(namespaceURI, "namespaceURI");
		if (NodeType != XmlNodeType.Element)
		{
			throw new XmlException("Xml_InvalidNodeType", NodeType.ToString(), this as IXmlLineInfo);
		}
		if (LocalName != localName || NamespaceURI != namespaceURI)
		{
			throw new XmlException("Xml_ElementNotFoundNs", new string[2] { localName, namespaceURI }, this as IXmlLineInfo);
		}
	}

	internal Exception CreateReadContentAsException(string methodName)
	{
		return CreateReadContentAsException(methodName, NodeType, this as IXmlLineInfo);
	}

	internal Exception CreateReadElementContentAsException(string methodName)
	{
		return CreateReadElementContentAsException(methodName, NodeType, this as IXmlLineInfo);
	}

	internal bool CanReadContentAs()
	{
		return CanReadContentAs(NodeType);
	}

	internal static Exception CreateReadContentAsException(string methodName, XmlNodeType nodeType, IXmlLineInfo lineInfo)
	{
		return new InvalidOperationException(AddLineInfo(System.SR.Format("Xml_InvalidReadContentAs", methodName, nodeType), lineInfo));
	}

	internal static Exception CreateReadElementContentAsException(string methodName, XmlNodeType nodeType, IXmlLineInfo lineInfo)
	{
		return new InvalidOperationException(AddLineInfo(System.SR.Format("Xml_InvalidReadElementContentAs", methodName, nodeType), lineInfo));
	}

	private static string AddLineInfo(string message, IXmlLineInfo lineInfo)
	{
		if (lineInfo != null)
		{
			object[] args = new object[2]
			{
				lineInfo.LineNumber.ToString(CultureInfo.InvariantCulture),
				lineInfo.LinePosition.ToString(CultureInfo.InvariantCulture)
			};
			return message + " " + System.SR.Format("Xml_ErrorPosition", args);
		}
		return message;
	}

	internal string InternalReadContentAsString()
	{
		string text = string.Empty;
		StringBuilder stringBuilder = null;
		bool num;
		do
		{
			switch (NodeType)
			{
			case XmlNodeType.Attribute:
				return Value;
			case XmlNodeType.Text:
			case XmlNodeType.CDATA:
			case XmlNodeType.Whitespace:
			case XmlNodeType.SignificantWhitespace:
				if (text.Length == 0)
				{
					text = Value;
				}
				else
				{
					if (stringBuilder == null)
					{
						stringBuilder = new StringBuilder().Append(text);
					}
					stringBuilder.Append(Value);
				}
				goto case XmlNodeType.ProcessingInstruction;
			case XmlNodeType.EntityReference:
				if (!CanResolveEntity)
				{
					break;
				}
				ResolveEntity();
				goto case XmlNodeType.ProcessingInstruction;
			case XmlNodeType.ProcessingInstruction:
			case XmlNodeType.Comment:
			case XmlNodeType.EndEntity:
				num = ((AttributeCount != 0) ? ReadAttributeValue() : Read());
				continue;
			}
			break;
		}
		while (num);
		if (stringBuilder != null)
		{
			return stringBuilder.ToString();
		}
		return text;
	}

	private bool SetupReadElementContentAsXxx(string methodName)
	{
		if (NodeType != XmlNodeType.Element)
		{
			throw CreateReadElementContentAsException(methodName);
		}
		bool isEmptyElement = IsEmptyElement;
		Read();
		if (isEmptyElement)
		{
			return false;
		}
		switch (NodeType)
		{
		case XmlNodeType.EndElement:
			Read();
			return false;
		case XmlNodeType.Element:
			throw new XmlException("Xml_MixedReadElementContentAs", string.Empty, this as IXmlLineInfo);
		default:
			return true;
		}
	}

	private void FinishReadElementContentAsXxx()
	{
		if (NodeType != XmlNodeType.EndElement)
		{
			throw new XmlException("Xml_InvalidNodeType", NodeType.ToString());
		}
		Read();
	}

	internal static ConformanceLevel GetV1ConformanceLevel(XmlReader reader)
	{
		return GetXmlTextReaderImpl(reader)?.V1ComformanceLevel ?? ConformanceLevel.Document;
	}

	private static XmlTextReaderImpl GetXmlTextReaderImpl(XmlReader reader)
	{
		if (reader is XmlTextReaderImpl result)
		{
			return result;
		}
		if (reader is XmlTextReader xmlTextReader)
		{
			return xmlTextReader.Impl;
		}
		if (reader is XmlValidatingReaderImpl xmlValidatingReaderImpl)
		{
			return xmlValidatingReaderImpl.ReaderImpl;
		}
		if (reader is XmlValidatingReader xmlValidatingReader)
		{
			return xmlValidatingReader.Impl.ReaderImpl;
		}
		return null;
	}

	public static XmlReader Create(Stream input)
	{
		ArgumentNullException.ThrowIfNull(input, "input");
		return new XmlTextReaderImpl(input, null, 0, XmlReaderSettings.s_defaultReaderSettings, null, string.Empty, null, closeInput: false);
	}

	public static XmlReader Create(Stream input, XmlReaderSettings? settings)
	{
		return Create(input, settings, string.Empty);
	}

	public static XmlReader Create(Stream input, XmlReaderSettings? settings, string? baseUri)
	{
		if (settings == null)
		{
			settings = XmlReaderSettings.s_defaultReaderSettings;
		}
		return settings.CreateReader(input, null, baseUri, null);
	}

	public static XmlReader Create(TextReader input)
	{
		ArgumentNullException.ThrowIfNull(input, "input");
		return new XmlTextReaderImpl(input, XmlReaderSettings.s_defaultReaderSettings, string.Empty, null);
	}

	public static XmlReader Create(TextReader input, XmlReaderSettings? settings, string? baseUri)
	{
		if (settings == null)
		{
			settings = XmlReaderSettings.s_defaultReaderSettings;
		}
		return settings.CreateReader(input, baseUri, null);
	}

	internal static XmlReader CreateSqlReader(Stream input, XmlReaderSettings settings, XmlParserContext inputContext)
	{
		ArgumentNullException.ThrowIfNull(input, "input");
		if (settings == null)
		{
			settings = XmlReaderSettings.s_defaultReaderSettings;
		}
		byte[] array = new byte[CalcBufferSize(input)];
		int minimumBytes = Math.Min(array.Length, 2);
		int num = input.ReadAtLeast(array, minimumBytes, throwOnEndOfStream: false);
		XmlReader xmlReader;
		if (num >= 2 && array[0] == 223 && array[1] == byte.MaxValue)
		{
			if (inputContext != null)
			{
				throw new ArgumentException("XmlBinary_NoParserContext", "inputContext");
			}
			xmlReader = new XmlSqlBinaryReader(input, array, num, string.Empty, settings.CloseInput, settings);
		}
		else
		{
			xmlReader = new XmlTextReaderImpl(input, array, num, settings, null, string.Empty, inputContext, settings.CloseInput);
		}
		if (settings.ValidationType != ValidationType.None)
		{
			xmlReader = settings.AddValidation(xmlReader);
		}
		if (settings.Async)
		{
			xmlReader = XmlAsyncCheckReader.CreateAsyncCheckWrapper(xmlReader);
		}
		return xmlReader;
	}

	internal static int CalcBufferSize(Stream input)
	{
		int num = 4096;
		if (input.CanSeek)
		{
			long length = input.Length;
			if (length < num)
			{
				num = (int)length;
			}
			else if (length > 65536)
			{
				num = 8192;
			}
		}
		return num;
	}
}
