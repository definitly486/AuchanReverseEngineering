using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct PropertyPtrTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsPropertyTableRowRefSizeSmall;

	private readonly int _PropertyOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal PropertyPtrTableReader(int numberOfRows, int propertyTableRowRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsPropertyTableRowRefSizeSmall = propertyTableRowRefSize == 2;
		_PropertyOffset = 0;
		RowSize = _PropertyOffset + propertyTableRowRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
	}
}
