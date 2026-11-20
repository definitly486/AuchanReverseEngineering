using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace System.Xml;

public sealed class XmlWriterSettings
{
	internal static readonly XmlWriterSettings s_defaultWriterSettings = new XmlWriterSettings
	{
		ReadOnly = true
	};

	private bool _useAsync;

	private Encoding _encoding;

	private bool _omitXmlDecl;

	private NewLineHandling _newLineHandling;

	private string _newLineChars;

	private string _indentChars;

	private bool _newLineOnAttributes;

	private bool _closeOutput;

	private NamespaceHandling _namespaceHandling;

	private ConformanceLevel _conformanceLevel;

	private bool _checkCharacters;

	private bool _writeEndDocumentOnClose;

	private bool _doNotEscapeUriAttributes;

	private bool _mergeCDataSections;

	private string _mediaType;

	private string _docTypeSystem;

	private string _docTypePublic;

	private XmlStandalone _standalone;

	private bool _autoXmlDecl;

	public bool Async => _useAsync;

	public Encoding Encoding
	{
		get
		{
			return _encoding;
		}
		[MemberNotNull("_encoding")]
		set
		{
			CheckReadOnly("Encoding");
			_encoding = value;
		}
	}

	public bool OmitXmlDeclaration
	{
		get
		{
			return _omitXmlDecl;
		}
		set
		{
			CheckReadOnly("OmitXmlDeclaration");
			_omitXmlDecl = value;
		}
	}

	public NewLineHandling NewLineHandling => _newLineHandling;

	public string NewLineChars => _newLineChars;

	public bool Indent
	{
		get
		{
			return IndentInternal == TriState.True;
		}
		set
		{
			CheckReadOnly("Indent");
			IndentInternal = (value ? TriState.True : TriState.False);
		}
	}

	public string IndentChars => _indentChars;

	public bool NewLineOnAttributes => _newLineOnAttributes;

	public bool CloseOutput
	{
		get
		{
			return _closeOutput;
		}
		set
		{
			CheckReadOnly("CloseOutput");
			_closeOutput = value;
		}
	}

	public ConformanceLevel ConformanceLevel
	{
		get
		{
			return _conformanceLevel;
		}
		set
		{
			CheckReadOnly("ConformanceLevel");
			if ((uint)value > 2u)
			{
				ThrowArgumentOutOfRangeException("value");
			}
			_conformanceLevel = value;
		}
	}

	public bool CheckCharacters => _checkCharacters;

	public NamespaceHandling NamespaceHandling
	{
		get
		{
			return _namespaceHandling;
		}
		set
		{
			CheckReadOnly("NamespaceHandling");
			ArgumentOutOfRangeException.ThrowIfGreaterThan((uint)value, 1u, "value");
			_namespaceHandling = value;
		}
	}

	public bool WriteEndDocumentOnClose => _writeEndDocumentOnClose;

	public XmlOutputMethod OutputMethod { get; internal set; }

	internal List<XmlQualifiedName> CDataSectionElements { get; private set; } = new List<XmlQualifiedName>();

	public bool DoNotEscapeUriAttributes => _doNotEscapeUriAttributes;

	internal bool MergeCDataSections => _mergeCDataSections;

	internal string? MediaType => _mediaType;

	internal string? DocTypeSystem => _docTypeSystem;

	internal string? DocTypePublic => _docTypePublic;

	internal XmlStandalone Standalone => _standalone;

	internal bool AutoXmlDeclaration => _autoXmlDecl;

	internal TriState IndentInternal { get; set; }

	private bool IsQuerySpecific
	{
		get
		{
			if (CDataSectionElements.Count == 0 && _docTypePublic == null && _docTypeSystem == null)
			{
				return _standalone == XmlStandalone.Yes;
			}
			return true;
		}
	}

	internal bool ReadOnly { get; set; }

	public XmlWriterSettings()
	{
		Initialize();
	}

	public XmlWriterSettings Clone()
	{
		XmlWriterSettings obj = (XmlWriterSettings)MemberwiseClone();
		obj.CDataSectionElements = new List<XmlQualifiedName>(CDataSectionElements);
		obj.ReadOnly = false;
		return obj;
	}

