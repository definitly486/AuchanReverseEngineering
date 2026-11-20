using System.Diagnostics.CodeAnalysis;
using System.Xml.Schema;

namespace System.Xml.Serialization;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
public class XmlAttributeAttribute : Attribute
{
	private string _attributeName;

	private Type _type;

	private string _ns;

	private string _dataType;

	private XmlSchemaForm _form;

	public Type? Type => _type;

	public string AttributeName => _attributeName ?? string.Empty;

	public string? Namespace => _ns;

	public string DataType
	{
		get
		{
			return _dataType ?? string.Empty;
		}
		[param: AllowNull]
		set
		{
			_dataType = value;
		}
	}

	public XmlSchemaForm Form => _form;

	public XmlAttributeAttribute()
	{
	}

	public XmlAttributeAttribute(string? attributeName)
	{
		_attributeName = attributeName;
	}
}
