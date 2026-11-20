namespace System.Xml.Serialization;

[AttributeUsage(AttributeTargets.Field)]
public class XmlEnumAttribute : Attribute
{
	private string _name;

	public string? Name => _name;

	public XmlEnumAttribute()
	{
	}

	public XmlEnumAttribute(string? name)
	{
		_name = name;
	}
}
