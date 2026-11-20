using System.Xml.Schema;

namespace System.Xml.Serialization;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false)]
public class XmlArrayAttribute : Attribute
{
	private string _elementName;

	private string _ns;

	private bool _nullable;

	private XmlSchemaForm _form;

	private int _order = -1;

	public string ElementName => _elementName ?? string.Empty;

	public string? Namespace => _ns;

	public bool IsNullable => _nullable;

	public XmlSchemaForm Form => _form;

	public int Order => _order;
}
