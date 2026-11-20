using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Polly.Bulkhead;

public class AsyncBulkheadPolicy : AsyncPolicy, IBulkheadPolicy, IsPolicy, IDisposable
{
	private readonly SemaphoreSlim _maxParallelizationSemaphore;

	private readonly SemaphoreSlim _maxQueuedActionsSemaphore;

	private readonly int _maxQueueingActions;

	private readonly Func<Context, Task> _onBulkheadRejectedAsync;

	public int BulkheadAvailableCount => _maxParallelizationSemaphore.CurrentCount;

	public int QueueAvailableCount => Math.Min(_maxQueuedActionsSemaphore.CurrentCount, _maxQueueingActions);

	internal AsyncBulkheadPolicy(int maxParallelization, int maxQueueingActions, Func<Context, Task> onBulkheadRejectedAsync)
	{
		_maxQueueingActions = maxQueueingActions;
		_onBulkheadRejectedAsync = onBulkheadRejectedAsync;
		(_maxParallelizationSemaphore, _maxQueuedActionsSemaphore) = BulkheadSemaphoreFactory.CreateBulkheadSemaphores(maxParallelization, maxQueueingActions);
	}

	[DebuggerStepThrough]
	protected override Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return AsyncBulkheadEngine.ImplementationAsync(action, context, _onBulkheadRejectedAsync, _maxParallelizationSemaphore, _maxQueuedActionsSemaphore, continueOnCapturedContext, cancellationToken);
	}

	public void Dispose()
	{
		_maxParallelizationSemaphore.Dispose();
		_maxQueuedActionsSemaphore.Dispose();
		GC.SuppressFinalize(this);
	}
}
public class AsyncBulkheadPolicy<TResult> : AsyncPolicy<TResult>, IBulkheadPolicy<TResult>, IBulkheadPolicy, IsPolicy, IDisposable
{
	private readonly SemaphoreSlim _maxParallelizationSemaphore;

	private readonly SemaphoreSlim _maxQueuedActionsSemaphore;

	private readonly int _maxQueueingActions;

	private readonly Func<Context, Task> _onBulkheadRejectedAsync;

	public int BulkheadAvailableCount => _maxParallelizationSemaphore.CurrentCount;

	public int QueueAvailableCount => Math.Min(_maxQueuedActionsSemaphore.CurrentCount, _maxQueueingActions);

	internal AsyncBulkheadPolicy(int maxParallelization, int maxQueueingActions, Func<Context, Task> onBulkheadRejectedAsync)
		: base((PolicyBuilder<TResult>?)null)
	{
		_maxQueueingActions = maxQueueingActions;
		_onBulkheadRejectedAsync = onBulkheadRejectedAsync;
		(_maxParallelizationSemaphore, _maxQueuedActionsSemaphore) = BulkheadSemaphoreFactory.CreateBulkheadSemaphores(maxParallelization, maxQueueingActions);
	}

	[DebuggerStepThrough]
	protected override Task<TResult> ImplementationAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return AsyncBulkheadEngine.ImplementationAsync(action, context, _onBulkheadRejectedAsync, _maxParallelizationSemaphore, _maxQueuedActionsSemaphore, continueOnCapturedContext, cancellationToken);
	}

	public void Dispose()
	{
		_maxParallelizationSemaphore.Dispose();
		_maxQueuedActionsSemaphore.Dispose();
		GC.SuppressFinalize(this);
	}
}
