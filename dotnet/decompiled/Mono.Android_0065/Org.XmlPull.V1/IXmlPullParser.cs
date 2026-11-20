using System;
using System.Collections.Generic;
using System.IO;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Org.XmlPull.V1;

[Register("org/xmlpull/v1/XmlPullParser", "", "Org.XmlPull.V1.IXmlPullParserInvoker")]
public interface IXmlPullParser : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("org/xmlpull/v1/XmlPullParser", typeof(IXmlPullParser), isInterface: true);

	[Register("TYPES")]
	static IList<string>? Types => Android.Runtime.JavaArray<string>.FromJniHandle(_members.StaticFields.GetObjectValue("TYPES.[Ljava/lang/String;").Handle, JniHandleOwnership.TransferLocalRef);

	int AttributeCount { get; }

	int ColumnNumber { get; }

	int Depth { get; }

	XmlPullParserNode EventType { get; }

	string? InputEncoding { get; }

	bool IsEmptyElementTag { get; }

	bool IsWhitespace { get; }

	int LineNumber { get; }

	string? Name { get; }

	string? Namespace { get; }

	string? PositionDescription { get; }

	string? Prefix { get; }

	string? Text { get; }

	void DefineEntityReplacementText(string? entityName, string? replacementText);

	string? GetAttributeName(int index);

	string? GetAttributeNamespace(int index);

	string? GetAttributePrefix(int index);

	string? GetAttributeType(int index);

	string? GetAttributeValue(int index);

	string? GetAttributeValue(string? @namespace, string? name);

	bool GetFeature(string? name);

	string? GetNamespace(string? prefix);

	int GetNamespaceCount(int depth);

	string? GetNamespacePrefix(int pos);

	string? GetNamespaceUri(int pos);

	Java.Lang.Object? GetProperty(string? name);

	char[]? GetTextCharacters(int[]? holderForStartAndLength);

	bool IsAttributeDefault(int index);

	XmlPullParserNode Next();

	XmlPullParserNode NextTag();

	string? NextText();

	XmlPullParserNode NextToken();

	void Require(XmlPullParserNode type, string? @namespace, string? name);

	void SetFeature(string? name, bool state);

	void SetInput(Stream? inputStream, string? inputEncoding);

	void SetInput(Reader? @in);

	void SetProperty(string? name, Java.Lang.Object? value);
}
