using System;
using System.Threading.Tasks;

namespace Auchan.Common.Extensions;

public static class WeakReferenceExtensions
{
	public static void Invoke<T>(this WeakReference<T>? @this, Action<T> action) where T : class
	{
		if (@this != null && @this.TryGetTarget(out T target))
		{
			action(target);
		}
	}

	public static R Invoke<T, R>(this WeakReference<T>? @this, Func<T?, R> func) where T : class
	{
		if (@this == null)
		{
			return func(null);
		}
		if (@this.TryGetTarget(out T target))
		{
			return func(target);
		}
		return func(null);
	}

	public static Task InvokeAsync<T>(this WeakReference<T>? @this, Func<T, Task> asyncAction) where T : class
	{
		if (@this == null)
		{
			return Task.CompletedTask;
		}
		if (@this.TryGetTarget(out T target))
		{
			return asyncAction(target);
		}
		return Task.CompletedTask;
	}
}
