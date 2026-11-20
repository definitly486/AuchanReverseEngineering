using System.Text;

namespace System.Xml;

public class XmlParserContext
{
	private XmlNameTable _nt;

	private XmlNamespaceManager _nsMgr;

	private string _docTypeName = string.Empty;

	private string _pubId = string.Empty;

	private string _sysId = string.Empty;

	private string _internalSubset = string.Empty;

	private string _xmlLang = string.Empty;

	private XmlSpace _xmlSpace;

	private string _baseURI = string.Empty;

	private Encoding _encoding;

	public XmlNameTable? NameTable => _nt;

	public XmlNamespaceManager? NamespaceManager => _nsMgr;

	public string DocTypeName => _docTypeName;

	public string PublicId => _pubId;

	public string SystemId => _sysId;

	public string BaseURI => _baseURI;

	public string InternalSubset => _internalSubset;

	public string XmlLang => _xmlLang;

	public XmlSpace XmlSpace => _xmlSpace;

	public Encoding? Encoding => _encoding;

	internal bool HasDtdInfo
	{
		get
		{
			if (!(_internalSubset != string.Empty) && !(_pubId != string.Empty))
			{
				return _sysId != string.Empty;
			}
			return true;
		}
	}

	public XmlParserContext(XmlNameTable? nt, XmlNamespaceManager? nsMgr, string? xmlLang, XmlSpace xmlSpace)
		: this(nt, nsMgr, null, null, null, null, string.Empty, xmlLang, xmlSpace)
	{
	}

	public XmlParserContext(XmlNameTable? nt, XmlNamespaceManager? nsMgr, string? docTypeName, string? pubId, string? sysId, string? internalSubset, string? baseURI, string? xmlLang, XmlSpace xmlSpace)
		: this(nt, nsMgr, docTypeName, pubId, sysId, internalSubset, baseURI, xmlLang, xmlSpace, null)
	{
	}

	public XmlParserContext(XmlNameTable? nt, XmlNamespaceManager? nsMgr, string? docTypeName, string? pubId, string? sysId, string? internalSubset, string? baseURI, string? xmlLang, XmlSpace xmlSpace, Encoding? enc)
	{
		if (nsMgr != null)
		{
			if (nt == null)
			{
				_nt = nsMgr.NameTable;
			}
			else
			{
				if (nt != nsMgr.NameTable)
				{
					throw new XmlException("Xml_NotSameNametable", string.Empty);
				}
				_nt = nt;
			}
		}
		else
		{
			_nt = nt;
		}
		_nsMgr = nsMgr;
		_docTypeName = docTypeName ?? string.Empty;
		_pubId = pubId ?? string.Empty;
		_sysId = sysId ?? string.Empty;
		_internalSubset = internalSubset ?? string.Empty;
		_baseURI = baseURI ?? string.Empty;
		_xmlLang = xmlLang ?? string.Empty;
		_xmlSpace = xmlSpace;
		_encoding = enc;
	}
}
