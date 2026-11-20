using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct CustomAttributeTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsHasCustomAttributeRefSizeSmall;

	private readonly bool _IsCustomAttributeTypeRefSizeSmall;

	private readonly bool _IsBlobHeapRefSizeSmall;

	private readonly int _ParentOffset;

	private readonly int _TypeOffset;

	private readonly int _ValueOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal readonly int[]? PtrTable;

	internal CustomAttributeTableReader(int numberOfRows, bool declaredSorted, int hasCustomAttributeRefSize, int customAttributeTypeRefSize, int blobHeapRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsHasCustomAttributeRefSizeSmall = hasCustomAttributeRefSize == 2;
		_IsCustomAttributeTypeRefSizeSmall = customAttributeTypeRefSize == 2;
		_IsBlobHeapRefSizeSmall = blobHeapRefSize == 2;
		_ParentOffset = 0;
		_TypeOffset = _ParentOffset + hasCustomAttributeRefSize;
		_ValueOffset = _TypeOffset + customAttributeTypeRefSize;
		RowSize = _ValueOffset + blobHeapRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
		PtrTable = null;
		if (!declaredSorted && !CheckSorted())
		{
			PtrTable = Block.BuildPtrTable(numberOfRows, RowSize, _ParentOffset, _IsHasCustomAttributeRefSizeSmall);
		}
	}

	private bool CheckSorted()
	{
		return Block.IsOrderedByReferenceAscending(RowSize, _ParentOffset, _IsHasCustomAttributeRefSizeSmall);
	}
}
