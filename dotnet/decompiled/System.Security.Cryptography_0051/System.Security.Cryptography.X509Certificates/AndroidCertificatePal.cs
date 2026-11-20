using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Formats.Asn1;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates.Asn1;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Cryptography.X509Certificates;

internal sealed class AndroidCertificatePal : ICertificatePal, ICertificatePalCore, IDisposable
{
	private SafeX509Handle _cert;

	private SafeKeyHandle _privateKey;

	private global::Interop.JObjectLifetime.SafeJObjectHandle _keyStorePrivateKeyEntry;

	private CertificateData _certData;

	public bool HasPrivateKey
	{
		get
		{
			if (_privateKey == null)
			{
				return _keyStorePrivateKeyEntry != null;
			}
			return true;
		}
	}

	public nint Handle => _keyStorePrivateKeyEntry?.DangerousGetHandle() ?? _cert?.DangerousGetHandle() ?? IntPtr.Zero;

	internal SafeX509Handle SafeHandle => _cert;

	public string Issuer
	{
		get
		{
			EnsureCertificateData();
			return _certData.IssuerName;
		}
	}

	public string Subject
	{
		get
		{
			EnsureCertificateData();
			return _certData.SubjectName;
		}
	}

	public byte[] Thumbprint
	{
		get
		{
			EnsureCertificateData();
			return SHA1.HashData(_certData.RawData);
		}
	}

	public string KeyAlgorithm
	{
		get
		{
			EnsureCertificateData();
			return _certData.PublicKeyAlgorithm.AlgorithmId;
		}
	}

	public byte[] KeyAlgorithmParameters
	{
		get
		{
			EnsureCertificateData();
			return _certData.PublicKeyAlgorithm.Parameters;
		}
	}

	public byte[] PublicKeyValue
	{
		get
		{
			EnsureCertificateData();
			return _certData.PublicKey;
		}
	}

	public byte[] SerialNumber
	{
		get
		{
			EnsureCertificateData();
			return _certData.SerialNumber;
		}
	}

	public string SignatureAlgorithm
	{
		get
		{
			EnsureCertificateData();
			return _certData.SignatureAlgorithm.AlgorithmId;
		}
	}

	public DateTime NotAfter
	{
		get
		{
			EnsureCertificateData();
			return _certData.NotAfter.ToLocalTime();
		}
	}

	public DateTime NotBefore
	{
		get
		{
			EnsureCertificateData();
			return _certData.NotBefore.ToLocalTime();
		}
	}

	public byte[] RawData => global::Interop.AndroidCrypto.X509Encode(_cert);

	public int Version
	{
		get
		{
			EnsureCertificateData();
			return _certData.Version + 1;
		}
	}

	public X500DistinguishedName SubjectName
	{
		get
		{
			EnsureCertificateData();
			return _certData.Subject;
		}
	}

	public X500DistinguishedName IssuerName
	{
		get
		{
			EnsureCertificateData();
			return _certData.Issuer;
		}
	}

	public IEnumerable<X509Extension> Extensions
	{
		get
		{
			EnsureCertificateData();
			return _certData.Extensions;
		}
	}

	internal SafeKeyHandle PrivateKeyHandle => _privateKey;

	public static ICertificatePal FromHandle(nint handle)
	{
		if (handle == IntPtr.Zero)
		{
			throw new ArgumentException("Arg_InvalidHandle", "handle");
		}
		if (global::Interop.AndroidCrypto.IsKeyStorePrivateKeyEntry(handle))
		{
			return new AndroidCertificatePal(global::Interop.JObjectLifetime.SafeJObjectHandle.CreateGlobalReferenceFromHandle(handle));
		}
		SafeX509Handle safeX509Handle = new SafeX509Handle();
		Marshal.InitHandle(safeX509Handle, global::Interop.JObjectLifetime.NewGlobalReference(handle));
		return new AndroidCertificatePal(safeX509Handle);
	}

	public static ICertificatePal FromOtherCert(X509Certificate cert)
	{
		AndroidCertificatePal androidCertificatePal = (AndroidCertificatePal)cert.Pal;
		global::Interop.JObjectLifetime.SafeJObjectHandle keyStorePrivateKeyEntry = androidCertificatePal._keyStorePrivateKeyEntry;
		if (keyStorePrivateKeyEntry != null)
		{
			bool success = false;
			try
			{
				keyStorePrivateKeyEntry.DangerousAddRef(ref success);
				return new AndroidCertificatePal(global::Interop.JObjectLifetime.SafeJObjectHandle.CreateGlobalReferenceFromHandle(keyStorePrivateKeyEntry.DangerousGetHandle()));
			}
			finally
			{
				if (success)
				{
					keyStorePrivateKeyEntry.DangerousRelease();
				}
			}
		}
		if (androidCertificatePal.PrivateKeyHandle != null)
		{
			return androidCertificatePal.CopyWithPrivateKeyHandle(androidCertificatePal.PrivateKeyHandle.DuplicateHandle());
		}
		SafeX509Handle safeX509Handle = new SafeX509Handle();
		Marshal.InitHandle(safeX509Handle, global::Interop.JObjectLifetime.NewGlobalReference(androidCertificatePal.Handle));
		return new AndroidCertificatePal(safeX509Handle);
	}

