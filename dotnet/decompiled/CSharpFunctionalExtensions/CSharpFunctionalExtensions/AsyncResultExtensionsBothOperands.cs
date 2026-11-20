using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions;

public static class AsyncResultExtensionsBothOperands
{
	public static async Task<Result<K, E>> Bind<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<Result<K, E>>> func)
	{
		return await (await resultTask.DefaultAwait()).Bind(func).DefaultAwait();
	}

	public static async Task<Result<K>> Bind<T, K>(this Task<Result<T>> resultTask, Func<T, Task<Result<K>>> func)
	{
		return await (await resultTask.DefaultAwait()).Bind(func).DefaultAwait();
	}

	public static async Task<Result<K>> Bind<K>(this Task<Result> resultTask, Func<Task<Result<K>>> func)
	{
		return await (await resultTask.DefaultAwait()).Bind(func).DefaultAwait();
	}

	public static async Task<Result> Bind<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> func)
	{
		return await (await resultTask.DefaultAwait()).Bind(func).DefaultAwait();
	}

	public static async Task<Result> Bind(this Task<Result> resultTask, Func<Task<Result>> func)
	{
		return await (await resultTask.DefaultAwait()).Bind(func).DefaultAwait();
	}

	public static async Task<UnitResult<E>> Bind<E>(this Task<UnitResult<E>> resultTask, Func<Task<UnitResult<E>>> func)
	{
		return await (await resultTask.DefaultAwait()).Bind(func).DefaultAwait();
	}

	public static async Task<Result<T, E>> Bind<T, E>(this Task<UnitResult<E>> resultTask, Func<Task<Result<T, E>>> func)
	{
		return await (await resultTask.DefaultAwait()).Bind(func).DefaultAwait();
	}

	public static async Task<UnitResult<E>> Bind<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task<UnitResult<E>>> func)
	{
		return await (await resultTask.DefaultAwait()).Bind(func).DefaultAwait();
	}

	public static async Task<Result> BindTry(this Task<Result> resultTask, Func<Task<Result>> func, Func<Exception, string> errorHandler = null)
	{
		return await (await resultTask.DefaultAwait()).BindTry(func, errorHandler).DefaultAwait();
	}

	public static async Task<Result<K>> BindTry<K>(this Task<Result> resultTask, Func<Task<Result<K>>> func, Func<Exception, string> errorHandler = null)
	{
		return await (await resultTask.DefaultAwait()).BindTry(func, errorHandler).DefaultAwait();
	}

	public static async Task<Result> BindTry<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> func, Func<Exception, string> errorHandler = null)
	{
		return await (await resultTask.DefaultAwait()).BindTry(func, errorHandler).DefaultAwait();
	}

	public static async Task<Result<K>> BindTry<T, K>(this Task<Result<T>> resultTask, Func<T, Task<Result<K>>> func, Func<Exception, string> errorHandler = null)
	{
		return await (await resultTask.DefaultAwait()).BindTry(func, errorHandler).DefaultAwait();
	}

	public static async Task<UnitResult<E>> BindTry<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task<UnitResult<E>>> func, Func<Exception, E> errorHandler)
	{
		return await (await resultTask.DefaultAwait()).BindTry(func, errorHandler).DefaultAwait();
	}

	public static async Task<Result<K, E>> BindTry<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<Result<K, E>>> func, Func<Exception, E> errorHandler)
	{
		return await (await resultTask.DefaultAwait()).BindTry(func, errorHandler).DefaultAwait();
	}

	public static async Task<Result<T, E>> BindTry<T, E>(this Task<UnitResult<E>> resultTask, Func<Task<Result<T, E>>> func, Func<Exception, E> errorHandler)
	{
		return await (await resultTask.DefaultAwait()).BindTry(func, errorHandler).DefaultAwait();
	}

	public static async Task<UnitResult<E>> BindTry<E>(this Task<UnitResult<E>> resultTask, Func<Task<UnitResult<E>>> func, Func<Exception, E> errorHandler)
	{
		return await (await resultTask.DefaultAwait()).BindTry(func, errorHandler).DefaultAwait();
	}

	public static async Task<Result<T>> Check<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		return await result.Bind(func).Map(() => result.Value).DefaultAwait();
	}

	public static async Task<Result<T>> Check<T, K>(this Task<Result<T>> resultTask, Func<T, Task<Result<K>>> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		return await result.Bind(func).Map((K _) => result.Value).DefaultAwait();
	}

	public static async Task<Result<T, E>> Check<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<Result<K, E>>> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		return await result.Bind(func).Map((K _) => result.Value).DefaultAwait();
	}

	public static async Task<Result<T, E>> Check<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task<UnitResult<E>>> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		return await result.Bind(func).Map(() => result.Value).DefaultAwait();
	}

	public static async Task<UnitResult<E>> Check<E>(this Task<UnitResult<E>> resultTask, Func<Task<UnitResult<E>>> func)
	{
		UnitResult<E> result = await resultTask.DefaultAwait();
		return await result.Bind(func).Map(() => result).DefaultAwait();
	}

	public static Task<Result<T>> CheckIf<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result>> func)
	{
		if (condition)
		{
			return resultTask.Check(func);
		}
		return resultTask;
	}

	public static Task<Result<T>> CheckIf<T, K>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result<K>>> func)
	{
		if (condition)
		{
			return resultTask.Check(func);
		}
		return resultTask;
	}

	public static Task<Result<T, E>> CheckIf<T, K, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, Task<Result<K, E>>> func)
	{
		if (condition)
		{
			return resultTask.Check(func);
		}
		return resultTask;
	}

	public static Task<Result<T, E>> CheckIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, Task<UnitResult<E>>> func)
	{
		if (condition)
		{
			return resultTask.Check(func);
		}
		return resultTask;
	}

	public static Task<UnitResult<E>> CheckIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Func<Task<UnitResult<E>>> func)
	{
		if (condition)
		{
			return resultTask.Check(func);
		}
		return resultTask;
	}

	public static async Task<Result<T>> CheckIf<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Result>> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate(result.Value))
		{
			return await result.Check(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T>> CheckIf<T, K>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Result<K>>> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate(result.Value))
		{
			return await result.Check(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> CheckIf<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Task<Result<K, E>>> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate(result.Value))
		{
			return await result.Check(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> CheckIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Task<UnitResult<E>>> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate(result.Value))
		{
			return await result.Check(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<UnitResult<E>> CheckIf<E>(this Task<UnitResult<E>> resultTask, Func<bool> predicate, Func<Task<UnitResult<E>>> func)
	{
		UnitResult<E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate())
		{
			return await result.Check(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, Task<bool>> predicate, string errorMessage)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await predicate(result.Value).DefaultAwait()))
		{
			return Result.Failure<T>(errorMessage);
		}
		return result;
	}

	public static async Task<Result<T, E>> Ensure<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task<bool>> predicate, E error)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await predicate(result.Value).DefaultAwait()))
		{
			return Result.Failure<T, E>(error);
		}
		return result;
	}

	public static async Task<Result<T, E>> Ensure<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task<bool>> predicate, Func<T, E> errorPredicate)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await predicate(result.Value).DefaultAwait()))
		{
			return Result.Failure<T, E>(errorPredicate(result.Value));
		}
		return result;
	}

	public static async Task<Result<T, E>> Ensure<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task<bool>> predicate, Func<T, Task<E>> errorPredicate)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await predicate(result.Value).DefaultAwait()))
		{
			return Result.Failure<T, E>(await errorPredicate(result.Value).DefaultAwait());
		}
		return result;
	}

	public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, Task<bool>> predicate, Func<T, string> errorPredicate)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await predicate(result.Value).DefaultAwait()))
		{
			return Result.Failure<T>(errorPredicate(result.Value));
		}
		return result;
	}

	public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, Task<bool>> predicate, Func<T, Task<string>> errorPredicate)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await predicate(result.Value).DefaultAwait()))
		{
			return Result.Failure<T>(await errorPredicate(result.Value).DefaultAwait());
		}
		return result;
	}

	public static async Task<Result> Ensure(this Task<Result> resultTask, Func<Task<bool>> predicate, string errorMessage)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await predicate().DefaultAwait()))
		{
			return Result.Failure(errorMessage);
		}
		return result;
	}

	public static async Task<Result> Ensure(this Task<Result> resultTask, Func<Task<Result>> predicate)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return result;
		}
		Result result2 = await predicate();
		if (result2.IsFailure)
		{
			return Result.Failure(result2.Error);
		}
		return result;
	}

	public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<Task<Result>> predicate)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return result;
		}
		Result result2 = await predicate();
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static async Task<Result> Ensure<T>(this Task<Result> resultTask, Func<Task<Result<T>>> predicate)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return result;
		}
		Result<T> result2 = await predicate();
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<Task<Result<T>>> predicate)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return result;
		}
		Result<T> result2 = await predicate();
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, Task<Result>> predicate)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return result;
		}
		Result result2 = await predicate(result.Value);
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static async Task<Result<T>> Ensure<T>(this Task<Result<T>> resultTask, Func<T, Task<Result<T>>> predicate)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return result;
		}
		Result<T> result2 = await predicate(result.Value);
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static async Task<T> Finally<T>(this Task<Result> resultTask, Func<Result, Task<T>> func)
	{
		return await func(await resultTask.DefaultAwait()).DefaultAwait();
	}

	public static async Task<K> Finally<T, K>(this Task<Result<T>> resultTask, Func<Result<T>, Task<K>> func)
	{
		return await func(await resultTask.DefaultAwait()).DefaultAwait();
	}

	public static async Task<K> Finally<K, E>(this Task<UnitResult<E>> resultTask, Func<UnitResult<E>, Task<K>> func)
	{
		return await func(await resultTask.DefaultAwait()).DefaultAwait();
	}

	public static async Task<K> Finally<T, K, E>(this Task<Result<T, E>> resultTask, Func<Result<T, E>, Task<K>> func)
	{
		return await func(await resultTask.DefaultAwait()).DefaultAwait();
	}

	public static async Task<Result<K, E>> Map<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<K>> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(await func(result.Value).DefaultAwait());
	}

	public static async Task<Result<K, E>> Map<T, K, E, TContext>(this Task<Result<T, E>> resultTask, Func<T, TContext, Task<K>> func, TContext context)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(await func(result.Value, context).DefaultAwait());
	}

	public static async Task<Result<K, E>> Map<K, E>(this Task<UnitResult<E>> resultTask, Func<Task<K>> func)
	{
		UnitResult<E> unitResult = await resultTask.DefaultAwait();
		if (unitResult.IsFailure)
		{
			return Result.Failure<K, E>(unitResult.Error);
		}
		return Result.Success<K, E>(await func().DefaultAwait());
	}

	public static async Task<Result<K, E>> Map<K, E, TContext>(this Task<UnitResult<E>> resultTask, Func<TContext, Task<K>> func, TContext context)
	{
		UnitResult<E> unitResult = await resultTask.DefaultAwait();
		if (unitResult.IsFailure)
		{
			return Result.Failure<K, E>(unitResult.Error);
		}
		return Result.Success<K, E>(await func(context).DefaultAwait());
	}

	public static async Task<Result<K>> Map<T, K>(this Task<Result<T>> resultTask, Func<T, Task<K>> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(await func(result.Value).DefaultAwait());
	}

	public static async Task<Result<K>> Map<T, K, TContext>(this Task<Result<T>> resultTask, Func<T, TContext, Task<K>> func, TContext context)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(await func(result.Value, context).DefaultAwait());
	}

	public static async Task<Result<K>> Map<K>(this Task<Result> resultTask, Func<Task<K>> func)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(await func().DefaultAwait());
	}

	public static async Task<Result<K>> Map<K, TContext>(this Task<Result> resultTask, Func<TContext, Task<K>> func, TContext context)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(await func(context).DefaultAwait());
	}

	public static async Task<Result<K, E>> MapTry<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<K>> func, Func<Exception, E> errorHandler)
	{
		return await (await resultTask.DefaultAwait()).MapTry(func, errorHandler).DefaultAwait();
	}

	public static async Task<Result<K, E>> MapTry<K, E>(this Task<UnitResult<E>> resultTask, Func<Task<K>> func, Func<Exception, E> errorHandler)
	{
		return await (await resultTask.DefaultAwait()).MapTry(func, errorHandler).DefaultAwait();
	}

	public static async Task<Result<K>> MapTry<T, K>(this Task<Result<T>> resultTask, Func<T, Task<K>> func, Func<Exception, string> errorHandler = null)
	{
		return await (await resultTask.DefaultAwait()).MapTry(func, errorHandler).DefaultAwait();
	}

	public static async Task<Result<K>> MapTry<K>(this Task<Result> resultTask, Func<Task<K>> func, Func<Exception, string> errorHandler = null)
	{
		return await (await resultTask.DefaultAwait()).MapTry(func, errorHandler).DefaultAwait();
	}

	public static async Task<Result<T, E>> OnFailureCompensate<T, E>(this Task<Result<T, E>> resultTask, Func<Task<Result<T, E>>> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T>> OnFailureCompensate<T>(this Task<Result<T>> resultTask, Func<Task<Result<T>>> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result> OnFailureCompensate(this Task<Result> resultTask, Func<Task<Result>> func)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T>> OnFailureCompensate<T>(this Task<Result<T>> resultTask, Func<string, Task<Result<T>>> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return await func(result.Error).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> OnFailureCompensate<T, E>(this Task<Result<T, E>> resultTask, Func<E, Task<Result<T, E>>> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return await func(result.Error).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result> OnFailureCompensate(this Task<Result> resultTask, Func<string, Task<Result>> func)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return await func(result.Error).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result> Tap(this Task<Result> resultTask, Func<Task> func)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T>> Tap<T>(this Task<Result<T>> resultTask, Func<Task> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T>> Tap<T>(this Task<Result<T>> resultTask, Func<T, Task> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			await func(result.Value).DefaultAwait();
		}
		return result;
	}

	public static async Task<UnitResult<E>> Tap<E>(this Task<UnitResult<E>> resultTask, Func<Task> func)
	{
		UnitResult<E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> Tap<T, E>(this Task<Result<T, E>> resultTask, Func<Task> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> Tap<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			await func(result.Value).DefaultAwait();
		}
		return result;
	}

	public static Task<Result> TapIf(this Task<Result> resultTask, bool condition, Func<Task> func)
	{
		if (condition)
		{
			return resultTask.Tap(func);
		}
		return resultTask;
	}

	public static Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, bool condition, Func<Task> func)
	{
		if (condition)
		{
			return resultTask.Tap(func);
		}
		return resultTask;
	}

	public static Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task> func)
	{
		if (condition)
		{
			return resultTask.Tap(func);
		}
		return resultTask;
	}

	public static Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<Task> func)
	{
		if (condition)
		{
			return resultTask.Tap(func);
		}
		return resultTask;
	}

	public static Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, Task> func)
	{
		if (condition)
		{
			return resultTask.Tap(func);
		}
		return resultTask;
	}

	public static Task<UnitResult<E>> TapIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Func<Task> func)
	{
		if (condition)
		{
			return resultTask.Tap(func);
		}
		return resultTask;
	}

	public static async Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Task> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate(result.Value))
		{
			return await result.Tap(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T>> TapIf<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate(result.Value))
		{
			return await result.Tap(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<Task> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate(result.Value))
		{
			return await result.Tap(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Task> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate(result.Value))
		{
			return await result.Tap(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<UnitResult<E>> TapIf<E>(this Task<UnitResult<E>> resultTask, Func<bool> predicate, Func<Task> func)
	{
		UnitResult<E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess && predicate())
		{
			return await result.Tap(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, Func<Task<bool>> predicate, Func<T, Task> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		bool flag = result.IsSuccess;
		if (flag)
		{
			flag = await predicate().DefaultAwait();
		}
		if (flag)
		{
			return await result.Tap(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> TapIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task<bool>> predicate, Func<T, Task> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		bool flag = result.IsSuccess;
		if (flag)
		{
			flag = await predicate(result.Value).DefaultAwait();
		}
		if (flag)
		{
			return await result.Tap(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result> TapIfTry(this Task<Result> resultTask, bool condition, Func<Task> func, Func<Exception, string> errorHandler = null)
	{
		Result result = await resultTask.DefaultAwait();
		if (errorHandler == null)
		{
			errorHandler = Result.Configuration.DefaultTryErrorHandler;
		}
		try
		{
			if (condition && result.IsSuccess)
			{
				await func();
			}
			return result;
		}
		catch (Exception arg)
		{
			return Result.Failure(errorHandler(arg));
		}
	}

	public static async Task<Result<T>> TapIfTry<T>(this Task<Result<T>> resultTask, bool condition, Func<Task> func, Func<Exception, string> errorHandler = null)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (errorHandler == null)
		{
			errorHandler = Result.Configuration.DefaultTryErrorHandler;
		}
		try
		{
			if (condition && result.IsSuccess)
			{
				await func();
			}
			return result;
		}
		catch (Exception arg)
		{
			string error = errorHandler(arg);
			return new Result<T>(isFailure: true, error, default(T));
		}
	}

	public static async Task<Result<T>> TapIfTry<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task> func, Func<Exception, string> errorHandler = null)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (errorHandler == null)
		{
			errorHandler = Result.Configuration.DefaultTryErrorHandler;
		}
		try
		{
			if (condition && result.IsSuccess)
			{
				await func(result.Value);
			}
			return result;
		}
		catch (Exception arg)
		{
			string error = errorHandler(arg);
			return new Result<T>(isFailure: true, error, default(T));
		}
	}

	public static async Task<UnitResult<E>> TapIfTry<E>(this Task<UnitResult<E>> resultTask, bool condition, Func<Task> func, Func<Exception, E> errorHandler)
	{
		UnitResult<E> result = await resultTask.DefaultAwait();
		try
		{
			if (condition && result.IsSuccess)
			{
				await func();
			}
			return result;
		}
		catch (Exception arg)
		{
			return new UnitResult<E>(isFailure: true, errorHandler(arg));
		}
	}

	public static async Task<Result<T, E>> TapIfTry<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<Task> func, Func<Exception, E> errorHandler)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		try
		{
			if (condition && result.IsSuccess)
			{
				await func();
			}
			return result;
		}
		catch (Exception arg)
		{
			E error = errorHandler(arg);
			return new Result<T, E>(isFailure: true, error, default(T));
		}
	}

	public static async Task<Result<T, E>> TapIfTry<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, Task> func, Func<Exception, E> errorHandler)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		try
		{
			if (condition && result.IsSuccess)
			{
				await func(result.Value);
			}
			return result;
		}
		catch (Exception arg)
		{
			E error = errorHandler(arg);
			return new Result<T, E>(isFailure: true, error, default(T));
		}
	}

	public static async Task<Result<T>> TapIfTry<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<Task> func, Func<Exception, string> errorHandler = null)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (errorHandler == null)
		{
			errorHandler = Result.Configuration.DefaultTryErrorHandler;
		}
		try
		{
			if (result.IsSuccess && predicate(result.Value) && result.IsSuccess)
			{
				await func();
			}
			return result;
		}
		catch (Exception arg)
		{
			string error = errorHandler(arg);
			return new Result<T>(isFailure: true, error, default(T));
		}
	}

	public static async Task<Result<T>> TapIfTry<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task> func, Func<Exception, string> errorHandler = null)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (errorHandler == null)
		{
			errorHandler = Result.Configuration.DefaultTryErrorHandler;
		}
		try
		{
			if (result.IsSuccess && predicate(result.Value))
			{
				await func(result.Value);
			}
			return result;
		}
		catch (Exception arg)
		{
			string error = errorHandler(arg);
			return new Result<T>(isFailure: true, error, default(T));
		}
	}

	public static async Task<Result<T, E>> TapIfTry<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<Task> func, Func<Exception, E> errorHandler)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		try
		{
			if (result.IsSuccess && predicate(result.Value))
			{
				await func();
			}
			return result;
		}
		catch (Exception arg)
		{
			E error = errorHandler(arg);
			return new Result<T, E>(isFailure: true, error, default(T));
		}
	}

	public static async Task<Result<T, E>> TapIfTry<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Task> func, Func<Exception, E> errorHandler)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		try
		{
			if (result.IsSuccess && predicate(result.Value))
			{
				await func(result.Value);
			}
			return result;
		}
		catch (Exception arg)
		{
			E error = errorHandler(arg);
			return new Result<T, E>(isFailure: true, error, default(T));
		}
	}

	public static async Task<Result> TapTry(this Task<Result> resultTask, Func<Task> func, Func<Exception, string> errorHandler = null)
	{
		Result result = await resultTask.DefaultAwait();
		if (errorHandler == null)
		{
			errorHandler = Result.Configuration.DefaultTryErrorHandler;
		}
		try
		{
			if (result.IsSuccess)
			{
				await func().DefaultAwait();
			}
			return result;
		}
		catch (Exception arg)
		{
			return Result.Failure(errorHandler(arg));
		}
	}

	public static async Task<Result<T>> TapTry<T>(this Task<Result<T>> resultTask, Func<Task> func, Func<Exception, string> errorHandler = null)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (errorHandler == null)
		{
			errorHandler = Result.Configuration.DefaultTryErrorHandler;
		}
		try
		{
			if (result.IsSuccess)
			{
				await func().DefaultAwait();
			}
			return result;
		}
		catch (Exception arg)
		{
			string error = errorHandler(arg);
			return new Result<T>(isFailure: true, error, default(T));
		}
	}

	public static async Task<Result<T>> TapTry<T>(this Task<Result<T>> resultTask, Func<T, Task> func, Func<Exception, string> errorHandler = null)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (errorHandler == null)
		{
			errorHandler = Result.Configuration.DefaultTryErrorHandler;
		}
		try
		{
			if (result.IsSuccess)
			{
				await func(result.Value).DefaultAwait();
			}
			return result;
		}
		catch (Exception arg)
		{
			string error = errorHandler(arg);
			return new Result<T>(isFailure: true, error, default(T));
		}
	}

	public static async Task<UnitResult<E>> TapTry<E>(this Task<UnitResult<E>> resultTask, Func<Task> func, Func<Exception, E> errorHandler)
	{
		UnitResult<E> result = await resultTask.DefaultAwait();
		try
		{
			if (result.IsSuccess)
			{
				await func().DefaultAwait();
			}
			return result;
		}
		catch (Exception arg)
		{
			return new UnitResult<E>(isFailure: true, errorHandler(arg));
		}
	}

	public static async Task<Result<T, E>> TapTry<T, E>(this Task<Result<T, E>> resultTask, Func<Task> func, Func<Exception, E> errorHandler)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		try
		{
			if (result.IsSuccess)
			{
				await func().DefaultAwait();
			}
			return result;
		}
		catch (Exception arg)
		{
			E error = errorHandler(arg);
			return new Result<T, E>(isFailure: true, error, default(T));
		}
	}

	public static async Task<Result<T, E>> TapTry<T, E>(this Task<Result<T, E>> resultTask, Func<T, Task> func, Func<Exception, E> errorHandler)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		try
		{
			if (result.IsSuccess)
			{
				await func(result.Value).DefaultAwait();
			}
			return result;
		}
		catch (Exception arg)
		{
			E error = errorHandler(arg);
			return new Result<T, E>(isFailure: true, error, default(T));
		}
	}
}
