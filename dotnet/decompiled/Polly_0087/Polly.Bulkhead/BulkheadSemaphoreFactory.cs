using System;
using System.Threading;

namespace Polly.Bulkhead;

internal static class BulkheadSemaphoreFactory
{
	public static (SemaphoreSlim MaxParallelizationSemaphore, SemaphoreSlim MaxQueuedActionsSemaphore) CreateBulkheadSemaphores(int maxParallelization, int maxQueueingActions)
	{
		SemaphoreSlim item = new SemaphoreSlim(maxParallelization, maxParallelization);
		int num = (int)Math.Min((long)maxQueueingActions + (long)maxParallelization, 2147483647L);
		SemaphoreSlim item2 = new SemaphoreSlim(num, num);
		return (MaxParallelizationSemaphore: item, MaxQueuedActionsSemaphore: item2);
	}
}
