using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct GenericParamTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsTypeOrMethodDefRefSizeSmall;

	private readonly bool _IsStringHeapRefSizeSmall;

	private readonly int _NumberOffset;

	private readonly int _FlagsOffset;

	private readonly int _OwnerOffset;

	private readonly int _NameOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal GenericParamTableReader(int numberOfRows, bool declaredSorted, int typeOrMethodDefRefSize, int stringHeapRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsTypeOrMethodDefRefSizeSmall = typeOrMethodDefRefSize == 2;
		_IsStringHeapRefSizeSmall = stringHeapRefSize == 2;
		_NumberOffset = 0;
		_FlagsOffset = _NumberOffset + 2;
		_OwnerOffset = _FlagsOffset + 2;
		_NameOffset = _OwnerOffset + typeOrMethodDefRefSize;
		RowSize = _NameOffset + stringHeapRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
		if (!declaredSorted && !CheckSorted())
		{
			Throw.TableNotSorted(TableIndex.GenericParam);
		}
	}

	private bool CheckSorted()
	{
		return Block.IsOrderedByReferenceAscending(RowSize, _OwnerOffset, _IsTypeOrMethodDefRefSizeSmall);
	}
}
