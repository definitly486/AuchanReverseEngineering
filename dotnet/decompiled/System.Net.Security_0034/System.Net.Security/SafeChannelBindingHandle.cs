using System.Runtime.InteropServices;
using System.Security.Authentication.ExtendedProtection;

namespace System.Net.Security;

internal sealed class SafeChannelBindingHandle : ChannelBinding
{
	private readonly int _cbtPrefixByteArraySize;

	private unsafe static int SecChannelBindingSize => sizeof(SecChannelBindings);

	internal int Length { get; private set; }

	internal nint CertHashPtr { get; }

	public override int Size => Length;

	public override bool IsInvalid => handle == IntPtr.Zero;

	internal void SetCertHash(byte[] certHashBytes)
	{
		int num = certHashBytes.Length;
		Marshal.Copy(certHashBytes, 0, CertHashPtr, num);
		SetCertHashLength(num);
	}

	internal unsafe SafeChannelBindingHandle(ChannelBindingKind kind)
	{
		ReadOnlySpan<byte> readOnlySpan = ((kind == ChannelBindingKind.Endpoint) ? "tls-server-end-point:"u8 : "tls-unique:"u8);
		_cbtPrefixByteArraySize = readOnlySpan.Length;
		handle = Marshal.AllocHGlobal(SecChannelBindingSize + _cbtPrefixByteArraySize + 128);
		nint num = handle + SecChannelBindingSize;
		readOnlySpan.CopyTo(new Span<byte>((void*)num, readOnlySpan.Length));
		CertHashPtr = num + _cbtPrefixByteArraySize;
		Length = 128;
	}

	internal void SetCertHashLength(int certHashLength)
	{
		int num = _cbtPrefixByteArraySize + certHashLength;
		Length = SecChannelBindingSize + num;
		Marshal.StructureToPtr(new SecChannelBindings
		{
			ApplicationDataLength = num,
			ApplicationDataOffset = SecChannelBindingSize
		}, handle, fDeleteOld: true);
	}

	protected override bool ReleaseHandle()
	{
		Marshal.FreeHGlobal(handle);
		SetHandle(IntPtr.Zero);
		return true;
	}
}
