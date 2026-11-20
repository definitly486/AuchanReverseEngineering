using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct ImportScopeTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _isImportScopeRefSizeSmall;

	private readonly bool _isBlobHeapRefSizeSmall;

	private readonly int _importsOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal ImportScopeTableReader(int numberOfRows, int importScopeRefSize, int blobHeapRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_isImportScopeRefSizeSmall = importScopeRefSize == 2;
		_isBlobHeapRefSizeSmall = blobHeapRefSize == 2;
		_importsOffset = importScopeRefSize;
		RowSize = _importsOffset + blobHeapRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
	}
}
