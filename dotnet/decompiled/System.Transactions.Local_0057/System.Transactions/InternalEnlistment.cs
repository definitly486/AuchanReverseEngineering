using System.Runtime.CompilerServices;

namespace System.Transactions;

internal class InternalEnlistment
{
	internal EnlistmentState _twoPhaseState;

	internal EnlistmentState State
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	internal ISinglePhaseNotification SinglePhaseNotification
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	internal virtual Guid ResourceManagerIdentifier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}
}
