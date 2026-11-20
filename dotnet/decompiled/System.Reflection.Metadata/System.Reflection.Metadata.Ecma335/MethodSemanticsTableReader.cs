using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct MethodSemanticsTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsMethodTableRowRefSizeSmall;

	private readonly bool _IsHasSemanticRefSizeSmall;

	private readonly int _SemanticsFlagOffset;

	private readonly int _MethodOffset;

	private readonly int _AssociationOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal MethodSemanticsTableReader(int numberOfRows, bool declaredSorted, int methodTableRowRefSize, int hasSemanticRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsMethodTableRowRefSizeSmall = methodTableRowRefSize == 2;
		_IsHasSemanticRefSizeSmall = hasSemanticRefSize == 2;
		_SemanticsFlagOffset = 0;
		_MethodOffset = _SemanticsFlagOffset + 2;
		_AssociationOffset = _MethodOffset + methodTableRowRefSize;
		RowSize = _AssociationOffset + hasSemanticRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
		if (!declaredSorted && !CheckSorted())
		{
			Throw.TableNotSorted(TableIndex.MethodSemantics);
		}
	}

	private bool CheckSorted()
	{
		return Block.IsOrderedByReferenceAscending(RowSize, _AssociationOffset, _IsHasSemanticRefSizeSmall);
	}
}
