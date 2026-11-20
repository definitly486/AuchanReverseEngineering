using System;
using Android.Runtime;
using Java.Interop;

namespace Org.Xml.Sax;

[Register("org/xml/sax/ErrorHandler", "", "Org.Xml.Sax.IErrorHandlerInvoker")]
public interface IErrorHandler : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("error", "(Lorg/xml/sax/SAXParseException;)V", "GetError_Lorg_xml_sax_SAXParseException_Handler:Org.Xml.Sax.IErrorHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Error(SAXParseException? exception);

	[Register("fatalError", "(Lorg/xml/sax/SAXParseException;)V", "GetFatalError_Lorg_xml_sax_SAXParseException_Handler:Org.Xml.Sax.IErrorHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void FatalError(SAXParseException? exception);

	[Register("warning", "(Lorg/xml/sax/SAXParseException;)V", "GetWarning_Lorg_xml_sax_SAXParseException_Handler:Org.Xml.Sax.IErrorHandlerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Warning(SAXParseException? exception);
}
