using System;
using Android.Runtime;
using Java.Interop;

namespace Org.Xml.Sax;

[Register("org/xml/sax/Attributes", "", "Org.Xml.Sax.IAttributesInvoker")]
public interface IAttributes : IJavaObject, IDisposable, IJavaPeerable
{
	int Length
	{
		[Register("getLength", "()I", "GetGetLengthHandler:Org.Xml.Sax.IAttributesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("getIndex", "(Ljava/lang/String;Ljava/lang/String;)I", "GetGetIndex_Ljava_lang_String_Ljava_lang_String_Handler:Org.Xml.Sax.IAttributesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetIndex(string? uri, string? localName);

	[Register("getIndex", "(Ljava/lang/String;)I", "GetGetIndex_Ljava_lang_String_Handler:Org.Xml.Sax.IAttributesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int GetIndex(string? qName);

	[Register("getLocalName", "(I)Ljava/lang/String;", "GetGetLocalName_IHandler:Org.Xml.Sax.IAttributesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetLocalName(int index);

	[Register("getQName", "(I)Ljava/lang/String;", "GetGetQName_IHandler:Org.Xml.Sax.IAttributesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetQName(int index);

	[Register("getType", "(I)Ljava/lang/String;", "GetGetType_IHandler:Org.Xml.Sax.IAttributesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetType(int index);

	[Register("getType", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", "GetGetType_Ljava_lang_String_Ljava_lang_String_Handler:Org.Xml.Sax.IAttributesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetType(string? uri, string? localName);

	[Register("getType", "(Ljava/lang/String;)Ljava/lang/String;", "GetGetType_Ljava_lang_String_Handler:Org.Xml.Sax.IAttributesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetType(string? qName);

	[Register("getURI", "(I)Ljava/lang/String;", "GetGetURI_IHandler:Org.Xml.Sax.IAttributesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetURI(int index);

	[Register("getValue", "(I)Ljava/lang/String;", "GetGetValue_IHandler:Org.Xml.Sax.IAttributesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetValue(int index);

	[Register("getValue", "(Ljava/lang/String;Ljava/lang/String;)Ljava/lang/String;", "GetGetValue_Ljava_lang_String_Ljava_lang_String_Handler:Org.Xml.Sax.IAttributesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetValue(string? uri, string? localName);

	[Register("getValue", "(Ljava/lang/String;)Ljava/lang/String;", "GetGetValue_Ljava_lang_String_Handler:Org.Xml.Sax.IAttributesInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string? GetValue(string? qName);
}
