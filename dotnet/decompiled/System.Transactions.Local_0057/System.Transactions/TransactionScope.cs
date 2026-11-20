using System.Runtime.Versioning;
using System.Threading;

namespace System.Transactions;

[UnsupportedOSPlatform("browser")]
public sealed class TransactionScope : IDisposable
{
	private bool _complete;

	private Transaction _savedCurrent;

	private Transaction _contextTransaction;

	private TransactionScope _savedCurrentScope;

	private ContextData _threadContextData;

	private ContextData _savedTLSContextData;

	private Transaction _expectedCurrent;

	private CommittableTransaction _committableTransaction;

	private DependentTransaction _dependentTransaction;

	private bool _disposed;

	private Timer _scopeTimer;

	private Thread _scopeThread;

	private bool _interopModeSpecified;

	private EnterpriseServicesInteropOption _interopOption;

	internal EnterpriseServicesInteropOption InteropMode => _interopOption;

	internal ContextKey? ContextKey { get; private set; }

	internal bool AsyncFlowEnabled { get; private set; }

	public TransactionScope(TransactionScopeAsyncFlowOption asyncFlowOption)
		: this(TransactionScopeOption.Required, asyncFlowOption)
	{
	}

	public TransactionScope(TransactionScopeOption scopeOption, TransactionScopeAsyncFlowOption asyncFlowOption)
	{
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		ValidateAndSetAsyncFlowOption(asyncFlowOption);
		if (NeedToCreateTransaction(scopeOption))
		{
			_committableTransaction = new CommittableTransaction();
			_expectedCurrent = _committableTransaction.Clone();
		}
		if (!(null == _expectedCurrent) || log.IsEnabled())
		{
			if (null == _committableTransaction)
			{
				TransactionScopeResult transactionScopeResult = TransactionScopeResult.UsingExistingCurrent;
			}
			else
			{
				TransactionScopeResult transactionScopeResult = TransactionScopeResult.CreatedTransaction;
			}
			if (!log.IsEnabled())
			{
			}
		}
		PushScope();
		if (!log.IsEnabled())
		{
		}
	}

	public TransactionScope(TransactionScopeOption scopeOption, TransactionOptions transactionOptions, TransactionScopeAsyncFlowOption asyncFlowOption)
	{
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		ValidateScopeTimeout("transactionOptions.Timeout", transactionOptions.Timeout);
		TimeSpan timeout = transactionOptions.Timeout;
		transactionOptions.Timeout = TransactionManager.ValidateTimeout(transactionOptions.Timeout);
		TransactionManager.ValidateIsolationLevel(transactionOptions.IsolationLevel);
		ValidateAndSetAsyncFlowOption(asyncFlowOption);
		if (NeedToCreateTransaction(scopeOption))
		{
			_committableTransaction = new CommittableTransaction(transactionOptions);
			_expectedCurrent = _committableTransaction.Clone();
		}
		else if (null != _expectedCurrent && IsolationLevel.Unspecified != transactionOptions.IsolationLevel && _expectedCurrent.IsolationLevel != transactionOptions.IsolationLevel)
		{
			throw new ArgumentException("TransactionScopeIsolationLevelDifferentFromTransaction", "transactionOptions");
		}
		if (null != _expectedCurrent && null == _committableTransaction && TimeSpan.Zero != timeout)
		{
			_scopeTimer = new Timer(TimerCallback, this, timeout, TimeSpan.Zero);
		}
		if (!(null == _expectedCurrent) || log.IsEnabled())
		{
			if (null == _committableTransaction)
			{
				TransactionScopeResult transactionScopeResult = TransactionScopeResult.UsingExistingCurrent;
			}
			else
			{
				TransactionScopeResult transactionScopeResult = TransactionScopeResult.CreatedTransaction;
			}
			if (!log.IsEnabled())
			{
			}
		}
		PushScope();
		if (!log.IsEnabled())
		{
		}
	}

	private bool NeedToCreateTransaction(TransactionScopeOption scopeOption)
	{
		bool result = false;
		CommonInitialize();
		switch (scopeOption)
		{
		case TransactionScopeOption.Suppress:
			_expectedCurrent = null;
			result = false;
			break;
		case TransactionScopeOption.Required:
			_expectedCurrent = _savedCurrent;
			if (null == _expectedCurrent)
			{
				result = true;
			}
			break;
		case TransactionScopeOption.RequiresNew:
			result = true;
			break;
		default:
			throw new ArgumentOutOfRangeException("scopeOption");
		}
		return result;
	}

