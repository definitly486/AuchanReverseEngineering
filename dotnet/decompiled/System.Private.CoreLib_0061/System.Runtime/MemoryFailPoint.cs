using System.Runtime.ConstrainedExecution;
using System.Threading;

namespace System.Runtime;

public sealed class MemoryFailPoint : CriticalFinalizerObject, IDisposable
{
	private static readonly ulong s_topOfMemory = GetTopOfMemory();

	private static long s_hiddenLastKnownFreeAddressSpace;

	private static long s_hiddenLastTimeCheckingAddressSpace;

	private static readonly ulong s_GCSegmentSize = 16777216uL;

	private static long s_failPointReservedMemory;

	private readonly ulong _reservedMemory;

	private bool _mustSubtractReservation;

	private static long LastKnownFreeAddressSpace => Volatile.Read(in s_hiddenLastKnownFreeAddressSpace);

	private static long LastTimeCheckingAddressSpace => Volatile.Read(in s_hiddenLastTimeCheckingAddressSpace);

	internal static ulong MemoryFailPointReservedMemory => (ulong)Volatile.Read(in s_failPointReservedMemory);

	private static void AddToLastKnownFreeAddressSpace(long addend)
	{
		Interlocked.Add(ref s_hiddenLastKnownFreeAddressSpace, addend);
	}

	public MemoryFailPoint(int sizeInMegabytes)
	{
		ArgumentOutOfRangeException.ThrowIfNegativeOrZero(sizeInMegabytes, "sizeInMegabytes");
		ulong num = (_reservedMemory = (ulong)((long)sizeInMegabytes << 20));
		ulong num2 = (ulong)(Math.Ceiling((double)num / (double)s_GCSegmentSize) * (double)s_GCSegmentSize);
		if (num2 >= s_topOfMemory)
		{
			throw new InsufficientMemoryException("InsufficientMemory_MemFailPoint_TooBig");
		}
		ulong num3 = (ulong)(Math.Ceiling((double)sizeInMegabytes / 16.0) * 16.0);
		num3 <<= 20;
		for (int i = 0; i < 3; i++)
		{
			if (!CheckForAvailableMemory(out var availPageFile, out var totalAddressSpaceFree))
			{
				return;
			}
			ulong memoryFailPointReservedMemory = MemoryFailPointReservedMemory;
			ulong num4 = num2 + memoryFailPointReservedMemory;
			bool flag = num4 < num2 || num4 < memoryFailPointReservedMemory;
			bool flag2 = availPageFile < num3 + memoryFailPointReservedMemory + 16777216 || flag;
			bool flag3 = totalAddressSpaceFree < num4 || flag;
			long num5 = Environment.TickCount;
			if (num5 > LastTimeCheckingAddressSpace + 10000 || num5 < LastTimeCheckingAddressSpace || LastKnownFreeAddressSpace < (long)num2)
			{
				CheckForFreeAddressSpace(num2, shouldThrow: false);
			}
			bool flag4 = (ulong)LastKnownFreeAddressSpace < num2;
			if (!flag2 && !flag3 && !flag4)
			{
				break;
			}
			switch (i)
			{
			case 0:
				GC.Collect();
				break;
			case 1:
				if (flag2)
				{
					GrowPageFileIfNecessaryAndPossible(new UIntPtr(num2));
				}
				break;
			case 2:
				if (flag2 || flag3)
				{
					throw new InsufficientMemoryException("InsufficientMemory_MemFailPoint");
				}
				if (flag4)
				{
					throw new InsufficientMemoryException("InsufficientMemory_MemFailPoint_VAFrag");
				}
				break;
			}
		}
		AddToLastKnownFreeAddressSpace((long)(0L - num));
		if (LastKnownFreeAddressSpace < 0)
		{
			CheckForFreeAddressSpace(num2, shouldThrow: true);
		}
		AddMemoryFailPointReservation((long)num);
		_mustSubtractReservation = true;
	}

	~MemoryFailPoint()
	{
		Disposing();
	}

	public void Dispose()
	{
		Disposing();
		GC.SuppressFinalize(this);
	}

	private void Disposing()
	{
		if (_mustSubtractReservation)
		{
			AddMemoryFailPointReservation((long)(0L - _reservedMemory));
			_mustSubtractReservation = false;
		}
	}

	internal static long AddMemoryFailPointReservation(long size)
	{
		return Interlocked.Add(ref s_failPointReservedMemory, size);
	}

	private static ulong GetTopOfMemory()
	{
		if (4 != 4)
		{
		}
		return 4294967295uL;
	}

	private static bool CheckForAvailableMemory(out ulong availPageFile, out ulong totalAddressSpaceFree)
	{
		availPageFile = 0uL;
		totalAddressSpaceFree = 0uL;
		return false;
	}

	private static void CheckForFreeAddressSpace(ulong size, bool shouldThrow)
	{
	}

	private static void GrowPageFileIfNecessaryAndPossible(nuint numBytes)
	{
	}
}
