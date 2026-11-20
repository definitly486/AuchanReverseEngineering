using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct GenericParamConstraintTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsGenericParamTableRowRefSizeSmall;

	private readonly bool _IsTypeDefOrRefRefSizeSmall;

	private readonly int _OwnerOffset;

	private readonly int _ConstraintOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal GenericParamConstraintTableReader(int numberOfRows, bool declaredSorted, int genericParamTableRowRefSize, int typeDefOrRefRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsGenericParamTableRowRefSizeSmall = genericParamTableRowRefSize == 2;
		_IsTypeDefOrRefRefSizeSmall = typeDefOrRefRefSize == 2;
		_OwnerOffset = 0;
		_ConstraintOffset = _OwnerOffset + genericParamTableRowRefSize;
		RowSize = _ConstraintOffset + typeDefOrRefRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
		if (!declaredSorted && !CheckSorted())
		{
			Throw.TableNotSorted(TableIndex.GenericParamConstraint);
		}
	}

	private bool CheckSorted()
	{
		return Block.IsOrderedByReferenceAscending(RowSize, _OwnerOffset, _IsGenericParamTableRowRefSizeSmall);
	}
}
