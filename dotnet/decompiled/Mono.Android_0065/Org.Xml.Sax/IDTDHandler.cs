using System;
using Android.Runtime;
using Java.Interop;

namespace Org.Xml.Sax;

[Register("org/xml/sax/DTDHandler", "", "Org.Xml.Sax.IDTDHandlerInvoker")]
public interface IDTDHandler : IJavaObject, IDisposable, IJavaPeerable
{
	void NotationDecl(string? name, string? publicId, string? systemId);

	void UnparsedEntityDecl(string? name, string? publicId, string? systemId, string? notationName);
}
