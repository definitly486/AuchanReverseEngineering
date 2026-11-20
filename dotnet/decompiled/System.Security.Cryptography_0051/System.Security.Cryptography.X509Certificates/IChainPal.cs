namespace System.Security.Cryptography.X509Certificates;

internal interface IChainPal : IDisposable
{
	X509ChainElement[] ChainElements { get; }

	X509ChainStatus[] ChainStatus { get; }

	bool? Verify(X509VerificationFlags flags, out Exception exception);
}
