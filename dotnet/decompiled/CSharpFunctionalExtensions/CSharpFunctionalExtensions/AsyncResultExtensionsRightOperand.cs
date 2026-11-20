using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions;

public static class AsyncResultExtensionsRightOperand
{
	public static Task<Result<K, E>> Bind<T, K, E>(this Result<T, E> result, Func<T, Task<Result<K, E>>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error).AsCompletedTask();
		}
		return func(result.Value);
	}

	public static Task<Result<K>> Bind<T, K>(this Result<T> result, Func<T, Task<Result<K>>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error).AsCompletedTask();
		}
		return func(result.Value);
	}

	public static Task<Result<K>> Bind<K>(this Result result, Func<Task<Result<K>>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error).AsCompletedTask();
		}
		return func();
	}

	public static Task<Result> Bind<T>(this Result<T> result, Func<T, Task<Result>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure(result.Error).AsCompletedTask();
		}
		return func(result.Value);
	}

	public static Task<Result> Bind(this Result result, Func<Task<Result>> func)
	{
		if (result.IsFailure)
		{
			return result.AsCompletedTask();
		}
		return func();
	}

	public static Task<UnitResult<E>> Bind<E>(this UnitResult<E> result, Func<Task<UnitResult<E>>> func)
	{
		if (result.IsFailure)
		{
			return UnitResult.Failure<E>(result.Error).AsCompletedTask();
		}
		return func();
	}

	public static Task<Result<T, E>> Bind<T, E>(this UnitResult<E> result, Func<Task<Result<T, E>>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<T, E>(result.Error).AsCompletedTask();
		}
		return func();
	}

	public static Task<UnitResult<E>> Bind<T, E>(this Result<T, E> result, Func<T, Task<UnitResult<E>>> func)
	{
		if (result.IsFailure)
		{
			return UnitResult.Failure<E>(result.Error).AsCompletedTask();
		}
		return func(result.Value);
	}

	public static async Task<Result<K, E>> BindTry<T, K, E>(this Result<T, E> result, Func<T, Task<Result<K, E>>> func, Func<Exception, E> errorHandler)
	{
		return (!result.IsFailure) ? (await Result.Try(() => func(result.Value), errorHandler).Bind((Result<K, E> r) => r).DefaultAwait()) : Result.Failure<K, E>(result.Error);
	}

	public static async Task<Result<K>> BindTry<T, K>(this Result<T> result, Func<T, Task<Result<K>>> func, Func<Exception, string> errorHandler = null)
	{
		return (!result.IsFailure) ? (await Result.Try(() => func(result.Value), errorHandler).Bind((Result<K> r) => r).DefaultAwait()) : Result.Failure<K>(result.Error);
	}

	public static async Task<Result<K>> BindTry<K>(this Result result, Func<Task<Result<K>>> func, Func<Exception, string> errorHandler = null)
	{
		return (!result.IsFailure) ? (await Result.Try(() => func(), errorHandler).Bind((Result<K> r) => r).DefaultAwait()) : Result.Failure<K>(result.Error);
	}

	public static async Task<Result> BindTry<T>(this Result<T> result, Func<T, Task<Result>> func, Func<Exception, string> errorHandler = null)
	{
		return (!result.IsFailure) ? (await Result.Try(() => func(result.Value), errorHandler).Bind((Result r) => r).DefaultAwait()) : Result.Failure(result.Error);
	}

	public static async Task<Result> BindTry(this Result result, Func<Task<Result>> func, Func<Exception, string> errorHandler = null)
	{
		return (!result.IsFailure) ? (await Result.Try(() => func(), errorHandler).Bind((Result r) => r).DefaultAwait()) : Result.Failure(result.Error);
	}

	public static async Task<UnitResult<E>> BindTry<E>(this UnitResult<E> result, Func<Task<UnitResult<E>>> func, Func<Exception, E> errorHandler)
	{
		return (!result.IsFailure) ? (await Result.Try(() => func(), errorHandler).Bind((UnitResult<E> r) => r).DefaultAwait()) : UnitResult.Failure<E>(result.Error);
	}

	public static async Task<Result<T, E>> BindTry<T, E>(this UnitResult<E> result, Func<Task<Result<T, E>>> func, Func<Exception, E> errorHandler)
	{
		return (!result.IsFailure) ? (await Result.Try(() => func(), errorHandler).Bind((Result<T, E> r) => r).DefaultAwait()) : Result.Failure<T, E>(result.Error);
	}

	public static async Task<UnitResult<E>> BindTry<T, E>(this Result<T, E> result, Func<T, Task<UnitResult<E>>> func, Func<Exception, E> errorHandler)
	{
		return (!result.IsFailure) ? (await Result.Try(() => func(result.Value), errorHandler).Bind((UnitResult<E> r) => r).DefaultAwait()) : UnitResult.Failure<E>(result.Error);
	}

	public static async Task<Result<T>> Check<T>(this Result<T> result, Func<T, Task<Result>> func)
	{
		return await result.Bind(func).Map(() => result.Value).DefaultAwait();
	}

	public static async Task<Result<T>> Check<T, K>(this Result<T> result, Func<T, Task<Result<K>>> func)
	{
		return await result.Bind(func).Map((K _) => result.Value).DefaultAwait();
	}

	public static async Task<Result<T, E>> Check<T, K, E>(this Result<T, E> result, Func<T, Task<Result<K, E>>> func)
	{
		return await result.Bind(func).Map((K _) => result.Value).DefaultAwait();
	}

	public static async Task<Result<T, E>> Check<T, E>(this Result<T, E> result, Func<T, Task<UnitResult<E>>> func)
	{
		return await result.Bind(func).Map(() => result.Value).DefaultAwait();
	}

	public static async Task<UnitResult<E>> Check<E>(this UnitResult<E> result, Func<Task<UnitResult<E>>> func)
	{
		return await result.Bind(func).Map(() => result).DefaultAwait();
	}

	public static Task<Result<T>> CheckIf<T>(this Result<T> result, bool condition, Func<T, Task<Result>> func)
	{
		if (condition)
		{
			return result.Check(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T>> CheckIf<T, K>(this Result<T> result, bool condition, Func<T, Task<Result<K>>> func)
	{
		if (condition)
		{
			return result.Check(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T, E>> CheckIf<T, K, E>(this Result<T, E> result, bool condition, Func<T, Task<Result<K, E>>> func)
	{
		if (condition)
		{
			return result.Check(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T, E>> CheckIf<T, E>(this Result<T, E> result, bool condition, Func<T, Task<UnitResult<E>>> func)
	{
		if (condition)
		{
			return result.Check(func);
		}
		return Task.FromResult(result);
	}

	public static Task<UnitResult<E>> CheckIf<E>(this UnitResult<E> result, bool condition, Func<Task<UnitResult<E>>> func)
	{
		if (condition)
		{
			return result.Check(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T>> CheckIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Task<Result>> func)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T>> CheckIf<T, K>(this Result<T> result, Func<T, bool> predicate, Func<T, Task<Result<K>>> func)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T, E>> CheckIf<T, K, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, Task<Result<K, E>>> func)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T, E>> CheckIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, Task<UnitResult<E>>> func)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(func);
		}
		return Task.FromResult(result);
	}

	public static async Task<UnitResult<E>> CheckIf<E>(this UnitResult<E> result, Func<bool> predicate, Func<Task<UnitResult<E>>> func)
	{
		if (result.IsSuccess && predicate())
		{
			return await result.Check(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T>> Ensure<T>(this Result<T> result, Func<T, Task<bool>> predicate, string errorMessage)
	{
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

	public static async Task<Result<T, E>> Ensure<T, E>(this Result<T, E> result, Func<T, Task<bool>> predicate, E error)
	{
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

	public static async Task<Result<T, E>> Ensure<T, E>(this Result<T, E> result, Func<T, Task<bool>> predicate, Func<T, E> errorPredicate)
	{
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

	public static async Task<Result<T, E>> Ensure<T, E>(this Result<T, E> result, Func<T, Task<bool>> predicate, Func<T, Task<E>> errorPredicate)
	{
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

	public static async Task<Result<T>> Ensure<T>(this Result<T> result, Func<T, Task<bool>> predicate, Func<T, string> errorPredicate)
	{
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

	public static async Task<Result<T>> Ensure<T>(this Result<T> result, Func<T, Task<bool>> predicate, Func<T, Task<string>> errorPredicate)
	{
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

	public static async Task<Result> Ensure(this Result result, Func<Task<bool>> predicate, string errorMessage)
	{
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

	public static async Task<Result> Ensure(this Result result, Func<Task<Result>> predicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		Result result2 = await predicate().DefaultAwait();
		if (result2.IsFailure)
		{
			return Result.Failure(result2.Error);
		}
		return result;
	}

	public static async Task<Result<T>> Ensure<T>(this Result<T> result, Func<Task<Result>> predicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		Result result2 = await predicate().DefaultAwait();
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static async Task<Result> Ensure<T>(this Result result, Func<Task<Result<T>>> predicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		Result<T> result2 = await predicate().DefaultAwait();
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static async Task<Result<T>> Ensure<T>(this Result<T> result, Func<Task<Result<T>>> predicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		Result<T> result2 = await predicate().DefaultAwait();
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static async Task<Result<T>> Ensure<T>(this Result<T> result, Func<T, Task<Result>> predicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		Result result2 = await predicate(result.Value).DefaultAwait();
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static async Task<Result<T>> Ensure<T>(this Result<T> result, Func<T, Task<Result<T>>> predicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		Result<T> result2 = await predicate(result.Value).DefaultAwait();
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static Task<T> Finally<T>(this Result result, Func<Result, Task<T>> func)
	{
		return func(result);
	}

	public static Task<K> Finally<T, K>(this Result<T> result, Func<Result<T>, Task<K>> func)
	{
		return func(result);
	}

	public static Task<K> Finally<K, E>(this UnitResult<E> result, Func<UnitResult<E>, Task<K>> func)
	{
		return func(result);
	}

	public static Task<K> Finally<T, K, E>(this Result<T, E> result, Func<Result<T, E>, Task<K>> func)
	{
		return func(result);
	}

	public static async Task<Result<K, E>> Map<T, K, E>(this Result<T, E> result, Func<T, Task<K>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(await func(result.Value).DefaultAwait());
	}

	public static async Task<Result<K, E>> Map<T, K, E, TContext>(this Result<T, E> result, Func<T, TContext, Task<K>> func, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(await func(result.Value, context).DefaultAwait());
	}

	public static async Task<Result<K, E>> Map<K, E>(this UnitResult<E> result, Func<Task<K>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(await func().DefaultAwait());
	}

	public static async Task<Result<K, E>> Map<K, E, TContext>(this UnitResult<E> result, Func<TContext, Task<K>> func, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(await func(context).DefaultAwait());
	}

	public static async Task<Result<K>> Map<T, K>(this Result<T> result, Func<T, Task<K>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(await func(result.Value).DefaultAwait());
	}

	public static async Task<Result<K>> Map<T, K, TContext>(this Result<T> result, Func<T, TContext, Task<K>> func, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(await func(result.Value, context).DefaultAwait());
	}

	public static async Task<Result<K>> Map<T, K>(this Result<T> result, Func<T, Task<Result<K>>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return await func(result.Value).DefaultAwait();
	}

	public static async Task<Result<K>> Map<T, K, TContext>(this Result<T> result, Func<T, TContext, Task<Result<K>>> func, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return await func(result.Value, context).DefaultAwait();
	}

	public static async Task<Result<K>> Map<K>(this Result result, Func<Task<K>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(await func().DefaultAwait());
	}

	public static async Task<Result<K>> Map<K, TContext>(this Result result, Func<TContext, Task<K>> func, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(await func(context).DefaultAwait());
	}

	public static async Task<Result<K, E>> MapTry<T, K, E>(this Result<T, E> result, Func<T, Task<K>> func, Func<Exception, E> errorHandler)
	{
		return (!result.IsFailure) ? (await Result.Try(() => func(result.Value), errorHandler).DefaultAwait()) : Result.Failure<K, E>(result.Error);
	}

	public static async Task<Result<K, E>> MapTry<K, E>(this UnitResult<E> result, Func<Task<K>> func, Func<Exception, E> errorHandler)
	{
		return (!result.IsFailure) ? (await Result.Try(() => func(), errorHandler).DefaultAwait()) : Result.Failure<K, E>(result.Error);
	}

	public static async Task<Result<K>> MapTry<T, K>(this Result<T> result, Func<T, Task<K>> func, Func<Exception, string> errorHandler = null)
	{
		return (!result.IsFailure) ? (await Result.Try(() => func(result.Value), errorHandler).DefaultAwait()) : Result.Failure<K>(result.Error);
	}

	public static async Task<Result<K>> MapTry<K>(this Result result, Func<Task<K>> func, Func<Exception, string> errorHandler = null)
	{
		return (!result.IsFailure) ? (await Result.Try(() => func(), errorHandler).DefaultAwait()) : Result.Failure<K>(result.Error);
	}

	public static async Task<Result<T>> OnFailureCompensate<T>(this Result<T> result, Func<Task<Result<T>>> func)
	{
		if (result.IsFailure)
		{
			return await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> OnFailureCompensate<T, E>(this Result<T, E> result, Func<Task<Result<T, E>>> func)
	{
		if (result.IsFailure)
		{
			return await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result> OnFailureCompensate(this Result result, Func<Task<Result>> func)
	{
		if (result.IsFailure)
		{
			return await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T>> OnFailureCompensate<T>(this Result<T> result, Func<string, Task<Result<T>>> func)
	{
		if (result.IsFailure)
		{
			return await func(result.Error).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> OnFailureCompensate<T, E>(this Result<T, E> result, Func<E, Task<Result<T, E>>> func)
	{
		if (result.IsFailure)
		{
			return await func(result.Error).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result> OnFailureCompensate(this Result result, Func<string, Task<Result>> func)
	{
		if (result.IsFailure)
		{
			return await func(result.Error).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result> Tap(this Result result, Func<Task> func)
	{
		if (result.IsSuccess)
		{
			await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T>> Tap<T>(this Result<T> result, Func<Task> func)
	{
		if (result.IsSuccess)
		{
			await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T>> Tap<T>(this Result<T> result, Func<T, Task> func)
	{
		if (result.IsSuccess)
		{
			await func(result.Value).DefaultAwait();
		}
		return result;
	}

	public static async Task<UnitResult<E>> Tap<E>(this UnitResult<E> result, Func<Task> func)
	{
		if (result.IsSuccess)
		{
			await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> Tap<T, E>(this Result<T, E> result, Func<Task> func)
	{
		if (result.IsSuccess)
		{
			await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> Tap<T, E>(this Result<T, E> result, Func<T, Task> func)
	{
		if (result.IsSuccess)
		{
			await func(result.Value).DefaultAwait();
		}
		return result;
	}

	public static Task<Result> TapIf(this Result result, bool condition, Func<Task> func)
	{
		if (condition)
		{
			return result.Tap(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T>> TapIf<T>(this Result<T> result, bool condition, Func<Task> func)
	{
		if (condition)
		{
			return result.Tap(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T>> TapIf<T>(this Result<T> result, bool condition, Func<T, Task> func)
	{
		if (condition)
		{
			return result.Tap(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T, E>> TapIf<T, E>(this Result<T, E> result, bool condition, Func<Task> func)
	{
		if (condition)
		{
			return result.Tap(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T, E>> TapIf<T, E>(this Result<T, E> result, bool condition, Func<T, Task> func)
	{
		if (condition)
		{
			return result.Tap(func);
		}
		return Task.FromResult(result);
	}

	public static Task<UnitResult<E>> TapIf<E>(this UnitResult<E> result, bool condition, Func<Task> func)
	{
		if (condition)
		{
			return result.Tap(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T>> TapIf<T>(this Result<T> result, Func<T, bool> predicate, Func<Task> func)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T>> TapIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Task> func)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T, E>> TapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<Task> func)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T, E>> TapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, Task> func)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(func);
		}
		return Task.FromResult(result);
	}

	public static Task<UnitResult<E>> TapIf<E>(this UnitResult<E> result, Func<bool> predicate, Func<Task> func)
	{
		if (result.IsSuccess && predicate())
		{
			return result.Tap(func);
		}
		return Task.FromResult(result);
	}

	public static async Task<Result> TapIfTry(this Result result, bool condition, Func<Task> func, Func<Exception, string> errorHandler = null)
	{
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

	public static async Task<Result<T>> TapIfTry<T>(this Result<T> result, bool condition, Func<Task> func, Func<Exception, string> errorHandler = null)
	{
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

	public static async Task<Result<T>> TapIfTry<T>(this Result<T> result, bool condition, Func<T, Task> func, Func<Exception, string> errorHandler = null)
	{
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

	public static async Task<UnitResult<E>> TapIfTry<E>(this UnitResult<E> result, bool condition, Func<Task> func, Func<Exception, E> errorHandler)
	{
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

	public static async Task<Result<T, E>> TapIfTry<T, E>(this Result<T, E> result, bool condition, Func<Task> func, Func<Exception, E> errorHandler)
	{
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

	public static async Task<Result<T, E>> TapIfTry<T, E>(this Result<T, E> result, bool condition, Func<T, Task> func, Func<Exception, E> errorHandler)
	{
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

	public static async Task<Result<T>> TapIfTry<T>(this Result<T> result, Func<T, bool> predicate, Func<Task> func, Func<Exception, string> errorHandler = null)
	{
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

	public static async Task<Result<T>> TapIfTry<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Task> func, Func<Exception, string> errorHandler = null)
	{
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

	public static async Task<Result<T, E>> TapIfTry<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<Task> func, Func<Exception, E> errorHandler)
	{
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

	public static async Task<Result<T, E>> TapIfTry<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, Task> func, Func<Exception, E> errorHandler)
	{
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

	public static async Task<Result> TapTry(this Result result, Func<Task> func, Func<Exception, string> errorHandler = null)
	{
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

	public static async Task<Result<T>> TapTry<T>(this Result<T> result, Func<Task> func, Func<Exception, string> errorHandler = null)
	{
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

	public static async Task<Result<T>> TapTry<T>(this Result<T> result, Func<T, Task> func, Func<Exception, string> errorHandler = null)
	{
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

	public static async Task<UnitResult<E>> TapTry<E>(this UnitResult<E> result, Func<Task> func, Func<Exception, E> errorHandler)
	{
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

	public static async Task<Result<T, E>> TapTry<T, E>(this Result<T, E> result, Func<Task> func, Func<Exception, E> errorHandler)
	{
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

	public static async Task<Result<T, E>> TapTry<T, E>(this Result<T, E> result, Func<T, Task> func, Func<Exception, E> errorHandler)
	{
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
