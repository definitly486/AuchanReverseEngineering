using System;
using Android.Runtime;
using Java.Interop;

namespace Org.Xml.Sax;

[Register("org/xml/sax/ContentHandler", "", "Org.Xml.Sax.IContentHandlerInvoker")]
public interface IContentHandler : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("characters", "([CII)V", "GetCharacters_arrayCIIHandler:Org.Xml.Sax.IContentHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Characters(char[]? ch, int start, int length);

	[Register("endDocument", "()V", "GetEndDocumentHandler:Org.Xml.Sax.IContentHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void EndDocument();

	[Register("endElement", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;)V", "GetEndElement_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Handler:Org.Xml.Sax.IContentHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void EndElement(string? uri, string? localName, string? qName);

	[Register("endPrefixMapping", "(Ljava/lang/String;)V", "GetEndPrefixMapping_Ljava_lang_String_Handler:Org.Xml.Sax.IContentHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void EndPrefixMapping(string? prefix);

	[Register("ignorableWhitespace", "([CII)V", "GetIgnorableWhitespace_arrayCIIHandler:Org.Xml.Sax.IContentHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void IgnorableWhitespace(char[]? ch, int start, int length);

	[Register("processingInstruction", "(Ljava/lang/String;Ljava/lang/String;)V", "GetProcessingInstruction_Ljava_lang_String_Ljava_lang_String_Handler:Org.Xml.Sax.IContentHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void ProcessingInstruction(string? target, string? data);

	[Register("setDocumentLocator", "(Lorg/xml/sax/Locator;)V", "GetSetDocumentLocator_Lorg_xml_sax_Locator_Handler:Org.Xml.Sax.IContentHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void SetDocumentLocator(ILocator? locator);

	[Register("skippedEntity", "(Ljava/lang/String;)V", "GetSkippedEntity_Ljava_lang_String_Handler:Org.Xml.Sax.IContentHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void SkippedEntity(string? name);

	[Register("startDocument", "()V", "GetStartDocumentHandler:Org.Xml.Sax.IContentHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void StartDocument();

	[Register("startElement", "(Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;Lorg/xml/sax/Attributes;)V", "GetStartElement_Ljava_lang_String_Ljava_lang_String_Ljava_lang_String_Lorg_xml_sax_Attributes_Handler:Org.Xml.Sax.IContentHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void StartElement(string? uri, string? localName, string? qName, IAttributes? atts);

	[Register("startPrefixMapping", "(Ljava/lang/String;Ljava/lang/String;)V", "GetStartPrefixMapping_Ljava_lang_String_Ljava_lang_String_Handler:Org.Xml.Sax.IContentHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void StartPrefixMapping(string? prefix, string? uri);
}
