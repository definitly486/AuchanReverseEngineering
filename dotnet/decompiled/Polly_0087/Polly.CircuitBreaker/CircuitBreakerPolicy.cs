using System;
using System.Diagnostics;
using System.Threading;
using Polly.Utilities;

namespace Polly.CircuitBreaker;

public class CircuitBreakerPolicy : Policy, ICircuitBreakerPolicy, IsPolicy
{
	internal readonly ICircuitController<EmptyStruct> BreakerController;

	public CircuitState CircuitState => BreakerController.CircuitState;

	public Exception LastException => BreakerController.LastException;

	internal CircuitBreakerPolicy(PolicyBuilder policyBuilder, ICircuitController<EmptyStruct> breakerController)
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
	protected override TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
	{
		TResult result = default(TResult);
		CircuitBreakerEngine.Implementation(delegate(Context ctx, CancellationToken ct)
		{
			result = action(ctx, ct);
			return EmptyStruct.Instance;
		}, context, base.ExceptionPredicates, ResultPredicates<EmptyStruct>.None, BreakerController, cancellationToken);
		return result;
	}
}
public class CircuitBreakerPolicy<TResult> : Policy<TResult>, ICircuitBreakerPolicy<TResult>, ICircuitBreakerPolicy, IsPolicy
{
	internal readonly ICircuitController<TResult> BreakerController;

	public CircuitState CircuitState => BreakerController.CircuitState;

	public Exception LastException => BreakerController.LastException;

	public TResult LastHandledResult => BreakerController.LastHandledResult;

	internal CircuitBreakerPolicy(PolicyBuilder<TResult> policyBuilder, ICircuitController<TResult> breakerController)
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
	protected override TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
	{
		if (action == null)
		{
			throw new ArgumentNullException("action");
		}
		return CircuitBreakerEngine.Implementation(action, context, base.ExceptionPredicates, base.ResultPredicates, BreakerController, cancellationToken);
	}
}
