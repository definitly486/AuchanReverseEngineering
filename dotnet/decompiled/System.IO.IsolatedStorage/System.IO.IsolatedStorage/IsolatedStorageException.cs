using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace System.IO.IsolatedStorage;

[Serializable]
[TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class IsolatedStorageException : Exception, ISerializable
{
	internal Exception _underlyingException;

	public IsolatedStorageException(string? message)
		: base(message ?? "IsolatedStorage_Exception")
	{
		base.HResult = -2146233264;
	}

	public IsolatedStorageException(string? message, Exception? inner)
		: base(message ?? "IsolatedStorage_Exception", inner)
	{
		base.HResult = -2146233264;
	}
}
