using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks;

public static class AsyncResultExtensionsRightOperand
{
	public static ValueTask<Result<K, E>> Bind<T, K, E>(this Result<T, E> result, Func<T, ValueTask<Result<K, E>>> valueTask)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error).AsCompletedValueTask();
		}
		return valueTask(result.Value);
	}

	public static ValueTask<Result<K>> Bind<T, K>(this Result<T> result, Func<T, ValueTask<Result<K>>> valueTask)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error).AsCompletedValueTask();
		}
		return valueTask(result.Value);
	}

	public static ValueTask<Result<K>> Bind<K>(this Result result, Func<ValueTask<Result<K>>> valueTask)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error).AsCompletedValueTask();
		}
		return valueTask();
	}

	public static ValueTask<Result> Bind<T>(this Result<T> result, Func<T, ValueTask<Result>> valueTask)
	{
		if (result.IsFailure)
		{
			return Result.Failure(result.Error).AsCompletedValueTask();
		}
		return valueTask(result.Value);
	}

	public static ValueTask<Result> Bind(this Result result, Func<ValueTask<Result>> valueTask)
	{
		if (result.IsFailure)
		{
			return result.AsCompletedValueTask();
		}
		return valueTask();
	}

	public static ValueTask<UnitResult<E>> Bind<E>(this UnitResult<E> result, Func<ValueTask<UnitResult<E>>> valueTask)
	{
		if (result.IsFailure)
		{
			return UnitResult.Failure<E>(result.Error).AsCompletedValueTask();
		}
		return valueTask();
	}

	public static ValueTask<Result<T, E>> Bind<T, E>(this UnitResult<E> result, Func<ValueTask<Result<T, E>>> valueTask)
	{
		if (result.IsFailure)
		{
			return Result.Failure<T, E>(result.Error).AsCompletedValueTask();
		}
		return valueTask();
	}

	public static ValueTask<UnitResult<E>> Bind<T, E>(this Result<T, E> result, Func<T, ValueTask<UnitResult<E>>> valueTask)
	{
		if (result.IsFailure)
		{
			return UnitResult.Failure<E>(result.Error).AsCompletedValueTask();
		}
		return valueTask(result.Value);
	}

	public static async ValueTask<Result<K, E>> BindTry<T, K, E>(this Result<T, E> result, Func<T, ValueTask<Result<K, E>>> valueTask, Func<Exception, E> errorHandler)
	{
		return (!result.IsFailure) ? (await Result.Try(async () => await valueTask(result.Value), errorHandler).Bind((Result<K, E> r) => r)) : Result.Failure<K, E>(result.Error);
	}

	public static async ValueTask<Result<K>> BindTry<T, K>(this Result<T> result, Func<T, ValueTask<Result<K>>> valueTask, Func<Exception, string> errorHandler = null)
	{
		return (!result.IsFailure) ? (await Result.Try(async () => await valueTask(result.Value), errorHandler).Bind((Result<K> r) => r)) : Result.Failure<K>(result.Error);
	}

	public static async ValueTask<Result<K>> BindTry<K>(this Result result, Func<ValueTask<Result<K>>> valueTask, Func<Exception, string> errorHandler = null)
	{
		return (!result.IsFailure) ? (await Result.Try(async () => await valueTask(), errorHandler).Bind((Result<K> r) => r)) : Result.Failure<K>(result.Error);
	}

	public static async ValueTask<Result> BindTry<T>(this Result<T> result, Func<T, ValueTask<Result>> valueTask, Func<Exception, string> errorHandler = null)
	{
		return (!result.IsFailure) ? (await Result.Try(async () => await valueTask(result.Value), errorHandler).Bind((Result r) => r)) : Result.Failure(result.Error);
	}

	public static async ValueTask<Result> BindTry(this Result result, Func<ValueTask<Result>> valueTask, Func<Exception, string> errorHandler = null)
	{
		return (!result.IsFailure) ? (await Result.Try(async () => await valueTask(), errorHandler).Bind((Result r) => r)) : Result.Failure(result.Error);
	}

	public static async ValueTask<UnitResult<E>> BindTry<E>(this UnitResult<E> result, Func<ValueTask<UnitResult<E>>> valueTask, Func<Exception, E> errorHandler)
	{
		return (!result.IsFailure) ? (await Result.Try(async () => await valueTask(), errorHandler).Bind((UnitResult<E> r) => r)) : UnitResult.Failure<E>(result.Error);
	}

	public static async ValueTask<Result<T, E>> BindTry<T, E>(this UnitResult<E> result, Func<ValueTask<Result<T, E>>> valueTask, Func<Exception, E> errorHandler)
	{
		return (!result.IsFailure) ? (await Result.Try(async () => await valueTask(), errorHandler).Bind((Result<T, E> r) => r)) : Result.Failure<T, E>(result.Error);
	}

	public static async ValueTask<UnitResult<E>> BindTry<T, E>(this Result<T, E> result, Func<T, ValueTask<UnitResult<E>>> valueTask, Func<Exception, E> errorHandler)
	{
		return (!result.IsFailure) ? (await Result.Try(async () => await valueTask(result.Value), errorHandler).Bind((UnitResult<E> r) => r)) : UnitResult.Failure<E>(result.Error);
	}

	public static async ValueTask<Result<T>> Check<T>(this Result<T> result, Func<T, ValueTask<Result>> valueTask)
	{
		return await result.Bind(valueTask).Map(() => result.Value);
	}

	public static async ValueTask<Result<T>> Check<T, K>(this Result<T> result, Func<T, ValueTask<Result<K>>> valueTask)
	{
		return await result.Bind(valueTask).Map((K _) => result.Value);
	}

	public static async ValueTask<Result<T, E>> Check<T, K, E>(this Result<T, E> result, Func<T, ValueTask<Result<K, E>>> valueTask)
	{
		return await result.Bind(valueTask).Map((K _) => result.Value);
	}

	public static async ValueTask<Result<T, E>> Check<T, E>(this Result<T, E> result, Func<T, ValueTask<UnitResult<E>>> valueTask)
	{
		return await result.Bind(valueTask).Map(() => result.Value);
	}

	public static async ValueTask<UnitResult<E>> Check<E>(this UnitResult<E> result, Func<ValueTask<UnitResult<E>>> valueTask)
	{
		return await result.Bind(valueTask).Map(() => result);
	}

	public static ValueTask<Result<T>> CheckIf<T>(this Result<T> result, bool condition, Func<T, ValueTask<Result>> valueTask)
	{
		if (condition)
		{
			return result.Check(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T>> CheckIf<T, K>(this Result<T> result, bool condition, Func<T, ValueTask<Result<K>>> valueTask)
	{
		if (condition)
		{
			return result.Check(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T, E>> CheckIf<T, K, E>(this Result<T, E> result, bool condition, Func<T, ValueTask<Result<K, E>>> valueTask)
	{
		if (condition)
		{
			return result.Check(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T, E>> CheckIf<T, E>(this Result<T, E> result, bool condition, Func<T, ValueTask<UnitResult<E>>> valueTask)
	{
		if (condition)
		{
			return result.Check(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<UnitResult<E>> CheckIf<E>(this UnitResult<E> result, bool condition, Func<ValueTask<UnitResult<E>>> valueTask)
	{
		if (condition)
		{
			return result.Check(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T>> CheckIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<Result>> valueTask)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T>> CheckIf<T, K>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<Result<K>>> valueTask)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T, E>> CheckIf<T, K, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, ValueTask<Result<K, E>>> valueTask)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T, E>> CheckIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, ValueTask<UnitResult<E>>> valueTask)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static async ValueTask<UnitResult<E>> CheckIf<E>(this UnitResult<E> result, Func<bool> predicate, Func<ValueTask<UnitResult<E>>> valueTask)
	{
		if (result.IsSuccess && predicate())
		{
			return await result.Check(valueTask);
		}
		return result;
	}

	public static async ValueTask<Result<T>> Ensure<T>(this Result<T> result, Func<T, ValueTask<bool>> predicate, string errorMessage)
	{
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await predicate(result.Value)))
		{
			return Result.Failure<T>(errorMessage);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> Ensure<T, E>(this Result<T, E> result, Func<T, ValueTask<bool>> predicate, E error)
	{
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await predicate(result.Value)))
		{
			return Result.Failure<T, E>(error);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> Ensure<T, E>(this Result<T, E> result, Func<T, ValueTask<bool>> predicate, Func<T, E> errorPredicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await predicate(result.Value)))
		{
			return Result.Failure<T, E>(errorPredicate(result.Value));
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> Ensure<T, E>(this Result<T, E> result, Func<T, ValueTask<bool>> predicate, Func<T, ValueTask<E>> errorPredicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await predicate(result.Value)))
		{
			return Result.Failure<T, E>(await errorPredicate(result.Value));
		}
		return result;
	}

	public static async ValueTask<Result<T>> Ensure<T>(this Result<T> result, Func<T, ValueTask<bool>> predicate, Func<T, string> errorPredicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await predicate(result.Value)))
		{
			return Result.Failure<T>(errorPredicate(result.Value));
		}
		return result;
	}

	public static async ValueTask<Result<T>> Ensure<T>(this Result<T> result, Func<T, ValueTask<bool>> predicate, Func<T, ValueTask<string>> errorPredicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await predicate(result.Value)))
		{
			return Result.Failure<T>(await errorPredicate(result.Value));
		}
		return result;
	}

	public static async ValueTask<Result> Ensure(this Result result, Func<ValueTask<bool>> predicate, string errorMessage)
	{
		if (result.IsFailure)
		{
			return result;
		}
		if (!(await predicate()))
		{
			return Result.Failure(errorMessage);
		}
		return result;
	}

	public static async ValueTask<Result> Ensure(this Result result, Func<ValueTask<Result>> predicate)
	{
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

	public static async ValueTask<Result<T>> Ensure<T>(this Result<T> result, Func<ValueTask<Result>> predicate)
	{
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

	public static async ValueTask<Result> Ensure<T>(this Result result, Func<ValueTask<Result<T>>> predicate)
	{
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

	public static async ValueTask<Result<T>> Ensure<T>(this Result<T> result, Func<ValueTask<Result<T>>> predicate)
	{
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

	public static async ValueTask<Result<T>> Ensure<T>(this Result<T> result, Func<T, ValueTask<Result>> predicate)
	{
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

	public static async ValueTask<Result<T>> Ensure<T>(this Result<T> result, Func<T, ValueTask<Result<T>>> predicate)
	{
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

	public static async ValueTask<T> Finally<T>(this Result result, Func<Result, ValueTask<T>> valueTask)
	{
		return await valueTask(result);
	}

	public static async ValueTask<K> Finally<T, K>(this Result<T> result, Func<Result<T>, ValueTask<K>> valueTask)
	{
		return await valueTask(result);
	}

	public static async ValueTask<K> Finally<K, E>(this UnitResult<E> result, Func<UnitResult<E>, ValueTask<K>> valueTask)
	{
		return await valueTask(result);
	}

	public static async ValueTask<K> Finally<T, K, E>(this Result<T, E> result, Func<Result<T, E>, ValueTask<K>> valueTask)
	{
		return await valueTask(result);
	}

	public static async ValueTask<Result<K, E>> Map<T, K, E>(this Result<T, E> result, Func<T, ValueTask<K>> valueTask)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(await valueTask(result.Value));
	}

	public static async ValueTask<Result<K, E>> Map<T, K, E, TContext>(this Result<T, E> result, Func<T, TContext, ValueTask<K>> valueTask, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(await valueTask(result.Value, context));
	}

	public static async ValueTask<Result<K, E>> Map<K, E>(this UnitResult<E> result, Func<ValueTask<K>> valueTask)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(await valueTask());
	}

	public static async ValueTask<Result<K, E>> Map<K, E, TContext>(this UnitResult<E> result, Func<TContext, ValueTask<K>> valueTask, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(await valueTask(context));
	}

	public static async ValueTask<Result<K>> Map<T, K>(this Result<T> result, Func<T, ValueTask<K>> valueTask)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(await valueTask(result.Value));
	}

	public static async ValueTask<Result<K>> Map<T, K, TContext>(this Result<T> result, Func<T, TContext, ValueTask<K>> valueTask, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(await valueTask(result.Value, context));
	}

	public static async ValueTask<Result<K>> Map<T, K>(this Result<T> result, Func<T, ValueTask<Result<K>>> valueTask)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return await valueTask(result.Value);
	}

	public static async ValueTask<Result<K>> Map<T, K, TContext>(this Result<T> result, Func<T, TContext, ValueTask<Result<K>>> valueTask, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return await valueTask(result.Value, context);
	}

	public static async ValueTask<Result<K>> Map<K>(this Result result, Func<ValueTask<K>> valueTask)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(await valueTask());
	}

	public static async ValueTask<Result<K>> Map<K, TContext>(this Result result, Func<TContext, ValueTask<K>> valueTask, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(await valueTask(context));
	}

	public static async ValueTask<Result<K, E>> MapTry<T, K, E>(this Result<T, E> result, Func<T, ValueTask<K>> valueTask, Func<Exception, E> errorHandler)
	{
		return (!result.IsFailure) ? (await Result.Try(async () => await valueTask(result.Value), errorHandler).DefaultAwait()) : Result.Failure<K, E>(result.Error);
	}

	public static async ValueTask<Result<K, E>> MapTry<K, E>(this UnitResult<E> result, Func<ValueTask<K>> valueTask, Func<Exception, E> errorHandler)
	{
		return (!result.IsFailure) ? (await Result.Try(async () => await valueTask(), errorHandler).DefaultAwait()) : Result.Failure<K, E>(result.Error);
	}

	public static async ValueTask<Result<K>> MapTry<T, K>(this Result<T> result, Func<T, ValueTask<K>> valueTask, Func<Exception, string> errorHandler = null)
	{
		return (!result.IsFailure) ? (await Result.Try(async () => await valueTask(result.Value), errorHandler).DefaultAwait()) : Result.Failure<K>(result.Error);
	}

	public static async ValueTask<Result<K>> MapTry<K>(this Result result, Func<ValueTask<K>> valueTask, Func<Exception, string> errorHandler = null)
	{
		return (!result.IsFailure) ? (await Result.Try(async () => await valueTask(), errorHandler).DefaultAwait()) : Result.Failure<K>(result.Error);
	}

	public static async ValueTask<Result<T>> OnFailureCompensate<T>(this Result<T> result, Func<ValueTask<Result<T>>> valueTask)
	{
		if (result.IsFailure)
		{
			return await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> OnFailureCompensate<T, E>(this Result<T, E> result, Func<ValueTask<Result<T, E>>> valueTask)
	{
		if (result.IsFailure)
		{
			return await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result> OnFailureCompensate(this Result result, Func<ValueTask<Result>> valueTask)
	{
		if (result.IsFailure)
		{
			return await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result<T>> OnFailureCompensate<T>(this Result<T> result, Func<string, ValueTask<Result<T>>> valueTask)
	{
		if (result.IsFailure)
		{
			return await valueTask(result.Error);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> OnFailureCompensate<T, E>(this Result<T, E> result, Func<E, ValueTask<Result<T, E>>> valueTask)
	{
		if (result.IsFailure)
		{
			return await valueTask(result.Error);
		}
		return result;
	}

	public static async ValueTask<Result> OnFailureCompensate(this Result result, Func<string, ValueTask<Result>> valueTask)
	{
		if (result.IsFailure)
		{
			return await valueTask(result.Error);
		}
		return result;
	}

	public static async ValueTask<Result> Tap(this Result result, Func<ValueTask> valueTask)
	{
		if (result.IsSuccess)
		{
			await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result<T>> Tap<T>(this Result<T> result, Func<ValueTask> valueTask)
	{
		if (result.IsSuccess)
		{
			await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result<T>> Tap<T>(this Result<T> result, Func<T, ValueTask> valueTask)
	{
		if (result.IsSuccess)
		{
			await valueTask(result.Value);
		}
		return result;
	}

	public static async ValueTask<UnitResult<E>> Tap<E>(this UnitResult<E> result, Func<ValueTask> valueTask)
	{
		if (result.IsSuccess)
		{
			await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> Tap<T, E>(this Result<T, E> result, Func<ValueTask> valueTask)
	{
		if (result.IsSuccess)
		{
			await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> Tap<T, E>(this Result<T, E> result, Func<T, ValueTask> valueTask)
	{
		if (result.IsSuccess)
		{
			await valueTask(result.Value);
		}
		return result;
	}

	public static ValueTask<Result> TapIf(this Result result, bool condition, Func<ValueTask> valueTask)
	{
		if (condition)
		{
			return result.Tap(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T>> TapIf<T>(this Result<T> result, bool condition, Func<ValueTask> valueTask)
	{
		if (condition)
		{
			return result.Tap(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T>> TapIf<T>(this Result<T> result, bool condition, Func<T, ValueTask> valueTask)
	{
		if (condition)
		{
			return result.Tap(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T, E>> TapIf<T, E>(this Result<T, E> result, bool condition, Func<ValueTask> valueTask)
	{
		if (condition)
		{
			return result.Tap(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T, E>> TapIf<T, E>(this Result<T, E> result, bool condition, Func<T, ValueTask> valueTask)
	{
		if (condition)
		{
			return result.Tap(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<UnitResult<E>> TapIf<E>(this UnitResult<E> result, bool condition, Func<ValueTask> valueTask)
	{
		if (condition)
		{
			return result.Tap(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T>> TapIf<T>(this Result<T> result, Func<T, bool> predicate, Func<ValueTask> valueTask)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T>> TapIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask> valueTask)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T, E>> TapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<ValueTask> valueTask)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T, E>> TapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, ValueTask> valueTask)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(valueTask);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<UnitResult<E>> TapIf<E>(this UnitResult<E> result, Func<bool> predicate, Func<ValueTask> valueTask)
	{
		if (result.IsSuccess && predicate())
		{
			return result.Tap(valueTask);
		}
		return result.AsCompletedValueTask();
	}
}
