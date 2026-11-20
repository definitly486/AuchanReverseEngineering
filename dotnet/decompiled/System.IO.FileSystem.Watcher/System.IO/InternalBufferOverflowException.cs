using System.Runtime.CompilerServices;

namespace System.IO;

[Serializable]
[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class InternalBufferOverflowException : SystemException
{
	public InternalBufferOverflowException(string? message)
		: base(message)
	{
		base.HResult = -2146232059;
	}
}
