using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct DocumentTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _isGuidHeapRefSizeSmall;

	private readonly bool _isBlobHeapRefSizeSmall;

	private readonly int _hashAlgorithmOffset;

	private readonly int _hashOffset;

	private readonly int _languageOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal DocumentTableReader(int numberOfRows, int guidHeapRefSize, int blobHeapRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_isGuidHeapRefSizeSmall = guidHeapRefSize == 2;
		_isBlobHeapRefSizeSmall = blobHeapRefSize == 2;
		_hashAlgorithmOffset = blobHeapRefSize;
		_hashOffset = _hashAlgorithmOffset + guidHeapRefSize;
		_languageOffset = _hashOffset + blobHeapRefSize;
		RowSize = _languageOffset + guidHeapRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
	}
}
