namespace System.Transactions.Oletx;

internal sealed class OletxTransactionManager
{
	internal OletxTransactionManager(string nodeName)
	{
	}

	internal OletxCommittableTransaction CreateTransaction(TransactionOptions options)
	{
		throw NotSupported();
	}

	internal static Exception NotSupported()
	{
		return new PlatformNotSupportedException("DistributedNotSupported");
	}
}
