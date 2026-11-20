using System;
using System.Runtime.Versioning;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Org.XmlPull.V1;

namespace Android.Content.Res;

[Register("android/content/res/XmlResourceParser", "", "Android.Content.Res.IXmlResourceParserInvoker")]
public interface IXmlResourceParser : IAttributeSet, IJavaObject, IDisposable, IJavaPeerable, IXmlPullParser
{
	new int AttributeCount { get; }

	new string PositionDescription { get; }

	new string GetAttributeName(int pos);

	new string GetAttributeValue(int pos);

	new string? GetAttributeValue(string? ns, string? name);

	void Close();

	[SupportedOSPlatform("android28.0")]
	new string? GetAttributeNamespace(int index);
}
