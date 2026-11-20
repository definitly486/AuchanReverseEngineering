namespace System.Security.Cryptography;

internal static class HashProviderDispenser
{
	internal static class OneShotHashProvider
	{
		public static int MacData(string hashAlgorithmId, ReadOnlySpan<byte> key, ReadOnlySpan<byte> source, Span<byte> destination)
		{
			nint num = global::Interop.Crypto.HashAlgorithmToEvp(hashAlgorithmId);
			int num2 = global::Interop.Crypto.EvpMdSize(num);
			if (num2 <= 0 || destination.Length < num2)
			{
				throw new CryptographicException();
			}
			return global::Interop.Crypto.HmacOneShot(num, key, source, destination);
		}

		public unsafe static int HashData(string hashAlgorithmId, ReadOnlySpan<byte> source, Span<byte> destination)
		{
			nint num = global::Interop.Crypto.HashAlgorithmToEvp(hashAlgorithmId);
			int num2 = global::Interop.Crypto.EvpMdSize(num);
			if (num2 <= 0 || destination.Length < num2)
			{
				throw new CryptographicException();
			}
			fixed (byte* source2 = source)
			{
				fixed (byte* md = destination)
				{
					uint length = (uint)destination.Length;
					if (global::Interop.Crypto.EvpDigestOneShot(num, source2, source.Length, md, &length) != 1)
					{
						throw global::Interop.Crypto.CreateOpenSslCryptographicException();
					}
				}
			}
			return num2;
		}
	}

	private sealed class EvpHashProvider : HashProvider
	{
		private readonly LiteHash _liteHash;

		private bool _running;

		private ConcurrencyBlock _block;

		public override int HashSizeInBytes => _liteHash.HashSizeInBytes;

		public EvpHashProvider(string hashAlgorithmId)
		{
			_liteHash = LiteHashProvider.CreateHash(hashAlgorithmId);
		}

		public override void AppendHashData(ReadOnlySpan<byte> data)
		{
			using (ConcurrencyBlock.Enter(ref _block))
			{
				_liteHash.Append(data);
				_running = true;
			}
		}

		public override int FinalizeHashAndReset(Span<byte> destination)
		{
			using (ConcurrencyBlock.Enter(ref _block))
			{
				int result = _liteHash.Finalize(destination);
				_liteHash.Reset();
				_running = false;
				return result;
			}
		}

		public override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_liteHash.Dispose();
			}
		}

		public override void Reset()
		{
			using (ConcurrencyBlock.Enter(ref _block))
			{
				if (_running)
				{
					_liteHash.Reset();
					_running = false;
				}
			}
		}
	}

	private sealed class HmacHashProvider : HashProvider
	{
		private readonly LiteHmac _liteHmac;

		private bool _running;

		private ConcurrencyBlock _block;

		public override int HashSizeInBytes => _liteHmac.HashSizeInBytes;

		public HmacHashProvider(string hashAlgorithmId, ReadOnlySpan<byte> key)
		{
			_liteHmac = LiteHashProvider.CreateHmac(hashAlgorithmId, key);
		}

		public override void AppendHashData(ReadOnlySpan<byte> data)
		{
			using (ConcurrencyBlock.Enter(ref _block))
			{
				_liteHmac.Append(data);
				_running = true;
			}
		}

		public override int FinalizeHashAndReset(Span<byte> destination)
		{
			using (ConcurrencyBlock.Enter(ref _block))
			{
				int result = _liteHmac.Finalize(destination);
				_liteHmac.Reset();
				_running = false;
				return result;
			}
		}

		public override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_liteHmac.Dispose();
			}
		}

		public override void Reset()
		{
			using (ConcurrencyBlock.Enter(ref _block))
			{
				if (_running)
				{
					_liteHmac.Reset();
					_running = false;
				}
			}
		}
	}

	internal static HashProvider CreateHashProvider(string hashAlgorithmId)
	{
		return new EvpHashProvider(hashAlgorithmId);
	}

	internal static HashProvider CreateMacProvider(string hashAlgorithmId, ReadOnlySpan<byte> key)
	{
		return new HmacHashProvider(hashAlgorithmId, key);
	}

	internal static bool HashSupported(string hashAlgorithmId)
	{
		return global::Interop.Crypto.HashAlgorithmSupported(hashAlgorithmId);
	}

	internal static bool MacSupported(string hashAlgorithmId)
	{
		return HashSupported(hashAlgorithmId);
	}
}
