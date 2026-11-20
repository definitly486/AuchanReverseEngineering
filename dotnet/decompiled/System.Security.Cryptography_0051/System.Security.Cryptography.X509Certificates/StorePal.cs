using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using Internal.Cryptography;
using Microsoft.Win32.SafeHandles;

namespace System.Security.Cryptography.X509Certificates;

internal sealed class StorePal
{
	internal sealed class CollectionBasedLoader : ILoaderPal, IDisposable
	{
		private X509Certificate2Collection _coll;

		internal CollectionBasedLoader(X509Certificate2Collection coll)
		{
			_coll = coll;
		}

		public void Dispose()
		{
			X509Certificate2Collection coll = _coll;
			_coll = null;
			if (coll == null)
			{
				return;
			}
			foreach (X509Certificate2 item in coll)
			{
				item.Dispose();
			}
		}

		public void MoveTo(X509Certificate2Collection collection)
		{
			collection.AddRange(_coll);
			_coll = null;
		}
	}

	private sealed class AndroidKeyStore : IStorePal, IDisposable
	{
		private struct EnumCertificatesContext
		{
			public HashSet<X509Certificate2> Results;
		}

		private readonly bool _readOnly;

		private readonly SafeX509StoreHandle _keyStoreHandle;

		public static AndroidKeyStore OpenDefault(OpenFlags openFlags)
		{
			SafeX509StoreHandle safeX509StoreHandle = global::Interop.AndroidCrypto.X509StoreOpenDefault();
			if (safeX509StoreHandle.IsInvalid)
			{
				safeX509StoreHandle.Dispose();
				throw new CryptographicException();
			}
			return new AndroidKeyStore(safeX509StoreHandle, openFlags);
		}

		private AndroidKeyStore(SafeX509StoreHandle keyStoreHandle, OpenFlags openFlags)
		{
			_keyStoreHandle = keyStoreHandle;
			_readOnly = (openFlags & (OpenFlags.ReadWrite | OpenFlags.MaxAllowed)) == 0;
		}

		public void Dispose()
		{
			_keyStoreHandle.Dispose();
		}

		public unsafe void CloneTo(X509Certificate2Collection collection)
		{
			EnumCertificatesContext enumCertificatesContext = new EnumCertificatesContext
			{
				Results = new HashSet<X509Certificate2>()
			};
			if (!global::Interop.AndroidCrypto.X509StoreEnumerateCertificates(_keyStoreHandle, (delegate* unmanaged<void*, void*, global::Interop.AndroidCrypto.PAL_KeyAlgorithm, void*, void>)(delegate*<void*, void*, global::Interop.AndroidCrypto.PAL_KeyAlgorithm, void*, void>)(&EnumCertificatesCallback), &enumCertificatesContext))
			{
				throw new CryptographicException("Cryptography_X509_StoreEnumerateFailure");
			}
			foreach (X509Certificate2 result in enumCertificatesContext.Results)
			{
				collection.Add(result);
			}
		}

		[UnmanagedCallersOnly]
		private unsafe static void EnumCertificatesCallback(void* certPtr, void* privateKeyPtr, global::Interop.AndroidCrypto.PAL_KeyAlgorithm privateKeyAlgorithm, void* context)
		{
			SafeX509Handle handle = new SafeX509Handle((nint)certPtr);
			AndroidCertificatePal pal = ((privateKeyPtr == null) ? new AndroidCertificatePal(handle) : new AndroidCertificatePal(handle, privateKeyAlgorithm switch
			{
				global::Interop.AndroidCrypto.PAL_KeyAlgorithm.DSA => new SafeDsaHandle((nint)privateKeyPtr), 
				global::Interop.AndroidCrypto.PAL_KeyAlgorithm.EC => new SafeEcKeyHandle((nint)privateKeyPtr), 
				global::Interop.AndroidCrypto.PAL_KeyAlgorithm.RSA => new SafeRsaHandle((nint)privateKeyPtr), 
				_ => throw new NotSupportedException("NotSupported_KeyAlgorithm"), 
			}));
			X509Certificate2 x509Certificate = new X509Certificate2(pal);
			if (!((EnumCertificatesContext*)context)->Results.Add(x509Certificate))
			{
				x509Certificate.Dispose();
			}
		}
	}

