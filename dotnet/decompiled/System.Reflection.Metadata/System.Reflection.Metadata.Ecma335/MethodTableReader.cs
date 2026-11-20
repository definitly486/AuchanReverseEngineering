using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct MethodTableReader
{
	internal readonly int NumberOfRows;

	private readonly bool _IsParamRefSizeSmall;

	private readonly bool _IsStringHeapRefSizeSmall;

	private readonly bool _IsBlobHeapRefSizeSmall;

	private readonly int _RvaOffset;

	private readonly int _ImplFlagsOffset;

	private readonly int _FlagsOffset;

	private readonly int _NameOffset;

	private readonly int _SignatureOffset;

	private readonly int _ParamListOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal MethodTableReader(int numberOfRows, int paramRefSize, int stringHeapRefSize, int blobHeapRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsParamRefSizeSmall = paramRefSize == 2;
		_IsStringHeapRefSizeSmall = stringHeapRefSize == 2;
		_IsBlobHeapRefSizeSmall = blobHeapRefSize == 2;
		_RvaOffset = 0;
		_ImplFlagsOffset = _RvaOffset + 4;
		_FlagsOffset = _ImplFlagsOffset + 2;
		_NameOffset = _FlagsOffset + 2;
		_SignatureOffset = _NameOffset + stringHeapRefSize;
		_ParamListOffset = _SignatureOffset + blobHeapRefSize;
		RowSize = _ParamListOffset + paramRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
	}
}
