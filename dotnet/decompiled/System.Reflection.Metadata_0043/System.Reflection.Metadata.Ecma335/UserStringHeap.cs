using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct UserStringHeap
{
	internal readonly MemoryBlock Block;

	public UserStringHeap(MemoryBlock block)
	{
		Block = block;
	}
}
