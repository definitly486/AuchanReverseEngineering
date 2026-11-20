using System.Runtime.CompilerServices;

namespace System.Transactions;

[Serializable]
[TypeForwardedFrom("System.Transactions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
public class TransactionAbortedException : TransactionException
{
	internal new static TransactionAbortedException Create(string message, Exception innerException, Guid distributedTxId)
	{
		string text = message;
		if (TransactionException.IncludeDistributedTxId(distributedTxId))
		{
			text = System.SR.Format("DistributedTxIDInTransactionException", text, distributedTxId);
		}
		return Create(text, innerException);
	}

	internal new static TransactionAbortedException Create(string message, Exception innerException)
	{
		TransactionsEtwProvider log = TransactionsEtwProvider.Log;
		if (log.IsEnabled())
		{
		}
		return new TransactionAbortedException(message, innerException);
	}

	public TransactionAbortedException(string? message, Exception? innerException)
		: base(message ?? "TransactionAborted", innerException)
	{
	}
}
