namespace System.Security.Cryptography;

internal sealed class SafeRsaHandle : SafeKeyHandle
{
	public SafeRsaHandle()
	{
	}

	public SafeRsaHandle(nint ptr)
	{
		SetHandle(ptr);
	}

	protected override bool ReleaseHandle()
	{
		global::Interop.AndroidCrypto.RsaDestroy(handle);
		SetHandle(IntPtr.Zero);
		return true;
	}

	internal override SafeRsaHandle DuplicateHandle()
	{
		return DuplicateHandle(DangerousGetHandle());
	}

	internal static SafeRsaHandle DuplicateHandle(nint handle)
	{
		SafeRsaHandle safeRsaHandle = new SafeRsaHandle();
		if (!global::Interop.AndroidCrypto.RsaUpRef(handle))
		{
			safeRsaHandle.Dispose();
			throw new CryptographicException();
		}
		safeRsaHandle.SetHandle(handle);
		return safeRsaHandle;
	}
}
