using System;
using System.Diagnostics;
using System.Threading;

namespace Polly.Fallback;

internal static class FallbackEngine
{
	[DebuggerDisableUserUnhandledExceptions]
	internal static TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, ExceptionPredicates shouldHandleExceptionPredicates, ResultPredicates<TResult> shouldHandleResultPredicates, Action<DelegateResult<TResult>, Context> onFallback, Func<DelegateResult<TResult>, Context, CancellationToken, TResult> fallbackAction, CancellationToken cancellationToken)
	{
		DelegateResult<TResult> arg;
		try
		{
			cancellationToken.ThrowIfCancellationRequested();
			TResult result = action(context, cancellationToken);
			if (!shouldHandleResultPredicates.AnyMatch(result))
			{
				return result;
			}
			arg = new DelegateResult<TResult>(result);
		}
		catch (Exception ex)
		{
			Exception ex2 = shouldHandleExceptionPredicates.FirstMatchOrDefault(ex);
			if (ex2 == null)
			{
				throw;
			}
			arg = new DelegateResult<TResult>(ex2);
		}
		onFallback(arg, context);
		return fallbackAction(arg, context, cancellationToken);
	}
}
