using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks;

public static class AsyncResultExtensionsBothOperands
{
	public static async ValueTask<Result<K, E>> Bind<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<Result<K, E>>> valueTask)
	{
		return await (await resultTask).Bind(valueTask);
	}

	public static async ValueTask<Result<K>> Bind<T, K>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<K>>> valueTask)
	{
		return await (await resultTask).Bind(valueTask);
	}

	public static async ValueTask<Result<K>> Bind<K>(this ValueTask<Result> resultTask, Func<ValueTask<Result<K>>> valueTask)
	{
		return await (await resultTask).Bind(valueTask);
	}

	public static async ValueTask<Result> Bind<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result>> valueTask)
	{
		return await (await resultTask).Bind(valueTask);
	}

	public static async ValueTask<Result> Bind(this ValueTask<Result> resultTask, Func<ValueTask<Result>> valueTask)
	{
		return await (await resultTask).Bind(valueTask);
	}

	public static async ValueTask<Result<T, E>> Bind<T, E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<Result<T, E>>> valueTask)
	{
		return await (await resultTask).Bind(valueTask);
	}

	public static async ValueTask<UnitResult<E>> Bind<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<UnitResult<E>>> valueTask)
	{
		return await (await resultTask).Bind(valueTask);
	}

	public static async ValueTask<UnitResult<E>> Bind<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<UnitResult<E>>> valueTask)
	{
		return await (await resultTask).Bind(valueTask);
	}

	public static async ValueTask<Result> BindTry(this ValueTask<Result> resultTask, Func<ValueTask<Result>> valueTask, Func<Exception, string> errorHandler = null)
	{
		return await (await resultTask).BindTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result<K>> BindTry<K>(this ValueTask<Result> resultTask, Func<ValueTask<Result<K>>> valueTask, Func<Exception, string> errorHandler = null)
	{
		return await (await resultTask).BindTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result> BindTry<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result>> valueTask, Func<Exception, string> errorHandler = null)
	{
		return await (await resultTask).BindTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result<K>> BindTry<T, K>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<K>>> valueTask, Func<Exception, string> errorHandler = null)
	{
		return await (await resultTask).BindTry(valueTask, errorHandler);
	}

	public static async ValueTask<UnitResult<E>> BindTry<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<UnitResult<E>>> valueTask, Func<Exception, E> errorHandler)
	{
		return await (await resultTask).BindTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result<K, E>> BindTry<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<Result<K, E>>> valueTask, Func<Exception, E> errorHandler)
	{
		return await (await resultTask).BindTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result<T, E>> BindTry<T, E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<Result<T, E>>> valueTask, Func<Exception, E> errorHandler)
	{
		return await (await resultTask).BindTry(valueTask, errorHandler);
	}

	public static async ValueTask<UnitResult<E>> BindTry<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<UnitResult<E>>> valueTask, Func<Exception, E> errorHandler)
	{
		return await (await resultTask).BindTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result<T>> Check<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result>> valueTask)
	{
		Result<T> result = await resultTask;
		return await result.Bind(valueTask).Map(() => result.Value);
	}

	public static async ValueTask<Result<T>> Check<T, K>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<K>>> valueTask)
	{
		Result<T> result = await resultTask;
		return await result.Bind(valueTask).Map((K _) => result.Value);
	}

	public static async ValueTask<Result<T, E>> Check<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<Result<K, E>>> valueTask)
	{
		Result<T, E> result = await resultTask;
		return await result.Bind(valueTask).Map((K _) => result.Value);
	}

	public static async ValueTask<Result<T, E>> Check<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<UnitResult<E>>> valueTask)
	{
		Result<T, E> result = await resultTask;
		return await result.Bind(valueTask).Map(() => result.Value);
	}

	public static async ValueTask<UnitResult<E>> Check<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<UnitResult<E>>> valueTask)
	{
		UnitResult<E> result = await resultTask;
		return await result.Bind(valueTask).Map(() => result);
	}

	public static ValueTask<Result<T>> CheckIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result>> valueTask)
	{
		if (condition)
		{
			return resultTask.Check(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<Result<T>> CheckIf<T, K>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result<K>>> valueTask)
	{
		if (condition)
		{
			return resultTask.Check(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<Result<T, E>> CheckIf<T, K, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<T, ValueTask<Result<K, E>>> valueTask)
	{
		if (condition)
		{
			return resultTask.Check(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<Result<T, E>> CheckIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<T, ValueTask<UnitResult<E>>> valueTask)
	{
		if (condition)
		{
			return resultTask.Check(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<UnitResult<E>> CheckIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Func<ValueTask<UnitResult<E>>> valueTask)
	{
		if (condition)
		{
			return resultTask.Check(valueTask);
		}
		return resultTask;
	}

	public static async ValueTask<Result<T>> CheckIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<Result>> valueTask)
	{
		Result<T> result = await resultTask;
		if (result.IsSuccess && predicate(result.Value))
		{
			return await result.Check(valueTask);
		}
		return result;
	}

	public static async ValueTask<Result<T>> CheckIf<T, K>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<Result<K>>> valueTask)
	{
		Result<T> result = await resultTask;
		if (result.IsSuccess && predicate(result.Value))
		{
			return await result.Check(valueTask);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> CheckIf<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<Result<K, E>>> valueTask)
	{
		Result<T, E> result = await resultTask;
		if (result.IsSuccess && predicate(result.Value))
		{
			return await result.Check(valueTask);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> CheckIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<UnitResult<E>>> valueTask)
	{
		Result<T, E> result = await resultTask;
		if (result.IsSuccess && predicate(result.Value))
		{
			return await result.Check(valueTask);
		}
		return result;
	}

	public static async ValueTask<UnitResult<E>> CheckIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<bool> predicate, Func<ValueTask<UnitResult<E>>> valueTask)
	{
		UnitResult<E> result = await resultTask;
		if (result.IsSuccess && predicate())
		{
			return await result.Check(valueTask);
		}
		return result;
	}

	public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<bool>> valueTaskPredicate, string errorMessage)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await valueTaskPredicate(result.Value)))
		{
			return Result.Failure<T>(errorMessage);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> Ensure<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<bool>> valueTaskPredicate, E error)
	{
		Result<T, E> result = await resultTask;
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await valueTaskPredicate(result.Value)))
		{
			return Result.Failure<T, E>(error);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> Ensure<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<bool>> valueTaskPredicate, Func<T, E> valueTaskErrorPredicate)
	{
		Result<T, E> result = await resultTask;
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await valueTaskPredicate(result.Value)))
		{
			return Result.Failure<T, E>(valueTaskErrorPredicate(result.Value));
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> Ensure<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<bool>> valueTaskPredicate, Func<T, ValueTask<E>> valueTaskErrorPredicate)
	{
		Result<T, E> result = await resultTask;
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await valueTaskPredicate(result.Value)))
		{
			return Result.Failure<T, E>(await valueTaskErrorPredicate(result.Value));
		}
		return result;
	}

	public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<bool>> predicateValueTask, Func<T, string> valueTaskErrorPredicate)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await predicateValueTask(result.Value)))
		{
			return Result.Failure<T>(valueTaskErrorPredicate(result.Value));
		}
		return result;
	}

	public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<bool>> valueTaskPredicate, Func<T, ValueTask<string>> valueTaskErrorPredicate)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await valueTaskPredicate(result.Value)))
		{
			return Result.Failure<T>(await valueTaskErrorPredicate(result.Value));
		}
		return result;
	}

	public static async ValueTask<Result> Ensure(this ValueTask<Result> resultTask, Func<ValueTask<bool>> valueTaskPredicate, string errorMessage)
	{
		Result result = await resultTask;
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await valueTaskPredicate()))
		{
			return Result.Failure(errorMessage);
		}
		return result;
	}

	public static async ValueTask<Result> Ensure(this ValueTask<Result> resultTask, Func<ValueTask<Result>> valueTaskPredicate)
	{
		Result result = await resultTask;
		if (result.IsFailure)
		{
			return result;
		}
		Result result2 = await valueTaskPredicate();
		if (result2.IsFailure)
		{
			return Result.Failure(result2.Error);
		}
		return result;
	}

	public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result>> valueTaskPredicate)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure)
		{
			return result;
		}
		Result result2 = await valueTaskPredicate();
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static async ValueTask<Result> Ensure<T>(this ValueTask<Result> resultTask, Func<ValueTask<Result<T>>> valueTaskPredicate)
	{
		Result result = await resultTask;
		if (result.IsFailure)
		{
			return result;
		}
		Result<T> result2 = await valueTaskPredicate();
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T>>> valueTaskPredicate)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure)
		{
			return result;
		}
		Result<T> result2 = await valueTaskPredicate();
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result>> valueTaskPredicate)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure)
		{
			return result;
		}
		Result result2 = await valueTaskPredicate(result.Value);
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static async ValueTask<Result<T>> Ensure<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<T>>> valueTaskPredicate)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure)
		{
			return result;
		}
		Result<T> result2 = await valueTaskPredicate(result.Value);
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static async ValueTask<T> Finally<T>(this ValueTask<Result> resultTask, Func<Result, ValueTask<T>> valueTask)
	{
		return await valueTask(await resultTask);
	}

	public static async ValueTask<K> Finally<T, K>(this ValueTask<Result<T>> resultTask, Func<Result<T>, ValueTask<K>> valueTask)
	{
		return await valueTask(await resultTask);
	}

	public static async ValueTask<K> Finally<K, E>(this ValueTask<UnitResult<E>> resultTask, Func<UnitResult<E>, ValueTask<K>> valueTask)
	{
		return await valueTask(await resultTask);
	}

	public static async ValueTask<K> Finally<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<Result<T, E>, ValueTask<K>> valueTask)
	{
		return await valueTask(await resultTask);
	}

	public static async ValueTask<Result<K, E>> Map<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<K>> valueTask)
	{
		Result<T, E> result = await resultTask;
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(await valueTask(result.Value));
	}

	public static async ValueTask<Result<K, E>> Map<T, K, E, TContext>(this ValueTask<Result<T, E>> resultTask, Func<T, TContext, ValueTask<K>> valueTask, TContext context)
	{
		Result<T, E> result = await resultTask;
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(await valueTask(result.Value, context));
	}

	public static async ValueTask<Result<K, E>> Map<K, E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<K>> valueTask)
	{
		UnitResult<E> unitResult = await resultTask;
		if (unitResult.IsFailure)
		{
			return Result.Failure<K, E>(unitResult.Error);
		}
		return Result.Success<K, E>(await valueTask());
	}

	public static async ValueTask<Result<K, E>> Map<K, E, TContext>(this ValueTask<UnitResult<E>> resultTask, Func<TContext, ValueTask<K>> valueTask, TContext context)
	{
		UnitResult<E> unitResult = await resultTask;
		if (unitResult.IsFailure)
		{
			return Result.Failure<K, E>(unitResult.Error);
		}
		return Result.Success<K, E>(await valueTask(context));
	}

	public static async ValueTask<Result<K>> Map<T, K>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<K>> valueTask)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(await valueTask(result.Value));
	}

	public static async ValueTask<Result<K>> Map<T, K, TContext>(this ValueTask<Result<T>> resultTask, Func<T, TContext, ValueTask<K>> valueTask, TContext context)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(await valueTask(result.Value, context));
	}

	public static async ValueTask<Result<K>> Map<K>(this ValueTask<Result> resultTask, Func<ValueTask<K>> valueTask)
	{
		Result result = await resultTask;
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(await valueTask());
	}

	public static async ValueTask<Result<K>> Map<K, TContext>(this ValueTask<Result> resultTask, Func<TContext, ValueTask<K>> valueTask, TContext context)
	{
		Result result = await resultTask;
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(await valueTask(context));
	}

	public static async ValueTask<Result<K, E>> MapTry<T, K, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask<K>> valueTask, Func<Exception, E> errorHandler)
	{
		return await (await resultTask).MapTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result<K, E>> MapTry<K, E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask<K>> valueTask, Func<Exception, E> errorHandler)
	{
		return await (await resultTask).MapTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result<K>> MapTry<T, K>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<K>> valueTask, Func<Exception, string> errorHandler = null)
	{
		return await (await resultTask).MapTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result<K>> MapTry<K>(this ValueTask<Result> resultTask, Func<ValueTask<K>> valueTask, Func<Exception, string> errorHandler = null)
	{
		return await (await resultTask).MapTry(valueTask, errorHandler);
	}

	public static async ValueTask<Result<T, E>> OnFailureCompensate<T, E>(this ValueTask<Result<T, E>> resultTask, Func<ValueTask<Result<T, E>>> valueTask)
	{
		Result<T, E> result = await resultTask;
		if (result.IsFailure)
		{
			return await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result<T>> OnFailureCompensate<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<Result<T>>> valueTask)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure)
		{
			return await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result> OnFailureCompensate(this ValueTask<Result> resultTask, Func<ValueTask<Result>> valueTask)
	{
		Result result = await resultTask;
		if (result.IsFailure)
		{
			return await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result<T>> OnFailureCompensate<T>(this ValueTask<Result<T>> resultTask, Func<string, ValueTask<Result<T>>> valueTask)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure)
		{
			return await valueTask(result.Error);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> OnFailureCompensate<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, ValueTask<Result<T, E>>> valueTask)
	{
		Result<T, E> result = await resultTask;
		if (result.IsFailure)
		{
			return await valueTask(result.Error);
		}
		return result;
	}

	public static async ValueTask<Result> OnFailureCompensate(this ValueTask<Result> resultTask, Func<string, ValueTask<Result>> valueTask)
	{
		Result result = await resultTask;
		if (result.IsFailure)
		{
			return await valueTask(result.Error);
		}
		return result;
	}

	public static async ValueTask<Result> Tap(this ValueTask<Result> resultTask, Func<ValueTask> valueTask)
	{
		Result result = await resultTask;
		if (result.IsSuccess)
		{
			await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result<T>> Tap<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask> valueTask)
	{
		Result<T> result = await resultTask;
		if (result.IsSuccess)
		{
			await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result<T>> Tap<T>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask> valueTask)
	{
		Result<T> result = await resultTask;
		if (result.IsSuccess)
		{
			await valueTask(result.Value);
		}
		return result;
	}

	public static async ValueTask<UnitResult<E>> Tap<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask> valueTask)
	{
		UnitResult<E> result = await resultTask;
		if (result.IsSuccess)
		{
			await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> Tap<T, E>(this ValueTask<Result<T, E>> resultTask, Func<ValueTask> valueTask)
	{
		Result<T, E> result = await resultTask;
		if (result.IsSuccess)
		{
			await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> Tap<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, ValueTask> valueTask)
	{
		Result<T, E> result = await resultTask;
		if (result.IsSuccess)
		{
			await valueTask(result.Value);
		}
		return result;
	}

	public static ValueTask<Result> TapIf(this ValueTask<Result> resultTask, bool condition, Func<ValueTask> valueTask)
	{
		if (condition)
		{
			return resultTask.Tap(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<Result<T>> TapIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask> valueTask)
	{
		if (condition)
		{
			return resultTask.Tap(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<Result<T>> TapIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask> valueTask)
	{
		if (condition)
		{
			return resultTask.Tap(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<Result<T, E>> TapIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<ValueTask> valueTask)
	{
		if (condition)
		{
			return resultTask.Tap(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<Result<T, E>> TapIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<T, ValueTask> valueTask)
	{
		if (condition)
		{
			return resultTask.Tap(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<UnitResult<E>> TapIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Func<ValueTask> valueTask)
	{
		if (condition)
		{
			return resultTask.Tap(valueTask);
		}
		return resultTask;
	}

	public static async ValueTask<Result<T>> TapIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<ValueTask> valueTask)
	{
		Result<T> result = await resultTask;
		if (result.IsSuccess && predicate(result.Value))
		{
			return await result.Tap(valueTask);
		}
		return result;
	}

	public static async ValueTask<Result<T>> TapIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask> valueTask)
	{
		Result<T> result = await resultTask;
		if (result.IsSuccess && predicate(result.Value))
		{
			return await result.Tap(valueTask);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> TapIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<ValueTask> valueTask)
	{
		Result<T, E> result = await resultTask;
		if (result.IsSuccess && predicate(result.Value))
		{
			return await result.Tap(valueTask);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> TapIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, ValueTask> valueTask)
	{
		Result<T, E> result = await resultTask;
		if (result.IsSuccess && predicate(result.Value))
		{
			return await result.Tap(valueTask);
		}
		return result;
	}

	public static async ValueTask<UnitResult<E>> TapIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<bool> predicate, Func<ValueTask> valueTask)
	{
		UnitResult<E> result = await resultTask;
		if (result.IsSuccess && predicate())
		{
			return await result.Tap(valueTask);
		}
		return result;
	}
}
