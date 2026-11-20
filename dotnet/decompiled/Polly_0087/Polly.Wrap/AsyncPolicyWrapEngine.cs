using System;
using System.Threading;
using System.Threading.Tasks;

namespace Polly.Wrap;

internal static class AsyncPolicyWrapEngine
{
	internal static Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> func, Context context, bool continueOnCapturedContext, IAsyncPolicy<TResult> outerPolicy, IAsyncPolicy<TResult> innerPolicy, CancellationToken cancellationToken)
	{
		return outerPolicy.ExecuteAsync((Context ctx, CancellationToken ct) => innerPolicy.ExecuteAsync(func, ctx, ct, continueOnCapturedContext), context, cancellationToken, continueOnCapturedContext);
	}

	internal static Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> func, Context context, bool continueOnCapturedContext, IAsyncPolicy<TResult> outerPolicy, IAsyncPolicy innerPolicy, CancellationToken cancellationToken)
	{
		return outerPolicy.ExecuteAsync((Context ctx, CancellationToken ct) => innerPolicy.ExecuteAsync(func, ctx, ct, continueOnCapturedContext), context, cancellationToken, continueOnCapturedContext);
	}

	internal static Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> func, Context context, bool continueOnCapturedContext, IAsyncPolicy outerPolicy, IAsyncPolicy<TResult> innerPolicy, CancellationToken cancellationToken)
	{
		return outerPolicy.ExecuteAsync((Context ctx, CancellationToken ct) => innerPolicy.ExecuteAsync(func, ctx, ct, continueOnCapturedContext), context, cancellationToken, continueOnCapturedContext);
	}

	internal static Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> func, Context context, bool continueOnCapturedContext, IAsyncPolicy outerPolicy, IAsyncPolicy innerPolicy, CancellationToken cancellationToken)
	{
		return outerPolicy.ExecuteAsync((Context ctx, CancellationToken ct) => innerPolicy.ExecuteAsync(func, ctx, ct, continueOnCapturedContext), context, cancellationToken, continueOnCapturedContext);
	}

	internal static Task ImplementationAsync(Func<Context, CancellationToken, Task> action, Context context, bool continueOnCapturedContext, IAsyncPolicy outerPolicy, IAsyncPolicy innerPolicy, CancellationToken cancellationToken)
	{
		return outerPolicy.ExecuteAsync((Context ctx, CancellationToken ct) => innerPolicy.ExecuteAsync(action, ctx, ct, continueOnCapturedContext), context, cancellationToken, continueOnCapturedContext);
	}
}
