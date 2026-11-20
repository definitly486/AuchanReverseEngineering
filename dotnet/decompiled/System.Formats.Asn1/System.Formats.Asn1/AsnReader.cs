namespace System.Formats.Asn1;

public class AsnReader
{
	private ReadOnlyMemory<byte> _data;

	private readonly AsnReaderOptions _options;

	public AsnEncodingRules RuleSet { get; }

	public bool HasData => !_data.IsEmpty;

	public AsnReader(ReadOnlyMemory<byte> data, AsnEncodingRules ruleSet, AsnReaderOptions options = default(AsnReaderOptions))
	{
		AsnDecoder.CheckEncodingRules(ruleSet);
		_data = data;
		RuleSet = ruleSet;
		_options = options;
	}

	public void ThrowIfNotEmpty()
	{
		if (HasData)
		{
			throw new AsnContentException("ContentException_TooMuchData");
		}
	}

	public Asn1Tag PeekTag()
	{
		int bytesConsumed;
		return Asn1Tag.Decode(_data.Span, out bytesConsumed);
	}

	public ReadOnlyMemory<byte> PeekEncodedValue()
	{
		AsnDecoder.ReadEncodedValue(_data.Span, RuleSet, out var _, out var _, out var bytesConsumed);
		return _data.Slice(0, bytesConsumed);
	}

	public ReadOnlyMemory<byte> ReadEncodedValue()
	{
		ReadOnlyMemory<byte> result = PeekEncodedValue();
		_data = _data.Slice(result.Length);
		return result;
	}

	private AsnReader CloneAtSlice(int start, int length)
	{
		return new AsnReader(_data.Slice(start, length), RuleSet, _options);
	}

	public ReadOnlyMemory<byte> ReadIntegerBytes(Asn1Tag? expectedTag = null)
	{
		int bytesConsumed;
		ReadOnlySpan<byte> smaller = AsnDecoder.ReadIntegerBytes(_data.Span, RuleSet, out bytesConsumed, expectedTag);
		ReadOnlyMemory<byte> result = AsnDecoder.Slice(_data, smaller);
		_data = _data.Slice(bytesConsumed);
		return result;
	}

	public bool TryReadInt32(out int value, Asn1Tag? expectedTag = null)
	{
		int bytesConsumed;
		bool result = AsnDecoder.TryReadInt32(_data.Span, RuleSet, out value, out bytesConsumed, expectedTag);
		_data = _data.Slice(bytesConsumed);
		return result;
	}

	public bool TryReadPrimitiveOctetString(out ReadOnlyMemory<byte> contents, Asn1Tag? expectedTag = null)
	{
		ReadOnlySpan<byte> value;
		int bytesConsumed;
		bool num = AsnDecoder.TryReadPrimitiveOctetString(_data.Span, RuleSet, out value, out bytesConsumed, expectedTag);
		if (num)
		{
			contents = AsnDecoder.Slice(_data, value);
			_data = _data.Slice(bytesConsumed);
			return num;
		}
		contents = default(ReadOnlyMemory<byte>);
		return num;
	}

	public string ReadObjectIdentifier(Asn1Tag? expectedTag = null)
	{
		int bytesConsumed;
		string result = AsnDecoder.ReadObjectIdentifier(_data.Span, RuleSet, out bytesConsumed, expectedTag);
		_data = _data.Slice(bytesConsumed);
		return result;
	}

	public AsnReader ReadSequence(Asn1Tag? expectedTag = null)
	{
		AsnDecoder.ReadSequence(_data.Span, RuleSet, out var contentOffset, out var contentLength, out var bytesConsumed, expectedTag);
		AsnReader result = CloneAtSlice(contentOffset, contentLength);
		_data = _data.Slice(bytesConsumed);
		return result;
	}

	public AsnReader ReadSetOf(Asn1Tag? expectedTag = null)
	{
		return ReadSetOf(_options.SkipSetSortOrderVerification, expectedTag);
	}

	public AsnReader ReadSetOf(bool skipSortOrderValidation, Asn1Tag? expectedTag = null)
	{
		AsnDecoder.ReadSetOf(_data.Span, RuleSet, out var contentOffset, out var contentLength, out var bytesConsumed, skipSortOrderValidation, expectedTag);
		AsnReader result = CloneAtSlice(contentOffset, contentLength);
		_data = _data.Slice(bytesConsumed);
		return result;
	}

	public string ReadCharacterString(UniversalTagNumber encodingType, Asn1Tag? expectedTag = null)
	{
		int bytesConsumed;
		string result = AsnDecoder.ReadCharacterString(_data.Span, RuleSet, encodingType, out bytesConsumed, expectedTag);
		_data = _data.Slice(bytesConsumed);
		return result;
	}
}
