namespace System.Xml.Schema;

internal sealed class RangeContentValidator : ContentValidator
{
	private readonly BitSet _firstpos;

	private readonly BitSet[] _followpos;

	private readonly BitSet _positionsWithRangeTerminals;

	private readonly SymbolsDictionary _symbols;

	private readonly Positions _positions;

	private readonly int _minMaxNodesCount;

	private readonly int _endMarkerPos;

	internal RangeContentValidator(BitSet firstpos, BitSet[] followpos, SymbolsDictionary symbols, Positions positions, int endMarkerPos, XmlSchemaContentType contentType, bool isEmptiable, BitSet positionsWithRangeTerminals, int minmaxNodesCount)
		: base(contentType, isOpen: false, isEmptiable)
	{
		_firstpos = firstpos;
		_followpos = followpos;
		_symbols = symbols;
		_positions = positions;
		_positionsWithRangeTerminals = positionsWithRangeTerminals;
		_minMaxNodesCount = minmaxNodesCount;
		_endMarkerPos = endMarkerPos;
	}
}
