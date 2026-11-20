namespace System.Security.Cryptography;

internal sealed class ECAndroid : IDisposable
{
	private Lazy<SafeEcKeyHandle> _key;

	internal SafeEcKeyHandle Value => _key.Value;

	internal int KeySize => global::Interop.AndroidCrypto.EcKeyGetSize(_key.Value);

	public ECAndroid(AsymmetricAlgorithm owner)
	{
		_key = new Lazy<SafeEcKeyHandle>(() => GenerateKeyLazy(owner));
	}

	public ECAndroid(SafeEcKeyHandle key)
	{
		_key = new Lazy<SafeEcKeyHandle>(key);
	}

	private static SafeEcKeyHandle GenerateKeyLazy(AsymmetricAlgorithm owner)
	{
		return GenerateKeyByKeySize(owner.KeySize);
	}

	public void Dispose()
	{
		FreeKey();
	}

	internal SafeEcKeyHandle UpRefKeyHandle()
	{
		return _key.Value.DuplicateHandle();
	}

	private void FreeKey()
	{
		if (_key != null)
		{
			if (_key.IsValueCreated)
			{
				_key.Value?.Dispose();
			}
			_key = null;
		}
	}

	public int ImportParameters(ECParameters parameters)
	{
		parameters.Validate();
		SafeEcKeyHandle safeEcKeyHandle;
		if (parameters.Curve.IsPrime)
		{
			safeEcKeyHandle = ImportPrimeCurveParameters(parameters);
		}
		else if (parameters.Curve.IsCharacteristic2)
		{
			safeEcKeyHandle = ImportCharacteristic2CurveParameters(parameters);
		}
		else
		{
			if (!parameters.Curve.IsNamed)
			{
				throw new PlatformNotSupportedException(System.SR.Format("Cryptography_CurveNotSupported", parameters.Curve.CurveType.ToString()));
			}
			safeEcKeyHandle = ImportNamedCurveParameters(parameters);
		}
		if (safeEcKeyHandle == null || safeEcKeyHandle.IsInvalid)
		{
			safeEcKeyHandle?.Dispose();
			throw new CryptographicException();
		}
		FreeKey();
		_key = new Lazy<SafeEcKeyHandle>(safeEcKeyHandle);
		return KeySize;
	}

	public static ECParameters ExportParameters(SafeEcKeyHandle currentKey, bool includePrivateParameters)
	{
		string text = global::Interop.AndroidCrypto.EcKeyGetCurveName(currentKey);
		if (text != null)
		{
			return ExportNamedCurveParameters(currentKey, text, includePrivateParameters);
		}
		return ExportExplicitCurveParameters(currentKey, includePrivateParameters);
	}

	private static ECParameters ExportNamedCurveParameters(SafeEcKeyHandle key, string curveName, bool includePrivateParameters)
	{
		CheckInvalidKey(key);
		ECParameters eCKeyParameters = global::Interop.AndroidCrypto.GetECKeyParameters(key, includePrivateParameters);
		if (eCKeyParameters.D != null != includePrivateParameters)
		{
			throw new CryptographicException("Cryptography_CSP_NoPrivateKey");
		}
		eCKeyParameters.Curve = ECCurve.CreateFromFriendlyName(curveName);
		return eCKeyParameters;
	}

	private static ECParameters ExportExplicitCurveParameters(SafeEcKeyHandle key, bool includePrivateParameters)
	{
		CheckInvalidKey(key);
		ECParameters eCCurveParameters = global::Interop.AndroidCrypto.GetECCurveParameters(key, includePrivateParameters);
		if (eCCurveParameters.D != null != includePrivateParameters)
		{
			throw new CryptographicException("Cryptography_CSP_NoPrivateKey");
		}
		return eCCurveParameters;
	}

