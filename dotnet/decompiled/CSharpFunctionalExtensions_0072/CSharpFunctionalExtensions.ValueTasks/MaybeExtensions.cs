using System;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions.ValueTasks;

public static class MaybeExtensions
{
	public static async ValueTask<Maybe<T>> AsMaybe<T>(this ValueTask<T?> nullableTask) where T : struct
	{
		T? value = await nullableTask;
		return CSharpFunctionalExtensions.MaybeExtensions.AsMaybe(ref value);
	}

	public static async ValueTask<Maybe<T>> AsMaybe<T>(this ValueTask<T?> nullableTask) where T : class
	{
		return (await nullableTask).AsMaybe();
	}

	public static async ValueTask<Maybe<K>> Bind<T, K>(this ValueTask<Maybe<T>> maybeTask, Func<T, ValueTask<Maybe<K>>> selector)
	{
		return await (await maybeTask).Bind(selector);
	}

	public static async ValueTask<Maybe<K>> Bind<T, K, TContext>(this ValueTask<Maybe<T>> maybeTask, Func<T, TContext, ValueTask<Maybe<K>>> selector, TContext context)
	{
		return await (await maybeTask).Bind(selector, context);
	}

	public static async ValueTask<Maybe<K>> Bind<T, K>(this ValueTask<Maybe<T>> maybeTask, Func<T, Maybe<K>> selector)
	{
		return (await maybeTask).Bind(selector);
	}

	public static async ValueTask<Maybe<K>> Bind<T, K, TContext>(this ValueTask<Maybe<T>> maybeTask, Func<T, TContext, Maybe<K>> selector, TContext context)
	{
		return (await maybeTask).Bind(selector, context);
	}

	public static ValueTask<Maybe<K>> Bind<T, K>(this Maybe<T> maybe, Func<T, ValueTask<Maybe<K>>> selector)
	{
		if (maybe.HasNoValue)
		{
			return Maybe<K>.None.AsCompletedValueTask();
		}
		return selector(maybe.GetValueOrThrow());
	}

	public static ValueTask<Maybe<K>> Bind<T, K, TContext>(this Maybe<T> maybe, Func<T, TContext, ValueTask<Maybe<K>>> selector, TContext context)
	{
		if (maybe.HasNoValue)
		{
			return Maybe<K>.None.AsCompletedValueTask();
		}
		return selector(maybe.GetValueOrThrow(), context);
	}

	public static async Task Execute<T>(this ValueTask<Maybe<T>> maybeTask, Func<T, ValueTask> valueTask)
	{
		Maybe<T> maybe = await maybeTask;
		if (!maybe.HasNoValue)
		{
			await valueTask(maybe.GetValueOrThrow());
		}
	}

	public static async Task Execute<T>(this ValueTask<Maybe<T>> maybeTask, Action<T> action)
	{
		Maybe<T> maybe = await maybeTask;
		if (!maybe.HasNoValue)
		{
			action(maybe.GetValueOrThrow());
		}
	}

	public static async Task Execute<T>(this Maybe<T> maybe, Func<T, ValueTask> valueTask)
	{
		if (!maybe.HasNoValue)
		{
			await valueTask(maybe.GetValueOrThrow());
		}
	}

	public static async Task ExecuteNoValue<T>(this ValueTask<Maybe<T>> maybeTask, Func<ValueTask> valueTask)
	{
		if (!(await maybeTask).HasValue)
		{
			await valueTask();
		}
	}

	public static async Task ExecuteNoValue<T>(this ValueTask<Maybe<T>> maybeTask, Action action)
	{
		if (!(await maybeTask).HasValue)
		{
			action();
		}
	}

	public static async Task ExecuteNoValue<T>(this Maybe<T> maybe, Func<ValueTask> valueTask)
	{
		if (!maybe.HasValue)
		{
			await valueTask();
		}
	}

	public static async ValueTask<T> GetValueOrDefault<T>(this ValueTask<Maybe<T>> maybeTask, Func<ValueTask<T>> defaultValue)
	{
		return await (await maybeTask).GetValueOrDefault(defaultValue);
	}

	public static async ValueTask<K> GetValueOrDefault<T, K>(this ValueTask<Maybe<T>> maybeTask, Func<T, ValueTask<K>> selector, K defaultValue = default(K))
	{
		return await (await maybeTask).GetValueOrDefault(selector, defaultValue);
	}

	public static async ValueTask<K> GetValueOrDefault<T, K>(this ValueTask<Maybe<T>> maybeTask, Func<T, ValueTask<K>> selector, Func<ValueTask<K>> defaultValue)
	{
		return await (await maybeTask).GetValueOrDefault(selector, defaultValue);
	}

