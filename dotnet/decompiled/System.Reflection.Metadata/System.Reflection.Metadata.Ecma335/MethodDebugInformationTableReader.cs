using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct MethodDebugInformationTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _isDocumentRefSmall;

	private readonly bool _isBlobHeapRefSizeSmall;

	private readonly int _sequencePointsOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal MethodDebugInformationTableReader(int numberOfRows, int documentRefSize, int blobHeapRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_isDocumentRefSmall = documentRefSize == 2;
		_isBlobHeapRefSizeSmall = blobHeapRefSize == 2;
		_sequencePointsOffset = documentRefSize;
		RowSize = _sequencePointsOffset + blobHeapRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
	}
}
