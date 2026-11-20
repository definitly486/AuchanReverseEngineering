using System;
using Android.Runtime;
using Java.Interop;

namespace Org.Xml.Sax;

[Register("org/xml/sax/ErrorHandler", "", "Org.Xml.Sax.IErrorHandlerInvoker")]
public interface IErrorHandler : IJavaObject, IDisposable, IJavaPeerable
{
	void Error(SAXParseException? exception);

	void FatalError(SAXParseException? exception);

	void Warning(SAXParseException? exception);
}
