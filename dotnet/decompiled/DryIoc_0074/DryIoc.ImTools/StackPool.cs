using System.Runtime.CompilerServices;
using System.Threading;

namespace DryIoc.ImTools;

public sealed class StackPool<T> where T : class
{
	private sealed class Stack
	{
		public readonly T Head;

		public readonly Stack Tail;

		public Stack(T h, Stack t)
		{
			Head = h;
			Tail = t;
		}
	}

	private Stack _s;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public T RentOrDefault()
	{
		Stack stack = Interlocked.Exchange(ref _s, _s?.Tail);
		if (stack == null)
		{
			return null;
		}
		return stack.Head;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Return(T x)
	{
		Interlocked.Exchange(ref _s, new Stack(x, _s));
	}
}
