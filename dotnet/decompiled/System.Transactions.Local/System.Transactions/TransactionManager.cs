using System.Collections;
using System.Threading;
using System.Transactions.Configuration;
using System.Transactions.Oletx;

namespace System.Transactions;

public static class TransactionManager
{
	private static Hashtable s_promotedTransactionTable;

	private static TransactionTable s_transactionTable;

	private static TransactionStartedEventHandler s_distributedTransactionStartedDelegate;

	internal static HostCurrentTransactionCallback s_currentDelegate;

	internal static bool s_currentDelegateSet;

	private static object s_classSyncObject;

	private static bool s_defaultTimeoutValidated;

	private static long s_defaultTimeoutTicks;

	private static bool s_cachedMaxTimeout;

	private static TimeSpan s_maximumTimeout;

	internal static OletxTransactionManager distributedTransactionManager;

	private static object ClassSyncObject => LazyInitializer.EnsureInitialized(ref s_classSyncObject);

	internal static IsolationLevel DefaultIsolationLevel
	{
		get
		{
			TransactionsEtwProvider log = TransactionsEtwProvider.Log;
			if (log.IsEnabled())
			{
			}
			return IsolationLevel.Serializable;
		}
	}

	public static TimeSpan DefaultTimeout
	{
		get
		{
			TransactionsEtwProvider log = TransactionsEtwProvider.Log;
			if (log.IsEnabled())
			{
			}
			if (!s_defaultTimeoutValidated)
			{
				LazyInitializer.EnsureInitialized(ref s_defaultTimeoutTicks, ref s_defaultTimeoutValidated, ref s_classSyncObject, () => ValidateTimeout(DefaultSettingsSection.Timeout).Ticks);
				if (Interlocked.Read(ref s_defaultTimeoutTicks) != DefaultSettingsSection.Timeout.Ticks && !log.IsEnabled())
				{
				}
			}
			if (log.IsEnabled())
			{
			}
			return new TimeSpan(Interlocked.Read(ref s_defaultTimeoutTicks));
		}
	}

	public static TimeSpan MaximumTimeout
	{
		get
		{
			TransactionsEtwProvider log = TransactionsEtwProvider.Log;
			if (log.IsEnabled())
			{
			}
			LazyInitializer.EnsureInitialized(ref s_maximumTimeout, ref s_cachedMaxTimeout, ref s_classSyncObject, () => MachineSettingsSection.MaxTimeout);
			if (log.IsEnabled())
			{
			}
			return s_maximumTimeout;
		}
	}

	internal static Hashtable PromotedTransactionTable => LazyInitializer.EnsureInitialized(ref s_promotedTransactionTable, ref s_classSyncObject, () => new Hashtable(100));

	internal static TransactionTable TransactionTable => LazyInitializer.EnsureInitialized(ref s_transactionTable, ref s_classSyncObject, () => new TransactionTable());

	internal static OletxTransactionManager DistributedTransactionManager => LazyInitializer.EnsureInitialized(ref distributedTransactionManager, ref s_classSyncObject, () => new OletxTransactionManager(DefaultSettingsSection.DistributedTransactionManagerName));

	internal static void FireDistributedTransactionStarted(Transaction transaction)
	{
		TransactionStartedEventHandler transactionStartedEventHandler = null;
		lock (ClassSyncObject)
		{
			transactionStartedEventHandler = s_distributedTransactionStartedDelegate;
		}
		if (transactionStartedEventHandler != null)
		{
			TransactionEventArgs e = new TransactionEventArgs();
			e._transaction = transaction.InternalClone();
			transactionStartedEventHandler(e._transaction, e);
		}
	}

	internal static void ValidateIsolationLevel(IsolationLevel transactionIsolationLevel)
	{
		if ((uint)transactionIsolationLevel > 6u)
		{
			throw new ArgumentOutOfRangeException("transactionIsolationLevel");
		}
	}

	internal static TimeSpan ValidateTimeout(TimeSpan transactionTimeout)
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(transactionTimeout, TimeSpan.Zero, "transactionTimeout");
		if (MaximumTimeout != TimeSpan.Zero && (transactionTimeout > MaximumTimeout || transactionTimeout == TimeSpan.Zero))
		{
			return MaximumTimeout;
		}
		return transactionTimeout;
	}
}
