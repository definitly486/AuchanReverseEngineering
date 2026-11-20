namespace System.Transactions;

internal abstract class ActiveStates : TransactionState
{
	internal override TransactionStatus get_Status(InternalTransaction tx)
	{
		return TransactionStatus.Active;
	}
}
