namespace System.Security.Cryptography.X509Certificates;

internal abstract class Pkcs12Key : IDisposable
{
	internal abstract IDisposable Key { get; }

	internal abstract bool TryExportSubjectPublicKeyInfo(Span<byte> destination, out int bytesWritten);

	public void Dispose()
	{
		Key.Dispose();
	}
}
