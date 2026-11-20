using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal struct EventTableReader
{
	internal int NumberOfRows;

	private readonly bool _IsTypeDefOrRefRefSizeSmall;

	private readonly bool _IsStringHeapRefSizeSmall;

	private readonly int _FlagsOffset;

	private readonly int _NameOffset;

	private readonly int _EventTypeOffset;

	internal readonly int RowSize;

	internal MemoryBlock Block;

	internal EventTableReader(int numberOfRows, int typeDefOrRefRefSize, int stringHeapRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsTypeDefOrRefRefSizeSmall = typeDefOrRefRefSize == 2;
		_IsStringHeapRefSizeSmall = stringHeapRefSize == 2;
		_FlagsOffset = 0;
		_NameOffset = _FlagsOffset + 2;
		_EventTypeOffset = _NameOffset + stringHeapRefSize;
		RowSize = _EventTypeOffset + typeDefOrRefRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
	}
}
