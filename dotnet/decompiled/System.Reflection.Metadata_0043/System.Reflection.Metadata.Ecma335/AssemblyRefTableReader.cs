using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct AssemblyRefTableReader
{
	internal readonly int NumberOfNonVirtualRows;

	internal readonly int NumberOfVirtualRows;

	private readonly bool _IsStringHeapRefSizeSmall;

	private readonly bool _IsBlobHeapRefSizeSmall;

	private readonly int _MajorVersionOffset;

	private readonly int _MinorVersionOffset;

	private readonly int _BuildNumberOffset;

	private readonly int _RevisionNumberOffset;

	private readonly int _FlagsOffset;

	private readonly int _PublicKeyOrTokenOffset;

	private readonly int _NameOffset;

	private readonly int _CultureOffset;

	private readonly int _HashValueOffset;

	internal readonly int RowSize;

	internal readonly MemoryBlock Block;

	internal AssemblyRefTableReader(int numberOfRows, int stringHeapRefSize, int blobHeapRefSize, MemoryBlock containingBlock, int containingBlockOffset, MetadataKind metadataKind)
	{
		NumberOfNonVirtualRows = numberOfRows;
		NumberOfVirtualRows = ((metadataKind != MetadataKind.Ecma335) ? 6 : 0);
		_IsStringHeapRefSizeSmall = stringHeapRefSize == 2;
		_IsBlobHeapRefSizeSmall = blobHeapRefSize == 2;
		_MajorVersionOffset = 0;
		_MinorVersionOffset = _MajorVersionOffset + 2;
		_BuildNumberOffset = _MinorVersionOffset + 2;
		_RevisionNumberOffset = _BuildNumberOffset + 2;
		_FlagsOffset = _RevisionNumberOffset + 2;
		_PublicKeyOrTokenOffset = _FlagsOffset + 4;
		_NameOffset = _PublicKeyOrTokenOffset + blobHeapRefSize;
		_CultureOffset = _NameOffset + stringHeapRefSize;
		_HashValueOffset = _CultureOffset + stringHeapRefSize;
		RowSize = _HashValueOffset + blobHeapRefSize;
		Block = containingBlock.GetMemoryBlockAt(containingBlockOffset, RowSize * numberOfRows);
	}

	internal StringHandle GetName(int rowId)
	{
		int num = (rowId - 1) * RowSize;
		return StringHandle.FromOffset(Block.PeekHeapReference(num + _NameOffset, _IsStringHeapRefSizeSmall));
	}
}