	private static SafeEcKeyHandle ImportNamedCurveParameters(ECParameters parameters)
	{
		string? oid = ((!string.IsNullOrEmpty(parameters.Curve.Oid.Value)) ? parameters.Curve.Oid.Value : parameters.Curve.Oid.FriendlyName);
		byte[]? x = parameters.Q.X;
		byte[]? x2 = parameters.Q.X;
		int qxLength = ((x2 != null) ? x2.Length : 0);
		byte[]? y = parameters.Q.Y;
		byte[]? y2 = parameters.Q.Y;
		return global::Interop.AndroidCrypto.EcKeyCreateByKeyParameters(oid, x, qxLength, y, (y2 != null) ? y2.Length : 0, parameters.D, (parameters.D != null) ? parameters.D.Length : 0);
	}

	private static SafeEcKeyHandle ImportPrimeCurveParameters(ECParameters parameters)
	{
		ECCurve.ECCurveType curveType = parameters.Curve.CurveType;
		byte[]? x = parameters.Q.X;
		byte[]? x2 = parameters.Q.X;
		int qxLength = ((x2 != null) ? x2.Length : 0);
		byte[]? y = parameters.Q.Y;
		byte[]? y2 = parameters.Q.Y;
		return global::Interop.AndroidCrypto.EcKeyCreateByExplicitParameters(curveType, x, qxLength, y, (y2 != null) ? y2.Length : 0, parameters.D, (parameters.D != null) ? parameters.D.Length : 0, parameters.Curve.Prime, parameters.Curve.Prime.Length, parameters.Curve.A, parameters.Curve.A.Length, parameters.Curve.B, parameters.Curve.B.Length, parameters.Curve.G.X, parameters.Curve.G.X.Length, parameters.Curve.G.Y, parameters.Curve.G.Y.Length, parameters.Curve.Order, parameters.Curve.Order.Length, parameters.Curve.Cofactor, parameters.Curve.Cofactor.Length, parameters.Curve.Seed, (parameters.Curve.Seed != null) ? parameters.Curve.Seed.Length : 0);
	}

	private static SafeEcKeyHandle ImportCharacteristic2CurveParameters(ECParameters parameters)
	{
		ECCurve.ECCurveType curveType = parameters.Curve.CurveType;
		byte[]? x = parameters.Q.X;
		byte[]? x2 = parameters.Q.X;
		int qxLength = ((x2 != null) ? x2.Length : 0);
		byte[]? y = parameters.Q.Y;
		byte[]? y2 = parameters.Q.Y;
		return global::Interop.AndroidCrypto.EcKeyCreateByExplicitParameters(curveType, x, qxLength, y, (y2 != null) ? y2.Length : 0, parameters.D, (parameters.D != null) ? parameters.D.Length : 0, parameters.Curve.Polynomial, parameters.Curve.Polynomial.Length, parameters.Curve.A, parameters.Curve.A.Length, parameters.Curve.B, parameters.Curve.B.Length, parameters.Curve.G.X, parameters.Curve.G.X.Length, parameters.Curve.G.Y, parameters.Curve.G.Y.Length, parameters.Curve.Order, parameters.Curve.Order.Length, parameters.Curve.Cofactor, parameters.Curve.Cofactor.Length, parameters.Curve.Seed, (parameters.Curve.Seed != null) ? parameters.Curve.Seed.Length : 0);
	}

	private static void CheckInvalidKey(SafeEcKeyHandle key)
	{
		if (key == null || key.IsInvalid)
		{
			throw new CryptographicException("Cryptography_OpenInvalidHandle");
		}
	}

	public static SafeEcKeyHandle GenerateKeyByKeySize(int keySize)
	{
		string text = keySize switch
		{
			256 => "1.2.840.10045.3.1.7", 
			384 => "1.3.132.0.34", 
			521 => "1.3.132.0.35", 
			_ => throw new InvalidOperationException("Cryptography_InvalidKeySize"), 
		};
		SafeEcKeyHandle safeEcKeyHandle = global::Interop.AndroidCrypto.EcKeyCreateByOid(text);
		if (safeEcKeyHandle == null || safeEcKeyHandle.IsInvalid)
		{
			safeEcKeyHandle?.Dispose();
			throw new PlatformNotSupportedException(System.SR.Format("Cryptography_CurveNotSupported", text));
		}
		return safeEcKeyHandle;
	}
}
