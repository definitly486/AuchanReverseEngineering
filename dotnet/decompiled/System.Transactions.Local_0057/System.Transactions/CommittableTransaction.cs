using System.Runtime.Versioning;
using System.Threading;

namespace System.Transactions;

[UnsupportedOSPlatform("browser")]
public sealed class CommittableTransaction : Transaction, IAsyncResult
{
	object? IAsyncResult.AsyncState => _internalTransaction._asyncState;

	bool IAsyncResult.CompletedSynchronously => false;

	WaitHandle IAsyncResult.AsyncWaitHandle
	{
		get
		{
			if (_internalTransaction._asyncResultEvent == null)
			{
				lock (_internalTransaction)
				{
					if (_internalTransaction._asyncResultEvent == null)
					{
						ManualResetEvent asyncResultEvent = new ManualResetEvent(_internalTransaction.State.get_Status(_internalTransaction) != TransactionStatus.Active);
						_internalTransaction._asyncResultEvent = asyncResultEvent;
					}
				}
			}
			return _internalTransaction._asyncResultEvent;
		}
	}

	bool IAsyncResult.IsCompleted
	{
		get
		{
			lock (_internalTransaction)
			{
				return _internalTransaction.State.get_Status(_internalTransaction) != TransactionStatus.Active;
			}
		}
	}

	public CommittableTransaction()
		: this(TransactionManager.DefaultIsolationLevel, TransactionManager.DefaultTimeout)
	{
	}

	public CommittableTransaction(TransactionOptions options)
		: this(options.IsolationLevel, options.Timeout)
	{
	}

	internal CommittableTransaction(IsolationLevel isoLevel, TimeSpan timeout)
		: base(isoLevel, null)
	{
		_internalTransaction = new InternalTransaction(timeout, this);
		_internalTransaction._cloneCount = 1;
		_cloneId = 1;
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (!log.IsEnabled())
		{
		}
	}

	public void Commit()
	{
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		ObjectDisposedException.ThrowIf(base.Disposed, this);
		lock (_internalTransaction)
		{
			if (_complete)
			{
				throw TransactionException.CreateTransactionCompletedException(base.DistributedTxId);
			}
			_internalTransaction.State.BeginCommit(_internalTransaction, asyncCommit: false, null, null);
			while (!_internalTransaction.State.IsCompleted(_internalTransaction) && Monitor.Wait(_internalTransaction))
			{
			}
			_internalTransaction.State.EndCommit(_internalTransaction);
		}
		if (!log.IsEnabled())
		{
		}
	}

	internal override void InternalDispose()
	{
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		if (Interlocked.Exchange(ref _disposed, 1) == 1)
		{
			return;
		}
		if (_internalTransaction.State.get_Status(_internalTransaction) == TransactionStatus.Active)
		{
			lock (_internalTransaction)
			{
				_internalTransaction.State.DisposeRoot(_internalTransaction);
			}
		}
		if (Interlocked.Decrement(ref _internalTransaction._cloneCount) == 0L)
		{
			_internalTransaction.Dispose();
		}
		if (!log.IsEnabled())
		{
		}
	}
}
