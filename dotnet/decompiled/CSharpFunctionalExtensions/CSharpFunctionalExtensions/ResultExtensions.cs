using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace CSharpFunctionalExtensions;

public static class ResultExtensions
{
	private static readonly TransactionOptions _transactionOptions = new TransactionOptions
	{
		IsolationLevel = IsolationLevel.ReadCommitted,
		Timeout = TransactionManager.DefaultTimeout
	};

	public static Maybe<T> AsMaybe<T>(this Result<T> result)
	{
		if (!result.IsSuccess)
		{
			return Maybe<T>.None;
		}
		return Maybe<T>.From(result.Value);
	}

	public static Result<K, E> Bind<T, K, E>(this Result<T, E> result, Func<T, Result<K, E>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return func(result.Value);
	}

	public static Result<K> Bind<T, K>(this Result<T> result, Func<T, Result<K>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return func(result.Value);
	}

	public static Result<K> Bind<K>(this Result result, Func<Result<K>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return func();
	}

	public static Result Bind<T>(this Result<T> result, Func<T, Result> func)
	{
		if (result.IsFailure)
		{
			return result;
		}
		return func(result.Value);
	}

	public static Result Bind(this Result result, Func<Result> func)
	{
		if (result.IsFailure)
		{
			return result;
		}
		return func();
	}

	public static UnitResult<E> Bind<E>(this UnitResult<E> result, Func<UnitResult<E>> func)
	{
		if (result.IsFailure)
		{
			return result.Error;
		}
		return func();
	}

	public static Result<T, E> Bind<T, E>(this UnitResult<E> result, Func<Result<T, E>> func)
	{
		if (result.IsFailure)
		{
			return result.Error;
		}
		return func();
	}

	public static UnitResult<E> Bind<T, E>(this Result<T, E> result, Func<T, UnitResult<E>> func)
	{
		if (result.IsFailure)
		{
			return result.Error;
		}
		return func(result.Value);
	}

	public static Result BindIf(this Result result, bool condition, Func<Result> func)
	{
		if (!condition)
		{
			return result;
		}
		return result.Bind(func);
	}

	public static Result<T> BindIf<T>(this Result<T> result, bool condition, Func<T, Result<T>> func)
	{
		if (!condition)
		{
			return result;
		}
		return result.Bind(func);
	}

	public static UnitResult<E> BindIf<E>(this UnitResult<E> result, bool condition, Func<UnitResult<E>> func)
	{
		if (!condition)
		{
			return result;
		}
		return result.Bind(func);
	}

	public static Result<T, E> BindIf<T, E>(this Result<T, E> result, bool condition, Func<T, Result<T, E>> func)
	{
		if (!condition)
		{
			return result;
		}
		return result.Bind(func);
	}

	public static Result BindIf(this Result result, Func<bool> predicate, Func<Result> func)
	{
		if (!result.IsSuccess || !predicate())
		{
			return result;
		}
		return result.Bind(func);
	}

