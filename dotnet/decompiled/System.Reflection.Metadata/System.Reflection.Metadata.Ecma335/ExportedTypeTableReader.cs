using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct ExportedTypeTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsImplementationRefSizeSmall;

	private readonly bool _IsStringHeapRefSizeSmall;

	private readonly int _FlagsOffset;

	private readonly int _TypeDefIdOffset;

	private readonly int _TypeNameOffset;

	private readonly int _TypeNamespaceOffset;

	private readonly int _ImplementationOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal ExportedTypeTableReader(int numberOfRows, int implementationRefSize, int stringHeapRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsImplementationRefSizeSmall = implementationRefSize == 2;
		_IsStringHeapRefSizeSmall = stringHeapRefSize == 2;
		_FlagsOffset = 0;
		_TypeDefIdOffset = _FlagsOffset + 4;
		_TypeNameOffset = _TypeDefIdOffset + 4;
		_TypeNamespaceOffset = _TypeNameOffset + stringHeapRefSize;
		_ImplementationOffset = _TypeNamespaceOffset + stringHeapRefSize;
		RowSize = _ImplementationOffset + implementationRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
	}
}
