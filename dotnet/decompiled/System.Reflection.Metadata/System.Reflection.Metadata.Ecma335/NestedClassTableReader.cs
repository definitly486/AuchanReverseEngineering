using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct NestedClassTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsTypeDefTableRowRefSizeSmall;

	private readonly int _NestedClassOffset;

	private readonly int _EnclosingClassOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal NestedClassTableReader(int numberOfRows, bool declaredSorted, int typeDefTableRowRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsTypeDefTableRowRefSizeSmall = typeDefTableRowRefSize == 2;
		_NestedClassOffset = 0;
		_EnclosingClassOffset = _NestedClassOffset + typeDefTableRowRefSize;
		RowSize = _EnclosingClassOffset + typeDefTableRowRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
		if (!declaredSorted && !CheckSorted())
		{
			Throw.TableNotSorted(TableIndex.NestedClass);
		}
	}

	private bool CheckSorted()
	{
		return Block.IsOrderedByReferenceAscending(RowSize, _NestedClassOffset, _IsTypeDefTableRowRefSizeSmall);
	}
}
