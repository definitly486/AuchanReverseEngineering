using System;
using System.Threading;
using System.Threading.Tasks;

namespace Akavache.Sqlite3.Internal;

public sealed class AsyncLock : IDisposable
{
	private sealed class Releaser : IDisposable
	{
		private readonly AsyncLock _toRelease;

		internal Releaser(AsyncLock toRelease)
		{
			_toRelease = toRelease;
		}

		public void Dispose()
		{
			_toRelease._semaphore.Release();
		}
	}

	private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

	private readonly Task<IDisposable?> _releaser;

	public AsyncLock()
	{
		_releaser = Task.FromResult((IDisposable)new Releaser(this));
	}

	public Task<IDisposable?> LockAsync(in CancellationToken cancellationToken = default(CancellationToken))
	{
		Task task = _semaphore.WaitAsync(cancellationToken);
		if (!task.IsCompleted || task.IsFaulted || task.IsCanceled)
		{
			return task.ContinueWith((Task task2, object? state) => (!task2.IsCanceled && state != null) ? ((IDisposable)state) : null, _releaser.Result, cancellationToken, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
		}
		return _releaser;
	}

	public void Dispose()
	{
		_semaphore?.Dispose();
		_releaser?.Dispose();
	}
}
