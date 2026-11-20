using System.Runtime.InteropServices;

namespace System.Net.Sockets;

internal static class SocketExceptionFactory
{
	private static string CreateMessage(int nativeSocketError, EndPoint endPoint)
	{
		return Marshal.GetPInvokeErrorMessage(nativeSocketError) + " " + endPoint.ToString();
	}

	public static SocketException CreateSocketException(int socketError, EndPoint endPoint)
	{
		int nativeSocketError = socketError;
		if (System.Net.Sockets.SocketErrorPal.TryGetNativeErrorForSocketError((SocketError)socketError, out var errno))
		{
			nativeSocketError = errno.Info().RawErrno;
		}
		return new SocketException(socketError, CreateMessage(nativeSocketError, endPoint));
	}
}
