using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions;

public static class AsyncResultExtensionsLeftOperand
{
	public static async Task<Result<K, E>> Bind<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Result<K, E>> func)
	{
		return (await resultTask.DefaultAwait()).Bind(func);
	}

	public static async Task<Result<K>> Bind<T, K>(this Task<Result<T>> resultTask, Func<T, Result<K>> func)
	{
		return (await resultTask.DefaultAwait()).Bind(func);
	}

	public static async Task<Result<K>> Bind<K>(this Task<Result> resultTask, Func<Result<K>> func)
	{
		return (await resultTask.DefaultAwait()).Bind(func);
	}

	public static async Task<Result> Bind<T>(this Task<Result<T>> resultTask, Func<T, Result> func)
	{
		return (await resultTask.DefaultAwait()).Bind(func);
	}

	public static async Task<Result> Bind(this Task<Result> resultTask, Func<Result> func)
	{
		return (await resultTask.DefaultAwait()).Bind(func);
	}

	public static async Task<UnitResult<E>> Bind<E>(this Task<UnitResult<E>> resultTask, Func<UnitResult<E>> func)
	{
		return (await resultTask.DefaultAwait()).Bind(func);
	}

	public static async Task<Result<T, E>> Bind<T, E>(this Task<UnitResult<E>> resultTask, Func<Result<T, E>> func)
	{
		return (await resultTask.DefaultAwait()).Bind(func);
	}

	public static async Task<UnitResult<E>> Bind<T, E>(this Task<Result<T, E>> resultTask, Func<T, UnitResult<E>> func)
	{
		return (await resultTask.DefaultAwait()).Bind(func);
	}

	public static async Task<Result> BindTry(this Task<Result> resultTask, Func<Result> func, Func<Exception, string> errorHandler = null)
	{
		return (await resultTask.DefaultAwait()).BindTry(func, errorHandler);
	}

	public static async Task<Result<K>> BindTry<K>(this Task<Result> resultTask, Func<Result<K>> func, Func<Exception, string> errorHandler = null)
	{
		return (await resultTask.DefaultAwait()).BindTry(func, errorHandler);
	}

	public static async Task<Result> BindTry<T>(this Task<Result<T>> resultTask, Func<T, Result> func, Func<Exception, string> errorHandler = null)
	{
		return (await resultTask.DefaultAwait()).BindTry(func, errorHandler);
	}

	public static async Task<Result<K>> BindTry<T, K>(this Task<Result<T>> resultTask, Func<T, Result<K>> func, Func<Exception, string> errorHandler = null)
	{
		return (await resultTask.DefaultAwait()).BindTry(func, errorHandler);
	}

	public static async Task<UnitResult<E>> BindTry<T, E>(this Task<Result<T, E>> resultTask, Func<T, UnitResult<E>> func, Func<Exception, E> errorHandler)
	{
		return (await resultTask.DefaultAwait()).BindTry(func, errorHandler);
	}

	public static async Task<Result<K, E>> BindTry<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Result<K, E>> func, Func<Exception, E> errorHandler)
	{
		return (await resultTask.DefaultAwait()).BindTry(func, errorHandler);
	}

	public static async Task<UnitResult<E>> BindTry<E>(this Task<UnitResult<E>> resultTask, Func<UnitResult<E>> func, Func<Exception, E> errorHandler)
	{
		return (await resultTask.DefaultAwait()).BindTry(func, errorHandler);
	}

	public static async Task<Result<T, E>> BindTry<T, E>(this Task<UnitResult<E>> resultTask, Func<Result<T, E>> func, Func<Exception, E> errorHandler)
	{
		return (await resultTask.DefaultAwait()).BindTry(func, errorHandler);
	}

	public static async Task<Result<T>> Check<T>(this Task<Result<T>> resultTask, Func<T, Result> func)
	{
		return (await resultTask.DefaultAwait()).Check(func);
	}

	public static async Task<Result<T>> Check<T, K>(this Task<Result<T>> resultTask, Func<T, Result<K>> func)
	{
		return (await resultTask.DefaultAwait()).Check(func);
	}

	public static async Task<Result<T, E>> Check<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Result<K, E>> func)
	{
		return (await resultTask.DefaultAwait()).Check(func);
	}

	public static async Task<Result<T, E>> Check<T, E>(this Task<Result<T, E>> resultTask, Func<T, UnitResult<E>> func)
	{
		return (await resultTask.DefaultAwait()).Check(func);
	}

	public static async Task<UnitResult<E>> Check<E>(this Task<UnitResult<E>> resultTask, Func<UnitResult<E>> func)
	{
		return (await resultTask.DefaultAwait()).Check(func);
	}

	public static Task<Result<T>> CheckIf<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Result> func)
	{
		if (condition)
		{
			return resultTask.Check(func);
		}
		return resultTask;
	}

	public static Task<Result<T>> CheckIf<T, K>(this Task<Result<T>> resultTask, bool condition, Func<T, Result<K>> func)
	{
		if (condition)
		{
			return resultTask.Check(func);
		}
		return resultTask;
	}

	public static Task<Result<T, E>> CheckIf<T, K, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, Result<K, E>> func)
	{
		if (condition)
		{
			return resultTask.Check(func);
		}
		return resultTask;
	}

	public static Task<Result<T, E>> CheckIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, UnitResult<E>> func)
	{
		if (condition)
		{
			return resultTask.Check(func);
		}
		return resultTask;
	}

	public static Task<UnitResult<E>> CheckIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Func<UnitResult<E>> func)
	{
		if (condition)
		{
			return resultTask.Check(func);
		}
		return resultTask;
	}

	public static async Task<Result<T>> CheckIf<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(func);
		}
		return result;
	}

	public static async Task<Result<T>> CheckIf<T, K>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<K>> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(func);
		}
		return result;
	}

	public static async Task<Result<T, E>> CheckIf<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Result<K, E>> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(func);
		}
		return result;
	}

	public static async Task<Result<T, E>> CheckIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, UnitResult<E>> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(func);
		}
		return result;
	}

	public static async Task<UnitResult<E>> CheckIf<E>(this Task<UnitResult<E>> resultTask, Func<bool> predicate, Func<UnitResult<E>> func)
	{
		UnitResult<E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate())
		{
			return result.Check(func);
		}
		return result;
	}

	public static async Task<Result> Combine(this IEnumerable<Task<Result>> tasks, string errorMessageSeparator = null)
	{
		return (await Task.WhenAll(tasks).DefaultAwait()).Combine(errorMessageSeparator);
	}

	public static async Task<Result<IEnumerable<T>, E>> Combine<T, E>(this IEnumerable<Task<Result<T, E>>> tasks, Func<IEnumerable<E>, E> composerError)
	{
		return (await Task.WhenAll(tasks).DefaultAwait()).Combine(composerError);
	}

	public static async Task<Result<IEnumerable<T>, E>> Combine<T, E>(this IEnumerable<Task<Result<T, E>>> tasks) where E : ICombine
	{
		return (await Task.WhenAll(tasks).DefaultAwait()).Combine();
	}

	public static async Task<Result<IEnumerable<T>>> Combine<T>(this IEnumerable<Task<Result<T>>> tasks, string errorMessageSeparator = null)
	{
		return (await Task.WhenAll(tasks).DefaultAwait()).Combine(errorMessageSeparator);
	}

	public static async Task<Result> Combine(this Task<IEnumerable<Result>> task, string errorMessageSeparator = null)
	{
		return (await task.DefaultAwait()).Combine(errorMessageSeparator);
	}

	public static async Task<Result<IEnumerable<T>, E>> Combine<T, E>(this Task<IEnumerable<Result<T, E>>> task, Func<IEnumerable<E>, E> composerError)
	{
		return (await task.DefaultAwait()).Combine(composerError);
	}

	public static async Task<Result<IEnumerable<T>, E>> Combine<T, E>(this Task<IEnumerable<Result<T, E>>> task) where E : ICombine
	{
		return (await task.DefaultAwait()).Combine();
	}

	public static async Task<Result<IEnumerable<T>>> Combine<T>(this Task<IEnumerable<Result<T>>> task, string errorMessageSeparator = null)
	{
		return (await task.DefaultAwait()).Combine(errorMessageSeparator);
	}

	public static async Task<Result> Combine(this Task<IEnumerable<Task<Result>>> task, string errorMessageSeparator = null)
	{
		return await (await task.DefaultAwait()).Combine(errorMessageSeparator).DefaultAwait();
	}

	public static async Task<Result<IEnumerable<T>, E>> Combine<T, E>(this Task<IEnumerable<Task<Result<T, E>>>> task, Func<IEnumerable<E>, E> composerError)
	{
		return await (await task.DefaultAwait()).Combine(composerError).DefaultAwait();
	}

	public static async Task<Result<IEnumerable<T>, E>> Combine<T, E>(this Task<IEnumerable<Task<Result<T, E>>>> task) where E : ICombine
	{
		return await (await task.DefaultAwait()).Combine().DefaultAwait();
	}

	public static async Task<Result<IEnumerable<T>>> Combine<T>(this Task<IEnumerable<Task<Result<T>>>> task, string errorMessageSeparator = null)
	{
		return await (await task.DefaultAwait()).Combine(errorMessageSeparator).DefaultAwait();
	}

	public static async Task<Result<K, E>> Combine<T, K, E>(this IEnumerable<Task<Result<T, E>>> tasks, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
	{
		return (await Task.WhenAll(tasks).DefaultAwait()).Combine(composer, composerError);
	}

	public static async Task<Result<K, E>> Combine<T, K, E>(this IEnumerable<Task<Result<T, E>>> tasks, Func<IEnumerable<T>, K> composer) where E : ICombine
	{
		return (await Task.WhenAll(tasks).DefaultAwait()).Combine(composer);
	}

	public static async Task<Result<K>> Combine<T, K>(this IEnumerable<Task<Result<T>>> tasks, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
	{
		return (await Task.WhenAll(tasks).DefaultAwait()).Combine(composer, errorMessageSeparator);
	}

	public static async Task<Result<K, E>> Combine<T, K, E>(this Task<IEnumerable<Task<Result<T, E>>>> task, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
	{
		return await (await task.DefaultAwait()).Combine(composer, composerError).DefaultAwait();
	}

	public static async Task<Result<K, E>> Combine<T, K, E>(this Task<IEnumerable<Task<Result<T, E>>>> task, Func<IEnumerable<T>, K> composer) where E : ICombine
	{
		return await (await task.DefaultAwait()).Combine(composer).DefaultAwait();
	}

	public static async Task<Result<K>> Combine<T, K>(this Task<IEnumerable<Task<Result<T>>>> task, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
	{
		return await (await task.DefaultAwait()).Combine(composer, errorMessageSeparator).DefaultAwait();
	}

	public static async Task<Result> CombineInOrder(this IEnumerable<Task<Result>> tasks, string errorMessageSeparator = null)
	{
		return (await CompleteInOrder(tasks).DefaultAwait()).Combine(errorMessageSeparator);
	}

	public static async Task<Result<IEnumerable<T>, E>> CombineInOrder<T, E>(this IEnumerable<Task<Result<T, E>>> tasks, Func<IEnumerable<E>, E> composerError)
	{
		return (await CompleteInOrder(tasks).DefaultAwait()).Combine(composerError);
	}

	public static async Task<Result<IEnumerable<T>, E>> CombineInOrder<T, E>(this IEnumerable<Task<Result<T, E>>> tasks) where E : ICombine
	{
		return (await CompleteInOrder(tasks).DefaultAwait()).Combine();
	}

	public static async Task<Result<IEnumerable<T>>> CombineInOrder<T>(this IEnumerable<Task<Result<T>>> tasks, string errorMessageSeparator = null)
	{
		return (await CompleteInOrder(tasks).DefaultAwait()).Combine(errorMessageSeparator);
	}

	public static async Task<Result> CombineInOrder(this Task<IEnumerable<Task<Result>>> task, string errorMessageSeparator = null)
	{
		return await (await task.DefaultAwait()).CombineInOrder(errorMessageSeparator).DefaultAwait();
	}

	public static async Task<Result<IEnumerable<T>, E>> CombineInOrder<T, E>(this Task<IEnumerable<Task<Result<T, E>>>> task, Func<IEnumerable<E>, E> composerError)
	{
		return await (await task.DefaultAwait()).CombineInOrder(composerError).DefaultAwait();
	}

	public static async Task<Result<IEnumerable<T>, E>> CombineInOrder<T, E>(this Task<IEnumerable<Task<Result<T, E>>>> task) where E : ICombine
	{
		return await (await task.DefaultAwait()).CombineInOrder().DefaultAwait();
	}

	public static async Task<Result<IEnumerable<T>>> CombineInOrder<T>(this Task<IEnumerable<Task<Result<T>>>> task, string errorMessageSeparator = null)
	{
		return await (await task.DefaultAwait()).CombineInOrder(errorMessageSeparator).DefaultAwait();
	}

	public static async Task<Result<K, E>> CombineInOrder<T, K, E>(this IEnumerable<Task<Result<T, E>>> tasks, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
	{
		return (await CompleteInOrder(tasks).DefaultAwait()).Combine(composer, composerError);
	}

	public static async Task<Result<K, E>> CombineInOrder<T, K, E>(this IEnumerable<Task<Result<T, E>>> tasks, Func<IEnumerable<T>, K> composer) where E : ICombine
	{
		return (await CompleteInOrder(tasks).DefaultAwait()).Combine(composer);
	}

	public static async Task<Result<K>> CombineInOrder<T, K>(this IEnumerable<Task<Result<T>>> tasks, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
	{
		return (await CompleteInOrder(tasks).DefaultAwait()).Combine(composer, errorMessageSeparator);
	}

	public static async Task<Result<K, E>> CombineInOrder<T, K, E>(this Task<IEnumerable<Task<Result<T, E>>>> task, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
	{
		return await (await task.DefaultAwait()).CombineInOrder(composer, composerError).DefaultAwait();
	}

	public static async Task<Result<K, E>> CombineInOrder<T, K, E>(this Task<IEnumerable<Task<Result<T, E>>>> task, Func<IEnumerable<T>, K> composer) where E : ICombine
	{
		return await (await task.DefaultAwait()).CombineInOrder(composer).DefaultAwait();
	}

	public static async Task<Result<K>> CombineInOrder<T, K>(this Task<IEnumerable<Task<Result<T>>>> task, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
	{
		return await (await task.DefaultAwait()).CombineInOrder(composer, errorMessageSeparator).DefaultAwait();
	}

	public static async Task<T[]> CompleteInOrder<T>(IEnumerable<Task<T>> tasks)
	{
		List<T> results = new List<T>();
		foreach (Task<T> task in tasks)
		{
			List<T> list = results;
			list.Add(await task.DefaultAwait());
		}
		return results.ToArray();
	}

	public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, string errorMessage)
	{
		return (await resultTask.DefaultAwait()).Ensure(predicate, errorMessage);
	}

	public static async Task<Result<T, E>> Ensure<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, E error)
	{
		return (await resultTask.DefaultAwait()).Ensure(predicate, error);
	}

	public static async Task<Result<T, E>> Ensure<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, E> errorPredicate)
	{
		return (await resultTask.DefaultAwait()).Ensure(predicate, errorPredicate);
	}

	public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, string> errorPredicate)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return result;
		}
		return result.Ensure(predicate, errorPredicate);
	}

	public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task<string>> errorPredicate)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return result;
		}
		if (predicate(result.Value))
		{
			return result;
		}
		return Result.Failure<T>(await errorPredicate(result.Value).DefaultAwait());
	}

	public static async Task<Result> Ensure(this Task<Result> resultTask, Func<bool> predicate, string errorMessage)
	{
		return (await resultTask.DefaultAwait()).Ensure(predicate, errorMessage);
	}

	public static async Task<Result> Ensure(this Task<Result> resultTask, Func<Result> predicate)
	{
		return (await resultTask.DefaultAwait()).Ensure(predicate);
	}

	public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<Result> predicate)
	{
		return (await resultTask.DefaultAwait()).Ensure(predicate);
	}

	public static async Task<Result> Ensure<T>(this Task<Result> resultTask, Func<Result<T>> predicate)
	{
		return (await resultTask.DefaultAwait()).Ensure(predicate);
	}

	public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<Result<T>> predicate)
	{
		return (await resultTask.DefaultAwait()).Ensure(predicate);
	}

	public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, Result> predicate)
	{
		return (await resultTask.DefaultAwait()).Ensure(predicate);
	}

	public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, Result<T>> predicate)
	{
		return (await resultTask.DefaultAwait()).Ensure(predicate);
	}

	public static async Task<T> Finally<T>(this Task<Result> resultTask, Func<Result, T> func)
	{
		return (await resultTask.DefaultAwait()).Finally(func);
	}

	public static async Task<K> Finally<T, K>(this Task<Result<T>> resultTask, Func<Result<T>, K> func)
	{
		return (await resultTask.DefaultAwait()).Finally(func);
	}

	public static async Task<K> Finally<K, E>(this Task<UnitResult<E>> resultTask, Func<UnitResult<E>, K> func)
	{
		return (await resultTask.DefaultAwait()).Finally(func);
	}

	public static async Task<K> Finally<T, K, E>(this Task<Result<T, E>> resultTask, Func<Result<T, E>, K> func)
	{
		return (await resultTask.DefaultAwait()).Finally(func);
	}

	public static async Task<Result<K, E>> Map<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, K> func)
	{
		return (await resultTask.DefaultAwait()).Map(func);
	}

	public static async Task<Result<K, E>> Map<T, K, E, TContext>(this Task<Result<T, E>> resultTask, Func<T, TContext, K> func, TContext context)
	{
		return (await resultTask.DefaultAwait()).Map(func, context);
	}

	public static async Task<Result<K, E>> Map<K, E>(this Task<UnitResult<E>> resultTask, Func<K> func)
	{
		return (await resultTask.DefaultAwait()).Map(func);
	}

	public static async Task<Result<K, E>> Map<K, E, TContext>(this Task<UnitResult<E>> resultTask, Func<TContext, K> func, TContext context)
	{
		return (await resultTask.DefaultAwait()).Map(func, context);
	}

	public static async Task<Result<K>> Map<T, K>(this Task<Result<T>> resultTask, Func<T, K> func)
	{
		return (await resultTask.DefaultAwait()).Map(func);
	}

	public static async Task<Result<K>> Map<T, K, TContext>(this Task<Result<T>> resultTask, Func<T, TContext, K> func, TContext context)
	{
		return (await resultTask.DefaultAwait()).Map(func, context);
	}

	public static async Task<Result<K>> Map<K>(this Task<Result> resultTask, Func<K> func)
	{
		return (await resultTask.DefaultAwait()).Map(func);
	}

	public static async Task<Result<K>> Map<K, TContext>(this Task<Result> resultTask, Func<TContext, K> func, TContext context)
	{
		return (await resultTask.DefaultAwait()).Map(func, context);
	}

	public static async Task<Result<K, E>> MapTry<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, K> func, Func<Exception, E> errorHandler)
	{
		return (await resultTask.DefaultAwait()).MapTry(func, errorHandler);
	}

	public static async Task<Result<K, E>> MapTry<K, E>(this Task<UnitResult<E>> resultTask, Func<K> func, Func<Exception, E> errorHandler)
	{
		return (await resultTask.DefaultAwait()).MapTry(func, errorHandler);
	}

	public static async Task<Result<K>> MapTry<T, K>(this Task<Result<T>> resultTask, Func<T, K> func, Func<Exception, string> errorHandler = null)
	{
		return (await resultTask.DefaultAwait()).MapTry(func, errorHandler);
	}

	public static async Task<Result<K>> MapTry<K>(this Task<Result> resultTask, Func<K> func, Func<Exception, string> errorHandler = null)
	{
		return (await resultTask.DefaultAwait()).MapTry(func, errorHandler);
	}

	public static async Task<K> Match<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<K>> onSuccess, Func<E, Task<K>> onFailure)
	{
		return await (await resultTask.DefaultAwait()).Match(onSuccess, onFailure).DefaultAwait();
	}

	public static async Task<K> Match<K, T>(this Task<Result<T>> resultTask, Func<T, Task<K>> onSuccess, Func<string, Task<K>> onFailure)
	{
		return await (await resultTask.DefaultAwait()).Match(onSuccess, onFailure).DefaultAwait();
	}

	public static async Task<T> Match<T>(this Task<Result> resultTask, Func<Task<T>> onSuccess, Func<string, Task<T>> onFailure)
	{
		return await (await resultTask.DefaultAwait()).Match(onSuccess, onFailure).DefaultAwait();
	}

	public static async Task<K> Match<K, E>(this Task<UnitResult<E>> resultTask, Func<Task<K>> onSuccess, Func<E, Task<K>> onFailure)
	{
		return await (await resultTask.DefaultAwait()).Match(onSuccess, onFailure).DefaultAwait();
	}

	public static async Task Match<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task> onSuccess, Func<E, Task> onFailure)
	{
		await (await resultTask.DefaultAwait()).Match(onSuccess, onFailure).DefaultAwait();
	}

	public static async Task Match<E>(this Task<UnitResult<E>> resultTask, Func<Task> onSuccess, Func<E, Task> onFailure)
	{
		await (await resultTask.DefaultAwait()).Match(onSuccess, onFailure).DefaultAwait();
	}

	public static async Task Match<T>(this Task<Result<T>> resultTask, Func<T, Task> onSuccess, Func<string, Task> onFailure)
	{
		await (await resultTask.DefaultAwait()).Match(onSuccess, onFailure).DefaultAwait();
	}

	public static async Task Match(this Task<Result> resultTask, Func<Task> onSuccess, Func<string, Task> onFailure)
	{
		await (await resultTask.DefaultAwait()).Match(onSuccess, onFailure).DefaultAwait();
	}

	public static async Task<K> Match<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, K> onSuccess, Func<E, K> onFailure)
	{
		return (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
	}

	public static async Task<K> Match<K, T>(this Task<Result<T>> resultTask, Func<T, K> onSuccess, Func<string, K> onFailure)
	{
		return (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
	}

	public static async Task<T> Match<T>(this Task<Result> resultTask, Func<T> onSuccess, Func<string, T> onFailure)
	{
		return (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
	}

	public static async Task<K> Match<K, E>(this Task<UnitResult<E>> resultTask, Func<K> onSuccess, Func<E, K> onFailure)
	{
		return (await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
	}

	public static async Task Match<T, E>(this Task<Result<T, E>> resultTask, Action<T> onSuccess, Action<E> onFailure)
	{
		(await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
	}

	public static async Task Match<E>(this Task<UnitResult<E>> resultTask, Action onSuccess, Action<E> onFailure)
	{
		(await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
	}

	public static async Task Match<T>(this Task<Result<T>> resultTask, Action<T> onSuccess, Action<string> onFailure)
	{
		(await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
	}

	public static async Task Match(this Task<Result> resultTask, Action onSuccess, Action<string> onFailure)
	{
		(await resultTask.DefaultAwait()).Match(onSuccess, onFailure);
	}

	public static Task<K> Match<T, K, E>(this Result<T, E> result, Func<T, Task<K>> onSuccess, Func<E, Task<K>> onFailure)
	{
		if (!result.IsSuccess)
		{
			return onFailure(result.Error);
		}
		return onSuccess(result.Value);
	}

	public static Task<K> Match<K, T>(this Result<T> result, Func<T, Task<K>> onSuccess, Func<string, Task<K>> onFailure)
	{
		if (!result.IsSuccess)
		{
			return onFailure(result.Error);
		}
		return onSuccess(result.Value);
	}

	public static Task<T> Match<T>(this Result result, Func<Task<T>> onSuccess, Func<string, Task<T>> onFailure)
	{
		if (!result.IsSuccess)
		{
			return onFailure(result.Error);
		}
		return onSuccess();
	}

	public static Task<K> Match<K, E>(this UnitResult<E> result, Func<Task<K>> onSuccess, Func<E, Task<K>> onFailure)
	{
		if (!result.IsSuccess)
		{
			return onFailure(result.Error);
		}
		return onSuccess();
	}

	public static Task Match<T, E>(this Result<T, E> result, Func<T, Task> onSuccess, Func<E, Task> onFailure)
	{
		if (!result.IsSuccess)
		{
			return onFailure(result.Error);
		}
		return onSuccess(result.Value);
	}

	public static Task Match<E>(this UnitResult<E> result, Func<Task> onSuccess, Func<E, Task> onFailure)
	{
		if (!result.IsSuccess)
		{
			return onFailure(result.Error);
		}
		return onSuccess();
	}

	public static Task Match<T>(this Result<T> result, Func<T, Task> onSuccess, Func<string, Task> onFailure)
	{
		if (!result.IsSuccess)
		{
			return onFailure(result.Error);
		}
		return onSuccess(result.Value);
	}

	public static Task Match(this Result result, Func<Task> onSuccess, Func<string, Task> onFailure)
	{
		if (!result.IsSuccess)
		{
			return onFailure(result.Error);
		}
		return onSuccess();
	}

	public static async Task<Result<T, E>> OnFailureCompensate<T, E>(this Task<Result<T, E>> resultTask, Func<Result<T, E>> func)
	{
		return (await resultTask.DefaultAwait()).OnFailureCompensate(func);
	}

	public static async Task<Result<T>> OnFailureCompensate<T>(this Task<Result<T>> resultTask, Func<Result<T>> func)
	{
		return (await resultTask.DefaultAwait()).OnFailureCompensate(func);
	}

	public static async Task<Result> OnFailureCompensate(this Task<Result> resultTask, Func<Result> func)
	{
		return (await resultTask.DefaultAwait()).OnFailureCompensate(func);
	}

	public static async Task<Result<T>> OnFailureCompensate<T>(this Task<Result<T>> resultTask, Func<string, Result<T>> func)
	{
		return (await resultTask.DefaultAwait()).OnFailureCompensate(func);
	}

	public static async Task<Result<T, E>> OnFailureCompensate<T, E>(this Task<Result<T, E>> resultTask, Func<E, Result<T, E>> func)
	{
		return (await resultTask.DefaultAwait()).OnFailureCompensate(func);
	}

	public static async Task<Result> OnFailureCompensate(this Task<Result> resultTask, Func<string, Result> func)
	{
		return (await resultTask.DefaultAwait()).OnFailureCompensate(func);
	}

	public static async Task<Result> Tap(this Task<Result> resultTask, Action action)
	{
		return (await resultTask.DefaultAwait()).Tap(action);
	}

	public static async Task<Result<T>> Tap<T>(this Task<Result<T>> resultTask, Action action)
	{
		return (await resultTask.DefaultAwait()).Tap(action);
	}

	public static async Task<Result<T>> Tap<T>(this Task<Result<T>> resultTask, Action<T> action)
	{
		return (await resultTask.DefaultAwait()).Tap(action);
	}

	public static async Task<UnitResult<E>> Tap<E>(this Task<UnitResult<E>> resultTask, Action action)
	{
		return (await resultTask.DefaultAwait()).Tap(action);
	}

	public static async Task<Result<T, E>> Tap<T, E>(this Task<Result<T, E>> resultTask, Action action)
	{
		return (await resultTask.DefaultAwait()).Tap(action);
	}

	public static async Task<Result<T, E>> Tap<T, E>(this Task<Result<T, E>> resultTask, Action<T> action)
	{
		return (await resultTask.DefaultAwait()).Tap(action);
	}

	public static Task<Result> TapIf(this Task<Result> resultTask, bool condition, Action action)
	{
		if (condition)
		{
			return resultTask.Tap(action);
		}
		return resultTask;
	}

	public static Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, bool condition, Action action)
	{
		if (condition)
		{
			return resultTask.Tap(action);
		}
		return resultTask;
	}

	public static Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, bool condition, Action<T> action)
	{
		if (condition)
		{
			return resultTask.Tap(action);
		}
		return resultTask;
	}

	public static Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Action action)
	{
		if (condition)
		{
			return resultTask.Tap(action);
		}
		return resultTask;
	}

	public static Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Action<T> action)
	{
		if (condition)
		{
			return resultTask.Tap(action);
		}
		return resultTask;
	}

	public static Task<UnitResult<E>> TapIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Action action)
	{
		if (condition)
		{
			return resultTask.Tap(action);
		}
		return resultTask;
	}

	public static async Task<Result> TapIf(this Task<Result> resultTask, Func<bool> predicate, Action action)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate())
		{
			return result.Tap(action);
		}
		return result;
	}

	public static async Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Action action)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(action);
		}
		return result;
	}

	public static async Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Action<T> action)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(action);
		}
		return result;
	}

	public static async Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Action action)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(action);
		}
		return result;
	}

	public static async Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Action<T> action)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(action);
		}
		return result;
	}

	public static async Task<UnitResult<E>> TapIf<E>(this Task<UnitResult<E>> resultTask, Func<bool> predicate, Action action)
	{
		UnitResult<E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate())
		{
			return result.Tap(action);
		}
		return result;
	}

	public static async Task<Result> TapIfTry(this Task<Result> resultTask, bool condition, Action action)
	{
		return (await resultTask.DefaultAwait()).TapIfTry(condition, action);
	}

	public static async Task<Result<T>> TapIfTry<T>(this Task<Result<T>> resultTask, bool condition, Action action)
	{
		return (await resultTask.DefaultAwait()).TapIfTry(condition, action);
	}

	public static async Task<Result<T>> TapIfTry<T>(this Task<Result<T>> resultTask, bool condition, Action<T> action)
	{
		return (await resultTask.DefaultAwait()).TapIfTry(condition, action);
	}

	public static async Task<UnitResult<E>> TapIfTry<E>(this Task<UnitResult<E>> resultTask, bool condition, Action action, Func<Exception, E> errorHandler)
	{
		return (await resultTask.DefaultAwait()).TapIfTry(condition, action, errorHandler);
	}

	public static async Task<Result<T, E>> TapIfTry<T, E>(this Task<Result<T, E>> resultTask, bool condition, Action action, Func<Exception, E> errorHandler)
	{
		return (await resultTask.DefaultAwait()).TapIfTry(condition, action, errorHandler);
	}

	public static async Task<Result<T, E>> TapIfTry<T, E>(this Task<Result<T, E>> resultTask, bool condition, Action<T> action, Func<Exception, E> errorHandler)
	{
		return (await resultTask.DefaultAwait()).TapIfTry(condition, action, errorHandler);
	}

	public static async Task<Result<T>> TapIfTry<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Action action)
	{
		return (await resultTask.DefaultAwait()).TapIfTry(predicate, action);
	}

	public static async Task<Result<T>> TapIfTry<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Action<T> action)
	{
		return (await resultTask.DefaultAwait()).TapIfTry(predicate, action);
	}

	public static async Task<Result<T, E>> TapIfTry<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Action action, Func<Exception, E> errorHandler)
	{
		return (await resultTask.DefaultAwait()).TapIfTry(predicate, action, errorHandler);
	}

	public static async Task<Result<T, E>> TapIfTry<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Action<T> action, Func<Exception, E> errorHandler)
	{
		return (await resultTask.DefaultAwait()).TapIfTry(predicate, action, errorHandler);
	}

	public static async Task<Result> TapTry(this Task<Result> resultTask, Action action)
	{
		return (await resultTask.DefaultAwait()).TapTry(action);
	}

	public static async Task<Result<T>> TapTry<T>(this Task<Result<T>> resultTask, Action action)
	{
		return (await resultTask.DefaultAwait()).TapTry(action);
	}

	public static async Task<Result<T>> TapTry<T>(this Task<Result<T>> resultTask, Action<T> action)
	{
		return (await resultTask.DefaultAwait()).TapTry(action);
	}

	public static async Task<UnitResult<E>> TapTry<E>(this Task<UnitResult<E>> resultTask, Action action, Func<Exception, E> errorHandler)
	{
		return (await resultTask.DefaultAwait()).TapTry(action, errorHandler);
	}

	public static async Task<Result<T, E>> TapTry<T, E>(this Task<Result<T, E>> resultTask, Action action, Func<Exception, E> errorHandler)
	{
		return (await resultTask.DefaultAwait()).TapTry(action, errorHandler);
	}

	public static async Task<Result<T, E>> TapTry<T, E>(this Task<Result<T, E>> resultTask, Action<T> action, Func<Exception, E> errorHandler)
	{
		return (await resultTask.DefaultAwait()).TapTry(action, errorHandler);
	}
}