	public void Dispose()
	{
		bool flag = false;
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		if (_disposed)
		{
			if (!log.IsEnabled())
			{
			}
			return;
		}
		if (_scopeThread != Thread.CurrentThread && !AsyncFlowEnabled)
		{
			if (log.IsEnabled())
			{
			}
			throw new InvalidOperationException("InvalidScopeThread");
		}
		Exception ex = null;
		try
		{
			_disposed = true;
			TransactionScope currentScope = _threadContextData.CurrentScope;
			Transaction contextTransaction = null;
			Transaction transaction = Transaction.FastGetTransaction(currentScope, _threadContextData, out contextTransaction);
			if (!Equals(currentScope))
			{
				if (currentScope == null)
				{
					Transaction transaction2 = (Transaction)(((object)_committableTransaction) ?? ((object)_dependentTransaction));
					transaction2.Rollback();
					flag = true;
					throw TransactionException.CreateInvalidOperationException(TraceSourceType.TraceSourceBase, "TransactionScopeInvalidNesting", null, transaction2.DistributedTxId);
				}
				if (currentScope._interopOption == EnterpriseServicesInteropOption.None && ((null != currentScope._expectedCurrent && !currentScope._expectedCurrent.Equals(transaction)) || (null != transaction && null == currentScope._expectedCurrent)))
				{
					if (null == transaction)
					{
						TransactionTraceIdentifier empty = TransactionTraceIdentifier.Empty;
					}
					else
					{
						TransactionTraceIdentifier empty = transaction.TransactionTraceId;
					}
					if (null == _expectedCurrent)
					{
						TransactionTraceIdentifier empty2 = TransactionTraceIdentifier.Empty;
					}
					else
					{
						TransactionTraceIdentifier empty2 = _expectedCurrent.TransactionTraceId;
					}
					if (log.IsEnabled())
					{
					}
					ex = TransactionException.CreateInvalidOperationException(TraceSourceType.TraceSourceBase, "TransactionScopeIncorrectCurrent", null, (transaction == null) ? Guid.Empty : transaction.DistributedTxId);
					if (null != transaction)
					{
						try
						{
							transaction.Rollback();
						}
						catch (TransactionException)
						{
						}
						catch (ObjectDisposedException)
						{
						}
					}
				}
				while (!Equals(currentScope))
				{
					if (ex == null)
					{
						ex = TransactionException.CreateInvalidOperationException(TraceSourceType.TraceSourceBase, "TransactionScopeInvalidNesting", null, (transaction == null) ? Guid.Empty : transaction.DistributedTxId);
					}
					if ((null == currentScope._expectedCurrent && !log.IsEnabled()) || log.IsEnabled())
					{
					}
					currentScope._complete = false;
					try
					{
						currentScope.InternalDispose();
					}
					catch (TransactionException)
					{
					}
					currentScope = _threadContextData.CurrentScope;
					_complete = false;
				}
			}
			else if (_interopOption == EnterpriseServicesInteropOption.None && ((null != _expectedCurrent && !_expectedCurrent.Equals(transaction)) || (null != transaction && null == _expectedCurrent)))
			{
				if (null == transaction)
				{
					TransactionTraceIdentifier empty3 = TransactionTraceIdentifier.Empty;
				}
				else
				{
					TransactionTraceIdentifier empty3 = transaction.TransactionTraceId;
				}
				if (null == _expectedCurrent)
				{
					TransactionTraceIdentifier empty4 = TransactionTraceIdentifier.Empty;
				}
				else
				{
					TransactionTraceIdentifier empty4 = _expectedCurrent.TransactionTraceId;
				}
				if (log.IsEnabled())
				{
				}
				if (ex == null)
				{
					ex = TransactionException.CreateInvalidOperationException(TraceSourceType.TraceSourceBase, "TransactionScopeIncorrectCurrent", null, (transaction == null) ? Guid.Empty : transaction.DistributedTxId);
				}
				if (null != transaction)
				{
					try
					{
						transaction.Rollback();
					}
					catch (TransactionException)
					{
					}
					catch (ObjectDisposedException)
					{
					}
				}
				_complete = false;
			}
			flag = true;
		}
		finally
		{
			if (!flag)
			{
				PopScope();
			}
		}
		InternalDispose();
		if (ex != null)
		{
			throw ex;
		}
		if (!log.IsEnabled())
		{
		}
	}

