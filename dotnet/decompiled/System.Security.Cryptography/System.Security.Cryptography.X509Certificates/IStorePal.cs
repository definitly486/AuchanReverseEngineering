namespace System.Security.Cryptography.X509Certificates;

internal interface IStorePal : IDisposable
{
	void CloneTo(X509Certificate2Collection collection);
}
