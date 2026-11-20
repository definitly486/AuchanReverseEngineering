using System;
using System.Threading;
using NLog.Common;

namespace NLog.Internal;

internal sealed class SingleCallContinuation
{
	internal static readonly AsyncContinuation Completed = new SingleCallContinuation(null).CompletedFunction;

	private AsyncContinuation? _asyncContinuation;

	public SingleCallContinuation(AsyncContinuation? asyncContinuation)
	{
		_asyncContinuation = asyncContinuation;
	}

	public void Function(Exception? exception)
	{
		try
		{
			Interlocked.Exchange(ref _asyncContinuation, null)?.Invoke(exception);
		}
		catch (Exception ex)
		{
			InternalLogger.Error(ex, "Exception in asynchronous handler.");
			if (ex.MustBeRethrown())
			{
				throw;
			}
		}
	}

	private void CompletedFunction(Exception? exception)
	{
	}
}
