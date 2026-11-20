using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct FieldLayoutTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsFieldTableRowRefSizeSmall;

	private readonly int _OffsetOffset;

	private readonly int _FieldOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal FieldLayoutTableReader(int numberOfRows, bool declaredSorted, int fieldTableRowRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsFieldTableRowRefSizeSmall = fieldTableRowRefSize == 2;
		_OffsetOffset = 0;
		_FieldOffset = _OffsetOffset + 4;
		RowSize = _FieldOffset + fieldTableRowRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
		if (!declaredSorted && !CheckSorted())
		{
			Throw.TableNotSorted(TableIndex.FieldLayout);
		}
	}

	private bool CheckSorted()
	{
		return Block.IsOrderedByReferenceAscending(RowSize, _FieldOffset, _IsFieldTableRowRefSizeSmall);
	}
}
