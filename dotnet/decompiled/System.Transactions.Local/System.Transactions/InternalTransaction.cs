using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Transactions.Oletx;

namespace System.Transactions;

internal sealed class InternalTransaction : IDisposable
{
	private TransactionState _transactionState;

	internal TransactionState _promoteState;

	internal Guid _promoterType = Guid.Empty;

	internal Guid _distributedTransactionIdentifierNonMSDTC = Guid.Empty;

	internal FinalizedObject _finalizedObject;

	internal readonly int _transactionHash;

	private readonly long _absoluteTimeout;

	private long _creationTime;

	internal InternalEnlistment _durableEnlistment;

	internal VolatileEnlistmentSet _phase0Volatiles;

	internal VolatileEnlistmentSet _phase1Volatiles;

	internal int _phase0VolatileWaveCount;

	internal OletxDependentTransaction _phase0WaveDependentClone;

	internal int _phase0WaveDependentCloneCount;

	internal OletxDependentTransaction _abortingDependentClone;

	internal int _abortingDependentCloneCount;

	internal Bucket _tableBucket;

	internal int _bucketIndex;

	internal TransactionCompletedEventHandler _transactionCompletedDelegate;

	private OletxTransaction _promotedTransaction;

	internal Exception _innerException;

	internal int _cloneCount;

	internal volatile ManualResetEvent _asyncResultEvent;

	internal bool _asyncCommit;

	internal AsyncCallback _asyncCallback;

	internal object _asyncState;

	internal bool _needPulse;

	internal readonly CommittableTransaction _committableTransaction;

	internal readonly Transaction _outcomeSource;

	private static object s_classSyncObject;

	private static string s_instanceIdentifier;

	private volatile bool _traceIdentifierInited;

	private TransactionTraceIdentifier _traceIdentifier;

	internal TransactionState State
	{
		get
		{
			return _transactionState;
		}
		set
		{
			_transactionState = value;
		}
	}

	internal int TransactionHash => _transactionHash;

	internal long AbsoluteTimeout => _absoluteTimeout;

	internal long CreationTime
	{
		set
		{
			_creationTime = value;
		}
	}

	internal OletxTransaction PromotedTransaction
	{
		get
		{
			return _promotedTransaction;
		}
		set
		{
			_promotedTransaction = value;
		}
	}

	internal Guid DistributedTxId => State.get_Identifier(this);

	internal static string InstanceIdentifier => LazyInitializer.EnsureInitialized(ref s_instanceIdentifier, ref s_classSyncObject, () => $"{Guid.NewGuid()}:");

	internal TransactionTraceIdentifier TransactionTraceId
	{
		get
		{
			if (!_traceIdentifierInited)
			{
				lock (this)
				{
					if (!_traceIdentifierInited)
					{
						IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
						DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler(0, 2, invariantCulture);
						handler.AppendFormatted(InstanceIdentifier);
						handler.AppendFormatted(_transactionHash);
						TransactionTraceIdentifier traceIdentifier = new TransactionTraceIdentifier(string.Create(invariantCulture, ref handler), 0);
						_traceIdentifier = traceIdentifier;
						_traceIdentifierInited = true;
					}
				}
			}
			return _traceIdentifier;
		}
	}

	internal void SetPromoterTypeToMSDTC()
	{
		if (_promoterType != Guid.Empty && _promoterType != TransactionInterop.PromoterTypeDtc)
		{
			throw new InvalidOperationException("PromoterTypeInvalid");
		}
		_promoterType = TransactionInterop.PromoterTypeDtc;
	}

	internal InternalTransaction(TimeSpan timeout, CommittableTransaction committableTransaction)
	{
		_absoluteTimeout = TransactionManager.TransactionTable.TimeoutTicks(timeout);
		TransactionState.TransactionStateActive.EnterState(this);
		_promoteState = TransactionState.TransactionStatePromoted;
		_committableTransaction = committableTransaction;
		_outcomeSource = committableTransaction;
		_transactionHash = TransactionManager.TransactionTable.Add(this);
	}

	internal void SignalAsyncCompletion()
	{
		_asyncResultEvent?.Set();
		if (_asyncCallback != null)
		{
			Monitor.Exit(this);
			try
			{
				_asyncCallback(_committableTransaction);
			}
			finally
			{
				Monitor.Enter(this);
			}
		}
	}

	internal void FireCompletion()
	{
		TransactionCompletedEventHandler transactionCompletedDelegate = _transactionCompletedDelegate;
		if (transactionCompletedDelegate != null)
		{
			TransactionEventArgs e = new TransactionEventArgs();
			e._transaction = _outcomeSource.InternalClone();
			transactionCompletedDelegate(e._transaction, e);
		}
	}

	public void Dispose()
	{
	}
}
