using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Polly.Utilities;

namespace Polly.CircuitBreaker;

public class AsyncCircuitBreakerPolicy : AsyncPolicy, ICircuitBreakerPolicy, IsPolicy
{
	internal readonly ICircuitController<EmptyStruct> BreakerController;

	public CircuitState CircuitState => BreakerController.CircuitState;

	public Exception LastException => BreakerController.LastException;

	internal AsyncCircuitBreakerPolicy(PolicyBuilder policyBuilder, ICircuitController<EmptyStruct> breakerController)
		: base(policyBuilder)
	{
		BreakerController = breakerController;
	}

	public void Isolate()
	{
		BreakerController.Isolate();
	}

	public void Reset()
	{
		BreakerController.Reset();
	}

	protected override async Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
	{
		TResult result = default(TResult);
		await AsyncCircuitBreakerEngine.ImplementationAsync(async delegate(Context ctx, CancellationToken ct)
		{
			result = await action(ctx, ct).ConfigureAwait(continueOnCapturedContext);
			return EmptyStruct.Instance;
		}, context, continueOnCapturedContext, base.ExceptionPredicates, ResultPredicates<EmptyStruct>.None, BreakerController, cancellationToken).ConfigureAwait(continueOnCapturedContext);
		return result;
	}
}
public class AsyncCircuitBreakerPolicy<TResult> : AsyncPolicy<TResult>, ICircuitBreakerPolicy<TResult>, ICircuitBreakerPolicy, IsPolicy
{
	internal readonly ICircuitController<TResult> BreakerController;

	public CircuitState CircuitState => BreakerController.CircuitState;

	public Exception LastException => BreakerController.LastException;

	public TResult LastHandledResult => BreakerController.LastHandledResult;

	internal AsyncCircuitBreakerPolicy(PolicyBuilder<TResult> policyBuilder, ICircuitController<TResult> breakerController)
		: base(policyBuilder)
	{
		BreakerController = breakerController;
	}

	public void Isolate()
	{
		BreakerController.Isolate();
	}

	public void Reset()
	{
		BreakerController.Reset();
	}

	[DebuggerStepThrough]
	protected override Task<TResult> ImplementationAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return AsyncCircuitBreakerEngine.ImplementationAsync(action, context, continueOnCapturedContext, base.ExceptionPredicates, base.ResultPredicates, BreakerController, cancellationToken);
	}
}
