using System.Collections;
using System.Transactions.Oletx;

namespace System.Transactions;

internal class TransactionStatePromoted : TransactionStatePromotedBase
{
	internal override void EnterState(InternalTransaction tx)
	{
		tx.SetPromoterTypeToMSDTC();
		if (tx._outcomeSource._isoLevel == IsolationLevel.Snapshot)
		{
			throw TransactionException.CreateInvalidOperationException(TraceSourceType.TraceSourceLtm, "CannotPromoteSnapshot", null);
		}
		CommonEnterState(tx);
		OletxCommittableTransaction oletxCommittableTransaction = null;
		try
		{
			TimeSpan timeSpan;
			if (tx.AbsoluteTimeout == long.MaxValue)
			{
				timeSpan = TimeSpan.Zero;
			}
			else
			{
				timeSpan = TransactionManager.TransactionTable.RecalcTimeout(tx);
				if (timeSpan <= TimeSpan.Zero)
				{
					return;
				}
			}
			TransactionOptions options = new TransactionOptions
			{
				IsolationLevel = tx._outcomeSource._isoLevel,
				Timeout = timeSpan
			};
			oletxCommittableTransaction = TransactionManager.DistributedTransactionManager.CreateTransaction(options);
			oletxCommittableTransaction.SavedLtmPromotedTransaction = tx._outcomeSource;
			TransactionsEtwProvider log = TransactionsEtwProvider.Log;
			if (!log.IsEnabled())
			{
			}
		}
		catch (TransactionException innerException)
		{
			tx._innerException = innerException;
			TransactionsEtwProvider log2 = TransactionsEtwProvider.Log;
			if (!log2.IsEnabled())
			{
			}
			return;
		}
		finally
		{
			if (oletxCommittableTransaction == null)
			{
				tx.State.ChangeStateAbortedDuringPromotion(tx);
			}
		}
		tx.PromotedTransaction = oletxCommittableTransaction;
		Hashtable promotedTransactionTable = TransactionManager.PromotedTransactionTable;
		lock (promotedTransactionTable)
		{
			tx._finalizedObject = new FinalizedObject(tx, oletxCommittableTransaction.Identifier);
			WeakReference value = new WeakReference(tx._outcomeSource, trackResurrection: false);
			promotedTransactionTable[oletxCommittableTransaction.Identifier] = value;
		}
		TransactionManager.FireDistributedTransactionStarted(tx._outcomeSource);
		PromoteEnlistmentsAndOutcome(tx);
	}

	protected static bool PromotePhaseVolatiles(InternalTransaction tx, ref VolatileEnlistmentSet volatiles, bool phase0)
	{
		if (volatiles._volatileEnlistmentCount + volatiles._dependentClones > 0)
		{
			if (phase0)
			{
				volatiles.VolatileDemux = new Phase0VolatileDemultiplexer(tx);
			}
			else
			{
				volatiles.VolatileDemux = new Phase1VolatileDemultiplexer(tx);
			}
			volatiles.VolatileDemux._promotedEnlistment = tx.PromotedTransaction.EnlistVolatile(volatiles.VolatileDemux, phase0 ? EnlistmentOptions.EnlistDuringPrepareRequired : EnlistmentOptions.None);
		}
		return true;
	}

	internal virtual bool PromoteDurable(InternalTransaction tx)
	{
		if (tx._durableEnlistment != null)
		{
			InternalEnlistment durableEnlistment = tx._durableEnlistment;
			IPromotedEnlistment promotedEnlistment = tx.PromotedTransaction.EnlistDurable(durableEnlistment.ResourceManagerIdentifier, (DurableInternalEnlistment)durableEnlistment, durableEnlistment.SinglePhaseNotification != null, EnlistmentOptions.None);
			tx._durableEnlistment.State.ChangeStatePromoted(tx._durableEnlistment, promotedEnlistment);
		}
		return true;
	}

	internal virtual void PromoteEnlistmentsAndOutcome(InternalTransaction tx)
	{
		bool flag = false;
		tx.PromotedTransaction.RealTransaction.InternalTransaction = tx;
		try
		{
			flag = PromotePhaseVolatiles(tx, ref tx._phase0Volatiles, phase0: true);
		}
		catch (TransactionException innerException)
		{
			tx._innerException = innerException;
			TransactionsEtwProvider log = TransactionsEtwProvider.Log;
			if (!log.IsEnabled())
			{
			}
			return;
		}
		finally
		{
			if (!flag)
			{
				tx.PromotedTransaction.Rollback();
				tx.State.ChangeStateAbortedDuringPromotion(tx);
			}
		}
		flag = false;
		try
		{
			flag = PromotePhaseVolatiles(tx, ref tx._phase1Volatiles, phase0: false);
		}
		catch (TransactionException innerException2)
		{
			tx._innerException = innerException2;
			TransactionsEtwProvider log2 = TransactionsEtwProvider.Log;
			if (!log2.IsEnabled())
			{
			}
			return;
		}
		finally
		{
			if (!flag)
			{
				tx.PromotedTransaction.Rollback();
				tx.State.ChangeStateAbortedDuringPromotion(tx);
			}
		}
		flag = false;
		try
		{
			flag = PromoteDurable(tx);
		}
		catch (TransactionException innerException3)
		{
			tx._innerException = innerException3;
			TransactionsEtwProvider log3 = TransactionsEtwProvider.Log;
			if (!log3.IsEnabled())
			{
			}
		}
		finally
		{
			if (!flag)
			{
				tx.PromotedTransaction.Rollback();
				tx.State.ChangeStateAbortedDuringPromotion(tx);
			}
		}
	}

	internal override void DisposeRoot(InternalTransaction tx)
	{
		tx.State.Rollback(tx, null);
	}
}
