using System;
using System.Threading.Tasks;

namespace Auchan.Common.Extensions;

public static class FunctionalExtensions
{
	public static async Task<TResult> ToAsync<TSource, TResult>(this Task<TSource> sourceTask, Func<TSource, Task<TResult>> function)
	{
		return await function(await sourceTask);
	}

	public static async Task<TResult> ToAsync<TSource, TResult>(this Task<TSource> sourceTask, Func<TSource, TResult> function)
	{
		return function(await sourceTask);
	}

	public static async Task<TResult> ToAsync<TSource, TResult>(this TSource source, Func<TSource, Task<TResult>> function)
	{
		return await function(source);
	}

	public static async Task<TSource> DoAsync<TSource>(this TSource source, Func<TSource, Task> asyncAction)
	{
		await asyncAction(source);
		return source;
	}

	public static async Task<TSource> DoAsync<TSource>(this Task<TSource> sourceTask, Func<TSource, Task> asyncAction)
	{
		await asyncAction(await sourceTask);
		return await sourceTask;
	}
}
