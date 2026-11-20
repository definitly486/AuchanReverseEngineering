namespace System.Security.Cryptography.X509Certificates;

public sealed class PublicKey
{
	private readonly Oid _oid;

	public AsnEncodedData EncodedKeyValue { get; }

	public AsnEncodedData? EncodedParameters { get; }

	public Oid Oid => _oid;

	internal PublicKey(Oid oid, AsnEncodedData parameters, AsnEncodedData keyValue, bool skipCopy)
	{
		_oid = oid;
		if (skipCopy)
		{
			EncodedParameters = parameters;
			EncodedKeyValue = keyValue;
		}
		else
		{
			EncodedParameters = ((parameters == null) ? null : new AsnEncodedData(parameters));
			EncodedKeyValue = new AsnEncodedData(keyValue);
		}
	}
}
