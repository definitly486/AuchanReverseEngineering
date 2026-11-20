using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Auchan.Common.Common;

public abstract class BrokeredParameter
{
}
public abstract class BrokeredParameter<TResult> : BrokeredParameter
{
	public TaskCompletionSource<TResult> TaskCompletionSource { get; } = new TaskCompletionSource<TResult>();

	public CancellationToken CancellationToken { get; }

	protected BrokeredParameter(CancellationToken cancellationToken = default(CancellationToken))
	{
		CancellationToken = cancellationToken;
	}

	public Task<TResult> WaitForResultAsync()
	{
		return TaskCompletionSource.Task;
	}

	public TaskAwaiter<TResult> GetAwaiter()
	{
		return TaskCompletionSource.Task.GetAwaiter();
	}
}
