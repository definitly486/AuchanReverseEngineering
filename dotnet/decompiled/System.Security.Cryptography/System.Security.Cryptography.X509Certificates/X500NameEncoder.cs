using System.Buffers;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Text;

namespace System.Security.Cryptography.X509Certificates;

internal static class X500NameEncoder
{
	private enum EncodingRules
	{
		Unknown,
		IA5String,
		DirectoryString,
		PrintableString,
		UTF8String,
		NumericString
	}

	private static readonly SearchValues<char> s_needsQuotingChars = SearchValues.Create(",+=\"\n<>#;".AsSpan());

	private static readonly Lazy<Dictionary<string, EncodingRules>> s_lazyEncodingRulesLookup = new Lazy<Dictionary<string, EncodingRules>>(CreateEncodingRulesLookup);

	internal static string X500DistinguishedNameDecode(byte[] encodedName, bool printOid, X500DistinguishedNameFlags flags, bool addTrailingDelimiter = false)
	{
		bool reverse = (flags & X500DistinguishedNameFlags.Reversed) == X500DistinguishedNameFlags.Reversed;
		bool quoteIfNeeded = (flags & X500DistinguishedNameFlags.DoNotUseQuotes) != X500DistinguishedNameFlags.DoNotUseQuotes;
		bool num = (flags & X500DistinguishedNameFlags.DoNotUsePlusSign) != X500DistinguishedNameFlags.DoNotUsePlusSign;
		string dnSeparator = (((flags & X500DistinguishedNameFlags.UseSemicolons) == X500DistinguishedNameFlags.UseSemicolons) ? "; " : (((flags & (X500DistinguishedNameFlags.UseCommas | X500DistinguishedNameFlags.UseNewLines)) != X500DistinguishedNameFlags.UseNewLines) ? ", " : "\n"));
		string multiValueSeparator = (num ? " + " : " ");
		try
		{
			return X500DistinguishedNameDecode(encodedName, printOid, reverse, quoteIfNeeded, dnSeparator, multiValueSeparator, addTrailingDelimiter);
		}
		catch (CryptographicException)
		{
			return "";
		}
	}

	private static bool NeedsQuoting(ReadOnlySpan<char> rdnValue)
	{
		if (!rdnValue.IsEmpty && !IsQuotableWhitespace(rdnValue[0]))
		{
			if (!IsQuotableWhitespace(rdnValue[rdnValue.Length - 1]))
			{
				return rdnValue.ContainsAny(s_needsQuotingChars);
			}
		}
		return true;
	}

	private static bool IsQuotableWhitespace(char c)
	{
		if (c != ' ')
		{
			if (c >= '\t')
			{
				return c <= '\r';
			}
			return false;
		}
		return true;
	}

	private static void AppendOid(ref System.Text.ValueStringBuilder decodedName, string oidValue)
	{
		Oid oid = new Oid(oidValue);
		if (StringComparer.Ordinal.Equals(oid.FriendlyName, oidValue) || string.IsNullOrEmpty(oid.FriendlyName))
		{
			decodedName.Append("OID.");
			decodedName.Append(oid.Value);
		}
		else
		{
			decodedName.Append(oid.FriendlyName);
		}
		decodedName.Append('=');
	}

	private static Dictionary<string, EncodingRules> CreateEncodingRulesLookup()
	{
		return new Dictionary<string, EncodingRules>(43, StringComparer.Ordinal)
		{
			{
				"2.5.4.2",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.3",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.4",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.5",
				EncodingRules.PrintableString
			},
			{
				"2.5.4.6",
				EncodingRules.PrintableString
			},
			{
				"2.5.4.7",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.8",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.9",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.10",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.11",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.12",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.13",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.15",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.17",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.18",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.19",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.20",
				EncodingRules.PrintableString
			},
			{
				"2.5.4.24",
				EncodingRules.NumericString
			},
			{
				"2.5.4.25",
				EncodingRules.NumericString
			},
			{
				"2.5.4.27",
				EncodingRules.PrintableString
			},
			{
				"2.5.4.41",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.42",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.43",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.44",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.46",
				EncodingRules.PrintableString
			},
			{
				"2.5.4.51",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.54",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.65",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.80",
				EncodingRules.UTF8String
			},
			{
				"2.5.4.81",
				EncodingRules.UTF8String
			},
			{
				"2.5.4.83",
				EncodingRules.UTF8String
			},
			{
				"2.5.4.86",
				EncodingRules.UTF8String
			},
			{
				"2.5.4.87",
				EncodingRules.UTF8String
			},
			{
				"2.5.4.89",
				EncodingRules.PrintableString
			},
			{
				"2.5.4.94",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.95",
				EncodingRules.UTF8String
			},
			{
				"2.5.4.97",
				EncodingRules.DirectoryString
			},
			{
				"2.5.4.98",
				EncodingRules.PrintableString
			},
			{
				"2.5.4.99",
				EncodingRules.NumericString
			},
			{
				"2.5.4.100",
				EncodingRules.UTF8String
			},
			{
				"2.5.4.104",
				EncodingRules.UTF8String
			},
			{
				"2.5.4.105",
				EncodingRules.UTF8String
			},
			{
				"1.2.840.113549.1.9.1",
				EncodingRules.IA5String
			}
		};
	}

