using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace DryIoc.ImTools;

public sealed class Ref<T> where T : class
{
	private T _value;

	public T Value => _value;

	public Ref(T initialValue = null)
	{
		_value = initialValue;
	}

	public T Swap(Func<T, T> getNewValue)
	{
		return Ref.Swap(ref _value, getNewValue);
	}

	public T Swap<A>(A a, Func<T, A, T> getNewValue, int retryCountUntilThrow = 50)
	{
		return Ref.Swap(ref _value, a, getNewValue, retryCountUntilThrow);
	}

	public T Swap<A, B>(A a, B b, Func<T, A, B, T> getNewValue, int retryCountUntilThrow = 50)
	{
		return Ref.Swap(ref _value, a, b, getNewValue, retryCountUntilThrow);
	}

	public T SwapAndGetNewValue<A>(A a, Func<T, A, T> getNewValue, int retryCountUntilThrow = 50)
	{
		return Ref.SwapAndGetNewValue(ref _value, a, getNewValue, retryCountUntilThrow);
	}

	public T Swap(T newValue)
	{
		return Interlocked.Exchange(ref _value, newValue);
	}

	public T SetNonAtomic(T newValue)
	{
		return _value = newValue;
	}

	public bool TrySwapIfStillCurrent(T currentValue, T newValue)
	{
		return Interlocked.CompareExchange(ref _value, newValue, currentValue) == currentValue;
	}

	public void UnsafeSet(T newValue)
	{
		_value = newValue;
	}
}
public static class Ref
{
	public const int RETRY_COUNT_UNTIL_THROW = 50;

	public static Ref<T> Of<T>(T value) where T : class
	{
		return new Ref<T>(value);
	}

	public static Ref<T> NewRef<T>(this Ref<T> original) where T : class
	{
		return Of(original.Value);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T Swap<T>(ref T value, Func<T, T> getNewValue, int retryCountUntilThrow = 50) where T : class
	{
		SpinWait spinWait = default(SpinWait);
		int num = 0;
		T val;
		while (true)
		{
			val = value;
			T value2 = getNewValue(val);
			if (Interlocked.CompareExchange(ref value, value2, val) == val)
			{
				break;
			}
			if (++num > retryCountUntilThrow)
			{
				ThrowRetryCountExceeded(retryCountUntilThrow);
			}
			spinWait.SpinOnce();
		}
		return val;
	}

	private static void ThrowRetryCountExceeded(int retryCountExceeded)
	{
		throw new InvalidOperationException($"Ref retried to Update for {retryCountExceeded} times But there is always someone else intervened.");
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T Swap<T, A>(ref T value, A a, Func<T, A, T> getNewValue, int retryCountUntilThrow = 50) where T : class
	{
		SpinWait spinWait = default(SpinWait);
		int num = 0;
		T val;
		while (true)
		{
			val = value;
			T value2 = getNewValue(val, a);
			if (Interlocked.CompareExchange(ref value, value2, val) == val)
			{
				break;
			}
			if (++num > retryCountUntilThrow)
			{
				ThrowRetryCountExceeded(retryCountUntilThrow);
			}
			spinWait.SpinOnce();
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T SwapAndGetNewValue<T, A>(ref T value, A a, Func<T, A, T> getNewValue, int retryCountUntilThrow = 50) where T : class
	{
		SpinWait spinWait = default(SpinWait);
		int num = 0;
		T val2;
		while (true)
		{
			T val = value;
			val2 = getNewValue(val, a);
			if (Interlocked.CompareExchange(ref value, val2, val) == val)
			{
				break;
			}
			if (++num > retryCountUntilThrow)
			{
				ThrowRetryCountExceeded(retryCountUntilThrow);
			}
			spinWait.SpinOnce();
		}
		return val2;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T Swap<T, A, B>(ref T value, A a, B b, Func<T, A, B, T> getNewValue, int retryCountUntilThrow = 50) where T : class
	{
		SpinWait spinWait = default(SpinWait);
		int num = 0;
		T val;
		while (true)
		{
			val = value;
			T value2 = getNewValue(val, a, b);
			if (Interlocked.CompareExchange(ref value, value2, val) == val)
			{
				break;
			}
			if (++num > retryCountUntilThrow)
			{
				ThrowRetryCountExceeded(retryCountUntilThrow);
			}
			spinWait.SpinOnce();
		}
		return val;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T Swap<T, A, B, C>(ref T value, A a, B b, C c, Func<T, A, B, C, T> getNewValue, int retryCountUntilThrow = 50) where T : class
	{
		SpinWait spinWait = default(SpinWait);
		int num = 0;
		T val;
		while (true)
		{
			val = value;
			T value2 = getNewValue(val, a, b, c);
			if (Interlocked.CompareExchange(ref value, value2, val) == val)
			{
				break;
			}
			if (++num > retryCountUntilThrow)
			{
				ThrowRetryCountExceeded(retryCountUntilThrow);
			}
			spinWait.SpinOnce();
		}
		return val;
	}
}
