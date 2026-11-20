using System.Threading;

namespace System.Transactions;

internal abstract class TransactionStateEnded : TransactionState
{
	internal override void EnterState(InternalTransaction tx)
	{
		if (tx._needPulse)
		{
			Monitor.Pulse(tx);
		}
	}

	internal override bool IsCompleted(InternalTransaction tx)
	{
		return true;
	}
}
