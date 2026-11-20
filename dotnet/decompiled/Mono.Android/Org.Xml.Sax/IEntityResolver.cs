using System;
using Android.Runtime;
using Java.Interop;

namespace Org.Xml.Sax;

[Register("org/xml/sax/EntityResolver", "", "Org.Xml.Sax.IEntityResolverInvoker")]
public interface IEntityResolver : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("resolveEntity", "(Ljava/lang/String;Ljava/lang/String;)Lorg/xml/sax/InputSource;", "GetResolveEntity_Ljava_lang_String_Ljava_lang_String_Handler:Org.Xml.Sax.IEntityResolverInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	InputSource? ResolveEntity(string? publicId, string? systemId);
}
