using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;

namespace System.Buffers;

internal sealed class SharedArrayPool<T> : ArrayPool<T>
{
	[ThreadStatic]
	private static SharedArrayPoolThreadLocalArray[] t_tlsBuckets;

	private readonly ConditionalWeakTable<SharedArrayPoolThreadLocalArray[], object> _allTlsBuckets = new ConditionalWeakTable<SharedArrayPoolThreadLocalArray[], object>();

	private readonly SharedArrayPoolPartitions[] _buckets = new SharedArrayPoolPartitions[27];

	private bool _trimCallbackCreated;

	private int Id => GetHashCode();

	private SharedArrayPoolPartitions CreatePerCorePartitions(int bucketIndex)
	{
		SharedArrayPoolPartitions sharedArrayPoolPartitions = new SharedArrayPoolPartitions();
		return Interlocked.CompareExchange(ref _buckets[bucketIndex], sharedArrayPoolPartitions, null) ?? sharedArrayPoolPartitions;
	}

	public override T[] Rent(int minimumLength)
	{
		ArrayPoolEventSource log = ArrayPoolEventSource.Log;
		int num = Utilities.SelectBucketIndex(minimumLength);
		SharedArrayPoolThreadLocalArray[] array = t_tlsBuckets;
		T[] array2;
		if (array != null && (uint)num < (uint)array.Length)
		{
			array2 = Unsafe.As<T[]>(array[num].Array);
			if (array2 != null)
			{
				array[num].Array = null;
				if (log.IsEnabled())
				{
				}
				return array2;
			}
		}
		SharedArrayPoolPartitions[] buckets = _buckets;
		if ((uint)num < (uint)buckets.Length)
		{
			SharedArrayPoolPartitions sharedArrayPoolPartitions = buckets[num];
			if (sharedArrayPoolPartitions != null)
			{
				array2 = Unsafe.As<T[]>(sharedArrayPoolPartitions.TryPop());
				if (array2 != null)
				{
					if (log.IsEnabled())
					{
					}
					return array2;
				}
			}
			minimumLength = Utilities.GetMaxSizeForBucket(num);
		}
		else
		{
			if (minimumLength == 0)
			{
				return Array.Empty<T>();
			}
			ArgumentOutOfRangeException.ThrowIfNegative(minimumLength, "minimumLength");
		}
		array2 = GC.AllocateUninitializedArray<T>(minimumLength);
		if (log.IsEnabled())
		{
		}
		return array2;
	}

	public override void Return(T[] array, bool clearArray = false)
	{
		if (array == null)
		{
			ThrowHelper.ThrowArgumentNullException(ExceptionArgument.array);
		}
		int num = Utilities.SelectBucketIndex(array.Length);
		SharedArrayPoolThreadLocalArray[] array2 = t_tlsBuckets ?? InitializeTlsBucketsAndTrimming();
		bool flag = false;
		bool flag2 = true;
		if ((uint)num < (uint)array2.Length)
		{
			flag = true;
			if (clearArray)
			{
				Array.Clear(array);
			}
			if (array.Length != Utilities.GetMaxSizeForBucket(num))
			{
				throw new ArgumentException("ArgumentException_BufferNotFromPool", "array");
			}
			ref SharedArrayPoolThreadLocalArray reference = ref array2[num];
			Array array3 = reference.Array;
			reference = new SharedArrayPoolThreadLocalArray(array);
			if (array3 != null)
			{
				flag2 = (_buckets[num] ?? CreatePerCorePartitions(num)).TryPush(array3);
			}
		}
		ArrayPoolEventSource log = ArrayPoolEventSource.Log;
		if (!log.IsEnabled())
		{
		}
	}

	public bool Trim()
	{
		int tickCount = Environment.TickCount;
		Utilities.MemoryPressure memoryPressure = Utilities.GetMemoryPressure();
		ArrayPoolEventSource log = ArrayPoolEventSource.Log;
		if (log.IsEnabled())
		{
		}
		SharedArrayPoolPartitions[] buckets = _buckets;
		for (int i = 0; i < buckets.Length; i++)
		{
			buckets[i]?.Trim(tickCount, Id, memoryPressure);
		}
		if (memoryPressure == Utilities.MemoryPressure.High)
		{
			log.IsEnabled();
			foreach (KeyValuePair<SharedArrayPoolThreadLocalArray[], object> item in (IEnumerable<KeyValuePair<SharedArrayPoolThreadLocalArray[], object>>)_allTlsBuckets)
			{
				Array.Clear(item.Key);
			}
		}
		else
		{
			uint num = ((memoryPressure != Utilities.MemoryPressure.Medium) ? 30000u : 15000u);
			uint num2 = num;
			foreach (KeyValuePair<SharedArrayPoolThreadLocalArray[], object> item2 in (IEnumerable<KeyValuePair<SharedArrayPoolThreadLocalArray[], object>>)_allTlsBuckets)
			{
				SharedArrayPoolThreadLocalArray[] key = item2.Key;
				for (int j = 0; j < key.Length; j++)
				{
					if (key[j].Array != null)
					{
						int millisecondsTimeStamp = key[j].MillisecondsTimeStamp;
						if (millisecondsTimeStamp == 0)
						{
							key[j].MillisecondsTimeStamp = tickCount;
						}
						else if (tickCount - millisecondsTimeStamp >= num2 && Interlocked.Exchange(ref key[j].Array, null) is T[] && !log.IsEnabled())
						{
						}
					}
				}
			}
		}
		return true;
	}

	private SharedArrayPoolThreadLocalArray[] InitializeTlsBucketsAndTrimming()
	{
		SharedArrayPoolThreadLocalArray[] array = (t_tlsBuckets = new SharedArrayPoolThreadLocalArray[27]);
		_allTlsBuckets.Add(array, null);
		if (!Interlocked.Exchange(ref _trimCallbackCreated, value: true))
		{
			Gen2GcCallback.Register((object s) => ((SharedArrayPool<T>)s).Trim(), this);
		}
		return array;
	}
}
