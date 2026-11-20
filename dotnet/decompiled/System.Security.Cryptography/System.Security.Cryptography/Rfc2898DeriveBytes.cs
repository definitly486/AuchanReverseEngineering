using System.Buffers.Binary;
using System.Diagnostics.CodeAnalysis;

namespace System.Security.Cryptography;

public class Rfc2898DeriveBytes : DeriveBytes
{
	private byte[] _salt;

	private uint _iterations;

	private IncrementalHash _hmac;

	private readonly int _blockSize;

	private byte[] _buffer;

	private uint _block;

	private int _startIndex;

	private int _endIndex;

	public HashAlgorithmName HashAlgorithm { get; }

	[Obsolete("The constructors on Rfc2898DeriveBytes are obsolete. Use the static Pbkdf2 method instead.", DiagnosticId = "SYSLIB0060", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public Rfc2898DeriveBytes(byte[] password, byte[] salt, int iterations, HashAlgorithmName hashAlgorithm)
		: this(password, salt, iterations, hashAlgorithm, clearPassword: false)
	{
	}

	internal Rfc2898DeriveBytes(byte[] password, byte[] salt, int iterations, HashAlgorithmName hashAlgorithm, bool clearPassword)
		: this(new ReadOnlySpan<byte>(password ?? throw new ArgumentNullException("password")), new ReadOnlySpan<byte>(salt ?? throw new ArgumentNullException("salt")), iterations, hashAlgorithm)
	{
		if (clearPassword)
		{
			CryptographicOperations.ZeroMemory(password);
		}
	}

	internal Rfc2898DeriveBytes(ReadOnlySpan<byte> password, ReadOnlySpan<byte> salt, int iterations, HashAlgorithmName hashAlgorithm)
	{
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(iterations, "iterations");
		_salt = new byte[salt.Length + 4];
		salt.CopyTo(_salt);
		_iterations = (uint)iterations;
		HashAlgorithm = hashAlgorithm;
		_hmac = OpenHmac(password);
		_blockSize = _hmac.HashLengthInBytes;
		Initialize();
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			if (_hmac != null)
			{
				_hmac.Dispose();
				_hmac = null;
			}
			if (_buffer != null)
			{
				Array.Clear(_buffer);
			}
			if (_salt != null)
			{
				Array.Clear(_salt);
			}
		}
		base.Dispose(disposing);
	}

	public override byte[] GetBytes(int cb)
	{
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(cb, "cb");
		byte[] array = new byte[cb];
		GetBytes(array);
		return array;
	}

	internal void GetBytes(Span<byte> destination)
	{
		int length = destination.Length;
		int i = 0;
		int num = _endIndex - _startIndex;
		ReadOnlySpan<byte> readOnlySpan = _buffer;
		if (num > 0)
		{
			if (length < num)
			{
				readOnlySpan.Slice(_startIndex, length).CopyTo(destination);
				_startIndex += length;
				return;
			}
			readOnlySpan.Slice(_startIndex, num).CopyTo(destination);
			_startIndex = (_endIndex = 0);
			i += num;
		}
		for (; i < length; i += _blockSize)
		{
			Func();
			int num2 = length - i;
			if (num2 >= _blockSize)
			{
				readOnlySpan.Slice(0, _blockSize).CopyTo(destination.Slice(i));
				continue;
			}
			readOnlySpan.Slice(0, num2).CopyTo(destination.Slice(i));
			_startIndex = num2;
			_endIndex = _buffer.Length;
			break;
		}
	}

	private IncrementalHash OpenHmac(ReadOnlySpan<byte> password)
	{
		HashAlgorithmName hashAlgorithm = HashAlgorithm;
		if (string.IsNullOrEmpty(hashAlgorithm.Name))
		{
			throw new CryptographicException("Cryptography_HashAlgorithmNameNullOrEmpty");
		}
		if (hashAlgorithm != HashAlgorithmName.SHA1 && hashAlgorithm != HashAlgorithmName.SHA256 && hashAlgorithm != HashAlgorithmName.SHA384 && hashAlgorithm != HashAlgorithmName.SHA512 && hashAlgorithm != HashAlgorithmName.SHA3_256 && hashAlgorithm != HashAlgorithmName.SHA3_384 && hashAlgorithm != HashAlgorithmName.SHA3_512)
		{
			throw new CryptographicException(System.SR.Format("Cryptography_UnknownHashAlgorithm", hashAlgorithm.Name));
		}
		return IncrementalHash.CreateHMAC(hashAlgorithm, password);
	}

	[MemberNotNull("_buffer")]
	private void Initialize()
	{
		if (_buffer != null)
		{
			Array.Clear(_buffer);
		}
		_buffer = new byte[_blockSize];
		_block = 0u;
		_startIndex = (_endIndex = 0);
	}

	private void Func()
	{
		if (_block == uint.MaxValue)
		{
			throw new CryptographicException("Cryptography_ExceedKdfExtractLimit");
		}
		BinaryPrimitives.WriteUInt32BigEndian(_salt.AsSpan(_salt.Length - 4), _block + 1);
		Span<byte> span = stackalloc byte[64];
		span = span.Slice(0, _blockSize);
		_hmac.AppendData(_salt);
		_hmac.GetHashAndReset(span);
		span.CopyTo(_buffer);
		for (int i = 2; i <= _iterations; i++)
		{
			_hmac.AppendData(span);
			_hmac.GetHashAndReset(span);
			for (int num = _buffer.Length - 1; num >= 0; num--)
			{
				_buffer[num] ^= span[num];
			}
		}
		_block++;
	}

	public static byte[] Pbkdf2(ReadOnlySpan<byte> password, ReadOnlySpan<byte> salt, int iterations, HashAlgorithmName hashAlgorithm, int outputLength)
	{
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(iterations, "iterations");
		ArgumentOutOfRangeException.ThrowIfNegative(outputLength, "outputLength");
		ValidateHashAlgorithm(hashAlgorithm);
		byte[] array = new byte[outputLength];
		Pbkdf2Core(password, salt, array, iterations, hashAlgorithm);
		return array;
	}

	private static void Pbkdf2Core(ReadOnlySpan<byte> password, ReadOnlySpan<byte> salt, Span<byte> destination, int iterations, HashAlgorithmName hashAlgorithm)
	{
		if (!destination.IsEmpty)
		{
			Pbkdf2Implementation.Fill(password, salt, iterations, hashAlgorithm, destination);
		}
	}

	private static void ValidateHashAlgorithm(HashAlgorithmName hashAlgorithm)
	{
		string name = hashAlgorithm.Name;
		ArgumentException.ThrowIfNullOrEmpty(name, "hashAlgorithm");
		if (!(name == HashAlgorithmName.SHA1.Name) && !(name == HashAlgorithmName.SHA256.Name) && !(name == HashAlgorithmName.SHA384.Name) && !(name == HashAlgorithmName.SHA512.Name))
		{
			if (!(name == HashAlgorithmName.SHA3_256.Name) && !(name == HashAlgorithmName.SHA3_384.Name) && !(name == HashAlgorithmName.SHA3_512.Name))
			{
				throw new CryptographicException(System.SR.Format("Cryptography_UnknownHashAlgorithm", name));
			}
			if (!HMACSHA3_256.IsSupported)
			{
				throw new PlatformNotSupportedException();
			}
		}
	}
}