	public static Result<T> BindIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Result<T>> func)
	{
		if (!result.IsSuccess || !predicate(result.Value))
		{
			return result;
		}
		return result.Bind(func);
	}

	public static UnitResult<E> BindIf<E>(this UnitResult<E> result, Func<bool> predicate, Func<UnitResult<E>> func)
	{
		if (!result.IsSuccess || !predicate())
		{
			return result;
		}
		return result.Bind(func);
	}

	public static Result<T, E> BindIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, Result<T, E>> func)
	{
		if (!result.IsSuccess || !predicate(result.Value))
		{
			return result;
		}
		return result.Bind(func);
	}

	public static async Task<Result> BindIf(this Task<Result> resultTask, bool condition, Func<Task<Result>> func)
	{
		return await (await resultTask.DefaultAwait()).BindIf(condition, func).DefaultAwait();
	}

	public static async Task<Result<T>> BindIf<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<Result<T>>> func)
	{
		return await (await resultTask.DefaultAwait()).BindIf(condition, func).DefaultAwait();
	}

	public static async Task<UnitResult<E>> BindIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Func<Task<UnitResult<E>>> func)
	{
		return await (await resultTask.DefaultAwait()).BindIf(condition, func).DefaultAwait();
	}

	public static async Task<Result<T, E>> BindIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, Task<Result<T, E>>> func)
	{
		return await (await resultTask.DefaultAwait()).BindIf(condition, func).DefaultAwait();
	}

	public static async Task<Result> BindIf(this Task<Result> resultTask, Func<bool> predicate, Func<Task<Result>> func)
	{
		return await (await resultTask.DefaultAwait()).BindIf(predicate, func).DefaultAwait();
	}

	public static async Task<Result<T>> BindIf<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task<Result<T>>> func)
	{
		return await (await resultTask.DefaultAwait()).BindIf(predicate, func).DefaultAwait();
	}

	public static async Task<UnitResult<E>> BindIf<E>(this Task<UnitResult<E>> resultTask, Func<bool> predicate, Func<Task<UnitResult<E>>> func)
	{
		return await (await resultTask.DefaultAwait()).BindIf(predicate, func).DefaultAwait();
	}

	public static async Task<Result<T, E>> BindIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Task<Result<T, E>>> func)
	{
		return await (await resultTask.DefaultAwait()).BindIf(predicate, func).DefaultAwait();
	}

	public static async Task<Result> BindIf(this Task<Result> resultTask, bool condition, Func<Result> func)
	{
		return (await resultTask.DefaultAwait()).BindIf(condition, func);
	}

	public static async Task<Result<T>> BindIf<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Result<T>> func)
	{
		return (await resultTask.DefaultAwait()).BindIf(condition, func);
	}

	public static async Task<UnitResult<E>> BindIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Func<UnitResult<E>> func)
	{
		return (await resultTask.DefaultAwait()).BindIf(condition, func);
	}

	public static async Task<Result<T, E>> BindIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, Result<T, E>> func)
	{
		return (await resultTask.DefaultAwait()).BindIf(condition, func);
	}

	public static async Task<Result> BindIf(this Task<Result> resultTask, Func<bool> predicate, Func<Result> func)
	{
		return (await resultTask.DefaultAwait()).BindIf(predicate, func);
	}

	public static async Task<Result<T>> BindIf<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Result<T>> func)
	{
		return (await resultTask.DefaultAwait()).BindIf(predicate, func);
	}

	public static async Task<UnitResult<E>> BindIf<E>(this Task<UnitResult<E>> resultTask, Func<bool> predicate, Func<UnitResult<E>> func)
	{
		return (await resultTask.DefaultAwait()).BindIf(predicate, func);
	}

	public static async Task<Result<T, E>> BindIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Result<T, E>> func)
	{
		return (await resultTask.DefaultAwait()).BindIf(predicate, func);
	}

	public static Task<Result> BindIf(this Result result, bool condition, Func<Task<Result>> func)
	{
		if (!condition)
		{
			return result.AsCompletedTask();
		}
		return result.Bind(func);
	}

	public static Task<Result<T>> BindIf<T>(this Result<T> result, bool condition, Func<T, Task<Result<T>>> func)
	{
		if (!condition)
		{
			return result.AsCompletedTask();
		}
		return result.Bind(func);
	}

	public static Task<UnitResult<E>> BindIf<E>(this UnitResult<E> result, bool condition, Func<Task<UnitResult<E>>> func)
	{
		if (!condition)
		{
			return result.AsCompletedTask();
		}
		return result.Bind(func);
	}

	public static Task<Result<T, E>> BindIf<T, E>(this Result<T, E> result, bool condition, Func<T, Task<Result<T, E>>> func)
	{
		if (!condition)
		{
			return result.AsCompletedTask();
		}
		return result.Bind(func);
	}

	public static Task<Result> BindIf(this Result result, Func<bool> predicate, Func<Task<Result>> func)
	{
		if (!result.IsSuccess || !predicate())
		{
			return result.AsCompletedTask();
		}
		return result.Bind(func);
	}

	public static Task<Result<T>> BindIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Task<Result<T>>> func)
	{
		if (!result.IsSuccess || !predicate(result.Value))
		{
			return result.AsCompletedTask();
		}
		return result.Bind(func);
	}

	public static Task<UnitResult<E>> BindIf<E>(this UnitResult<E> result, Func<bool> predicate, Func<Task<UnitResult<E>>> func)
	{
		if (!result.IsSuccess || !predicate())
		{
			return result.AsCompletedTask();
		}
		return result.Bind(func);
	}

	public static Task<Result<T, E>> BindIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, Task<Result<T, E>>> func)
	{
		if (!result.IsSuccess || !predicate(result.Value))
		{
			return result.AsCompletedTask();
		}
		return result.Bind(func);
	}

	public static Result<Maybe<K>, E> BindOptional<T, K, E>(this Result<Maybe<T>, E> result, Func<T, Result<K, E>> bind)
	{
		if (result.IsFailure)
		{
			return Result.Failure<Maybe<K>, E>(result.Error);
		}
		if (result.Value.HasNoValue)
		{
			return Result.Success<Maybe<K>, E>(Maybe.None);
		}
		return bind(result.Value.Value).Map(Maybe.From);
	}

	public static Result BindTry(this Result result, Func<Result> func, Func<Exception, string> errorHandler = null)
	{
		if (!result.IsFailure)
		{
			return Result.Try(() => func(), errorHandler).Bind((Result r) => r);
		}
		return Result.Failure(result.Error);
	}

	public static Result<K> BindTry<K>(this Result result, Func<Result<K>> func, Func<Exception, string> errorHandler = null)
	{
		if (!result.IsFailure)
		{
			return Result.Try(() => func(), errorHandler).Bind((Result<K> r) => r);
		}
		return Result.Failure<K>(result.Error);
	}

	public static Result BindTry<T>(this Result<T> result, Func<T, Result> func, Func<Exception, string> errorHandler = null)
	{
		if (!result.IsFailure)
		{
			return Result.Try(() => func(result.Value), errorHandler).Bind((Result r) => r);
		}
		return Result.Failure(result.Error);
	}

	public static Result<K> BindTry<T, K>(this Result<T> result, Func<T, Result<K>> func, Func<Exception, string> errorHandler = null)
	{
		if (!result.IsFailure)
		{
			return Result.Try(() => func(result.Value), errorHandler).Bind((Result<K> r) => r);
		}
		return Result.Failure<K>(result.Error);
	}

	public static Result<K, E> BindTry<T, K, E>(this Result<T, E> result, Func<T, Result<K, E>> func, Func<Exception, E> errorHandler)
	{
		if (!result.IsFailure)
		{
			return Result.Try(() => func(result.Value), errorHandler).Bind((Result<K, E> r) => r);
		}
		return Result.Failure<K, E>(result.Error);
	}

	public static UnitResult<E> BindTry<E>(this UnitResult<E> result, Func<UnitResult<E>> func, Func<Exception, E> errorHandler)
	{
		if (!result.IsFailure)
		{
			return Result.Try(() => func(), errorHandler).Bind((UnitResult<E> r) => r);
		}
		return UnitResult.Failure<E>(result.Error);
	}

	public static Result<T, E> BindTry<T, E>(this UnitResult<E> result, Func<Result<T, E>> func, Func<Exception, E> errorHandler)
	{
		if (!result.IsFailure)
		{
			return Result.Try(() => func(), errorHandler).Bind((Result<T, E> r) => r);
		}
		return Result.Failure<T, E>(result.Error);
	}

	public static UnitResult<E> BindTry<T, E>(this Result<T, E> result, Func<T, UnitResult<E>> func, Func<Exception, E> errorHandler)
	{
		if (!result.IsFailure)
		{
			return Result.Try(() => func(result.Value), errorHandler).Bind((UnitResult<E> r) => r);
		}
		return Result.Failure<T, E>(result.Error);
	}

	public static Result<K> BindWithTransactionScope<T, K>(this Result<T> self, Func<T, Result<K>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Result<K> BindWithTransactionScope<K>(this Result self, Func<Result<K>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Result BindWithTransactionScope<T>(this Result<T> self, Func<T, Result> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Result BindWithTransactionScope(this Result self, Func<Result> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Result<K, E> BindWithTransactionScope<T, K, E>(this Result<T, E> self, Func<T, Result<K, E>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Task<Result<K, E>> BindWithTransactionScope<T, K, E>(this Task<Result<T, E>> self, Func<T, Task<Result<K, E>>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Task<Result<K>> BindWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, Task<Result<K>>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Task<Result<K>> BindWithTransactionScope<K>(this Task<Result> self, Func<Task<Result<K>>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Task<Result> BindWithTransactionScope<T>(this Task<Result<T>> self, Func<T, Task<Result>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Task<Result> BindWithTransactionScope(this Task<Result> self, Func<Task<Result>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Task<Result<K, E>> BindWithTransactionScope<T, K, E>(this Task<Result<T, E>> self, Func<T, Result<K, E>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Task<Result<K>> BindWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, Result<K>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Task<Result<K>> BindWithTransactionScope<K>(this Task<Result> self, Func<Result<K>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Task<Result> BindWithTransactionScope<T>(this Task<Result<T>> self, Func<T, Result> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Task<Result> BindWithTransactionScope(this Task<Result> self, Func<Result> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Task<Result<K, E>> BindWithTransactionScope<T, K, E>(this Result<T, E> self, Func<T, Task<Result<K, E>>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Task<Result<K>> BindWithTransactionScope<T, K>(this Result<T> self, Func<T, Task<Result<K>>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Task<Result<K>> BindWithTransactionScope<K>(this Result self, Func<Task<Result<K>>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Task<Result> BindWithTransactionScope<T>(this Result<T> self, Func<T, Task<Result>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Task<Result> BindWithTransactionScope(this Result self, Func<Task<Result>> f)
	{
		return WithTransactionScope(() => self.Bind(f));
	}

	public static Result<(T First, K Second)> BindZip<T, K>(this Result<T> result, Func<T, Result<K>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<(T, K)>(result.Error);
		}
		Result<K> result2 = func(result.Value);
		if (!result2.IsFailure)
		{
			return Result.Success((result.Value, result2.Value));
		}
		return Result.Failure<(T, K)>(result2.Error);
	}

	public static Result<(T First, K Second), E> BindZip<T, K, E>(this Result<T, E> result, Func<T, Result<K, E>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<(T, K), E>(result.Error);
		}
		Result<K, E> result2 = func(result.Value);
		if (!result2.IsFailure)
		{
			return Result.Success<(T, K), E>((result.Value, result2.Value));
		}
		return Result.Failure<(T, K), E>(result2.Error);
	}

	public static Result<(T1 First, T2 Second, K Third)> BindZip<T1, T2, K>(this Result<(T1, T2)> result, Func<T1, T2, Result<K>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, K)>(result.Error);
		}
		(T1, T2) value = result.Value;
		Result<K> result2 = func(value.Item1, value.Item2);
		if (!result2.IsFailure)
		{
			return Result.Success((value.Item1, value.Item2, result2.Value));
		}
		return Result.Failure<(T1, T2, K)>(result2.Error);
	}

	public static Result<(T1 First, T2 Second, K Third), E> BindZip<T1, T2, K, E>(this Result<(T1, T2), E> result, Func<T1, T2, Result<K, E>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, K), E>(result.Error);
		}
		(T1, T2) value = result.Value;
		Result<K, E> result2 = func(value.Item1, value.Item2);
		if (!result2.IsFailure)
		{
			return Result.Success<(T1, T2, K), E>((value.Item1, value.Item2, result2.Value));
		}
		return Result.Failure<(T1, T2, K), E>(result2.Error);
	}

	public static Result<(T1, T2, T3, K)> BindZip<T1, T2, T3, K>(this Result<(T1, T2, T3)> result, Func<T1, T2, T3, Result<K>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, K)>(result.Error);
		}
		(T1, T2, T3) value = result.Value;
		Result<K> result2 = func(value.Item1, value.Item2, value.Item3);
		if (!result2.IsFailure)
		{
			return Result.Success((value.Item1, value.Item2, value.Item3, result2.Value));
		}
		return Result.Failure<(T1, T2, T3, K)>(result2.Error);
	}

	public static Result<(T1, T2, T3, K), E> BindZip<T1, T2, T3, K, E>(this Result<(T1, T2, T3), E> result, Func<T1, T2, T3, Result<K, E>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, K), E>(result.Error);
		}
		(T1, T2, T3) value = result.Value;
		Result<K, E> result2 = func(value.Item1, value.Item2, value.Item3);
		if (!result2.IsFailure)
		{
			return Result.Success<(T1, T2, T3, K), E>((value.Item1, value.Item2, value.Item3, result2.Value));
		}
		return Result.Failure<(T1, T2, T3, K), E>(result2.Error);
	}

	public static Result<(T1, T2, T3, T4, K)> BindZip<T1, T2, T3, T4, K>(this Result<(T1, T2, T3, T4)> result, Func<T1, T2, T3, T4, Result<K>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, T4, K)>(result.Error);
		}
		(T1, T2, T3, T4) value = result.Value;
		Result<K> result2 = func(value.Item1, value.Item2, value.Item3, value.Item4);
		if (!result2.IsFailure)
		{
			return Result.Success((value.Item1, value.Item2, value.Item3, value.Item4, result2.Value));
		}
		return Result.Failure<(T1, T2, T3, T4, K)>(result2.Error);
	}

	public static Result<(T1, T2, T3, T4, K), E> BindZip<T1, T2, T3, T4, K, E>(this Result<(T1, T2, T3, T4), E> result, Func<T1, T2, T3, T4, Result<K, E>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, T4, K), E>(result.Error);
		}
		(T1, T2, T3, T4) value = result.Value;
		Result<K, E> result2 = func(value.Item1, value.Item2, value.Item3, value.Item4);
		if (!result2.IsFailure)
		{
			return Result.Success<(T1, T2, T3, T4, K), E>((value.Item1, value.Item2, value.Item3, value.Item4, result2.Value));
		}
		return Result.Failure<(T1, T2, T3, T4, K), E>(result2.Error);
	}

	public static Result<(T1, T2, T3, T4, T5, K)> BindZip<T1, T2, T3, T4, T5, K>(this Result<(T1, T2, T3, T4, T5)> result, Func<T1, T2, T3, T4, T5, Result<K>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, T4, T5, K)>(result.Error);
		}
		(T1, T2, T3, T4, T5) value = result.Value;
		Result<K> result2 = func(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5);
		if (!result2.IsFailure)
		{
			return Result.Success((value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, result2.Value));
		}
		return Result.Failure<(T1, T2, T3, T4, T5, K)>(result2.Error);
	}

	public static Result<(T1, T2, T3, T4, T5, K), E> BindZip<T1, T2, T3, T4, T5, K, E>(this Result<(T1, T2, T3, T4, T5), E> result, Func<T1, T2, T3, T4, T5, Result<K, E>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, T4, T5, K), E>(result.Error);
		}
		(T1, T2, T3, T4, T5) value = result.Value;
		Result<K, E> result2 = func(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5);
		if (!result2.IsFailure)
		{
			return Result.Success<(T1, T2, T3, T4, T5, K), E>((value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, result2.Value));
		}
		return Result.Failure<(T1, T2, T3, T4, T5, K), E>(result2.Error);
	}

	public static Result<(T1, T2, T3, T4, T5, T6, K)> BindZip<T1, T2, T3, T4, T5, T6, K>(this Result<(T1, T2, T3, T4, T5, T6)> result, Func<T1, T2, T3, T4, T5, T6, Result<K>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, T4, T5, T6, K)>(result.Error);
		}
		(T1, T2, T3, T4, T5, T6) value = result.Value;
		Result<K> result2 = func(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6);
		if (!result2.IsFailure)
		{
			return Result.Success((value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, result2.Value));
		}
		return Result.Failure<(T1, T2, T3, T4, T5, T6, K)>(result2.Error);
	}

	public static Result<(T1, T2, T3, T4, T5, T6, K), E> BindZip<T1, T2, T3, T4, T5, T6, K, E>(this Result<(T1, T2, T3, T4, T5, T6), E> result, Func<T1, T2, T3, T4, T5, T6, Result<K, E>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, T4, T5, T6, K), E>(result.Error);
		}
		(T1, T2, T3, T4, T5, T6) value = result.Value;
		Result<K, E> result2 = func(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6);
		if (!result2.IsFailure)
		{
			return Result.Success<(T1, T2, T3, T4, T5, T6, K), E>((value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, result2.Value));
		}
		return Result.Failure<(T1, T2, T3, T4, T5, T6, K), E>(result2.Error);
	}

	public static Result<(T1, T2, T3, T4, T5, T6, T7, K)> BindZip<T1, T2, T3, T4, T5, T6, T7, K>(this Result<(T1, T2, T3, T4, T5, T6, T7)> result, Func<T1, T2, T3, T4, T5, T6, T7, Result<K>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, T4, T5, T6, T7, K)>(result.Error);
		}
		(T1, T2, T3, T4, T5, T6, T7) value = result.Value;
		Result<K> result2 = func(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7);
		if (!result2.IsFailure)
		{
			return Result.Success((value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7, result2.Value));
		}
		return Result.Failure<(T1, T2, T3, T4, T5, T6, T7, K)>(result2.Error);
	}

	public static Result<(T1, T2, T3, T4, T5, T6, T7, K), E> BindZip<T1, T2, T3, T4, T5, T6, T7, K, E>(this Result<(T1, T2, T3, T4, T5, T6, T7), E> result, Func<T1, T2, T3, T4, T5, T6, T7, Result<K, E>> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, T4, T5, T6, T7, K), E>(result.Error);
		}
		(T1, T2, T3, T4, T5, T6, T7) value = result.Value;
		Result<K, E> result2 = func(value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7);
		if (!result2.IsFailure)
		{
			return Result.Success<(T1, T2, T3, T4, T5, T6, T7, K), E>((value.Item1, value.Item2, value.Item3, value.Item4, value.Item5, value.Item6, value.Item7, result2.Value));
		}
		return Result.Failure<(T1, T2, T3, T4, T5, T6, T7, K), E>(result2.Error);
	}

	public static async Task<Result<(T First, K Second)>> BindZip<T, K>(this Task<Result<T>> resultTask, Func<T, Task<Result<K>>> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<(T, K)>(result.Error);
		}
		T v = result.Value;
		Result<K> result2 = await func(v).DefaultAwait();
		return result2.IsFailure ? Result.Failure<(T, K)>(result2.Error) : Result.Success((v, result2.Value));
	}

	public static async Task<Result<(T First, K Second), E>> BindZip<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Task<Result<K, E>>> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<(T, K), E>(result.Error);
		}
		T value = result.Value;
		Result<K, E> result2 = await func(value).DefaultAwait();
		return result2.IsFailure ? Result.Failure<(T, K), E>(result2.Error) : Result.Success<(T, K), E>((value, result2.Value));
	}

	public static async Task<Result<(T1 First, T2 Second, K Third)>> BindZip<T1, T2, K>(this Task<Result<(T1, T2)>> resultTask, Func<T1, T2, Task<Result<K>>> func)
	{
		Result<(T1, T2)> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, K)>(result.Error);
		}
		(T1, T2) v = result.Value;
		Result<K> result2 = await func(v.Item1, v.Item2).DefaultAwait();
		return result2.IsFailure ? Result.Failure<(T1, T2, K)>(result2.Error) : Result.Success((v.Item1, v.Item2, result2.Value));
	}

	public static async Task<Result<(T1 First, T2 Second, K Third), E>> BindZip<T1, T2, K, E>(this Task<Result<(T1, T2), E>> resultTask, Func<T1, T2, Task<Result<K, E>>> func)
	{
		Result<(T1, T2), E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, K), E>(result.Error);
		}
		(T1, T2) v = result.Value;
		Result<K, E> result2 = await func(v.Item1, v.Item2).DefaultAwait();
		return result2.IsFailure ? Result.Failure<(T1, T2, K), E>(result2.Error) : Result.Success<(T1, T2, K), E>((v.Item1, v.Item2, result2.Value));
	}

	public static async Task<Result<(T1, T2, T3, K)>> BindZip<T1, T2, T3, K>(this Task<Result<(T1, T2, T3)>> resultTask, Func<T1, T2, T3, Task<Result<K>>> func)
	{
		Result<(T1, T2, T3)> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, K)>(result.Error);
		}
		(T1, T2, T3) v = result.Value;
		Result<K> result2 = await func(v.Item1, v.Item2, v.Item3).DefaultAwait();
		return result2.IsFailure ? Result.Failure<(T1, T2, T3, K)>(result2.Error) : Result.Success((v.Item1, v.Item2, v.Item3, result2.Value));
	}

	public static async Task<Result<(T1, T2, T3, K), E>> BindZip<T1, T2, T3, K, E>(this Task<Result<(T1, T2, T3), E>> resultTask, Func<T1, T2, T3, Task<Result<K, E>>> func)
	{
		Result<(T1, T2, T3), E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, K), E>(result.Error);
		}
		(T1, T2, T3) v = result.Value;
		Result<K, E> result2 = await func(v.Item1, v.Item2, v.Item3).DefaultAwait();
		return result2.IsFailure ? Result.Failure<(T1, T2, T3, K), E>(result2.Error) : Result.Success<(T1, T2, T3, K), E>((v.Item1, v.Item2, v.Item3, result2.Value));
	}

	public static async Task<Result<(T1, T2, T3, T4, K)>> BindZip<T1, T2, T3, T4, K>(this Task<Result<(T1, T2, T3, T4)>> resultTask, Func<T1, T2, T3, T4, Task<Result<K>>> func)
	{
		Result<(T1, T2, T3, T4)> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, T4, K)>(result.Error);
		}
		(T1, T2, T3, T4) v = result.Value;
		Result<K> result2 = await func(v.Item1, v.Item2, v.Item3, v.Item4).DefaultAwait();
		return result2.IsFailure ? Result.Failure<(T1, T2, T3, T4, K)>(result2.Error) : Result.Success((v.Item1, v.Item2, v.Item3, v.Item4, result2.Value));
	}

	public static async Task<Result<(T1, T2, T3, T4, K), E>> BindZip<T1, T2, T3, T4, K, E>(this Task<Result<(T1, T2, T3, T4), E>> resultTask, Func<T1, T2, T3, T4, Task<Result<K, E>>> func)
	{
		Result<(T1, T2, T3, T4), E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, T4, K), E>(result.Error);
		}
		(T1, T2, T3, T4) v = result.Value;
		Result<K, E> result2 = await func(v.Item1, v.Item2, v.Item3, v.Item4).DefaultAwait();
		return result2.IsFailure ? Result.Failure<(T1, T2, T3, T4, K), E>(result2.Error) : Result.Success<(T1, T2, T3, T4, K), E>((v.Item1, v.Item2, v.Item3, v.Item4, result2.Value));
	}

	public static async Task<Result<(T1, T2, T3, T4, T5, K)>> BindZip<T1, T2, T3, T4, T5, K>(this Task<Result<(T1, T2, T3, T4, T5)>> resultTask, Func<T1, T2, T3, T4, T5, Task<Result<K>>> func)
	{
		Result<(T1, T2, T3, T4, T5)> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, T4, T5, K)>(result.Error);
		}
		(T1, T2, T3, T4, T5) v = result.Value;
		Result<K> result2 = await func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5).DefaultAwait();
		return result2.IsFailure ? Result.Failure<(T1, T2, T3, T4, T5, K)>(result2.Error) : Result.Success((v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, result2.Value));
	}

	public static async Task<Result<(T1, T2, T3, T4, T5, K), E>> BindZip<T1, T2, T3, T4, T5, K, E>(this Task<Result<(T1, T2, T3, T4, T5), E>> resultTask, Func<T1, T2, T3, T4, T5, Task<Result<K, E>>> func)
	{
		Result<(T1, T2, T3, T4, T5), E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, T4, T5, K), E>(result.Error);
		}
		(T1, T2, T3, T4, T5) v = result.Value;
		Result<K, E> result2 = await func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5).DefaultAwait();
		return result2.IsFailure ? Result.Failure<(T1, T2, T3, T4, T5, K), E>(result2.Error) : Result.Success<(T1, T2, T3, T4, T5, K), E>((v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, result2.Value));
	}

	public static async Task<Result<(T1, T2, T3, T4, T5, T6, K)>> BindZip<T1, T2, T3, T4, T5, T6, K>(this Task<Result<(T1, T2, T3, T4, T5, T6)>> resultTask, Func<T1, T2, T3, T4, T5, T6, Task<Result<K>>> func)
	{
		Result<(T1, T2, T3, T4, T5, T6)> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, T4, T5, T6, K)>(result.Error);
		}
		(T1, T2, T3, T4, T5, T6) v = result.Value;
		Result<K> result2 = await func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6).DefaultAwait();
		return result2.IsFailure ? Result.Failure<(T1, T2, T3, T4, T5, T6, K)>(result2.Error) : Result.Success((v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, result2.Value));
	}

	public static async Task<Result<(T1, T2, T3, T4, T5, T6, K), E>> BindZip<T1, T2, T3, T4, T5, T6, K, E>(this Task<Result<(T1, T2, T3, T4, T5, T6), E>> resultTask, Func<T1, T2, T3, T4, T5, T6, Task<Result<K, E>>> func)
	{
		Result<(T1, T2, T3, T4, T5, T6), E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, T4, T5, T6, K), E>(result.Error);
		}
		(T1, T2, T3, T4, T5, T6) v = result.Value;
		Result<K, E> result2 = await func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6).DefaultAwait();
		return result2.IsFailure ? Result.Failure<(T1, T2, T3, T4, T5, T6, K), E>(result2.Error) : Result.Success<(T1, T2, T3, T4, T5, T6, K), E>((v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, result2.Value));
	}

	public static async Task<Result<(T1, T2, T3, T4, T5, T6, T7, K)>> BindZip<T1, T2, T3, T4, T5, T6, T7, K>(this Task<Result<(T1, T2, T3, T4, T5, T6, T7)>> resultTask, Func<T1, T2, T3, T4, T5, T6, T7, Task<Result<K>>> func)
	{
		Result<(T1, T2, T3, T4, T5, T6, T7)> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, T4, T5, T6, T7, K)>(result.Error);
		}
		(T1, T2, T3, T4, T5, T6, T7) v = result.Value;
		Result<K> result2 = await func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, v.Item7).DefaultAwait();
		return result2.IsFailure ? Result.Failure<(T1, T2, T3, T4, T5, T6, T7, K)>(result2.Error) : Result.Success((v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, v.Item7, result2.Value));
	}

	public static async Task<Result<(T1, T2, T3, T4, T5, T6, T7, K), E>> BindZip<T1, T2, T3, T4, T5, T6, T7, K, E>(this Task<Result<(T1, T2, T3, T4, T5, T6, T7), E>> resultTask, Func<T1, T2, T3, T4, T5, T6, T7, Task<Result<K, E>>> func)
	{
		Result<(T1, T2, T3, T4, T5, T6, T7), E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			return Result.Failure<(T1, T2, T3, T4, T5, T6, T7, K), E>(result.Error);
		}
		(T1, T2, T3, T4, T5, T6, T7) v = result.Value;
		Result<K, E> result2 = await func(v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, v.Item7).DefaultAwait();
		return result2.IsFailure ? Result.Failure<(T1, T2, T3, T4, T5, T6, T7, K), E>(result2.Error) : Result.Success<(T1, T2, T3, T4, T5, T6, T7, K), E>((v.Item1, v.Item2, v.Item3, v.Item4, v.Item5, v.Item6, v.Item7, result2.Value));
	}

	public static Task<Result<(T First, K Second)>> BindZip<T, K>(this Result<T> result, Func<T, Task<Result<K>>> func)
	{
		if (!result.IsFailure)
		{
			return result.AsCompletedTask().BindZip(func);
		}
		return Result.Failure<(T, K)>(result.Error).AsCompletedTask();
	}

	public static Task<Result<(T First, K Second), E>> BindZip<T, K, E>(this Result<T, E> result, Func<T, Task<Result<K, E>>> func)
	{
		if (!result.IsFailure)
		{
			return result.AsCompletedTask().BindZip(func);
		}
		return Result.Failure<(T, K), E>(result.Error).AsCompletedTask();
	}

	public static Task<Result<(T1 First, T2 Second, K Third)>> BindZip<T1, T2, K>(this Result<(T1, T2)> result, Func<T1, T2, Task<Result<K>>> func)
	{
		if (!result.IsFailure)
		{
			return result.AsCompletedTask().BindZip(func);
		}
		return Result.Failure<(T1, T2, K)>(result.Error).AsCompletedTask();
	}

	public static Task<Result<(T1 First, T2 Second, K Third), E>> BindZip<T1, T2, K, E>(this Result<(T1, T2), E> result, Func<T1, T2, Task<Result<K, E>>> func)
	{
		if (!result.IsFailure)
		{
			return result.AsCompletedTask().BindZip(func);
		}
		return Result.Failure<(T1, T2, K), E>(result.Error).AsCompletedTask();
	}

	public static Task<Result<(T1, T2, T3, K)>> BindZip<T1, T2, T3, K>(this Result<(T1, T2, T3)> result, Func<T1, T2, T3, Task<Result<K>>> func)
	{
		if (!result.IsFailure)
		{
			return result.AsCompletedTask().BindZip(func);
		}
		return Result.Failure<(T1, T2, T3, K)>(result.Error).AsCompletedTask();
	}

	public static Task<Result<(T1, T2, T3, K), E>> BindZip<T1, T2, T3, K, E>(this Result<(T1, T2, T3), E> result, Func<T1, T2, T3, Task<Result<K, E>>> func)
	{
		if (!result.IsFailure)
		{
			return result.AsCompletedTask().BindZip(func);
		}
		return Result.Failure<(T1, T2, T3, K), E>(result.Error).AsCompletedTask();
	}

	public static Task<Result<(T1, T2, T3, T4, K)>> BindZip<T1, T2, T3, T4, K>(this Result<(T1, T2, T3, T4)> result, Func<T1, T2, T3, T4, Task<Result<K>>> func)
	{
		if (!result.IsFailure)
		{
			return result.AsCompletedTask().BindZip(func);
		}
		return Result.Failure<(T1, T2, T3, T4, K)>(result.Error).AsCompletedTask();
	}

	public static Task<Result<(T1, T2, T3, T4, K), E>> BindZip<T1, T2, T3, T4, K, E>(this Result<(T1, T2, T3, T4), E> result, Func<T1, T2, T3, T4, Task<Result<K, E>>> func)
	{
		if (!result.IsFailure)
		{
			return result.AsCompletedTask().BindZip(func);
		}
		return Result.Failure<(T1, T2, T3, T4, K), E>(result.Error).AsCompletedTask();
	}

	public static Task<Result<(T1, T2, T3, T4, T5, K)>> BindZip<T1, T2, T3, T4, T5, K>(this Result<(T1, T2, T3, T4, T5)> result, Func<T1, T2, T3, T4, T5, Task<Result<K>>> func)
	{
		if (!result.IsFailure)
		{
			return result.AsCompletedTask().BindZip(func);
		}
		return Result.Failure<(T1, T2, T3, T4, T5, K)>(result.Error).AsCompletedTask();
	}

	public static Task<Result<(T1, T2, T3, T4, T5, K), E>> BindZip<T1, T2, T3, T4, T5, K, E>(this Result<(T1, T2, T3, T4, T5), E> result, Func<T1, T2, T3, T4, T5, Task<Result<K, E>>> func)
	{
		if (!result.IsFailure)
		{
			return result.AsCompletedTask().BindZip(func);
		}
		return Result.Failure<(T1, T2, T3, T4, T5, K), E>(result.Error).AsCompletedTask();
	}

	public static Task<Result<(T1, T2, T3, T4, T5, T6, K)>> BindZip<T1, T2, T3, T4, T5, T6, K>(this Result<(T1, T2, T3, T4, T5, T6)> result, Func<T1, T2, T3, T4, T5, T6, Task<Result<K>>> func)
	{
		if (!result.IsFailure)
		{
			return result.AsCompletedTask().BindZip(func);
		}
		return Result.Failure<(T1, T2, T3, T4, T5, T6, K)>(result.Error).AsCompletedTask();
	}

	public static Task<Result<(T1, T2, T3, T4, T5, T6, K), E>> BindZip<T1, T2, T3, T4, T5, T6, K, E>(this Result<(T1, T2, T3, T4, T5, T6), E> result, Func<T1, T2, T3, T4, T5, T6, Task<Result<K, E>>> func)
	{
		if (!result.IsFailure)
		{
			return result.AsCompletedTask().BindZip(func);
		}
		return Result.Failure<(T1, T2, T3, T4, T5, T6, K), E>(result.Error).AsCompletedTask();
	}

	public static Task<Result<(T1, T2, T3, T4, T5, T6, T7, K)>> BindZip<T1, T2, T3, T4, T5, T6, T7, K>(this Result<(T1, T2, T3, T4, T5, T6, T7)> result, Func<T1, T2, T3, T4, T5, T6, T7, Task<Result<K>>> func)
	{
		if (!result.IsFailure)
		{
			return result.AsCompletedTask().BindZip(func);
		}
		return Result.Failure<(T1, T2, T3, T4, T5, T6, T7, K)>(result.Error).AsCompletedTask();
	}

	public static Task<Result<(T1, T2, T3, T4, T5, T6, T7, K), E>> BindZip<T1, T2, T3, T4, T5, T6, T7, K, E>(this Result<(T1, T2, T3, T4, T5, T6, T7), E> result, Func<T1, T2, T3, T4, T5, T6, T7, Task<Result<K, E>>> func)
	{
		if (!result.IsFailure)
		{
			return result.AsCompletedTask().BindZip(func);
		}
		return Result.Failure<(T1, T2, T3, T4, T5, T6, T7, K), E>(result.Error).AsCompletedTask();
	}

	public static async Task<Result<(T First, K Second)>> BindZip<T, K>(this Task<Result<T>> resultTask, Func<T, Result<K>> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		return result.IsFailure ? Result.Failure<(T, K)>(result.Error) : result.BindZip(func);
	}

	public static async Task<Result<(T First, K Second), E>> BindZip<T, K, E>(this Task<Result<T, E>> resultTask, Func<T, Result<K, E>> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		return result.IsFailure ? Result.Failure<(T, K), E>(result.Error) : result.BindZip(func);
	}

	public static async Task<Result<(T1 First, T2 Second, K Third)>> BindZip<T1, T2, K>(this Task<Result<(T1, T2)>> resultTask, Func<T1, T2, Result<K>> func)
	{
		Result<(T1, T2)> result = await resultTask.DefaultAwait();
		return result.IsFailure ? Result.Failure<(T1, T2, K)>(result.Error) : result.BindZip(func);
	}

	public static async Task<Result<(T1 First, T2 Second, K Third), E>> BindZip<T1, T2, K, E>(this Task<Result<(T1, T2), E>> resultTask, Func<T1, T2, Result<K, E>> func)
	{
		Result<(T1, T2), E> result = await resultTask.DefaultAwait();
		return result.IsFailure ? Result.Failure<(T1, T2, K), E>(result.Error) : result.BindZip(func);
	}

	public static async Task<Result<(T1, T2, T3, K)>> BindZip<T1, T2, T3, K>(this Task<Result<(T1, T2, T3)>> resultTask, Func<T1, T2, T3, Result<K>> func)
	{
		Result<(T1, T2, T3)> result = await resultTask.DefaultAwait();
		return result.IsFailure ? Result.Failure<(T1, T2, T3, K)>(result.Error) : result.BindZip(func);
	}

	public static async Task<Result<(T1, T2, T3, K), E>> BindZip<T1, T2, T3, K, E>(this Task<Result<(T1, T2, T3), E>> resultTask, Func<T1, T2, T3, Result<K, E>> func)
	{
		Result<(T1, T2, T3), E> result = await resultTask.DefaultAwait();
		return result.IsFailure ? Result.Failure<(T1, T2, T3, K), E>(result.Error) : result.BindZip(func);
	}

	public static async Task<Result<(T1, T2, T3, T4, K)>> BindZip<T1, T2, T3, T4, K>(this Task<Result<(T1, T2, T3, T4)>> resultTask, Func<T1, T2, T3, T4, Result<K>> func)
	{
		Result<(T1, T2, T3, T4)> result = await resultTask.DefaultAwait();
		return result.IsFailure ? Result.Failure<(T1, T2, T3, T4, K)>(result.Error) : result.BindZip(func);
	}

	public static async Task<Result<(T1, T2, T3, T4, K), E>> BindZip<T1, T2, T3, T4, K, E>(this Task<Result<(T1, T2, T3, T4), E>> resultTask, Func<T1, T2, T3, T4, Result<K, E>> func)
	{
		Result<(T1, T2, T3, T4), E> result = await resultTask.DefaultAwait();
		return result.IsFailure ? Result.Failure<(T1, T2, T3, T4, K), E>(result.Error) : result.BindZip(func);
	}

	public static async Task<Result<(T1, T2, T3, T4, T5, K)>> BindZip<T1, T2, T3, T4, T5, K>(this Task<Result<(T1, T2, T3, T4, T5)>> resultTask, Func<T1, T2, T3, T4, T5, Result<K>> func)
	{
		Result<(T1, T2, T3, T4, T5)> result = await resultTask.DefaultAwait();
		return result.IsFailure ? Result.Failure<(T1, T2, T3, T4, T5, K)>(result.Error) : result.BindZip(func);
	}

	public static async Task<Result<(T1, T2, T3, T4, T5, K), E>> BindZip<T1, T2, T3, T4, T5, K, E>(this Task<Result<(T1, T2, T3, T4, T5), E>> resultTask, Func<T1, T2, T3, T4, T5, Result<K, E>> func)
	{
		Result<(T1, T2, T3, T4, T5), E> result = await resultTask.DefaultAwait();
		return result.IsFailure ? Result.Failure<(T1, T2, T3, T4, T5, K), E>(result.Error) : result.BindZip(func);
	}

	public static async Task<Result<(T1, T2, T3, T4, T5, T6, K)>> BindZip<T1, T2, T3, T4, T5, T6, K>(this Task<Result<(T1, T2, T3, T4, T5, T6)>> resultTask, Func<T1, T2, T3, T4, T5, T6, Result<K>> func)
	{
		Result<(T1, T2, T3, T4, T5, T6)> result = await resultTask.DefaultAwait();
		return result.IsFailure ? Result.Failure<(T1, T2, T3, T4, T5, T6, K)>(result.Error) : result.BindZip(func);
	}

	public static async Task<Result<(T1, T2, T3, T4, T5, T6, K), E>> BindZip<T1, T2, T3, T4, T5, T6, K, E>(this Task<Result<(T1, T2, T3, T4, T5, T6), E>> resultTask, Func<T1, T2, T3, T4, T5, T6, Result<K, E>> func)
	{
		Result<(T1, T2, T3, T4, T5, T6), E> result = await resultTask.DefaultAwait();
		return result.IsFailure ? Result.Failure<(T1, T2, T3, T4, T5, T6, K), E>(result.Error) : result.BindZip(func);
	}

	public static async Task<Result<(T1, T2, T3, T4, T5, T6, T7, K)>> BindZip<T1, T2, T3, T4, T5, T6, T7, K>(this Task<Result<(T1, T2, T3, T4, T5, T6, T7)>> resultTask, Func<T1, T2, T3, T4, T5, T6, T7, Result<K>> func)
	{
		Result<(T1, T2, T3, T4, T5, T6, T7)> result = await resultTask.DefaultAwait();
		return result.IsFailure ? Result.Failure<(T1, T2, T3, T4, T5, T6, T7, K)>(result.Error) : result.BindZip(func);
	}

	public static async Task<Result<(T1, T2, T3, T4, T5, T6, T7, K), E>> BindZip<T1, T2, T3, T4, T5, T6, T7, K, E>(this Task<Result<(T1, T2, T3, T4, T5, T6, T7), E>> resultTask, Func<T1, T2, T3, T4, T5, T6, T7, Result<K, E>> func)
	{
		Result<(T1, T2, T3, T4, T5, T6, T7), E> result = await resultTask.DefaultAwait();
		return result.IsFailure ? Result.Failure<(T1, T2, T3, T4, T5, T6, T7, K), E>(result.Error) : result.BindZip(func);
	}

	public static Result<T> Check<T>(this Result<T> result, Func<T, Result> func)
	{
		return result.Bind(func).Map(() => result.Value);
	}

	public static Result<T> Check<T, K>(this Result<T> result, Func<T, Result<K>> func)
	{
		return result.Bind(func).Map((K _) => result.Value);
	}

	public static Result<T, E> Check<T, K, E>(this Result<T, E> result, Func<T, Result<K, E>> func)
	{
		return result.Bind(func).Map((K _) => result.Value);
	}

	public static Result<T, E> Check<T, E>(this Result<T, E> result, Func<T, UnitResult<E>> func)
	{
		return result.Bind(func).Map(() => result.Value);
	}

	public static UnitResult<E> Check<E>(this UnitResult<E> result, Func<UnitResult<E>> func)
	{
		return result.Bind(func).Map(() => result);
	}

	public static Result<T> CheckIf<T>(this Result<T> result, bool condition, Func<T, Result> func)
	{
		if (condition)
		{
			return result.Check(func);
		}
		return result;
	}

	public static Result<T> CheckIf<T, K>(this Result<T> result, bool condition, Func<T, Result<K>> func)
	{
		if (condition)
		{
			return result.Check(func);
		}
		return result;
	}

	public static Result<T, E> CheckIf<T, K, E>(this Result<T, E> result, bool condition, Func<T, Result<K, E>> func)
	{
		if (condition)
		{
			return result.Check(func);
		}
		return result;
	}

	public static Result<T, E> CheckIf<T, E>(this Result<T, E> result, bool condition, Func<T, UnitResult<E>> func)
	{
		if (condition)
		{
			return result.Check(func);
		}
		return result;
	}

	public static UnitResult<E> CheckIf<E>(this UnitResult<E> result, bool condition, Func<UnitResult<E>> func)
	{
		if (condition)
		{
			return result.Check(func);
		}
		return result;
	}

	public static Result<T> CheckIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Result> func)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(func);
		}
		return result;
	}

	public static Result<T> CheckIf<T, K>(this Result<T> result, Func<T, bool> predicate, Func<T, Result<K>> func)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(func);
		}
		return result;
	}

	public static Result<T, E> CheckIf<T, K, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, Result<K, E>> func)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(func);
		}
		return result;
	}

	public static Result<T, E> CheckIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, UnitResult<E>> func)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Check(func);
		}
		return result;
	}

	public static UnitResult<E> CheckIf<E>(this UnitResult<E> result, Func<bool> predicate, Func<UnitResult<E>> func)
	{
		if (result.IsSuccess && predicate())
		{
			return result.Check(func);
		}
		return result;
	}

	public static Result Combine(this IEnumerable<Result> results, string errorMessageSeparator = null)
	{
		return Result.Combine(results, errorMessageSeparator);
	}

	public static UnitResult<E> Combine<E>(this IEnumerable<UnitResult<E>> results) where E : ICombine
	{
		return Result.Combine(results);
	}

	public static Result<IEnumerable<T>, E> Combine<T, E>(this IEnumerable<Result<T, E>> results) where E : ICombine
	{
		results = results.ToList();
		Result<bool, E> result = Result.Combine(results);
		if (!result.IsSuccess)
		{
			return Result.Failure<IEnumerable<T>, E>(result.Error);
		}
		return Result.Success<IEnumerable<T>, E>(results.Select((Result<T, E> e) => e.Value));
	}

	public static Result<IEnumerable<T>, E> Combine<T, E>(this IEnumerable<Result<T, E>> results, Func<IEnumerable<E>, E> composerError)
	{
		results = results.ToList();
		Result<bool, E> result = Result.Combine(results, composerError);
		if (!result.IsSuccess)
		{
			return Result.Failure<IEnumerable<T>, E>(result.Error);
		}
		return Result.Success<IEnumerable<T>, E>(results.Select((Result<T, E> e) => e.Value));
	}

	public static Result<IEnumerable<T>> Combine<T>(this IEnumerable<Result<T>> results, string errorMessageSeparator = null)
	{
		results = results.ToList();
		Result result = Result.Combine(results, errorMessageSeparator);
		if (!result.IsSuccess)
		{
			return Result.Failure<IEnumerable<T>>(result.Error);
		}
		return Result.Success(results.Select((Result<T> e) => e.Value));
	}

	public static Result<K, E> Combine<T, K, E>(this IEnumerable<Result<T, E>> results, Func<IEnumerable<T>, K> composer, Func<IEnumerable<E>, E> composerError)
	{
		Result<IEnumerable<T>, E> result = results.Combine(composerError);
		if (!result.IsSuccess)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(composer(result.Value));
	}

	public static Result<K, E> Combine<T, K, E>(this IEnumerable<Result<T, E>> results, Func<IEnumerable<T>, K> composer) where E : ICombine
	{
		Result<IEnumerable<T>, E> result = results.Combine();
		if (!result.IsSuccess)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(composer(result.Value));
	}

	public static Result<K> Combine<T, K>(this IEnumerable<Result<T>> results, Func<IEnumerable<T>, K> composer, string errorMessageSeparator = null)
	{
		Result<IEnumerable<T>> result = results.Combine(errorMessageSeparator);
		if (!result.IsSuccess)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(composer(result.Value));
	}

	public static Result Compensate(this Result result, Func<string, Result> func)
	{
		if (result.IsSuccess)
		{
			return Result.Success();
		}
		return func(result.Error);
	}

	public static UnitResult<E> Compensate<E>(this Result result, Func<string, UnitResult<E>> func)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E>();
		}
		return func(result.Error);
	}

	public static Result Compensate<T>(this Result<T> result, Func<string, Result> func)
	{
		if (result.IsSuccess)
		{
			return Result.Success();
		}
		return func(result.Error);
	}

	public static Result<T> Compensate<T>(this Result<T> result, Func<string, Result<T>> func)
	{
		if (result.IsSuccess)
		{
			return Result.Success(result.Value);
		}
		return func(result.Error);
	}

	public static Result<T, E> Compensate<T, E>(this Result<T> result, Func<string, Result<T, E>> func)
	{
		if (result.IsSuccess)
		{
			return Result.Success<T, E>(result.Value);
		}
		return func(result.Error);
	}

	public static Result Compensate<E>(this UnitResult<E> result, Func<E, Result> func)
	{
		if (result.IsSuccess)
		{
			return Result.Success();
		}
		return func(result.Error);
	}

	public static UnitResult<E2> Compensate<E, E2>(this UnitResult<E> result, Func<E, UnitResult<E2>> func)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E2>();
		}
		return func(result.Error);
	}

	public static Result Compensate<T, E>(this Result<T, E> result, Func<E, Result> func)
	{
		if (result.IsSuccess)
		{
			return Result.Success();
		}
		return func(result.Error);
	}

	public static UnitResult<E2> Compensate<T, E, E2>(this Result<T, E> result, Func<E, UnitResult<E2>> func)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E2>();
		}
		return func(result.Error);
	}

	public static Result<T, E2> Compensate<T, E, E2>(this Result<T, E> result, Func<E, Result<T, E2>> func)
	{
		if (result.IsSuccess)
		{
			return Result.Success<T, E2>(result.Value);
		}
		return func(result.Error);
	}

	public static async Task<Result> Compensate(this Task<Result> resultTask, Func<string, Task<Result>> func)
	{
		return await (await resultTask.DefaultAwait()).Compensate(func).DefaultAwait();
	}

	public static async Task<UnitResult<E>> Compensate<E>(this Task<Result> resultTask, Func<string, Task<UnitResult<E>>> func)
	{
		return await (await resultTask.DefaultAwait()).Compensate(func).DefaultAwait();
	}

	public static async Task<Result> Compensate<T>(this Task<Result<T>> resultTask, Func<string, Task<Result>> func)
	{
		return await (await resultTask.DefaultAwait()).Compensate(func).DefaultAwait();
	}

	public static async Task<Result<T>> Compensate<T>(this Task<Result<T>> resultTask, Func<string, Task<Result<T>>> func)
	{
		return await (await resultTask.DefaultAwait()).Compensate(func).DefaultAwait();
	}

	public static async Task<Result<T, E>> Compensate<T, E>(this Task<Result<T>> resultTask, Func<string, Task<Result<T, E>>> func)
	{
		return await (await resultTask.DefaultAwait()).Compensate(func).DefaultAwait();
	}

	public static async Task<Result> Compensate<E>(this Task<UnitResult<E>> resultTask, Func<E, Task<Result>> func)
	{
		return await (await resultTask.DefaultAwait()).Compensate(func).DefaultAwait();
	}

	public static async Task<UnitResult<E2>> Compensate<E, E2>(this Task<UnitResult<E>> resultTask, Func<E, Task<UnitResult<E2>>> func)
	{
		return await (await resultTask.DefaultAwait()).Compensate(func).DefaultAwait();
	}

	public static async Task<Result> Compensate<T, E>(this Task<Result<T, E>> resultTask, Func<E, Task<Result>> func)
	{
		return await (await resultTask.DefaultAwait()).Compensate(func).DefaultAwait();
	}

	public static async Task<UnitResult<E2>> Compensate<T, E, E2>(this Task<Result<T, E>> resultTask, Func<E, Task<UnitResult<E2>>> func)
	{
		return await (await resultTask.DefaultAwait()).Compensate(func).DefaultAwait();
	}

	public static async Task<Result<T, E2>> Compensate<T, E, E2>(this Task<Result<T, E>> resultTask, Func<E, Task<Result<T, E2>>> func)
	{
		return await (await resultTask.DefaultAwait()).Compensate(func).DefaultAwait();
	}

	public static async Task<Result> Compensate(this Task<Result> resultTask, Func<string, Result> func)
	{
		return (await resultTask.DefaultAwait()).Compensate(func);
	}

	public static async Task<UnitResult<E>> Compensate<E>(this Task<Result> resultTask, Func<string, UnitResult<E>> func)
	{
		return (await resultTask.DefaultAwait()).Compensate(func);
	}

	public static async Task<Result> Compensate<T>(this Task<Result<T>> resultTask, Func<string, Result> func)
	{
		return (await resultTask.DefaultAwait()).Compensate(func);
	}

	public static async Task<Result<T>> Compensate<T>(this Task<Result<T>> resultTask, Func<string, Result<T>> func)
	{
		return (await resultTask.DefaultAwait()).Compensate(func);
	}

	public static async Task<Result<T, E>> Compensate<T, E>(this Task<Result<T>> resultTask, Func<string, Result<T, E>> func)
	{
		return (await resultTask.DefaultAwait()).Compensate(func);
	}

	public static async Task<Result> Compensate<E>(this Task<UnitResult<E>> resultTask, Func<E, Result> func)
	{
		return (await resultTask.DefaultAwait()).Compensate(func);
	}

	public static async Task<UnitResult<E2>> Compensate<E, E2>(this Task<UnitResult<E>> resultTask, Func<E, UnitResult<E2>> func)
	{
		return (await resultTask.DefaultAwait()).Compensate(func);
	}

	public static async Task<Result> Compensate<T, E>(this Task<Result<T, E>> resultTask, Func<E, Result> func)
	{
		return (await resultTask.DefaultAwait()).Compensate(func);
	}

	public static async Task<UnitResult<E2>> Compensate<T, E, E2>(this Task<Result<T, E>> resultTask, Func<E, UnitResult<E2>> func)
	{
		return (await resultTask.DefaultAwait()).Compensate(func);
	}

	public static async Task<Result<T, E2>> Compensate<T, E, E2>(this Task<Result<T, E>> resultTask, Func<E, Result<T, E2>> func)
	{
		return (await resultTask.DefaultAwait()).Compensate(func);
	}

	public static Task<Result> Compensate(this Result result, Func<string, Task<Result>> func)
	{
		if (result.IsSuccess)
		{
			return Result.Success().AsCompletedTask();
		}
		return func(result.Error);
	}

	public static Task<UnitResult<E>> Compensate<E>(this Result result, Func<string, Task<UnitResult<E>>> func)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E>().AsCompletedTask();
		}
		return func(result.Error);
	}

	public static Task<Result> Compensate<T>(this Result<T> result, Func<string, Task<Result>> func)
	{
		if (result.IsSuccess)
		{
			return Result.Success().AsCompletedTask();
		}
		return func(result.Error);
	}

	public static Task<Result<T>> Compensate<T>(this Result<T> result, Func<string, Task<Result<T>>> func)
	{
		if (result.IsSuccess)
		{
			return Result.Success(result.Value).AsCompletedTask();
		}
		return func(result.Error);
	}

	public static Task<Result<T, E>> Compensate<T, E>(this Result<T> result, Func<string, Task<Result<T, E>>> func)
	{
		if (result.IsSuccess)
		{
			return Result.Success<T, E>(result.Value).AsCompletedTask();
		}
		return func(result.Error);
	}

	public static Task<Result> Compensate<E>(this UnitResult<E> result, Func<E, Task<Result>> func)
	{
		if (result.IsSuccess)
		{
			return Result.Success().AsCompletedTask();
		}
		return func(result.Error);
	}

	public static Task<UnitResult<E2>> Compensate<E, E2>(this UnitResult<E> result, Func<E, Task<UnitResult<E2>>> func)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E2>().AsCompletedTask();
		}
		return func(result.Error);
	}

	public static Task<Result> Compensate<T, E>(this Result<T, E> result, Func<E, Task<Result>> func)
	{
		if (result.IsSuccess)
		{
			return Result.Success().AsCompletedTask();
		}
		return func(result.Error);
	}

	public static Task<UnitResult<E2>> Compensate<T, E, E2>(this Result<T, E> result, Func<E, Task<UnitResult<E2>>> func)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E2>().AsCompletedTask();
		}
		return func(result.Error);
	}

	public static Task<Result<T, E2>> Compensate<T, E, E2>(this Result<T, E> result, Func<E, Task<Result<T, E2>>> func)
	{
		if (result.IsSuccess)
		{
			return Result.Success<T, E2>(result.Value).AsCompletedTask();
		}
		return func(result.Error);
	}

	public static void Deconstruct(this Result result, out bool isSuccess, out bool isFailure)
	{
		isSuccess = result.IsSuccess;
		isFailure = result.IsFailure;
	}

	public static void Deconstruct(this Result result, out bool isSuccess, out bool isFailure, out string error)
	{
		isSuccess = result.IsSuccess;
		isFailure = result.IsFailure;
		error = (result.IsFailure ? result.Error : null);
	}

	public static void Deconstruct<T>(this Result<T> result, out bool isSuccess, out bool isFailure)
	{
		isSuccess = result.IsSuccess;
		isFailure = result.IsFailure;
	}

	public static void Deconstruct<T>(this Result<T> result, out bool isSuccess, out bool isFailure, out T value)
	{
		isSuccess = result.IsSuccess;
		isFailure = result.IsFailure;
		value = (result.IsSuccess ? result.Value : default(T));
	}

	public static void Deconstruct<T>(this Result<T> result, out bool isSuccess, out bool isFailure, out T value, out string error)
	{
		isSuccess = result.IsSuccess;
		isFailure = result.IsFailure;
		value = (result.IsSuccess ? result.Value : default(T));
		error = (result.IsFailure ? result.Error : null);
	}

	public static void Deconstruct<T, E>(this Result<T, E> result, out bool isSuccess, out bool isFailure)
	{
		isSuccess = result.IsSuccess;
		isFailure = result.IsFailure;
	}

	public static void Deconstruct<T, E>(this Result<T, E> result, out bool isSuccess, out bool isFailure, out T value)
	{
		isSuccess = result.IsSuccess;
		isFailure = result.IsFailure;
		value = (result.IsSuccess ? result.Value : default(T));
	}

	public static void Deconstruct<T, E>(this Result<T, E> result, out bool isSuccess, out bool isFailure, out T value, out E error)
	{
		isSuccess = result.IsSuccess;
		isFailure = result.IsFailure;
		value = (result.IsSuccess ? result.Value : default(T));
		error = (result.IsFailure ? result.Error : default(E));
	}

	public static Result<T, E> Ensure<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, E> errorPredicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		if (!predicate(result.Value))
		{
			return Result.Failure<T, E>(errorPredicate(result.Value));
		}
		return result;
	}

	public static Result<T, E> Ensure<T, E>(this Result<T, E> result, Func<T, bool> predicate, E error)
	{
		if (result.IsFailure)
		{
			return result;
		}
		if (!predicate(result.Value))
		{
			return Result.Failure<T, E>(error);
		}
		return result;
	}

	public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, string errorMessage)
	{
		if (result.IsFailure)
		{
			return result;
		}
		if (!predicate(result.Value))
		{
			return Result.Failure<T>(errorMessage);
		}
		return result;
	}

	public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, Func<T, string> errorPredicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		if (!predicate(result.Value))
		{
			return Result.Failure<T>(errorPredicate(result.Value));
		}
		return result;
	}

	public static Result Ensure(this Result result, Func<bool> predicate, string errorMessage)
	{
		if (result.IsFailure)
		{
			return result;
		}
		if (!predicate())
		{
			return Result.Failure(errorMessage);
		}
		return result;
	}

	public static Result Ensure(this Result result, Func<Result> predicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		Result result2 = predicate();
		if (result2.IsFailure)
		{
			return Result.Failure(result2.Error);
		}
		return result;
	}

	public static Result<T> Ensure<T>(this Result<T> result, Func<Result> predicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		Result result2 = predicate();
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static Result Ensure<T>(this Result result, Func<Result<T>> predicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		Result<T> result2 = predicate();
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static Result<T> Ensure<T>(this Result<T> result, Func<Result<T>> predicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		Result<T> result2 = predicate();
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static Result<T> Ensure<T>(this Result<T> result, Func<T, Result> predicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		Result result2 = predicate(result.Value);
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static Result<T> Ensure<T>(this Result<T> result, Func<T, Result<T>> predicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		Result<T> result2 = predicate(result.Value);
		if (result2.IsFailure)
		{
			return Result.Failure<T>(result2.Error);
		}
		return result;
	}

	public static UnitResult<E> Ensure<E>(this UnitResult<E> result, Func<bool> predicate, Func<E> errorPredicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		if (!predicate())
		{
			return UnitResult.Failure<E>(errorPredicate());
		}
		return result;
	}

	public static UnitResult<E> Ensure<E>(this UnitResult<E> result, Func<bool> predicate, E error)
	{
		if (result.IsFailure)
		{
			return result;
		}
		if (!predicate())
		{
			return UnitResult.Failure(in error);
		}
		return result;
	}

	public static UnitResult<E> Ensure<E>(this UnitResult<E> result, Func<UnitResult<E>> predicate)
	{
		if (result.IsFailure)
		{
			return result;
		}
		UnitResult<E> unitResult = predicate();
		if (unitResult.IsFailure)
		{
			return UnitResult.Failure<E>(unitResult.Error);
		}
		return result;
	}

	public static Result<T> EnsureNot<T>(this Result<T> result, Func<T, bool> test, string error)
	{
		return result.Ensure((T v) => !test(v), error);
	}

	public static Result<T, E> EnsureNot<T, E>(this Result<T, E> result, Func<T, bool> test, E error)
	{
		return result.Ensure((T v) => !test(v), error);
	}

	public static Result<T> EnsureNotNull<T>(this Result<T?> result, string error) where T : class
	{
		return result.Ensure<T>((T value) => value != null, error).Map((T value) => value);
	}

	public static Result<T> EnsureNotNull<T>(this Result<T?> result, string error) where T : struct
	{
		return result.Ensure((T? value) => value.HasValue, error).Map((T? value) => value.Value);
	}

	public static Result<T> EnsureNotNull<T>(this Result<T?> result, Func<string> errorFactory) where T : class
	{
		return result.Ensure<T>((T value) => value != null, (T _) => errorFactory()).Map((T value) => value);
	}

	public static Result<T> EnsureNotNull<T>(this Result<T?> result, Func<string> errorFactory) where T : struct
	{
		return result.Ensure((T? value) => value.HasValue, (T? _) => errorFactory()).Map((T? value) => value.Value);
	}

	public static Result<T, E> EnsureNotNull<T, E>(this Result<T?, E> result, E error) where T : class
	{
		return result.Ensure<T, E>((T value) => value != null, error).Map((T value) => value);
	}

	public static Result<T, E> EnsureNotNull<T, E>(this Result<T?, E> result, E error) where T : struct
	{
		return result.Ensure((T? value) => value.HasValue, error).Map((T? value) => value.Value);
	}

	public static Result<T, E> EnsureNotNull<T, E>(this Result<T?, E> result, Func<E> errorFactory) where T : class
	{
		return result.Ensure<T, E>((T value) => value != null, (T _) => errorFactory()).Map((T value) => value);
	}

	public static Result<T, E> EnsureNotNull<T, E>(this Result<T?, E> result, Func<E> errorFactory) where T : struct
	{
		return result.Ensure((T? value) => value.HasValue, (T? _) => errorFactory()).Map((T? value) => value.Value);
	}

	public static Task<Result<T>> EnsureNotNull<T>(this Task<Result<T?>> resultTask, string error) where T : class
	{
		return resultTask.Ensure<T>((T value) => value != null, error).Map((T value) => value);
	}

	public static Task<Result<T>> EnsureNotNull<T>(this Task<Result<T?>> resultTask, string error) where T : struct
	{
		return resultTask.Ensure((T? value) => value.HasValue, error).Map((T? value) => value.Value);
	}

	public static Task<Result<T>> EnsureNotNull<T>(this Task<Result<T?>> resultTask, Func<Task<string>> errorFactory) where T : class
	{
		return resultTask.Ensure<T>((T value) => value != null, (T _) => errorFactory()).Map((T value) => value);
	}

	public static Task<Result<T>> EnsureNotNull<T>(this Task<Result<T?>> resultTask, Func<Task<string>> errorFactory) where T : struct
	{
		return resultTask.Ensure((T? value) => value.HasValue, (T? _) => errorFactory()).Map((T? value) => value.Value);
	}

	public static Task<Result<T, E>> EnsureNotNull<T, E>(this Task<Result<T?, E>> resultTask, E error) where T : class
	{
		return resultTask.Ensure<T, E>((T value) => value != null, error).Map((T value) => value);
	}

	public static Task<Result<T, E>> EnsureNotNull<T, E>(this Task<Result<T?, E>> resultTask, E error) where T : struct
	{
		return resultTask.Ensure((T? value) => value.HasValue, error).Map((T? value) => value.Value);
	}

	public static Task<Result<T, E>> EnsureNotNull<T, E>(this Task<Result<T?, E>> resultTask, Func<Task<E>> errorFactory) where T : class
	{
		return resultTask.Ensure<T, E>((T value) => Task.FromResult(value != null), (T _) => errorFactory()).Map((T value) => value);
	}

	public static Task<Result<T, E>> EnsureNotNull<T, E>(this Task<Result<T?, E>> resultTask, Func<Task<E>> errorFactory) where T : struct
	{
		return resultTask.Ensure<T?, E>((T? value) => Task.FromResult(value.HasValue), (T? _) => errorFactory()).Map((T? value) => value.Value);
	}

	public static Task<Result<T>> EnsureNotNull<T>(this Task<Result<T?>> resultTask, Func<string> errorFactory) where T : class
	{
		return resultTask.Ensure<T>((T value) => value != null, (T _) => errorFactory()).Map((T value) => value);
	}

	public static Task<Result<T>> EnsureNotNull<T>(this Task<Result<T?>> resultTask, Func<string> errorFactory) where T : struct
	{
		return resultTask.Ensure((T? value) => value.HasValue, (T? _) => errorFactory()).Map((T? value) => value.Value);
	}

	public static Task<Result<T, E>> EnsureNotNull<T, E>(this Task<Result<T?, E>> resultTask, Func<E> errorFactory) where T : class
	{
		return resultTask.Ensure<T, E>((T value) => Task.FromResult(value != null), (T _) => errorFactory()).Map((T value) => value);
	}

	public static Task<Result<T, E>> EnsureNotNull<T, E>(this Task<Result<T?, E>> resultTask, Func<E> errorFactory) where T : struct
	{
		return resultTask.Ensure((T? value) => Task.FromResult(value.HasValue), (T? _) => errorFactory()).Map((T? value) => value.Value);
	}

	public static Task<Result<T>> EnsureNotNull<T>(this Result<T?> result, Func<Task<string>> errorFactory) where T : class
	{
		return result.Ensure<T>((T value) => Task.FromResult(value != null), (T _) => errorFactory()).Map((T value) => value);
	}

	public static Task<Result<T>> EnsureNotNull<T>(this Result<T?> result, Func<Task<string>> errorFactory) where T : struct
	{
		return result.Ensure((T? value) => Task.FromResult(value.HasValue), (T? _) => errorFactory()).Map((T? value) => value.Value);
	}

	public static Task<Result<T, E>> EnsureNotNull<T, E>(this Result<T?, E> result, Func<Task<E>> errorFactory) where T : class
	{
		return result.Ensure<T, E>((T value) => Task.FromResult(value != null), (T _) => errorFactory()).Map((T value) => value);
	}

	public static Task<Result<T, E>> EnsureNotNull<T, E>(this Result<T?, E> result, Func<Task<E>> errorFactory) where T : struct
	{
		return result.Ensure<T?, E>((T? value) => Task.FromResult(value.HasValue), (T? _) => errorFactory()).Map((T? value) => value.Value);
	}

	public static T Finally<T>(this Result result, Func<Result, T> func)
	{
		return func(result);
	}

	public static K Finally<T, K>(this Result<T> result, Func<Result<T>, K> func)
	{
		return func(result);
	}

	public static K Finally<K, E>(this UnitResult<E> result, Func<UnitResult<E>, K> func)
	{
		return func(result);
	}

	public static K Finally<T, K, E>(this Result<T, E> result, Func<Result<T, E>, K> func)
	{
		return func(result);
	}

	public static T GetValueOrDefault<T>(this in Result<T> result, Func<T> defaultValue)
	{
		if (result.IsFailure)
		{
			return defaultValue();
		}
		return result.Value;
	}

	public static K GetValueOrDefault<T, K>(this in Result<T> result, Func<T, K> selector, K defaultValue = default(K))
	{
		if (result.IsFailure)
		{
			return defaultValue;
		}
		return selector(result.Value);
	}

	public static K GetValueOrDefault<T, K>(this in Result<T> result, Func<T, K> selector, Func<K> defaultValue)
	{
		if (result.IsFailure)
		{
			return defaultValue();
		}
		return selector(result.Value);
	}

	public static async Task<T> GetValueOrDefault<T>(this Task<Result<T>> resultTask, Func<Task<T>> defaultValue)
	{
		return await (await resultTask.DefaultAwait()).GetValueOrDefault(defaultValue).DefaultAwait();
	}

	public static async Task<K> GetValueOrDefault<T, K>(this Task<Result<T>> resultTask, Func<T, Task<K>> selector, K defaultValue = default(K))
	{
		return await (await resultTask.DefaultAwait()).GetValueOrDefault(selector, defaultValue).DefaultAwait();
	}

	public static async Task<K> GetValueOrDefault<T, K>(this Task<Result<T>> resultTask, Func<T, Task<K>> selector, Func<Task<K>> defaultValue)
	{
		return await (await resultTask.DefaultAwait()).GetValueOrDefault(selector, defaultValue).DefaultAwait();
	}

	public static async Task<T> GetValueOrDefault<T>(this Task<Result<T>> resultTask, Func<T> defaultValue)
	{
		return (await resultTask.DefaultAwait()).GetValueOrDefault(defaultValue);
	}

	public static async Task<K> GetValueOrDefault<T, K>(this Task<Result<T>> resultTask, Func<T, K> selector, K defaultValue = default(K))
	{
		return (await resultTask.DefaultAwait()).GetValueOrDefault(selector, defaultValue);
	}

	public static async Task<K> GetValueOrDefault<T, K>(this Task<Result<T>> resultTask, Func<T, K> selector, Func<K> defaultValue)
	{
		return (await resultTask.DefaultAwait()).GetValueOrDefault(selector, defaultValue);
	}

	public static async Task<T> GetValueOrDefault<T>(this Result<T> result, Func<Task<T>> defaultValue)
	{
		if (result.IsFailure)
		{
			return await defaultValue().DefaultAwait();
		}
		return result.Value;
	}

	public static async Task<K> GetValueOrDefault<T, K>(this Result<T> result, Func<T, K> selector, Func<Task<K>> defaultValue)
	{
		if (result.IsFailure)
		{
			return await defaultValue().DefaultAwait();
		}
		return selector(result.Value);
	}

	public static async Task<K> GetValueOrDefault<T, K>(this Result<T> result, Func<T, Task<K>> selector, K defaultValue = default(K))
	{
		if (result.IsFailure)
		{
			return defaultValue;
		}
		return await selector(result.Value).DefaultAwait();
	}

	public static async Task<K> GetValueOrDefault<T, K>(this Result<T> result, Func<T, Task<K>> selector, Func<Task<K>> defaultValue)
	{
		if (result.IsFailure)
		{
			return await defaultValue().DefaultAwait();
		}
		return await selector(result.Value).DefaultAwait();
	}

	public static Result<K, E> Map<T, K, E>(this Result<T, E> result, Func<T, K> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(func(result.Value));
	}

	public static Result<K, E> Map<T, K, E, TContext>(this Result<T, E> result, Func<T, TContext, K> func, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(func(result.Value, context));
	}

	public static Result<K, E> Map<K, E>(this UnitResult<E> result, Func<K> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(func());
	}

	public static Result<K, E> Map<K, E, TContext>(this UnitResult<E> result, Func<TContext, K> func, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K, E>(result.Error);
		}
		return Result.Success<K, E>(func(context));
	}

	public static Result<K> Map<T, K>(this Result<T> result, Func<T, K> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(func(result.Value));
	}

	public static Result<K> Map<T, K, TContext>(this Result<T> result, Func<T, TContext, K> func, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(func(result.Value, context));
	}

	public static Result<K> Map<K>(this Result result, Func<K> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(func());
	}

	public static Result<K> Map<K, TContext>(this Result result, Func<TContext, K> func, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<K>(result.Error);
		}
		return Result.Success(func(context));
	}

	public static Result<Maybe<K>> Map<T, K>(this Result<Maybe<T>> result, Func<T, K> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<Maybe<K>>(result.Error);
		}
		return Result.Success(result.Value.Map(func));
	}

	public static Result<Maybe<K>, E> Map<T, K, E>(this Result<Maybe<T>, E> result, Func<T, K> func)
	{
		if (result.IsFailure)
		{
			return Result.Failure<Maybe<K>, E>(result.Error);
		}
		return Result.Success<Maybe<K>, E>(result.Value.Map(func));
	}

	public static Result MapError(this Result result, Func<string, string> errorFactory)
	{
		if (result.IsFailure)
		{
			return Result.Failure(errorFactory(result.Error));
		}
		return Result.Success();
	}

	public static Result MapError<TContext>(this Result result, Func<string, TContext, string> errorFactory, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure(errorFactory(result.Error, context));
		}
		return Result.Success();
	}

	public static UnitResult<E> MapError<E>(this Result result, Func<string, E> errorFactory)
	{
		if (result.IsFailure)
		{
			return UnitResult.Failure<E>(errorFactory(result.Error));
		}
		return UnitResult.Success<E>();
	}

	public static UnitResult<E> MapError<E, TContext>(this Result result, Func<string, TContext, E> errorFactory, TContext context)
	{
		if (result.IsFailure)
		{
			return UnitResult.Failure<E>(errorFactory(result.Error, context));
		}
		return UnitResult.Success<E>();
	}

	public static Result<T> MapError<T>(this Result<T> result, Func<string, string> errorFactory)
	{
		if (result.IsFailure)
		{
			return Result.Failure<T>(errorFactory(result.Error));
		}
		return Result.Success(result.Value);
	}

	public static Result<T> MapError<T, TContext>(this Result<T> result, Func<string, TContext, string> errorFactory, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<T>(errorFactory(result.Error, context));
		}
		return Result.Success(result.Value);
	}

	public static Result<T, E> MapError<T, E>(this Result<T> result, Func<string, E> errorFactory)
	{
		if (result.IsFailure)
		{
			return Result.Failure<T, E>(errorFactory(result.Error));
		}
		return Result.Success<T, E>(result.Value);
	}

	public static Result<T, E> MapError<T, E, TContext>(this Result<T> result, Func<string, TContext, E> errorFactory, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<T, E>(errorFactory(result.Error, context));
		}
		return Result.Success<T, E>(result.Value);
	}

	public static Result MapError<E>(this UnitResult<E> result, Func<E, string> errorFactory)
	{
		if (result.IsFailure)
		{
			return Result.Failure(errorFactory(result.Error));
		}
		return Result.Success();
	}

	public static Result MapError<E, TContext>(this UnitResult<E> result, Func<E, TContext, string> errorFactory, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure(errorFactory(result.Error, context));
		}
		return Result.Success();
	}

	public static UnitResult<E2> MapError<E, E2>(this UnitResult<E> result, Func<E, E2> errorFactory)
	{
		if (result.IsFailure)
		{
			return UnitResult.Failure<E2>(errorFactory(result.Error));
		}
		return UnitResult.Success<E2>();
	}

	public static UnitResult<E2> MapError<E, E2, TContext>(this UnitResult<E> result, Func<E, TContext, E2> errorFactory, TContext context)
	{
		if (result.IsFailure)
		{
			return UnitResult.Failure<E2>(errorFactory(result.Error, context));
		}
		return UnitResult.Success<E2>();
	}

	public static Result<T> MapError<T, E>(this Result<T, E> result, Func<E, string> errorFactory)
	{
		if (result.IsFailure)
		{
			return Result.Failure<T>(errorFactory(result.Error));
		}
		return Result.Success(result.Value);
	}

	public static Result<T> MapError<T, E, TContext>(this Result<T, E> result, Func<E, TContext, string> errorFactory, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<T>(errorFactory(result.Error, context));
		}
		return Result.Success(result.Value);
	}

	public static Result<T, E2> MapError<T, E, E2>(this Result<T, E> result, Func<E, E2> errorFactory)
	{
		if (result.IsFailure)
		{
			return Result.Failure<T, E2>(errorFactory(result.Error));
		}
		return Result.Success<T, E2>(result.Value);
	}

	public static Result<T, E2> MapError<T, E, E2, TContext>(this Result<T, E> result, Func<E, TContext, E2> errorFactory, TContext context)
	{
		if (result.IsFailure)
		{
			return Result.Failure<T, E2>(errorFactory(result.Error, context));
		}
		return Result.Success<T, E2>(result.Value);
	}

	public static async Task<Result> MapError(this Task<Result> resultTask, Func<string, Task<string>> errorFactory)
	{
		return await (await resultTask.DefaultAwait()).MapError(errorFactory).DefaultAwait();
	}

	public static async Task<Result> MapError<TContext>(this Task<Result> resultTask, Func<string, TContext, Task<string>> errorFactory, TContext context)
	{
		return await (await resultTask.DefaultAwait()).MapError(errorFactory, context).DefaultAwait();
	}

	public static async Task<UnitResult<E>> MapError<E>(this Task<Result> resultTask, Func<string, Task<E>> errorFactory)
	{
		return await (await resultTask.DefaultAwait()).MapError(errorFactory).DefaultAwait();
	}

	public static async Task<UnitResult<E>> MapError<E, TContext>(this Task<Result> resultTask, Func<string, TContext, Task<E>> errorFactory, TContext context)
	{
		return await (await resultTask.DefaultAwait()).MapError(errorFactory, context).DefaultAwait();
	}

	public static async Task<Result<T>> MapError<T>(this Task<Result<T>> resultTask, Func<string, Task<string>> errorFactory)
	{
		return await (await resultTask.DefaultAwait()).MapError(errorFactory).DefaultAwait();
	}

	public static async Task<Result<T>> MapError<T, TContext>(this Task<Result<T>> resultTask, Func<string, TContext, Task<string>> errorFactory, TContext context)
	{
		return await (await resultTask.DefaultAwait()).MapError(errorFactory, context).DefaultAwait();
	}

	public static async Task<Result<T, E>> MapError<T, E>(this Task<Result<T>> resultTask, Func<string, Task<E>> errorFactory)
	{
		return await (await resultTask.DefaultAwait()).MapError(errorFactory).DefaultAwait();
	}

	public static async Task<Result<T, E>> MapError<T, E, TContext>(this Task<Result<T>> resultTask, Func<string, TContext, Task<E>> errorFactory, TContext context)
	{
		return await (await resultTask.DefaultAwait()).MapError(errorFactory, context).DefaultAwait();
	}

	public static async Task<Result> MapError<E>(this Task<UnitResult<E>> resultTask, Func<E, Task<string>> errorFactory)
	{
		return await (await resultTask.DefaultAwait()).MapError(errorFactory).DefaultAwait();
	}

	public static async Task<Result> MapError<E, TContext>(this Task<UnitResult<E>> resultTask, Func<E, TContext, Task<string>> errorFactory, TContext context)
	{
		return await (await resultTask.DefaultAwait()).MapError(errorFactory, context).DefaultAwait();
	}

	public static async Task<UnitResult<E2>> MapError<E, E2>(this Task<UnitResult<E>> resultTask, Func<E, Task<E2>> errorFactory)
	{
		return await (await resultTask.DefaultAwait()).MapError(errorFactory).DefaultAwait();
	}

	public static async Task<UnitResult<E2>> MapError<E, E2, TContext>(this Task<UnitResult<E>> resultTask, Func<E, TContext, Task<E2>> errorFactory, TContext context)
	{
		return await (await resultTask.DefaultAwait()).MapError(errorFactory, context).DefaultAwait();
	}

	public static async Task<Result<T>> MapError<T, E>(this Task<Result<T, E>> resultTask, Func<E, Task<string>> errorFactory)
	{
		return await (await resultTask.DefaultAwait()).MapError(errorFactory).DefaultAwait();
	}

	public static async Task<Result<T>> MapError<T, E, TContext>(this Task<Result<T, E>> resultTask, Func<E, TContext, Task<string>> errorFactory, TContext context)
	{
		return await (await resultTask.DefaultAwait()).MapError(errorFactory, context).DefaultAwait();
	}

	public static async Task<Result<T, E2>> MapError<T, E, E2>(this Task<Result<T, E>> resultTask, Func<E, Task<E2>> errorFactory)
	{
		return await (await resultTask.DefaultAwait()).MapError(errorFactory).DefaultAwait();
	}

	public static async Task<Result<T, E2>> MapError<T, E, E2, TContext>(this Task<Result<T, E>> resultTask, Func<E, TContext, Task<E2>> errorFactory, TContext context)
	{
		return await (await resultTask.DefaultAwait()).MapError(errorFactory, context).DefaultAwait();
	}

	public static async Task<Result> MapError(this Task<Result> resultTask, Func<string, string> errorFactory)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			return Result.Success();
		}
		return Result.Failure(errorFactory(result.Error));
	}

	public static async Task<Result> MapError<TContext>(this Task<Result> resultTask, Func<string, TContext, string> errorFactory, TContext context)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			return Result.Success();
		}
		return Result.Failure(errorFactory(result.Error, context));
	}

	public static async Task<UnitResult<E>> MapError<E>(this Task<Result> resultTask, Func<string, E> errorFactory)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			return UnitResult.Success<E>();
		}
		return UnitResult.Failure<E>(errorFactory(result.Error));
	}

	public static async Task<UnitResult<E>> MapError<E, TContext>(this Task<Result> resultTask, Func<string, TContext, E> errorFactory, TContext context)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			return UnitResult.Success<E>();
		}
		return UnitResult.Failure<E>(errorFactory(result.Error, context));
	}

	public static async Task<Result<T>> MapError<T>(this Task<Result<T>> resultTask, Func<string, string> errorFactory)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			return Result.Success(result.Value);
		}
		return Result.Failure<T>(errorFactory(result.Error));
	}

	public static async Task<Result<T>> MapError<T, TContext>(this Task<Result<T>> resultTask, Func<string, TContext, string> errorFactory, TContext context)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			return Result.Success(result.Value);
		}
		return Result.Failure<T>(errorFactory(result.Error, context));
	}

	public static async Task<Result<T, E>> MapError<T, E>(this Task<Result<T>> resultTask, Func<string, E> errorFactory)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			return Result.Success<T, E>(result.Value);
		}
		return Result.Failure<T, E>(errorFactory(result.Error));
	}

	public static async Task<Result<T, E>> MapError<T, E, TContext>(this Task<Result<T>> resultTask, Func<string, TContext, E> errorFactory, TContext context)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			return Result.Success<T, E>(result.Value);
		}
		return Result.Failure<T, E>(errorFactory(result.Error, context));
	}

	public static async Task<Result> MapError<E>(this Task<UnitResult<E>> resultTask, Func<E, string> errorFactory)
	{
		UnitResult<E> unitResult = await resultTask.DefaultAwait();
		if (unitResult.IsSuccess)
		{
			return Result.Success();
		}
		return Result.Failure(errorFactory(unitResult.Error));
	}

	public static async Task<Result> MapError<E, TContext>(this Task<UnitResult<E>> resultTask, Func<E, TContext, string> errorFactory, TContext context)
	{
		UnitResult<E> unitResult = await resultTask.DefaultAwait();
		if (unitResult.IsSuccess)
		{
			return Result.Success();
		}
		return Result.Failure(errorFactory(unitResult.Error, context));
	}

	public static async Task<UnitResult<E2>> MapError<E, E2>(this Task<UnitResult<E>> resultTask, Func<E, E2> errorFactory)
	{
		UnitResult<E> unitResult = await resultTask.DefaultAwait();
		if (unitResult.IsSuccess)
		{
			return UnitResult.Success<E2>();
		}
		return UnitResult.Failure<E2>(errorFactory(unitResult.Error));
	}

	public static async Task<UnitResult<E2>> MapError<E, E2, TContext>(this Task<UnitResult<E>> resultTask, Func<E, TContext, E2> errorFactory, TContext context)
	{
		UnitResult<E> unitResult = await resultTask.DefaultAwait();
		if (unitResult.IsSuccess)
		{
			return UnitResult.Success<E2>();
		}
		return UnitResult.Failure<E2>(errorFactory(unitResult.Error, context));
	}

	public static async Task<Result<T>> MapError<T, E>(this Task<Result<T, E>> resultTask, Func<E, string> errorFactory)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			return Result.Success(result.Value);
		}
		return Result.Failure<T>(errorFactory(result.Error));
	}

	public static async Task<Result<T>> MapError<T, E, TContext>(this Task<Result<T, E>> resultTask, Func<E, TContext, string> errorFactory, TContext context)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			return Result.Success(result.Value);
		}
		return Result.Failure<T>(errorFactory(result.Error, context));
	}

	public static async Task<Result<T, E2>> MapError<T, E, E2>(this Task<Result<T, E>> resultTask, Func<E, E2> errorFactory)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			return Result.Success<T, E2>(result.Value);
		}
		return Result.Failure<T, E2>(errorFactory(result.Error));
	}

	public static async Task<Result<T, E2>> MapError<T, E, E2, TContext>(this Task<Result<T, E>> resultTask, Func<E, TContext, E2> errorFactory, TContext context)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsSuccess)
		{
			return Result.Success<T, E2>(result.Value);
		}
		return Result.Failure<T, E2>(errorFactory(result.Error, context));
	}

	public static async Task<Result> MapError(this Result result, Func<string, Task<string>> errorFactory)
	{
		if (result.IsSuccess)
		{
			return Result.Success();
		}
		return Result.Failure(await errorFactory(result.Error).DefaultAwait());
	}

	public static async Task<Result> MapError<TContext>(this Result result, Func<string, TContext, Task<string>> errorFactory, TContext context)
	{
		if (result.IsSuccess)
		{
			return Result.Success();
		}
		return Result.Failure(await errorFactory(result.Error, context).DefaultAwait());
	}

	public static async Task<UnitResult<E>> MapError<E>(this Result result, Func<string, Task<E>> errorFactory)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E>();
		}
		return UnitResult.Failure<E>(await errorFactory(result.Error).DefaultAwait());
	}

	public static async Task<UnitResult<E>> MapError<E, TContext>(this Result result, Func<string, TContext, Task<E>> errorFactory, TContext context)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E>();
		}
		return UnitResult.Failure<E>(await errorFactory(result.Error, context).DefaultAwait());
	}

	public static async Task<Result<T>> MapError<T>(this Result<T> result, Func<string, Task<string>> errorFactory)
	{
		if (result.IsSuccess)
		{
			return Result.Success(result.Value);
		}
		return Result.Failure<T>(await errorFactory(result.Error).DefaultAwait());
	}

	public static async Task<Result<T>> MapError<T, TContext>(this Result<T> result, Func<string, TContext, Task<string>> errorFactory, TContext context)
	{
		if (result.IsSuccess)
		{
			return Result.Success(result.Value);
		}
		return Result.Failure<T>(await errorFactory(result.Error, context).DefaultAwait());
	}

	public static async Task<Result<T, E>> MapError<T, E>(this Result<T> result, Func<string, Task<E>> errorFactory)
	{
		if (result.IsSuccess)
		{
			return Result.Success<T, E>(result.Value);
		}
		return Result.Failure<T, E>(await errorFactory(result.Error).DefaultAwait());
	}

	public static async Task<Result<T, E>> MapError<T, E, TContext>(this Result<T> result, Func<string, TContext, Task<E>> errorFactory, TContext context)
	{
		if (result.IsSuccess)
		{
			return Result.Success<T, E>(result.Value);
		}
		return Result.Failure<T, E>(await errorFactory(result.Error, context).DefaultAwait());
	}

	public static async Task<Result> MapError<E>(this UnitResult<E> result, Func<E, Task<string>> errorFactory)
	{
		if (result.IsSuccess)
		{
			return Result.Success();
		}
		return Result.Failure(await errorFactory(result.Error).DefaultAwait());
	}

	public static async Task<Result> MapError<E, TContext>(this UnitResult<E> result, Func<E, TContext, Task<string>> errorFactory, TContext context)
	{
		if (result.IsSuccess)
		{
			return Result.Success();
		}
		return Result.Failure(await errorFactory(result.Error, context).DefaultAwait());
	}

	public static async Task<UnitResult<E2>> MapError<E, E2>(this UnitResult<E> result, Func<E, Task<E2>> errorFactory)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E2>();
		}
		return UnitResult.Failure<E2>(await errorFactory(result.Error).DefaultAwait());
	}

	public static async Task<UnitResult<E2>> MapError<E, E2, TContext>(this UnitResult<E> result, Func<E, TContext, Task<E2>> errorFactory, TContext context)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E2>();
		}
		return UnitResult.Failure<E2>(await errorFactory(result.Error, context).DefaultAwait());
	}

	public static async Task<Result<T>> MapError<T, E>(this Result<T, E> result, Func<E, Task<string>> errorFactory)
	{
		if (result.IsSuccess)
		{
			return Result.Success(result.Value);
		}
		return Result.Failure<T>(await errorFactory(result.Error).DefaultAwait());
	}

	public static async Task<Result<T>> MapError<T, E, TContext>(this Result<T, E> result, Func<E, TContext, Task<string>> errorFactory, TContext context)
	{
		if (result.IsSuccess)
		{
			return Result.Success(result.Value);
		}
		return Result.Failure<T>(await errorFactory(result.Error, context).DefaultAwait());
	}

	public static async Task<Result<T, E2>> MapError<T, E, E2>(this Result<T, E> result, Func<E, Task<E2>> errorFactory)
	{
		if (result.IsSuccess)
		{
			return Result.Success<T, E2>(result.Value);
		}
		return Result.Failure<T, E2>(await errorFactory(result.Error).DefaultAwait());
	}

	public static async Task<Result<T, E2>> MapError<T, E, E2, TContext>(this Result<T, E> result, Func<E, TContext, Task<E2>> errorFactory, TContext context)
	{
		if (result.IsSuccess)
		{
			return Result.Success<T, E2>(result.Value);
		}
		return Result.Failure<T, E2>(await errorFactory(result.Error, context).DefaultAwait());
	}

	public static Result<T> MapIf<T>(this Result<T> result, bool condition, Func<T, T> func)
	{
		if (!condition)
		{
			return result;
		}
		return result.Map(func);
	}

	public static Result<T> MapIf<T, TContext>(this Result<T> result, bool condition, Func<T, TContext, T> func, TContext context)
	{
		if (!condition)
		{
			return result;
		}
		return result.Map(func, context);
	}

	public static Result<T, E> MapIf<T, E>(this Result<T, E> result, bool condition, Func<T, T> func)
	{
		if (!condition)
		{
			return result;
		}
		return result.Map(func);
	}

	public static Result<T, E> MapIf<T, E, TContext>(this Result<T, E> result, bool condition, Func<T, TContext, T> func, TContext context)
	{
		if (!condition)
		{
			return result;
		}
		return result.Map(func, context);
	}

	public static Result<T> MapIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, T> func)
	{
		if (!result.IsSuccess || !predicate(result.Value))
		{
			return result;
		}
		return result.Map(func);
	}

	public static Result<T> MapIf<T, TContext>(this Result<T> result, Func<T, TContext, bool> predicate, Func<T, TContext, T> func, TContext context)
	{
		if (!result.IsSuccess || !predicate(result.Value, context))
		{
			return result;
		}
		return result.Map(func, context);
	}

	public static Result<T, E> MapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, T> func)
	{
		if (!result.IsSuccess || !predicate(result.Value))
		{
			return result;
		}
		return result.Map(func);
	}

	public static Result<T, E> MapIf<T, E, TContext>(this Result<T, E> result, Func<T, TContext, bool> predicate, Func<T, TContext, T> func, TContext context)
	{
		if (!result.IsSuccess || !predicate(result.Value, context))
		{
			return result;
		}
		return result.Map(func, context);
	}

	public static async Task<Result<T>> MapIf<T>(this Task<Result<T>> resultTask, bool condition, Func<T, Task<T>> func)
	{
		return await (await resultTask.DefaultAwait()).MapIf(condition, func).DefaultAwait();
	}

	public static async Task<Result<T>> MapIf<T, TContext>(this Task<Result<T>> resultTask, bool condition, Func<T, TContext, Task<T>> func, TContext context)
	{
		return await (await resultTask.DefaultAwait()).MapIf(condition, func, context).DefaultAwait();
	}

	public static async Task<Result<T, E>> MapIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, Task<T>> func)
	{
		return await (await resultTask.DefaultAwait()).MapIf(condition, func).DefaultAwait();
	}

	public static async Task<Result<T, E>> MapIf<T, E, TContext>(this Task<Result<T, E>> resultTask, bool condition, Func<T, TContext, Task<T>> func, TContext context)
	{
		return await (await resultTask.DefaultAwait()).MapIf(condition, func, context).DefaultAwait();
	}

	public static async Task<Result<T>> MapIf<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, Task<T>> func)
	{
		return await (await resultTask.DefaultAwait()).MapIf(predicate, func).DefaultAwait();
	}

	public static async Task<Result<T>> MapIf<T, TContext>(this Task<Result<T>> resultTask, Func<T, TContext, bool> predicate, Func<T, TContext, Task<T>> func, TContext context)
	{
		return await (await resultTask.DefaultAwait()).MapIf(predicate, func, context).DefaultAwait();
	}

	public static async Task<Result<T, E>> MapIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, Task<T>> func)
	{
		return await (await resultTask.DefaultAwait()).MapIf(predicate, func).DefaultAwait();
	}

	public static async Task<Result<T, E>> MapIf<T, E, TContext>(this Task<Result<T, E>> resultTask, Func<T, TContext, bool> predicate, Func<T, TContext, Task<T>> func, TContext context)
	{
		return await (await resultTask.DefaultAwait()).MapIf(predicate, func, context).DefaultAwait();
	}

	public static async Task<Result<T>> MapIf<T>(this Task<Result<T>> resultTask, bool condition, Func<T, T> func)
	{
		return (await resultTask.DefaultAwait()).MapIf(condition, func);
	}

	public static async Task<Result<T>> MapIf<T, TContext>(this Task<Result<T>> resultTask, bool condition, Func<T, TContext, T> func, TContext context)
	{
		return (await resultTask.DefaultAwait()).MapIf(condition, func, context);
	}

	public static async Task<Result<T, E>> MapIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<T, T> func)
	{
		return (await resultTask.DefaultAwait()).MapIf(condition, func);
	}

	public static async Task<Result<T, E>> MapIf<T, E, TContext>(this Task<Result<T, E>> resultTask, bool condition, Func<T, TContext, T> func, TContext context)
	{
		return (await resultTask.DefaultAwait()).MapIf(condition, func, context);
	}

	public static async Task<Result<T>> MapIf<T>(this Task<Result<T>> resultTask, Func<T, bool> predicate, Func<T, T> func)
	{
		return (await resultTask.DefaultAwait()).MapIf(predicate, func);
	}

	public static async Task<Result<T>> MapIf<T, TContext>(this Task<Result<T>> resultTask, Func<T, TContext, bool> predicate, Func<T, TContext, T> func, TContext context)
	{
		return (await resultTask.DefaultAwait()).MapIf(predicate, func, context);
	}

	public static async Task<Result<T, E>> MapIf<T, E>(this Task<Result<T, E>> resultTask, Func<T, bool> predicate, Func<T, T> func)
	{
		return (await resultTask.DefaultAwait()).MapIf(predicate, func);
	}

	public static async Task<Result<T, E>> MapIf<T, E, TContext>(this Task<Result<T, E>> resultTask, Func<T, TContext, bool> predicate, Func<T, TContext, T> func, TContext context)
	{
		return (await resultTask.DefaultAwait()).MapIf(predicate, func, context);
	}

	public static Task<Result<T>> MapIf<T>(this Result<T> result, bool condition, Func<T, Task<T>> func)
	{
		if (!condition)
		{
			return result.AsCompletedTask();
		}
		return result.Map(func);
	}

	public static Task<Result<T>> MapIf<T, TContext>(this Result<T> result, bool condition, Func<T, TContext, Task<T>> func, TContext context)
	{
		if (!condition)
		{
			return result.AsCompletedTask();
		}
		return result.Map(func, context);
	}

	public static Task<Result<T, E>> MapIf<T, E>(this Result<T, E> result, bool condition, Func<T, Task<T>> func)
	{
		if (!condition)
		{
			return result.AsCompletedTask();
		}
		return result.Map(func);
	}

	public static Task<Result<T, E>> MapIf<T, E, TContext>(this Result<T, E> result, bool condition, Func<T, TContext, Task<T>> func, TContext context)
	{
		if (!condition)
		{
			return result.AsCompletedTask();
		}
		return result.Map(func, context);
	}

	public static Task<Result<T>> MapIf<T>(this Result<T> result, Func<T, bool> predicate, Func<T, Task<T>> func)
	{
		if (!result.IsSuccess || !predicate(result.Value))
		{
			return result.AsCompletedTask();
		}
		return result.Map(func);
	}

	public static Task<Result<T>> MapIf<T, TContext>(this Result<T> result, Func<T, TContext, bool> predicate, Func<T, TContext, Task<T>> func, TContext context)
	{
		if (!result.IsSuccess || !predicate(result.Value, context))
		{
			return result.AsCompletedTask();
		}
		return result.Map(func, context);
	}

	public static Task<Result<T, E>> MapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, Task<T>> func)
	{
		if (!result.IsSuccess || !predicate(result.Value))
		{
			return result.AsCompletedTask();
		}
		return result.Map(func);
	}

	public static Task<Result<T, E>> MapIf<T, E, TContext>(this Result<T, E> result, Func<T, TContext, bool> predicate, Func<T, TContext, Task<T>> func, TContext context)
	{
		if (!result.IsSuccess || !predicate(result.Value, context))
		{
			return result.AsCompletedTask();
		}
		return result.Map(func, context);
	}

	public static Result<K, E> MapTry<T, K, E>(this Result<T, E> result, Func<T, K> func, Func<Exception, E> errorHandler)
	{
		if (!result.IsFailure)
		{
			return Result.Try(() => func(result.Value), errorHandler);
		}
		return Result.Failure<K, E>(result.Error);
	}

	public static Result<K, E> MapTry<K, E>(this UnitResult<E> result, Func<K> func, Func<Exception, E> errorHandler)
	{
		if (!result.IsFailure)
		{
			return Result.Try(() => func(), errorHandler);
		}
		return Result.Failure<K, E>(result.Error);
	}

	public static Result<K> MapTry<T, K>(this Result<T> result, Func<T, K> func, Func<Exception, string> errorHandler = null)
	{
		if (!result.IsFailure)
		{
			return Result.Try(() => func(result.Value), errorHandler);
		}
		return Result.Failure<K>(result.Error);
	}

	public static Result<K> MapTry<K>(this Result result, Func<K> func, Func<Exception, string> errorHandler = null)
	{
		if (!result.IsFailure)
		{
			return Result.Try(() => func(), errorHandler);
		}
		return Result.Failure<K>(result.Error);
	}

	public static Result<K> MapWithTransactionScope<T, K>(this Result<T> self, Func<T, K> f)
	{
		return WithTransactionScope(() => self.Map(f));
	}

	public static Result<K> MapWithTransactionScope<K>(this Result self, Func<K> f)
	{
		return WithTransactionScope(() => self.Map(f));
	}

	public static Task<Result<K>> MapWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, Task<K>> f)
	{
		return WithTransactionScope(() => self.Map(f));
	}

	public static Task<Result<K>> MapWithTransactionScope<K>(this Task<Result> self, Func<Task<K>> f)
	{
		return WithTransactionScope(() => self.Map(f));
	}

	public static Task<Result<K>> MapWithTransactionScope<T, K>(this Task<Result<T>> self, Func<T, K> f)
	{
		return WithTransactionScope(() => self.Map(f));
	}

	public static Task<Result<K>> MapWithTransactionScope<K>(this Task<Result> self, Func<K> f)
	{
		return WithTransactionScope(() => self.Map(f));
	}

	public static Task<Result<K>> MapWithTransactionScope<T, K>(this Result<T> self, Func<T, Task<K>> f)
	{
		return WithTransactionScope(() => self.Map(f));
	}

	public static Task<Result<K>> MapWithTransactionScope<K>(this Result self, Func<Task<K>> f)
	{
		return WithTransactionScope(() => self.Map(f));
	}

	public static K Match<T, K, E>(this Result<T, E> result, Func<T, K> onSuccess, Func<E, K> onFailure)
	{
		if (!result.IsSuccess)
		{
			return onFailure(result.Error);
		}
		return onSuccess(result.Value);
	}

	public static K Match<K, T>(this Result<T> result, Func<T, K> onSuccess, Func<string, K> onFailure)
	{
		if (!result.IsSuccess)
		{
			return onFailure(result.Error);
		}
		return onSuccess(result.Value);
	}

	public static T Match<T>(this Result result, Func<T> onSuccess, Func<string, T> onFailure)
	{
		if (!result.IsSuccess)
		{
			return onFailure(result.Error);
		}
		return onSuccess();
	}

	public static K Match<K, E>(this UnitResult<E> result, Func<K> onSuccess, Func<E, K> onFailure)
	{
		if (!result.IsSuccess)
		{
			return onFailure(result.Error);
		}
		return onSuccess();
	}

	public static void Match<T, E>(this Result<T, E> result, Action<T> onSuccess, Action<E> onFailure)
	{
		if (result.IsSuccess)
		{
			onSuccess(result.Value);
		}
		else
		{
			onFailure(result.Error);
		}
	}

	public static void Match<E>(this UnitResult<E> result, Action onSuccess, Action<E> onFailure)
	{
		if (result.IsSuccess)
		{
			onSuccess();
		}
		else
		{
			onFailure(result.Error);
		}
	}

	public static void Match<T>(this Result<T> result, Action<T> onSuccess, Action<string> onFailure)
	{
		if (result.IsSuccess)
		{
			onSuccess(result.Value);
		}
		else
		{
			onFailure(result.Error);
		}
	}

	public static void Match(this Result result, Action onSuccess, Action<string> onFailure)
	{
		if (result.IsSuccess)
		{
			onSuccess();
		}
		else
		{
			onFailure(result.Error);
		}
	}

	public static Result<T, E> OnFailureCompensate<T, E>(this Result<T, E> result, Func<Result<T, E>> func)
	{
		if (result.IsFailure)
		{
			return func();
		}
		return result;
	}

	public static Result<T> OnFailureCompensate<T>(this Result<T> result, Func<Result<T>> func)
	{
		if (result.IsFailure)
		{
			return func();
		}
		return result;
	}

	public static Result OnFailureCompensate(this Result result, Func<Result> func)
	{
		if (result.IsFailure)
		{
			return func();
		}
		return result;
	}

	public static Result<T, E> OnFailureCompensate<T, E>(this Result<T, E> result, Func<E, Result<T, E>> func)
	{
		if (result.IsFailure)
		{
			return func(result.Error);
		}
		return result;
	}

	public static Result<T> OnFailureCompensate<T>(this Result<T> result, Func<string, Result<T>> func)
	{
		if (result.IsFailure)
		{
			return func(result.Error);
		}
		return result;
	}

	public static Result OnFailureCompensate(this Result result, Func<string, Result> func)
	{
		if (result.IsFailure)
		{
			return func(result.Error);
		}
		return result;
	}

	public static Result OnSuccessTry(this Result result, Action action, Func<Exception, string> errorHandler = null)
	{
		if (!result.IsFailure)
		{
			return Result.Try(action, errorHandler);
		}
		return result;
	}

	public static Result OnSuccessTry<T>(this Result<T> result, Action<T> action, Func<Exception, string> errorHandler = null)
	{
		if (!result.IsFailure)
		{
			return Result.Try(delegate
			{
				action(result.Value);
			}, errorHandler);
		}
		return Result.Failure(result.Error);
	}

	public static async Task<Result> OnSuccessTry(this Task<Result> task, Func<Task> func, Func<Exception, string> errorHandler = null)
	{
		return await (await task.DefaultAwait()).OnSuccessTry(func, errorHandler).DefaultAwait();
	}

	public static async Task<Result> OnSuccessTry<T>(this Task<Result<T>> task, Func<T, Task> func, Func<Exception, string> errorHandler = null)
	{
		return await (await task.DefaultAwait()).OnSuccessTry(func, errorHandler).DefaultAwait();
	}

	public static async Task<Result> OnSuccessTry(this Task<Result> task, Action action, Func<Exception, string> errorHandler = null)
	{
		return (await task.DefaultAwait()).OnSuccessTry(action, errorHandler);
	}

	public static async Task<Result> OnSuccessTry<T>(this Task<Result<T>> task, Action<T> action, Func<Exception, string> errorHandler = null)
	{
		return (await task.DefaultAwait()).OnSuccessTry(action, errorHandler);
	}

	public static async Task<Result> OnSuccessTry(this Result result, Func<Task> func, Func<Exception, string> errorHandler = null)
	{
		return (!result.IsFailure) ? (await Result.Try(func, errorHandler).DefaultAwait()) : result;
	}

	public static async Task<Result> OnSuccessTry<T>(this Result<T> result, Func<T, Task> func, Func<Exception, string> errorHandler = null)
	{
		return (!result.IsFailure) ? (await Result.Try(() => func(result.Value), errorHandler).DefaultAwait()) : Result.Failure(result.Error);
	}

	public static Result<T, E> Required<T, E>(this Result<Maybe<T>, E> result, E error)
	{
		return result.Bind((Maybe<T> value) => MaybeExtensions.ToResult(in value, error));
	}

	public static Result<T> Required<T>(this Result<Maybe<T>> result, string error)
	{
		return result.Bind((Maybe<T> value) => MaybeExtensions.ToResult(in value, error));
	}

	public static Result<K> Select<T, K>(this in Result<T> result, Func<T, K> selector)
	{
		return result.Map(selector);
	}

	public static Result<TR> SelectMany<T, TK, TR>(this Result<T> result, Func<T, Result<TK>> func, Func<T, TK, TR> project)
	{
		return result.Bind(func).Map((TK x) => project(result.Value, x));
	}

	public static Result<TR, TE> SelectMany<T, TK, TE, TR>(this Result<T, TE> result, Func<T, Result<TK, TE>> func, Func<T, TK, TR> project)
	{
		return result.Bind(func).Map((TK x) => project(result.Value, x));
	}

	public static async Task<Result<TR>> SelectMany<T, TK, TR>(this Task<Result<T>> resultTask, Func<T, Task<Result<TK>>> func, Func<T, TK, TR> project)
	{
		return await (await resultTask.DefaultAwait()).SelectMany(func, project).DefaultAwait();
	}

	public static async Task<Result<TR, TE>> SelectMany<T, TK, TE, TR>(this Task<Result<T, TE>> resultTask, Func<T, Task<Result<TK, TE>>> func, Func<T, TK, TR> project)
	{
		return await (await resultTask.DefaultAwait()).SelectMany(func, project).DefaultAwait();
	}

	public static async Task<Result<TR>> SelectMany<T, TK, TR>(this Task<Result<T>> resultTask, Func<T, Result<TK>> func, Func<T, TK, TR> project)
	{
		return (await resultTask.DefaultAwait()).SelectMany(func, project);
	}

	public static async Task<Result<TR, TE>> SelectMany<T, TK, TE, TR>(this Task<Result<T, TE>> resultTask, Func<T, Result<TK, TE>> func, Func<T, TK, TR> project)
	{
		return (await resultTask.DefaultAwait()).SelectMany(func, project);
	}

	public static Task<Result<TR>> SelectMany<T, TK, TR>(this Result<T> result, Func<T, Task<Result<TK>>> func, Func<T, TK, TR> project)
	{
		return result.Bind(func).Map((TK x) => project(result.Value, x));
	}

	public static Task<Result<TR, TE>> SelectMany<T, TK, TE, TR>(this Result<T, TE> result, Func<T, Task<Result<TK, TE>>> func, Func<T, TK, TR> project)
	{
		return result.Bind(func).Map((TK x) => project(result.Value, x));
	}

	public static Result Tap(this Result result, Action action)
	{
		if (result.IsSuccess)
		{
			action();
		}
		return result;
	}

	public static Result<T> Tap<T>(this Result<T> result, Action action)
	{
		if (result.IsSuccess)
		{
			action();
		}
		return result;
	}

	public static Result<T> Tap<T>(this Result<T> result, Action<T> action)
	{
		if (result.IsSuccess)
		{
			action(result.Value);
		}
		return result;
	}

	public static UnitResult<E> Tap<E>(this UnitResult<E> result, Action action)
	{
		if (result.IsSuccess)
		{
			action();
		}
		return result;
	}

	public static Result<T, E> Tap<T, E>(this Result<T, E> result, Action action)
	{
		if (result.IsSuccess)
		{
			action();
		}
		return result;
	}

	public static Result<T, E> Tap<T, E>(this Result<T, E> result, Action<T> action)
	{
		if (result.IsSuccess)
		{
			action(result.Value);
		}
		return result;
	}

	public static Result<T, E> TapError<T, E>(this Result<T, E> result, Action action)
	{
		if (result.IsFailure)
		{
			action();
		}
		return result;
	}

	public static Result<T> TapError<T>(this Result<T> result, Action action)
	{
		if (result.IsFailure)
		{
			action();
		}
		return result;
	}

	public static Result TapError(this Result result, Action action)
	{
		if (result.IsFailure)
		{
			action();
		}
		return result;
	}

	public static UnitResult<E> TapError<E>(this UnitResult<E> result, Action<E> action)
	{
		if (result.IsFailure)
		{
			action(result.Error);
		}
		return result;
	}

	public static UnitResult<E> TapError<E>(this UnitResult<E> result, Action action)
	{
		if (result.IsFailure)
		{
			action();
		}
		return result;
	}

	public static Result<T, E> TapError<T, E>(this Result<T, E> result, Action<E> action)
	{
		if (result.IsFailure)
		{
			action(result.Error);
		}
		return result;
	}

	public static Result<T> TapError<T>(this Result<T> result, Action<string> action)
	{
		if (result.IsFailure)
		{
			action(result.Error);
		}
		return result;
	}

	public static Result TapError(this Result result, Action<string> action)
	{
		if (result.IsFailure)
		{
			action(result.Error);
		}
		return result;
	}

	public static async Task<Result<T, E>> TapError<T, E>(this Task<Result<T, E>> resultTask, Func<Task> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T>> TapError<T>(this Task<Result<T>> resultTask, Func<Task> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result> TapError(this Task<Result> resultTask, Func<Task> func)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result> TapError(this Task<Result> resultTask, Func<string, Task> func)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			await func(result.Error).DefaultAwait();
		}
		return result;
	}

	public static async Task<UnitResult<E>> TapError<E>(this Task<UnitResult<E>> resultTask, Func<E, Task> func)
	{
		UnitResult<E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			await func(result.Error).DefaultAwait();
		}
		return result;
	}

	public static async Task<UnitResult<E>> TapError<E>(this Task<UnitResult<E>> resultTask, Func<Task> func)
	{
		UnitResult<E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T>> TapError<T>(this Task<Result<T>> resultTask, Func<string, Task> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			await func(result.Error).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> TapError<T, E>(this Task<Result<T, E>> resultTask, Func<E, Task> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsFailure)
		{
			await func(result.Error).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T>> TapError<T>(this Task<Result<T>> resultTask, Action action)
	{
		return (await resultTask.DefaultAwait()).TapError(action);
	}

	public static async Task<Result> TapError(this Task<Result> resultTask, Action action)
	{
		return (await resultTask.DefaultAwait()).TapError(action);
	}

	public static async Task<Result<T, E>> TapError<T, E>(this Task<Result<T, E>> resultTask, Action action)
	{
		return (await resultTask.DefaultAwait()).TapError(action);
	}

	public static async Task<UnitResult<E>> TapError<E>(this Task<UnitResult<E>> resultTask, Action action)
	{
		return (await resultTask.DefaultAwait()).TapError(action);
	}

	public static async Task<UnitResult<E>> TapError<E>(this Task<UnitResult<E>> resultTask, Action<E> action)
	{
		return (await resultTask.DefaultAwait()).TapError(action);
	}

	public static async Task<Result<T>> TapError<T>(this Task<Result<T>> resultTask, Action<string> action)
	{
		return (await resultTask.DefaultAwait()).TapError(action);
	}

	public static async Task<Result<T, E>> TapError<T, E>(this Task<Result<T, E>> resultTask, Action<E> action)
	{
		return (await resultTask.DefaultAwait()).TapError(action);
	}

	public static async Task<Result> TapError(this Task<Result> resultTask, Action<string> action)
	{
		return (await resultTask.DefaultAwait()).TapError(action);
	}

	public static async Task<Result<T>> TapError<T>(this Result<T> result, Func<Task> func)
	{
		if (result.IsFailure)
		{
			await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> TapError<T, E>(this Result<T, E> result, Func<Task> func)
	{
		if (result.IsFailure)
		{
			await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result> TapError(this Result result, Func<Task> func)
	{
		if (result.IsFailure)
		{
			await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<Result> TapError(this Result result, Func<string, Task> func)
	{
		if (result.IsFailure)
		{
			await func(result.Error).DefaultAwait();
		}
		return result;
	}

	public static async Task<UnitResult<E>> TapError<E>(this UnitResult<E> result, Func<Task> func)
	{
		if (result.IsFailure)
		{
			await func().DefaultAwait();
		}
		return result;
	}

	public static async Task<UnitResult<E>> TapError<E>(this UnitResult<E> result, Func<E, Task> func)
	{
		if (result.IsFailure)
		{
			await func(result.Error).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T>> TapError<T>(this Result<T> result, Func<string, Task> func)
	{
		if (result.IsFailure)
		{
			await func(result.Error).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> TapError<T, E>(this Result<T, E> result, Func<E, Task> func)
	{
		if (result.IsFailure)
		{
			await func(result.Error).DefaultAwait();
		}
		return result;
	}

	public static Result TapErrorIf(this Result result, bool condition, Action action)
	{
		if (condition)
		{
			return result.TapError(action);
		}
		return result;
	}

	public static Result TapErrorIf(this Result result, bool condition, Action<string> action)
	{
		if (condition)
		{
			return result.TapError(action);
		}
		return result;
	}

	public static Result<T> TapErrorIf<T>(this Result<T> result, bool condition, Action action)
	{
		if (condition)
		{
			return result.TapError(action);
		}
		return result;
	}

	public static Result<T> TapErrorIf<T>(this Result<T> result, bool condition, Action<string> action)
	{
		if (condition)
		{
			return result.TapError(action);
		}
		return result;
	}

	public static UnitResult<E> TapErrorIf<E>(this UnitResult<E> result, bool condition, Action action)
	{
		if (condition)
		{
			return result.TapError(action);
		}
		return result;
	}

	public static UnitResult<E> TapErrorIf<E>(this UnitResult<E> result, bool condition, Action<E> action)
	{
		if (condition)
		{
			return result.TapError(action);
		}
		return result;
	}

	public static Result<T, E> TapErrorIf<T, E>(this Result<T, E> result, bool condition, Action action)
	{
		if (condition)
		{
			return result.TapError(action);
		}
		return result;
	}

	public static Result<T, E> TapErrorIf<T, E>(this Result<T, E> result, bool condition, Action<E> action)
	{
		if (condition)
		{
			return result.TapError(action);
		}
		return result;
	}

	public static Result TapErrorIf(this Result result, Func<string, bool> predicate, Action action)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static Result TapErrorIf(this Result result, Func<string, bool> predicate, Action<string> action)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static Result<T> TapErrorIf<T>(this Result<T> result, Func<string, bool> predicate, Action action)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static Result<T> TapErrorIf<T>(this Result<T> result, Func<string, bool> predicate, Action<string> action)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static Result<T, E> TapErrorIf<T, E>(this Result<T, E> result, Func<E, bool> predicate, Action action)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static Result<T, E> TapErrorIf<T, E>(this Result<T, E> result, Func<E, bool> predicate, Action<E> action)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static UnitResult<E> TapErrorIf<E>(this UnitResult<E> result, Func<E, bool> predicate, Action action)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static UnitResult<E> TapErrorIf<E>(this UnitResult<E> result, Func<E, bool> predicate, Action<E> action)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static Task<Result> TapErrorIf(this Task<Result> resultTask, bool condition, Func<Task> func)
	{
		if (condition)
		{
			return resultTask.TapError(func);
		}
		return resultTask;
	}

	public static Task<Result> TapErrorIf(this Task<Result> resultTask, bool condition, Func<string, Task> func)
	{
		if (condition)
		{
			return resultTask.TapError(func);
		}
		return resultTask;
	}

	public static Task<Result<T>> TapErrorIf<T>(this Task<Result<T>> resultTask, bool condition, Func<Task> func)
	{
		if (condition)
		{
			return resultTask.TapError(func);
		}
		return resultTask;
	}

	public static Task<Result<T>> TapErrorIf<T>(this Task<Result<T>> resultTask, bool condition, Func<string, Task> func)
	{
		if (condition)
		{
			return resultTask.TapError(func);
		}
		return resultTask;
	}

	public static Task<Result<T, E>> TapErrorIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<Task> func)
	{
		if (condition)
		{
			return resultTask.TapError(func);
		}
		return resultTask;
	}

	public static Task<Result<T, E>> TapErrorIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Func<E, Task> func)
	{
		if (condition)
		{
			return resultTask.TapError(func);
		}
		return resultTask;
	}

	public static Task<UnitResult<E>> TapErrorIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Func<Task> func)
	{
		if (condition)
		{
			return resultTask.TapError(func);
		}
		return resultTask;
	}

	public static Task<UnitResult<E>> TapErrorIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Func<E, Task> func)
	{
		if (condition)
		{
			return resultTask.TapError(func);
		}
		return resultTask;
	}

	public static async Task<Result> TapErrorIf(this Task<Result> resultTask, Func<string, bool> predicate, Func<Task> func)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsFailure && predicate(result.Error))
		{
			return await result.TapError(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result> TapErrorIf(this Task<Result> resultTask, Func<string, bool> predicate, Func<string, Task> func)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsFailure && predicate(result.Error))
		{
			return await result.TapError(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T>> TapErrorIf<T>(this Task<Result<T>> resultTask, Func<string, bool> predicate, Func<Task> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure && predicate(result.Error))
		{
			return await result.TapError(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T>> TapErrorIf<T>(this Task<Result<T>> resultTask, Func<string, bool> predicate, Func<string, Task> func)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure && predicate(result.Error))
		{
			return await result.TapError(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> TapErrorIf<T, E>(this Task<Result<T, E>> resultTask, Func<E, bool> predicate, Func<Task> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsFailure && predicate(result.Error))
		{
			return await result.TapError(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<Result<T, E>> TapErrorIf<T, E>(this Task<Result<T, E>> resultTask, Func<E, bool> predicate, Func<E, Task> func)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsFailure && predicate(result.Error))
		{
			return await result.TapError(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<UnitResult<E>> TapErrorIf<E>(this Task<UnitResult<E>> resultTask, Func<E, bool> predicate, Func<Task> func)
	{
		UnitResult<E> result = await resultTask.DefaultAwait();
		if (result.IsFailure && predicate(result.Error))
		{
			return await result.TapError(func).DefaultAwait();
		}
		return result;
	}

	public static async Task<UnitResult<E>> TapErrorIf<E>(this Task<UnitResult<E>> resultTask, Func<E, bool> predicate, Func<E, Task> func)
	{
		UnitResult<E> result = await resultTask.DefaultAwait();
		if (result.IsFailure && predicate(result.Error))
		{
			return await result.TapError(func).DefaultAwait();
		}
		return result;
	}

	public static Task<Result> TapErrorIf(this Task<Result> resultTask, bool condition, Action action)
	{
		if (condition)
		{
			return resultTask.TapError(action);
		}
		return resultTask;
	}

	public static Task<Result> TapErrorIf(this Task<Result> resultTask, bool condition, Action<string> action)
	{
		if (condition)
		{
			return resultTask.TapError(action);
		}
		return resultTask;
	}

	public static Task<Result<T>> TapErrorIf<T>(this Task<Result<T>> resultTask, bool condition, Action action)
	{
		if (condition)
		{
			return resultTask.TapError(action);
		}
		return resultTask;
	}

	public static Task<Result<T>> TapErrorIf<T>(this Task<Result<T>> resultTask, bool condition, Action<string> action)
	{
		if (condition)
		{
			return resultTask.TapError(action);
		}
		return resultTask;
	}

	public static Task<Result<T, E>> TapErrorIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Action action)
	{
		if (condition)
		{
			return resultTask.TapError(action);
		}
		return resultTask;
	}

	public static Task<Result<T, E>> TapErrorIf<T, E>(this Task<Result<T, E>> resultTask, bool condition, Action<E> action)
	{
		if (condition)
		{
			return resultTask.TapError(action);
		}
		return resultTask;
	}

	public static Task<UnitResult<E>> TapErrorIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Action action)
	{
		if (condition)
		{
			return resultTask.TapError(action);
		}
		return resultTask;
	}

	public static Task<UnitResult<E>> TapErrorIf<E>(this Task<UnitResult<E>> resultTask, bool condition, Action<E> action)
	{
		if (condition)
		{
			return resultTask.TapError(action);
		}
		return resultTask;
	}

	public static async Task<Result> TapErrorIf(this Task<Result> resultTask, Func<string, bool> predicate, Action action)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static async Task<Result> TapErrorIf(this Task<Result> resultTask, Func<string, bool> predicate, Action<string> action)
	{
		Result result = await resultTask.DefaultAwait();
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static async Task<Result<T>> TapErrorIf<T>(this Task<Result<T>> resultTask, Func<string, bool> predicate, Action action)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static async Task<Result<T>> TapErrorIf<T>(this Task<Result<T>> resultTask, Func<string, bool> predicate, Action<string> action)
	{
		Result<T> result = await resultTask.DefaultAwait();
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static async Task<Result<T, E>> TapErrorIf<T, E>(this Task<Result<T, E>> resultTask, Func<E, bool> predicate, Action action)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static async Task<Result<T, E>> TapErrorIf<T, E>(this Task<Result<T, E>> resultTask, Func<E, bool> predicate, Action<E> action)
	{
		Result<T, E> result = await resultTask.DefaultAwait();
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static async Task<UnitResult<E>> TapErrorIf<E>(this Task<UnitResult<E>> resultTask, Func<E, bool> predicate, Action action)
	{
		UnitResult<E> result = await resultTask.DefaultAwait();
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static async Task<UnitResult<E>> TapErrorIf<E>(this Task<UnitResult<E>> resultTask, Func<E, bool> predicate, Action<E> action)
	{
		UnitResult<E> result = await resultTask.DefaultAwait();
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(action);
		}
		return result;
	}

	public static Task<Result> TapErrorIf(this Result result, bool condition, Func<Task> func)
	{
		if (condition)
		{
			return result.TapError(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result> TapErrorIf(this Result result, bool condition, Func<string, Task> func)
	{
		if (condition)
		{
			return result.TapError(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T>> TapErrorIf<T>(this Result<T> result, bool condition, Func<Task> func)
	{
		if (condition)
		{
			return result.TapError(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T>> TapErrorIf<T>(this Result<T> result, bool condition, Func<string, Task> func)
	{
		if (condition)
		{
			return result.TapError(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T, E>> TapErrorIf<T, E>(this Result<T, E> result, bool condition, Func<Task> func)
	{
		if (condition)
		{
			return result.TapError(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T, E>> TapErrorIf<T, E>(this Result<T, E> result, bool condition, Func<E, Task> func)
	{
		if (condition)
		{
			return result.TapError(func);
		}
		return Task.FromResult(result);
	}

	public static Task<UnitResult<E>> TapErrorIf<E>(this UnitResult<E> result, bool condition, Func<Task> func)
	{
		if (condition)
		{
			return result.TapError(func);
		}
		return Task.FromResult(result);
	}

	public static Task<UnitResult<E>> TapErrorIf<E>(this UnitResult<E> result, bool condition, Func<E, Task> func)
	{
		if (condition)
		{
			return result.TapError(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result> TapErrorIf(this Result result, Func<string, bool> predicate, Func<Task> func)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result> TapErrorIf(this Result result, Func<string, bool> predicate, Func<string, Task> func)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T>> TapErrorIf<T>(this Result<T> result, Func<string, bool> predicate, Func<Task> func)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T>> TapErrorIf<T>(this Result<T> result, Func<string, bool> predicate, Func<string, Task> func)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T, E>> TapErrorIf<T, E>(this Result<T, E> result, Func<E, bool> predicate, Func<Task> func)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(func);
		}
		return Task.FromResult(result);
	}

	public static Task<Result<T, E>> TapErrorIf<T, E>(this Result<T, E> result, Func<E, bool> predicate, Func<E, Task> func)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(func);
		}
		return Task.FromResult(result);
	}

	public static Task<UnitResult<E>> TapErrorIf<E>(this UnitResult<E> result, Func<E, bool> predicate, Func<Task> func)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(func);
		}
		return Task.FromResult(result);
	}

	public static Task<UnitResult<E>> TapErrorIf<E>(this UnitResult<E> result, Func<E, bool> predicate, Func<E, Task> func)
	{
		if (result.IsFailure && predicate(result.Error))
		{
			return result.TapError(func);
		}
		return Task.FromResult(result);
	}

	public static Result TapIf(this Result result, bool condition, Action action)
	{
		if (condition)
		{
			return result.Tap(action);
		}
		return result;
	}

	public static Result<T> TapIf<T>(this Result<T> result, bool condition, Action action)
	{
		if (condition)
		{
			return result.Tap(action);
		}
		return result;
	}

	public static Result<T> TapIf<T>(this Result<T> result, bool condition, Action<T> action)
	{
		if (condition)
		{
			return result.Tap(action);
		}
		return result;
	}

	public static UnitResult<E> TapIf<E>(this UnitResult<E> result, bool condition, Action action)
	{
		if (condition)
		{
			return result.Tap(action);
		}
		return result;
	}

	public static Result<T, E> TapIf<T, E>(this Result<T, E> result, bool condition, Action action)
	{
		if (condition)
		{
			return result.Tap(action);
		}
		return result;
	}

	public static Result<T, E> TapIf<T, E>(this Result<T, E> result, bool condition, Action<T> action)
	{
		if (condition)
		{
			return result.Tap(action);
		}
		return result;
	}

	public static Result<T> TapIf<T>(this Result<T> result, Func<T, bool> predicate, Action action)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(action);
		}
		return result;
	}

	public static Result<T> TapIf<T>(this Result<T> result, Func<T, bool> predicate, Action<T> action)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(action);
		}
		return result;
	}

	public static Result<T, E> TapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Action action)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(action);
		}
		return result;
	}

	public static Result<T, E> TapIf<T, E>(this Result<T, E> result, Func<T, bool> predicate, Action<T> action)
	{
		if (result.IsSuccess && predicate(result.Value))
		{
			return result.Tap(action);
		}
		return result;
	}

	public static UnitResult<E> TapIf<E>(this UnitResult<E> result, Func<bool> predicate, Action action)
	{
		if (result.IsSuccess && predicate())
		{
			return result.Tap(action);
		}
		return result;
	}

	public static Result TapIfTry(this Result result, bool condition, Action action, Func<Exception, string> errorHandler = null)
	{
		if (errorHandler == null)
		{
			errorHandler = Result.Configuration.DefaultTryErrorHandler;
		}
		try
		{
			if (condition && result.IsSuccess)
			{
				action();
			}
			return result;
		}
		catch (Exception arg)
		{
			return Result.Failure(errorHandler(arg));
		}
	}

	public static Result<T> TapIfTry<T>(this Result<T> result, bool condition, Action action, Func<Exception, string> errorHandler = null)
	{
		if (errorHandler == null)
		{
			errorHandler = Result.Configuration.DefaultTryErrorHandler;
		}
		try
		{
			if (condition && result.IsSuccess)
			{
				action();
			}
			return result;
		}
		catch (Exception arg)
		{
			string error = errorHandler(arg);
			return new Result<T>(isFailure: true, error, default(T));
		}
	}

	public static Result<T> TapIfTry<T>(this Result<T> result, bool condition, Action<T> action, Func<Exception, string> errorHandler = null)
	{
		if (errorHandler == null)
		{
			errorHandler = Result.Configuration.DefaultTryErrorHandler;
		}
		try
		{
			if (condition && result.IsSuccess)
			{
				action(result.Value);
			}
			return result;
		}
		catch (Exception arg)
		{
			string error = errorHandler(arg);
			return new Result<T>(isFailure: true, error, default(T));
		}
	}

	public static UnitResult<E> TapIfTry<E>(this UnitResult<E> result, bool condition, Action action, Func<Exception, E> errorHandler)
	{
		try
		{
			if (condition && result.IsSuccess)
			{
				action();
			}
			return result;
		}
		catch (Exception arg)
		{
			return new UnitResult<E>(isFailure: true, errorHandler(arg));
		}
	}

	public static Result<T, E> TapIfTry<T, E>(this Result<T, E> result, bool condition, Action action, Func<Exception, E> errorHandler)
	{
		try
		{
			if (condition && result.IsSuccess)
			{
				action();
			}
			return result;
		}
		catch (Exception arg)
		{
			E error = errorHandler(arg);
			return new Result<T, E>(isFailure: true, error, default(T));
		}
	}

	public static Result<T, E> TapIfTry<T, E>(this Result<T, E> result, bool condition, Action<T> action, Func<Exception, E> errorHandler)
	{
		try
		{
			if (condition && result.IsSuccess)
			{
				action(result.Value);
			}
			return result;
		}
		catch (Exception arg)
		{
			E error = errorHandler(arg);
			return new Result<T, E>(isFailure: true, error, default(T));
		}
	}

	public static Result<T> TapIfTry<T>(this Result<T> result, Func<T, bool> predicate, Action action, Func<Exception, string> errorHandler = null)
	{
		if (errorHandler == null)
		{
			errorHandler = Result.Configuration.DefaultTryErrorHandler;
		}
		try
		{
			if (result.IsSuccess && predicate(result.Value) && result.IsSuccess)
			{
				action();
			}
			return result;
		}
		catch (Exception arg)
		{
			string error = errorHandler(arg);
			return new Result<T>(isFailure: true, error, default(T));
		}
	}

	public static Result<T> TapIfTry<T>(this Result<T> result, Func<T, bool> predicate, Action<T> action, Func<Exception, string> errorHandler = null)
	{
		if (errorHandler == null)
		{
			errorHandler = Result.Configuration.DefaultTryErrorHandler;
		}
		try
		{
			if (result.IsSuccess && predicate(result.Value))
			{
				action(result.Value);
			}
			return result;
		}
		catch (Exception arg)
		{
			string error = errorHandler(arg);
			return new Result<T>(isFailure: true, error, default(T));
		}
	}

	public static Result<T, E> TapIfTry<T, E>(this Result<T, E> result, Func<T, bool> predicate, Action action, Func<Exception, E> errorHandler)
	{
		try
		{
			if (result.IsSuccess && predicate(result.Value))
			{
				action();
			}
			return result;
		}
		catch (Exception arg)
		{
			E error = errorHandler(arg);
			return new Result<T, E>(isFailure: true, error, default(T));
		}
	}

	public static Result<T, E> TapIfTry<T, E>(this Result<T, E> result, Func<T, bool> predicate, Action<T> action, Func<Exception, E> errorHandler)
	{
		try
		{
			if (result.IsSuccess && predicate(result.Value))
			{
				action(result.Value);
			}
			return result;
		}
		catch (Exception arg)
		{
			E error = errorHandler(arg);
			return new Result<T, E>(isFailure: true, error, default(T));
		}
	}

	public static Result TapTry(this Result result, Action action, Func<Exception, string> errorHandler = null)
	{
		if (errorHandler == null)
		{
			errorHandler = Result.Configuration.DefaultTryErrorHandler;
		}
		try
		{
			if (result.IsSuccess)
			{
				action();
			}
			return result;
		}
		catch (Exception arg)
		{
			return Result.Failure(errorHandler(arg));
		}
	}

	public static Result<T> TapTry<T>(this Result<T> result, Action action, Func<Exception, string> errorHandler = null)
	{
		if (errorHandler == null)
		{
			errorHandler = Result.Configuration.DefaultTryErrorHandler;
		}
		try
		{
			if (result.IsSuccess)
			{
				action();
			}
			return result;
		}
		catch (Exception arg)
		{
			string error = errorHandler(arg);
			return new Result<T>(isFailure: true, error, default(T));
		}
	}

	public static Result<T> TapTry<T>(this Result<T> result, Action<T> action, Func<Exception, string> errorHandler = null)
	{
		if (errorHandler == null)
		{
			errorHandler = Result.Configuration.DefaultTryErrorHandler;
		}
		try
		{
			if (result.IsSuccess)
			{
				action(result.Value);
			}
			return result;
		}
		catch (Exception arg)
		{
			string error = errorHandler(arg);
			return new Result<T>(isFailure: true, error, default(T));
		}
	}

	public static UnitResult<E> TapTry<E>(this UnitResult<E> result, Action action, Func<Exception, E> errorHandler)
	{
		try
		{
			if (result.IsSuccess)
			{
				action();
			}
			return result;
		}
		catch (Exception arg)
		{
			return new UnitResult<E>(isFailure: true, errorHandler(arg));
		}
	}

	public static Result<T, E> TapTry<T, E>(this Result<T, E> result, Action action, Func<Exception, E> errorHandler)
	{
		try
		{
			if (result.IsSuccess)
			{
				action();
			}
			return result;
		}
		catch (Exception arg)
		{
			E error = errorHandler(arg);
			return new Result<T, E>(isFailure: true, error, default(T));
		}
	}

	public static Result<T, E> TapTry<T, E>(this Result<T, E> result, Action<T> action, Func<Exception, E> errorHandler)
	{
		try
		{
			if (result.IsSuccess)
			{
				action(result.Value);
			}
			return result;
		}
		catch (Exception arg)
		{
			E error = errorHandler(arg);
			return new Result<T, E>(isFailure: true, error, default(T));
		}
	}

	private static T WithTransactionScope<T>(Func<T> f) where T : IResult
	{
		using TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, _transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
		T result = f();
		if (result.IsSuccess)
		{
			transactionScope.Complete();
		}
		return result;
	}

	private static async Task<T> WithTransactionScope<T>(Func<Task<T>> f) where T : IResult
	{
		using TransactionScope trans = new TransactionScope(TransactionScopeOption.Required, _transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
		T result = await f().DefaultAwait();
		if (result.IsSuccess)
		{
			trans.Complete();
		}
		return result;
	}
}
