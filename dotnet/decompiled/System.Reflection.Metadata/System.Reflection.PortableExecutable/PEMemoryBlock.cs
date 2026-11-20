using System.Reflection.Internal;

namespace System.Reflection.PortableExecutable;

public readonly struct PEMemoryBlock
{
	private readonly AbstractMemoryBlock _block;

	private readonly int _offset;

	public unsafe byte* Pointer
	{
		get
		{
			if (_block == null)
			{
				return null;
			}
			return _block.Pointer + _offset;
		}
	}

	public int Length => (_block?.Size - _offset).GetValueOrDefault();

	internal PEMemoryBlock(AbstractMemoryBlock block, int offset = 0)
	{
		_block = block;
		_offset = offset;
	}
}
