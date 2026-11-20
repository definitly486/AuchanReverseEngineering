using System;
using System.Runtime.CompilerServices;

namespace DryIoc;

internal sealed class RequestStack
{
	public Request[] Requests;

	public const int DefaultCapacity = 4;

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static RequestStack Create(int capacityPowerOfTwo = 4)
	{
		return new RequestStack(capacityPowerOfTwo);
	}

	public static RequestStack CreateToAccommodateIndex(int index)
	{
		int num = 4;
		while (index >= num)
		{
			num <<= 1;
		}
		return new RequestStack(num);
	}

	private RequestStack(int capacity)
	{
		Requests = new Request[capacity];
	}

	public ref Request GetOrPushRef(int index)
	{
		Request[] array = Requests;
		if (index >= array.Length)
		{
			array = (Requests = Expand(array, index));
		}
		return ref array[index];
	}

	private static Request[] Expand(Request[] items, int index)
	{
		int num = items.Length;
		int num2 = num << 1;
		while (index >= num2)
		{
			num2 <<= 1;
		}
		Request[] array = new Request[num2];
		Array.Copy(items, 0, array, 0, num);
		return array;
	}
}
