using System.Runtime.CompilerServices;

namespace System.Threading;

internal static class ObjectHeader
{
	private struct Header
	{
		public unsafe void* vtable;

		public nint synchronization;
	}

	private ref struct ObjectHeaderOnStack
	{
		private unsafe Header** _header;

		public unsafe ref Header Header => ref Unsafe.AsRef<Header>(*_header);

		private unsafe ObjectHeaderOnStack(ref object o)
		{
			_header = (Header**)Unsafe.AsPointer(in o);
		}

		public static ObjectHeaderOnStack Create(ref object o)
		{
			return new ObjectHeaderOnStack(ref o);
		}
	}

	private struct MonoThreadsSync
	{
		public uint status;

		public uint nest;

		public int hash_code;
	}

	private static class SyncBlock
	{
		public static int HashCode(ref MonoThreadsSync mon)
		{
			return mon.hash_code;
		}

		public static ref uint Status(ref MonoThreadsSync mon)
		{
			return ref mon.status;
		}

		public static void IncrementNest(ref MonoThreadsSync mon)
		{
			mon.nest++;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool TryDecrementNest(ref MonoThreadsSync mon)
		{
			if (mon.nest == 1)
			{
				return false;
			}
			mon.nest--;
			return true;
		}
	}

	private static class MonitorStatus
	{
		public static int GetOwner(uint status)
		{
			return (int)(status & 0xFFFF);
		}

		public static uint SetOwner(uint status, int owner)
		{
			return (status & 0xFFFF0000u) | (uint)owner;
		}

		public static bool HaveWaiters(uint status)
		{
			return (status & 0x80000000u) != 0;
		}
	}

	private struct LockWord
	{
		private nint _lock_word;

		public bool IsInflated => (_lock_word & 2) != 0;

		public bool HasHash => (_lock_word & 1) != 0;

		public bool IsFree => _lock_word == IntPtr.Zero;

		public bool IsFlat => (_lock_word & 3) == 0;

		public bool IsNested => (_lock_word & 0x3FC) != 0;

		public int FlatHash => (int)(_lock_word >>> 2);

		public bool IsNestMax => (_lock_word & 0x3FC) == 1020;

		public nint AsIntPtr => _lock_word;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public unsafe ref MonoThreadsSync GetInflatedLock()
		{
			return ref Unsafe.AsRef<MonoThreadsSync>((void*)(_lock_word & ~(nint)3));
		}

		public LockWord IncrementNest()
		{
			Unsafe.SkipInit(out LockWord result);
			result._lock_word = _lock_word + 4;
			return result;
		}

		public LockWord DecrementNest()
		{
			Unsafe.SkipInit(out LockWord result);
			result._lock_word = _lock_word - 4;
			return result;
		}

		public int GetOwner()
		{
			return (int)(_lock_word >>> 10);
		}

