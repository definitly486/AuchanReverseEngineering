using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct LocalScopeTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _isMethodRefSmall;

	private readonly bool _isImportScopeRefSmall;

	private readonly bool _isLocalConstantRefSmall;

	private readonly bool _isLocalVariableRefSmall;

	private readonly int _importScopeOffset;

	private readonly int _variableListOffset;

	private readonly int _constantListOffset;

	private readonly int _startOffsetOffset;

	private readonly int _lengthOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal LocalScopeTableReader(int numberOfRows, bool declaredSorted, int methodRefSize, int importScopeRefSize, int localVariableRefSize, int localConstantRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_isMethodRefSmall = methodRefSize == 2;
		_isImportScopeRefSmall = importScopeRefSize == 2;
		_isLocalVariableRefSmall = localVariableRefSize == 2;
		_isLocalConstantRefSmall = localConstantRefSize == 2;
		_importScopeOffset = methodRefSize;
		_variableListOffset = _importScopeOffset + importScopeRefSize;
		_constantListOffset = _variableListOffset + localVariableRefSize;
		_startOffsetOffset = _constantListOffset + localConstantRefSize;
		_lengthOffset = _startOffsetOffset + 4;
		RowSize = _lengthOffset + 4;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
		if (numberOfRows > 0 && !declaredSorted)
		{
			Throw.TableNotSorted(TableIndex.LocalScope);
		}
	}
}
