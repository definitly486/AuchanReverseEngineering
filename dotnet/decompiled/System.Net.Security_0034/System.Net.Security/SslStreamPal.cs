using System.Security.Authentication.ExtendedProtection;

namespace System.Net.Security;

internal static class SslStreamPal
{
	public static Exception GetException(SecurityStatusPal status)
	{
		return status.Exception ?? new global::Interop.AndroidCrypto.SslException((int)status.ErrorCode);
	}

	public static SecurityStatusPal SelectApplicationProtocol(SafeFreeCredentials credentialsHandle, SafeDeleteSslContext context, SslAuthenticationOptions sslAuthenticationOptions, ReadOnlySpan<byte> clientProtocols)
	{
		throw new PlatformNotSupportedException("SelectApplicationProtocol");
	}

	public static ProtocolToken AcceptSecurityContext(ref SafeFreeCredentials credential, ref SafeDeleteSslContext context, ReadOnlySpan<byte> inputBuffer, out int consumed, SslAuthenticationOptions sslAuthenticationOptions)
	{
		return HandshakeInternal(credential, ref context, inputBuffer, out consumed, sslAuthenticationOptions);
	}

	public static ProtocolToken InitializeSecurityContext(ref SafeFreeCredentials credential, ref SafeDeleteSslContext context, string targetName, ReadOnlySpan<byte> inputBuffer, out int consumed, SslAuthenticationOptions sslAuthenticationOptions)
	{
		return HandshakeInternal(credential, ref context, inputBuffer, out consumed, sslAuthenticationOptions);
	}

	public static SafeFreeCredentials AcquireCredentialsHandle(SslAuthenticationOptions _1, bool _2)
	{
		return null;
	}

	public static ProtocolToken EncryptMessage(SafeDeleteSslContext securityContext, ReadOnlyMemory<byte> input, int headerSize, int trailerSize)
	{
		ProtocolToken token = default(ProtocolToken);
		try
		{
			token.Status = new SecurityStatusPal(global::Interop.AndroidCrypto.SSLStreamWrite(securityContext.SslContext, input) switch
			{
				global::Interop.AndroidCrypto.PAL_SSLStreamStatus.OK => SecurityStatusPalErrorCode.OK, 
				global::Interop.AndroidCrypto.PAL_SSLStreamStatus.NeedData => SecurityStatusPalErrorCode.ContinueNeeded, 
				global::Interop.AndroidCrypto.PAL_SSLStreamStatus.Renegotiate => SecurityStatusPalErrorCode.Renegotiate, 
				global::Interop.AndroidCrypto.PAL_SSLStreamStatus.Closed => SecurityStatusPalErrorCode.ContextExpired, 
				_ => SecurityStatusPalErrorCode.InternalError, 
			});
			securityContext.ReadPendingWrites(ref token);
		}
		catch (Exception exception)
		{
			token.Status = new SecurityStatusPal(SecurityStatusPalErrorCode.InternalError, exception);
		}
		return token;
	}

	public static SecurityStatusPal DecryptMessage(SafeDeleteSslContext securityContext, Span<byte> buffer, out int offset, out int count)
	{
		offset = 0;
		count = 0;
		try
		{
			SafeSslHandle sslContext = securityContext.SslContext;
			securityContext.Write(buffer);
			int bytesRead;
			global::Interop.AndroidCrypto.PAL_SSLStreamStatus pAL_SSLStreamStatus = global::Interop.AndroidCrypto.SSLStreamRead(sslContext, buffer, out bytesRead);
			if (pAL_SSLStreamStatus == global::Interop.AndroidCrypto.PAL_SSLStreamStatus.Error)
			{
				return new SecurityStatusPal(SecurityStatusPalErrorCode.InternalError);
			}
			count = bytesRead;
			return new SecurityStatusPal(pAL_SSLStreamStatus switch
			{
				global::Interop.AndroidCrypto.PAL_SSLStreamStatus.OK => SecurityStatusPalErrorCode.OK, 
				global::Interop.AndroidCrypto.PAL_SSLStreamStatus.NeedData => SecurityStatusPalErrorCode.OK, 
				global::Interop.AndroidCrypto.PAL_SSLStreamStatus.Renegotiate => SecurityStatusPalErrorCode.Renegotiate, 
				global::Interop.AndroidCrypto.PAL_SSLStreamStatus.Closed => SecurityStatusPalErrorCode.ContextExpired, 
				_ => SecurityStatusPalErrorCode.InternalError, 
			});
		}
		catch (Exception exception)
		{
			return new SecurityStatusPal(SecurityStatusPalErrorCode.InternalError, exception);
		}
	}

	public static ChannelBinding QueryContextChannelBinding(SafeDeleteContext securityContext, ChannelBindingKind attribute)
	{
		if (attribute == ChannelBindingKind.Endpoint)
		{
			return EndpointChannelBindingToken.Build(securityContext);
		}
		return null;
	}

	public static void QueryContextStreamSizes(SafeDeleteContext securityContext, out StreamSizes streamSizes)
	{
		streamSizes = StreamSizes.Default;
	}

	public static void QueryContextConnectionInfo(SafeDeleteSslContext securityContext, ref SslConnectionInfo connectionInfo)
	{
		connectionInfo.UpdateSslConnectionInfo(securityContext.SslContext);
	}

	public static bool TryUpdateClintCertificate(SafeFreeCredentials _1, SafeDeleteSslContext _2, SslAuthenticationOptions _3)
	{
		return false;
	}

	private static ProtocolToken HandshakeInternal(SafeFreeCredentials credential, ref SafeDeleteSslContext context, ReadOnlySpan<byte> inputBuffer, out int consumed, SslAuthenticationOptions sslAuthenticationOptions)
	{
		ProtocolToken token = default(ProtocolToken);
		consumed = 0;
		try
		{
			SafeDeleteSslContext safeDeleteSslContext = context;
			if (context == null || context.IsInvalid)
			{
				context = new SafeDeleteSslContext(sslAuthenticationOptions);
				safeDeleteSslContext = context;
			}
			if (inputBuffer.Length > 0)
			{
				safeDeleteSslContext.Write(inputBuffer);
			}
			consumed = inputBuffer.Length;
			SecurityStatusPalErrorCode errorCode = global::Interop.AndroidCrypto.SSLStreamHandshake(safeDeleteSslContext.SslContext) switch
			{
				global::Interop.AndroidCrypto.PAL_SSLStreamStatus.OK => SecurityStatusPalErrorCode.OK, 
				global::Interop.AndroidCrypto.PAL_SSLStreamStatus.NeedData => SecurityStatusPalErrorCode.ContinueNeeded, 
				_ => SecurityStatusPalErrorCode.InternalError, 
			};
			Exception exception = safeDeleteSslContext?.SslStreamProxy.ValidationException;
			token.Status = new SecurityStatusPal(errorCode, exception);
			safeDeleteSslContext.ReadPendingWrites(ref token);
			return token;
		}
		catch (Exception exception2)
		{
			token.Status = new SecurityStatusPal(SecurityStatusPalErrorCode.InternalError, exception2);
			return token;
		}
	}

	public static SecurityStatusPal ApplyAlertToken(SafeDeleteContext securityContext, TlsAlertType alertType, TlsAlertMessage alertMessage)
	{
		return new SecurityStatusPal(SecurityStatusPalErrorCode.OK);
	}
}