	internal XmlWriter CreateWriter(Stream output)
	{
		ArgumentNullException.ThrowIfNull(output, "output");
		XmlWriter xmlWriter;
		if (Encoding.WebName == "utf-8")
		{
			switch (OutputMethod)
			{
			case XmlOutputMethod.Xml:
				xmlWriter = (Indent ? new XmlUtf8RawTextWriterIndent(output, this) : new XmlUtf8RawTextWriter(output, this));
				break;
			case XmlOutputMethod.Html:
				xmlWriter = (Indent ? new HtmlUtf8RawTextWriterIndent(output, this) : new HtmlUtf8RawTextWriter(output, this));
				break;
			case XmlOutputMethod.Text:
				xmlWriter = new TextUtf8RawTextWriter(output, this);
				break;
			case XmlOutputMethod.AutoDetect:
				xmlWriter = new XmlAutoDetectWriter(output, this);
				break;
			default:
				return null;
			}
		}
		else
		{
			switch (OutputMethod)
			{
			case XmlOutputMethod.Xml:
				xmlWriter = (Indent ? new XmlEncodedRawTextWriterIndent(output, this) : new XmlEncodedRawTextWriter(output, this));
				break;
			case XmlOutputMethod.Html:
				xmlWriter = (Indent ? new HtmlEncodedRawTextWriterIndent(output, this) : new HtmlEncodedRawTextWriter(output, this));
				break;
			case XmlOutputMethod.Text:
				xmlWriter = new TextEncodedRawTextWriter(output, this);
				break;
			case XmlOutputMethod.AutoDetect:
				xmlWriter = new XmlAutoDetectWriter(output, this);
				break;
			default:
				return null;
			}
		}
		if (OutputMethod != XmlOutputMethod.AutoDetect && IsQuerySpecific)
		{
			xmlWriter = new QueryOutputWriter((XmlRawWriter)xmlWriter, this);
		}
		xmlWriter = new XmlWellFormedWriter(xmlWriter, this);
		if (_useAsync)
		{
			xmlWriter = new XmlAsyncCheckWriter(xmlWriter);
		}
		return xmlWriter;
	}

	internal XmlWriter CreateWriter(TextWriter output)
	{
		ArgumentNullException.ThrowIfNull(output, "output");
		XmlWriter xmlWriter;
		switch (OutputMethod)
		{
		case XmlOutputMethod.Xml:
			xmlWriter = (Indent ? new XmlEncodedRawTextWriterIndent(output, this) : new XmlEncodedRawTextWriter(output, this));
			break;
		case XmlOutputMethod.Html:
			xmlWriter = (Indent ? new HtmlEncodedRawTextWriterIndent(output, this) : new HtmlEncodedRawTextWriter(output, this));
			break;
		case XmlOutputMethod.Text:
			xmlWriter = new TextEncodedRawTextWriter(output, this);
			break;
		case XmlOutputMethod.AutoDetect:
			xmlWriter = new XmlAutoDetectWriter(output, this);
			break;
		default:
			return null;
		}
		if (OutputMethod != XmlOutputMethod.AutoDetect && IsQuerySpecific)
		{
			xmlWriter = new QueryOutputWriter((XmlRawWriter)xmlWriter, this);
		}
		xmlWriter = new XmlWellFormedWriter(xmlWriter, this);
		if (_useAsync)
		{
			xmlWriter = new XmlAsyncCheckWriter(xmlWriter);
		}
		return xmlWriter;
	}

	private void CheckReadOnly([CallerMemberName] string propertyName = null)
	{
		if (ReadOnly)
		{
			throw new XmlException("Xml_ReadOnlyProperty", GetType().Name + "." + propertyName);
		}
	}

	[MemberNotNull("_encoding")]
	[MemberNotNull("_newLineChars")]
	[MemberNotNull("_indentChars")]
	private void Initialize()
	{
		_encoding = System.Text.Encoding.UTF8;
		_omitXmlDecl = false;
		_newLineHandling = NewLineHandling.Replace;
		_newLineChars = "\n";
		IndentInternal = TriState.Unknown;
		_indentChars = "  ";
		_newLineOnAttributes = false;
		_closeOutput = false;
		_namespaceHandling = NamespaceHandling.Default;
		_conformanceLevel = ConformanceLevel.Document;
		_checkCharacters = true;
		_writeEndDocumentOnClose = true;
		OutputMethod = XmlOutputMethod.Xml;
		CDataSectionElements.Clear();
		_mergeCDataSections = false;
		_mediaType = null;
		_docTypeSystem = null;
		_docTypePublic = null;
		_standalone = XmlStandalone.Omit;
		_doNotEscapeUriAttributes = false;
		_useAsync = false;
		ReadOnly = false;
	}

	[DoesNotReturn]
	[StackTraceHidden]
	private static void ThrowArgumentOutOfRangeException(string paramName)
	{
		throw new ArgumentOutOfRangeException(paramName);
	}
}
