using System.Runtime.CompilerServices;

namespace System.Transactions.Oletx;

internal sealed class OletxCommittableTransaction : OletxTransaction
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void BeginCommit(InternalTransaction tx)
	{
		throw new NotSupportedException("Linked away");
	}
}