	private void InternalDispose()
	{
		_disposed = true;
		try
		{
			PopScope();
			TransactionsEtwProvider log = TransactionsEtwProvider.Log;
			if ((null == _expectedCurrent && !log.IsEnabled()) || log.IsEnabled())
			{
			}
			if (!(null != _expectedCurrent))
			{
				return;
			}
			if (!_complete)
			{
				if (log.IsEnabled())
				{
				}
				((Transaction)(((object)_committableTransaction) ?? ((object)_dependentTransaction))).Rollback();
			}
			else if (null != _committableTransaction)
			{
				_committableTransaction.Commit();
			}
			else
			{
				_dependentTransaction.Complete();
			}
		}
		finally
		{
			_scopeTimer?.Dispose();
			if (null != _committableTransaction)
			{
				_committableTransaction.Dispose();
				_expectedCurrent.Dispose();
			}
			_dependentTransaction?.Dispose();
		}
	}

	public void Complete()
	{
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		ObjectDisposedException.ThrowIf(_disposed, this);
		if (_complete)
		{
			throw TransactionException.CreateInvalidOperationException(TraceSourceType.TraceSourceBase, "DisposeScope", null);
		}
		_complete = true;
		if (!log.IsEnabled())
		{
		}
	}

	private static void TimerCallback(object state)
	{
		if (!(state is TransactionScope transactionScope))
		{
			TransactionsEtwProvider log = TransactionsEtwProvider.Log;
			if (log.IsEnabled())
			{
			}
			throw TransactionException.Create("InternalError" + "TransactionScopeTimerObjectInvalid", null);
		}
		transactionScope.Timeout();
	}

	private void Timeout()
	{
		if (_complete || !(null != _expectedCurrent))
		{
			return;
		}
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		try
		{
			_expectedCurrent.Rollback();
		}
		catch (ObjectDisposedException)
		{
			if (!log.IsEnabled())
			{
			}
		}
		catch (TransactionException)
		{
			if (!log.IsEnabled())
			{
			}
		}
	}

	private void CommonInitialize()
	{
		ContextKey = new ContextKey();
		_complete = false;
		_dependentTransaction = null;
		_disposed = false;
		_committableTransaction = null;
		_expectedCurrent = null;
		_scopeTimer = null;
		_scopeThread = Thread.CurrentThread;
		Transaction.GetCurrentTransactionAndScope(AsyncFlowEnabled ? TxLookup.DefaultCallContext : TxLookup.DefaultTLS, out _savedCurrent, out _savedCurrentScope, out _contextTransaction);
		ValidateAsyncFlowOptionAndESInteropOption();
	}

	private void PushScope()
	{
		if (!_interopModeSpecified)
		{
			_interopOption = Transaction.InteropMode(_savedCurrentScope);
		}
		SaveTLSContextData();
		if (AsyncFlowEnabled)
		{
			_threadContextData = CallContextCurrentData.CreateOrGetCurrentData(ContextKey);
			if (_savedCurrentScope == null && _savedCurrent == null)
			{
				ContextData.TLSCurrentData = null;
			}
		}
		else
		{
			_threadContextData = ContextData.TLSCurrentData;
			CallContextCurrentData.ClearCurrentData(ContextKey, removeContextData: false);
		}
		SetCurrent(_expectedCurrent);
		_threadContextData.CurrentScope = this;
	}

