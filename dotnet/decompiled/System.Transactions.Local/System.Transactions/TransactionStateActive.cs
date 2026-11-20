namespace System.Transactions;

internal class TransactionStateActive : EnlistableStates
{
	internal override void EnterState(InternalTransaction tx)
	{
		CommonEnterState(tx);
	}

	internal override void BeginCommit(InternalTransaction tx, bool asyncCommit, AsyncCallback asyncCallback, object asyncState)
	{
		tx._asyncCommit = asyncCommit;
		tx._asyncCallback = asyncCallback;
		tx._asyncState = asyncState;
		TransactionState.TransactionStatePhase0.EnterState(tx);
	}

	internal override void Rollback(InternalTransaction tx, Exception e)
	{
		if (tx._innerException == null)
		{
			tx._innerException = e;
		}
		TransactionState.TransactionStateAborted.EnterState(tx);
	}

	internal override void Phase0VolatilePrepareDone(InternalTransaction tx)
	{
	}

	internal override void DisposeRoot(InternalTransaction tx)
	{
		tx.State.Rollback(tx, null);
	}
}
