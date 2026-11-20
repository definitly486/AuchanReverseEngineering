using System.Runtime.CompilerServices;

namespace System.Transactions;

internal abstract class EnlistmentState
{
	[MethodImpl(MethodImplOptions.NoInlining)]
	internal virtual void InternalAborted(InternalEnlistment enlistment)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal virtual void InternalCommitted(InternalEnlistment enlistment)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal virtual void ChangeStateCommitting(InternalEnlistment enlistment)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal virtual void ChangeStatePromoted(InternalEnlistment enlistment, IPromotedEnlistment promotedEnlistment)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal virtual void ChangeStatePreparing(InternalEnlistment enlistment)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal virtual void ChangeStateSinglePhaseCommit(InternalEnlistment enlistment)
	{
		throw new NotSupportedException("Linked away");
	}
}
