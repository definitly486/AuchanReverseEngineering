using System.Runtime.InteropServices;

namespace System.Security.Cryptography;

internal abstract class SafeKeyHandle : SafeHandle
{
	public override bool IsInvalid => handle == IntPtr.Zero;

	protected SafeKeyHandle()
		: base(IntPtr.Zero, ownsHandle: true)
	{
	}

	internal abstract SafeKeyHandle DuplicateHandle();
}
