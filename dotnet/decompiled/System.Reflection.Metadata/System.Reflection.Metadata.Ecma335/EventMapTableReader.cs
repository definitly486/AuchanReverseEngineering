using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct EventMapTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsTypeDefTableRowRefSizeSmall;

	private readonly bool _IsEventRefSizeSmall;

	private readonly int _ParentOffset;

	private readonly int _EventListOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal EventMapTableReader(int numberOfRows, int typeDefTableRowRefSize, int eventRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsTypeDefTableRowRefSizeSmall = typeDefTableRowRefSize == 2;
		_IsEventRefSizeSmall = eventRefSize == 2;
		_ParentOffset = 0;
		_EventListOffset = _ParentOffset + typeDefTableRowRefSize;
		RowSize = _EventListOffset + eventRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
	}
}
