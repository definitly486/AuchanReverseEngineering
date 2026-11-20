using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpFunctionalExtensions;

public static class MaybeExtensions
{
	public static Maybe<T> AsMaybe<T>(this ref T? value) where T : struct
	{
		return Unsafe.As<T?, Maybe<T>>(ref value);
	}

	public static Maybe<T> AsMaybe<T>(this T? value) where T : class
	{
		if (value != null)
		{
			return value;
		}
		return default(Maybe<T>);
	}

	public static async Task<Maybe<T>> AsMaybe<T>(this Task<T?> nullableTask) where T : struct
	{
		T? value = await nullableTask.DefaultAwait();
		return AsMaybe(ref value);
	}

	public static async Task<Maybe<T>> AsMaybe<T>(this Task<T?> nullableTask) where T : class
	{
		return (await nullableTask.DefaultAwait()).AsMaybe();
	}

	public static T? AsNullable<T>(this ref Maybe<T> value) where T : struct
	{
		return Unsafe.As<Maybe<T>, T?>(ref value);
	}

	public static Maybe<K> Bind<T, K>(this in Maybe<T> maybe, Func<T, Maybe<K>> selector)
	{
		if (maybe.HasNoValue)
		{
			return Maybe<K>.None;
		}
		return selector(maybe.GetValueOrThrow());
	}

	public static Maybe<K> Bind<T, K, TContext>(this in Maybe<T> maybe, Func<T, TContext, Maybe<K>> selector, TContext context)
	{
		if (maybe.HasNoValue)
		{
			return Maybe<K>.None;
		}
		return selector(maybe.GetValueOrThrow(), context);
	}

