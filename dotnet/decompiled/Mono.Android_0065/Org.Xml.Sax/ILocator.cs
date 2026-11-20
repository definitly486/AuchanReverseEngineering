using System;
using Android.Runtime;
using Java.Interop;

namespace Org.Xml.Sax;

[Register("org/xml/sax/Locator", "", "Org.Xml.Sax.ILocatorInvoker")]
public interface ILocator : IJavaObject, IDisposable, IJavaPeerable
{
	int ColumnNumber { get; }

	int LineNumber { get; }

	string? PublicId { get; }

	string? SystemId { get; }
}
