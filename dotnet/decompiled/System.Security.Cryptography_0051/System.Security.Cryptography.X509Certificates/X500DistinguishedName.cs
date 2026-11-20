namespace System.Security.Cryptography.X509Certificates;

public sealed class X500DistinguishedName : AsnEncodedData
{
	private volatile string _lazyDistinguishedName;

	public string Name => _lazyDistinguishedName ?? (_lazyDistinguishedName = Decode(X500DistinguishedNameFlags.Reversed));

	public X500DistinguishedName(ReadOnlySpan<byte> encodedDistinguishedName)
		: base(new Oid(null, null), encodedDistinguishedName)
	{
	}

	public string Decode(X500DistinguishedNameFlags flag)
	{
		ThrowIfInvalid(flag);
		return X509Pal.Instance.X500DistinguishedNameDecode(base.RawData, flag);
	}

	public override string Format(bool multiLine)
	{
		return X509Pal.Instance.X500DistinguishedNameFormat(base.RawData, multiLine);
	}

	private static void ThrowIfInvalid(X500DistinguishedNameFlags flags)
	{
		uint num = 29169u;
		if (((uint)flags & ~num) != 0)
		{
			throw new ArgumentException(System.SR.Format("Arg_EnumIllegalVal", "flag"));
		}
	}
}
