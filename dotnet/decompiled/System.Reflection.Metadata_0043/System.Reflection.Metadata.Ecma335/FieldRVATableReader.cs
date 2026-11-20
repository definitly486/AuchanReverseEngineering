using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct FieldRVATableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsFieldTableRowRefSizeSmall;

	private readonly int _RvaOffset;

	private readonly int _FieldOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal FieldRVATableReader(int numberOfRows, bool declaredSorted, int fieldTableRowRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsFieldTableRowRefSizeSmall = fieldTableRowRefSize == 2;
		_RvaOffset = 0;
		_FieldOffset = _RvaOffset + 4;
		RowSize = _FieldOffset + fieldTableRowRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
		if (!declaredSorted && !CheckSorted())
		{
			Throw.TableNotSorted(TableIndex.FieldRva);
		}
	}

	private bool CheckSorted()
	{
		return Block.IsOrderedByReferenceAscending(RowSize, _FieldOffset, _IsFieldTableRowRefSizeSmall);
	}
}
