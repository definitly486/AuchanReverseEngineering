using System.Runtime.Versioning;
using System.Text;

namespace System.Security.Cryptography.X509Certificates;

public class X509Certificate2 : X509Certificate
{
	private volatile Oid _lazySignatureAlgorithm;

	private volatile int _lazyVersion;

	private volatile X500DistinguishedName _lazySubjectName;

	private volatile X500DistinguishedName _lazyIssuerName;

	private volatile PublicKey _lazyPublicKey;

	private volatile AsymmetricAlgorithm _lazyPrivateKey;

	private volatile X509ExtensionCollection _lazyExtensions;

	internal new ICertificatePal Pal => (ICertificatePal)base.Pal;

	public X509ExtensionCollection Extensions
	{
		get
		{
			ThrowIfInvalid();
			X509ExtensionCollection x509ExtensionCollection = _lazyExtensions;
			if (x509ExtensionCollection == null)
			{
				x509ExtensionCollection = new X509ExtensionCollection();
				foreach (X509Extension extension in Pal.Extensions)
				{
					X509Extension x509Extension = CreateCustomExtensionIfAny(extension.Oid);
					if (x509Extension == null)
					{
						x509ExtensionCollection.Add(extension);
						continue;
					}
					x509Extension.CopyFrom(extension);
					x509ExtensionCollection.Add(x509Extension);
				}
				_lazyExtensions = x509ExtensionCollection;
			}
			return x509ExtensionCollection;
		}
	}

	public bool HasPrivateKey
	{
		get
		{
			ThrowIfInvalid();
			return Pal.HasPrivateKey;
		}
	}

	public X500DistinguishedName IssuerName
	{
		get
		{
			ThrowIfInvalid();
			return _lazyIssuerName ?? (_lazyIssuerName = Pal.IssuerName);
		}
	}

	public DateTime NotAfter => GetNotAfter();

	public DateTime NotBefore => GetNotBefore();

	public PublicKey PublicKey
	{
		get
		{
			ThrowIfInvalid();
			PublicKey publicKey = _lazyPublicKey;
			if (publicKey == null)
			{
				string keyAlgorithm = GetKeyAlgorithm();
				byte[] keyAlgorithmParameters = Pal.KeyAlgorithmParameters;
				byte[] publicKeyValue = Pal.PublicKeyValue;
				Oid oid = new Oid(keyAlgorithm);
				publicKey = (_lazyPublicKey = new PublicKey(oid, (keyAlgorithmParameters == null) ? null : new AsnEncodedData(oid, keyAlgorithmParameters), new AsnEncodedData(oid, publicKeyValue), skipCopy: true));
			}
			return publicKey;
		}
	}

	public byte[] RawData => RawDataMemory.ToArray();

	public ReadOnlyMemory<byte> RawDataMemory => base.PalRawDataMemory;

	public string SerialNumber => GetSerialNumberString();

	public Oid SignatureAlgorithm
	{
		get
		{
			ThrowIfInvalid();
			return _lazySignatureAlgorithm ?? (_lazySignatureAlgorithm = new Oid(Pal.SignatureAlgorithm, null));
		}
	}

	public X500DistinguishedName SubjectName
	{
		get
		{
			ThrowIfInvalid();
			return _lazySubjectName ?? (_lazySubjectName = Pal.SubjectName);
		}
	}

	public string Thumbprint => GetCertHashString();

	public int Version
	{
		get
		{
			ThrowIfInvalid();
			int num = _lazyVersion;
			if (num == 0)
			{
				num = (_lazyVersion = Pal.Version);
			}
			return num;
		}
	}

	public override void Reset()
	{
		_lazySignatureAlgorithm = null;
		_lazyVersion = 0;
		_lazySubjectName = null;
		_lazyIssuerName = null;
		_lazyPublicKey = null;
		_lazyPrivateKey = null;
		_lazyExtensions = null;
		base.Reset();
	}

