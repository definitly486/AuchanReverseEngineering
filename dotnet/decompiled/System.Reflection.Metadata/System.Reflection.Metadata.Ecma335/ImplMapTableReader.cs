using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct ImplMapTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsModuleRefTableRowRefSizeSmall;

	private readonly bool _IsMemberForwardRowRefSizeSmall;

	private readonly bool _IsStringHeapRefSizeSmall;

	private readonly int _FlagsOffset;

	private readonly int _MemberForwardedOffset;

	private readonly int _ImportNameOffset;

	private readonly int _ImportScopeOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal ImplMapTableReader(int numberOfRows, bool declaredSorted, int moduleRefTableRowRefSize, int memberForwardedRefSize, int stringHeapRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsModuleRefTableRowRefSizeSmall = moduleRefTableRowRefSize == 2;
		_IsMemberForwardRowRefSizeSmall = memberForwardedRefSize == 2;
		_IsStringHeapRefSizeSmall = stringHeapRefSize == 2;
		_FlagsOffset = 0;
		_MemberForwardedOffset = _FlagsOffset + 2;
		_ImportNameOffset = _MemberForwardedOffset + memberForwardedRefSize;
		_ImportScopeOffset = _ImportNameOffset + stringHeapRefSize;
		RowSize = _ImportScopeOffset + moduleRefTableRowRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
		if (!declaredSorted && !CheckSorted())
		{
			Throw.TableNotSorted(TableIndex.ImplMap);
		}
	}

	private bool CheckSorted()
	{
		return Block.IsOrderedByReferenceAscending(RowSize, _MemberForwardedOffset, _IsMemberForwardRowRefSizeSmall);
	}
}
