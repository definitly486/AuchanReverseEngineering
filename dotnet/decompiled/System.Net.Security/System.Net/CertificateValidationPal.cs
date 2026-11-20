using System.Net.Security;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace System.Net;

internal static class CertificateValidationPal
{
	private static readonly object s_syncObject = new object();

	private static volatile X509Store s_myCertStoreEx;

	private static volatile X509Store s_myMachineCertStoreEx;

	private static X509Chain s_chain;

	internal static X509Certificate2 GetRemoteCertificate(SafeDeleteContext securityContext)
	{
		return GetRemoteCertificate(securityContext, retrieveChainCertificates: false, ref s_chain, null);
	}

	internal static X509Certificate2 GetRemoteCertificate(SafeDeleteContext securityContext, ref X509Chain chain, X509ChainPolicy chainPolicy)
	{
		return GetRemoteCertificate(securityContext, retrieveChainCertificates: true, ref chain, chainPolicy);
	}

	internal static X509Store EnsureStoreOpened(bool isMachineStore)
	{
		X509Store x509Store = (isMachineStore ? s_myMachineCertStoreEx : s_myCertStoreEx);
		if (x509Store == null)
		{
			StoreLocation storeLocation = ((!isMachineStore) ? StoreLocation.CurrentUser : StoreLocation.LocalMachine);
			if (1 == 0)
			{
			}
			lock (s_syncObject)
			{
				x509Store = (isMachineStore ? s_myMachineCertStoreEx : s_myCertStoreEx);
				if (x509Store == null)
				{
					try
					{
						x509Store = OpenStore(storeLocation);
						if (System.Net.NetEventSource.Log.IsEnabled())
						{
						}
						if (isMachineStore)
						{
							s_myMachineCertStoreEx = x509Store;
						}
						else
						{
							s_myCertStoreEx = x509Store;
						}
					}
					catch (Exception ex)
					{
						if (ex is CryptographicException || ex is SecurityException)
						{
							return null;
						}
						if (System.Net.NetEventSource.Log.IsEnabled())
						{
						}
						throw;
					}
				}
			}
		}
		return x509Store;
	}

	internal static SslPolicyErrors VerifyCertificateProperties(SafeDeleteContext securityContext, X509Chain chain, X509Certificate2 remoteCertificate, bool checkCertName, bool _, string hostName)
	{
		if (remoteCertificate == null)
		{
			return SslPolicyErrors.RemoteCertificateNotAvailable;
		}
		SslPolicyErrors sslPolicyErrors = ((!chain.Build(remoteCertificate)) ? SslPolicyErrors.RemoteCertificateChainErrors : SslPolicyErrors.None);
		if (checkCertName && !global::Interop.AndroidCrypto.SSLStreamVerifyHostname(((SafeDeleteSslContext)securityContext).SslContext, hostName))
		{
			sslPolicyErrors |= SslPolicyErrors.RemoteCertificateNameMismatch;
		}
		return sslPolicyErrors;
	}

	private static X509Certificate2 GetRemoteCertificate(SafeDeleteContext securityContext, bool retrieveChainCertificates, ref X509Chain chain, X509ChainPolicy chainPolicy)
	{
		SafeSslHandle safeSslHandle = ((SafeDeleteSslContext)securityContext)?.SslContext;
		if (safeSslHandle == null)
		{
			return null;
		}
		X509Certificate2 result = null;
		if (!retrieveChainCertificates)
		{
			using System.Security.Cryptography.X509Certificates.SafeX509Handle safeX509Handle = global::Interop.AndroidCrypto.SSLStreamGetPeerCertificate(safeSslHandle);
			if (!safeX509Handle.IsInvalid)
			{
				result = new X509Certificate2(safeX509Handle.DangerousGetHandle());
			}
		}
		else
		{
			if (chain == null)
			{
				chain = new X509Chain();
			}
			if (chainPolicy != null)
			{
				chain.ChainPolicy = chainPolicy;
			}
			nint[] array = global::Interop.AndroidCrypto.SSLStreamGetPeerCertificates(safeSslHandle);
			if (array != null && array.Length != 0)
			{
				result = new X509Certificate2(array[0]);
				nint[] array2 = array;
				for (int i = 0; i < array2.Length; i++)
				{
					using System.Security.Cryptography.X509Certificates.SafeX509Handle safeX509Handle2 = new System.Security.Cryptography.X509Certificates.SafeX509Handle(array2[i]);
					chain.ChainPolicy.ExtraStore.Add(new X509Certificate2(safeX509Handle2.DangerousGetHandle()));
				}
			}
		}
		return result;
	}

	internal static bool IsLocalCertificateUsed(SafeFreeCredentials _, SafeDeleteContext securityContext)
	{
		SafeSslHandle safeSslHandle = ((SafeDeleteSslContext)securityContext)?.SslContext;
		if (safeSslHandle == null)
		{
			return false;
		}
		return global::Interop.AndroidCrypto.SSLStreamIsLocalCertificateUsed(safeSslHandle);
	}

	internal static string[] GetRequestCertificateAuthorities(SafeDeleteContext securityContext)
	{
		if (((SafeDeleteSslContext)securityContext).SslContext == null)
		{
			return Array.Empty<string>();
		}
		throw new NotImplementedException("GetRequestCertificateAuthorities");
	}

	private static X509Store OpenStore(StoreLocation storeLocation)
	{
		X509Store x509Store = new X509Store(StoreName.My, storeLocation);
		x509Store.Open(OpenFlags.ReadOnly);
		return x509Store;
	}
}