	public static async Task<Maybe<K>> Bind<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Task<Maybe<K>>> selector)
	{
		return await (await maybeTask.DefaultAwait()).Bind(selector).DefaultAwait();
	}

	public static async Task<Maybe<K>> Bind<T, K, TContext>(this Task<Maybe<T>> maybeTask, Func<T, TContext, Task<Maybe<K>>> selector, TContext context)
	{
		return await (await maybeTask.DefaultAwait()).Bind(selector, context).DefaultAwait();
	}

	public static async Task<Maybe<K>> Bind<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Maybe<K>> selector)
	{
		return (await maybeTask.DefaultAwait()).Bind(selector);
	}

	public static async Task<Maybe<K>> Bind<T, K, TContext>(this Task<Maybe<T>> maybeTask, Func<T, TContext, Maybe<K>> selector, TContext context)
	{
		return (await maybeTask.DefaultAwait()).Bind(selector, context);
	}

	public static Task<Maybe<K>> Bind<T, K>(this Maybe<T> maybe, Func<T, Task<Maybe<K>>> selector)
	{
		if (maybe.HasNoValue)
		{
			return Maybe<K>.None.AsCompletedTask();
		}
		return selector(maybe.GetValueOrThrow());
	}

	public static Task<Maybe<K>> Bind<T, K, TContext>(this Maybe<T> maybe, Func<T, TContext, Task<Maybe<K>>> selector, TContext context)
	{
		if (maybe.HasNoValue)
		{
			return Maybe<K>.None.AsCompletedTask();
		}
		return selector(maybe.GetValueOrThrow(), context);
	}

	public static Result<Maybe<TOut>, TError> BindOptional<TIn, TOut, TError>(this Maybe<TIn> maybe, Func<TIn, Result<TOut, TError>> bind)
	{
		return maybe.Bind((TIn v) => Maybe.From(bind(v))).Optional();
	}

	public static IEnumerable<U> Choose<T, U>(this IEnumerable<Maybe<T>> source, Func<T, U> selector)
	{
		foreach (Maybe<T> item in source)
		{
			if (item.HasValue)
			{
				yield return selector(item.GetValueOrThrow());
			}
		}
	}

	public static IEnumerable<T> Choose<T>(this IEnumerable<Maybe<T>> source)
	{
		foreach (Maybe<T> item in source)
		{
			if (item.HasValue)
			{
				yield return item.GetValueOrThrow();
			}
		}
	}

	public static void Deconstruct<T>(this in Maybe<T> result, out bool hasValue, out T value)
	{
		hasValue = result.HasValue;
		value = result.GetValueOrDefault();
	}

	public static void Execute<T>(this in Maybe<T> maybe, Action<T> action)
	{
		if (!maybe.HasNoValue)
		{
			action(maybe.GetValueOrThrow());
		}
	}

	public static async Task Execute<T>(this Task<Maybe<T>> maybeTask, Func<T, Task> asyncAction)
	{
		Maybe<T> maybe = await maybeTask.DefaultAwait();
		if (!maybe.HasNoValue)
		{
			await asyncAction(maybe.GetValueOrThrow()).DefaultAwait();
		}
	}

	public static async Task Execute<T>(this Task<Maybe<T>> maybeTask, Action<T> action)
	{
		Maybe<T> maybe = await maybeTask.DefaultAwait();
		if (!maybe.HasNoValue)
		{
			action(maybe.GetValueOrThrow());
		}
	}

	public static async Task Execute<T>(this Maybe<T> maybe, Func<T, Task> action)
	{
		if (!maybe.HasNoValue)
		{
			await action(maybe.GetValueOrThrow()).DefaultAwait();
		}
	}

	public static void ExecuteNoValue<T>(this in Maybe<T> maybe, Action action)
	{
		if (!maybe.HasValue)
		{
			action();
		}
	}

	public static async Task ExecuteNoValue<T>(this Task<Maybe<T>> maybeTask, Func<Task> asyncAction)
	{
		if (!(await maybeTask.DefaultAwait()).HasValue)
		{
			await asyncAction().DefaultAwait();
		}
	}

	public static async Task ExecuteNoValue<T>(this Task<Maybe<T>> maybeTask, Action action)
	{
		if (!(await maybeTask.DefaultAwait()).HasValue)
		{
			action();
		}
	}

	public static async Task ExecuteNoValue<T>(this Maybe<T> maybe, Func<Task> action)
	{
		if (!maybe.HasValue)
		{
			await action().DefaultAwait();
		}
	}

	public static Maybe<T> Flatten<T>(this in Maybe<Maybe<T>> maybe)
	{
		return maybe.GetValueOrDefault();
	}

	public static T GetValueOrDefault<T>(this in Maybe<T> maybe, Func<T> defaultValue)
	{
		if (maybe.HasNoValue)
		{
			return defaultValue();
		}
		return maybe.GetValueOrThrow();
	}

	public static K GetValueOrDefault<T, K>(this in Maybe<T> maybe, Func<T, K> selector, K defaultValue = default(K))
	{
		if (maybe.HasNoValue)
		{
			return defaultValue;
		}
		return selector(maybe.GetValueOrThrow());
	}

	public static K GetValueOrDefault<T, K>(this in Maybe<T> maybe, Func<T, K> selector, Func<K> defaultValue)
	{
		if (maybe.HasNoValue)
		{
			return defaultValue();
		}
		return selector(maybe.GetValueOrThrow());
	}

	public static async Task<T> GetValueOrDefault<T>(this Task<Maybe<T>> maybeTask, Func<Task<T>> defaultValue)
	{
		return await (await maybeTask.DefaultAwait()).GetValueOrDefault(defaultValue).DefaultAwait();
	}

	public static async Task<K> GetValueOrDefault<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Task<K>> selector, K defaultValue = default(K))
	{
		return await (await maybeTask.DefaultAwait()).GetValueOrDefault(selector, defaultValue).DefaultAwait();
	}

	public static async Task<K> GetValueOrDefault<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Task<K>> selector, Func<Task<K>> defaultValue)
	{
		return await (await maybeTask.DefaultAwait()).GetValueOrDefault(selector, defaultValue).DefaultAwait();
	}

	public static async Task<T> GetValueOrDefault<T>(this Task<Maybe<T>> maybeTask, Func<T> defaultValue)
	{
		return (await maybeTask.DefaultAwait()).GetValueOrDefault(defaultValue);
	}

	public static async Task<K> GetValueOrDefault<T, K>(this Task<Maybe<T>> maybeTask, Func<T, K> selector, K defaultValue = default(K))
	{
		return (await maybeTask.DefaultAwait()).GetValueOrDefault(selector, defaultValue);
	}

	public static async Task<K> GetValueOrDefault<T, K>(this Task<Maybe<T>> maybeTask, Func<T, K> selector, Func<K> defaultValue)
	{
		return (await maybeTask.DefaultAwait()).GetValueOrDefault(selector, defaultValue);
	}

	public static async Task<T> GetValueOrDefault<T>(this Maybe<T> maybe, Func<Task<T>> defaultValue)
	{
		if (maybe.HasNoValue)
		{
			return await defaultValue().DefaultAwait();
		}
		return maybe.GetValueOrThrow();
	}

	public static async Task<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, K> selector, Func<Task<K>> defaultValue)
	{
		if (maybe.HasNoValue)
		{
			return await defaultValue().DefaultAwait();
		}
		return selector(maybe.GetValueOrThrow());
	}

	public static async Task<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, Task<K>> selector, K defaultValue = default(K))
	{
		if (maybe.HasNoValue)
		{
			return defaultValue;
		}
		return await selector(maybe.GetValueOrThrow()).DefaultAwait();
	}

	public static async Task<K> GetValueOrDefault<T, K>(this Maybe<T> maybe, Func<T, Task<K>> selector, Func<Task<K>> defaultValue)
	{
		if (maybe.HasNoValue)
		{
			return await defaultValue().DefaultAwait();
		}
		return await selector(maybe.GetValueOrThrow()).DefaultAwait();
	}

	public static async Task<T> GetValueOrThrow<T>(this Task<Maybe<T>> maybeTask)
	{
		return (await maybeTask.DefaultAwait()).GetValueOrThrow();
	}

	public static async Task<T> GetValueOrThrow<T>(this Task<Maybe<T>> maybeTask, string errorMessage)
	{
		return (await maybeTask.DefaultAwait()).GetValueOrThrow(errorMessage);
	}

	public static Maybe<K> Map<T, K>(this in Maybe<T> maybe, Func<T, K> selector)
	{
		if (maybe.HasNoValue)
		{
			return Maybe<K>.None;
		}
		return selector(maybe.GetValueOrThrow());
	}

	public static Maybe<K> Map<T, K, TContext>(this in Maybe<T> maybe, Func<T, TContext, K> selector, TContext context)
	{
		if (maybe.HasNoValue)
		{
			return Maybe<K>.None;
		}
		return selector(maybe.GetValueOrThrow(), context);
	}

	public static async Task<Maybe<K>> Map<T, K>(this Task<Maybe<T>> maybeTask, Func<T, Task<K>> selector)
	{
		return await (await maybeTask.DefaultAwait()).Map(selector).DefaultAwait();
	}

	public static async Task<Maybe<K>> Map<T, K, TContext>(this Task<Maybe<T>> maybeTask, Func<T, TContext, Task<K>> selector, TContext context)
	{
		return await (await maybeTask.DefaultAwait()).Map(selector, context).DefaultAwait();
	}

	public static async Task<Maybe<K>> Map<T, K>(this Task<Maybe<T>> maybeTask, Func<T, K> selector)
	{
		return (await maybeTask.DefaultAwait()).Map(selector);
	}

	public static async Task<Maybe<K>> Map<T, K, TContext>(this Task<Maybe<T>> maybeTask, Func<T, TContext, K> selector, TContext context)
	{
		return (await maybeTask.DefaultAwait()).Map(selector, context);
	}

	public static async Task<Maybe<K>> Map<T, K>(this Maybe<T> maybe, Func<T, Task<K>> selector)
	{
		if (maybe.HasNoValue)
		{
			return Maybe<K>.None;
		}
		return await selector(maybe.GetValueOrThrow()).DefaultAwait();
	}

	public static async Task<Maybe<K>> Map<T, K, TContext>(this Maybe<T> maybe, Func<T, TContext, Task<K>> selector, TContext context)
	{
		if (maybe.HasNoValue)
		{
			return Maybe<K>.None;
		}
		return await selector(maybe.GetValueOrThrow(), context).DefaultAwait();
	}

	public static TE Match<TE, T>(this in Maybe<T> maybe, Func<T, TE> Some, Func<TE> None)
	{
		if (!maybe.HasValue)
		{
			return None();
		}
		return Some(maybe.GetValueOrThrow());
	}

	public static TE Match<TE, T, TContext>(this in Maybe<T> maybe, Func<T, TContext, TE> Some, Func<TContext, TE> None, TContext context)
	{
		if (!maybe.HasValue)
		{
			return None(context);
		}
		return Some(maybe.GetValueOrThrow(), context);
	}

	public static void Match<T>(this in Maybe<T> maybe, Action<T> Some, Action None)
	{
		if (maybe.HasValue)
		{
			Some(maybe.GetValueOrThrow());
		}
		else
		{
			None();
		}
	}

	public static void Match<T, TContext>(this in Maybe<T> maybe, Action<T, TContext> Some, Action<TContext> None, TContext context)
	{
		if (maybe.HasValue)
		{
			Some(maybe.GetValueOrThrow(), context);
		}
		else
		{
			None(context);
		}
	}

	public static TE Match<TE, TKey, TValue>(this in Maybe<KeyValuePair<TKey, TValue>> maybe, Func<TKey, TValue, TE> Some, Func<TE> None)
	{
		if (!maybe.HasValue)
		{
			return None();
		}
		return Some(maybe.GetValueOrThrow().Key, maybe.GetValueOrThrow().Value);
	}

	public static TE Match<TE, TKey, TValue, TContext>(this in Maybe<KeyValuePair<TKey, TValue>> maybe, Func<TKey, TValue, TContext, TE> Some, Func<TContext, TE> None, TContext context)
	{
		if (!maybe.HasValue)
		{
			return None(context);
		}
		return Some(maybe.GetValueOrThrow().Key, maybe.GetValueOrThrow().Value, context);
	}

	public static void Match<TKey, TValue>(this in Maybe<KeyValuePair<TKey, TValue>> maybe, Action<TKey, TValue> Some, Action None)
	{
		if (maybe.HasValue)
		{
			Some(maybe.GetValueOrThrow().Key, maybe.GetValueOrThrow().Value);
		}
		else
		{
			None();
		}
	}

	public static void Match<TKey, TValue, TContext>(this in Maybe<KeyValuePair<TKey, TValue>> maybe, Action<TKey, TValue, TContext> Some, Action<TContext> None, TContext context)
	{
		if (maybe.HasValue)
		{
			Some(maybe.GetValueOrThrow().Key, maybe.GetValueOrThrow().Value, context);
		}
		else
		{
			None(context);
		}
	}

	public static async Task<TE> Match<TE, T>(this Maybe<T> maybe, Func<T, CancellationToken, Task<TE>> Some, Func<CancellationToken, Task<TE>> None, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (!maybe.HasValue) ? (await None(cancellationToken)) : (await Some(maybe.GetValueOrThrow(), cancellationToken));
	}

	public static async Task<TE> Match<TE, T, TContext>(this Maybe<T> maybe, Func<T, TContext, CancellationToken, Task<TE>> Some, Func<TContext, CancellationToken, Task<TE>> None, TContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (!maybe.HasValue) ? (await None(context, cancellationToken)) : (await Some(maybe.GetValueOrThrow(), context, cancellationToken));
	}

	public static async Task Match<T>(this Maybe<T> maybe, Func<T, CancellationToken, Task> Some, Func<CancellationToken, Task> None, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (maybe.HasValue)
		{
			await Some(maybe.GetValueOrThrow(), cancellationToken);
		}
		else
		{
			await None(cancellationToken);
		}
	}

	public static async Task Match<T, TContext>(this Maybe<T> maybe, Func<T, TContext, CancellationToken, Task> Some, Func<TContext, CancellationToken, Task> None, TContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (maybe.HasValue)
		{
			await Some(maybe.GetValueOrThrow(), context, cancellationToken);
		}
		else
		{
			await None(context, cancellationToken);
		}
	}

	public static async Task<TE> Match<TE, TKey, TValue>(this Maybe<KeyValuePair<TKey, TValue>> maybe, Func<TKey, TValue, CancellationToken, Task<TE>> Some, Func<CancellationToken, Task<TE>> None, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (!maybe.HasValue) ? (await None(cancellationToken)) : (await Some(maybe.GetValueOrThrow().Key, maybe.GetValueOrThrow().Value, cancellationToken));
	}

	public static async Task<TE> Match<TE, TKey, TValue, TContext>(this Maybe<KeyValuePair<TKey, TValue>> maybe, Func<TKey, TValue, TContext, CancellationToken, Task<TE>> Some, Func<TContext, CancellationToken, Task<TE>> None, TContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (!maybe.HasValue) ? (await None(context, cancellationToken)) : (await Some(maybe.GetValueOrThrow().Key, maybe.GetValueOrThrow().Value, context, cancellationToken));
	}

	public static async Task Match<TKey, TValue>(this Maybe<KeyValuePair<TKey, TValue>> maybe, Func<TKey, TValue, CancellationToken, Task> Some, Func<CancellationToken, Task> None, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (maybe.HasValue)
		{
			await Some(maybe.GetValueOrThrow().Key, maybe.GetValueOrThrow().Value, cancellationToken);
		}
		else
		{
			await None(cancellationToken);
		}
	}

	public static async Task Match<TKey, TValue, TContext>(this Maybe<KeyValuePair<TKey, TValue>> maybe, Func<TKey, TValue, TContext, CancellationToken, Task> Some, Func<TContext, CancellationToken, Task> None, TContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (maybe.HasValue)
		{
			await Some(maybe.GetValueOrThrow().Key, maybe.GetValueOrThrow().Value, context, cancellationToken);
		}
		else
		{
			await None(context, cancellationToken);
		}
	}

	public static async ValueTask<TE> Match<TE, T>(this Maybe<T> maybe, Func<T, CancellationToken, ValueTask<TE>> Some, Func<CancellationToken, ValueTask<TE>> None, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (!maybe.HasValue) ? (await None(cancellationToken)) : (await Some(maybe.GetValueOrThrow(), cancellationToken));
	}

	public static async ValueTask<TE> Match<TE, T, TContext>(this Maybe<T> maybe, Func<T, TContext, CancellationToken, ValueTask<TE>> Some, Func<TContext, CancellationToken, ValueTask<TE>> None, TContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (!maybe.HasValue) ? (await None(context, cancellationToken)) : (await Some(maybe.GetValueOrThrow(), context, cancellationToken));
	}

	public static async ValueTask Match<T>(this Maybe<T> maybe, Func<T, CancellationToken, ValueTask> Some, Func<CancellationToken, ValueTask> None, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (maybe.HasValue)
		{
			await Some(maybe.GetValueOrThrow(), cancellationToken);
		}
		else
		{
			await None(cancellationToken);
		}
	}

	public static async ValueTask Match<T, TContext>(this Maybe<T> maybe, Func<T, TContext, CancellationToken, ValueTask> Some, Func<TContext, CancellationToken, ValueTask> None, TContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (maybe.HasValue)
		{
			await Some(maybe.GetValueOrThrow(), context, cancellationToken);
		}
		else
		{
			await None(context, cancellationToken);
		}
	}

	public static async ValueTask<TE> Match<TE, TKey, TValue>(this Maybe<KeyValuePair<TKey, TValue>> maybe, Func<TKey, TValue, CancellationToken, ValueTask<TE>> Some, Func<CancellationToken, ValueTask<TE>> None, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (!maybe.HasValue) ? (await None(cancellationToken)) : (await Some(maybe.GetValueOrThrow().Key, maybe.GetValueOrThrow().Value, cancellationToken));
	}

	public static async ValueTask<TE> Match<TE, TKey, TValue, TContext>(this Maybe<KeyValuePair<TKey, TValue>> maybe, Func<TKey, TValue, TContext, CancellationToken, ValueTask<TE>> Some, Func<TContext, CancellationToken, ValueTask<TE>> None, TContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (!maybe.HasValue) ? (await None(context, cancellationToken)) : (await Some(maybe.GetValueOrThrow().Key, maybe.GetValueOrThrow().Value, context, cancellationToken));
	}

	public static async ValueTask Match<TKey, TValue>(this Maybe<KeyValuePair<TKey, TValue>> maybe, Func<TKey, TValue, CancellationToken, ValueTask> Some, Func<CancellationToken, ValueTask> None, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (maybe.HasValue)
		{
			await Some(maybe.GetValueOrThrow().Key, maybe.GetValueOrThrow().Value, cancellationToken);
		}
		else
		{
			await None(cancellationToken);
		}
	}

	public static async ValueTask Match<TKey, TValue, TContext>(this Maybe<KeyValuePair<TKey, TValue>> maybe, Func<TKey, TValue, TContext, CancellationToken, ValueTask> Some, Func<TContext, CancellationToken, ValueTask> None, TContext context, CancellationToken cancellationToken = default(CancellationToken))
	{
		if (maybe.HasValue)
		{
			await Some(maybe.GetValueOrThrow().Key, maybe.GetValueOrThrow().Value, context, cancellationToken);
		}
		else
		{
			await None(context, cancellationToken);
		}
	}

	public static Result<Maybe<T>, E> Optional<T, E>(this Maybe<Result<T, E>> maybe)
	{
		if (maybe.HasNoValue)
		{
			return Result.Success<Maybe<T>, E>(Maybe<T>.None);
		}
		if (maybe.Value.IsFailure)
		{
			return Result.Failure<Maybe<T>, E>(maybe.Value.Error);
		}
		return Result.Success<Maybe<T>, E>(Maybe.From(maybe.Value.Value));
	}

	public static Result<Maybe<T>> Optional<T>(this Maybe<Result<T>> maybe)
	{
		if (maybe.HasNoValue)
		{
			return Result.Success(Maybe<T>.None);
		}
		if (maybe.Value.IsFailure)
		{
			return Result.Failure<Maybe<T>>(maybe.Value.Error);
		}
		return Result.Success(Maybe.From(maybe.Value.Value));
	}

	public static Maybe<T> Or<T>(this in Maybe<T> maybe, Func<T> fallbackOperation)
	{
		if (maybe.HasNoValue)
		{
			return fallbackOperation();
		}
		return maybe;
	}

	public static Maybe<T> Or<T>(this in Maybe<T> maybe, Maybe<T> fallback)
	{
		if (maybe.HasNoValue)
		{
			return fallback;
		}
		return maybe;
	}

	public static Maybe<T> Or<T>(this in Maybe<T> maybe, Func<Maybe<T>> fallbackOperation)
	{
		if (maybe.HasNoValue)
		{
			return fallbackOperation();
		}
		return maybe;
	}

	public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Task<T> fallback)
	{
		Maybe<T> result = await maybeTask.DefaultAwait();
		if (result.HasNoValue)
		{
			return Maybe<T>.From(await fallback.DefaultAwait());
		}
		return result;
	}

	public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Func<Task<T>> fallbackOperation)
	{
		Maybe<T> result = await maybeTask.DefaultAwait();
		if (result.HasNoValue)
		{
			return Maybe<T>.From(await fallbackOperation().DefaultAwait());
		}
		return result;
	}

	public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Func<Maybe<T>> fallbackOperation)
	{
		Maybe<T> result = await maybeTask.DefaultAwait();
		if (result.HasNoValue)
		{
			return fallbackOperation();
		}
		return result;
	}

	public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Func<Task<Maybe<T>>> fallbackOperation)
	{
		Maybe<T> result = await maybeTask.DefaultAwait();
		if (result.HasNoValue)
		{
			return await fallbackOperation().DefaultAwait();
		}
		return result;
	}

	public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, T fallback)
	{
		Maybe<T> result = await maybeTask.DefaultAwait();
		if (result.HasNoValue)
		{
			return Maybe<T>.From(fallback);
		}
		return result;
	}

	public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Func<T> fallbackOperation)
	{
		Maybe<T> result = await maybeTask.DefaultAwait();
		if (result.HasNoValue)
		{
			return Maybe<T>.From(fallbackOperation());
		}
		return result;
	}

	public static async Task<Maybe<T>> Or<T>(this Task<Maybe<T>> maybeTask, Maybe<T> fallback)
	{
		Maybe<T> result = await maybeTask.DefaultAwait();
		if (result.HasNoValue)
		{
			return fallback;
		}
		return result;
	}

	public static async Task<Maybe<T>> Or<T>(this Maybe<T> maybe, Func<Task<T>> fallbackOperation)
	{
		if (maybe.HasNoValue)
		{
			return await fallbackOperation().DefaultAwait();
		}
		return maybe;
	}

	public static async Task<Maybe<T>> Or<T>(this Maybe<T> maybe, Task<Maybe<T>> fallback)
	{
		if (maybe.HasNoValue)
		{
			return await fallback.DefaultAwait();
		}
		return maybe;
	}

	public static async Task<Maybe<T>> Or<T>(this Maybe<T> maybe, Func<Task<Maybe<T>>> fallbackOperation)
	{
		if (maybe.HasNoValue)
		{
			return await fallbackOperation().DefaultAwait();
		}
		return maybe;
	}

	public static Maybe<K> Select<T, K>(this in Maybe<T> maybe, Func<T, K> selector)
	{
		return maybe.Map(selector);
	}

	public static Maybe<K> SelectMany<T, K>(this in Maybe<T> maybe, Func<T, Maybe<K>> selector)
	{
		return maybe.Bind(selector);
	}

	public static Maybe<V> SelectMany<T, U, V>(this in Maybe<T> maybe, Func<T, Maybe<U>> selector, Func<T, U, V> project)
	{
		return maybe.GetValueOrDefault((T x) => selector(x).GetValueOrDefault((U u) => project(x, u), Maybe<V>.None), Maybe<V>.None);
	}

	public static Result ToInvertedResult<T>(this in Maybe<T> maybe, string errorMessage)
	{
		if (maybe.HasValue)
		{
			return Result.Failure<T>(errorMessage);
		}
		return Result.Success();
	}

	public static UnitResult<E> ToInvertedResult<T, E>(this in Maybe<T> maybe, E error)
	{
		if (maybe.HasValue)
		{
			return UnitResult.Failure(in error);
		}
		return UnitResult.Success<E>();
	}

	public static UnitResult<E> ToInvertedResult<T, E>(this in Maybe<T> maybe, Func<E> errorFunc)
	{
		if (maybe.HasValue)
		{
			return UnitResult.Failure<E>(errorFunc());
		}
		return UnitResult.Success<E>();
	}

	public static async Task<Result> ToInvertedResult<T>(this Task<Maybe<T>> maybeTask, string errorMessage)
	{
		return (await maybeTask.DefaultAwait()).ToInvertedResult<T>(errorMessage);
	}

	public static async Task<UnitResult<E>> ToInvertedResult<T, E>(this Task<Maybe<T>> maybeTask, E error)
	{
		return (await maybeTask.DefaultAwait()).ToInvertedResult<T, E>(error);
	}

	public static async Task<UnitResult<E>> ToInvertedResult<T, E>(this Task<Maybe<T>> maybeTask, Func<E> errorFunc)
	{
		return (await maybeTask.DefaultAwait()).ToInvertedResult<T, E>(errorFunc);
	}

	public static async ValueTask<Result> ToInvertedResult<T>(this ValueTask<Maybe<T>> maybeTask, string errorMessage)
	{
		return (await maybeTask).ToInvertedResult<T>(errorMessage);
	}

	public static async ValueTask<UnitResult<E>> ToInvertedResult<T, E>(this ValueTask<Maybe<T>> maybeTask, E error)
	{
		return (await maybeTask).ToInvertedResult<T, E>(error);
	}

	public static async ValueTask<UnitResult<E>> ToInvertedResult<T, E>(this ValueTask<Maybe<T>> maybeTask, Func<E> errorFunc)
	{
		return (await maybeTask).ToInvertedResult<T, E>(errorFunc);
	}

	public static List<T> ToList<T>(this in Maybe<T> maybe)
	{
		return maybe.GetValueOrDefault((T value) => new List<T> { value }, new List<T>());
	}

	public static Result<T> ToResult<T>(this in Maybe<T> maybe, string errorMessage)
	{
		if (maybe.HasNoValue)
		{
			return Result.Failure<T>(errorMessage);
		}
		return Result.Success(maybe.GetValueOrThrow());
	}

	public static Result<T, E> ToResult<T, E>(this in Maybe<T> maybe, E error)
	{
		if (maybe.HasNoValue)
		{
			return Result.Failure<T, E>(error);
		}
		return Result.Success<T, E>(maybe.GetValueOrThrow());
	}

	public static Result<T, E> ToResult<T, E>(this in Maybe<T> maybe, Func<E> errorFunc)
	{
		if (maybe.HasNoValue)
		{
			return Result.Failure<T, E>(errorFunc());
		}
		return Result.Success<T, E>(maybe.GetValueOrThrow());
	}

	public static async Task<Result<T>> ToResult<T>(this Task<Maybe<T>> maybeTask, string errorMessage)
	{
		return (await maybeTask.DefaultAwait()).ToResult<T>(errorMessage);
	}

	public static async Task<Result<T, E>> ToResult<T, E>(this Task<Maybe<T>> maybeTask, E error)
	{
		return (await maybeTask.DefaultAwait()).ToResult<T, E>(error);
	}

	public static async Task<Result<T, E>> ToResult<T, E>(this Task<Maybe<T>> maybeTask, Func<E> errorFunc)
	{
		return (await maybeTask.DefaultAwait()).ToResult<T, E>(errorFunc);
	}

	public static UnitResult<E> ToUnitResult<E>(this in Maybe<E> maybe)
	{
		if (maybe.HasValue)
		{
			return UnitResult.Failure<E>(maybe.Value);
		}
		return UnitResult.Success<E>();
	}

	public static UnitResult<E> ToUnitResult<T, E>(this in Maybe<T> maybe, E error)
	{
		if (maybe.HasNoValue)
		{
			return UnitResult.Failure(in error);
		}
		return UnitResult.Success<E>();
	}

	public static UnitResult<E> ToUnitResult<T, E>(this in Maybe<T> maybe, Func<E> errorFunc)
	{
		if (maybe.HasNoValue)
		{
			return UnitResult.Failure<E>(errorFunc());
		}
		return UnitResult.Success<E>();
	}

	public static async Task<UnitResult<E>> ToUnitResult<E>(this Task<Maybe<E>> maybeTask)
	{
		return (await maybeTask.DefaultAwait()).ToUnitResult<E>();
	}

	public static async Task<UnitResult<E>> ToUnitResult<T, E>(this Task<Maybe<T>> maybeTask, E error)
	{
		return (await maybeTask.DefaultAwait()).ToUnitResult<T, E>(error);
	}

	public static async Task<UnitResult<E>> ToUnitResult<T, E>(this Task<Maybe<T>> maybeTask, Func<E> errorFunc)
	{
		return (await maybeTask.DefaultAwait()).ToUnitResult<T, E>(errorFunc);
	}

	public static Maybe<V> TryFind<K, V>(this IReadOnlyDictionary<K, V> dict, K key)
	{
		if (dict.ContainsKey(key))
		{
			return dict[key];
		}
		return Maybe<V>.None;
	}

	public static Maybe<T> TryFirst<T>(this IEnumerable<T> source)
	{
		source = (source as ICollection<T>) ?? source.ToList();
		if (source.Any())
		{
			return Maybe<T>.From(source.First());
		}
		return Maybe<T>.None;
	}

	public static Maybe<T> TryFirst<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		List<T> list = source.Where(predicate).Take(1).ToList();
		if (list.Any())
		{
			return Maybe<T>.From(list[0]);
		}
		return Maybe<T>.None;
	}

	public static Maybe<T> TryLast<T>(this IEnumerable<T> source)
	{
		source = (source as ICollection<T>) ?? source.ToList();
		if (source.Any())
		{
			return Maybe<T>.From(source.Last());
		}
		return Maybe<T>.None;
	}

	public static Maybe<T> TryLast<T>(this IEnumerable<T> source, Func<T, bool> predicate)
	{
		T val = source.LastOrDefault(predicate);
		if (val != null)
		{
			return Maybe<T>.From(val);
		}
		return Maybe<T>.None;
	}

	public static Maybe<T> Where<T>(this in Maybe<T> maybe, Func<T, bool> predicate)
	{
		if (maybe.HasNoValue)
		{
			return Maybe<T>.None;
		}
		if (predicate(maybe.GetValueOrThrow()))
		{
			return maybe;
		}
		return Maybe<T>.None;
	}

	public static async Task<Maybe<T>> Where<T>(this Task<Maybe<T>> maybeTask, Func<T, Task<bool>> predicate)
	{
		return await (await maybeTask.DefaultAwait()).Where(predicate).DefaultAwait();
	}

	public static async Task<Maybe<T>> Where<T>(this Task<Maybe<T>> maybeTask, Func<T, bool> predicate)
	{
		return (await maybeTask.DefaultAwait()).Where(predicate);
	}

	public static async Task<Maybe<T>> Where<T>(this Maybe<T> maybe, Func<T, Task<bool>> predicate)
	{
		if (maybe.HasNoValue)
		{
			return Maybe<T>.None;
		}
		if (await predicate(maybe.GetValueOrThrow()).DefaultAwait())
		{
			return maybe;
		}
		return Maybe<T>.None;
	}
}
