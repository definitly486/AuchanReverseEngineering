using Internal.Cryptography;

namespace System.Security.Cryptography;

internal sealed class CryptographicAttributeObject
{
	private readonly Oid _oid;

	public Oid Oid => _oid.CopyOid();

	public AsnEncodedDataCollection Values { get; }

	public CryptographicAttributeObject(Oid oid, AsnEncodedDataCollection values)
	{
		_oid = oid.CopyOid();
		if (values == null)
		{
			Values = new AsnEncodedDataCollection();
			return;
		}
		AsnEncodedDataEnumerator enumerator = values.GetEnumerator();
		while (enumerator.MoveNext())
		{
			AsnEncodedData current = enumerator.Current;
			if (current.Oid == null)
			{
				throw new ArgumentException("Argument_InvalidOidValue", "values");
			}
			if (!string.Equals(current.Oid.Value, oid.Value, StringComparison.Ordinal))
			{
				throw new InvalidOperationException(System.SR.Format("InvalidOperation_WrongOidInAsnCollection", oid.Value, current.Oid.Value));
			}
		}
		Values = values;
	}
}
