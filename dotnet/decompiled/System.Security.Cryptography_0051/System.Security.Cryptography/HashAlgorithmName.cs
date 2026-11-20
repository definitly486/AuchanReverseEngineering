using System.Diagnostics.CodeAnalysis;

namespace System.Security.Cryptography;

public readonly struct HashAlgorithmName : IEquatable<HashAlgorithmName>
{
	private readonly string _name;

	public static HashAlgorithmName MD5 => new HashAlgorithmName("MD5");

	public static HashAlgorithmName SHA1 => new HashAlgorithmName("SHA1");

	public static HashAlgorithmName SHA256 => new HashAlgorithmName("SHA256");

	public static HashAlgorithmName SHA384 => new HashAlgorithmName("SHA384");

	public static HashAlgorithmName SHA512 => new HashAlgorithmName("SHA512");

	public static HashAlgorithmName SHA3_256 => new HashAlgorithmName("SHA3-256");

	public static HashAlgorithmName SHA3_384 => new HashAlgorithmName("SHA3-384");

	public static HashAlgorithmName SHA3_512 => new HashAlgorithmName("SHA3-512");

	public string? Name => _name;

	public HashAlgorithmName(string? name)
	{
		_name = name;
	}

	public override string ToString()
	{
		return _name ?? string.Empty;
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is HashAlgorithmName)
		{
			return Equals((HashAlgorithmName)obj);
		}
		return false;
	}

	public bool Equals(HashAlgorithmName other)
	{
		return _name == other._name;
	}

	public override int GetHashCode()
	{
		if (_name != null)
		{
			return _name.GetHashCode();
		}
		return 0;
	}

	public static bool operator ==(HashAlgorithmName left, HashAlgorithmName right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(HashAlgorithmName left, HashAlgorithmName right)
	{
		return !(left == right);
	}
}
