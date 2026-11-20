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

	int AttributeCount
	{
		[Register("getAttributeCount", "()I", "GetGetAttributeCountHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	int ColumnNumber
	{
		[Register("getColumnNumber", "()I", "GetGetColumnNumberHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	int Depth
	{
		[Register("getDepth", "()I", "GetGetDepthHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	XmlPullParserNode EventType
	{
		[Register("getEventType", "()I", "GetGetEventTypeHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	string? InputEncoding
	{
		[Register("getInputEncoding", "()Ljava/lang/String;", "GetGetInputEncodingHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsEmptyElementTag
	{
		[Register("isEmptyElementTag", "()Z", "GetIsEmptyElementTagHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsWhitespace
	{
		[Register("isWhitespace", "()Z", "GetIsWhitespaceHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	int LineNumber
	{
		[Register("getLineNumber", "()I", "GetGetLineNumberHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	string? Name
	{
		[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	string? Namespace
	{
		[Register("getNamespace", "()Ljava/lang/String;", "GetGetNamespaceHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	string? PositionDescription
	{
		[Register("getPositionDescription", "()Ljava/lang/String;", "GetGetPositionDescriptionHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	string? Prefix
	{
		[Register("getPrefix", "()Ljava/lang/String;", "GetGetPrefixHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	string? Text
	{
		[Register("getText", "()Ljava/lang/String;", "GetGetTextHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("defineEntityReplacementText", "(Ljava/lang/String;Ljava/lang/String;)V", "GetDefineEntityReplacementText_Ljava_lang_String_Ljava_lang_String_Handler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void DefineEntityReplacementText(string? entityName, string? replacementText);

	[Register("getAttributeName", "(I)Ljava/lang/String;", "GetGetAttributeName_IHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetAttributeName(int index);

	[Register("getAttributeNamespace", "(I)Ljava/lang/String;", "GetGetAttributeNamespace_IHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetAttributeNamespace(int index);

	[Register("getAttributePrefix", "(I)Ljava/lang/String;", "GetGetAttributePrefix_IHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetAttributePrefix(int index);

	[Register("getAttributeType", "(I)Ljava/lang/String;", "GetGetAttributeType_IHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetAttributeType(int index);

	[Register("getAttributeValue", "(I)Ljava/lang/String;", "GetGetAttributeValue_IHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetAttributeValue(int index);

	[Register("getAttributeValue", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", "GetGetAttributeValue_Ljava_lang_String_Ljava_lang_String_Handler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetAttributeValue(string? @namespace, string? name);

	[Register("getFeature", "(Ljava/lang/String;)Z", "GetGetFeature_Ljava_lang_String_Handler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool GetFeature(string? name);

	[Register("getNamespace", "(Ljava/lang/String;)Ljava/lang/String;", "GetGetNamespace_Ljava_lang_String_Handler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetNamespace(string? prefix);

	[Register("getNamespaceCount", "(I)I", "GetGetNamespaceCount_IHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetNamespaceCount(int depth);

	[Register("getNamespacePrefix", "(I)Ljava/lang/String;", "GetGetNamespacePrefix_IHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetNamespacePrefix(int pos);

	[Register("getNamespaceUri", "(I)Ljava/lang/String;", "GetGetNamespaceUri_IHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetNamespaceUri(int pos);

	[Register("getProperty", "(Ljava/lang/String;)Ljava/lang/Object;", "GetGetProperty_Ljava_lang_String_Handler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Java.Lang.Object? GetProperty(string? name);

	[Register("getTextCharacters", "([I)[C", "GetGetTextCharacters_arrayIHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	char[]? GetTextCharacters(int[]? holderForStartAndLength);

	[Register("isAttributeDefault", "(I)Z", "GetIsAttributeDefault_IHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool IsAttributeDefault(int index);

	[Register("next", "()I", "GetNextHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	XmlPullParserNode Next();

	[Register("nextTag", "()I", "GetNextTagHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	XmlPullParserNode NextTag();

	[Register("nextText", "()Ljava/lang/String;", "GetNextTextHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? NextText();

	[Register("nextToken", "()I", "GetNextTokenHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	XmlPullParserNode NextToken();

	[Register("require", "(ILjava/lang/String;Ljava/lang/String;)V", "GetRequire_ILjava_lang_String_Ljava_lang_String_Handler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Require(XmlPullParserNode type, string? @namespace, string? name);

	[Register("setFeature", "(Ljava/lang/String;Z)V", "GetSetFeature_Ljava_lang_String_ZHandler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void SetFeature(string? name, bool state);

	[Register("setInput", "(Ljava/io/InputStream;Ljava/lang/String;)V", "GetSetInput_Ljava_io_InputStream_Ljava_lang_String_Handler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void SetInput(Stream? inputStream, string? inputEncoding);

	[Register("setInput", "(Ljava/io/Reader;)V", "GetSetInput_Ljava_io_Reader_Handler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void SetInput(Reader? @in);

	[Register("setProperty", "(Ljava/lang/String;Ljava/lang/Object;)V", "GetSetProperty_Ljava_lang_String_Ljava_lang_Object_Handler:Org.XmlPull.V1.IXmlPullParserInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void SetProperty(string? name, Java.Lang.Object? value);
}
