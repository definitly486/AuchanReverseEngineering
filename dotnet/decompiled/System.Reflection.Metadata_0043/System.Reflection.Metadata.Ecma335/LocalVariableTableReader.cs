using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct LocalVariableTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _isStringHeapRefSizeSmall;

	private readonly int _attributesOffset;

	private readonly int _indexOffset;

	private readonly int _nameOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal LocalVariableTableReader(int numberOfRows, int stringHeapRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_isStringHeapRefSizeSmall = stringHeapRefSize == 2;
		_attributesOffset = 0;
		_indexOffset = _attributesOffset + 2;
		_nameOffset = _indexOffset + 2;
		RowSize = _nameOffset + stringHeapRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
	}
}
