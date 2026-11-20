using System;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Android.Net.Http;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Security;
using Java.Security.Cert;
using Javax.Net.Ssl;
using Javax.Security.Cert;

namespace Xamarin.Android.Net;

internal sealed class ServerCertificateCustomValidator
{
	private sealed class TrustManager : Java.Lang.Object, IX509TrustManager, ITrustManager, IJavaObject, IDisposable, IJavaPeerable
	{
		private sealed class FakeSSLSession : Java.Lang.Object, ISSLSession, IJavaObject, IDisposable, IJavaPeerable
		{
			private readonly Java.Security.Cert.X509Certificate[] _certificates;

			public int ApplicationBufferSize
			{
				get
				{
					throw new InvalidOperationException();
				}
			}

			public string CipherSuite
			{
				get
				{
					throw new InvalidOperationException();
				}
			}

			public long CreationTime
			{
				get
				{
					throw new InvalidOperationException();
				}
			}

			public bool IsValid
			{
				get
				{
					throw new InvalidOperationException();
				}
			}

			public long LastAccessedTime
			{
				get
				{
					throw new InvalidOperationException();
				}
			}

			public IPrincipal LocalPrincipal
			{
				get
				{
					throw new InvalidOperationException();
				}
			}

			public int PacketBufferSize
			{
				get
				{
					throw new InvalidOperationException();
				}
			}

			public string PeerHost
			{
				get
				{
					throw new InvalidOperationException();
				}
			}

			public int PeerPort
			{
				get
				{
					throw new InvalidOperationException();
				}
			}

			public IPrincipal PeerPrincipal
			{
				get
				{
					throw new InvalidOperationException();
				}
			}

			public string Protocol
			{
				get
				{
					throw new InvalidOperationException();
				}
			}

			public ISSLSessionContext SessionContext
			{
				get
				{
					throw new InvalidOperationException();
				}
			}

			public FakeSSLSession(Java.Security.Cert.X509Certificate[] certificates)
			{
				_certificates = certificates;
			}

			public Java.Security.Cert.Certificate[] GetPeerCertificates()
			{
				return _certificates;
			}

			public byte[] GetId()
			{
				throw new InvalidOperationException();
			}

			public Java.Security.Cert.Certificate[] GetLocalCertificates()
			{
				throw new InvalidOperationException();
			}

			public Javax.Security.Cert.X509Certificate[] GetPeerCertificateChain()
			{
				throw new InvalidOperationException();
			}

			public Java.Lang.Object GetValue(string name)
			{
				throw new InvalidOperationException();
			}

			public string[] GetValueNames()
			{
				throw new InvalidOperationException();
			}

			public void Invalidate()
			{
				throw new InvalidOperationException();
			}

			public void PutValue(string name, Java.Lang.Object value)
			{
				throw new InvalidOperationException();
			}

			public void RemoveValue(string name)
			{
				throw new InvalidOperationException();
			}

			int IJavaPeerable.get_JniIdentityHashCode()
			{
				return base.JniIdentityHashCode;
			}

			JniObjectReference IJavaPeerable.get_PeerReference()
			{
				return base.PeerReference;
			}

			void IJavaPeerable.UnregisterFromRuntime()
			{
				UnregisterFromRuntime();
			}
		}

		private readonly IX509TrustManager _internalTrustManager;

		private readonly HttpRequestMessage _request;

		private readonly Func<HttpRequestMessage, X509Certificate2?, X509Chain?, SslPolicyErrors, bool> _serverCertificateCustomValidationCallback;

		public TrustManager(IX509TrustManager internalTrustManager, HttpRequestMessage request, Func<HttpRequestMessage, X509Certificate2?, X509Chain?, SslPolicyErrors, bool> serverCertificateCustomValidationCallback)
		{
			_request = request;
			_internalTrustManager = internalTrustManager;
			_serverCertificateCustomValidationCallback = serverCertificateCustomValidationCallback;
		}

		public void CheckServerTrusted(Java.Security.Cert.X509Certificate[] javaChain, string authType)
		{
			SslPolicyErrors sslPolicyErrors = SslPolicyErrors.None;
			try
			{
				new X509TrustManagerExtensions(_internalTrustManager).CheckServerTrusted(javaChain, authType, _request.RequestUri?.Host);
			}
			catch (CertificateException)
			{
				sslPolicyErrors |= SslPolicyErrors.RemoteCertificateChainErrors;
			}
			X509Certificate2[] array = Convert(javaChain);
			X509Certificate2 arg = null;
			if (array.Length != 0)
			{
				arg = array[0];
			}
			else
			{
				sslPolicyErrors |= SslPolicyErrors.RemoteCertificateNotAvailable;
			}
			if (!VerifyHostname(javaChain))
			{
				sslPolicyErrors |= SslPolicyErrors.RemoteCertificateNameMismatch;
			}
			if (!_serverCertificateCustomValidationCallback(_request, arg, CreateChain(array), sslPolicyErrors))
			{
				throw new CertificateException("The remote certificate was rejected by the provided RemoteCertificateValidationCallback.");
			}
		}

