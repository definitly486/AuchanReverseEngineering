using System;
using Android.Runtime;
using Java.Interop;

namespace Org.Xml.Sax;

[Register("org/xml/sax/EntityResolver", "", "Org.Xml.Sax.IEntityResolverInvoker")]
public interface IEntityResolver : IJavaObject, IDisposable, IJavaPeerable
{
	InputSource? ResolveEntity(string? publicId, string? systemId);
}
