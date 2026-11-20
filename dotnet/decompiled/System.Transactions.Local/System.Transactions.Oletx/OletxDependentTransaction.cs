using System.Runtime.CompilerServices;

namespace System.Transactions.Oletx;

internal sealed class OletxDependentTransaction : OletxTransaction
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Complete()
	{
		throw new NotSupportedException("Linked away");
	}
}
