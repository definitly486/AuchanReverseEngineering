using System.Runtime.CompilerServices;

namespace System.Transactions.Oletx;

internal class OletxTransaction
{
	internal sealed class RealOletxTransaction
	{
		internal InternalTransaction InternalTransaction
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			set
			{
				throw new NotSupportedException("Linked away");
			}
		}
	}

	internal Guid Identifier
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	internal RealOletxTransaction RealTransaction
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		get
		{
			throw new NotSupportedException("Linked away");
		}
	}

	internal Transaction SavedLtmPromotedTransaction
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		set
		{
			throw new NotSupportedException("Linked away");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal IPromotedEnlistment EnlistDurable(Guid resourceManagerIdentifier, DurableInternalEnlistment internalEnlistment, bool v, EnlistmentOptions enlistmentOptions)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal void Rollback()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal OletxDependentTransaction DependentClone(bool delayCommit)
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal IPromotedEnlistment EnlistVolatile(VolatileDemultiplexer volatileDemux, EnlistmentOptions enlistmentOptions)
	{
		throw new NotSupportedException("Linked away");
	}

	internal void Dispose()
	{
	}
}
