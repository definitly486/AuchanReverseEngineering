using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal struct MemberRefTableReader
{
	internal int NumberOfRows;

	private readonly bool _IsMemberRefParentRefSizeSmall;

	private readonly bool _IsStringHeapRefSizeSmall;

	private readonly bool _IsBlobHeapRefSizeSmall;

	private readonly int _ClassOffset;

	private readonly int _NameOffset;

	private readonly int _SignatureOffset;

	internal readonly int RowSize;

	internal MemoryBlock Block;

	internal MemberRefTableReader(int numberOfRows, int memberRefParentRefSize, int stringHeapRefSize, int blobHeapRefSize, MemoryBlock containingBlock, int containingBlockOffset)
	{
		NumberOfRows = numberOfRows;
		_IsMemberRefParentRefSizeSmall = memberRefParentRefSize == 2;
		_IsStringHeapRefSizeSmall = stringHeapRefSize == 2;
		_IsBlobHeapRefSizeSmall = blobHeapRefSize == 2;
		_ClassOffset = 0;
		_NameOffset = _ClassOffset + memberRefParentRefSize;
		_SignatureOffset = _NameOffset + stringHeapRefSize;
		RowSize = _SignatureOffset + blobHeapRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
	}
}
