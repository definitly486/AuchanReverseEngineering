using System;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;

namespace AsyncAwaitBestPractices;

public static class SafeFireAndForgetExtensions
{
	private static Action<Exception>? _onException;

	private static bool _shouldAlwaysRethrowException;

	public static void SetDefaultExceptionHandling(Action<Exception> onException)
	{
		SetDefaultExceptionHandling(in onException);
	}

	public static void SafeFireAndForget(this Task task, in Action<Exception>? onException = null, in bool continueOnCapturedContext = false)
	{
		HandleSafeFireAndForget(task, continueOnCapturedContext, onException);
	}

	public static void SetDefaultExceptionHandling(in Action<Exception> onException)
	{
		_onException = onException ?? throw new ArgumentNullException("onException");
	}

	private static async void HandleSafeFireAndForget<TException>(Task task, bool continueOnCapturedContext, Action<TException>? onException) where TException : Exception
	{
		try
		{
			await task.ConfigureAwait(continueOnCapturedContext);
		}
		catch (TException exception) when (_onException != null || onException != null)
		{
			HandleException(in exception, in onException);
			if (_shouldAlwaysRethrowException)
			{
				ExceptionDispatchInfo.Throw(exception);
			}
		}
	}

	private static void HandleException<TException>(in TException exception, in Action<TException>? onException) where TException : Exception
	{
		_onException?.Invoke(exception);
		onException?.Invoke(exception);
	}
}
