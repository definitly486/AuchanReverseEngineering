namespace System.Xml.Serialization;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue)]
public class XmlTextAttribute : Attribute
{
	private Type _type;

	private string _dataType;

	public Type? Type => _type;

	public string DataType => _dataType ?? string.Empty;
}
