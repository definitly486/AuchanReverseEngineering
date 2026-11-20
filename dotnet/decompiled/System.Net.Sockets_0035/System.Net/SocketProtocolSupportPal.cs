using System.Net.Sockets;

namespace System.Net;

internal static class SocketProtocolSupportPal
{
	public static bool OSSupportsIPv6 { get; } = IsSupported(AddressFamily.InterNetworkV6) && !IsIPv6Disabled();

	public static bool OSSupportsIPv4 { get; } = IsSupported(AddressFamily.InterNetwork);

	public static bool OSSupportsUnixDomainSockets { get; } = IsSupported(AddressFamily.Unix);

	private static bool IsIPv6Disabled()
	{
		if (AppContext.TryGetSwitch("System.Net.DisableIPv6", out var isEnabled))
		{
			return isEnabled;
		}
		string environmentVariable = Environment.GetEnvironmentVariable("DOTNET_SYSTEM_NET_DISABLEIPV6");
		if (environmentVariable != null)
		{
			if (!(environmentVariable == "1"))
			{
				return environmentVariable.Equals("true", StringComparison.OrdinalIgnoreCase);
			}
			return true;
		}
		return false;
	}

	private unsafe static bool IsSupported(AddressFamily af)
	{
		if (af == AddressFamily.Unix)
		{
			_ = 0;
			_ = 0;
			if (0 == 0)
			{
			}
		}
		nint num = -1;
		nint num2 = num;
		try
		{
			global::Interop.Error error = global::Interop.Sys.Socket((int)af, 2, 0, &num2);
			return error != global::Interop.Error.EAFNOSUPPORT && error != global::Interop.Error.EPROTONOSUPPORT;
		}
		finally
		{
			if (num2 != num)
			{
				global::Interop.Sys.Close(num2);
			}
		}
	}
}
