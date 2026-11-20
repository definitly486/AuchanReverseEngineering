using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct ParamPtrTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsParamTableRowRefSizeSmall;

	private readonly int _ParamOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal ParamPtrTableReader(int numberOfRows, int paramTableRowRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsParamTableRowRefSizeSmall = paramTableRowRefSize == 2;
		_ParamOffset = 0;
		RowSize = _ParamOffset + paramTableRowRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
	}
}
