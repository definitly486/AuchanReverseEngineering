using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal struct TypeDefTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsFieldRefSizeSmall;

	private readonly bool _IsMethodRefSizeSmall;

	private readonly bool _IsTypeDefOrRefRefSizeSmall;

	private readonly bool _IsStringHeapRefSizeSmall;

	private readonly int _FlagsOffset;

	private readonly int _NameOffset;

	private readonly int _NamespaceOffset;

	private readonly int _ExtendsOffset;

	private readonly int _FieldListOffset;

	private readonly int _MethodListOffset;

	internal readonly int RowSize;

	internal MemoryBlock Block;

	internal TypeDefTableReader(int numberOfRows, int fieldRefSize, int methodRefSize, int typeDefOrRefRefSize, int stringHeapRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsFieldRefSizeSmall = fieldRefSize == 2;
		_IsMethodRefSizeSmall = methodRefSize == 2;
		_IsTypeDefOrRefRefSizeSmall = typeDefOrRefRefSize == 2;
		_IsStringHeapRefSizeSmall = stringHeapRefSize == 2;
		_FlagsOffset = 0;
		_NameOffset = _FlagsOffset + 4;
		_NamespaceOffset = _NameOffset + stringHeapRefSize;
		_ExtendsOffset = _NamespaceOffset + stringHeapRefSize;
		_FieldListOffset = _ExtendsOffset + typeDefOrRefRefSize;
		_MethodListOffset = _FieldListOffset + fieldRefSize;
		RowSize = _MethodListOffset + methodRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
	}
}