		public void CheckClientTrusted(Java.Security.Cert.X509Certificate[] chain, string authType)
		{
			_internalTrustManager.CheckClientTrusted(chain, authType);
		}

		public Java.Security.Cert.X509Certificate[] GetAcceptedIssuers()
		{
			return _internalTrustManager.GetAcceptedIssuers() ?? Array.Empty<Java.Security.Cert.X509Certificate>();
		}

		private bool VerifyHostname(Java.Security.Cert.X509Certificate[] javaChain)
		{
			FakeSSLSession session = new FakeSSLSession(javaChain);
			return HttpsURLConnection.DefaultHostnameVerifier?.Verify(_request.RequestUri?.Host, session) ?? false;
		}

		private static X509Chain CreateChain(X509Certificate2[] certificates)
		{
			X509Chain x509Chain = new X509Chain();
			x509Chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
			x509Chain.ChainPolicy.RevocationFlag = X509RevocationFlag.ExcludeRoot;
			x509Chain.ChainPolicy.ExtraStore.AddRange(certificates);
			return x509Chain;
		}

		private static X509Certificate2[] Convert(Java.Security.Cert.X509Certificate[] certificates)
		{
			X509Certificate2[] array = new X509Certificate2[certificates.Length];
			for (int i = 0; i < certificates.Length; i++)
			{
				byte[] data = certificates[i].GetEncoded() ?? throw new InvalidOperationException("The remote certificate was not available.");
				array[i] = X509CertificateLoader.LoadCertificate(data);
			}
			return array;
		}

		int IJavaPeerable.get_JniIdentityHashCode()
		{
			return base.JniIdentityHashCode;
		}

		JniObjectReference IJavaPeerable.get_PeerReference()
		{
			return base.PeerReference;
		}

		void IJavaPeerable.UnregisterFromRuntime()
		{
			UnregisterFromRuntime();
		}
	}

	private sealed class AlwaysAcceptingHostnameVerifier : Java.Lang.Object, IHostnameVerifier, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly Lazy<AlwaysAcceptingHostnameVerifier> s_instance = new Lazy<AlwaysAcceptingHostnameVerifier>(() => new AlwaysAcceptingHostnameVerifier());

		public static AlwaysAcceptingHostnameVerifier Instance => s_instance.Value;

		public bool Verify(string? hostname, ISSLSession? session)
		{
			return true;
		}

		int IJavaPeerable.get_JniIdentityHashCode()
		{
			return base.JniIdentityHashCode;
		}

		JniObjectReference IJavaPeerable.get_PeerReference()
		{
			return base.PeerReference;
		}

		void IJavaPeerable.UnregisterFromRuntime()
		{
			UnregisterFromRuntime();
		}
	}

	public IHostnameVerifier HostnameVerifier => AlwaysAcceptingHostnameVerifier.Instance;

	public Func<HttpRequestMessage, X509Certificate2?, X509Chain?, SslPolicyErrors, bool> Callback { get; set; }

	public ServerCertificateCustomValidator(Func<HttpRequestMessage, X509Certificate2?, X509Chain?, SslPolicyErrors, bool> callback)
	{
		Callback = callback;
	}

	public ITrustManager[] ReplaceX509TrustManager(ITrustManager[]? trustManagers, HttpRequestMessage requestMessage)
	{
		if (trustManagers == null)
		{
			trustManagers = Array.Empty<ITrustManager>();
		}
		int index;
		TrustManager replacement = new TrustManager(FindX509TrustManager(trustManagers, out index), requestMessage, Callback);
		return ModifyTrustManagersArray(trustManagers, index, replacement);
	}

	private static IX509TrustManager FindX509TrustManager(ITrustManager[] trustManagers, out int index)
	{
		for (int i = 0; i < trustManagers.Length; i++)
		{
			ITrustManager trustManager = trustManagers[i];
			if (trustManager is IX509TrustManager result)
			{
				index = i;
				return result;
			}
			if (Build.VERSION.SdkInt <= BuildVersionCodes.M && IsTrustManagerImpl(trustManager))
			{
				index = i;
				return Extensions.JavaCast<IX509TrustManager>(trustManager);
			}
		}
		throw new InvalidOperationException("Could not find IX509TrustManager in ITrustManager array.");
		static bool IsTrustManagerImpl(ITrustManager trustManager2)
		{
			return JNIEnv.GetClassNameFromInstance(trustManager2.Handle).Equals("com/android/org/conscrypt/TrustManagerImpl", StringComparison.Ordinal);
		}
	}

	private static ITrustManager[] ModifyTrustManagersArray(ITrustManager[] trustManagers, int originalTrustManagerIndex, IX509TrustManager replacement)
	{
		ITrustManager[] array = new ITrustManager[trustManagers.Length];
		for (int i = 0; i < trustManagers.Length; i++)
		{
			if (i == originalTrustManagerIndex)
			{
				array[i] = replacement;
			}
			else
			{
				array[i] = trustManagers[i];
			}
		}
		return array;
	}
}
