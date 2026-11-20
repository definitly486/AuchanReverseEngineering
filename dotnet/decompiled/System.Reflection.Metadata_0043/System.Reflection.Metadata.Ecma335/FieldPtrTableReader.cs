using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct FieldPtrTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsFieldTableRowRefSizeSmall;

	private readonly int _FieldOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal FieldPtrTableReader(int numberOfRows, int fieldTableRowRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsFieldTableRowRefSizeSmall = fieldTableRowRefSize == 2;
		_FieldOffset = 0;
		RowSize = _FieldOffset + fieldTableRowRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
	}
}
