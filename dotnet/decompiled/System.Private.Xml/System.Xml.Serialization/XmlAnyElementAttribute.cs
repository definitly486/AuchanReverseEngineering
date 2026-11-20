namespace System.Xml.Serialization;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true)]
public class XmlAnyElementAttribute : Attribute
{
	private string _name;

	private string _ns;

	private int _order = -1;

	private bool _nsSpecified;

	public string Name => _name ?? string.Empty;

	public string? Namespace => _ns;

	public int Order => _order;

	internal bool NamespaceSpecified => _nsSpecified;

	internal bool GetNamespaceSpecified()
	{
		return NamespaceSpecified;
	}
}
