using System;
using System.Threading;
using System.Threading.Tasks;

namespace Websocket.Client.Threading;

public class WebsocketAsyncLock
{
	private class Releaser : IDisposable
	{
		private readonly SemaphoreSlim _semaphore;

		public Releaser(SemaphoreSlim semaphore)
		{
			_semaphore = semaphore;
		}

		public void Dispose()
		{
			_semaphore.Release();
		}
	}

	private readonly Task<IDisposable> _releaserTask;

	private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

	private readonly IDisposable _releaser;

	public WebsocketAsyncLock()
	{
		_releaser = new Releaser(_semaphore);
		_releaserTask = Task.FromResult(_releaser);
	}

	public Task<IDisposable> LockAsync()
	{
		Task task = _semaphore.WaitAsync();
		if (!task.IsCompleted)
		{
			return task.ContinueWith((Task _, object? releaser) => (IDisposable)releaser, _releaser, CancellationToken.None, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
		}
		return _releaserTask;
	}
}
