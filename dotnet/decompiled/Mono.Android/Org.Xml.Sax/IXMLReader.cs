using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Org.Xml.Sax;

[Register("org/xml/sax/XMLReader", "", "Org.Xml.Sax.IXMLReaderInvoker")]
public interface IXMLReader : IJavaObject, IDisposable, IJavaPeerable
{
	IContentHandler? ContentHandler
	{
		[Register("getContentHandler", "()Lorg/xml/sax/ContentHandler;", "GetGetContentHandlerHandler:Org.Xml.Sax.IXMLReaderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
		[Register("setContentHandler", "(Lorg/xml/sax/ContentHandler;)V", "GetSetContentHandler_Lorg_xml_sax_ContentHandler_Handler:Org.Xml.Sax.IXMLReaderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		set;
	}

	IDTDHandler? DTDHandler
	{
		[Register("getDTDHandler", "()Lorg/xml/sax/DTDHandler;", "GetGetDTDHandlerHandler:Org.Xml.Sax.IXMLReaderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
		[Register("setDTDHandler", "(Lorg/xml/sax/DTDHandler;)V", "GetSetDTDHandler_Lorg_xml_sax_DTDHandler_Handler:Org.Xml.Sax.IXMLReaderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		set;
	}

	IEntityResolver? EntityResolver
	{
		[Register("getEntityResolver", "()Lorg/xml/sax/EntityResolver;", "GetGetEntityResolverHandler:Org.Xml.Sax.IXMLReaderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
		[Register("setEntityResolver", "(Lorg/xml/sax/EntityResolver;)V", "GetSetEntityResolver_Lorg_xml_sax_EntityResolver_Handler:Org.Xml.Sax.IXMLReaderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		set;
	}

	IErrorHandler? ErrorHandler
	{
		[Register("getErrorHandler", "()Lorg/xml/sax/ErrorHandler;", "GetGetErrorHandlerHandler:Org.Xml.Sax.IXMLReaderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
		[Register("setErrorHandler", "(Lorg/xml/sax/ErrorHandler;)V", "GetSetErrorHandler_Lorg_xml_sax_ErrorHandler_Handler:Org.Xml.Sax.IXMLReaderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		set;
	}

	[Register("getFeature", "(Ljava/lang/String;)Z", "GetGetFeature_Ljava_lang_String_Handler:Org.Xml.Sax.IXMLReaderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool GetFeature(string? name);

	[Register("getProperty", "(Ljava/lang/String;)Ljava/lang/Object;", "GetGetProperty_Ljava_lang_String_Handler:Org.Xml.Sax.IXMLReaderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Java.Lang.Object? GetProperty(string? name);

	[Register("parse", "(Ljava/lang/String;)V", "GetParse_Ljava_lang_String_Handler:Org.Xml.Sax.IXMLReaderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Parse(string? systemId);

	[Register("parse", "(Lorg/xml/sax/InputSource;)V", "GetParse_Lorg_xml_sax_InputSource_Handler:Org.Xml.Sax.IXMLReaderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Parse(InputSource? input);

	[Register("setFeature", "(Ljava/lang/String;Z)V", "GetSetFeature_Ljava_lang_String_ZHandler:Org.Xml.Sax.IXMLReaderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void SetFeature(string? name, bool value);

	[Register("setProperty", "(Ljava/lang/String;Ljava/lang/Object;)V", "GetSetProperty_Ljava_lang_String_Ljava_lang_Object_Handler:Org.Xml.Sax.IXMLReaderInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void SetProperty(string? name, Java.Lang.Object? value);
}
