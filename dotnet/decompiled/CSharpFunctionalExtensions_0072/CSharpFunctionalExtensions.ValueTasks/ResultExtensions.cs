using System;
using System.Threading.Tasks;
using System.Transactions;

namespace CSharpFunctionalExtensions.ValueTasks;

public static class ResultExtensions
{
	public static async ValueTask<Result> BindIf(this ValueTask<Result> resultTask, bool condition, Func<ValueTask<Result>> valueTask)
	{
		return await (await resultTask).BindIf(condition, valueTask);
	}

	public static async ValueTask<Result<T>> BindIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<Result<T>>> valueTask)
	{
		return await (await resultTask).BindIf(condition, valueTask);
	}

	public static async ValueTask<UnitResult<E>> BindIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Func<ValueTask<UnitResult<E>>> valueTask)
	{
		return await (await resultTask).BindIf(condition, valueTask);
	}

	public static async ValueTask<Result<T, E>> BindIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<T, ValueTask<Result<T, E>>> valueTask)
	{
		return await (await resultTask).BindIf(condition, valueTask);
	}

	public static async ValueTask<Result> BindIf(this ValueTask<Result> resultTask, Func<bool> predicate, Func<ValueTask<Result>> valueTask)
	{
		return await (await resultTask).BindIf(predicate, valueTask);
	}

	public static async ValueTask<Result<T>> BindIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<Result<T>>> valueTask)
	{
		return await (await resultTask).BindIf(predicate, valueTask);
	}

	public static async ValueTask<UnitResult<E>> BindIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<bool> predicate, Func<ValueTask<UnitResult<E>>> valueTask)
	{
		return await (await resultTask).BindIf(predicate, valueTask);
	}

	public static async ValueTask<Result<T, E>> BindIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<Result<T, E>>> valueTask)
	{
		return await (await resultTask).BindIf(predicate, valueTask);
	}

	public static async ValueTask<Result> BindIf(this ValueTask<Result> resultTask, bool condition, Func<Result> valueTask)
	{
		return (await resultTask).BindIf(condition, valueTask);
	}

	public static async ValueTask<Result<T>> BindIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, Result<T>> valueTask)
	{
		return (await resultTask).BindIf(condition, valueTask);
	}

	public static async ValueTask<UnitResult<E>> BindIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Func<UnitResult<E>> valueTask)
	{
		return (await resultTask).BindIf(condition, valueTask);
	}

	public static async ValueTask<Result<T, E>> BindIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<T, Result<T, E>> valueTask)
	{
		return (await resultTask).BindIf(condition, valueTask);
	}

	public static async ValueTask<Result> BindIf(this ValueTask<Result> resultTask, Func<bool> predicate, Func<Result> valueTask)
	{
		return (await resultTask).BindIf(predicate, valueTask);
	}

	public static async ValueTask<Result<T>> BindIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<T>> valueTask)
	{
		return (await resultTask).BindIf(predicate, valueTask);
	}

	public static async ValueTask<UnitResult<E>> BindIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<bool> predicate, Func<UnitResult<E>> valueTask)
	{
		return (await resultTask).BindIf(predicate, valueTask);
	}

	public static async ValueTask<Result<T, E>> BindIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Result<T, E>> valueTask)
	{
		return (await resultTask).BindIf(predicate, valueTask);
	}

	public static ValueTask<Result> BindIf(this Result result, bool condition, Func<ValueTask<Result>> valueTask)
	{
		if (!condition)
		{
			return result.AsCompletedValueTask();
		}
		return result.Bind(valueTask);
	}

	public static ValueTask<Result<T>> BindIf<T>(this Result<T> result, bool condition, Func<T, ValueTask<Result<T>>> valueTask)
	{
		if (!condition)
		{
			return result.AsCompletedValueTask();
		}
		return result.Bind(valueTask);
	}

	public static ValueTask<UnitResult<E>> BindIf<E>(this UnitResult<E> result, bool condition, Func<ValueTask<UnitResult<E>>> valueTask)
	{
		if (!condition)
		{
			return result.AsCompletedValueTask();
		}
		return result.Bind(valueTask);
	}

	public static ValueTask<Result<T, E>> BindIf<T, E>(this Result<T, E> result, bool condition, Func<T, ValueTask<Result<T, E>>> valueTask)
	{
		if (!condition)
		{
			return result.AsCompletedValueTask();
		}
		return result.Bind(valueTask);
	}

	public static ValueTask<Result> BindIf(this Result result, Func<bool> predicate, Func<ValueTask<Result>> valueTask)
	{
		if (!result.IsSuccess || !predicate())
		{
			return result.AsCompletedValueTask();
		}
		return result.Bind(valueTask);
	}

	public static ValueTask<Result<T>> BindIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<Result<T>>> valueTask)
	{
		if (!result.IsSuccess || !predicate(result.Value))
		{
			return result.AsCompletedValueTask();
		}
		return result.Bind(valueTask);
	}

	public static ValueTask<UnitResult<E>> BindIf<E>(this UnitResult<E> result, Func<bool> predicate, Func<ValueTask<UnitResult<E>>> valueTask)
	{
		if (!result.IsSuccess || !predicate())
		{
			return result.AsCompletedValueTask();
		}
		return result.Bind(valueTask);
	}

	public static ValueTask<Result<T, E>> BindIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, ValueTask<Result<T, E>>> valueTask)
	{
		if (!result.IsSuccess || !predicate(result.Value))
		{
			return result.AsCompletedValueTask();
		}
		return result.Bind(valueTask);
	}

	public static ValueTask<Result<K, E>> BindWithTransactionScope<T, K, E>(this ValueTask<Result<T, E>> self, Func<T, ValueTask<Result<K, E>>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static ValueTask<Result<K>> BindWithTransactionScope<T, K>(this ValueTask<Result<T>> self, Func<T, ValueTask<Result<K>>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static ValueTask<Result<K>> BindWithTransactionScope<K>(this ValueTask<Result> self, Func<ValueTask<Result<K>>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static ValueTask<Result> BindWithTransactionScope<T>(this ValueTask<Result<T>> self, Func<T, ValueTask<Result>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static ValueTask<Result> BindWithTransactionScope(this ValueTask<Result> self, Func<ValueTask<Result>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static ValueTask<Result<K, E>> BindWithTransactionScope<T, K, E>(this ValueTask<Result<T, E>> self, Func<T, Result<K, E>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static ValueTask<Result<K>> BindWithTransactionScope<T, K>(this ValueTask<Result<T>> self, Func<T, Result<K>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static ValueTask<Result<K>> BindWithTransactionScope<K>(this ValueTask<Result> self, Func<Result<K>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static ValueTask<Result> BindWithTransactionScope<T>(this ValueTask<Result<T>> self, Func<T, Result> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static ValueTask<Result> BindWithTransactionScope(this ValueTask<Result> self, Func<Result> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static ValueTask<Result<K, E>> BindWithTransactionScope<T, K, E>(this Result<T, E> self, Func<T, ValueTask<Result<K, E>>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static ValueTask<Result<K>> BindWithTransactionScope<T, K>(this Result<T> self, Func<T, ValueTask<Result<K>>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static ValueTask<Result<K>> BindWithTransactionScope<K>(this Result self, Func<ValueTask<Result<K>>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static ValueTask<Result> BindWithTransactionScope<T>(this Result<T> self, Func<T, ValueTask<Result>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static ValueTask<Result> BindWithTransactionScope(this Result self, Func<ValueTask<Result>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static async ValueTask<Result> Compensate(this ValueTask<Result> resultTask, Func<string, ValueTask<Result>> valueTask)
	{
		return await (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<UnitResult<E>> Compensate<E>(this ValueTask<Result> resultTask, Func<string, ValueTask<UnitResult<E>>> valueTask)
	{
		return await (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<Result> Compensate<T>(this ValueTask<Result<T>> resultTask, Func<string, ValueTask<Result>> valueTask)
	{
		return await (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<Result<T>> Compensate<T>(this ValueTask<Result<T>> resultTask, Func<string, ValueTask<Result<T>>> valueTask)
	{
		return await (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<Result<T, E>> Compensate<T, E>(this ValueTask<Result<T>> resultTask, Func<string, ValueTask<Result<T, E>>> valueTask)
	{
		return await (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<Result> Compensate<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, ValueTask<Result>> valueTask)
	{
		return await (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<UnitResult<E2>> Compensate<E, E2>(this ValueTask<UnitResult<E>> resultTask, Func<E, ValueTask<UnitResult<E2>>> valueTask)
	{
		return await (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<Result> Compensate<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, ValueTask<Result>> valueTask)
	{
		return await (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<UnitResult<E2>> Compensate<T, E, E2>(this ValueTask<Result<T, E>> resultTask, Func<E, ValueTask<UnitResult<E2>>> valueTask)
	{
		return await (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<Result<T, E2>> Compensate<T, E, E2>(this ValueTask<Result<T, E>> resultTask, Func<E, ValueTask<Result<T, E2>>> valueTask)
	{
		return await (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<Result> Compensate(this ValueTask<Result> resultTask, Func<string, Result> valueTask)
	{
		return (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<UnitResult<E>> Compensate<E>(this ValueTask<Result> resultTask, Func<string, UnitResult<E>> valueTask)
	{
		return (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<Result> Compensate<T>(this ValueTask<Result<T>> resultTask, Func<string, Result> valueTask)
	{
		return (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<Result<T>> Compensate<T>(this ValueTask<Result<T>> resultTask, Func<string, Result<T>> valueTask)
	{
		return (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<Result<T, E>> Compensate<T, E>(this ValueTask<Result<T>> resultTask, Func<string, Result<T, E>> valueTask)
	{
		return (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<Result> Compensate<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, Result> valueTask)
	{
		return (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<UnitResult<E2>> Compensate<E, E2>(this ValueTask<UnitResult<E>> resultTask, Func<E, UnitResult<E2>> valueTask)
	{
		return (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<Result> Compensate<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, Result> valueTask)
	{
		return (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<UnitResult<E2>> Compensate<T, E, E2>(this ValueTask<Result<T, E>> resultTask, Func<E, UnitResult<E2>> valueTask)
	{
		return (await resultTask).Compensate(valueTask);
	}

	public static async ValueTask<Result<T, E2>> Compensate<T, E, E2>(this ValueTask<Result<T, E>> resultTask, Func<E, Result<T, E2>> valueTask)
	{
		return (await resultTask).Compensate(valueTask);
	}

	public static ValueTask<Result> Compensate(this Result result, Func<string, ValueTask<Result>> valueTask)
	{
		if (result.IsSuccess)
		{
			return Result.Success().AsCompletedValueTask();
		}
		return valueTask(result.Error);
	}

	public static ValueTask<UnitResult<E>> Compensate<E>(this Result result, Func<string, ValueTask<UnitResult<E>>> valueTask)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E>().AsCompletedValueTask();
		}
		return valueTask(result.Error);
	}

	public static ValueTask<Result> Compensate<T>(this Result<T> result, Func<string, ValueTask<Result>> valueTask)
	{
		if (result.IsSuccess)
		{
			return Result.Success().AsCompletedValueTask();
		}
		return valueTask(result.Error);
	}

	public static ValueTask<Result<T>> Compensate<T>(this Result<T> result, Func<string, ValueTask<Result<T>>> valueTask)
	{
		if (result.IsSuccess)
		{
			return Result.Success(result.Value).AsCompletedValueTask();
		}
		return valueTask(result.Error);
	}

	public static ValueTask<Result<T, E>> Compensate<T, E>(this Result<T> result, Func<string, ValueTask<Result<T, E>>> valueTask)
	{
		if (result.IsSuccess)
		{
			return Result.Success<T, E>(result.Value).AsCompletedValueTask();
		}
		return valueTask(result.Error);
	}

	public static ValueTask<Result> Compensate<E>(this UnitResult<E> result, Func<E, ValueTask<Result>> valueTask)
	{
		if (result.IsSuccess)
		{
			return Result.Success().AsCompletedValueTask();
		}
		return valueTask(result.Error);
	}

	public static ValueTask<UnitResult<E2>> Compensate<E, E2>(this UnitResult<E> result, Func<E, ValueTask<UnitResult<E2>>> valueTask)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E2>().AsCompletedValueTask();
		}
		return valueTask(result.Error);
	}

	public static ValueTask<Result> Compensate<T, E>(this Result<T, E> result, Func<E, ValueTask<Result>> valueTask)
	{
		if (result.IsSuccess)
		{
			return Result.Success().AsCompletedValueTask();
		}
		return valueTask(result.Error);
	}

	public static ValueTask<UnitResult<E2>> Compensate<T, E, E2>(this Result<T, E> result, Func<E, ValueTask<UnitResult<E2>>> valueTask)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E2>().AsCompletedValueTask();
		}
		return valueTask(result.Error);
	}

	public static ValueTask<Result<T, E2>> Compensate<T, E, E2>(this Result<T, E> result, Func<E, ValueTask<Result<T, E2>>> valueTask)
	{
		if (result.IsSuccess)
		{
			return Result.Success<T, E2>(result.Value).AsCompletedValueTask();
		}
		return valueTask(result.Error);
	}

	public static ValueTask<Result<T>> EnsureNotNull<T>(this ValueTask<Result<T?>> resultTask, string error) where T : class
	{
		return resultTask.Ensure<T>((T value) => value != null, error).Map((T value) => value);
	}

	public static ValueTask<Result<T>> EnsureNotNull<T>(this ValueTask<Result<T?>> resultTask, string error) where T : struct
	{
		return resultTask.Ensure((T? value) => value.HasValue, error).Map((T? value) => value.Value);
	}

	public static ValueTask<Result<T>> EnsureNotNull<T>(this ValueTask<Result<T?>> resultTask, Func<ValueTask<string>> errorFactory) where T : class
	{
		return resultTask.Ensure<T>((T value) => value != null, (T _) => errorFactory()).Map((T value) => value);
	}

	public static ValueTask<Result<T>> EnsureNotNull<T>(this ValueTask<Result<T?>> resultTask, Func<ValueTask<string>> errorFactory) where T : struct
	{
		return resultTask.Ensure((T? value) => value.HasValue, (T? _) => errorFactory()).Map((T? value) => value.Value);
	}

	public static ValueTask<Result<T, E>> EnsureNotNull<T, E>(this ValueTask<Result<T?, E>> resultTask, E error) where T : class
	{
		return resultTask.Ensure<T, E>((T value) => value != null, error).Map((T value) => value);
	}

	public static ValueTask<Result<T, E>> EnsureNotNull<T, E>(this ValueTask<Result<T?, E>> resultTask, E error) where T : struct
	{
		return resultTask.Ensure((T? value) => value.HasValue, error).Map((T? value) => value.Value);
	}

	public static ValueTask<Result<T, E>> EnsureNotNull<T, E>(this ValueTask<Result<T?, E>> resultTask, Func<ValueTask<E>> errorFactory) where T : class
	{
		return resultTask.Ensure<T, E>((T value) => ValueTask.FromResult(value != null), (T _) => errorFactory()).Map((T value) => value);
	}

	public static ValueTask<Result<T, E>> EnsureNotNull<T, E>(this ValueTask<Result<T?, E>> resultTask, Func<ValueTask<E>> errorFactory) where T : struct
	{
		return resultTask.Ensure<T?, E>((T? value) => ValueTask.FromResult(value.HasValue), (T? _) => errorFactory()).Map((T? value) => value.Value);
	}

	public static ValueTask<Result<T>> EnsureNotNull<T>(this ValueTask<Result<T?>> resultTask, Func<string> errorFactory) where T : class
	{
		return resultTask.Ensure<T>((T value) => value != null, (T _) => errorFactory()).Map((T value) => value);
	}

	public static ValueTask<Result<T>> EnsureNotNull<T>(this ValueTask<Result<T?>> resultTask, Func<string> errorFactory) where T : struct
	{
		return resultTask.Ensure((T? value) => value.HasValue, (T? _) => errorFactory()).Map((T? value) => value.Value);
	}

	public static ValueTask<Result<T, E>> EnsureNotNull<T, E>(this ValueTask<Result<T?, E>> resultTask, Func<E> errorFactory) where T : class
	{
		return resultTask.Ensure<T, E>((T value) => ValueTask.FromResult(value != null), (T _) => errorFactory()).Map((T value) => value);
	}

	public static ValueTask<Result<T, E>> EnsureNotNull<T, E>(this ValueTask<Result<T?, E>> resultTask, Func<E> errorFactory) where T : struct
	{
		return resultTask.Ensure((T? value) => ValueTask.FromResult(value.HasValue), (T? _) => errorFactory()).Map((T? value) => value.Value);
	}

	public static ValueTask<Result<T>> EnsureNotNull<T>(this Result<T?> result, Func<ValueTask<string>> errorFactory) where T : class
	{
		return result.Ensure<T>((T value) => ValueTask.FromResult(value != null), (T _) => errorFactory()).Map((T value) => value);
	}

	public static ValueTask<Result<T>> EnsureNotNull<T>(this Result<T?> result, Func<ValueTask<string>> errorFactory) where T : struct
	{
		return result.Ensure((T? value) => ValueTask.FromResult(value.HasValue), (T? _) => errorFactory()).Map((T? value) => value.Value);
	}

	public static ValueTask<Result<T, E>> EnsureNotNull<T, E>(this Result<T?, E> result, Func<ValueTask<E>> errorFactory) where T : class
	{
		return result.Ensure<T, E>((T value) => ValueTask.FromResult(value != null), (T _) => errorFactory()).Map((T value) => value);
	}

	public static ValueTask<Result<T, E>> EnsureNotNull<T, E>(this Result<T?, E> result, Func<ValueTask<E>> errorFactory) where T : struct
	{
		return result.Ensure<T?, E>((T? value) => ValueTask.FromResult(value.HasValue), (T? _) => errorFactory()).Map((T? value) => value.Value);
	}

	public static async ValueTask<T> GetValueOrDefault<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask<T>> defaultValue)
	{
		return await (await resultTask).GetValueOrDefault(defaultValue);
	}

	public static async ValueTask<K> GetValueOrDefault<T, K>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<K>> selector, K defaultValue = default(K))
	{
		return await (await resultTask).GetValueOrDefault(selector, defaultValue);
	}

	public static async ValueTask<K> GetValueOrDefault<T, K>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<K>> selector, Func<ValueTask<K>> defaultValue)
	{
		return await (await resultTask).GetValueOrDefault(selector, defaultValue);
	}

	public static async ValueTask<T> GetValueOrDefault<T>(this ValueTask<Result<T>> resultTask, Func<T> defaultValue)
	{
		return (await resultTask).GetValueOrDefault(defaultValue);
	}

	public static async ValueTask<K> GetValueOrDefault<T, K>(this ValueTask<Result<T>> resultTask, Func<T, K> selector, K defaultValue = default(K))
	{
		return (await resultTask).GetValueOrDefault(selector, defaultValue);
	}

	public static async ValueTask<K> GetValueOrDefault<T, K>(this ValueTask<Result<T>> resultTask, Func<T, K> selector, Func<K> defaultValue)
	{
		return (await resultTask).GetValueOrDefault(selector, defaultValue);
	}

	public static async ValueTask<T> GetValueOrDefault<T>(this Result<T> result, Func<ValueTask<T>> valueTask)
	{
		if (result.IsFailure)
		{
			return await valueTask();
		}
		return result.Value;
	}

	public static async ValueTask<K> GetValueOrDefault<T, K>(this Result<T> result, Func<T, K> selector, Func<ValueTask<K>> valueTask)
	{
		if (result.IsFailure)
		{
			return await valueTask();
		}
		return selector(result.Value);
	}

	public static async ValueTask<K> GetValueOrDefault<T, K>(this Result<T> result, Func<T, ValueTask<K>> valueTask, K defaultValue = default(K))
	{
		if (result.IsFailure)
		{
			return defaultValue;
		}
		return await valueTask(result.Value);
	}

	public static async ValueTask<K> GetValueOrDefault<T, K>(this Result<T> result, Func<T, ValueTask<K>> valueTask, Func<ValueTask<K>> defaultValue)
	{
		if (result.IsFailure)
		{
			return await defaultValue();
		}
		return await valueTask(result.Value);
	}

	public static async ValueTask<Result> MapError(this ValueTask<Result> resultTask, Func<string, ValueTask<string>> errorFactory)
	{
		return await (await resultTask).MapError(errorFactory);
	}

	public static async ValueTask<Result> MapError<TContext>(this ValueTask<Result> resultTask, Func<string, TContext, ValueTask<string>> errorFactory, TContext context)
	{
		return await (await resultTask).MapError(errorFactory, context);
	}

	public static async ValueTask<UnitResult<E>> MapError<E>(this ValueTask<Result> resultTask, Func<string, ValueTask<E>> errorFactory)
	{
		return await (await resultTask).MapError(errorFactory);
	}

	public static async ValueTask<UnitResult<E>> MapError<E, TContext>(this ValueTask<Result> resultTask, Func<string, TContext, ValueTask<E>> errorFactory, TContext context)
	{
		return await (await resultTask).MapError(errorFactory, context);
	}

	public static async ValueTask<Result<T>> MapError<T>(this ValueTask<Result<T>> resultTask, Func<string, ValueTask<string>> errorFactory)
	{
		return await (await resultTask).MapError(errorFactory);
	}

	public static async ValueTask<Result<T>> MapError<T, TContext>(this ValueTask<Result<T>> resultTask, Func<string, TContext, ValueTask<string>> errorFactory, TContext context)
	{
		return await (await resultTask).MapError(errorFactory, context);
	}

	public static async ValueTask<Result<T, E>> MapError<T, E>(this ValueTask<Result<T>> resultTask, Func<string, ValueTask<E>> errorFactory)
	{
		return await (await resultTask).MapError(errorFactory);
	}

	public static async ValueTask<Result<T, E>> MapError<T, E, TContext>(this ValueTask<Result<T>> resultTask, Func<string, TContext, ValueTask<E>> errorFactory, TContext context)
	{
		return await (await resultTask).MapError(errorFactory, context);
	}

	public static async ValueTask<Result> MapError<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, ValueTask<string>> errorFactory)
	{
		return await (await resultTask).MapError(errorFactory);
	}

	public static async ValueTask<Result> MapError<E, TContext>(this ValueTask<UnitResult<E>> resultTask, Func<E, TContext, ValueTask<string>> errorFactory, TContext context)
	{
		return await (await resultTask).MapError(errorFactory, context);
	}

	public static async ValueTask<UnitResult<E2>> MapError<E, E2>(this ValueTask<UnitResult<E>> resultTask, Func<E, ValueTask<E2>> errorFactory)
	{
		return await (await resultTask).MapError(errorFactory);
	}

	public static async ValueTask<UnitResult<E2>> MapError<E, E2, TContext>(this ValueTask<UnitResult<E>> resultTask, Func<E, TContext, ValueTask<E2>> errorFactory, TContext context)
	{
		return await (await resultTask).MapError(errorFactory, context);
	}

	public static async ValueTask<Result<T>> MapError<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, ValueTask<string>> errorFactory)
	{
		return await (await resultTask).MapError(errorFactory);
	}

	public static async ValueTask<Result<T>> MapError<T, E, TContext>(this ValueTask<Result<T, E>> resultTask, Func<E, TContext, ValueTask<string>> errorFactory, TContext context)
	{
		return await (await resultTask).MapError(errorFactory, context);
	}

	public static async ValueTask<Result<T, E2>> MapError<T, E, E2>(this ValueTask<Result<T, E>> resultTask, Func<E, ValueTask<E2>> errorFactory)
	{
		return await (await resultTask).MapError(errorFactory);
	}

	public static async ValueTask<Result<T, E2>> MapError<T, E, E2, TContext>(this ValueTask<Result<T, E>> resultTask, Func<E, TContext, ValueTask<E2>> errorFactory, TContext context)
	{
		return await (await resultTask).MapError(errorFactory, context);
	}

	public static async ValueTask<Result> MapError(this ValueTask<Result> resultTask, Func<string, string> errorFactory)
	{
		Result result = await resultTask;
		if (result.IsSuccess)
		{
			return Result.Success();
		}
		return Result.Failure(errorFactory(result.Error));
	}

	public static async ValueTask<Result> MapError<TContext>(this ValueTask<Result> resultTask, Func<string, TContext, string> errorFactory, TContext context)
	{
		Result result = await resultTask;
		if (result.IsSuccess)
		{
			return Result.Success();
		}
		return Result.Failure(errorFactory(result.Error, context));
	}

	public static async ValueTask<UnitResult<E>> MapError<E>(this ValueTask<Result> resultTask, Func<string, E> errorFactory)
	{
		Result result = await resultTask;
		if (result.IsSuccess)
		{
			return UnitResult.Success<E>();
		}
		return UnitResult.Failure<E>(errorFactory(result.Error));
	}

	public static async ValueTask<UnitResult<E>> MapError<E, TContext>(this ValueTask<Result> resultTask, Func<string, TContext, E> errorFactory, TContext context)
	{
		Result result = await resultTask;
		if (result.IsSuccess)
		{
			return UnitResult.Success<E>();
		}
		return UnitResult.Failure<E>(errorFactory(result.Error, context));
	}

	public static async ValueTask<Result<T>> MapError<T>(this ValueTask<Result<T>> resultTask, Func<string, string> errorFactory)
	{
		Result<T> result = await resultTask;
		if (result.IsSuccess)
		{
			return Result.Success(result.Value);
		}
		return Result.Failure<T>(errorFactory(result.Error));
	}

	public static async ValueTask<Result<T>> MapError<T, TContext>(this ValueTask<Result<T>> resultTask, Func<string, TContext, string> errorFactory, TContext context)
	{
		Result<T> result = await resultTask;
		if (result.IsSuccess)
		{
			return Result.Success(result.Value);
		}
		return Result.Failure<T>(errorFactory(result.Error, context));
	}

	public static async ValueTask<Result<T, E>> MapError<T, E>(this ValueTask<Result<T>> resultTask, Func<string, E> errorFactory)
	{
		Result<T> result = await resultTask;
		if (result.IsSuccess)
		{
			return Result.Success<T, E>(result.Value);
		}
		return Result.Failure<T, E>(errorFactory(result.Error));
	}

	public static async ValueTask<Result<T, E>> MapError<T, E, TContext>(this ValueTask<Result<T>> resultTask, Func<string, TContext, E> errorFactory, TContext context)
	{
		Result<T> result = await resultTask;
		if (result.IsSuccess)
		{
			return Result.Success<T, E>(result.Value);
		}
		return Result.Failure<T, E>(errorFactory(result.Error, context));
	}

	public static async ValueTask<Result> MapError<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, string> errorFactory)
	{
		UnitResult<E> unitResult = await resultTask;
		if (unitResult.IsSuccess)
		{
			return Result.Success();
		}
		return Result.Failure(errorFactory(unitResult.Error));
	}

	public static async ValueTask<Result> MapError<E, TContext>(this ValueTask<UnitResult<E>> resultTask, Func<E, TContext, string> errorFactory, TContext context)
	{
		UnitResult<E> unitResult = await resultTask;
		if (unitResult.IsSuccess)
		{
			return Result.Success();
		}
		return Result.Failure(errorFactory(unitResult.Error, context));
	}

	public static async ValueTask<UnitResult<E2>> MapError<E, E2>(this ValueTask<UnitResult<E>> resultTask, Func<E, E2> errorFactory)
	{
		UnitResult<E> unitResult = await resultTask;
		if (unitResult.IsSuccess)
		{
			return UnitResult.Success<E2>();
		}
		return UnitResult.Failure<E2>(errorFactory(unitResult.Error));
	}

	public static async ValueTask<UnitResult<E2>> MapError<E, E2, TContext>(this ValueTask<UnitResult<E>> resultTask, Func<E, TContext, E2> errorFactory, TContext context)
	{
		UnitResult<E> unitResult = await resultTask;
		if (unitResult.IsSuccess)
		{
			return UnitResult.Success<E2>();
		}
		return UnitResult.Failure<E2>(errorFactory(unitResult.Error, context));
	}

	public static async ValueTask<Result<T>> MapError<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, string> errorFactory)
	{
		Result<T, E> result = await resultTask;
		if (result.IsSuccess)
		{
			return Result.Success(result.Value);
		}
		return Result.Failure<T>(errorFactory(result.Error));
	}

	public static async ValueTask<Result<T>> MapError<T, E, TContext>(this ValueTask<Result<T, E>> resultTask, Func<E, TContext, string> errorFactory, TContext context)
	{
		Result<T, E> result = await resultTask;
		if (result.IsSuccess)
		{
			return Result.Success(result.Value);
		}
		return Result.Failure<T>(errorFactory(result.Error, context));
	}

	public static async ValueTask<Result<T, E2>> MapError<T, E, E2>(this ValueTask<Result<T, E>> resultTask, Func<E, E2> errorFactory)
	{
		Result<T, E> result = await resultTask;
		if (result.IsSuccess)
		{
			return Result.Success<T, E2>(result.Value);
		}
		return Result.Failure<T, E2>(errorFactory(result.Error));
	}

	public static async ValueTask<Result<T, E2>> MapError<T, E, E2, TContext>(this ValueTask<Result<T, E>> resultTask, Func<E, TContext, E2> errorFactory, TContext context)
	{
		Result<T, E> result = await resultTask;
		if (result.IsSuccess)
		{
			return Result.Success<T, E2>(result.Value);
		}
		return Result.Failure<T, E2>(errorFactory(result.Error, context));
	}

	public static async ValueTask<Result> MapError(this Result result, Func<string, ValueTask<string>> errorFactory)
	{
		if (result.IsSuccess)
		{
			return Result.Success();
		}
		return Result.Failure(await errorFactory(result.Error));
	}

	public static async ValueTask<Result> MapError<TContext>(this Result result, Func<string, TContext, ValueTask<string>> errorFactory, TContext context)
	{
		if (result.IsSuccess)
		{
			return Result.Success();
		}
		return Result.Failure(await errorFactory(result.Error, context));
	}

	public static async ValueTask<UnitResult<E>> MapError<E>(this Result result, Func<string, ValueTask<E>> errorFactory)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E>();
		}
		return UnitResult.Failure<E>(await errorFactory(result.Error));
	}

	public static async ValueTask<UnitResult<E>> MapError<E, TContext>(this Result result, Func<string, TContext, ValueTask<E>> errorFactory, TContext context)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E>();
		}
		return UnitResult.Failure<E>(await errorFactory(result.Error, context));
	}

	public static async ValueTask<Result<T>> MapError<T>(this Result<T> result, Func<string, ValueTask<string>> errorFactory)
	{
		if (result.IsSuccess)
		{
			return Result.Success(result.Value);
		}
		return Result.Failure<T>(await errorFactory(result.Error));
	}

	public static async ValueTask<Result<T>> MapError<T, TContext>(this Result<T> result, Func<string, TContext, ValueTask<string>> errorFactory, TContext context)
	{
		if (result.IsSuccess)
		{
			return Result.Success(result.Value);
		}
		return Result.Failure<T>(await errorFactory(result.Error, context));
	}

	public static async ValueTask<Result<T, E>> MapError<T, E>(this Result<T> result, Func<string, ValueTask<E>> errorFactory)
	{
		if (result.IsSuccess)
		{
			return Result.Success<T, E>(result.Value);
		}
		return Result.Failure<T, E>(await errorFactory(result.Error));
	}

	public static async ValueTask<Result<T, E>> MapError<T, E, TContext>(this Result<T> result, Func<string, TContext, ValueTask<E>> errorFactory, TContext context)
	{
		if (result.IsSuccess)
		{
			return Result.Success<T, E>(result.Value);
		}
		return Result.Failure<T, E>(await errorFactory(result.Error, context));
	}

	public static async ValueTask<Result> MapError<E>(this UnitResult<E> result, Func<E, ValueTask<string>> errorFactory)
	{
		if (result.IsSuccess)
		{
			return Result.Success();
		}
		return Result.Failure(await errorFactory(result.Error));
	}

	public static async ValueTask<Result> MapError<E, TContext>(this UnitResult<E> result, Func<E, TContext, ValueTask<string>> errorFactory, TContext context)
	{
		if (result.IsSuccess)
		{
			return Result.Success();
		}
		return Result.Failure(await errorFactory(result.Error, context));
	}

	public static async ValueTask<UnitResult<E2>> MapError<E, E2>(this UnitResult<E> result, Func<E, ValueTask<E2>> errorFactory)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E2>();
		}
		return UnitResult.Failure<E2>(await errorFactory(result.Error));
	}

	public static async ValueTask<UnitResult<E2>> MapError<E, E2, TContext>(this UnitResult<E> result, Func<E, TContext, ValueTask<E2>> errorFactory, TContext context)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E2>();
		}
		return UnitResult.Failure<E2>(await errorFactory(result.Error, context));
	}

	public static async ValueTask<Result<T>> MapError<T, E>(this Result<T, E> result, Func<E, ValueTask<string>> errorFactory)
	{
		if (result.IsSuccess)
		{
			return Result.Success(result.Value);
		}
		return Result.Failure<T>(await errorFactory(result.Error));
	}

	public static async ValueTask<Result<T>> MapError<T, E, TContext>(this Result<T, E> result, Func<E, TContext, ValueTask<string>> errorFactory, TContext context)
	{
		if (result.IsSuccess)
		{
			return Result.Success(result.Value);
		}
		return Result.Failure<T>(await errorFactory(result.Error, context));
	}

	public static async ValueTask<Result<T, E2>> MapError<T, E, E2>(this Result<T, E> result, Func<E, ValueTask<E2>> errorFactory)
	{
		if (result.IsSuccess)
		{
			return Result.Success<T, E2>(result.Value);
		}
		return Result.Failure<T, E2>(await errorFactory(result.Error));
	}

	public static async ValueTask<Result<T, E2>> MapError<T, E, E2, TContext>(this Result<T, E> result, Func<E, TContext, ValueTask<E2>> errorFactory, TContext context)
	{
		if (result.IsSuccess)
		{
			return Result.Success<T, E2>(result.Value);
		}
		return Result.Failure<T, E2>(await errorFactory(result.Error, context));
	}

	public static async ValueTask<Result<T>> MapIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, ValueTask<T>> valueTask)
	{
		return await (await resultTask).MapIf(condition, valueTask);
	}

	public static async ValueTask<Result<T>> MapIf<T, TContext>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, TContext, ValueTask<T>> valueTask, TContext context)
	{
		return await (await resultTask).MapIf(condition, valueTask, context);
	}

	public static async ValueTask<Result<T, E>> MapIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<T, ValueTask<T>> valueTask)
	{
		return await (await resultTask).MapIf(condition, valueTask);
	}

	public static async ValueTask<Result<T, E>> MapIf<T, E, TContext>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<T, TContext, ValueTask<T>> valueTask, TContext context)
	{
		return await (await resultTask).MapIf(condition, valueTask, context);
	}

	public static async ValueTask<Result<T>> MapIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<T>> valueTask)
	{
		return await (await resultTask).MapIf(predicate, valueTask);
	}

	public static async ValueTask<Result<T>> MapIf<T, TContext>(this ValueTask<Result<T>> resultTask, Func<T, TContext, bool> predicate, Func<T, TContext, ValueTask<T>> valueTask, TContext context)
	{
		return await (await resultTask).MapIf(predicate, valueTask, context);
	}

	public static async ValueTask<Result<T, E>> MapIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, ValueTask<T>> valueTask)
	{
		return await (await resultTask).MapIf(predicate, valueTask);
	}

	public static async ValueTask<Result<T, E>> MapIf<T, E, TContext>(this ValueTask<Result<T, E>> resultTask, Func<T, TContext, bool> predicate, Func<T, TContext, ValueTask<T>> valueTask, TContext context)
	{
		return await (await resultTask).MapIf(predicate, valueTask, context);
	}

	public static async ValueTask<Result<T>> MapIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, T> valueTask)
	{
		return (await resultTask).MapIf(condition, valueTask);
	}

	public static async ValueTask<Result<T>> MapIf<T, TContext>(this ValueTask<Result<T>> resultTask, bool condition, Func<T, TContext, T> valueTask, TContext context)
	{
		return (await resultTask).MapIf(condition, valueTask, context);
	}

	public static async ValueTask<Result<T, E>> MapIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<T, T> valueTask)
	{
		return (await resultTask).MapIf(condition, valueTask);
	}

	public static async ValueTask<Result<T, E>> MapIf<T, E, TContext>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<T, TContext, T> valueTask, TContext context)
	{
		return (await resultTask).MapIf(condition, valueTask, context);
	}

	public static async ValueTask<Result<T>> MapIf<T>(this ValueTask<Result<T>> resultTask, Func<T, bool> predicate, Func<T, T> valueTask)
	{
		return (await resultTask).MapIf(predicate, valueTask);
	}

	public static async ValueTask<Result<T>> MapIf<T, TContext>(this ValueTask<Result<T>> resultTask, Func<T, TContext, bool> predicate, Func<T, TContext, T> valueTask, TContext context)
	{
		return (await resultTask).MapIf(predicate, valueTask, context);
	}

	public static async ValueTask<Result<T, E>> MapIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, T> valueTask)
	{
		return (await resultTask).MapIf(predicate, valueTask);
	}

	public static async ValueTask<Result<T, E>> MapIf<T, E, TContext>(this ValueTask<Result<T, E>> resultTask, Func<T, TContext, bool> predicate, Func<T, TContext, T> valueTask, TContext context)
	{
		return (await resultTask).MapIf(predicate, valueTask, context);
	}

	public static ValueTask<Result<T>> MapIf<T>(this Result<T> result, bool condition, Func<T, ValueTask<T>> valueTask)
	{
		if (!condition)
		{
			return result.AsCompletedValueTask();
		}
		return result.Map(valueTask);
	}

	public static ValueTask<Result<T>> MapIf<T, TContext>(this Result<T> result, bool condition, Func<T, TContext, ValueTask<T>> valueTask, TContext context)
	{
		if (!condition)
		{
			return result.AsCompletedValueTask();
		}
		return result.Map(valueTask, context);
	}

	public static ValueTask<Result<T, E>> MapIf<T, E>(this Result<T, E> result, bool condition, Func<T, ValueTask<T>> valueTask)
	{
		if (!condition)
		{
			return result.AsCompletedValueTask();
		}
		return result.Map(valueTask);
	}

	public static ValueTask<Result<T, E>> MapIf<T, E, TContext>(this Result<T, E> result, bool condition, Func<T, TContext, ValueTask<T>> valueTask, TContext context)
	{
		if (!condition)
		{
			return result.AsCompletedValueTask();
		}
		return result.Map(valueTask, context);
	}

	public static ValueTask<Result<T>> MapIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, ValueTask<T>> valueTask)
	{
		if (!result.IsSuccess || !predicate(result.Value))
		{
			return result.AsCompletedValueTask();
		}
		return result.Map(valueTask);
	}

	public static ValueTask<Result<T>> MapIf<T, TContext>(this Result<T> result, Func<T, TContext, bool> predicate, Func<T, TContext, ValueTask<T>> valueTask, TContext context)
	{
		if (!result.IsSuccess || !predicate(result.Value, context))
		{
			return result.AsCompletedValueTask();
		}
		return result.Map(valueTask, context);
	}

	public static ValueTask<Result<T, E>> MapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, ValueTask<T>> valueTask)
	{
		if (!result.IsSuccess || !predicate(result.Value))
		{
			return result.AsCompletedValueTask();
		}
		return result.Map(valueTask);
	}

	public static ValueTask<Result<T, E>> MapIf<T, E, TContext>(this Result<T, E> result, Func<T, TContext, bool> predicate, Func<T, TContext, ValueTask<T>> valueTask, TContext context)
	{
		if (!result.IsSuccess || !predicate(result.Value, context))
		{
			return result.AsCompletedValueTask();
		}
		return result.Map(valueTask, context);
	}

	public static ValueTask<Result<K>> MapWithTransactionScope<T, K>(this ValueTask<Result<T>> self, Func<T, ValueTask<K>> f)
	{
		return WithTransactionScope(() => self.Map(f));
	}

	public static ValueTask<Result<K>> MapWithTransactionScope<K>(this ValueTask<Result> self, Func<ValueTask<K>> f)
	{
		return WithTransactionScope(() => self.Map(f));
	}

	public static ValueTask<Result<K>> MapWithTransactionScope<T, K>(this ValueTask<Result<T>> self, Func<T, K> f)
	{
		return WithTransactionScope(() => self.Map(f));
	}

	public static ValueTask<Result<K>> MapWithTransactionScope<K>(this ValueTask<Result> self, Func<K> f)
	{
		return WithTransactionScope(() => self.Map(f));
	}

	public static ValueTask<Result<K>> MapWithTransactionScope<T, K>(this Result<T> self, Func<T, ValueTask<K>> f)
	{
		return WithTransactionScope(() => self.Map(f));
	}

	public static ValueTask<Result<K>> MapWithTransactionScope<K>(this Result self, Func<ValueTask<K>> f)
	{
		return WithTransactionScope(() => self.Map(f));
	}

	public static async ValueTask<Result<TR>> SelectMany<T, TK, TR>(this ValueTask<Result<T>> resultTask, Func<T, ValueTask<Result<TK>>> valueTask, Func<T, TK, TR> project)
	{
		return await (await resultTask).SelectMany(valueTask, project);
	}

	public static async ValueTask<Result<TR, TE>> SelectMany<T, TK, TE, TR>(this ValueTask<Result<T, TE>> resultTask, Func<T, ValueTask<Result<TK, TE>>> valueTask, Func<T, TK, TR> project)
	{
		return await (await resultTask).SelectMany(valueTask, project);
	}

	public static async ValueTask<Result<TR>> SelectMany<T, TK, TR>(this ValueTask<Result<T>> resultTask, Func<T, Result<TK>> valueTask, Func<T, TK, TR> project)
	{
		return (await resultTask).SelectMany(valueTask, project);
	}

	public static async ValueTask<Result<TR, TE>> SelectMany<T, TK, TE, TR>(this ValueTask<Result<T, TE>> resultTask, Func<T, Result<TK, TE>> valueTask, Func<T, TK, TR> project)
	{
		return (await resultTask).SelectMany(valueTask, project);
	}

	public static ValueTask<Result<TR>> SelectMany<T, TK, TR>(this Result<T> result, Func<T, ValueTask<Result<TK>>> valueTask, Func<T, TK, TR> project)
	{
		return result.Bind(valueTask).Map((TK x) => project(result.Value, x));
	}

	public static ValueTask<Result<TR, TE>> SelectMany<T, TK, TE, TR>(this Result<T, TE> result, Func<T, ValueTask<Result<TK, TE>>> valueTask, Func<T, TK, TR> project)
	{
		return result.Bind(valueTask).Map((TK x) => project(result.Value, x));
	}

	public static async ValueTask<Result<T, E>> TapError<T, E>(this ValueTask<Result<T, E>> resultTask, Func<ValueTask> valueTask)
	{
		Result<T, E> result = await resultTask;
		if (result.IsFailure)
		{
			await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result<T>> TapError<T>(this ValueTask<Result<T>> resultTask, Func<ValueTask> valueTask)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure)
		{
			await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result> TapError(this ValueTask<Result> resultTask, Func<ValueTask> valueTask)
	{
		Result result = await resultTask;
		if (result.IsFailure)
		{
			await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result> TapError(this ValueTask<Result> resultTask, Func<string, ValueTask> valueTask)
	{
		Result result = await resultTask;
		if (result.IsFailure)
		{
			await valueTask(result.Error);
		}
		return result;
	}

	public static async ValueTask<UnitResult<E>> TapError<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, ValueTask> valueTask)
	{
		UnitResult<E> result = await resultTask;
		if (result.IsFailure)
		{
			await valueTask(result.Error);
		}
		return result;
	}

	public static async ValueTask<UnitResult<E>> TapError<E>(this ValueTask<UnitResult<E>> resultTask, Func<ValueTask> valueTask)
	{
		UnitResult<E> result = await resultTask;
		if (result.IsFailure)
		{
			await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result<T>> TapError<T>(this ValueTask<Result<T>> resultTask, Func<string, ValueTask> valueTask)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure)
		{
			await valueTask(result.Error);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> TapError<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, ValueTask> valueTask)
	{
		Result<T, E> result = await resultTask;
		if (result.IsFailure)
		{
			await valueTask(result.Error);
		}
		return result;
	}

	public static async ValueTask<Result<T>> TapError<T>(this ValueTask<Result<T>> resultTask, Action action)
	{
		return (await resultTask).TapError(action);
	}

	public static async ValueTask<Result> TapError(this ValueTask<Result> resultTask, Action action)
	{
		return (await resultTask).TapError(action);
	}

	public static async ValueTask<Result<T, E>> TapError<T, E>(this ValueTask<Result<T, E>> resultTask, Action action)
	{
		return (await resultTask).TapError(action);
	}

	public static async ValueTask<UnitResult<E>> TapError<E>(this ValueTask<UnitResult<E>> resultTask, Action action)
	{
		return (await resultTask).TapError(action);
	}

	public static async ValueTask<UnitResult<E>> TapError<E>(this ValueTask<UnitResult<E>> resultTask, Action<E> action)
	{
		return (await resultTask).TapError(action);
	}

	public static async ValueTask<Result<T>> TapError<T>(this ValueTask<Result<T>> resultTask, Action<string> action)
	{
		return (await resultTask).TapError(action);
	}

	public static async ValueTask<Result<T, E>> TapError<T, E>(this ValueTask<Result<T, E>> resultTask, Action<E> action)
	{
		return (await resultTask).TapError(action);
	}

	public static async ValueTask<Result> TapError(this ValueTask<Result> resultTask, Action<string> action)
	{
		return (await resultTask).TapError(action);
	}

	public static async ValueTask<Result<T>> TapError<T>(this Result<T> result, Func<ValueTask> valueTask)
	{
		if (result.IsFailure)
		{
			await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> TapError<T, E>(this Result<T, E> result, Func<ValueTask> valueTask)
	{
		if (result.IsFailure)
		{
			await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result> TapError(this Result result, Func<ValueTask> valueTask)
	{
		if (result.IsFailure)
		{
			await valueTask();
		}
		return result;
	}

	public static async ValueTask<Result> TapError(this Result result, Func<string, ValueTask> valueTask)
	{
		if (result.IsFailure)
		{
			await valueTask(result.Error);
		}
		return result;
	}

	public static async ValueTask<UnitResult<E>> TapError<E>(this UnitResult<E> result, Func<ValueTask> valueTask)
	{
		if (result.IsFailure)
		{
			await valueTask();
		}
		return result;
	}

	public static async ValueTask<UnitResult<E>> TapError<E>(this UnitResult<E> result, Func<E, ValueTask> valueTask)
	{
		if (result.IsFailure)
		{
			await valueTask(result.Error);
		}
		return result;
	}

	public static async ValueTask<Result<T>> TapError<T>(this Result<T> result, Func<string, ValueTask> valueTask)
	{
		if (result.IsFailure)
		{
			await valueTask(result.Error);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> TapError<T, E>(this Result<T, E> result, Func<E, ValueTask> valueTask)
	{
		if (result.IsFailure)
		{
			await valueTask(result.Error);
		}
		return result;
	}

	public static ValueTask<Result> TapErrorIf(this ValueTask<Result> resultTask, bool condition, Func<ValueTask> valueTask)
	{
		if (condition)
		{
			return resultTask.TapError(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<Result> TapErrorIf(this ValueTask<Result> resultTask, bool condition, Func<string, ValueTask> valueTask)
	{
		if (condition)
		{
			return resultTask.TapError(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<Result<T>> TapErrorIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<ValueTask> valueTask)
	{
		if (condition)
		{
			return resultTask.TapError(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<Result<T>> TapErrorIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Func<string, ValueTask> valueTask)
	{
		if (condition)
		{
			return resultTask.TapError(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<Result<T, E>> TapErrorIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<ValueTask> valueTask)
	{
		if (condition)
		{
			return resultTask.TapError(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<Result<T, E>> TapErrorIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Func<E, ValueTask> valueTask)
	{
		if (condition)
		{
			return resultTask.TapError(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Func<ValueTask> valueTask)
	{
		if (condition)
		{
			return resultTask.TapError(valueTask);
		}
		return resultTask;
	}

	public static ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Func<E, ValueTask> valueTask)
	{
		if (condition)
		{
			return resultTask.TapError(valueTask);
		}
		return resultTask;
	}

	public static async ValueTask<Result> TapErrorIf(this ValueTask<Result> resultTask, Func<string, bool> predicate, Func<ValueTask> valueTask)
	{
		Result result = await resultTask;
		if (result.IsFailure && predicate(result.Error))
		{
			return await result.TapError(valueTask);
		}
		return result;
	}

	public static async ValueTask<Result> TapErrorIf(this ValueTask<Result> resultTask, Func<string, bool> predicate, Func<string, ValueTask> valueTask)
	{
		Result result = await resultTask;
		if (result.IsFailure && predicate(result.Error))
		{
			return await result.TapError(valueTask);
		}
		return result;
	}

	public static async ValueTask<Result<T>> TapErrorIf<T>(this ValueTask<Result<T>> resultTask, Func<string, bool> predicate, Func<ValueTask> valueTask)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure && predicate(result.Error))
		{
			return await result.TapError(valueTask);
		}
		return result;
	}

	public static async ValueTask<Result<T>> TapErrorIf<T>(this ValueTask<Result<T>> resultTask, Func<string, bool> predicate, Func<string, ValueTask> valueTask)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure && predicate(result.Error))
		{
			return await result.TapError(valueTask);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> TapErrorIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, bool> predicate, Func<ValueTask> valueTask)
	{
		Result<T, E> result = await resultTask;
		if (result.IsFailure && predicate(result.Error))
		{
			return await result.TapError(valueTask);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> TapErrorIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, bool> predicate, Func<E, ValueTask> valueTask)
	{
		Result<T, E> result = await resultTask;
		if (result.IsFailure && predicate(result.Error))
		{
			return await result.TapError(valueTask);
		}
		return result;
	}

	public static async ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, bool> predicate, Func<ValueTask> valueTask)
	{
		UnitResult<E> result = await resultTask;
		if (result.IsFailure && predicate(result.Error))
		{
			return await result.TapError(valueTask);
		}
		return result;
	}

	public static async ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, bool> predicate, Func<E, ValueTask> valueTask)
	{
		UnitResult<E> result = await resultTask;
		if (result.IsFailure && predicate(result.Error))
		{
			return await result.TapError(valueTask);
		}
		return result;
	}

	public static ValueTask<Result> TapErrorIf(this ValueTask<Result> resultTask, bool condition, Action action)
	{
		if (condition)
		{
			return resultTask.TapError(action);
		}
		return resultTask;
	}

	public static ValueTask<Result> TapErrorIf(this ValueTask<Result> resultTask, bool condition, Action<string> action)
	{
		if (condition)
		{
			return resultTask.TapError(action);
		}
		return resultTask;
	}

	public static ValueTask<Result<T>> TapErrorIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Action action)
	{
		if (condition)
		{
			return resultTask.TapError(action);
		}
		return resultTask;
	}

	public static ValueTask<Result<T>> TapErrorIf<T>(this ValueTask<Result<T>> resultTask, bool condition, Action<string> action)
	{
		if (condition)
		{
			return resultTask.TapError(action);
		}
		return resultTask;
	}

	public static ValueTask<Result<T, E>> TapErrorIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Action action)
	{
		if (condition)
		{
			return resultTask.TapError(action);
		}
		return resultTask;
	}

	public static ValueTask<Result<T, E>> TapErrorIf<T, E>(this ValueTask<Result<T, E>> resultTask, bool condition, Action<E> action)
	{
		if (condition)
		{
			return resultTask.TapError(action);
		}
		return resultTask;
	}

	public static ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Action action)
	{
		if (condition)
		{
			return resultTask.TapError(action);
		}
		return resultTask;
	}

	public static ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, bool condition, Action<E> action)
	{
		if (condition)
		{
			return resultTask.TapError(action);
		}
		return resultTask;
	}

	public static async ValueTask<Result> TapErrorIf(this ValueTask<Result> resultTask, Func<string, bool> predicate, Action action)
	{
		Result result = await resultTask;
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static async ValueTask<Result> TapErrorIf(this ValueTask<Result> resultTask, Func<string, bool> predicate, Action<string> action)
	{
		Result result = await resultTask;
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static async ValueTask<Result<T>> TapErrorIf<T>(this ValueTask<Result<T>> resultTask, Func<string, bool> predicate, Action action)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static async ValueTask<Result<T>> TapErrorIf<T>(this ValueTask<Result<T>> resultTask, Func<string, bool> predicate, Action<string> action)
	{
		Result<T> result = await resultTask;
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> TapErrorIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, bool> predicate, Action action)
	{
		Result<T, E> result = await resultTask;
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static async ValueTask<Result<T, E>> TapErrorIf<T, E>(this ValueTask<Result<T, E>> resultTask, Func<E, bool> predicate, Action<E> action)
	{
		Result<T, E> result = await resultTask;
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static async ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, bool> predicate, Action action)
	{
		UnitResult<E> result = await resultTask;
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static async ValueTask<UnitResult<E>> TapErrorIf<E>(this ValueTask<UnitResult<E>> resultTask, Func<E, bool> predicate, Action<E> action)
	{
		UnitResult<E> result = await resultTask;
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static ValueTask<Result> TapErrorIf(this Result result, bool condition, Func<ValueTask> func)
	{
		if (condition)
		{
			return result.TapError(func);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result> TapErrorIf(this Result result, bool condition, Func<string, ValueTask> func)
	{
		if (condition)
		{
			return result.TapError(func);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T>> TapErrorIf<T>(this Result<T> result, bool condition, Func<ValueTask> func)
	{
		if (condition)
		{
			return result.TapError(func);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T>> TapErrorIf<T>(this Result<T> result, bool condition, Func<string, ValueTask> func)
	{
		if (condition)
		{
			return result.TapError(func);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T, E>> TapErrorIf<T, E>(this Result<T, E> result, bool condition, Func<ValueTask> func)
	{
		if (condition)
		{
			return result.TapError(func);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T, E>> TapErrorIf<T, E>(this Result<T, E> result, bool condition, Func<E, ValueTask> func)
	{
		if (condition)
		{
			return result.TapError(func);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<UnitResult<E>> TapErrorIf<E>(this UnitResult<E> result, bool condition, Func<ValueTask> func)
	{
		if (condition)
		{
			return result.TapError(func);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<UnitResult<E>> TapErrorIf<E>(this UnitResult<E> result, bool condition, Func<E, ValueTask> func)
	{
		if (condition)
		{
			return result.TapError(func);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result> TapErrorIf(this Result result, Func<string, bool> predicate, Func<ValueTask> func)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(func);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result> TapErrorIf(this Result result, Func<string, bool> predicate, Func<string, ValueTask> func)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(func);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T>> TapErrorIf<T>(this Result<T> result, Func<string, bool> predicate, Func<ValueTask> func)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(func);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T>> TapErrorIf<T>(this Result<T> result, Func<string, bool> predicate, Func<string, ValueTask> func)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(func);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T, E>> TapErrorIf<T, E>(this Result<T, E> result, Func<E, bool> predicate, Func<ValueTask> func)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(func);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<Result<T, E>> TapErrorIf<T, E>(this Result<T, E> result, Func<E, bool> predicate, Func<E, ValueTask> func)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(func);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<UnitResult<E>> TapErrorIf<E>(this UnitResult<E> result, Func<E, bool> predicate, Func<ValueTask> func)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(func);
		}
		return result.AsCompletedValueTask();
	}

	public static ValueTask<UnitResult<E>> TapErrorIf<E>(this UnitResult<E> result, Func<E, bool> predicate, Func<E, ValueTask> func)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(func);
		}
		return result.AsCompletedValueTask();
	}

	private static async ValueTask<T> WithTransactionScope<T>(Func<ValueTask<T>> f) where T : IResult
	{
		using TransactionScope trans = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
		T result = await f();
		if (result.IsSuccess)
		{
			trans.Complete();
		}
		return result;
	}
}
