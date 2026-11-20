namespace System.Net.Sockets;

internal static class IPEndPointExtensions
{
	public static IPAddress GetIPAddress(ReadOnlySpan<byte> socketAddressBuffer)
	{
		switch (SocketAddressPal.GetAddressFamily(socketAddressBuffer))
		{
		case AddressFamily.InterNetworkV6:
		{
			Span<byte> span = stackalloc byte[16];
			SocketAddressPal.GetIPv6Address(socketAddressBuffer, span, out var scope);
			return new IPAddress(span, (span[0] == 254 && (span[1] & 0xC0) == 128) ? scope : 0);
		}
		case AddressFamily.InterNetwork:
			return new IPAddress((long)SocketAddressPal.GetIPv4Address(socketAddressBuffer) & 0xFFFFFFFFL);
		default:
			throw new SocketException(10047);
		}
	}
}
