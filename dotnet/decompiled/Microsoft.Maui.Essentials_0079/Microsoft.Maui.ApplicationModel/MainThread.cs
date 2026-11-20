using System;
using System.Threading.Tasks;
using Android.OS;

namespace Microsoft.Maui.ApplicationModel;

public static class MainThread
{
	private static volatile Handler handler;

	public static bool IsMainThread => PlatformIsMainThread;

	private static bool PlatformIsMainThread
	{
		get
		{
			if (OperatingSystem.IsAndroidVersionAtLeast(23))
			{
				return Looper.MainLooper.IsCurrentThread;
			}
			return Looper.MyLooper() == Looper.MainLooper;
		}
	}

	public static void BeginInvokeOnMainThread(Action action)
	{
		if (IsMainThread)
		{
			action();
		}
		else
		{
			PlatformBeginInvokeOnMainThread(action);
		}
	}

	public static Task InvokeOnMainThreadAsync(Action action)
	{
		if (IsMainThread)
		{
			action();
			return Task.CompletedTask;
		}
		TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
		BeginInvokeOnMainThread(delegate
		{
			try
			{
				action();
				tcs.TrySetResult(result: true);
			}
			catch (Exception exception)
			{
				tcs.TrySetException(exception);
			}
		});
		return tcs.Task;
	}

	public static Task<T> InvokeOnMainThreadAsync<T>(Func<T> func)
	{
		if (IsMainThread)
		{
			return Task.FromResult(func());
		}
		TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
		BeginInvokeOnMainThread(delegate
		{
			try
			{
				T result = func();
				tcs.TrySetResult(result);
			}
			catch (Exception exception)
			{
				tcs.TrySetException(exception);
			}
		});
		return tcs.Task;
	}

	public static Task InvokeOnMainThreadAsync(Func<Task> funcTask)
	{
		if (IsMainThread)
		{
			return funcTask();
		}
		TaskCompletionSource<object> tcs = new TaskCompletionSource<object>();
		BeginInvokeOnMainThread(async delegate
		{
			try
			{
				await funcTask().ConfigureAwait(continueOnCapturedContext: false);
				tcs.SetResult(null);
			}
			catch (Exception exception)
			{
				tcs.SetException(exception);
			}
		});
		return tcs.Task;
	}

	public static Task<T> InvokeOnMainThreadAsync<T>(Func<Task<T>> funcTask)
	{
		if (IsMainThread)
		{
			return funcTask();
		}
		TaskCompletionSource<T> tcs = new TaskCompletionSource<T>();
		BeginInvokeOnMainThread(async delegate
		{
			try
			{
				T result = await funcTask().ConfigureAwait(continueOnCapturedContext: false);
				tcs.SetResult(result);
			}
			catch (Exception exception)
			{
				tcs.SetException(exception);
			}
		});
		return tcs.Task;
	}

	private static void PlatformBeginInvokeOnMainThread(Action action)
	{
		if (handler?.Looper != Looper.MainLooper)
		{
			handler = new Handler(Looper.MainLooper);
		}
		handler.Post(action);
	}
}
