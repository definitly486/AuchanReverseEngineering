using System;
using System.Threading;
using System.Threading.Tasks;

namespace Auchan.Common.Common;

public class TaskQueue
{
	private const int InitialCount = 1;

	private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1);

	public bool HasRunningTasks => _semaphore.CurrentCount < 1;

	public async Task<T> Enqueue<T>(Func<Task<T>> taskGenerator)
	{
		await _semaphore.WaitAsync();
		try
		{
			return await taskGenerator();
		}
		finally
		{
			_semaphore.Release();
		}
	}

	public async Task Enqueue(Func<Task> taskGenerator)
	{
		await _semaphore.WaitAsync();
		try
		{
			await taskGenerator();
		}
		finally
		{
			_semaphore.Release();
		}
	}
}
