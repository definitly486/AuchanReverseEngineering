using System.Reflection.Internal;

namespace System.Reflection.Metadata.Ecma335;

internal readonly struct GuidHeap
{
	internal readonly MemoryBlock Block;

	public GuidHeap(MemoryBlock block)
	{
		Block = block;
	}
}
