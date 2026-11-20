using System.Runtime.CompilerServices;

namespace System.Security.Cryptography;

public abstract class HMAC : KeyedHashAlgorithm
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void HashCore(byte[] rgb, int ib, int cb)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override byte[] HashFinal()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override void Initialize()
	{
		throw new NotSupportedException("Linked away");
	}
}