	private void PopScope()
	{
		bool flag = true;
		if (AsyncFlowEnabled)
		{
			CallContextCurrentData.ClearCurrentData(ContextKey, removeContextData: true);
		}
		if (_scopeThread == Thread.CurrentThread)
		{
			RestoreSavedTLSContextData();
		}
		if (_savedCurrentScope != null)
		{
			if (_savedCurrentScope.AsyncFlowEnabled)
			{
				_threadContextData = CallContextCurrentData.CreateOrGetCurrentData(_savedCurrentScope.ContextKey);
			}
			else
			{
				if (_savedCurrentScope._scopeThread != Thread.CurrentThread)
				{
					flag = false;
					ContextData.TLSCurrentData = null;
				}
				else
				{
					_threadContextData = ContextData.TLSCurrentData;
				}
				CallContextCurrentData.ClearCurrentData(_savedCurrentScope.ContextKey, removeContextData: false);
			}
		}
		else
		{
			CallContextCurrentData.ClearCurrentData(null, removeContextData: false);
			if (_scopeThread != Thread.CurrentThread)
			{
				flag = false;
				ContextData.TLSCurrentData = null;
			}
			else
			{
				ContextData.TLSCurrentData = _threadContextData;
			}
		}
		if (flag)
		{
			_threadContextData.CurrentScope = _savedCurrentScope;
			RestoreCurrent();
		}
	}

	private void SetCurrent(Transaction newCurrent)
	{
		if (_dependentTransaction == null && _committableTransaction == null && newCurrent != null)
		{
			_dependentTransaction = newCurrent.DependentClone(DependentCloneOption.RollbackIfNotComplete);
		}
		switch (_interopOption)
		{
		case EnterpriseServicesInteropOption.None:
			_threadContextData.CurrentTransaction = newCurrent;
			break;
		case EnterpriseServicesInteropOption.Automatic:
			EnterpriseServices.VerifyEnterpriseServicesOk();
			if (false)
			{
			}
			_threadContextData.CurrentTransaction = newCurrent;
			break;
		case EnterpriseServicesInteropOption.Full:
			EnterpriseServices.VerifyEnterpriseServicesOk();
			EnterpriseServices.PushServiceDomain();
			break;
		}
	}

	private void SaveTLSContextData()
	{
		if (_savedTLSContextData == null)
		{
			_savedTLSContextData = new ContextData(asyncFlow: false);
		}
		_savedTLSContextData.CurrentScope = ContextData.TLSCurrentData.CurrentScope;
		_savedTLSContextData.CurrentTransaction = ContextData.TLSCurrentData.CurrentTransaction;
		_savedTLSContextData.DefaultComContextState = ContextData.TLSCurrentData.DefaultComContextState;
		_savedTLSContextData.WeakDefaultComContext = ContextData.TLSCurrentData.WeakDefaultComContext;
	}

	private void RestoreSavedTLSContextData()
	{
		if (_savedTLSContextData != null)
		{
			ContextData.TLSCurrentData.CurrentScope = _savedTLSContextData.CurrentScope;
			ContextData.TLSCurrentData.CurrentTransaction = _savedTLSContextData.CurrentTransaction;
			ContextData.TLSCurrentData.DefaultComContextState = _savedTLSContextData.DefaultComContextState;
			ContextData.TLSCurrentData.WeakDefaultComContext = _savedTLSContextData.WeakDefaultComContext;
		}
	}

	private void RestoreCurrent()
	{
		if (EnterpriseServices.CreatedServiceDomain)
		{
			EnterpriseServices.LeaveServiceDomain();
		}
		_threadContextData.CurrentTransaction = _contextTransaction;
	}

	private static void ValidateScopeTimeout(string paramName, TimeSpan scopeTimeout)
	{
		ArgumentOutOfRangeException.ThrowIfLessThan(scopeTimeout, TimeSpan.Zero, paramName);
	}

	private void ValidateAndSetAsyncFlowOption(TransactionScopeAsyncFlowOption asyncFlowOption)
	{
		switch (asyncFlowOption)
		{
		default:
			throw new ArgumentOutOfRangeException("asyncFlowOption");
		case TransactionScopeAsyncFlowOption.Enabled:
			AsyncFlowEnabled = true;
			break;
		case TransactionScopeAsyncFlowOption.Suppress:
			break;
		}
	}

	private void ValidateAsyncFlowOptionAndESInteropOption()
	{
		if (AsyncFlowEnabled)
		{
			EnterpriseServicesInteropOption enterpriseServicesInteropOption = _interopOption;
			if (!_interopModeSpecified)
			{
				enterpriseServicesInteropOption = Transaction.InteropMode(_savedCurrentScope);
			}
			if (enterpriseServicesInteropOption != EnterpriseServicesInteropOption.None)
			{
				throw new NotSupportedException("AsyncFlowAndESInteropNotSupported");
			}
		}
	}
}