		public static LockWord NewFlat(int owner)
		{
			Unsafe.SkipInit(out LockWord result);
			result._lock_word = (nint)((nuint)(uint)owner << 10);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static LockWord FromObjectHeader(ref Header header)
		{
			Unsafe.SkipInit(out LockWord result);
			result._lock_word = header.synchronization;
			return result;
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static LockWord GetLockWord(ObjectHeaderOnStack h)
	{
		return LockWord.FromObjectHeader(ref h.Header);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static nint LockWordCompareExchange(ObjectHeaderOnStack h, LockWord nlw, LockWord expected)
	{
		return Interlocked.CompareExchange(ref h.Header.synchronization, nlw.AsIntPtr, expected.AsIntPtr);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryGetHashCode(object o, out int hash)
	{
		hash = 0;
		if (o == null)
		{
			return true;
		}
		LockWord lockWord = GetLockWord(ObjectHeaderOnStack.Create(ref o));
		if (lockWord.HasHash)
		{
			if (lockWord.IsInflated)
			{
				hash = SyncBlock.HashCode(ref lockWord.GetInflatedLock());
				return true;
			}
			hash = lockWord.FlatHash;
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool TryEnterInflatedFast(scoped ref MonoThreadsSync mon, int small_id)
	{
		uint num = SyncBlock.Status(ref mon);
		if (MonitorStatus.GetOwner(num) == 0)
		{
			uint value = MonitorStatus.SetOwner(num, small_id);
			if (Interlocked.CompareExchange(ref SyncBlock.Status(ref mon), value, num) == num)
			{
				return true;
			}
			return false;
		}
		if (MonitorStatus.GetOwner(num) == small_id)
		{
			SyncBlock.IncrementNest(ref mon);
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryEnterFast(object o)
	{
		ObjectHeaderOnStack h = ObjectHeaderOnStack.Create(ref o);
		LockWord lockWord = GetLockWord(h);
		if (!lockWord.IsInflated && lockWord.HasHash)
		{
			return false;
		}
		int smallId = Thread.CurrentThread.GetSmallId();
		if (lockWord.IsFree)
		{
			LockWord nlw = LockWord.NewFlat(smallId);
			if (LockWordCompareExchange(h, nlw, lockWord) == lockWord.AsIntPtr)
			{
				return true;
			}
			return false;
		}
		if (lockWord.IsInflated)
		{
			return TryEnterInflatedFast(ref lockWord.GetInflatedLock(), smallId);
		}
		if (lockWord.IsFlat)
		{
			if (lockWord.GetOwner() == smallId)
			{
				if (lockWord.IsNestMax)
				{
					return false;
				}
				LockWord nlw2 = lockWord.IncrementNest();
				if (LockWordCompareExchange(h, nlw2, lockWord) == lockWord.AsIntPtr)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool IsEntered(object obj)
	{
		LockWord lockWord = GetLockWord(ObjectHeaderOnStack.Create(ref obj));
		if (lockWord.IsFlat)
		{
			return lockWord.GetOwner() == Thread.CurrentThread.GetSmallId();
		}
		if (lockWord.IsInflated)
		{
			return MonitorStatus.GetOwner(lockWord.GetInflatedLock().status) == Thread.CurrentThread.GetSmallId();
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool HasOwner(object obj)
	{
		LockWord lockWord = GetLockWord(ObjectHeaderOnStack.Create(ref obj));
		if (lockWord.IsFlat)
		{
			return !lockWord.IsFree;
		}
		if (lockWord.IsInflated)
		{
			return MonitorStatus.GetOwner(lockWord.GetInflatedLock().status) != 0;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool TryExitInflated(scoped ref MonoThreadsSync mon)
	{
		if (SyncBlock.TryDecrementNest(ref mon))
		{
			return true;
		}
		ref uint reference = ref SyncBlock.Status(ref mon);
		uint num = reference;
		if (MonitorStatus.HaveWaiters(num))
		{
			return false;
		}
		uint value = MonitorStatus.SetOwner(num, 0);
		if (Interlocked.CompareExchange(ref reference, value, num) == num)
		{
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static bool TryExitFlat(ObjectHeaderOnStack h, LockWord lw)
	{
		LockWord nlw = ((!lw.IsNested) ? default(LockWord) : lw.DecrementNest());
		if (LockWordCompareExchange(h, nlw, lw) == lw.AsIntPtr)
		{
			return true;
		}
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryExitChecked(object obj)
	{
		ObjectHeaderOnStack h = ObjectHeaderOnStack.Create(ref obj);
		LockWord lockWord = GetLockWord(h);
		bool flag = false;
		ref MonoThreadsSync reference = ref Unsafe.NullRef<MonoThreadsSync>();
		if (lockWord.IsFlat)
		{
			flag = lockWord.GetOwner() == Thread.CurrentThread.GetSmallId();
		}
		else if (lockWord.IsInflated)
		{
			reference = ref lockWord.GetInflatedLock();
			flag = MonitorStatus.GetOwner(reference.status) == Thread.CurrentThread.GetSmallId();
		}
		if (!flag)
		{
			throw new SynchronizationLockException("Arg_SynchronizationLockException");
		}
		if (lockWord.IsInflated)
		{
			return TryExitInflated(ref reference);
		}
		return TryExitFlat(h, lockWord);
	}
}
