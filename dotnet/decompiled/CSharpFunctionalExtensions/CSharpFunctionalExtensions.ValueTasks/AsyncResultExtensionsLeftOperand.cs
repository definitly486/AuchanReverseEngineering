using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks;

public static class AsyncResultExtensionsLeftOperand
{
	public static async ValueTask<Result<K, E>> Bind<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, Result<K, E>> valueTask)
	{
		return (await resultTask).Bind(valueTask);
	}

	public static async ValueTask<Result<K>> Bind<T, K>(this ValueTask<Result<T>> resultTask, Func<T, Result<K>> valueTask)
	{
		return (await resultTask).Bind(valueTask);
	}

	public static async ValueTask<Result<K>> Bind<K>(this ValueTask<Result> resultTask, Func<Result<K>> valueTask)
	{
		return (await resultTask).Bind(valueTask);
	}

	public static async ValueTask<Result> Bind<T>(this ValueTask<Result<T>> resultTask, Func<T, Result> valueTask)
	{
		return (await resultTask).Bind(valueTask);
	}

	public static async ValueTask<Result> Bind(this ValueTask<Result> resultTask, Func<Result> valueTask)
	{
		return (await resultTask).Bind(valueTask);
	}

	public static async ValueTask<Result<T, E>> Bind<T, E>(this ValueTask<UnitResult<E>> resultTask, Func<Result<T, E>> valueTask)
	{
		return (await resultTask).Bind(valueTask);
	}

	public static async ValueTask<UnitResult<E>> Bind<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, UnitResult<E>> valueTask)
	{
		return (await resultTask).Bind(valueTask);
	}

	public static async ValueTask<UnitResult<E>> Bind<E>(this ValueTask<UnitResult<E>> resultTask, Func<UnitResult<E>> valueTask)
	{
		return (await resultTask).Bind(valueTask);
	}

	public static async ValueTask<Result> BindTry(this ValueTask<Result> resultValueTask, Func<Result> valueTask, Func<Exception, string> errorHandler = null)
	{
		return (await resultValueTask).BindTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result<K>> BindTry<K>(this ValueTask<Result> resultValueTask, Func<Result<K>> valueTask, Func<Exception, string> errorHandler = null)
	{
		return (await resultValueTask).BindTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result> BindTry<T>(this ValueTask<Result<T>> resultValueTask, Func<T, Result> valueTask, Func<Exception, string> errorHandler = null)
	{
		return (await resultValueTask).BindTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result<K>> BindTry<T, K>(this ValueTask<Result<T>> resultValueTask, Func<T, Result<K>> valueTask, Func<Exception, string> errorHandler = null)
	{
		return (await resultValueTask).BindTry(valueTask, errorHandler);
	}

	public static async ValueTask<UnitResult<E>> BindTry<T, E>(this ValueTask<Result<T, E>> resultValueTask, Func<T, UnitResult<E>> valueTask, Func<Exception, E> errorHandler)
	{
		return (await resultValueTask).BindTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result<K, E>> BindTry<T, K, E>(this ValueTask<Result<T, E>> resultValueTask, Func<T, Result<K, E>> valueTask, Func<Exception, E> errorHandler)
	{
		return (await resultValueTask).BindTry(valueTask, errorHandler);
	}

	public static async ValueTask<UnitResult<E>> BindTry<E>(this ValueTask<UnitResult<E>> resultValueTask, Func<UnitResult<E>> valueTask, Func<Exception, E> errorHandler)
	{
		return (await resultValueTask).BindTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result<T, E>> BindTry<T, E>(this ValueTask<UnitResult<E>> resultValueTask, Func<Result<T, E>> valueTask, Func<Exception, E> errorHandler)
	{
		return (await resultValueTask).BindTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result<T>> Check<T>(this ValueTask<Result<T>> resultTask, Func<T, Result> valueTask)
	{
		return (await resultTask).Check(valueTask);
	}

	public static async ValueTask<Result<T>> Check<T, K>(this ValueTask<Result<T>> resultTask, Func<T, Result<K>> valueTask)
	{
		return (await resultTask).Check(valueTask);
	}

	public static async ValueTask<Result<T, E>> Check<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, Result<K, E>> valueTask)
	{
		return (await resultTask).Check(valueTask);
	}

	public static async ValueTask<Result<T, E>> Check<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, UnitResult<E>> valueTask)
	{
		return (await resultTask).Check(valueTask);
	}

	public static async ValueTask<UnitResult<E>> Check<E>(this ValueTask<UnitResult<E>> resultTask, Func<UnitResult<E>> valueTask)
	{
		return (await resultTask).Check(valueTask);
	}

	public static ValueTask<Result<T>> CheckIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result> valueTask)
	{
		if (condition)
		{
			return resultTask.Check(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<Result<T>> CheckIf<T, K>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result<K>> valueTask)
	{
		if (condition)
		{
			return resultTask.Check(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<Result<T, E>> CheckIf<T, K, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<T, Result<K, E>> valueTask)
	{
		if (condition)
		{
			return resultTask.Check(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<Result<T, E>> CheckIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<T, UnitResult<E>> valueTask)
	{
		if (condition)
		{
			return resultTask.Check(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<UnitResult<E>> CheckIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Func<UnitResult<E>> valueTask)
	{
		if (condition)
		{
			return resultTask.Check(valueTask);
		}
		return resultTask;
	}

	public static async ValueTask<Result<T>> CheckIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result> valueTask)
	{
		Result<T> result = await resultTask;
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(valueTask);
		}
		return result;
	}

	public static async ValueTask<Result<T>> CheckIf<T, K>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<K>> valueTask)
	{
		Result<T> result = await resultTask;
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(valueTask);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> CheckIf<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Result<K, E>> valueTask)
	{
		Result<T, E> result = await resultTask;
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(valueTask);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> CheckIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, UnitResult<E>> valueTask)
	{
		Result<T, E> result = await resultTask;
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(valueTask);
		}
		return result;
	}

	public static async ValueTask<UnitResult<E>> CheckIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<bool> predicate, Func<UnitResult<E>> valueTask)
	{
		UnitResult<E> result = await resultTask;
		if (result.IsSuccess && predicate())
		{
			return result.Check(valueTask);
		}
		return result;
	}

	public static async ValueTask<Result> Combine(this IEnumerable<ValueTask<Result>> tasks, string errorMessageSeparator = null)
	{
		return (await Task.WhenAll(tasks.Select((ValueTask<Result> x) => x.AsTask())).DefaultAwait()).Combine(errorMessageSeparator);
	}

	public static async ValueTask<Result<IEnumerable<T>, E>> Combine<T, E>(this IEnumerable<ValueTask<Result<T, E>>> tasks, Func<IEnumerable<E>, E> composerError)
	{
		return (await Task.WhenAll(tasks.Select((ValueTask<Result<T, E>> x) => x.AsTask())).DefaultAwait()).Combine(composerError);
	}

	public static async ValueTask<Result<IEnumerable<T>, E>> Combine<T, E>(this IEnumerable<ValueTask<Result<T, E>>> tasks) where E : ICombine
	{
		return (await Task.WhenAll(tasks.Select((ValueTask<Result<T, E>> x) => x.AsTask())).DefaultAwait()).Combine();
	}

	public static async ValueTask<Result<IEnumerable<T>>> Combine<T>(this IEnumerable<ValueTask<Result<T>>> tasks, string errorMessageSeparator = null)
	{
		return (await Task.WhenAll(tasks.Select((ValueTask<Result<T>> x) => x.AsTask())).DefaultAwait()).Combine(errorMessageSeparator);
	}

	public static async ValueTask<Result> Combine(this ValueTask<IEnumerable<Result>> task, string errorMessageSeparator = null)
	{
		return (await task).Combine(errorMessageSeparator);
	}

	public static async ValueTask<Result<IEnumerable<T>, E>> Combine<T, E>(this ValueTask<IEnumerable<Result<T, E>>> task, Func<IEnumerable<E>, E> composerError)
	{
		return (await task).Combine(composerError);
	}

	public static async ValueTask<Result<IEnumerable<T>, E>> Combine<T, E>(this ValueTask<IEnumerable<Result<T, E>>> task) where E : ICombine
	{
		return (await task).Combine();
	}

	public static async ValueTask<Result<IEnumerable<T>>> Combine<T>(this ValueTask<IEnumerable<Result<T>>> task, string errorMessageSeparator = null)
	{
		return (await task).Combine(errorMessageSeparator);
	}

	public static async ValueTask<Result> Combine(this ValueTask<IEnumerable<ValueTask<Result>>> task, string errorMessageSeparator = null)
	{
		return await (await task).Combine(errorMessageSeparator);
	}

	public static async ValueTask<Result<IEnumerable<T>, E>> Combine<T, E>(this ValueTask<IEnumerable<ValueTask<Result<T, E>>>> task, Func<IEnumerable<E>, E> composerError)
	{
		return await (await task).Combine(composerError);
	}

	public static async ValueTask<Result<IEnumerable<T>, E>> Combine<T, E>(this ValueTask<IEnumerable<ValueTask<Result<T, E>>>> task) where E : ICombine
	{
		return await (await task).Combine();
	}

	public static async ValueTask<Result<IEnumerable<T>>> Combine<T>(this ValueTask<IEnumerable<ValueTask<Result<T>>>> task, string errorMessageSeparator = null)
	{
		return await (await task).Combine(errorMessageSeparator);
	}

	public static async ValueTask<Result<K, E>> Combine<T, K, E>(this IEnumerable<ValueTask<Result<T, E>>> tasks, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
	{
		return (await Task.WhenAll(tasks.Select((ValueTask<Result<T, E>> x) => x.AsTask())).DefaultAwait()).Combine(composer, composerError);
	}

	public static async ValueTask<Result<K, E>> Combine<T, K, E>(this IEnumerable<ValueTask<Result<T, E>>> tasks, Func<IEnumerable<T>, K> composer) where E : ICombine
	{
		return (await Task.WhenAll(tasks.Select((ValueTask<Result<T, E>> x) => x.AsTask())).DefaultAwait()).Combine(composer);
	}

	public static async ValueTask<Result<K>> Combine<T, K>(this IEnumerable<ValueTask<Result<T>>> tasks, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
	{
		return (await Task.WhenAll(tasks.Select((ValueTask<Result<T>> x) => x.AsTask())).DefaultAwait()).Combine(composer, errorMessageSeparator);
	}

	public static async ValueTask<Result<K, E>> Combine<T, K, E>(this ValueTask<IEnumerable<ValueTask<Result<T, E>>>> task, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
	{
		return await (await task).Combine(composer, composerError);
	}

	public static async ValueTask<Result<K, E>> Combine<T, K, E>(this ValueTask<IEnumerable<ValueTask<Result<T, E>>>> task, Func<IEnumerable<T>, K> composer) where E : ICombine
	{
		return await (await task).Combine(composer);
	}

	public static async ValueTask<Result<K>> Combine<T, K>(this ValueTask<IEnumerable<ValueTask<Result<T>>>> task, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
	{
		return await (await task).Combine(composer, errorMessageSeparator);
	}

	public static async ValueTask<Result> CombineInOrder(this IEnumerable<ValueTask<Result>> tasks, string errorMessageSeparator = null)
	{
		return (await CompleteInOrder(tasks)).Combine(errorMessageSeparator);
	}

	public static async ValueTask<Result<IEnumerable<T>, E>> CombineInOrder<T, E>(this IEnumerable<ValueTask<Result<T, E>>> tasks, Func<IEnumerable<E>, E> composerError)
	{
		return (await CompleteInOrder(tasks)).Combine(composerError);
	}

	public static async ValueTask<Result<IEnumerable<T>, E>> CombineInOrder<T, E>(this IEnumerable<ValueTask<Result<T, E>>> tasks) where E : ICombine
	{
		return (await CompleteInOrder(tasks)).Combine();
	}

	public static async ValueTask<Result<IEnumerable<T>>> CombineInOrder<T>(this IEnumerable<ValueTask<Result<T>>> tasks, string errorMessageSeparator = null)
	{
		return (await CompleteInOrder(tasks)).Combine(errorMessageSeparator);
	}

	public static async ValueTask<Result> CombineInOrder(this ValueTask<IEnumerable<ValueTask<Result>>> task, string errorMessageSeparator = null)
	{
		return await (await task).CombineInOrder(errorMessageSeparator);
	}

	public static async ValueTask<Result<IEnumerable<T>, E>> CombineInOrder<T, E>(this ValueTask<IEnumerable<ValueTask<Result<T, E>>>> task, Func<IEnumerable<E>, E> composerError)
	{
		return await (await task).CombineInOrder(composerError);
	}

	public static async ValueTask<Result<IEnumerable<T>, E>> CombineInOrder<T, E>(this ValueTask<IEnumerable<ValueTask<Result<T, E>>>> task) where E : ICombine
	{
		return await (await task).CombineInOrder();
	}

	public static async ValueTask<Result<IEnumerable<T>>> CombineInOrder<T>(this ValueTask<IEnumerable<ValueTask<Result<T>>>> task, string errorMessageSeparator = null)
	{
		return await (await task).CombineInOrder(errorMessageSeparator);
	}

	public static async ValueTask<Result<K, E>> CombineInOrder<T, K, E>(this IEnumerable<ValueTask<Result<T, E>>> tasks, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
	{
		return (await CompleteInOrder(tasks)).Combine(composer, composerError);
	}

	public static async ValueTask<Result<K, E>> CombineInOrder<T, K, E>(this IEnumerable<ValueTask<Result<T, E>>> tasks, Func<IEnumerable<T>, K> composer) where E : ICombine
	{
		return (await CompleteInOrder(tasks)).Combine(composer);
	}

	public static async ValueTask<Result<K>> CombineInOrder<T, K>(this IEnumerable<ValueTask<Result<T>>> tasks, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
	{
		return (await CompleteInOrder(tasks)).Combine(composer, errorMessageSeparator);
	}

	public static async ValueTask<Result<K, E>> CombineInOrder<T, K, E>(this ValueTask<IEnumerable<ValueTask<Result<T, E>>>> task, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
	{
		return await (await task).CombineInOrder(composer, composerError);
	}

	public static async ValueTask<Result<K, E>> CombineInOrder<T, K, E>(this ValueTask<IEnumerable<ValueTask<Result<T, E>>>> task, Func<IEnumerable<T>, K> composer) where E : ICombine
	{
		return await (await task).CombineInOrder(composer);
	}

	public static async ValueTask<Result<K>> CombineInOrder<T, K>(this ValueTask<IEnumerable<ValueTask<Result<T>>>> task, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
	{
		return await (await task).CombineInOrder(composer, errorMessageSeparator);
	}

	public static async ValueTask<T[]> CompleteInOrder<T>(IEnumerable<ValueTask<T>> tasks)
	{
		List<T> results = new List<T>();
		foreach (ValueTask<T> task in tasks)
		{
			List<T> list = results;
			list.Add(await task);
		}
		return results.ToArray();
	}

	public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, string errorMessage)
	{
		return (await resultTask).Ensure(predicate, errorMessage);
	}

	public static async ValueTask<Result<T, E>> Ensure<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, E error)
	{
		return (await resultTask).Ensure(predicate, error);
	}

	public static async ValueTask<Result<T, E>> Ensure<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, E> errorPredicate)
	{
		return (await resultTask).Ensure(predicate, errorPredicate);
	}

	public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, string> errorPredicate)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure)
		{
			return result;
		}
		return result.Ensure(predicate, errorPredicate);
	}

	public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<string>> errorPredicate)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure)
		{
			return result;
		}
		if (predicate(result.Value))
		{
			return result;
		}
		return Result.Failure<T>(await errorPredicate(result.Value));
	}

	public static async ValueTask<Result> Ensure(this ValueTask<Result> resultTask, Func<bool> predicate, string errorMessage)
	{
		return (await resultTask).Ensure(predicate, errorMessage);
	}

	public static async ValueTask<Result> Ensure(this ValueTask<Result> resultTask, Func<Result> predicate)
	{
		return (await resultTask).Ensure(predicate);
	}

	public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<Result> predicate)
	{
		return (await resultTask).Ensure(predicate);
	}

	public static async ValueTask<Result> Ensure<T>(this ValueTask<Result> resultTask, Func<Result<T>> predicate)
	{
		return (await resultTask).Ensure(predicate);
	}

	public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>> predicate)
	{
		return (await resultTask).Ensure(predicate);
	}

	public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, Result> predicate)
	{
		return (await resultTask).Ensure(predicate);
	}

	public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, Result<T>> predicate)
	{
		return (await resultTask).Ensure(predicate);
	}

	public static async ValueTask<T> Finally<T>(this ValueTask<Result> resultTask, Func<Result, T> valueTask)
	{
		return (await resultTask).Finally(valueTask);
	}

	public static async ValueTask<K> Finally<T, K>(this ValueTask<Result<T>> resultTask, Func<Result<T>, K> valueTask)
	{
		return (await resultTask).Finally(valueTask);
	}

	public static async ValueTask<K> Finally<K, E>(this ValueTask<UnitResult<E>> resultTask, Func<UnitResult<E>, K> valueTask)
	{
		return (await resultTask).Finally(valueTask);
	}

	public static async ValueTask<K> Finally<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<Result<T, E>, K> valueTask)
	{
		return (await resultTask).Finally(valueTask);
	}

	public static async ValueTask<Result<K, E>> Map<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, K> valueTask)
	{
		return (await resultTask).Map(valueTask);
	}

	public static async ValueTask<Result<K, E>> Map<T, K, E, TContext>(this ValueTask<Result<T, E>> resultTask, Func<T, TContext, K> valueTask, TContext context)
	{
		return (await resultTask).Map(valueTask, context);
	}

	public static async ValueTask<Result<K, E>> Map<K, E>(this ValueTask<UnitResult<E>> resultTask, Func<K> valueTask)
	{
		return (await resultTask).Map(valueTask);
	}

	public static async ValueTask<Result<K, E>> Map<K, E, TContext>(this ValueTask<UnitResult<E>> resultTask, Func<TContext, K> valueTask, TContext context)
	{
		return (await resultTask).Map(valueTask, context);
	}

	public static async ValueTask<Result<K>> Map<T, K>(this ValueTask<Result<T>> resultTask, Func<T, K> valueTask)
	{
		return (await resultTask).Map(valueTask);
	}

	public static async ValueTask<Result<K>> Map<T, K, TContext>(this ValueTask<Result<T>> resultTask, Func<T, TContext, K> valueTask, TContext context)
	{
		return (await resultTask).Map(valueTask, context);
	}

	public static async ValueTask<Result<K>> Map<K>(this ValueTask<Result> resultTask, Func<K> valueTask)
	{
		return (await resultTask).Map(valueTask);
	}

	public static async ValueTask<Result<K>> Map<K, TContext>(this ValueTask<Result> resultTask, Func<TContext, K> valueTask, TContext context)
	{
		return (await resultTask).Map(valueTask, context);
	}

	public static async ValueTask<Result<K, E>> MapTry<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, K> valueTask, Func<Exception, E> errorHandler)
	{
		return (await resultTask).MapTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result<K, E>> MapTry<K, E>(this ValueTask<UnitResult<E>> resultTask, Func<K> valueTask, Func<Exception, E> errorHandler)
	{
		return (await resultTask).MapTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result<K>> MapTry<T, K>(this ValueTask<Result<T>> resultTask, Func<T, K> valueTask, Func<Exception, string> errorHandler = null)
	{
		return (await resultTask).MapTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result<K>> MapTry<K>(this ValueTask<Result> resultTask, Func<K> valueTask, Func<Exception, string> errorHandler = null)
	{
		return (await resultTask).MapTry(valueTask, errorHandler);
	}

	public static async ValueTask<K> Match<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<K>> onSuccessValueTask, Func<E, ValueTask<K>> onFailureValueTask)
	{
		return await (await resultTask).Match(onSuccessValueTask, onFailureValueTask);
	}

	public static async ValueTask<K> Match<K, T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<K>> onSuccessValueTask, Func<string, ValueTask<K>> onFailureValueTask)
	{
		return await (await resultTask).Match(onSuccessValueTask, onFailureValueTask);
	}

	public static async ValueTask<T> Match<T>(this ValueTask<Result> resultTask, Func<ValueTask<T>> onSuccessValueTask, Func<string, ValueTask<T>> onFailureValueTask)
	{
		return await (await resultTask).Match(onSuccessValueTask, onFailureValueTask);
	}

	public static async ValueTask<K> Match<K, E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<K>> onSuccessValueTask, Func<E, ValueTask<K>> onFailureValueTask)
	{
		return await (await resultTask).Match(onSuccessValueTask, onFailureValueTask);
	}

	public static async Task Match<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask> onSuccessValueTask, Func<E, ValueTask> onFailureValueTask)
	{
		await (await resultTask).Match(onSuccessValueTask, onFailureValueTask);
	}

	public static async Task Match<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask> onSuccessValueTask, Func<E, ValueTask> onFailureValueTask)
	{
		await (await resultTask).Match(onSuccessValueTask, onFailureValueTask);
	}

	public static async Task Match<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask> onSuccessValueTask, Func<string, ValueTask> onFailureValueTask)
	{
		await (await resultTask).Match(onSuccessValueTask, onFailureValueTask);
	}

	public static async Task Match(this ValueTask<Result> resultTask, Func<ValueTask> onSuccessValueTask, Func<string, ValueTask> onFailureValueTask)
	{
		await (await resultTask).Match(onSuccessValueTask, onFailureValueTask);
	}

	public static async ValueTask<K> Match<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, K> onSuccess, Func<E, K> onFailure)
	{
		return (await resultTask).Match(onSuccess, onFailure);
	}

	public static async ValueTask<K> Match<K, T>(this ValueTask<Result<T>> resultTask, Func<T, K> onSuccess, Func<string, K> onFailure)
	{
		return (await resultTask).Match(onSuccess, onFailure);
	}

	public static async ValueTask<T> Match<T>(this ValueTask<Result> resultTask, Func<T> onSuccess, Func<string, T> onFailure)
	{
		return (await resultTask).Match(onSuccess, onFailure);
	}

	public static async ValueTask<K> Match<K, E>(this ValueTask<UnitResult<E>> resultTask, Func<K> onSuccess, Func<E, K> onFailure)
	{
		return (await resultTask).Match(onSuccess, onFailure);
	}

	public static async Task Match<T, E>(this ValueTask<Result<T, E>> resultTask, Action<T> onSuccess, Action<E> onFailure)
	{
		(await resultTask).Match(onSuccess, onFailure);
	}

	public static async Task Match<T>(this ValueTask<Result<T>> resultTask, Action<T> onSuccess, Action<string> onFailure)
	{
		(await resultTask).Match(onSuccess, onFailure);
	}

	public static async Task Match(this ValueTask<Result> resultTask, Action onSuccess, Action<string> onFailure)
	{
		(await resultTask).Match(onSuccess, onFailure);
	}

	public static ValueTask<K> Match<T, K, E>(this Result<T, E> result, Func<T, ValueTask<K>> onSuccessValueTask, Func<E, ValueTask<K>> onFailureValueTask)
	{
		if (!result.IsSuccess)
		{
			return onFailureValueTask(result.Error);
		}
		return onSuccessValueTask(result.Value);
	}

	public static ValueTask<K> Match<K, T>(this Result<T> result, Func<T, ValueTask<K>> onSuccessValueTask, Func<string, ValueTask<K>> onFailureValueTask)
	{
		if (!result.IsSuccess)
		{
			return onFailureValueTask(result.Error);
		}
		return onSuccessValueTask(result.Value);
	}

	public static ValueTask<T> Match<T>(this Result result, Func<ValueTask<T>> onSuccessValueTask, Func<string, ValueTask<T>> onFailureValueTask)
	{
		if (!result.IsSuccess)
		{
			return onFailureValueTask(result.Error);
		}
		return onSuccessValueTask();
	}

	public static ValueTask<K> Match<K, E>(this UnitResult<E> result, Func<ValueTask<K>> onSuccessValueTask, Func<E, ValueTask<K>> onFailureValueTask)
	{
		if (!result.IsSuccess)
		{
			return onFailureValueTask(result.Error);
		}
		return onSuccessValueTask();
	}

	public static ValueTask Match<T, E>(this Result<T, E> result, Func<T, ValueTask> onSuccessValueTask, Func<E, ValueTask> onFailureValueTask)
	{
		if (!result.IsSuccess)
		{
			return onFailureValueTask(result.Error);
		}
		return onSuccessValueTask(result.Value);
	}

	public static ValueTask Match<E>(this UnitResult<E> result, Func<ValueTask> onSuccessValueTask, Func<E, ValueTask> onFailureValueTask)
	{
		if (!result.IsSuccess)
		{
			return onFailureValueTask(result.Error);
		}
		return onSuccessValueTask();
	}

	public static ValueTask Match<T>(this Result<T> result, Func<T, ValueTask> onSuccessValueTask, Func<string, ValueTask> onFailureValueTask)
	{
		if (!result.IsSuccess)
		{
			return onFailureValueTask(result.Error);
		}
		return onSuccessValueTask(result.Value);
	}

	public static ValueTask Match(this Result result, Func<ValueTask> onSuccessValueTask, Func<string, ValueTask> onFailureValueTask)
	{
		if (!result.IsSuccess)
		{
			return onFailureValueTask(result.Error);
		}
		return onSuccessValueTask();
	}

	public static async ValueTask<Result<T, E>> OnFailureCompensate<T, E>(this ValueTask<Result<T, E>> resultTask, Func<Result<T, E>> valueTask)
	{
		return (await resultTask).OnFailureCompensate(valueTask);
	}

	public static async ValueTask<Result<T>> OnFailureCompensate<T>(this ValueTask<Result<T>> resultTask, Func<Result<T>> valueTask)
	{
		return (await resultTask).OnFailureCompensate(valueTask);
	}

	public static async ValueTask<Result> OnFailureCompensate(this ValueTask<Result> resultTask, Func<Result> valueTask)
	{
		return (await resultTask).OnFailureCompensate(valueTask);
	}

	public static async ValueTask<Result<T>> OnFailureCompensate<T>(this ValueTask<Result<T>> resultTask, Func<string, Result<T>> valueTask)
	{
		return (await resultTask).OnFailureCompensate(valueTask);
	}

	public static async ValueTask<Result<T, E>> OnFailureCompensate<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, Result<T, E>> valueTask)
	{
		return (await resultTask).OnFailureCompensate(valueTask);
	}

	public static async ValueTask<Result> OnFailureCompensate(this ValueTask<Result> resultTask, Func<string, Result> valueTask)
	{
		return (await resultTask).OnFailureCompensate(valueTask);
	}

	public static async ValueTask<Result> Tap(this ValueTask<Result> resultTask, Action action)
	{
		return (await resultTask).Tap(action);
	}

	public static async ValueTask<Result<T>> Tap<T>(this ValueTask<Result<T>> resultTask, Action action)
	{
		return (await resultTask).Tap(action);
	}

	public static async ValueTask<Result<T>> Tap<T>(this ValueTask<Result<T>> resultTask, Action<T> action)
	{
		return (await resultTask).Tap(action);
	}

	public static async ValueTask<UnitResult<E>> Tap<E>(this ValueTask<UnitResult<E>> resultTask, Action action)
	{
		return (await resultTask).Tap(action);
	}

	public static async ValueTask<Result<T, E>> Tap<T, E>(this ValueTask<Result<T, E>> resultTask, Action action)
	{
		return (await resultTask).Tap(action);
	}

	public static async ValueTask<Result<T, E>> Tap<T, E>(this ValueTask<Result<T, E>> resultTask, Action<T> action)
	{
		return (await resultTask).Tap(action);
	}

	public static ValueTask<Result> TapIf(this ValueTask<Result> resultTask, bool condition, Action action)
	{
		if (condition)
		{
			return resultTask.Tap(action);
		}
		return resultTask;
	}

	public static ValueTask<Result<T>> TapIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Action action)
	{
		if (condition)
		{
			return resultTask.Tap(action);
		}
		return resultTask;
	}

	public static ValueTask<Result<T>> TapIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Action<T> action)
	{
		if (condition)
		{
			return resultTask.Tap(action);
		}
		return resultTask;
	}

	public static ValueTask<Result<T, E>> TapIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Action action)
	{
		if (condition)
		{
			return resultTask.Tap(action);
		}
		return resultTask;
	}

	public static ValueTask<Result<T, E>> TapIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Action<T> action)
	{
		if (condition)
		{
			return resultTask.Tap(action);
		}
		return resultTask;
	}

	public static ValueTask<UnitResult<E>> TapIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Action action)
	{
		if (condition)
		{
			return resultTask.Tap(action);
		}
		return resultTask;
	}

	public static async ValueTask<Result<T>> TapIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Action action)
	{
		Result<T> result = await resultTask;
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(action);
		}
		return result;
	}

	public static async ValueTask<Result<T>> TapIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Action<T> action)
	{
		Result<T> result = await resultTask;
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(action);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> TapIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Action action)
	{
		Result<T, E> result = await resultTask;
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(action);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> TapIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Action<T> action)
	{
		Result<T, E> result = await resultTask;
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(action);
		}
		return result;
	}

	public static async ValueTask<UnitResult<E>> TapIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<bool> predicate, Action action)
	{
		UnitResult<E> result = await resultTask;
		if (result.IsSuccess && predicate())
		{
			return result.Tap(action);
		}
		return result;
	}
}
