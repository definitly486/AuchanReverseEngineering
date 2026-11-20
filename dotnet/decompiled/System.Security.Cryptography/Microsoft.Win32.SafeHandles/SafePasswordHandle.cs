using System;
using System.Runtime.InteropServices;

namespace Microsoft.Win32.SafeHandles;

internal sealed class SafePasswordHandle : SafeHandleZeroOrMinusOneIsInvalid
{
	internal int Length { get; private set; }

	internal bool PasswordProvided { get; }

	public static SafePasswordHandle InvalidHandle => SafeHandleCache<SafePasswordHandle>.GetInvalidHandle(() => new SafePasswordHandle(null, passwordProvided: false));

	public SafePasswordHandle(string password, bool passwordProvided)
		: base(ownsHandle: true)
	{
		if (password != null)
		{
			handle = Marshal.StringToHGlobalUni(password);
			Length = password.Length;
		}
		PasswordProvided = passwordProvided;
	}

	protected override bool ReleaseHandle()
	{
		Marshal.ZeroFreeGlobalAllocUnicode(handle);
		SetHandle(-1);
		Length = 0;
		return true;
	}

	protected override void Dispose(bool disposing)
	{
		if (!disposing || !SafeHandleCache<SafePasswordHandle>.IsCachedInvalidHandle(this))
		{
			base.Dispose(disposing);
		}
	}

	internal unsafe ReadOnlySpan<char> DangerousGetSpan()
	{
		if (IsInvalid)
		{
			return default(ReadOnlySpan<char>);
		}
		return new ReadOnlySpan<char>((void*)handle, Length);
	}
}
