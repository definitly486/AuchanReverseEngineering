using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal struct ClassLayoutTableReader
{
	internal int NumberOfRows;

	private readonly bool _IsTypeDefTableRowRefSizeSmall;

	private readonly int _PackagingSizeOffset;

	private readonly int _ClassSizeOffset;

	private readonly int _ParentOffset;

	internal readonly int RowSize;

	internal MemoryBlock Block;

	internal ClassLayoutTableReader(int numberOfRows, bool declaredSorted, int typeDefTableRowRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsTypeDefTableRowRefSizeSmall = typeDefTableRowRefSize == 2;
		_PackagingSizeOffset = 0;
		_ClassSizeOffset = _PackagingSizeOffset + 2;
		_ParentOffset = _ClassSizeOffset + 4;
		RowSize = _ParentOffset + typeDefTableRowRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
		if (!declaredSorted && !CheckSorted())
		{
			Throw.TableNotSorted(TableIndex.ClassLayout);
		}
	}

	private bool CheckSorted()
	{
		return Block.IsOrderedByReferenceAscending(RowSize, _ParentOffset, _IsTypeDefTableRowRefSizeSmall);
	}
}
