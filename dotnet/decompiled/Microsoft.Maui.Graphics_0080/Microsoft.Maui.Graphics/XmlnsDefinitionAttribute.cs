using System;
using System.Diagnostics;

namespace Microsoft.Maui.Graphics;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
[DebuggerDisplay("{XmlNamespace}, {ClrNamespace}")]
internal sealed class XmlnsDefinitionAttribute : Attribute
{
	public string XmlNamespace { get; }

	public string ClrNamespace { get; }

	public XmlnsDefinitionAttribute(string xmlNamespace, string clrNamespace)
	{
		ClrNamespace = clrNamespace ?? throw new ArgumentNullException("xmlNamespace");
		XmlNamespace = xmlNamespace ?? throw new ArgumentNullException("clrNamespace");
	}
}
