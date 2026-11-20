using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Threading;

namespace System.Transactions;

public class Transaction : IDisposable, ISerializable
{
	internal IsolationLevel _isoLevel;

	internal bool _complete;

	internal int _cloneId;

	internal int _disposed;

	internal InternalTransaction _internalTransaction;

	internal TransactionTraceIdentifier _traceIdentifier;

	internal bool Disposed => _disposed == 1;

	internal Guid DistributedTxId
	{
		get
		{
			Guid result = Guid.Empty;
			if (_internalTransaction != null)
			{
				result = _internalTransaction.DistributedTxId;
			}
			return result;
		}
	}

	public IsolationLevel IsolationLevel
	{
		get
		{
			TransactionsEtwProvider log = TransactionsEtwProvider.Log;
			if (log.IsEnabled())
			{
			}
			ObjectDisposedException.ThrowIf(Disposed, this);
			if (log.IsEnabled())
			{
			}
			return _isoLevel;
		}
	}

	internal TransactionTraceIdentifier TransactionTraceId
	{
		get
		{
			if (_traceIdentifier == TransactionTraceIdentifier.Empty)
			{
				lock (_internalTransaction)
				{
					if (_traceIdentifier == TransactionTraceIdentifier.Empty)
					{
						TransactionTraceIdentifier traceIdentifier = new TransactionTraceIdentifier(_internalTransaction.TransactionTraceId.TransactionIdentifier, _cloneId);
						Interlocked.MemoryBarrier();
						_traceIdentifier = traceIdentifier;
					}
				}
			}
			return _traceIdentifier;
		}
	}

	internal static EnterpriseServicesInteropOption InteropMode(TransactionScope currentScope)
	{
		return currentScope?.InteropMode ?? EnterpriseServicesInteropOption.None;
	}

	internal static Transaction FastGetTransaction(TransactionScope currentScope, ContextData contextData, out Transaction contextTransaction)
	{
		Transaction transaction = null;
		contextTransaction = contextData.CurrentTransaction;
		switch (InteropMode(currentScope))
		{
		case EnterpriseServicesInteropOption.None:
			transaction = contextTransaction;
			if (transaction == null && currentScope == null)
			{
				transaction = ((!TransactionManager.s_currentDelegateSet) ? null : TransactionManager.s_currentDelegate());
			}
			break;
		case EnterpriseServicesInteropOption.Full:
			transaction = null;
			break;
		case EnterpriseServicesInteropOption.Automatic:
			if (false)
			{
			}
			transaction = contextData.CurrentTransaction;
			break;
		}
		return transaction;
	}

	internal static void GetCurrentTransactionAndScope(TxLookup defaultLookup, out Transaction current, out TransactionScope currentScope, out Transaction contextTransaction)
	{
		current = null;
		currentScope = null;
		contextTransaction = null;
		ContextData contextData = ContextData.LookupContextData(defaultLookup);
		if (contextData != null)
		{
			currentScope = contextData.CurrentScope;
			current = FastGetTransaction(currentScope, contextData, out contextTransaction);
		}
	}

	internal Transaction(IsolationLevel isoLevel, InternalTransaction internalTransaction)
	{
		TransactionManager.ValidateIsolationLevel(isoLevel);
		_isoLevel = isoLevel;
		if (IsolationLevel.Unspecified == _isoLevel)
		{
			_isoLevel = TransactionManager.DefaultIsolationLevel;
		}
		if (internalTransaction != null)
		{
			_internalTransaction = internalTransaction;
			_cloneId = Interlocked.Increment(ref _internalTransaction._cloneCount);
		}
	}

	public override int GetHashCode()
	{
		return _internalTransaction.TransactionHash;
	}

	public override bool Equals([NotNullWhen(true)] object? obj)
	{
		if (obj is Transaction transaction)
		{
			return _internalTransaction.TransactionHash == transaction._internalTransaction.TransactionHash;
		}
		return false;
	}

	public static bool operator ==(Transaction? x, Transaction? y)
	{
		return x?.Equals(y) ?? ((object)y == null);
	}

	public static bool operator !=(Transaction? x, Transaction? y)
	{
		if ((object)x != null)
		{
			return !x.Equals(y);
		}
		return (object)y != null;
	}

	public void Rollback()
	{
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		ObjectDisposedException.ThrowIf(Disposed, this);
		lock (_internalTransaction)
		{
			_internalTransaction.State.Rollback(_internalTransaction, null);
		}
		if (!log.IsEnabled())
		{
		}
	}

	public Transaction Clone()
	{
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		ObjectDisposedException.ThrowIf(Disposed, this);
		if (_complete)
		{
			throw TransactionException.CreateTransactionCompletedException(DistributedTxId);
		}
		Transaction result = InternalClone();
		if (log.IsEnabled())
		{
		}
		return result;
	}

	internal Transaction InternalClone()
	{
		Transaction result = new Transaction(_isoLevel, _internalTransaction);
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		return result;
	}

	public DependentTransaction DependentClone(DependentCloneOption cloneOption)
	{
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		if (cloneOption != DependentCloneOption.BlockCommitUntilComplete && cloneOption != DependentCloneOption.RollbackIfNotComplete)
		{
			throw new ArgumentOutOfRangeException("cloneOption");
		}
		ObjectDisposedException.ThrowIf(Disposed, this);
		if (_complete)
		{
			throw TransactionException.CreateTransactionCompletedException(DistributedTxId);
		}
		DependentTransaction result = new DependentTransaction(_isoLevel, _internalTransaction, cloneOption == DependentCloneOption.BlockCommitUntilComplete);
		if (log.IsEnabled())
		{
		}
		return result;
	}

	public void Dispose()
	{
		InternalDispose();
	}

	internal virtual void InternalDispose()
	{
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		if (Interlocked.Exchange(ref _disposed, 1) != 1)
		{
			if (Interlocked.Decrement(ref _internalTransaction._cloneCount) == 0L)
			{
				_internalTransaction.Dispose();
			}
			if (!log.IsEnabled())
			{
			}
		}
	}

	void ISerializable.GetObjectData(SerializationInfo serializationInfo, StreamingContext context)
	{
		throw new PlatformNotSupportedException();
	}
}
