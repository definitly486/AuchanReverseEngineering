using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace System.Security.Cryptography;

[EditorBrowsable(EditorBrowsableState.Never)]
public abstract class RC2 : SymmetricAlgorithm
{
	public virtual int EffectiveKeySize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
