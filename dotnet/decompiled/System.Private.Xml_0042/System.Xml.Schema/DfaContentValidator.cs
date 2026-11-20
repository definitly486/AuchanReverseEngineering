namespace System.Xml.Schema;

internal sealed class DfaContentValidator : ContentValidator
{
	private readonly int[][] _transitionTable;

	private readonly SymbolsDictionary _symbols;

	internal DfaContentValidator(int[][] transitionTable, SymbolsDictionary symbols, XmlSchemaContentType contentType, bool isOpen, bool isEmptiable)
		: base(contentType, isOpen, isEmptiable)
	{
		_transitionTable = transitionTable;
		_symbols = symbols;
	}
}
