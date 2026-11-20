using System.Formats.Asn1;
using System.Security.Cryptography.Asn1;
using System.Text;

namespace System.Security.Cryptography;

internal sealed class ManagedAsnFormatter : AsnFormatter
{
	protected override string FormatNative(Oid oid, byte[] rawData, bool multiLine)
	{
		if (oid == null || string.IsNullOrEmpty(oid.Value))
		{
			return AsnFormatter.EncodeSpaceSeparatedHexString(rawData);
		}
		if (oid.Value == "2.5.29.17")
		{
			return FormatSubjectAlternativeName(rawData);
		}
		return null;
	}

	private static string FormatSubjectAlternativeName(byte[] rawData)
	{
		try
		{
			StringBuilder stringBuilder = new StringBuilder();
			AsnValueReader asnValueReader = new AsnValueReader(rawData, AsnEncodingRules.DER);
			AsnValueReader reader = asnValueReader.ReadSequence();
			asnValueReader.ThrowIfNotEmpty();
			while (reader.HasData)
			{
				GeneralNameAsn.Decode(ref reader, rawData, out var decoded);
				if (stringBuilder.Length != 0)
				{
					stringBuilder.Append(", ");
				}
				if (decoded.OtherName.HasValue)
				{
					stringBuilder.Append("othername:<unsupported>");
				}
				else if (decoded.Rfc822Name != null)
				{
					stringBuilder.Append("email:");
					stringBuilder.Append(decoded.Rfc822Name);
				}
				else if (decoded.DnsName != null)
				{
					stringBuilder.Append("DNS:");
					stringBuilder.Append(decoded.DnsName);
				}
				else if (decoded.X400Address.HasValue)
				{
					stringBuilder.Append("X400Name:<unsupported>");
				}
				else if (decoded.DirectoryName.HasValue)
				{
					stringBuilder.Append("DirName:<unsupported>");
				}
				else if (decoded.EdiPartyName.HasValue)
				{
					stringBuilder.Append("EdiPartyName:<unsupported>");
				}
				else if (decoded.Uri != null)
				{
					stringBuilder.Append("URI:");
					stringBuilder.Append(decoded.Uri);
				}
				else if (decoded.IPAddress.HasValue)
				{
					ReadOnlySpan<byte> span = decoded.IPAddress.Value.Span;
					stringBuilder.Append("IP Address");
					if (span.Length == 4)
					{
						StringBuilder stringBuilder2 = stringBuilder;
						StringBuilder stringBuilder3 = stringBuilder2;
						StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(4, 4, stringBuilder2);
						handler.AppendLiteral(":");
						handler.AppendFormatted(span[0]);
						handler.AppendLiteral(".");
						handler.AppendFormatted(span[1]);
						handler.AppendLiteral(".");
						handler.AppendFormatted(span[2]);
						handler.AppendLiteral(".");
						handler.AppendFormatted(span[3]);
						stringBuilder3.Append(ref handler);
					}
					else if (span.Length == 16)
					{
						for (int i = 0; i < span.Length; i += 2)
						{
							StringBuilder stringBuilder2 = stringBuilder;
							StringBuilder stringBuilder4 = stringBuilder2;
							StringBuilder.AppendInterpolatedStringHandler handler = new StringBuilder.AppendInterpolatedStringHandler(1, 1, stringBuilder2);
							handler.AppendLiteral(":");
							handler.AppendFormatted((span[i] << 8) | span[i + 1], "X");
							stringBuilder4.Append(ref handler);
						}
					}
					else
					{
						stringBuilder.Append(":<invalid>");
					}
				}
				else
				{
					if (decoded.RegisteredId == null)
					{
						return null;
					}
					stringBuilder.Append("Registered ID:");
					stringBuilder.Append(decoded.RegisteredId);
				}
			}
			return stringBuilder.ToString();
		}
		catch (AsnContentException)
		{
			return null;
		}
	}
}
