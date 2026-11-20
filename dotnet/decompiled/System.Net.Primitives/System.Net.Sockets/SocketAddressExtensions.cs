namespace System.Net.Sockets;

internal static class SocketAddressExtensions
{
	public static IPAddress GetIPAddress(this SocketAddress socketAddress)
	{
		return IPEndPointExtensions.GetIPAddress(socketAddress.Buffer.Span);
	}

	public static int GetPort(this SocketAddress socketAddress)
	{
		return SocketAddressPal.GetPort(socketAddress.Buffer.Span);
	}

	public static IPEndPoint GetIPEndPoint(this SocketAddress socketAddress)
	{
		return new IPEndPoint(socketAddress.GetIPAddress(), socketAddress.GetPort());
	}
}
