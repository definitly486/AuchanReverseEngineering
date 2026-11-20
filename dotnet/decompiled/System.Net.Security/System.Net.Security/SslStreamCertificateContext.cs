using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;

namespace System.Net.Security;

public class SslStreamCertificateContext
{
	internal readonly SslCertificateTrust Trust;

	public X509Certificate2 TargetCertificate { get; }

	public ReadOnlyCollection<X509Certificate2> IntermediateCertificates { get; }

	public static SslStreamCertificateContext Create(X509Certificate2 target, X509Certificate2Collection? additionalCertificates, bool offline = false, SslCertificateTrust? trust = null)
	{
		return Create(target, additionalCertificates, offline, trust, noOcspFetch: false);
	}

	internal static SslStreamCertificateContext Create(X509Certificate2 target, X509Certificate2Collection additionalCertificates, bool offline, SslCertificateTrust trust, bool noOcspFetch)
	{
		if (!target.HasPrivateKey)
		{
			throw new NotSupportedException("net_ssl_io_no_server_cert");
		}
		X509Certificate2[] array = Array.Empty<X509Certificate2>();
		X509Certificate2 x509Certificate = null;
		using (X509Chain x509Chain = new X509Chain())
		{
			if (additionalCertificates != null)
			{
				x509Chain.ChainPolicy.ExtraStore.AddRange(additionalCertificates);
			}
			if (trust != null)
			{
				if (trust._store != null)
				{
					x509Chain.ChainPolicy.CustomTrustStore.AddRange(trust._store.Certificates);
				}
				if (trust._trustList != null)
				{
					x509Chain.ChainPolicy.CustomTrustStore.AddRange(trust._trustList);
				}
				if (x509Chain.ChainPolicy.CustomTrustStore.Count > 0)
				{
					x509Chain.ChainPolicy.TrustMode = X509ChainTrustMode.CustomRootTrust;
				}
			}
			x509Chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
			x509Chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
			x509Chain.ChainPolicy.DisableCertificateDownloads = offline;
			bool flag = x509Chain.Build(target);
			if (flag || System.Net.NetEventSource.Log.IsEnabled())
			{
			}
			if (!flag && additionalCertificates != null && additionalCertificates.Count > 0)
			{
				x509Chain.ChainPolicy.CustomTrustStore.AddRange(additionalCertificates);
				x509Chain.ChainPolicy.TrustMode = X509ChainTrustMode.CustomRootTrust;
				if (!x509Chain.Build(target) && !System.Net.NetEventSource.Log.IsEnabled())
				{
				}
			}
			int num = x509Chain.ChainElements.Count - 1;
			if (num >= 0)
			{
				num--;
				x509Certificate = x509Chain.ChainElements[x509Chain.ChainElements.Count - 1].Certificate;
				X509ChainStatus[] chainStatus = x509Chain.ChainStatus;
				foreach (X509ChainStatus x509ChainStatus in chainStatus)
				{
					if (x509ChainStatus.Status.HasFlag(X509ChainStatusFlags.PartialChain))
					{
						num++;
						x509Certificate = null;
						break;
					}
				}
				if (num > 0 && x509Chain.ChainElements.Count > 1)
				{
					array = new X509Certificate2[num];
					for (int j = 0; j < num; j++)
					{
						array[j] = x509Chain.ChainElements[j + 1].Certificate;
					}
				}
				x509Chain.ChainElements[0].Certificate.Dispose();
				int num2 = ((x509Certificate == null) ? x509Chain.ChainElements.Count : (x509Chain.ChainElements.Count - 1));
				for (int k = num + 1; k < num2; k++)
				{
					x509Chain.ChainElements[k].Certificate.Dispose();
				}
			}
		}
		SslStreamCertificateContext result = new SslStreamCertificateContext(target, new ReadOnlyCollection<X509Certificate2>(array), trust);
		_ = 0;
		x509Certificate?.Dispose();
		return result;
	}

	internal SslStreamCertificateContext Duplicate()
	{
		X509Certificate2Collection x509Certificate2Collection = new X509Certificate2Collection();
		foreach (X509Certificate2 intermediateCertificate in IntermediateCertificates)
		{
			x509Certificate2Collection.Add(intermediateCertificate);
		}
		return Create(new X509Certificate2(TargetCertificate), x509Certificate2Collection, offline: false, Trust);
	}

	internal void ReleaseResources()
	{
		foreach (X509Certificate2 intermediateCertificate in IntermediateCertificates)
		{
			intermediateCertificate.Dispose();
		}
	}

	private SslStreamCertificateContext(X509Certificate2 target, ReadOnlyCollection<X509Certificate2> intermediates, SslCertificateTrust trust)
	{
		IntermediateCertificates = intermediates;
		TargetCertificate = target;
		Trust = trust;
	}
}
