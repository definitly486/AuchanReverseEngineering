namespace System.Xml.Linq;

public class XDocumentType : XNode
{
	private string _name;

	private string _publicId;

	private string _systemId;

	private string _internalSubset;

	public string? InternalSubset
	{
		get
		{
			return _internalSubset;
		}
		set
		{
			bool num = NotifyChanging(this, XObjectChangeEventArgs.Value);
			_internalSubset = value;
			if (num)
			{
				NotifyChanged(this, XObjectChangeEventArgs.Value);
			}
		}
	}

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			value = XmlConvert.VerifyName(value);
			bool num = NotifyChanging(this, XObjectChangeEventArgs.Name);
			_name = value;
			if (num)
			{
				NotifyChanged(this, XObjectChangeEventArgs.Name);
			}
		}
	}

	public override XmlNodeType NodeType => XmlNodeType.DocumentType;

	public string? PublicId
	{
		get
		{
			return _publicId;
		}
		set
		{
			bool num = NotifyChanging(this, XObjectChangeEventArgs.Value);
			_publicId = value;
			if (num)
			{
				NotifyChanged(this, XObjectChangeEventArgs.Value);
			}
		}
	}

	public string? SystemId
	{
		get
		{
			return _systemId;
		}
		set
		{
			bool num = NotifyChanging(this, XObjectChangeEventArgs.Value);
			_systemId = value;
			if (num)
			{
				NotifyChanged(this, XObjectChangeEventArgs.Value);
			}
		}
	}

	public XDocumentType(string name, string? publicId, string? systemId, string? internalSubset)
	{
		_name = XmlConvert.VerifyName(name);
		_publicId = publicId;
		_systemId = systemId;
		_internalSubset = internalSubset;
	}

	public XDocumentType(XDocumentType other)
	{
		ArgumentNullException.ThrowIfNull(other, "other");
		_name = other._name;
		_publicId = other._publicId;
		_systemId = other._systemId;
		_internalSubset = other._internalSubset;
	}

	public override void WriteTo(XmlWriter writer)
	{
		ArgumentNullException.ThrowIfNull(writer, "writer");
		writer.WriteDocType(_name, _publicId, _systemId, _internalSubset);
	}

	internal override XNode CloneNode()
	{
		return new XDocumentType(this);
	}
}