	internal unsafe static bool TryReadX509(ReadOnlySpan<byte> rawData, [NotNullWhen(true)] out ICertificatePal handle)
	{
		if (rawData.IsEmpty)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
		}
		if (rawData[0] == 48)
		{
			fixed (byte* pointer = rawData)
			{
				using PointerMemoryManager<byte> pointerMemoryManager = new PointerMemoryManager<byte>(pointer, rawData.Length);
				AsnValueReader reader = new AsnValueReader(rawData, AsnEncodingRules.DER);
				CertificateAsn.Decode(ref reader, pointerMemoryManager.Memory, out var _);
			}
		}
		handle = null;
		SafeX509Handle safeX509Handle = global::Interop.AndroidCrypto.X509Decode(ref MemoryMarshal.GetReference(rawData), rawData.Length);
		if (safeX509Handle.IsInvalid)
		{
			safeX509Handle.Dispose();
			return false;
		}
		handle = new AndroidCertificatePal(safeX509Handle);
		return true;
	}

	internal AndroidCertificatePal(global::Interop.JObjectLifetime.SafeJObjectHandle handle)
	{
		_cert = global::Interop.AndroidCrypto.GetPrivateKeyEntryCertificate(handle);
		_keyStorePrivateKeyEntry = handle;
	}

	internal AndroidCertificatePal(SafeX509Handle handle)
	{
		_cert = handle;
	}

	internal AndroidCertificatePal(SafeX509Handle handle, SafeKeyHandle privateKey)
	{
		_cert = handle;
		_privateKey = privateKey;
	}

	public PolicyData GetPolicyData()
	{
		EnsureCertificateData();
		PolicyData result = default(PolicyData);
		foreach (X509Extension extension in _certData.Extensions)
		{
			switch (extension.Oid.Value)
			{
			case "1.3.6.1.4.1.311.21.10":
				result.ApplicationCertPolicies = extension.RawData;
				break;
			case "2.5.29.32":
				result.CertPolicies = extension.RawData;
				break;
			case "2.5.29.33":
				result.CertPolicyMappings = extension.RawData;
				break;
			case "2.5.29.36":
				result.CertPolicyConstraints = extension.RawData;
				break;
			case "2.5.29.37":
				result.EnhancedKeyUsage = extension.RawData;
				break;
			case "2.5.29.54":
				result.InhibitAnyPolicyExtension = extension.RawData;
				break;
			}
		}
		return result;
	}

	internal void SetPrivateKey(SafeKeyHandle privateKey)
	{
		_privateKey = privateKey;
	}

	public RSA GetRSAPrivateKey()
	{
		if (_privateKey == null || _privateKey.IsInvalid)
		{
			return null;
		}
		return new RSAImplementation.RSAAndroid((_privateKey as SafeRsaHandle) ?? throw new CryptographicException());
	}

	public DSA GetDSAPrivateKey()
	{
		if (_privateKey == null || _privateKey.IsInvalid)
		{
			return null;
		}
		return new DSAImplementation.DSAAndroid((_privateKey as SafeDsaHandle) ?? throw new CryptographicException());
	}

	public ECDsa GetECDsaPrivateKey()
	{
		if (_privateKey == null || _privateKey.IsInvalid)
		{
			return null;
		}
		return new ECDsaImplementation.ECDsaAndroid((_privateKey as SafeEcKeyHandle) ?? throw new CryptographicException());
	}

	public ECDiffieHellman GetECDiffieHellmanPrivateKey()
	{
		if (_privateKey == null || _privateKey.IsInvalid)
		{
			return null;
		}
		return new ECDiffieHellmanImplementation.ECDiffieHellmanAndroid((_privateKey as SafeEcKeyHandle) ?? throw new CryptographicException());
	}

	public string GetNameInfo(X509NameType nameType, bool forIssuer)
	{
		EnsureCertificateData();
		return _certData.GetNameInfo(nameType, forIssuer);
	}

	public void AppendPrivateKeyInfo(StringBuilder sb)
	{
		if (HasPrivateKey)
		{
			sb.AppendLine();
			sb.AppendLine();
			sb.AppendLine("[Private Key]");
		}
	}

	public void Dispose()
	{
		if (_privateKey != null)
		{
			_privateKey.Dispose();
			_privateKey = null;
		}
		if (_cert != null)
		{
			_cert.Dispose();
			_cert = null;
		}
	}

	public byte[] Export(X509ContentType contentType, SafePasswordHandle password)
	{
		using IExportPal exportPal = StorePal.FromCertificate(this);
		return exportPal.Export(contentType, password);
	}

	private void EnsureCertificateData()
	{
		if (_certData.Equals(default(CertificateData)))
		{
			_certData = new CertificateData(RawData);
		}
	}

	private AndroidCertificatePal CopyWithPrivateKeyHandle(SafeKeyHandle privateKey)
	{
		SafeX509Handle safeX509Handle = new SafeX509Handle();
		Marshal.InitHandle(safeX509Handle, global::Interop.JObjectLifetime.NewGlobalReference(Handle));
		return new AndroidCertificatePal(safeX509Handle, privateKey);
	}
}
