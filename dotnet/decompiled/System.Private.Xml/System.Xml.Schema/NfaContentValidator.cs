namespace System.Xml.Schema;

internal sealed class NfaContentValidator : ContentValidator
{
	private readonly BitSet _firstpos;

	private readonly BitSet[] _followpos;

	private readonly SymbolsDictionary _symbols;

	private readonly Positions _positions;

	private readonly int _endMarkerPos;

	internal NfaContentValidator(BitSet firstpos, BitSet[] followpos, SymbolsDictionary symbols, Positions positions, int endMarkerPos, XmlSchemaContentType contentType, bool isOpen, bool isEmptiable)
		: base(contentType, isOpen, isEmptiable)
	{
		_firstpos = firstpos;
		_followpos = followpos;
		_symbols = symbols;
		_positions = positions;
		_endMarkerPos = endMarkerPos;
	}
}
