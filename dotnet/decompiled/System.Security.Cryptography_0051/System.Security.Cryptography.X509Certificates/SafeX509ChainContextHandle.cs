using System.Runtime.InteropServices;

namespace System.Security.Cryptography.X509Certificates;

internal sealed class SafeX509ChainContextHandle : SafeHandle
{
	public override bool IsInvalid => handle == IntPtr.Zero;

	public SafeX509ChainContextHandle()
		: base(IntPtr.Zero, ownsHandle: true)
	{
	}

	protected override bool ReleaseHandle()
	{
		global::Interop.AndroidCrypto.X509ChainDestroyContext(handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
