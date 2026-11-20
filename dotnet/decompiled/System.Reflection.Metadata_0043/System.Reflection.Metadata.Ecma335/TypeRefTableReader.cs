using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct TypeRefTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsResolutionScopeRefSizeSmall;

	private readonly bool _IsStringHeapRefSizeSmall;

	private readonly int _ResolutionScopeOffset;

	private readonly int _NameOffset;

	private readonly int _NamespaceOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal TypeRefTableReader(int numberOfRows, int resolutionScopeRefSize, int stringHeapRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsResolutionScopeRefSizeSmall = resolutionScopeRefSize == 2;
		_IsStringHeapRefSizeSmall = stringHeapRefSize == 2;
		_ResolutionScopeOffset = 0;
		_NameOffset = _ResolutionScopeOffset + resolutionScopeRefSize;
		_NamespaceOffset = _NameOffset + stringHeapRefSize;
		RowSize = _NamespaceOffset + stringHeapRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
	}
}
