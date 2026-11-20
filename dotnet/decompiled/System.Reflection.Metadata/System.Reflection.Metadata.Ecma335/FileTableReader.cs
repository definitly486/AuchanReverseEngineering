using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct FileTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsStringHeapRefSizeSmall;

	private readonly bool _IsBlobHeapRefSizeSmall;

	private readonly int _FlagsOffset;

	private readonly int _NameOffset;

	private readonly int _HashValueOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal FileTableReader(int numberOfRows, int stringHeapRefSize, int blobHeapRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsStringHeapRefSizeSmall = stringHeapRefSize == 2;
		_IsBlobHeapRefSizeSmall = blobHeapRefSize == 2;
		_FlagsOffset = 0;
		_NameOffset = _FlagsOffset + 4;
		_HashValueOffset = _NameOffset + stringHeapRefSize;
		RowSize = _HashValueOffset + blobHeapRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
	}
}
