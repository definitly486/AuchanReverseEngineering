using System;
using Android.Runtime;
using Java.Interop;

namespace Org.Xml.Sax;

[Register("org/xml/sax/Locator", "", "Org.Xml.Sax.ILocatorInvoker")]
public interface ILocator : IJavaObject, IDisposable, IJavaPeerable
{
	int ColumnNumber
	{
		[Register("getColumnNumber", "()I", "GetGetColumnNumberHandler:Org.Xml.Sax.ILocatorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	int LineNumber
	{
		[Register("getLineNumber", "()I", "GetGetLineNumberHandler:Org.Xml.Sax.ILocatorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	string? PublicId
	{
		[Register("getPublicId", "()Ljava/lang/String;", "GetGetPublicIdHandler:Org.Xml.Sax.ILocatorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	string? SystemId
	{
		[Register("getSystemId", "()Ljava/lang/String;", "GetGetSystemIdHandler:Org.Xml.Sax.ILocatorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}
}
