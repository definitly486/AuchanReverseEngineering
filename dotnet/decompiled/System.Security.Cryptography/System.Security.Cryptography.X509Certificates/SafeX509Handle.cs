namespace System.Security.Cryptography.X509Certificates;

internal sealed class SafeX509Handle : global::Interop.JObjectLifetime.SafeJObjectHandle
{
	public SafeX509Handle()
	{
	}

	internal SafeX509Handle(nint ptr)
		: base(ptr)
	{
	}
}
