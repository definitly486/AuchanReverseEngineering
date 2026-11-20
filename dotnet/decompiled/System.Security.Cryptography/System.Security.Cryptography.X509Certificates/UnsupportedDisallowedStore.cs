namespace System.Security.Cryptography.X509Certificates;

internal sealed class UnsupportedDisallowedStore : IStorePal, IDisposable
{
	private readonly bool _readOnly;

	internal UnsupportedDisallowedStore(OpenFlags openFlags)
	{
		if ((openFlags & (OpenFlags.ReadWrite | OpenFlags.MaxAllowed)) == 0)
		{
			_readOnly = true;
		}
	}

	public void Dispose()
	{
	}

	public void CloneTo(X509Certificate2Collection collection)
	{
	}
}
