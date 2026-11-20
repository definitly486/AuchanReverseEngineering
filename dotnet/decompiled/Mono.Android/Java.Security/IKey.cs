using System;
using Android.Runtime;
using Java.IO;
using Java.Interop;

namespace Java.Security;

[Register("java/security/Key", "", "Java.Security.IKeyInvoker")]
public interface IKey : ISerializable, IJavaObject, IDisposable, IJavaPeerable
{
	string? Algorithm
	{
		[Register("getAlgorithm", "()Ljava/lang/String;", "GetGetAlgorithmHandler:Java.Security.IKeyInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	string? Format
	{
		[Register("getFormat", "()Ljava/lang/String;", "GetGetFormatHandler:Java.Security.IKeyInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("getEncoded", "()[B", "GetGetEncodedHandler:Java.Security.IKeyInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	byte[]? GetEncoded();
}
