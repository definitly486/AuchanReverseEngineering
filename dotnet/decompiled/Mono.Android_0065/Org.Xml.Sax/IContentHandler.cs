using System;
using Android.Runtime;
using Java.Interop;

namespace Org.Xml.Sax;

[Register("org/xml/sax/ContentHandler", "", "Org.Xml.Sax.IContentHandlerInvoker")]
public interface IContentHandler : IJavaObject, IDisposable, IJavaPeerable
{
	void Characters(char[]? ch, int start, int length);

	void EndDocument();

	void EndElement(string? uri, string? localName, string? qName);

	void EndPrefixMapping(string? prefix);

	void IgnorableWhitespace(char[]? ch, int start, int length);

	void ProcessingInstruction(string? target, string? data);

	void SetDocumentLocator(ILocator? locator);

	void SkippedEntity(string? name);

	void StartDocument();

	void StartElement(string? uri, string? localName, string? qName, IAttributes? atts);

	void StartPrefixMapping(string? prefix, string? uri);
}
