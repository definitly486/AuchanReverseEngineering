namespace System.Transactions;

internal abstract class VolatileDemultiplexer
{
	protected InternalTransaction _transaction;

	internal IPromotedEnlistment _promotedEnlistment;

	public VolatileDemultiplexer(InternalTransaction transaction)
	{
		_transaction = transaction;
	}
}
