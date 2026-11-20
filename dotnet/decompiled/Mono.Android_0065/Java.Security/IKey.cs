using System;
using Android.Runtime;
using Java.IO;
using Java.Interop;

namespace Java.Security;

[Register("java/security/Key", "", "Java.Security.IKeyInvoker")]
public interface IKey : ISerializable, IJavaObject, IDisposable, IJavaPeerable
{
	string? Algorithm { get; }

	string? Format { get; }

	byte[]? GetEncoded();
}
