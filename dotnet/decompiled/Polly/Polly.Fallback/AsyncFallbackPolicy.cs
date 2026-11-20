using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Polly.Utilities;

namespace Polly.Fallback;

public class AsyncFallbackPolicy : AsyncPolicy, IFallbackPolicy, IsPolicy
{
	private readonly Func<Exception, Context, Task> _onFallbackAsync;

	private readonly Func<Exception, Context, CancellationToken, Task> _fallbackAction;

	internal AsyncFallbackPolicy(PolicyBuilder policyBuilder, Func<Exception, Context, Task> onFallbackAsync, Func<Exception, Context, CancellationToken, Task> fallbackAction)
		: base(policyBuilder)
	{
		_onFallbackAsync = onFallbackAsync;
		_fallbackAction = fallbackAction;
	}

	protected override Task ImplementationAsync(Func<Context, CancellationToken, Task> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
	{
		return AsyncFallbackEngine.ImplementationAsync(async delegate(Context ctx, CancellationToken ct)
		{
			await action(ctx, ct).ConfigureAwait(continueOnCapturedContext);
			return EmptyStruct.Instance;
		}, context, base.ExceptionPredicates, ResultPredicates<EmptyStruct>.None, (DelegateResult<EmptyStruct> outcome, Context ctx) => _onFallbackAsync(outcome.Exception, ctx), async delegate(DelegateResult<EmptyStruct> outcome, Context ctx, CancellationToken ct)
		{
			await _fallbackAction(outcome.Exception, ctx, ct).ConfigureAwait(continueOnCapturedContext);
			return EmptyStruct.Instance;
		}, continueOnCapturedContext, cancellationToken);
	}

	protected override Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
	{
		throw new InvalidOperationException("You have executed the generic .Execute<TResult> method on a non-generic FallbackPolicy.  A non-generic FallbackPolicy only defines a fallback action which returns void; it can never return a substitute TResult value.  To use FallbackPolicy to provide fallback TResult values you must define a generic fallback policy FallbackPolicy<TResult>.  For example, define the policy as Policy<TResult>.Handle<Whatever>.Fallback<TResult>(/* some TResult value or Func<..., TResult> */);");
	}
}
public class AsyncFallbackPolicy<TResult> : AsyncPolicy<TResult>, IFallbackPolicy<TResult>, IFallbackPolicy, IsPolicy
{
	private readonly Func<DelegateResult<TResult>, Context, Task> _onFallbackAsync;

	private readonly Func<DelegateResult<TResult>, Context, CancellationToken, Task<TResult>> _fallbackAction;

	internal AsyncFallbackPolicy(PolicyBuilder<TResult> policyBuilder, Func<DelegateResult<TResult>, Context, Task> onFallbackAsync, Func<DelegateResult<TResult>, Context, CancellationToken, Task<TResult>> fallbackAction)
		: base(policyBuilder)
	{
		_onFallbackAsync = onFallbackAsync;
		_fallbackAction = fallbackAction;
	}

	[DebuggerStepThrough]
	protected override Task<TResult> ImplementationAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return AsyncFallbackEngine.ImplementationAsync(action, context, base.ExceptionPredicates, base.ResultPredicates, _onFallbackAsync, _fallbackAction, continueOnCapturedContext, cancellationToken);
	}
}