	[UnsupportedOSPlatform("browser")]
	public X509Certificate2(nint handle)
		: base(handle)
	{
	}

	internal X509Certificate2(ICertificatePal pal)
		: base(pal)
	{
	}

	[UnsupportedOSPlatform("browser")]
	public X509Certificate2(X509Certificate certificate)
		: base(certificate)
	{
	}

	[UnsupportedOSPlatform("browser")]
	public static X509ContentType GetCertContentType(ReadOnlySpan<byte> rawData)
	{
		if (rawData.Length == 0)
		{
			throw new ArgumentException("Arg_EmptyOrNullArray", "rawData");
		}
		return X509Pal.Instance.GetCertContentType(rawData);
	}

	public string GetNameInfo(X509NameType nameType, bool forIssuer)
	{
		return Pal.GetNameInfo(nameType, forIssuer);
	}

	public override string ToString()
	{
		return base.ToString(fVerbose: true);
	}

	public override string ToString(bool verbose)
	{
		if (!verbose || Pal == null)
		{
			return ToString();
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("[Version]");
		stringBuilder.Append("  V");
		stringBuilder.Append(Version);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("[Subject]");
		stringBuilder.Append("  ");
		stringBuilder.Append(SubjectName.Name);
		string nameInfo = GetNameInfo(X509NameType.SimpleName, forIssuer: false);
		if (nameInfo.Length > 0)
		{
			stringBuilder.AppendLine();
			stringBuilder.Append("  ");
			stringBuilder.Append("Simple Name: ");
			stringBuilder.Append(nameInfo);
		}
		string nameInfo2 = GetNameInfo(X509NameType.EmailName, forIssuer: false);
		if (nameInfo2.Length > 0)
		{
			stringBuilder.AppendLine();
			stringBuilder.Append("  ");
			stringBuilder.Append("Email Name: ");
			stringBuilder.Append(nameInfo2);
		}
		string nameInfo3 = GetNameInfo(X509NameType.UpnName, forIssuer: false);
		if (nameInfo3.Length > 0)
		{
			stringBuilder.AppendLine();
			stringBuilder.Append("  ");
			stringBuilder.Append("UPN Name: ");
			stringBuilder.Append(nameInfo3);
		}
		string nameInfo4 = GetNameInfo(X509NameType.DnsName, forIssuer: false);
		if (nameInfo4.Length > 0)
		{
			stringBuilder.AppendLine();
			stringBuilder.Append("  ");
			stringBuilder.Append("DNS Name: ");
			stringBuilder.Append(nameInfo4);
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("[Issuer]");
		stringBuilder.Append("  ");
		stringBuilder.Append(IssuerName.Name);
		nameInfo = GetNameInfo(X509NameType.SimpleName, forIssuer: true);
		if (nameInfo.Length > 0)
		{
			stringBuilder.AppendLine();
			stringBuilder.Append("  ");
			stringBuilder.Append("Simple Name: ");
			stringBuilder.Append(nameInfo);
		}
		nameInfo2 = GetNameInfo(X509NameType.EmailName, forIssuer: true);
		if (nameInfo2.Length > 0)
		{
			stringBuilder.AppendLine();
			stringBuilder.Append("  ");
			stringBuilder.Append("Email Name: ");
			stringBuilder.Append(nameInfo2);
		}
		nameInfo3 = GetNameInfo(X509NameType.UpnName, forIssuer: true);
		if (nameInfo3.Length > 0)
		{
			stringBuilder.AppendLine();
			stringBuilder.Append("  ");
			stringBuilder.Append("UPN Name: ");
			stringBuilder.Append(nameInfo3);
		}
		nameInfo4 = GetNameInfo(X509NameType.DnsName, forIssuer: true);
		if (nameInfo4.Length > 0)
		{
			stringBuilder.AppendLine();
			stringBuilder.Append("  ");
			stringBuilder.Append("DNS Name: ");
			stringBuilder.Append(nameInfo4);
		}
		stringBuilder.AppendLine();
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("[Serial Number]");
		stringBuilder.Append("  ");
		stringBuilder.AppendLine(SerialNumber);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("[Not Before]");
		stringBuilder.Append("  ");
		stringBuilder.AppendLine(X509Certificate.FormatDate(NotBefore));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("[Not After]");
		stringBuilder.Append("  ");
		stringBuilder.AppendLine(X509Certificate.FormatDate(NotAfter));
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("[Thumbprint]");
		stringBuilder.Append("  ");
		stringBuilder.AppendLine(Thumbprint);
		stringBuilder.AppendLine();
		stringBuilder.AppendLine("[Signature Algorithm]");
		stringBuilder.Append("  ");
		stringBuilder.Append(SignatureAlgorithm.FriendlyName);
		stringBuilder.Append('(');
		stringBuilder.Append(SignatureAlgorithm.Value);
		stringBuilder.AppendLine(")");
		stringBuilder.AppendLine();
		stringBuilder.Append("[Public Key]");
		try
		{
			PublicKey publicKey = PublicKey;
			stringBuilder.AppendLine();
			stringBuilder.Append("  ");
			stringBuilder.Append("Algorithm: ");
			stringBuilder.Append(publicKey.Oid.FriendlyName);
			try
			{
				stringBuilder.AppendLine();
				stringBuilder.Append("  ");
				stringBuilder.Append("Length: ");
				using RSA rSA = this.GetRSAPublicKey();
				if (rSA != null)
				{
					stringBuilder.Append(rSA.KeySize);
				}
			}
			catch (NotSupportedException)
			{
			}
			stringBuilder.AppendLine();
			stringBuilder.Append("  ");
			stringBuilder.Append("Key Blob: ");
			stringBuilder.AppendLine(publicKey.EncodedKeyValue.Format(multiLine: true));
			stringBuilder.Append("  ");
			stringBuilder.Append("Parameters: ");
			AsnEncodedData encodedParameters = publicKey.EncodedParameters;
			if (encodedParameters != null)
			{
				stringBuilder.Append(encodedParameters.Format(multiLine: true));
			}
		}
		catch (CryptographicException)
		{
		}
		Pal.AppendPrivateKeyInfo(stringBuilder);
		X509ExtensionCollection extensions = Extensions;
		if (extensions.Count > 0)
		{
			stringBuilder.AppendLine();
			stringBuilder.AppendLine();
			stringBuilder.Append("[Extensions]");
			foreach (X509Extension item in extensions)
			{
				try
				{
					stringBuilder.AppendLine();
					stringBuilder.Append("* ");
					stringBuilder.Append(item.Oid.FriendlyName);
					stringBuilder.Append('(');
					stringBuilder.Append(item.Oid.Value);
					stringBuilder.Append("):");
					stringBuilder.AppendLine();
					stringBuilder.Append("  ");
					stringBuilder.Append(item.Format(multiLine: true));
				}
				catch (CryptographicException)
				{
				}
			}
		}
		stringBuilder.AppendLine();
		return stringBuilder.ToString();
	}

	private static X509Extension CreateCustomExtensionIfAny(Oid oid)
	{
		return CreateCustomExtensionIfAny(oid.Value);
	}

	internal static X509Extension CreateCustomExtensionIfAny(string oidValue)
	{
		switch (oidValue)
		{
		case "2.5.29.10":
			_ = 0;
			return null;
		case "2.5.29.19":
			return new X509BasicConstraintsExtension();
		case "2.5.29.15":
			return new X509KeyUsageExtension();
		case "2.5.29.37":
			return new X509EnhancedKeyUsageExtension();
		case "2.5.29.14":
			return new X509SubjectKeyIdentifierExtension();
		case "2.5.29.35":
			return new X509AuthorityKeyIdentifierExtension();
		case "1.3.6.1.5.5.7.1.1":
			return new X509AuthorityInformationAccessExtension();
		case "2.5.29.17":
			return new X509SubjectAlternativeNameExtension();
		default:
			return null;
		}
	}
}
