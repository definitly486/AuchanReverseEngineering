using System;
using System.Diagnostics;
using System.Threading;

namespace Polly.Bulkhead;

public class BulkheadPolicy : Policy, IBulkheadPolicy, IsPolicy, IDisposable
{
	private readonly SemaphoreSlim _maxParallelizationSemaphore;

	private readonly SemaphoreSlim _maxQueuedActionsSemaphore;

	private readonly int _maxQueueingActions;

	private readonly Action<Context> _onBulkheadRejected;

	public int BulkheadAvailableCount => _maxParallelizationSemaphore.CurrentCount;

	public int QueueAvailableCount => Math.Min(_maxQueuedActionsSemaphore.CurrentCount, _maxQueueingActions);

	internal BulkheadPolicy(int maxParallelization, int maxQueueingActions, Action<Context> onBulkheadRejected)
	{
		_maxQueueingActions = maxQueueingActions;
		_onBulkheadRejected = onBulkheadRejected;
		(_maxParallelizationSemaphore, _maxQueuedActionsSemaphore) = BulkheadSemaphoreFactory.CreateBulkheadSemaphores(maxParallelization, maxQueueingActions);
	}

	[DebuggerStepThrough]
	protected override TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return BulkheadEngine.Implementation(action, context, _onBulkheadRejected, _maxParallelizationSemaphore, _maxQueuedActionsSemaphore, cancellationToken);
	}

	public void Dispose()
	{
		_maxParallelizationSemaphore.Dispose();
		_maxQueuedActionsSemaphore.Dispose();
		GC.SuppressFinalize(this);
	}
}
public class BulkheadPolicy<TResult> : Policy<TResult>, IBulkheadPolicy<TResult>, IBulkheadPolicy, IsPolicy, IDisposable
{
	private readonly SemaphoreSlim _maxParallelizationSemaphore;

	private readonly SemaphoreSlim _maxQueuedActionsSemaphore;

	private readonly int _maxQueueingActions;

	private readonly Action<Context> _onBulkheadRejected;

	public int BulkheadAvailableCount => _maxParallelizationSemaphore.CurrentCount;

	public int QueueAvailableCount => Math.Min(_maxQueuedActionsSemaphore.CurrentCount, _maxQueueingActions);

	internal BulkheadPolicy(int maxParallelization, int maxQueueingActions, Action<Context> onBulkheadRejected)
		: base((PolicyBuilder<TResult>?)null)
	{
		_maxQueueingActions = maxQueueingActions;
		_onBulkheadRejected = onBulkheadRejected;
		(_maxParallelizationSemaphore, _maxQueuedActionsSemaphore) = BulkheadSemaphoreFactory.CreateBulkheadSemaphores(maxParallelization, maxQueueingActions);
	}

	[DebuggerStepThrough]
	protected override TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return BulkheadEngine.Implementation(action, context, _onBulkheadRejected, _maxParallelizationSemaphore, _maxQueuedActionsSemaphore, cancellationToken);
	}

	public void Dispose()
	{
		_maxParallelizationSemaphore.Dispose();
		_maxQueuedActionsSemaphore.Dispose();
		GC.SuppressFinalize(this);
	}
}
