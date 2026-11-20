namespace System.Xml.Schema;

internal class ContentValidator
{
	private readonly XmlSchemaContentType _contentType;

	private bool _isOpen;

	private readonly bool _isEmptiable;

	public static readonly ContentValidator Empty = new ContentValidator(XmlSchemaContentType.Empty);

	public static readonly ContentValidator TextOnly = new ContentValidator(XmlSchemaContentType.TextOnly, isOpen: false, isEmptiable: false);

	public static readonly ContentValidator Mixed = new ContentValidator(XmlSchemaContentType.Mixed);

	public static readonly ContentValidator Any = new ContentValidator(XmlSchemaContentType.Mixed, isOpen: true, isEmptiable: true);

	public XmlSchemaContentType ContentType => _contentType;

	public virtual bool IsEmptiable => _isEmptiable;

	public bool IsOpen
	{
		get
		{
			if (_contentType == XmlSchemaContentType.TextOnly || _contentType == XmlSchemaContentType.Empty)
			{
				return false;
			}
			return _isOpen;
		}
		set
		{
			_isOpen = value;
		}
	}

	public ContentValidator(XmlSchemaContentType contentType)
	{
		_contentType = contentType;
		_isEmptiable = true;
	}

	protected ContentValidator(XmlSchemaContentType contentType, bool isOpen, bool isEmptiable)
	{
		_contentType = contentType;
		_isOpen = isOpen;
		_isEmptiable = isEmptiable;
	}
}
