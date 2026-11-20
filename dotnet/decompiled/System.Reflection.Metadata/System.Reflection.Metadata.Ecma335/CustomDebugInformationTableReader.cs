using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct CustomDebugInformationTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _isHasCustomDebugInformationRefSizeSmall;

	private readonly bool _isGuidHeapRefSizeSmall;

	private readonly bool _isBlobHeapRefSizeSmall;

	private readonly int _kindOffset;

	private readonly int _valueOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal CustomDebugInformationTableReader(int numberOfRows, bool declaredSorted, int hasCustomDebugInformationRefSize, int guidHeapRefSize, int blobHeapRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_isHasCustomDebugInformationRefSizeSmall = hasCustomDebugInformationRefSize == 2;
		_isGuidHeapRefSizeSmall = guidHeapRefSize == 2;
		_isBlobHeapRefSizeSmall = blobHeapRefSize == 2;
		_kindOffset = hasCustomDebugInformationRefSize;
		_valueOffset = _kindOffset + guidHeapRefSize;
		RowSize = _valueOffset + blobHeapRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
		if (numberOfRows > 0 && !declaredSorted)
		{
			Throw.TableNotSorted(TableIndex.CustomDebugInformation);
		}
	}
}
