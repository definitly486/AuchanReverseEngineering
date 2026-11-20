using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Maui.Graphics;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
public sealed class XmlnsPrefixAttribute : Attribute
{
	[CompilerGenerated]
	private readonly string _003CXmlNamespace_003Ek__BackingField;

	[CompilerGenerated]
	private readonly string _003CPrefix_003Ek__BackingField;

	public XmlnsPrefixAttribute(string xmlNamespace, string prefix)
	{
		_003CXmlNamespace_003Ek__BackingField = xmlNamespace ?? throw new ArgumentNullException("xmlNamespace");
		_003CPrefix_003Ek__BackingField = prefix ?? throw new ArgumentNullException("prefix");
	}
}
