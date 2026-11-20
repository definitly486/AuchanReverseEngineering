using System.Diagnostics.CodeAnalysis;

namespace System.Security.Cryptography;

internal static class ECDsaImplementation
{
	public sealed class ECDsaAndroid : ECDsa
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

		public ECDsaAndroid()
			: this(521)
		{
		}

		public ECDsaAndroid(int keySize)
		{
			base.KeySize = keySize;
			_key = new ECAndroid(this);
		}

		internal ECDsaAndroid(SafeEcKeyHandle ecKeyHandle)
		{
			_key = new ECAndroid(ecKeyHandle.DuplicateHandle());
			ForceSetKeySize(_key.KeySize);
		}

		private void ForceSetKeySize(int newKeySize)
		{
			KeySizeValue = newKeySize;
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
			_key.ImportParameters(parameters);
			ForceSetKeySize(_key.KeySize);
		}

		public override ECParameters ExportParameters(bool includePrivateParameters)
		{
			ThrowIfDisposed();
			return ECAndroid.ExportParameters(_key.Value, includePrivateParameters);
		}

		internal SafeEcKeyHandle DuplicateKeyHandle()
		{
			ThrowIfDisposed();
			return _key.UpRefKeyHandle();
		}

		[MemberNotNull("_key")]
		private void ThrowIfDisposed()
		{
			ObjectDisposedException.ThrowIf(_key == null, this);
		}
	}
}
