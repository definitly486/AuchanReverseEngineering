using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Internal.Cryptography;

namespace System.Security.Cryptography;

internal sealed class HMACCommon
{
	[CompilerGenerated]
	private byte[] _003CActualKey_003Ek__BackingField;

	private readonly string _hashAlgorithmId;

	private HashProvider _hMacProvider;

	private readonly int _blockSize;

	public int HashSizeInBytes => _hMacProvider.HashSizeInBytes;

	private byte[] ActualKey
	{
		[CompilerGenerated]
		set
		{
			_003CActualKey_003Ek__BackingField = value;
		}
	}

	internal HMACCommon(string hashAlgorithmId, ReadOnlySpan<byte> key, int blockSize)
	{
		_hashAlgorithmId = hashAlgorithmId;
		_blockSize = blockSize;
		ActualKey = ChangeKeyImpl(key);
	}

	[MemberNotNull("_hMacProvider")]
	private byte[] ChangeKeyImpl(ReadOnlySpan<byte> key)
	{
		byte[] result = null;
		if (key.Length > _blockSize && _blockSize > 0)
		{
			switch (_hashAlgorithmId)
			{
			case "SHA256":
				result = SHA256.HashData(key);
				break;
			case "SHA384":
				result = SHA384.HashData(key);
				break;
			case "SHA512":
				result = SHA512.HashData(key);
				break;
			case "SHA3-256":
				result = SHA3_256.HashData(key);
				break;
			case "SHA3-384":
				result = SHA3_384.HashData(key);
				break;
			case "SHA3-512":
				result = SHA3_512.HashData(key);
				break;
			case "SHA1":
				result = SHA1.HashData(key);
				break;
			case "MD5":
				if (Helpers.HasMD5)
				{
					result = MD5.HashData(key);
					break;
				}
				goto default;
			default:
				throw new CryptographicException(System.SR.Format("Cryptography_UnknownHashAlgorithm", _hashAlgorithmId));
			}
		}
		HashProvider hMacProvider = _hMacProvider;
		_hMacProvider = null;
		hMacProvider?.Dispose(disposing: true);
		_hMacProvider = HashProviderDispenser.CreateMacProvider(_hashAlgorithmId, key);
		return result;
	}

	public void AppendHashData(ReadOnlySpan<byte> source)
	{
		_hMacProvider.AppendHashData(source);
	}

	public int FinalizeHashAndReset(Span<byte> destination)
	{
		return _hMacProvider.FinalizeHashAndReset(destination);
	}

	public void Dispose(bool disposing)
	{
		if (disposing)
		{
			_hMacProvider?.Dispose(disposing: true);
			_hMacProvider = null;
		}
	}
}
