using System.Xml.Schema;

namespace System.Xml.Serialization;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true)]
public class XmlArrayItemAttribute : Attribute
{
	private string _elementName;

	private Type _type;

	private string _ns;

	private string _dataType;

	private bool _nullable;

	private bool _nullableSpecified;

	private XmlSchemaForm _form;

	private int _nestingLevel;

	public Type? Type => _type;

	public string ElementName => _elementName ?? string.Empty;

	public string? Namespace => _ns;

	public int NestingLevel
	{
		get
		{
			return _nestingLevel;
		}
		set
		{
			_nestingLevel = value;
		}
	}

	public string DataType => _dataType ?? string.Empty;

	public bool IsNullable => _nullable;

	internal bool IsNullableSpecified => _nullableSpecified;

	public XmlSchemaForm Form => _form;

	internal bool GetIsNullableSpecified()
	{
		return IsNullableSpecified;
	}
}
