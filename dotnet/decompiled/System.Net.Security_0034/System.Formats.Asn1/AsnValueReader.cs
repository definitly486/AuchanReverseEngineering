namespace System.Formats.Asn1;

internal ref struct AsnValueReader
{
	private static readonly byte[] s_singleByte = new byte[1];

	private ReadOnlySpan<byte> _span;

	private readonly AsnEncodingRules _ruleSet;

	internal bool HasData => !_span.IsEmpty;

	internal AsnValueReader(ReadOnlySpan<byte> span, AsnEncodingRules ruleSet)
	{
		_span = span;
		_ruleSet = ruleSet;
	}

	internal void ThrowIfNotEmpty()
	{
		if (!_span.IsEmpty)
		{
			new AsnReader(s_singleByte, _ruleSet).ThrowIfNotEmpty();
		}
	}

	internal Asn1Tag PeekTag()
	{
		int bytesConsumed;
		return Asn1Tag.Decode(_span, out bytesConsumed);
	}

	internal byte[] ReadOctetString(Asn1Tag? expectedTag = null)
	{
		int bytesConsumed;
		byte[] result = AsnDecoder.ReadOctetString(_span, _ruleSet, out bytesConsumed, expectedTag);
		_span = _span.Slice(bytesConsumed);
		return result;
	}

	internal string ReadObjectIdentifier(Asn1Tag? expectedTag = null)
	{
		int bytesConsumed;
		string result = AsnDecoder.ReadObjectIdentifier(_span, _ruleSet, out bytesConsumed, expectedTag);
		_span = _span.Slice(bytesConsumed);
		return result;
	}

	internal System.Formats.Asn1.AsnValueReader ReadSequence(Asn1Tag? expectedTag = null)
	{
		AsnDecoder.ReadSequence(_span, _ruleSet, out var contentOffset, out var contentLength, out var bytesConsumed, expectedTag);
		ReadOnlySpan<byte> span = _span.Slice(contentOffset, contentLength);
		_span = _span.Slice(bytesConsumed);
		return new System.Formats.Asn1.AsnValueReader(span, _ruleSet);
	}

	internal TEnum ReadEnumeratedValue<TEnum>(Asn1Tag? expectedTag = null) where TEnum : Enum
	{
		int bytesConsumed;
		TEnum result = AsnDecoder.ReadEnumeratedValue<TEnum>(_span, _ruleSet, out bytesConsumed, expectedTag);
		_span = _span.Slice(bytesConsumed);
		return result;
	}
}
