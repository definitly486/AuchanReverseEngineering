using System.Collections;
using System.Collections.Generic;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Cryptography.X509Certificates;

public class X509Certificate2Collection : X509CertificateCollection, IEnumerable<X509Certificate2>, IEnumerable
{
	public new X509Certificate2 this[int index] => (X509Certificate2)base[index];

	public int Add(X509Certificate2 certificate)
	{
		ArgumentNullException.ThrowIfNull(certificate, "certificate");
		return Add((X509Certificate)certificate);
	}

	public void AddRange(X509Certificate2[] certificates)
	{
		ArgumentNullException.ThrowIfNull(certificates, "certificates");
		int i = 0;
		try
		{
			for (; i < certificates.Length; i++)
			{
				Add(certificates[i]);
			}
		}
		catch
		{
			for (int j = 0; j < i; j++)
			{
				Remove(certificates[j]);
			}
			throw;
		}
	}

	public void AddRange(X509Certificate2Collection certificates)
	{
		ArgumentNullException.ThrowIfNull(certificates, "certificates");
		int i = 0;
		try
		{
			for (; i < certificates.Count; i++)
			{
				Add(certificates[i]);
			}
		}
		catch
		{
			for (int j = 0; j < i; j++)
			{
				Remove(certificates[j]);
			}
			throw;
		}
	}

	public byte[]? Export(X509ContentType contentType)
	{
		using IExportPal exportPal = StorePal.LinkFromCertificateCollection(this);
		return exportPal.Export(contentType, SafePasswordHandle.InvalidHandle);
	}

	public new X509Certificate2Enumerator GetEnumerator()
	{
		return new X509Certificate2Enumerator(this);
	}

	IEnumerator<X509Certificate2> IEnumerable<X509Certificate2>.GetEnumerator()
	{
		return GetEnumerator();
	}

	[Obsolete("Loading certificate data through the constructor or Import is obsolete. Use X509CertificateLoader instead to load certificates.", DiagnosticId = "SYSLIB0057", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public void Import(ReadOnlySpan<byte> rawData)
	{
		using ILoaderPal loaderPal = StorePal.FromBlob(rawData, SafePasswordHandle.InvalidHandle, X509KeyStorageFlags.DefaultKeySet);
		loaderPal.MoveTo(this);
	}

	public void Remove(X509Certificate2 certificate)
	{
		ArgumentNullException.ThrowIfNull(certificate, "certificate");
		Remove((X509Certificate)certificate);
	}

	public X509Certificate2Collection FindByThumbprint(HashAlgorithmName hashAlgorithm, ReadOnlySpan<byte> thumbprintBytes)
	{
		ArgumentException.ThrowIfNullOrEmpty(hashAlgorithm.Name, "hashAlgorithm");
		return FindByThumbprintCore(hashAlgorithm, thumbprintBytes);
	}

	private X509Certificate2Collection FindByThumbprintCore(HashAlgorithmName hashAlgorithm, ReadOnlySpan<byte> thumbprintBytes)
	{
		Span<byte> destination = stackalloc byte[64];
		X509Certificate2Collection x509Certificate2Collection = new X509Certificate2Collection();
		using X509Certificate2Enumerator x509Certificate2Enumerator = GetEnumerator();
		while (x509Certificate2Enumerator.MoveNext())
		{
			X509Certificate2 current = x509Certificate2Enumerator.Current;
			if (((ReadOnlySpan<byte>)destination[..CryptographicOperations.HashData(hashAlgorithm, current.RawDataMemory.Span, destination)]).SequenceEqual(thumbprintBytes))
			{
				x509Certificate2Collection.Add(current);
			}
		}
		return x509Certificate2Collection;
	}
}
