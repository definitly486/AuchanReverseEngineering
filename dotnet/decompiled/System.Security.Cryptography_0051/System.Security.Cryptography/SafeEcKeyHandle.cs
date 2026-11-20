namespace System.Security.Cryptography;

internal sealed class SafeEcKeyHandle : SafeKeyHandle
{
	public SafeEcKeyHandle()
	{
	}

	internal SafeEcKeyHandle(nint ptr)
	{
		SetHandle(ptr);
	}

	protected override bool ReleaseHandle()
	{
		global::Interop.AndroidCrypto.EcKeyDestroy(handle);
		SetHandle(IntPtr.Zero);
		return true;
	}

	internal static SafeEcKeyHandle DuplicateHandle(nint handle)
	{
		SafeEcKeyHandle safeEcKeyHandle = new SafeEcKeyHandle();
		if (!global::Interop.AndroidCrypto.EcKeyUpRef(handle))
		{
			safeEcKeyHandle.Dispose();
			throw new CryptographicException();
		}
		safeEcKeyHandle.SetHandle(handle);
		return safeEcKeyHandle;
	}

	internal override SafeEcKeyHandle DuplicateHandle()
	{
		return DuplicateHandle(DangerousGetHandle());
	}
}
