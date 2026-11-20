using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace System.Net;

internal sealed class SafeDeleteSslContext : SafeDeleteContext
{
	private static readonly SslProtocols[] s_orderedSslProtocols = new SslProtocols[4]
	{
		SslProtocols.Tls,
		SslProtocols.Tls11,
		SslProtocols.Tls12,
		SslProtocols.Tls13
	};

	private static readonly Lazy<SslProtocols> s_supportedSslProtocols = new Lazy<SslProtocols>(global::Interop.AndroidCrypto.SSLGetSupportedProtocols);

	private readonly SafeSslHandle _sslContext;

	private readonly Lock _lock = new Lock();

	private ArrayBuffer _inputBuffer = new ArrayBuffer(2048);

	private ArrayBuffer _outputBuffer = new ArrayBuffer(2048);

	private volatile bool _disposed;

	public SslStream.JavaProxy SslStreamProxy { get; }

	public SafeSslHandle SslContext => _sslContext;

	public override bool IsInvalid => _sslContext?.IsInvalid ?? true;

	public SafeDeleteSslContext(SslAuthenticationOptions authOptions)
		: base(IntPtr.Zero)
	{
		SslStreamProxy = authOptions.SslStreamProxy ?? throw new ArgumentNullException("SslStreamProxy");
		try
		{
			_sslContext = CreateSslContext(SslStreamProxy, authOptions);
			InitializeSslContext(_sslContext, authOptions);
		}
		catch (Exception)
		{
			Dispose();
			throw;
		}
	}

	protected override void Dispose(bool disposing)
	{
		using (_lock.EnterScope())
		{
			if (!_disposed)
			{
				_disposed = true;
				_sslContext.Dispose();
				if (disposing)
				{
					_inputBuffer.Dispose();
					_outputBuffer.Dispose();
				}
			}
		}
		base.Dispose(disposing);
	}

	[UnmanagedCallersOnly]
	private unsafe static void WriteToConnection(nint connection, byte* data, int dataLength)
	{
		if (!WeakGCHandle<SafeDeleteSslContext>.FromIntPtr(connection).TryGetTarget(out SafeDeleteSslContext target))
		{
			return;
		}
		using (target._lock.EnterScope())
		{
			if (!target._disposed)
			{
				ReadOnlySpan<byte> readOnlySpan = new ReadOnlySpan<byte>(data, dataLength);
				target._outputBuffer.EnsureAvailableSpace(dataLength);
				readOnlySpan.CopyTo(target._outputBuffer.AvailableSpan);
				target._outputBuffer.Commit(dataLength);
			}
		}
	}

	[UnmanagedCallersOnly]
	private unsafe static global::Interop.AndroidCrypto.PAL_SSLStreamStatus ReadFromConnection(nint connection, byte* data, int* dataLength)
	{
		if (!WeakGCHandle<SafeDeleteSslContext>.FromIntPtr(connection).TryGetTarget(out SafeDeleteSslContext target))
		{
			*dataLength = 0;
			return global::Interop.AndroidCrypto.PAL_SSLStreamStatus.Error;
		}
		using (target._lock.EnterScope())
		{
			if (target._disposed)
			{
				*dataLength = 0;
				return global::Interop.AndroidCrypto.PAL_SSLStreamStatus.Error;
			}
			int num = *dataLength;
			if (num == 0)
			{
				return global::Interop.AndroidCrypto.PAL_SSLStreamStatus.OK;
			}
			if (target._inputBuffer.ActiveLength == 0)
			{
				*dataLength = 0;
				return global::Interop.AndroidCrypto.PAL_SSLStreamStatus.NeedData;
			}
			num = Math.Min(num, target._inputBuffer.ActiveLength);
			target._inputBuffer.ActiveSpan.Slice(0, num).CopyTo(new Span<byte>(data, num));
			target._inputBuffer.Discard(num);
			*dataLength = num;
			return global::Interop.AndroidCrypto.PAL_SSLStreamStatus.OK;
		}
	}

	[UnmanagedCallersOnly]
	private static void CleanupManagedContext(nint managedContextHandle)
	{
		if (managedContextHandle != IntPtr.Zero)
		{
			WeakGCHandle<SafeDeleteSslContext>.FromIntPtr(managedContextHandle).Dispose();
		}
	}

	internal void Write(ReadOnlySpan<byte> buf)
	{
		using (_lock.EnterScope())
		{
			_inputBuffer.EnsureAvailableSpace(buf.Length);
			buf.CopyTo(_inputBuffer.AvailableSpan);
			_inputBuffer.Commit(buf.Length);
		}
	}

	internal void ReadPendingWrites(ref ProtocolToken token)
	{
		using (_lock.EnterScope())
		{
			if (_outputBuffer.ActiveLength == 0)
			{
				token.Size = 0;
				token.Payload = null;
			}
			else
			{
				token.SetPayload(_outputBuffer.ActiveSpan);
				_outputBuffer.Discard(_outputBuffer.ActiveLength);
			}
		}
	}

