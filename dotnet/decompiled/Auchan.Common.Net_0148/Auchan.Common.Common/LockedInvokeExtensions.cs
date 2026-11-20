using System;

namespace Auchan.Common.Common;

public static class LockedInvokeExtensions
{
	public static void LockedInvoke<T>(this T instance, Action<T> action) where T : class
	{
		lock (instance)
		{
			action(instance);
		}
	}

	public static TResult LockedInvoke<T, TResult>(this T instance, Func<T, TResult> action) where T : class
	{
		lock (instance)
		{
			return action(instance);
		}
	}
}
