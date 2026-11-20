using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Org.Xml.Sax;

[Register("org/xml/sax/XMLReader", "", "Org.Xml.Sax.IXMLReaderInvoker")]
public interface IXMLReader : IJavaObject, IDisposable, IJavaPeerable
{
	IContentHandler? ContentHandler { get; set; }

	IDTDHandler? DTDHandler { get; set; }

	IEntityResolver? EntityResolver { get; set; }

	IErrorHandler? ErrorHandler { get; set; }

	bool GetFeature(string? name);

	Java.Lang.Object? GetProperty(string? name);

	void Parse(string? systemId);

	void Parse(InputSource? input);

	void SetFeature(string? name, bool value);

	void SetProperty(string? name, Java.Lang.Object? value);
}
