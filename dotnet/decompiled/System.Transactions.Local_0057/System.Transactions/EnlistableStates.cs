namespace System.Transactions;

internal abstract class EnlistableStates : ActiveStates
{
	internal override void Timeout(InternalTransaction tx)
	{
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		TimeoutException e = new TimeoutException("TraceTransactionTimeout");
		Rollback(tx, e);
	}

	internal override void CompleteBlockingClone(InternalTransaction tx)
	{
		tx._phase0Volatiles._dependentClones--;
		if (tx._phase0Volatiles._preparedVolatileEnlistments == tx._phase0VolatileWaveCount + tx._phase0Volatiles._dependentClones)
		{
			tx.State.Phase0VolatilePrepareDone(tx);
		}
	}

	internal override void CompleteAbortingClone(InternalTransaction tx)
	{
		tx._phase1Volatiles._dependentClones--;
	}

	internal override void CreateBlockingClone(InternalTransaction tx)
	{
		tx._phase0Volatiles._dependentClones++;
	}

	internal override void CreateAbortingClone(InternalTransaction tx)
	{
		tx._phase1Volatiles._dependentClones++;
	}
}
