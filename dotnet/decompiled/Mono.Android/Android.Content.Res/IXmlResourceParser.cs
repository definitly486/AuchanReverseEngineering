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

	[Register("close", "()V", "GetCloseHandler:Android.Content.Res.IXmlResourceParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Close();

	[SupportedOSPlatform("android28.0")]
	[Register("getAttributeNamespace", "(I)Ljava/lang/String;", "GetGetAttributeNamespace_IHandler:Android.Content.Res.IXmlResourceParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 28)]
	new string? GetAttributeNamespace(int index);
}
