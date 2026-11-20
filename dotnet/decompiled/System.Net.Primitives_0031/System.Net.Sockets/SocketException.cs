using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.Net.Sockets;

[Serializable]
[TypeForwardedFrom("System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class SocketException : Win32Exception
{
	private readonly SocketError _errorCode;

	public override string Message => base.Message;

	public SocketError SocketErrorCode => _errorCode;

	public override int ErrorCode => base.NativeErrorCode;

	public SocketException(int errorCode)
		: this((SocketError)errorCode)
	{
	}

	public SocketException(int errorCode, string? message)
		: this((SocketError)errorCode, message)
	{
	}

	internal SocketException(SocketError socketError)
		: base(GetNativeErrorForSocketError(socketError))
	{
		_errorCode = socketError;
	}

	internal SocketException(SocketError socketError, string message)
		: base(GetNativeErrorForSocketError(socketError), message)
	{
		_errorCode = socketError;
	}

	private static int GetNativeErrorForSocketError(SocketError error)
	{
		int result = (int)error;
		if (SocketErrorPal.TryGetNativeErrorForSocketError(error, out var errno))
		{
			result = errno.Info().RawErrno;
		}
		return result;
	}
}
