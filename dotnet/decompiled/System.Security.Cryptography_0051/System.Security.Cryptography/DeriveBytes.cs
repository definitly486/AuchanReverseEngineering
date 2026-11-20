namespace System.Security.Cryptography;

public abstract class DeriveBytes : IDisposable
{
	public abstract byte[] GetBytes(int cb);

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
	}
}
