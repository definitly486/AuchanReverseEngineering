using System.Formats.Asn1;
using System.Security.Cryptography.X509Certificates.Asn1;

namespace System.Security.Cryptography.X509Certificates;

public sealed class X509KeyUsageExtension : X509Extension
{
	private bool _decoded;

	private X509KeyUsageFlags _keyUsages;

	public X509KeyUsageFlags KeyUsages
	{
		get
		{
			if (!_decoded)
			{
				DecodeX509KeyUsageExtension(base.RawData, out _keyUsages);
				_decoded = true;
			}
			return _keyUsages;
		}
	}

	public X509KeyUsageExtension()
		: base(Oids.KeyUsageOid)
	{
		_decoded = true;
	}

	public override void CopyFrom(AsnEncodedData asnEncodedData)
	{
		base.CopyFrom(asnEncodedData);
		_decoded = false;
	}

	internal static void DecodeX509KeyUsageExtension(ReadOnlySpan<byte> encoded, out X509KeyUsageFlags keyUsages)
	{
		KeyUsageFlagsAsn keyUsageFlagsAsn;
		try
		{
			AsnValueReader asnValueReader = new AsnValueReader(encoded, AsnEncodingRules.BER);
			keyUsageFlagsAsn = asnValueReader.ReadNamedBitListValue<KeyUsageFlagsAsn>();
			asnValueReader.ThrowIfNotEmpty();
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
		keyUsages = (X509KeyUsageFlags)(ReverseBitOrder((byte)keyUsageFlagsAsn) | (ReverseBitOrder((byte)((ushort)keyUsageFlagsAsn >> 8)) << 8));
	}

	private static byte ReverseBitOrder(byte b)
	{
		return (byte)((ulong)((b * 8623620610L) & 0x10884422010L) % 1023uL);
	}
}
