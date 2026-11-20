using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct StateMachineMethodTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _isMethodRefSizeSmall;

	private readonly int _kickoffMethodOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal StateMachineMethodTableReader(int numberOfRows, bool declaredSorted, int methodRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_isMethodRefSizeSmall = methodRefSize == 2;
		_kickoffMethodOffset = methodRefSize;
		RowSize = _kickoffMethodOffset + methodRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
		if (numberOfRows > 0 && !declaredSorted)
		{
			Throw.TableNotSorted(TableIndex.StateMachineMethod);
		}
	}
}
