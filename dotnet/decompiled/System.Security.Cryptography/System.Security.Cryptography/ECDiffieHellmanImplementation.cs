using System.Diagnostics.CodeAnalysis;

namespace System.Security.Cryptography;

internal static class ECDiffieHellmanImplementation
{
	public sealed class ECDiffieHellmanAndroid : ECDiffieHellman
	{
		private ECAndroid _key;

		public override KeySizes[] LegalKeySizes => ECAlgorithm.s_defaultKeySizes.CloneKeySizesArray();

		public override int KeySize
		{
			get
			{
				return base.KeySize;
			}
			set
			{
				if (KeySize != value)
				{
					base.KeySize = value;
					ThrowIfDisposed();
					_key.Dispose();
					_key = new ECAndroid(this);
				}
			}
		}

		internal ECDiffieHellmanAndroid(SafeEcKeyHandle ecKeyHandle)
		{
			_key = new ECAndroid(ecKeyHandle.DuplicateHandle());
			KeySizeValue = _key.KeySize;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				_key?.Dispose();
				_key = null;
			}
			base.Dispose(disposing);
		}

		public override void ImportParameters(ECParameters parameters)
		{
			ThrowIfDisposed();
			KeySizeValue = _key.ImportParameters(parameters);
		}

		public override ECParameters ExportParameters(bool includePrivateParameters)
		{
			return ECAndroid.ExportParameters(GetKey(), includePrivateParameters);
		}

		[MemberNotNull("_key")]
		private void ThrowIfDisposed()
		{
			ObjectDisposedException.ThrowIf(_key == null, this);
		}

		private SafeEcKeyHandle GetKey()
		{
			ThrowIfDisposed();
			return _key.Value;
		}
	}
}
