using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Polly.Fallback;

internal static class AsyncFallbackEngine
{
	[DebuggerDisableUserUnhandledExceptions]
	internal static async Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, ExceptionPredicates shouldHandleExceptionPredicates, ResultPredicates<TResult> shouldHandleResultPredicates, Func<DelegateResult<TResult>, Context, Task> onFallbackAsync, Func<DelegateResult<TResult>, Context, CancellationToken, Task<TResult>> fallbackAction, bool continueOnCapturedContext, CancellationToken cancellationToken)
	{
		DelegateResult<TResult> delegateOutcome;
		try
		{
			cancellationToken.ThrowIfCancellationRequested();
			TResult result = await action(context, cancellationToken).ConfigureAwait(continueOnCapturedContext);
			if (!shouldHandleResultPredicates.AnyMatch(result))
			{
				return result;
			}
			delegateOutcome = new DelegateResult<TResult>(result);
		}
		catch (Exception ex)
		{
			Exception ex2 = shouldHandleExceptionPredicates.FirstMatchOrDefault(ex);
			if (ex2 == null)
			{
				throw;
			}
			delegateOutcome = new DelegateResult<TResult>(ex2);
		}
		await onFallbackAsync(delegateOutcome, context).ConfigureAwait(continueOnCapturedContext);
		return await fallbackAction(delegateOutcome, context, cancellationToken).ConfigureAwait(continueOnCapturedContext);
	}
}
