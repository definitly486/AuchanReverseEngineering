namespace System.Security.Cryptography;

internal sealed class SafeDsaHandle : SafeKeyHandle
{
	public SafeDsaHandle()
	{
	}

	internal SafeDsaHandle(nint ptr)
	{
		SetHandle(ptr);
	}

	protected override bool ReleaseHandle()
	{
		global::Interop.JObjectLifetime.DeleteGlobalReference(handle);
		SetHandle(IntPtr.Zero);
		return true;
	}

	internal static SafeDsaHandle DuplicateHandle(nint handle)
	{
		SafeDsaHandle safeDsaHandle = new SafeDsaHandle();
		safeDsaHandle.SetHandle(global::Interop.JObjectLifetime.NewGlobalReference(handle));
		return safeDsaHandle;
	}

	internal override SafeDsaHandle DuplicateHandle()
	{
		return DuplicateHandle(DangerousGetHandle());
	}
}