	private sealed class AndroidExportProvider : UnixExportProvider
	{
		public AndroidExportProvider(ICertificatePalCore cert)
			: base(cert)
		{
		}

		public AndroidExportProvider(X509Certificate2Collection certs)
			: base(certs)
		{
		}

		protected override byte[] ExportPkcs7()
		{
			nint[] array;
			if (_singleCertPal != null)
			{
				array = new nint[1] { _singleCertPal.Handle };
			}
			else
			{
				array = new nint[_certs.Count];
				for (int i = 0; i < _certs.Count; i++)
				{
					array[i] = _certs[i].Pal.Handle;
				}
			}
			return global::Interop.AndroidCrypto.X509ExportPkcs7(array);
		}

		protected override byte[] ExportPkcs8(ICertificatePalCore certificatePal, PbeParameters pbeParameters, ReadOnlySpan<char> password)
		{
			SafeKeyHandle privateKeyHandle = ((AndroidCertificatePal)certificatePal).PrivateKeyHandle;
			AsymmetricAlgorithm asymmetricAlgorithm;
			if (!(privateKeyHandle is SafeEcKeyHandle ecKeyHandle))
			{
				if (!(privateKeyHandle is SafeRsaHandle key))
				{
					if (!(privateKeyHandle is SafeDsaHandle key2))
					{
						throw new NotSupportedException("NotSupported_KeyAlgorithm");
					}
					asymmetricAlgorithm = new DSAImplementation.DSAAndroid(key2);
				}
				else
				{
					asymmetricAlgorithm = new RSAImplementation.RSAAndroid(key);
				}
			}
			else
			{
				asymmetricAlgorithm = new ECDsaImplementation.ECDsaAndroid(ecKeyHandle);
			}
			using (asymmetricAlgorithm)
			{
				return asymmetricAlgorithm.ExportEncryptedPkcs8PrivateKey(password, pbeParameters);
			}
		}
	}

	private sealed class AndroidCertLoader : ILoaderPal, IDisposable
	{
		private ICertificatePal[] _certs;

		public AndroidCertLoader(SafeX509Handle[] certHandles)
		{
			_certs = new ICertificatePal[certHandles.Length];
			for (int i = 0; i < certHandles.Length; i++)
			{
				SafeX509Handle safeX509Handle = certHandles[i];
				_certs[i] = AndroidCertificatePal.FromHandle(safeX509Handle.DangerousGetHandle());
			}
		}

		public void Dispose()
		{
			_certs?.DisposeAll();
		}

		public void MoveTo(X509Certificate2Collection collection)
		{
			ICertificatePal[] array = Interlocked.Exchange(ref _certs, null);
			foreach (ICertificatePal pal in array)
			{
				collection.Add(new X509Certificate2(pal));
			}
		}
	}

	private sealed class TrustedStore : IStorePal, IDisposable
	{
		private struct EnumCertificatesContext
		{
			public HashSet<X509Certificate2> Results;
		}

		private readonly StoreLocation _location;

		internal TrustedStore(StoreLocation location)
		{
			_location = location;
		}

		public void Dispose()
		{
		}

		public unsafe void CloneTo(X509Certificate2Collection collection)
		{
			EnumCertificatesContext enumCertificatesContext = new EnumCertificatesContext
			{
				Results = new HashSet<X509Certificate2>()
			};
			if (!global::Interop.AndroidCrypto.X509StoreEnumerateTrustedCertificates((_location == StoreLocation.LocalMachine) ? ((byte)1) : ((byte)0), (delegate* unmanaged<void*, void*, void>)(delegate*<void*, void*, void>)(&EnumCertificatesCallback), &enumCertificatesContext))
			{
				throw new CryptographicException("Cryptography_X509_StoreEnumerateFailure");
			}
			foreach (X509Certificate2 result in enumCertificatesContext.Results)
			{
				collection.Add(result);
			}
		}

