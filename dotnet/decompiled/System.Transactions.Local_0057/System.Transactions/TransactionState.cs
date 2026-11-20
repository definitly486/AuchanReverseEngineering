using System.Threading;

namespace System.Transactions;

internal abstract class TransactionState
{
	private static TransactionStateActive s_transactionStateActive;

	private static TransactionStatePhase0 s_transactionStatePhase0;

	private static TransactionStateVolatilePhase1 s_transactionStateVolatilePhase1;

	private static TransactionStateVolatileSPC s_transactionStateVolatileSPC;

	private static TransactionStateSPC s_transactionStateSPC;

	private static TransactionStateAborted s_transactionStateAborted;

	private static TransactionStateCommitted s_transactionStateCommitted;

	private static TransactionStatePromoted s_transactionStatePromoted;

	private static TransactionStatePromotedCommitting s_transactionStatePromotedCommitting;

	internal static object s_classSyncObject;

	internal static TransactionStateActive TransactionStateActive => LazyInitializer.EnsureInitialized(ref s_transactionStateActive, ref s_classSyncObject, () => new TransactionStateActive());

	protected static TransactionStatePhase0 TransactionStatePhase0 => LazyInitializer.EnsureInitialized(ref s_transactionStatePhase0, ref s_classSyncObject, () => new TransactionStatePhase0());

	protected static TransactionStateVolatilePhase1 TransactionStateVolatilePhase1 => LazyInitializer.EnsureInitialized(ref s_transactionStateVolatilePhase1, ref s_classSyncObject, () => new TransactionStateVolatilePhase1());

	protected static TransactionStateVolatileSPC TransactionStateVolatileSPC => LazyInitializer.EnsureInitialized(ref s_transactionStateVolatileSPC, ref s_classSyncObject, () => new TransactionStateVolatileSPC());

	protected static TransactionStateSPC TransactionStateSPC => LazyInitializer.EnsureInitialized(ref s_transactionStateSPC, ref s_classSyncObject, () => new TransactionStateSPC());

	protected static TransactionStateAborted TransactionStateAborted => LazyInitializer.EnsureInitialized(ref s_transactionStateAborted, ref s_classSyncObject, () => new TransactionStateAborted());

	protected static TransactionStateCommitted TransactionStateCommitted => LazyInitializer.EnsureInitialized(ref s_transactionStateCommitted, ref s_classSyncObject, () => new TransactionStateCommitted());

	internal static TransactionStatePromoted TransactionStatePromoted => LazyInitializer.EnsureInitialized(ref s_transactionStatePromoted, ref s_classSyncObject, () => new TransactionStatePromoted());

	protected static TransactionStatePromotedCommitting TransactionStatePromotedCommitting => LazyInitializer.EnsureInitialized(ref s_transactionStatePromotedCommitting, ref s_classSyncObject, () => new TransactionStatePromotedCommitting());

	internal void CommonEnterState(InternalTransaction tx)
	{
		tx.State = this;
	}

	internal abstract void EnterState(InternalTransaction tx);

	internal virtual void BeginCommit(InternalTransaction tx, bool asyncCommit, AsyncCallback asyncCallback, object asyncState)
	{
		throw TransactionException.CreateTransactionStateException(tx._innerException, tx.DistributedTxId);
	}

	internal virtual void EndCommit(InternalTransaction tx)
	{
		throw TransactionException.CreateTransactionStateException(tx._innerException, tx.DistributedTxId);
	}

	internal virtual void Rollback(InternalTransaction tx, Exception e)
	{
		throw TransactionException.CreateTransactionStateException(tx._innerException, tx.DistributedTxId);
	}

	internal virtual Guid get_Identifier(InternalTransaction tx)
	{
		return Guid.Empty;
	}

	internal abstract TransactionStatus get_Status(InternalTransaction tx);

	internal virtual void CompleteBlockingClone(InternalTransaction tx)
	{
	}

	internal virtual void CompleteAbortingClone(InternalTransaction tx)
	{
	}

	internal virtual void CreateBlockingClone(InternalTransaction tx)
	{
		throw TransactionException.CreateTransactionStateException(tx._innerException, tx.DistributedTxId);
	}

	internal virtual void CreateAbortingClone(InternalTransaction tx)
	{
		throw TransactionException.CreateTransactionStateException(tx._innerException, tx.DistributedTxId);
	}

	internal virtual void ChangeStateTransactionAborted(InternalTransaction tx, Exception e)
	{
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		throw new InvalidOperationException();
	}

	internal virtual void ChangeStateAbortedDuringPromotion(InternalTransaction tx)
	{
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		throw new InvalidOperationException();
	}

	internal virtual void Timeout(InternalTransaction tx)
	{
	}

	internal virtual void Phase0VolatilePrepareDone(InternalTransaction tx)
	{
		throw TransactionException.CreateTransactionStateException(tx._innerException, tx.DistributedTxId);
	}

	internal virtual bool ContinuePhase0Prepares()
	{
		return false;
	}

	internal virtual bool ContinuePhase1Prepares()
	{
		return false;
	}

	internal virtual void DisposeRoot(InternalTransaction tx)
	{
	}

	internal virtual bool IsCompleted(InternalTransaction tx)
	{
		tx._needPulse = true;
		return false;
	}
}
