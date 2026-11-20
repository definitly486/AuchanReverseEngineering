using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct InterfaceImplTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsTypeDefTableRowRefSizeSmall;

	private readonly bool _IsTypeDefOrRefRefSizeSmall;

	private readonly int _ClassOffset;

	private readonly int _InterfaceOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal InterfaceImplTableReader(int numberOfRows, bool declaredSorted, int typeDefTableRowRefSize, int typeDefOrRefRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsTypeDefTableRowRefSizeSmall = typeDefTableRowRefSize == 2;
		_IsTypeDefOrRefRefSizeSmall = typeDefOrRefRefSize == 2;
		_ClassOffset = 0;
		_InterfaceOffset = _ClassOffset + typeDefTableRowRefSize;
		RowSize = _InterfaceOffset + typeDefOrRefRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
		if (!declaredSorted && !CheckSorted())
		{
			Throw.TableNotSorted(TableIndex.InterfaceImpl);
		}
	}

	private bool CheckSorted()
	{
		return Block.IsOrderedByReferenceAscending(RowSize, _ClassOffset, _IsTypeDefTableRowRefSizeSmall);
	}
}
