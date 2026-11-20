using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Net;

internal static class NameResolutionPal
{
	private static SocketError GetSocketErrorForNativeError(int error)
	{
		switch (error)
		{
		case 0:
			return SocketError.Success;
		case 1:
			return SocketError.TryAgain;
		case 2:
		case 6:
			return SocketError.InvalidArgument;
		case 3:
			return SocketError.NoRecovery;
		case 4:
			return SocketError.AddressFamilyNotSupported;
		case 5:
			return SocketError.HostNotFound;
		case 8:
			throw new OutOfMemoryException();
		case 9:
			return SocketError.SocketError;
		default:
			return SocketError.SocketError;
		}
	}

	private unsafe static void ParseHostEntry(global::Interop.Sys.HostEntry hostEntry, bool justAddresses, out string hostName, out string[] aliases, out IPAddress[] addresses)
	{
		try
		{
			hostName = ((!justAddresses && hostEntry.CanonicalName != null) ? Marshal.PtrToStringUTF8((nint)hostEntry.CanonicalName) : null);
			IPAddress[] array;
			if (hostEntry.IPAddressCount == 0)
			{
				array = Array.Empty<IPAddress>();
			}
			else
			{
				global::Interop.Sys.IPAddress[] array2 = new global::Interop.Sys.IPAddress[hostEntry.IPAddressCount];
				int num = 0;
				global::Interop.Sys.IPAddress* iPAddressList = hostEntry.IPAddressList;
				for (int i = 0; i < hostEntry.IPAddressCount; i++)
				{
					global::Interop.Sys.IPAddress iPAddress = iPAddressList[i];
					if (Array.IndexOf(array2, iPAddress, 0, num) == -1 && (!iPAddress.IsIPv6 || SocketProtocolSupportPal.OSSupportsIPv6))
					{
						array2[num++] = iPAddress;
					}
				}
				array = new IPAddress[num];
				for (int j = 0; j < num; j++)
				{
					array[j] = array2[j].GetIPAddress();
				}
			}
			string[] array3 = Array.Empty<string>();
			if (!justAddresses && hostEntry.Aliases != null)
			{
				int k;
				for (k = 0; hostEntry.Aliases[k] != null; k++)
				{
				}
				if (k > 0)
				{
					array3 = new string[k];
					for (int l = 0; l < array3.Length; l++)
					{
						array3[l] = Marshal.PtrToStringUTF8((nint)hostEntry.Aliases[l]);
					}
				}
			}
			aliases = array3;
			addresses = array;
		}
		finally
		{
			global::Interop.Sys.FreeHostEntry(&hostEntry);
		}
	}

	public unsafe static SocketError TryGetAddrInfo(string name, bool justAddresses, AddressFamily addressFamily, out string hostName, out string[] aliases, out IPAddress[] addresses, out int nativeErrorCode)
	{
		if (name == "")
		{
			name = Dns.GetHostName();
		}
		Unsafe.SkipInit(out global::Interop.Sys.HostEntry hostEntry);
		int hostEntryForName = global::Interop.Sys.GetHostEntryForName(name, addressFamily, &hostEntry);
		if (hostEntryForName != 0)
		{
			nativeErrorCode = hostEntryForName;
			hostName = name;
			aliases = Array.Empty<string>();
			addresses = Array.Empty<IPAddress>();
			return GetSocketErrorForNativeError(hostEntryForName);
		}
		ParseHostEntry(hostEntry, justAddresses, out hostName, out aliases, out addresses);
		nativeErrorCode = 0;
		return SocketError.Success;
	}

	public unsafe static string TryGetNameInfo(IPAddress addr, out SocketError socketError, out int nativeErrorCode)
	{
		if (false)
		{
		}
		byte* ptr = stackalloc byte[1026];
		byte isIpv;
		int num;
		if (addr.AddressFamily == AddressFamily.InterNetwork)
		{
			isIpv = 0;
			num = 4;
		}
		else
		{
			isIpv = 1;
			num = 16;
		}
		byte* ptr2 = stackalloc byte[(int)(uint)num];
		addr.TryWriteBytes(new Span<byte>(ptr2, num), out var _);
		int nameInfo = global::Interop.Sys.GetNameInfo(ptr2, (uint)num, isIpv, ptr, 1025u, null, 0u, global::Interop.Sys.GetNameInfoFlags.NI_NAMEREQD);
		socketError = GetSocketErrorForNativeError(nameInfo);
		nativeErrorCode = nameInfo;
		if (socketError != SocketError.Success)
		{
			return null;
		}
		return Marshal.PtrToStringUTF8((nint)ptr);
	}

	public static string GetHostName()
	{
		return global::Interop.Sys.GetHostName();
	}
}
