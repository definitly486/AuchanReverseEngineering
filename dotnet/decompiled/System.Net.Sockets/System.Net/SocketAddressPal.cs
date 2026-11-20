using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Net;

internal static class SocketAddressPal
{
	public static readonly int IPv4AddressSize;

	public static readonly int IPv6AddressSize;

	public static readonly int UdsAddressSize;

	public static readonly int MaxAddressSize;

	unsafe static SocketAddressPal()
	{
		int iPv4AddressSize = 0;
		int iPv6AddressSize = 0;
		int udsAddressSize = 0;
		int maxAddressSize = 0;
		global::Interop.Sys.GetSocketAddressSizes(&iPv4AddressSize, &iPv6AddressSize, &udsAddressSize, &maxAddressSize);
		IPv4AddressSize = iPv4AddressSize;
		IPv6AddressSize = iPv6AddressSize;
		UdsAddressSize = udsAddressSize;
		MaxAddressSize = maxAddressSize;
	}

	private static void ThrowOnFailure(global::Interop.Error err)
	{
		switch (err)
		{
		case global::Interop.Error.SUCCESS:
			break;
		case global::Interop.Error.EFAULT:
			throw new IndexOutOfRangeException();
		case global::Interop.Error.EAFNOSUPPORT:
			throw new PlatformNotSupportedException();
		default:
			throw new PlatformNotSupportedException();
		}
	}

	public unsafe static AddressFamily GetAddressFamily(ReadOnlySpan<byte> buffer)
	{
		global::Interop.Error addressFamily;
		Unsafe.SkipInit(out AddressFamily result);
		fixed (byte* socketAddress = buffer)
		{
			addressFamily = global::Interop.Sys.GetAddressFamily(socketAddress, buffer.Length, (int*)(&result));
		}
		ThrowOnFailure(addressFamily);
		return result;
	}

	public unsafe static ushort GetPort(ReadOnlySpan<byte> buffer)
	{
		global::Interop.Error port;
		Unsafe.SkipInit(out ushort result);
		fixed (byte* socketAddress = buffer)
		{
			port = global::Interop.Sys.GetPort(socketAddress, buffer.Length, &result);
		}
		ThrowOnFailure(port);
		return result;
	}

	public unsafe static uint GetIPv4Address(ReadOnlySpan<byte> buffer)
	{
		global::Interop.Error iPv4Address;
		Unsafe.SkipInit(out uint result);
		fixed (byte* reference = &MemoryMarshal.GetReference(buffer))
		{
			iPv4Address = global::Interop.Sys.GetIPv4Address(reference, buffer.Length, &result);
		}
		ThrowOnFailure(iPv4Address);
		return result;
	}

	public unsafe static void GetIPv6Address(ReadOnlySpan<byte> buffer, Span<byte> address, out uint scope)
	{
		global::Interop.Error iPv6Address;
		Unsafe.SkipInit(out uint num);
		fixed (byte* reference = &MemoryMarshal.GetReference(buffer))
		{
			fixed (byte* reference2 = &MemoryMarshal.GetReference(address))
			{
				iPv6Address = global::Interop.Sys.GetIPv6Address(reference, buffer.Length, reference2, address.Length, &num);
			}
		}
		ThrowOnFailure(iPv6Address);
		scope = num;
	}
}
