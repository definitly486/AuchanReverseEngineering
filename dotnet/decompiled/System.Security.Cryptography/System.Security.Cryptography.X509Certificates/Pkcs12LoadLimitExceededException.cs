namespace System.Security.Cryptography.X509Certificates;

public sealed class Pkcs12LoadLimitExceededException : CryptographicException
{
	public Pkcs12LoadLimitExceededException(string propertyName)
		: base(System.SR.Format("Cryptography_X509_PKCS12_LimitExceeded", propertyName))
	{
	}
}
