using System;
using Android.Runtime;
using Java.Interop;

namespace Org.Xml.Sax;

[Register("org/xml/sax/Attributes", "", "Org.Xml.Sax.IAttributesInvoker")]
public interface IAttributes : IJavaObject, IDisposable, IJavaPeerable
{
	int Length { get; }

	int GetIndex(string? uri, string? localName);

	int GetIndex(string? qName);

	string? GetLocalName(int index);

	string? GetQName(int index);

	string? GetType(int index);

	string? GetType(string? uri, string? localName);

	string? GetType(string? qName);

	string? GetURI(int index);

	string? GetValue(int index);

	string? GetValue(string? uri, string? localName);

	string? GetValue(string? qName);
}
