using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct MethodImplTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsTypeDefTableRowRefSizeSmall;

	private readonly bool _IsMethodDefOrRefRefSizeSmall;

	private readonly int _ClassOffset;

	private readonly int _MethodBodyOffset;

	private readonly int _MethodDeclarationOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal MethodImplTableReader(int numberOfRows, bool declaredSorted, int typeDefTableRowRefSize, int methodDefOrRefRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsTypeDefTableRowRefSizeSmall = typeDefTableRowRefSize == 2;
		_IsMethodDefOrRefRefSizeSmall = methodDefOrRefRefSize == 2;
		_ClassOffset = 0;
		_MethodBodyOffset = _ClassOffset + typeDefTableRowRefSize;
		_MethodDeclarationOffset = _MethodBodyOffset + methodDefOrRefRefSize;
		RowSize = _MethodDeclarationOffset + methodDefOrRefRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
		if (!declaredSorted && !CheckSorted())
		{
			Throw.TableNotSorted(TableIndex.MethodImpl);
		}
	}

	private bool CheckSorted()
	{
		return Block.IsOrderedByReferenceAscending(RowSize, _ClassOffset, _IsTypeDefTableRowRefSizeSmall);
	}
}
