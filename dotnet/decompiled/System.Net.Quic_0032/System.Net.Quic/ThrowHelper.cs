using System.Diagnostics.CodeAnalysis;
using System.Net.Security;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Security.Authentication;
using System.Threading;
using Microsoft.Quic;

namespace System.Net.Quic;

internal static class ThrowHelper
{
	internal static QuicException GetConnectionAbortedException(long errorCode)
	{
		return new QuicException(QuicError.ConnectionAborted, errorCode, System.SR.Format("net_quic_connectionaborted", errorCode));
	}

	internal static QuicException GetStreamAbortedException(long errorCode)
	{
		return new QuicException(QuicError.StreamAborted, errorCode, System.SR.Format("net_quic_streamaborted", errorCode));
	}

	internal static QuicException GetOperationAbortedException(string message = null)
	{
		return new QuicException(QuicError.OperationAborted, null, message ?? "net_quic_operationaborted");
	}

	internal static bool TryGetStreamExceptionForMsQuicStatus(int status, [NotNullWhen(true)] out Exception exception)
	{
		switch (status)
		{
		case 125:
			exception = null;
			return false;
		case 1:
			exception = GetOperationAbortedException();
			return true;
		default:
			if (MsQuic.StatusFailed(status))
			{
				exception = GetExceptionForMsQuicStatus(status);
				return true;
			}
			exception = null;
			return false;
		}
	}

