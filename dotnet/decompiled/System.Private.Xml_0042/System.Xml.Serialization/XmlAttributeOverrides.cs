using System.Collections.Generic;

namespace System.Xml.Serialization;

public class XmlAttributeOverrides
{
	private readonly Dictionary<Type, Dictionary<string, XmlAttributes>> _types = new Dictionary<Type, Dictionary<string, XmlAttributes>>();

	public XmlAttributes? this[Type type] => this[type, string.Empty];

	public XmlAttributes? this[Type type, string member]
	{
		get
		{
			if (!_types.TryGetValue(type, out var value) || !value.TryGetValue(member, out var value2))
			{
				return null;
			}
			return value2;
		}
	}
}
