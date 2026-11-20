using System.Diagnostics;

namespace System.Security.Cryptography;

[DebuggerDisplay("ECCurve = {Oid}")]
public struct ECCurve
{
	public enum ECCurveType
	{
		Implicit,
		PrimeShortWeierstrass,
		PrimeTwistedEdwards,
		PrimeMontgomery,
		Characteristic2,
		Named
	}

	public byte[]? A;

	public byte[]? B;

	public ECPoint G;

	public byte[]? Order;

	public byte[]? Cofactor;

	public byte[]? Seed;

	public ECCurveType CurveType;

	public HashAlgorithmName? Hash;

	public byte[]? Polynomial;

	public byte[]? Prime;

	private Oid _oid;

	public Oid Oid
	{
		get
		{
			return _oid;
		}
		private set
		{
			ArgumentNullException.ThrowIfNull(value, "Oid");
			if (string.IsNullOrEmpty(value.Value) && string.IsNullOrEmpty(value.FriendlyName))
			{
				throw new ArgumentException(System.SR.Format("Cryptography_InvalidCurveOid", value.Value));
			}
			_oid = value;
		}
	}

	public bool IsPrime
	{
		get
		{
			if (CurveType != ECCurveType.PrimeShortWeierstrass && CurveType != ECCurveType.PrimeMontgomery)
			{
				return CurveType == ECCurveType.PrimeTwistedEdwards;
			}
			return true;
		}
	}

	public bool IsCharacteristic2 => CurveType == ECCurveType.Characteristic2;

	public bool IsExplicit
	{
		get
		{
			if (!IsPrime)
			{
				return IsCharacteristic2;
			}
			return true;
		}
	}

	public bool IsNamed => CurveType == ECCurveType.Named;

	public static ECCurve CreateFromOid(Oid curveOid)
	{
		return new ECCurve
		{
			CurveType = ECCurveType.Named,
			Oid = curveOid
		};
	}

	public static ECCurve CreateFromFriendlyName(string oidFriendlyName)
	{
		ArgumentNullException.ThrowIfNull(oidFriendlyName, "oidFriendlyName");
		return CreateFromValueAndName(null, oidFriendlyName);
	}

	private static ECCurve CreateFromValueAndName(string oidValue, string oidFriendlyName)
	{
		Oid oid = null;
		if (oidValue == null && oidFriendlyName != null)
		{
			try
			{
				oid = System.Security.Cryptography.Oid.FromFriendlyName(oidFriendlyName, OidGroup.PublicKeyAlgorithm);
			}
			catch (CryptographicException)
			{
			}
		}
		if (oid == null)
		{
			oid = new Oid(oidValue, oidFriendlyName);
		}
		return CreateFromOid(oid);
	}

	public void Validate()
	{
		if (IsNamed)
		{
			if (HasAnyExplicitParameters())
			{
				throw new CryptographicException("Cryptography_InvalidECNamedCurve");
			}
			if (Oid == null || (string.IsNullOrEmpty(Oid.FriendlyName) && string.IsNullOrEmpty(Oid.Value)))
			{
				throw new CryptographicException(System.SR.Format("Cryptography_InvalidCurveOid", Oid?.Value));
			}
		}
		else if (IsExplicit)
		{
			bool flag = false;
			if (A == null || B == null || B.Length != A.Length || G.X == null || G.X.Length != A.Length || G.Y == null || G.Y.Length != A.Length || Order == null || Order.Length == 0 || Cofactor == null || Cofactor.Length == 0)
			{
				flag = true;
			}
			if (IsPrime)
			{
				if (!flag && (Prime == null || Prime.Length != A.Length))
				{
					flag = true;
				}
				if (flag)
				{
					throw new CryptographicException("Cryptography_InvalidECPrimeCurve");
				}
			}
			else if (IsCharacteristic2)
			{
				if (!flag && (Polynomial == null || Polynomial.Length == 0))
				{
					flag = true;
				}
				if (flag)
				{
					throw new CryptographicException("Cryptography_InvalidECCharacteristic2Curve");
				}
			}
		}
		else if (HasAnyExplicitParameters() || Oid != null)
		{
			throw new CryptographicException(System.SR.Format("Cryptography_CurveNotSupported", CurveType.ToString()));
		}
	}

	private bool HasAnyExplicitParameters()
	{
		if (A == null && B == null && G.X == null && G.Y == null && Order == null && Cofactor == null && Prime == null && Polynomial == null && Seed == null)
		{
			return Hash.HasValue;
		}
		return true;
	}
}