	internal static Exception GetExceptionForMsQuicStatus(int status, long? errorCode = null, string message = null)
	{
		Exception ex = GetExceptionInternal(status, errorCode, message);
		if (status != 0)
		{
			ex.HResult = status;
		}
		return ex;
		static Exception GetExceptionInternal(int num, long? transportErrorCode, string message2)
		{
			if (num == 111)
			{
				return new QuicException(QuicError.ConnectionRefused, null, transportErrorCode, "net_quic_connection_refused");
			}
			if (num == 110)
			{
				return new QuicException(QuicError.ConnectionTimeout, null, transportErrorCode, "net_quic_timeout");
			}
			if (num == 93)
			{
				return new QuicException(QuicError.VersionNegotiationError, null, transportErrorCode, "net_quic_ver_neg_error");
			}
			if (num == 62)
			{
				return new QuicException(QuicError.ConnectionIdle, null, transportErrorCode, "net_quic_connection_idle");
			}
			if (num == 71)
			{
				return new QuicException(QuicError.TransportError, null, transportErrorCode, "net_quic_protocol_error");
			}
			if (num == 91)
			{
				return new QuicException(QuicError.AlpnInUse, null, transportErrorCode, "net_quic_alpn_in_use");
			}
			if (num == 97)
			{
				return new SocketException(10049);
			}
			if (num == 98)
			{
				return new SocketException(10048);
			}
			if (num == 113)
			{
				return new SocketException(10065);
			}
			if (num == 99)
			{
				return new SocketException(10047);
			}
			if (num == 126 || num == 200000513 || num == 200000514 || num == 200000515)
			{
				return new AuthenticationException(System.SR.Format("net_quic_auth", GetErrorMessageForStatus(num, message2)));
			}
			if (num == 92)
			{
				return new AuthenticationException("net_quic_alpn_neg_error");
			}
			if (num == 130)
			{
				return new AuthenticationException(System.SR.Format("net_auth_tls_alert", System.Net.Security.TlsAlertMessage.UserCanceled));
			}
			if ((uint)num >= 200000256u && (uint)num < 200000512u)
			{
				System.Net.Security.TlsAlertMessage tlsAlertMessage = (System.Net.Security.TlsAlertMessage)(num - 200000256);
				return new AuthenticationException(System.SR.Format("net_auth_tls_alert", tlsAlertMessage));
			}
			return new QuicException(QuicError.InternalError, null, System.SR.Format("net_quic_internal_error", GetErrorMessageForStatus(num, message2)));
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	internal static void ThrowIfMsQuicError(int status, string message = null)
	{
		if (MsQuic.StatusFailed(status))
		{
			ThrowMsQuicException(status, message);
		}
	}

	internal static void ThrowMsQuicException(int status, string message = null)
	{
		throw GetExceptionForMsQuicStatus(status, null, message);
	}

	internal static string GetErrorMessageForStatus(int status, string message)
	{
		return (message ?? "Status code") + ": " + GetErrorMessageForStatus(status);
	}

	internal static string GetErrorMessageForStatus(int status)
	{
		return status switch
		{
			0 => "QUIC_STATUS_SUCCESS", 
			-2 => "QUIC_STATUS_PENDING", 
			-1 => "QUIC_STATUS_CONTINUE", 
			12 => "QUIC_STATUS_OUT_OF_MEMORY", 
			22 => "QUIC_STATUS_INVALID_PARAMETER", 
			1 => "QUIC_STATUS_INVALID_STATE", 
			95 => "QUIC_STATUS_NOT_SUPPORTED", 
			2 => "QUIC_STATUS_NOT_FOUND", 
			75 => "QUIC_STATUS_BUFFER_TOO_SMALL", 
			103 => "QUIC_STATUS_HANDSHAKE_FAILURE", 
			125 => "QUIC_STATUS_ABORTED", 
			98 => "QUIC_STATUS_ADDRESS_IN_USE", 
			97 => "QUIC_STATUS_INVALID_ADDRESS", 
			110 => "QUIC_STATUS_CONNECTION_TIMEOUT", 
			62 => "QUIC_STATUS_CONNECTION_IDLE", 
			113 => "QUIC_STATUS_UNREACHABLE", 
			5 => "QUIC_STATUS_INTERNAL_ERROR", 
			111 => "QUIC_STATUS_CONNECTION_REFUSED", 
			71 => "QUIC_STATUS_PROTOCOL_ERROR", 
			93 => "QUIC_STATUS_VER_NEG_ERROR", 
			126 => "QUIC_STATUS_TLS_ERROR", 
			130 => "QUIC_STATUS_USER_CANCELED", 
			92 => "QUIC_STATUS_ALPN_NEG_FAILURE", 
			86 => "QUIC_STATUS_STREAM_LIMIT_REACHED", 
			91 => "QUIC_STATUS_ALPN_IN_USE", 
			200000256 => "QUIC_STATUS_CLOSE_NOTIFY", 
			200000298 => "QUIC_STATUS_BAD_CERTIFICATE", 
			200000299 => "QUIC_STATUS_UNSUPPORTED_CERTIFICATE", 
			200000300 => "QUIC_STATUS_REVOKED_CERTIFICATE", 
			200000301 => "QUIC_STATUS_EXPIRED_CERTIFICATE", 
			200000302 => "QUIC_STATUS_UNKNOWN_CERTIFICATE", 
			200000372 => "QUIC_STATUS_REQUIRED_CERTIFICATE", 
			200000513 => "QUIC_STATUS_CERT_EXPIRED", 
			200000514 => "QUIC_STATUS_CERT_UNTRUSTED_ROOT", 
			200000515 => "QUIC_STATUS_CERT_NO_CERT", 
			_ => $"Unknown (0x{status:x})", 
		};
	}

	public static void ValidateErrorCode(string argumentName, long value, [CallerArgumentExpression("value")] string propertyName = null)
	{
		ValidateInRange(argumentName, value, 4611686018427387903L, propertyName);
	}

	public static void ValidateInRange(string argumentName, long value, long max, [CallerArgumentExpression("value")] string propertyName = null)
	{
		if (value < 0 || value > max)
		{
			throw new ArgumentOutOfRangeException(argumentName, value, System.SR.Format("net_quic_in_range", propertyName, max));
		}
	}

	public static void ValidateTimeSpan(string argumentName, TimeSpan value, [CallerArgumentExpression("value")] string propertyName = null)
	{
		if (value < TimeSpan.Zero && value != Timeout.InfiniteTimeSpan)
		{
			throw new ArgumentOutOfRangeException(argumentName, value, System.SR.Format("net_quic_timeout_use_gt_zero", propertyName));
		}
	}

	public static void ValidateNotNull(string argumentName, string resourceName, object value, [CallerArgumentExpression("value")] string propertyName = null)
	{
		if (value == null)
		{
			throw new ArgumentNullException(argumentName, System.SR.Format(resourceName, propertyName));
		}
	}
}
