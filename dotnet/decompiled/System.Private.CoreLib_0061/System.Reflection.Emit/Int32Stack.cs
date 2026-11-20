using System.Collections.Generic;

namespace System.Reflection.Emit;

internal sealed class Int32Stack : List<int>
{
	public Int32Stack(int initialCapacity)
		: base(initialCapacity)
	{
	}

	public int Peek()
	{
		if (base.Count == 0)
		{
			throw new InvalidOperationException();
		}
		return base[base.Count - 1];
	}

	public int Pop()
	{
		if (base.Count == 0)
		{
			throw new InvalidOperationException();
		}
		int result = base[base.Count - 1];
		RemoveAt(base.Count - 1);
		return result;
	}

	public void Push(int value)
	{
		Add(value);
	}
}