	private static string X500DistinguishedNameDecode(byte[] encodedName, bool printOid, bool reverse, bool quoteIfNeeded, string dnSeparator, string multiValueSeparator, bool addTrailingDelimiter)
	{
		try
		{
			AsnReader asnReader = new AsnReader(encodedName, AsnEncodingRules.DER);
			AsnReader asnReader2 = asnReader.ReadSequence();
			List<AsnReader> list = new List<AsnReader>();
			asnReader.ThrowIfNotEmpty();
			while (asnReader2.HasData)
			{
				list.Add(asnReader2.ReadSetOf(skipSortOrderValidation: true));
			}
			Span<char> initialBuffer = stackalloc char[512];
			System.Text.ValueStringBuilder decodedName = new System.Text.ValueStringBuilder(initialBuffer);
			int count = list.Count;
			bool flag = false;
			for (int i = 0; i < count; i++)
			{
				int index = (reverse ? (count - i - 1) : i);
				if (flag)
				{
					decodedName.Append(dnSeparator);
				}
				else
				{
					flag = true;
				}
				AsnReader asnReader3 = list[index];
				bool flag2 = false;
				while (asnReader3.HasData)
				{
					AsnReader asnReader4 = asnReader3.ReadSequence();
					string oidValue = asnReader4.ReadObjectIdentifier();
					bool binaryFallback;
					string text = ReadAttributeValue(asnReader4, out binaryFallback);
					asnReader4.ThrowIfNotEmpty();
					if (flag2)
					{
						decodedName.Append(multiValueSeparator);
					}
					else
					{
						flag2 = true;
					}
					if (printOid)
					{
						AppendOid(ref decodedName, oidValue);
					}
					int num;
					if (quoteIfNeeded && NeedsQuoting(text.AsSpan()))
					{
						num = ((!binaryFallback) ? 1 : 0);
						if (num != 0)
						{
							decodedName.Append('"');
							text = text.Replace("\"", "\"\"");
						}
					}
					else
					{
						num = 0;
					}
					decodedName.Append(text);
					if (num != 0)
					{
						decodedName.Append('"');
					}
				}
			}
			if (addTrailingDelimiter && decodedName.Length > 0)
			{
				decodedName.Append(dnSeparator);
			}
			string result = decodedName.ToString();
			decodedName.Dispose();
			return result;
		}
		catch (AsnContentException inner)
		{
			throw new CryptographicException("Cryptography_Der_Invalid_Encoding", inner);
		}
	}

	private static string ReadAttributeValue(AsnReader tavReader, out bool binaryFallback)
	{
		Asn1Tag asn1Tag = tavReader.PeekTag();
		if (asn1Tag.TagClass == TagClass.Universal)
		{
			switch ((UniversalTagNumber)asn1Tag.TagValue)
			{
			case UniversalTagNumber.UTF8String:
			case UniversalTagNumber.NumericString:
			case UniversalTagNumber.PrintableString:
			case UniversalTagNumber.TeletexString:
			case UniversalTagNumber.IA5String:
			case UniversalTagNumber.BMPString:
				binaryFallback = false;
				return tavReader.ReadCharacterString((UniversalTagNumber)asn1Tag.TagValue).TrimEnd('\0');
			case UniversalTagNumber.OctetString:
			{
				if (tavReader.TryReadPrimitiveOctetString(out var contents))
				{
					binaryFallback = true;
					return BinaryEncode(contents);
				}
				throw new CryptographicException("Cryptography_Der_Invalid_Encoding");
			}
			}
		}
		binaryFallback = true;
		return BinaryEncode(tavReader.ReadEncodedValue());
		static string BinaryEncode(ReadOnlyMemory<byte> data)
		{
			return string.Create(1 + data.Length * 2, data, delegate(Span<char> buff, ReadOnlyMemory<byte> state)
			{
				buff[0] = '#';
				System.HexConverter.EncodeToUtf16(state.Span, buff.Slice(1));
			});
		}
	}
}