	public static async ValueTask<T> GetValueOrDefault<T>(this ValueTask<Maybe<T>> maybeTask, Func<T> defaultValue)
	{
		return (await maybeTask).GetValueOrDefault(defaultValue);
	}

	public static async ValueTask<K> GetValueOrDefault<T, K>(this ValueTask<Maybe<T>> maybeTask, Func<T, K> selector, K defaultValue = default(K))
	{
		return (await maybeTask).GetValueOrDefault(selector, defaultValue);
	}

	public static async ValueTask<K> GetValueOrDefault<T, K>(this ValueTask<Maybe<T>> maybeTask, Func<T, K> selector, Func<K> defaultValue)
	{
		return (await maybeTask).GetValueOrDefault(selector, defaultValue);
	}

	public static async ValueTask<T> GetValueOrDefault<T>(this Maybe<T> maybe, Func<ValueTask<T>> valueTask)
	{
		if (maybe.HasNoValue)
		{
			return await valueTask();
		}
		return maybe.GetValueOrThrow();
	}

	public static async ValueTask<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, K> selector, Func<ValueTask<K>> valueTask)
	{
		if (maybe.HasNoValue)
		{
			return await valueTask();
		}
		return selector(maybe.GetValueOrThrow());
	}

	public static async ValueTask<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, ValueTask<K>> valueTask, K defaultValue = default(K))
	{
		if (maybe.HasNoValue)
		{
			return defaultValue;
		}
		return await valueTask(maybe.GetValueOrThrow());
	}

	public static async ValueTask<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, ValueTask<K>> valueTask, Func<ValueTask<K>> defaultValue)
	{
		if (maybe.HasNoValue)
		{
			return await defaultValue();
		}
		return await valueTask(maybe.GetValueOrThrow());
	}

	public static async ValueTask<T> GetValueOrThrow<T>(this ValueTask<Maybe<T>> maybeTask)
	{
		return (await maybeTask).GetValueOrThrow();
	}

	public static async ValueTask<T> GetValueOrThrow<T>(this ValueTask<Maybe<T>> maybeTask, string errorMessage)
	{
		return (await maybeTask).GetValueOrThrow(errorMessage);
	}

	public static async ValueTask<Maybe<K>> Map<T, K>(this ValueTask<Maybe<T>> maybeTask, Func<T, ValueTask<K>> valueTask)
	{
		return await (await maybeTask).Map(valueTask);
	}

	public static async ValueTask<Maybe<K>> Map<T, K, TContext>(this ValueTask<Maybe<T>> maybeTask, Func<T, TContext, ValueTask<K>> valueTask, TContext context)
	{
		return await (await maybeTask).Map(valueTask, context);
	}

	public static async ValueTask<Maybe<K>> Map<T, K>(this ValueTask<Maybe<T>> valueTask, Func<T, K> selector)
	{
		return (await valueTask).Map(selector);
	}

	public static async ValueTask<Maybe<K>> Map<T, K, TContext>(this ValueTask<Maybe<T>> valueTask, Func<T, TContext, K> selector, TContext context)
	{
		return (await valueTask).Map(selector, context);
	}

	public static async ValueTask<Maybe<K>> Map<T, K>(this Maybe<T> maybe, Func<T, ValueTask<K>> valueTask)
	{
		if (maybe.HasNoValue)
		{
			return Maybe<K>.None;
		}
		return await valueTask(maybe.GetValueOrThrow());
	}

	public static async ValueTask<Maybe<K>> Map<T, K, TContext>(this Maybe<T> maybe, Func<T, TContext, ValueTask<K>> valueTask, TContext context)
	{
		if (maybe.HasNoValue)
		{
			return Maybe<K>.None;
		}
		return await valueTask(maybe.GetValueOrThrow(), context);
	}

	public static async ValueTask<Maybe<T>> Or<T>(this ValueTask<Maybe<T>> maybeTask, ValueTask<T> fallback)
	{
		Maybe<T> result = await maybeTask;
		if (result.HasNoValue)
		{
			return Maybe<T>.From(await fallback);
		}
		return result;
	}

	public static async ValueTask<Maybe<T>> Or<T>(this ValueTask<Maybe<T>> maybeTask, Func<ValueTask<T>> fallbackOperation)
	{
		Maybe<T> result = await maybeTask;
		if (result.HasNoValue)
		{
			return Maybe<T>.From(await fallbackOperation());
		}
		return result;
	}

	public static async ValueTask<Maybe<T>> Or<T>(this ValueTask<Maybe<T>> maybeTask, Func<ValueTask<Maybe<T>>> fallbackOperation)
	{
		Maybe<T> result = await maybeTask;
		if (result.HasNoValue)
		{
			return await fallbackOperation();
		}
		return result;
	}

	public static async ValueTask<Maybe<T>> Or<T>(this ValueTask<Maybe<T>> maybeTask, T fallback)
	{
		Maybe<T> result = await maybeTask;
		if (result.HasNoValue)
		{
			return Maybe<T>.From(fallback);
		}
		return result;
	}

	public static async ValueTask<Maybe<T>> Or<T>(this ValueTask<Maybe<T>> maybeTask, Func<T> fallbackOperation)
	{
		Maybe<T> result = await maybeTask;
		if (result.HasNoValue)
		{
			return Maybe<T>.From(fallbackOperation());
		}
		return result;
	}

	public static async ValueTask<Maybe<T>> Or<T>(this ValueTask<Maybe<T>> maybeTask, Maybe<T> fallback)
	{
		Maybe<T> result = await maybeTask;
		if (result.HasNoValue)
		{
			return fallback;
		}
		return result;
	}

	public static async ValueTask<Maybe<T>> Or<T>(this ValueTask<Maybe<T>> maybeTask, Func<Maybe<T>> fallbackOperation)
	{
		Maybe<T> result = await maybeTask;
		if (result.HasNoValue)
		{
			return fallbackOperation();
		}
		return result;
	}

	public static async ValueTask<Maybe<T>> Or<T>(this Maybe<T> maybe, Func<ValueTask<T>> valueTaskFallbackOperation)
	{
		if (maybe.HasNoValue)
		{
			return await valueTaskFallbackOperation();
		}
		return maybe;
	}

	public static async ValueTask<Maybe<T>> Or<T>(this Maybe<T> maybe, ValueTask<Maybe<T>> valueTaskFallback)
	{
		if (maybe.HasNoValue)
		{
			return await valueTaskFallback;
		}
		return maybe;
	}

	public static async ValueTask<Maybe<T>> Or<T>(this Maybe<T> maybe, Func<ValueTask<Maybe<T>>> valueTaskFallbackOperation)
	{
		if (maybe.HasNoValue)
		{
			return await valueTaskFallbackOperation();
		}
		return maybe;
	}

	public static async ValueTask<Result<T>> ToResult<T>(this ValueTask<Maybe<T>> maybeTask, string errorMessage)
	{
		return (await maybeTask).ToResult<T>(errorMessage);
	}

	public static async ValueTask<Result<T, E>> ToResult<T, E>(this ValueTask<Maybe<T>> maybeTask, E error)
	{
		return (await maybeTask).ToResult<T, E>(error);
	}

	public static async ValueTask<Result<T, E>> ToResult<T, E>(this ValueTask<Maybe<T>> maybeTask, Func<E> errorFunc)
	{
		return (await maybeTask).ToResult<T, E>(errorFunc);
	}

	public static async ValueTask<UnitResult<E>> ToUnitResult<E>(this ValueTask<Maybe<E>> maybeTask)
	{
		return (await maybeTask).ToUnitResult<E>();
	}

	public static async ValueTask<UnitResult<E>> ToUnitResult<T, E>(this ValueTask<Maybe<T>> maybeTask, E error)
	{
		return (await maybeTask).ToUnitResult<T, E>(error);
	}

	public static async ValueTask<UnitResult<E>> ToUnitResult<T, E>(this ValueTask<Maybe<T>> maybeTask, Func<E> errorFunc)
	{
		return (await maybeTask).ToUnitResult<T, E>(errorFunc);
	}

	public static async ValueTask<Maybe<T>> Where<T>(this ValueTask<Maybe<T>> maybeTask, Func<T, ValueTask<bool>> predicate)
	{
		return await (await maybeTask).Where(predicate);
	}

	public static async ValueTask<Maybe<T>> Where<T>(this ValueTask<Maybe<T>> maybeTask, Func<T, bool> predicate)
	{
		return (await maybeTask).Where(predicate);
	}

	public static async ValueTask<Maybe<T>> Where<T>(this Maybe<T> maybe, Func<T, ValueTask<bool>> predicate)
	{
		if (maybe.HasNoValue)
		{
			return Maybe<T>.None;
		}
		if (await predicate(maybe.GetValueOrThrow()))
		{
			return maybe;
		}
		return Maybe<T>.None;
	}
}