		[UnmanagedCallersOnly]
		private unsafe static void EnumCertificatesCallback(void* certPtr, void* context)
		{
			X509Certificate2 x509Certificate = new X509Certificate2(new AndroidCertificatePal(new SafeX509Handle((nint)certPtr)));
			if (!((EnumCertificatesContext*)context)->Results.Add(x509Certificate))
			{
				x509Certificate.Dispose();
			}
		}
	}

	internal static ILoaderPal FromBlob(ReadOnlySpan<byte> rawData, SafePasswordHandle password, X509KeyStorageFlags keyStorageFlags)
	{
		return FromBlob(rawData, password, readingFromFile: false, keyStorageFlags);
	}

	internal static IExportPal FromCertificate(ICertificatePalCore cert)
	{
		return new AndroidExportProvider(cert);
	}

	internal static IExportPal LinkFromCertificateCollection(X509Certificate2Collection certificates)
	{
		return new AndroidExportProvider(certificates);
	}

	internal static IStorePal FromSystemStore(string storeName, StoreLocation storeLocation, OpenFlags openFlags)
	{
		bool flag = (openFlags & OpenFlags.ReadWrite) == OpenFlags.ReadWrite;
		if (flag && storeLocation == StoreLocation.LocalMachine)
		{
			throw new CryptographicException("Cryptography_Unix_X509_MachineStoresReadOnly", new PlatformNotSupportedException("Cryptography_Unix_X509_MachineStoresReadOnly"));
		}
		StringComparer ordinalIgnoreCase = StringComparer.OrdinalIgnoreCase;
		switch (storeLocation)
		{
		case StoreLocation.CurrentUser:
			if (ordinalIgnoreCase.Equals("Disallowed", storeName))
			{
				return new UnsupportedDisallowedStore(openFlags);
			}
			if (ordinalIgnoreCase.Equals("My", storeName))
			{
				return AndroidKeyStore.OpenDefault(openFlags);
			}
			if (ordinalIgnoreCase.Equals("Root", storeName))
			{
				if (flag)
				{
					throw new CryptographicException("Security_AccessDenied");
				}
				return new TrustedStore(storeLocation);
			}
			break;
		case StoreLocation.LocalMachine:
			if (ordinalIgnoreCase.Equals("Root", storeName))
			{
				return new TrustedStore(storeLocation);
			}
			break;
		}
		if ((openFlags & OpenFlags.OpenExistingOnly) == OpenFlags.OpenExistingOnly)
		{
			throw new CryptographicException("Cryptography_X509_StoreNotFound");
		}
		string message = System.SR.Format("Cryptography_X509_StoreCannotCreate", storeName, storeLocation);
		throw new CryptographicException(message, new PlatformNotSupportedException(message));
	}

	private static ILoaderPal FromBlob(ReadOnlySpan<byte> rawData, SafePasswordHandle password, bool readingFromFile, X509KeyStorageFlags keyStorageFlags)
	{
		if (X509Certificate2.GetCertContentType(rawData) == X509ContentType.Pfx)
		{
			try
			{
				return new CollectionBasedLoader(X509CertificateLoader.LoadPkcs12Collection(rawData, password.DangerousGetSpan(), keyStorageFlags, X509Certificate.GetPkcs12Limits(readingFromFile, password)));
			}
			catch (Pkcs12LoadLimitExceededException inner)
			{
				throw new CryptographicException("Cryptography_X509_PfxWithoutPassword_MaxAllowedIterationsExceeded", inner);
			}
		}
		return new AndroidCertLoader(global::Interop.AndroidCrypto.X509DecodeCollection(rawData));
	}
}
