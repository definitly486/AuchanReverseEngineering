using System;
using Android.Runtime;
using Java.Interop;

namespace Org.Xml.Sax;

[Register("org/xml/sax/DTDHandler", "", "Org.Xml.Sax.IDTDHandlerInvoker")]
public interface IDTDHandler : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("notationDecl", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "GetNotationDecl_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler:Org.Xml.Sax.IDTDHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void NotationDecl(string? name, string? publicId, string? systemId);

	[Register("unparsedEntityDecl", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "GetUnparsedEntityDecl_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler:Org.Xml.Sax.IDTDHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void UnparsedEntityDecl(string? name, string? publicId, string? systemId, string? notationName);
}