	private static SafeSslHandle CreateSslContext(SslStream.JavaProxy sslStreamProxy, SslAuthenticationOptions authOptions)
	{
		if (authOptions.CertificateContext == null)
		{
			return global::Interop.AndroidCrypto.SSLStreamCreate(sslStreamProxy);
		}
		SslStreamCertificateContext certificateContext = authOptions.CertificateContext;
		X509Certificate2 targetCertificate = certificateContext.TargetCertificate;
		if (global::Interop.AndroidCrypto.IsKeyStorePrivateKeyEntry(targetCertificate.Handle))
		{
			return global::Interop.AndroidCrypto.SSLStreamCreateWithKeyStorePrivateKeyEntry(sslStreamProxy, targetCertificate.Handle);
		}
		global::Interop.AndroidCrypto.PAL_KeyAlgorithm algorithm;
		byte[] array;
		using (AsymmetricAlgorithm asymmetricAlgorithm = GetPrivateKeyAlgorithm(targetCertificate, out algorithm))
		{
			array = asymmetricAlgorithm.ExportPkcs8PrivateKey();
		}
		nint[] array2 = new nint[certificateContext.IntermediateCertificates.Count + 1];
		array2[0] = targetCertificate.Handle;
		for (int i = 0; i < certificateContext.IntermediateCertificates.Count; i++)
		{
			array2[i + 1] = certificateContext.IntermediateCertificates[i].Handle;
		}
		return global::Interop.AndroidCrypto.SSLStreamCreateWithCertificates(sslStreamProxy, array, algorithm, array2);
	}

	private static AsymmetricAlgorithm GetPrivateKeyAlgorithm(X509Certificate2 cert, out global::Interop.AndroidCrypto.PAL_KeyAlgorithm algorithm)
	{
		AsymmetricAlgorithm rSAPrivateKey = cert.GetRSAPrivateKey();
		if (rSAPrivateKey != null)
		{
			algorithm = global::Interop.AndroidCrypto.PAL_KeyAlgorithm.RSA;
			return rSAPrivateKey;
		}
		rSAPrivateKey = cert.GetECDsaPrivateKey();
		if (rSAPrivateKey != null)
		{
			algorithm = global::Interop.AndroidCrypto.PAL_KeyAlgorithm.EC;
			return rSAPrivateKey;
		}
		rSAPrivateKey = cert.GetDSAPrivateKey();
		if (rSAPrivateKey != null)
		{
			algorithm = global::Interop.AndroidCrypto.PAL_KeyAlgorithm.DSA;
			return rSAPrivateKey;
		}
		throw new NotSupportedException("net_ssl_io_no_server_cert");
	}

	private unsafe void InitializeSslContext(SafeSslHandle handle, SslAuthenticationOptions authOptions)
	{
		EncryptionPolicy encryptionPolicy = authOptions.EncryptionPolicy;
		if ((uint)encryptionPolicy > 1u)
		{
			throw new PlatformNotSupportedException(System.SR.Format("net_encryptionpolicy_notsupported", authOptions.EncryptionPolicy));
		}
		bool isServer = authOptions.IsServer;
		if (authOptions.CipherSuitesPolicy != null)
		{
			throw new NotImplementedException("SafeDeleteSslContext");
		}
		nint managedContextHandle = GCHandle.ToIntPtr(GCHandle.Alloc(this, GCHandleType.Weak));
		string peerHost = ((!isServer && !string.IsNullOrEmpty(authOptions.TargetHost)) ? authOptions.TargetHost : null);
		global::Interop.AndroidCrypto.SSLStreamInitialize(handle, isServer, managedContextHandle, (delegate* unmanaged<nint, byte*, int*, global::Interop.AndroidCrypto.PAL_SSLStreamStatus>)(delegate*<nint, byte*, int*, global::Interop.AndroidCrypto.PAL_SSLStreamStatus>)(&ReadFromConnection), (delegate* unmanaged<nint, byte*, int, void>)(delegate*<nint, byte*, int, void>)(&WriteToConnection), (delegate* unmanaged<nint, void>)(delegate*<nint, void>)(&CleanupManagedContext), 2048, peerHost);
		if (authOptions.EnabledSslProtocols != SslProtocols.None)
		{
			SslProtocols num = authOptions.EnabledSslProtocols & s_supportedSslProtocols.Value;
			if (num == SslProtocols.None)
			{
				throw new PlatformNotSupportedException(System.SR.Format("net_security_sslprotocol_notsupported", authOptions.EnabledSslProtocols));
			}
			var (num2, num3) = num.ValidateContiguous(s_orderedSslProtocols);
			global::Interop.AndroidCrypto.SSLStreamSetEnabledProtocols(handle, s_orderedSslProtocols.AsSpan(num2, num3 - num2 + 1));
		}
		if (authOptions.ApplicationProtocols != null && authOptions.ApplicationProtocols.Count != 0 && global::Interop.AndroidCrypto.SSLSupportsApplicationProtocolsConfiguration())
		{
			global::Interop.AndroidCrypto.SSLStreamSetApplicationProtocols(handle, authOptions.ApplicationProtocols);
		}
		if (isServer && authOptions.RemoteCertRequired)
		{
			global::Interop.AndroidCrypto.SSLStreamRequestClientAuthentication(handle);
		}
		if (!isServer && !string.IsNullOrEmpty(authOptions.TargetHost) && !IPAddress.IsValid(authOptions.TargetHost.AsSpan()))
		{
			global::Interop.AndroidCrypto.SSLStreamSetTargetHost(handle, authOptions.TargetHost);
		}
	}
}
