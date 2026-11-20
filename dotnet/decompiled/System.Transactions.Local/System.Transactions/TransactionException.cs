using System.Runtime.CompilerServices;
using System.Transactions.Configuration;

namespace System.Transactions;

[Serializable]
[TypeForwardedFrom("System.Transactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class TransactionException : SystemException
{
	internal static bool IncludeDistributedTxId(Guid distributedTxId)
	{
		if (distributedTxId != Guid.Empty)
		{
			return AppSettings.IncludeDistributedTxIdInExceptionMessage;
		}
		return false;
	}

	internal static TransactionException Create(string message, Exception innerException)
	{
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		return new TransactionException(message, innerException);
	}

	internal static Exception CreateInvalidOperationException(TraceSourceType traceSource, string message, Exception innerException)
	{
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		return new InvalidOperationException(message, innerException);
	}

	public TransactionException(string? message, Exception? innerException)
		: base(message, innerException)
	{
	}

	internal static TransactionException Create(string message, Exception innerException, Guid distributedTxId)
	{
		string text = message;
		if (IncludeDistributedTxId(distributedTxId))
		{
			text = System.SR.Format("DistributedTxIDInTransactionException", text, distributedTxId);
		}
		return Create(text, innerException);
	}

	internal static TransactionException CreateTransactionStateException(Exception innerException, Guid distributedTxId)
	{
		return Create("TransactionStateException", innerException, distributedTxId);
	}

	internal static Exception CreateTransactionCompletedException(Guid distributedTxId)
	{
		string text = "TransactionAlreadyCompleted";
		if (IncludeDistributedTxId(distributedTxId))
		{
			text = System.SR.Format("DistributedTxIDInTransactionException", text, distributedTxId);
		}
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		return new InvalidOperationException(text);
	}

	internal static Exception CreateInvalidOperationException(TraceSourceType traceSource, string message, Exception innerException, Guid distributedTxId)
	{
		string text = message;
		if (IncludeDistributedTxId(distributedTxId))
		{
			text = System.SR.Format("DistributedTxIDInTransactionException", text, distributedTxId);
		}
		return CreateInvalidOperationException(traceSource, text, innerException);
	}
}
