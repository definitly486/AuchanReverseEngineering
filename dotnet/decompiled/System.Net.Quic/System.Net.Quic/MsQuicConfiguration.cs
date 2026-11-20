using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Microsoft.Quic;

namespace System.Net.Quic;

internal static class MsQuicConfiguration
{
	private sealed class MsQuicConfigurationCache : SafeHandleCache<CacheKey, MsQuicConfigurationSafeHandle>
	{
	}

	private readonly struct CacheKey : IEquatable<CacheKey>
	{
		public readonly ReadOnlyMemory<byte> CertificateThumbprints;

		public readonly QUIC_CREDENTIAL_FLAGS Flags;

		public readonly QUIC_SETTINGS Settings;

		public readonly List<SslApplicationProtocol> ApplicationProtocols;

		public readonly QUIC_ALLOWED_CIPHER_SUITE_FLAGS AllowedCipherSuites;

		public CacheKey(QUIC_SETTINGS settings, QUIC_CREDENTIAL_FLAGS flags, X509Certificate certificate, ReadOnlyCollection<X509Certificate2> intermediates, List<SslApplicationProtocol> alpnProtocols, QUIC_ALLOWED_CIPHER_SUITE_FLAGS allowedCipherSuites)
		{
			int num = ((certificate != null) ? 1 : 0);
			num += intermediates?.Count ?? 0;
			byte[] array = new byte[num * 64];
			num = 0;
			int bytesWritten;
			if (certificate != null)
			{
				certificate.TryGetCertHash(HashAlgorithmName.SHA512, array.AsSpan(0, 64), out bytesWritten);
				num++;
			}
			if (intermediates != null)
			{
				foreach (X509Certificate2 intermediate in intermediates)
				{
					intermediate.TryGetCertHash(HashAlgorithmName.SHA512, array.AsSpan(num * 64, 64), out bytesWritten);
					num++;
				}
			}
			CertificateThumbprints = array;
			Flags = flags;
			Settings = settings;
			ApplicationProtocols = new List<SslApplicationProtocol>(alpnProtocols);
			AllowedCipherSuites = allowedCipherSuites;
		}

		public override bool Equals(object obj)
		{
			if (obj is CacheKey other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(CacheKey other)
		{
			if (!CertificateThumbprints.Span.SequenceEqual(other.CertificateThumbprints.Span))
			{
				return false;
			}
			if (ApplicationProtocols.Count != other.ApplicationProtocols.Count)
			{
				return false;
			}
			for (int i = 0; i < ApplicationProtocols.Count; i++)
			{
				if (ApplicationProtocols[i] != other.ApplicationProtocols[i])
				{
					return false;
				}
			}
			if (Flags == other.Flags && Settings.Equals(other.Settings))
			{
				return AllowedCipherSuites == other.AllowedCipherSuites;
			}
			return false;
		}

		public override int GetHashCode()
		{
			HashCode hashCode = default(HashCode);
			hashCode.AddBytes(CertificateThumbprints.Span);
			hashCode.Add(Flags);
			hashCode.Add(Settings);
			foreach (SslApplicationProtocol applicationProtocol in ApplicationProtocols)
			{
				hashCode.AddBytes(applicationProtocol.Protocol.Span);
			}
			hashCode.Add(AllowedCipherSuites);
			return hashCode.ToHashCode();
		}
	}

	private static readonly MsQuicConfigurationCache s_configurationCache = new MsQuicConfigurationCache();

	internal static bool ConfigurationCacheEnabled { get; } = !AppContextSwitchHelper.GetBooleanConfig("System.Net.Quic.DisableConfigurationCache", "DOTNET_SYSTEM_NET_QUIC_DISABLE_CONFIGURATION_CACHE");

	private static MsQuicConfigurationSafeHandle GetCachedCredentialOrCreate(QUIC_SETTINGS settings, QUIC_CREDENTIAL_FLAGS flags, X509Certificate certificate, ReadOnlyCollection<X509Certificate2> intermediates, List<SslApplicationProtocol> alpnProtocols, QUIC_ALLOWED_CIPHER_SUITE_FLAGS allowedCipherSuites)
	{
		CacheKey key = new CacheKey(settings, flags, certificate, intermediates, alpnProtocols, allowedCipherSuites);
		return s_configurationCache.GetOrCreate(key, delegate((QUIC_SETTINGS settings, QUIC_CREDENTIAL_FLAGS flags, X509Certificate certificate, ReadOnlyCollection<X509Certificate2> intermediates, List<SslApplicationProtocol> alpnProtocols, QUIC_ALLOWED_CIPHER_SUITE_FLAGS allowedCipherSuites) args)
		{
			var (settings2, flags2, certificate2, intermediates2, alpnProtocols2, allowedCipherSuites2) = args;
			return CreateInternal(settings2, flags2, certificate2, intermediates2, alpnProtocols2, allowedCipherSuites2);
		}, (settings, flags, certificate, intermediates, alpnProtocols, allowedCipherSuites));
	}

	private static bool HasPrivateKey(this X509Certificate certificate)
	{
		if (certificate is X509Certificate2 x509Certificate && x509Certificate.Handle != IntPtr.Zero)
		{
			return x509Certificate.HasPrivateKey;
		}
		return false;
	}

	public static MsQuicConfigurationSafeHandle Create(QuicClientConnectionOptions options)
	{
		SslClientAuthenticationOptions clientAuthenticationOptions = options.ClientAuthenticationOptions;
		QUIC_CREDENTIAL_FLAGS qUIC_CREDENTIAL_FLAGS = QUIC_CREDENTIAL_FLAGS.NONE;
		qUIC_CREDENTIAL_FLAGS |= QUIC_CREDENTIAL_FLAGS.CLIENT;
		qUIC_CREDENTIAL_FLAGS |= QUIC_CREDENTIAL_FLAGS.INDICATE_CERTIFICATE_RECEIVED;
		qUIC_CREDENTIAL_FLAGS |= QUIC_CREDENTIAL_FLAGS.NO_CERTIFICATE_VALIDATION;
		if (MsQuicApi.UsesSChannelBackend)
		{
			qUIC_CREDENTIAL_FLAGS |= QUIC_CREDENTIAL_FLAGS.USE_SUPPLIED_CREDENTIALS;
		}
		X509Certificate certificate = null;
		ReadOnlyCollection<X509Certificate2> intermediates = null;
		if (clientAuthenticationOptions.ClientCertificateContext != null)
		{
			certificate = clientAuthenticationOptions.ClientCertificateContext.TargetCertificate;
			intermediates = clientAuthenticationOptions.ClientCertificateContext.IntermediateCertificates;
		}
		else
		{
			if (clientAuthenticationOptions.LocalCertificateSelectionCallback == null)
			{
				goto IL_00af;
			}
			X509Certificate x509Certificate = clientAuthenticationOptions.LocalCertificateSelectionCallback(options, clientAuthenticationOptions.TargetHost ?? string.Empty, clientAuthenticationOptions.ClientCertificates ?? new X509CertificateCollection(), null, Array.Empty<string>());
			if (x509Certificate != null)
			{
				if (x509Certificate.HasPrivateKey())
				{
					certificate = x509Certificate;
				}
				else if (System.Net.NetEventSource.Log.IsEnabled())
				{
					goto IL_00af;
				}
			}
		}
		goto IL_0109;
		IL_00af:
		if (clientAuthenticationOptions.ClientCertificates != null)
		{
			foreach (X509Certificate clientCertificate in clientAuthenticationOptions.ClientCertificates)
			{
				if (clientCertificate.HasPrivateKey())
				{
					certificate = clientCertificate;
					break;
				}
				if (!System.Net.NetEventSource.Log.IsEnabled())
				{
				}
			}
		}
		goto IL_0109;
		IL_0109:
		return Create(options, qUIC_CREDENTIAL_FLAGS, certificate, intermediates, clientAuthenticationOptions.ApplicationProtocols, clientAuthenticationOptions.CipherSuitesPolicy, clientAuthenticationOptions.EncryptionPolicy);
	}

	private static MsQuicConfigurationSafeHandle Create(QuicConnectionOptions options, QUIC_CREDENTIAL_FLAGS flags, X509Certificate certificate, ReadOnlyCollection<X509Certificate2> intermediates, List<SslApplicationProtocol> alpnProtocols, CipherSuitesPolicy cipherSuitesPolicy, EncryptionPolicy encryptionPolicy)
	{
		if (alpnProtocols == null || alpnProtocols.Count <= 0)
		{
			throw new ArgumentException(System.SR.Format("net_quic_not_null_not_empty_connection", "SslApplicationProtocol"), "options");
		}
		if (encryptionPolicy == EncryptionPolicy.NoEncryption)
		{
			throw new PlatformNotSupportedException(System.SR.Format("net_quic_ssl_option", encryptionPolicy));
		}
		QUIC_SETTINGS settings = default(QUIC_SETTINGS);
		settings.IsSet.PeerUnidiStreamCount = 1uL;
		settings.PeerUnidiStreamCount = (ushort)options.MaxInboundUnidirectionalStreams;
		settings.IsSet.PeerBidiStreamCount = 1uL;
		settings.PeerBidiStreamCount = (ushort)options.MaxInboundBidirectionalStreams;
		if (options.IdleTimeout != TimeSpan.Zero)
		{
			settings.IsSet.IdleTimeoutMs = 1uL;
			settings.IdleTimeoutMs = ((options.IdleTimeout != Timeout.InfiniteTimeSpan) ? ((ulong)options.IdleTimeout.TotalMilliseconds) : 0);
		}
		if (options.KeepAliveInterval != TimeSpan.Zero)
		{
			settings.IsSet.KeepAliveIntervalMs = 1uL;
			settings.KeepAliveIntervalMs = ((options.KeepAliveInterval != Timeout.InfiniteTimeSpan) ? ((uint)options.KeepAliveInterval.TotalMilliseconds) : 0u);
		}
		settings.IsSet.ConnFlowControlWindow = 1uL;
		settings.ConnFlowControlWindow = (uint)(options._initialReceiveWindowSizes?.Connection ?? 16777216);
		settings.IsSet.StreamRecvWindowBidiLocalDefault = 1uL;
		settings.StreamRecvWindowBidiLocalDefault = (uint)(options._initialReceiveWindowSizes?.LocallyInitiatedBidirectionalStream ?? 65536);
		settings.IsSet.StreamRecvWindowBidiRemoteDefault = 1uL;
		settings.StreamRecvWindowBidiRemoteDefault = (uint)(options._initialReceiveWindowSizes?.RemotelyInitiatedBidirectionalStream ?? 65536);
		settings.IsSet.StreamRecvWindowUnidiDefault = 1uL;
		settings.StreamRecvWindowUnidiDefault = (uint)(options._initialReceiveWindowSizes?.UnidirectionalStream ?? 65536);
		if (options.HandshakeTimeout != TimeSpan.Zero)
		{
			settings.IsSet.HandshakeIdleTimeoutMs = 1uL;
			settings.HandshakeIdleTimeoutMs = ((options.HandshakeTimeout != Timeout.InfiniteTimeSpan) ? ((ulong)options.HandshakeTimeout.TotalMilliseconds) : 0);
		}
		QUIC_ALLOWED_CIPHER_SUITE_FLAGS allowedCipherSuites = QUIC_ALLOWED_CIPHER_SUITE_FLAGS.NONE;
		if (cipherSuitesPolicy != null)
		{
			flags |= QUIC_CREDENTIAL_FLAGS.SET_ALLOWED_CIPHER_SUITES;
			allowedCipherSuites = CipherSuitePolicyToFlags(cipherSuitesPolicy);
		}
		if (!MsQuicApi.UsesSChannelBackend)
		{
			flags |= QUIC_CREDENTIAL_FLAGS.USE_PORTABLE_CERTIFICATES;
		}
		if (ConfigurationCacheEnabled)
		{
			return GetCachedCredentialOrCreate(settings, flags, certificate, intermediates, alpnProtocols, allowedCipherSuites);
		}
		return CreateInternal(settings, flags, certificate, intermediates, alpnProtocols, allowedCipherSuites);
	}

	private unsafe static MsQuicConfigurationSafeHandle CreateInternal(QUIC_SETTINGS settings, QUIC_CREDENTIAL_FLAGS flags, X509Certificate certificate, ReadOnlyCollection<X509Certificate2> intermediates, List<SslApplicationProtocol> alpnProtocols, QUIC_ALLOWED_CIPHER_SUITE_FLAGS allowedCipherSuites)
	{
		if (!MsQuicApi.UsesSChannelBackend && certificate is X509Certificate2 target && intermediates == null)
		{
			intermediates = SslStreamCertificateContext.Create(target, null, offline: true).IntermediateCertificates;
		}
		using MsQuicBuffers msQuicBuffers = new MsQuicBuffers();
		msQuicBuffers.Initialize(alpnProtocols, (SslApplicationProtocol alpnProtocol) => alpnProtocol.Protocol);
		Unsafe.SkipInit(out QUIC_HANDLE* handle);
		ThrowHelper.ThrowIfMsQuicError(MsQuicApi.Api.ConfigurationOpen(MsQuicApi.Api.Registration, msQuicBuffers.Buffers, (uint)msQuicBuffers.Count, &settings, (uint)sizeof(QUIC_SETTINGS), (void*)IntPtr.Zero, &handle), "ConfigurationOpen failed");
		MsQuicConfigurationSafeHandle msQuicConfigurationSafeHandle = new MsQuicConfigurationSafeHandle(handle);
		try
		{
			QUIC_CREDENTIAL_CONFIG qUIC_CREDENTIAL_CONFIG = new QUIC_CREDENTIAL_CONFIG
			{
				Flags = flags,
				AllowedCipherSuites = allowedCipherSuites
			};
			int status;
			if (certificate == null)
			{
				qUIC_CREDENTIAL_CONFIG.Type = QUIC_CREDENTIAL_TYPE.NONE;
				status = MsQuicApi.Api.ConfigurationLoadCredential(msQuicConfigurationSafeHandle, &qUIC_CREDENTIAL_CONFIG);
			}
			else if (MsQuicApi.UsesSChannelBackend)
			{
				qUIC_CREDENTIAL_CONFIG.Type = QUIC_CREDENTIAL_TYPE.CERTIFICATE_CONTEXT;
				qUIC_CREDENTIAL_CONFIG.CertificateContext = (void*)certificate.Handle;
				status = MsQuicApi.Api.ConfigurationLoadCredential(msQuicConfigurationSafeHandle, &qUIC_CREDENTIAL_CONFIG);
			}
			else
			{
				qUIC_CREDENTIAL_CONFIG.Type = QUIC_CREDENTIAL_TYPE.CERTIFICATE_PKCS12;
				byte[] array;
				if (intermediates != null && intermediates.Count > 0)
				{
					X509Certificate2Collection x509Certificate2Collection = new X509Certificate2Collection();
					x509Certificate2Collection.Add(certificate);
					foreach (X509Certificate2 intermediate in intermediates)
					{
						x509Certificate2Collection.Add(intermediate);
					}
					array = x509Certificate2Collection.Export(X509ContentType.Pfx);
				}
				else
				{
					array = certificate.Export(X509ContentType.Pfx);
				}
				fixed (byte* asn1Blob = array)
				{
					QUIC_CERTIFICATE_PKCS12 qUIC_CERTIFICATE_PKCS = new QUIC_CERTIFICATE_PKCS12
					{
						Asn1Blob = asn1Blob,
						Asn1BlobLength = (uint)array.Length,
						PrivateKeyPassword = (sbyte*)IntPtr.Zero
					};
					qUIC_CREDENTIAL_CONFIG.CertificatePkcs12 = &qUIC_CERTIFICATE_PKCS;
					status = MsQuicApi.Api.ConfigurationLoadCredential(msQuicConfigurationSafeHandle, &qUIC_CREDENTIAL_CONFIG);
				}
			}
			ThrowHelper.ThrowIfMsQuicError(status, "ConfigurationLoadCredential failed");
		}
		catch
		{
			msQuicConfigurationSafeHandle.Dispose();
			throw;
		}
		return msQuicConfigurationSafeHandle;
	}

	private static QUIC_ALLOWED_CIPHER_SUITE_FLAGS CipherSuitePolicyToFlags(CipherSuitesPolicy cipherSuitesPolicy)
	{
		QUIC_ALLOWED_CIPHER_SUITE_FLAGS qUIC_ALLOWED_CIPHER_SUITE_FLAGS = QUIC_ALLOWED_CIPHER_SUITE_FLAGS.NONE;
		using (IEnumerator<TlsCipherSuite> enumerator = cipherSuitesPolicy.AllowedCipherSuites.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				switch (enumerator.Current)
				{
				case TlsCipherSuite.TLS_AES_128_GCM_SHA256:
					qUIC_ALLOWED_CIPHER_SUITE_FLAGS |= QUIC_ALLOWED_CIPHER_SUITE_FLAGS.AES_128_GCM_SHA256;
					break;
				case TlsCipherSuite.TLS_AES_256_GCM_SHA384:
					qUIC_ALLOWED_CIPHER_SUITE_FLAGS |= QUIC_ALLOWED_CIPHER_SUITE_FLAGS.AES_256_GCM_SHA384;
					break;
				case TlsCipherSuite.TLS_CHACHA20_POLY1305_SHA256:
					qUIC_ALLOWED_CIPHER_SUITE_FLAGS |= QUIC_ALLOWED_CIPHER_SUITE_FLAGS.CHACHA20_POLY1305_SHA256;
					break;
				}
			}
		}
		if (qUIC_ALLOWED_CIPHER_SUITE_FLAGS == QUIC_ALLOWED_CIPHER_SUITE_FLAGS.NONE)
		{
			throw new ArgumentException("net_quic_empty_cipher_suite", "CipherSuitesPolicy");
		}
		return qUIC_ALLOWED_CIPHER_SUITE_FLAGS;
	}
}
