using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using NLog.Internal;

namespace NLog.Common;

public static class AsyncHelpers
{
	internal static int GetManagedThreadId()
	{
		return Thread.CurrentThread.ManagedThreadId;
	}

	internal static void StartAsyncTask(WaitCallback asyncDelegate, object? state)
	{
		ThreadPool.QueueUserWorkItem(asyncDelegate, state);
	}

	internal static void WaitForDelay(TimeSpan delay)
	{
		Thread.Sleep(delay);
	}

	[Obsolete("Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void ForEachItemSequentially<T>(IEnumerable<T> items, AsyncContinuation asyncContinuation, AsynchronousAction<T> action)
	{
		action = ExceptionGuard(action);
		IEnumerator<T> enumerator = items.GetEnumerator();
		InvokeNext(null);
		void InvokeNext(Exception? ex)
		{
			if (ex != null)
			{
				asyncContinuation(ex);
			}
			else if (!enumerator.MoveNext())
			{
				enumerator.Dispose();
				asyncContinuation(null);
			}
			else
			{
				action(enumerator.Current, PreventMultipleCalls(InvokeNext));
			}
		}
	}

	public static void Repeat(int repeatCount, AsyncContinuation asyncContinuation, AsynchronousAction action)
	{
		action = ExceptionGuard(action);
		int remaining = repeatCount;
		InvokeNext(null);
		void InvokeNext(Exception? ex)
		{
			if (ex != null)
			{
				asyncContinuation(ex);
			}
			else if (remaining-- <= 0)
			{
				asyncContinuation(null);
			}
			else
			{
				action(PreventMultipleCalls(InvokeNext));
			}
		}
	}

	[Obsolete("Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static AsyncContinuation PrecededBy(AsyncContinuation asyncContinuation, AsynchronousAction action)
	{
		action = ExceptionGuard(action);
		return delegate(Exception? ex)
		{
			if (ex != null)
			{
				asyncContinuation(ex);
			}
			else
			{
				action(PreventMultipleCalls(asyncContinuation));
			}
		};
	}

	[Obsolete("Marked obsolete on NLog 6.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static AsyncContinuation WithTimeout(AsyncContinuation asyncContinuation, TimeSpan timeout)
	{
		return new TimeoutContinuation(asyncContinuation, timeout).Function;
	}

	public static void ForEachItemInParallel<T>(IEnumerable<T> values, AsyncContinuation asyncContinuation, AsynchronousAction<T> action)
	{
		action = ExceptionGuard(action);
		List<T> list = new List<T>(values);
		int remaining = list.Count;
		List<Exception> exceptions = new List<Exception>();
		InternalLogger.Trace("ForEachItemInParallel() {0} items", list.Count);
		if (remaining == 0)
		{
			asyncContinuation(null);
			return;
		}
		AsyncContinuation continuation = delegate(Exception? ex)
		{
			InternalLogger.Trace("Continuation invoked: {0}", ex);
			if (ex != null)
			{
				lock (exceptions)
				{
					exceptions.Add(ex);
				}
			}
			int num = Interlocked.Decrement(ref remaining);
			InternalLogger.Trace("Parallel task completed. {0} items remaining", num);
			if (num == 0)
			{
				asyncContinuation(GetCombinedException(exceptions));
			}
		};
		foreach (T item in list)
		{
			T itemCopy = item;
			StartAsyncTask(delegate
			{
				AsyncContinuation asyncContinuation2 = PreventMultipleCalls(continuation);
				try
				{
					action(itemCopy, asyncContinuation2);
				}
				catch (Exception ex)
				{
					InternalLogger.Error(ex, "ForEachItemInParallel - Unhandled Exception");
					asyncContinuation2(ex);
				}
			}, null);
		}
	}

	[Obsolete("Marked obsolete on NLog 5.0")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void RunSynchronously(AsynchronousAction action)
	{
		ManualResetEvent ev = new ManualResetEvent(initialState: false);
		Exception lastException = null;
		action(PreventMultipleCalls(delegate(Exception? ex)
		{
			lastException = ex;
			ev.Set();
		}));
		ev.WaitOne();
		if (lastException != null)
		{
			throw new NLogRuntimeException("Asynchronous exception has occurred.", lastException);
		}
	}

	public static AsyncContinuation PreventMultipleCalls(AsyncContinuation asyncContinuation)
	{
		if (asyncContinuation.Target is SingleCallContinuation)
		{
			return asyncContinuation;
		}
		return new SingleCallContinuation(asyncContinuation).Function;
	}

	public static Exception? GetCombinedException(IList<Exception> exceptions)
	{
		if (exceptions.Count == 0)
		{
			return null;
		}
		if (exceptions.Count == 1)
		{
			return exceptions[0];
		}
		StringBuilder stringBuilder = new StringBuilder();
		string value = string.Empty;
		string text = "\n";
		foreach (Exception exception in exceptions)
		{
			stringBuilder.Append(value);
			stringBuilder.Append(exception.ToString());
			stringBuilder.Append(text);
			value = text;
		}
		return new NLogRuntimeException("Got multiple exceptions:\r\n" + stringBuilder);
	}

	private static AsynchronousAction ExceptionGuard(AsynchronousAction action)
	{
		return delegate(AsyncContinuation cont)
		{
			try
			{
				action(cont);
			}
			catch (Exception exception)
			{
				if (exception.MustBeRethrown())
				{
					throw;
				}
				cont(exception);
			}
		};
	}

	private static AsynchronousAction<T> ExceptionGuard<T>(AsynchronousAction<T> action)
	{
		return delegate(T argument, AsyncContinuation cont)
		{
			try
			{
				action(argument, cont);
			}
			catch (Exception exception)
			{
				if (exception.MustBeRethrown())
				{
					throw;
				}
				cont(exception);
			}
		};
	}

	internal static bool WaitForDispose(this Timer timer, TimeSpan timeout)
	{
		timer.Change(-1, -1);
		if (timeout != TimeSpan.Zero)
		{
			ManualResetEvent manualResetEvent = new ManualResetEvent(initialState: false);
			if (timer.Dispose(manualResetEvent) && !manualResetEvent.WaitOne((int)timeout.TotalMilliseconds))
			{
				return false;
			}
			manualResetEvent.Close();
		}
		else
		{
			timer.Dispose();
		}
		return true;
	}
}
