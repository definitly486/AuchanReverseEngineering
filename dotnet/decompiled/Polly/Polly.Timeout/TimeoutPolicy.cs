using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Polly.Timeout;

public class TimeoutPolicy : Policy, ITimeoutPolicy, IsPolicy
{
	private readonly TimeoutStrategy _timeoutStrategy;

	private readonly Func<Context, TimeSpan> _timeoutProvider;

	private readonly Action<Context, TimeSpan, Task, Exception> _onTimeout;

	internal TimeoutPolicy(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
	{
		_timeoutProvider = timeoutProvider;
		_timeoutStrategy = timeoutStrategy;
		_onTimeout = onTimeout;
	}

	[DebuggerStepThrough]
	protected override TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return TimeoutEngine.Implementation(action, context, _timeoutProvider, _timeoutStrategy, _onTimeout, cancellationToken);
	}
}
public class TimeoutPolicy<TResult> : Policy<TResult>, ITimeoutPolicy<TResult>, ITimeoutPolicy, IsPolicy
{
	private readonly TimeoutStrategy _timeoutStrategy;

	private readonly Func<Context, TimeSpan> _timeoutProvider;

	private readonly Action<Context, TimeSpan, Task, Exception> _onTimeout;

	internal TimeoutPolicy(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
		: base((PolicyBuilder<TResult>?)null)
	{
		_timeoutProvider = timeoutProvider;
		_timeoutStrategy = timeoutStrategy;
		_onTimeout = onTimeout;
	}

	protected override TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return TimeoutEngine.Implementation(action, context, _timeoutProvider, _timeoutStrategy, _onTimeout, cancellationToken);
	}
}
