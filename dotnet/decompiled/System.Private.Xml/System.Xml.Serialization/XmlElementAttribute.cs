using System.Xml.Schema;

namespace System.Xml.Serialization;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true)]
public class XmlElementAttribute : Attribute
{
	private string _elementName;

	private Type _type;

	private string _ns;

	private string _dataType;

	private bool _nullable;

	private bool _nullableSpecified;

	private XmlSchemaForm _form;

	private int _order = -1;

	public Type? Type => _type;

	public string ElementName => _elementName ?? string.Empty;

	public string? Namespace => _ns;

	public string DataType => _dataType ?? string.Empty;

	public bool IsNullable
	{
		get
		{
			return _nullable;
		}
		set
		{
			_nullable = value;
			_nullableSpecified = true;
		}
	}

	internal bool IsNullableSpecified => _nullableSpecified;

	public XmlSchemaForm Form => _form;

	public int Order => _order;

	public XmlElementAttribute()
	{
	}

	public XmlElementAttribute(string? elementName)
	{
		_elementName = elementName;
	}

	public XmlElementAttribute(string? elementName, Type? type)
	{
		_elementName = elementName;
		_type = type;
	}

	internal bool GetIsNullableSpecified()
	{
		return IsNullableSpecified;
	}
}
