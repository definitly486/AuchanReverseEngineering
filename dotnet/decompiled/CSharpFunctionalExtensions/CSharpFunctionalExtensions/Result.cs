using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CSharpFunctionalExtensions.Internal;

namespace CSharpFunctionalExtensions;

[Serializable]
public readonly struct Result : IResult, ISerializable, IError<string>
{
	internal static class Messages
	{
		public static readonly string ErrorIsInaccessibleForSuccess = "You attempted to access the Error property for a successful result. A successful result has no Error.";

		public static readonly string ErrorObjectIsNotProvidedForFailure = "You attempted to create a failure result, which must have an error, but a null error object (or empty string) was passed to the constructor.";

		public static readonly string ErrorObjectIsProvidedForSuccess = "You attempted to create a success result, which cannot have an error, but a non-null error object was passed to the constructor.";

		public static readonly string ConvertFailureExceptionOnSuccess = "ConvertFailure failed because the Result is in a success state.";

		public static string ValueIsInaccessibleForFailure(string error)
		{
			return "You attempted to access the Value property for a failed result. A failed result has no Value. The error was: " + error;
		}
	}

	public static class Configuration
	{
		public static string ErrorMessagesSeparator = ", ";

		public static bool DefaultConfigureAwait = false;

		public static Func<Exception, string> DefaultTryErrorHandler = (Exception exc) => exc.Message;
	}

	private readonly string _error;

	public bool IsFailure { get; }

	public bool IsSuccess => !IsFailure;

	public string Error => ResultCommonLogic.GetErrorWithSuccessGuard(IsFailure, _error);

	public static Result Combine(IEnumerable<Result> results, string errorMessagesSeparator = null)
	{
		List<Result> list = results.Where((Result x) => x.IsFailure).ToList();
		if (list.Count == 0)
		{
			return Success();
		}
		return Failure(string.Join(errorMessagesSeparator ?? Configuration.ErrorMessagesSeparator, AggregateMessages(list.Select((Result x) => x.Error))));
	}

	public static Result Combine<T>(IEnumerable<Result<T>> results, string errorMessagesSeparator = null)
	{
		return Combine(results.Select((Func<Result<T>, Result>)((Result<T> result) => result)), errorMessagesSeparator);
	}

	public static UnitResult<E> Combine<E>(IEnumerable<UnitResult<E>> results, Func<IEnumerable<E>, E> composerError)
	{
		List<UnitResult<E>> list = results.Where((UnitResult<E> x) => x.IsFailure).ToList();
		if (list.Count == 0)
		{
			return UnitResult.Success<E>();
		}
		return UnitResult.Failure<E>(composerError(list.Select((UnitResult<E> x) => x.Error)));
	}

	public static UnitResult<E> Combine<E>(Func<IEnumerable<E>, E> composerError, params UnitResult<E>[] results)
	{
		return Combine(results, composerError);
	}

	public static UnitResult<E> Combine<E>(params UnitResult<E>[] results) where E : ICombine
	{
		return Combine(results, CombineErrors);
	}

	public static UnitResult<E> Combine<E>(IEnumerable<UnitResult<E>> results) where E : ICombine
	{
		return Combine(results, CombineErrors);
	}

	public static Result<bool, E> Combine<T, E>(IEnumerable<Result<T, E>> results, Func<IEnumerable<E>, E> composerError)
	{
		UnitResult<E> unitResult = Combine(results.Select((Func<Result<T, E>, UnitResult<E>>)((Result<T, E> r) => r)), composerError);
		if (!unitResult.IsSuccess)
		{
			return Failure<bool, E>(unitResult.Error);
		}
		return Success<bool, E>(value: true);
	}

	public static Result<bool, E> Combine<T, E>(IEnumerable<Result<T, E>> results) where E : ICombine
	{
		return Combine(results, CombineErrors);
	}

	public static Result Combine(params Result[] results)
	{
		return Combine(results, Configuration.ErrorMessagesSeparator);
	}

	public static Result Combine<T>(params Result<T>[] results)
	{
		return Combine(results, Configuration.ErrorMessagesSeparator);
	}

	public static Result<bool, E> Combine<T, E>(params Result<T, E>[] results) where E : ICombine
	{
		return Combine(results, CombineErrors);
	}

	public static Result Combine(string errorMessagesSeparator, params Result[] results)
	{
		return Combine(results, errorMessagesSeparator);
	}

	public static Result Combine<T>(string errorMessagesSeparator, params Result<T>[] results)
	{
		return Combine(results, errorMessagesSeparator);
	}

	public static Result<bool, E> Combine<T, E>(Func<IEnumerable<E>, E> composerError, params Result<T, E>[] results)
	{
		return Combine(results, composerError);
	}

	private static E CombineErrors<E>(IEnumerable<E> errors) where E : ICombine
	{
		return errors.Aggregate((E x, E y) => (E)x.Combine(y));
	}

	private static IEnumerable<string> AggregateMessages(IEnumerable<string> messages)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		foreach (string message in messages)
		{
			if (!dictionary.ContainsKey(message))
			{
				dictionary.Add(message, 0);
			}
			dictionary[message]++;
		}
		return dictionary.Select((KeyValuePair<string, int> x) => (x.Value != 1) ? $"{x.Key} ({x.Value}×)" : x.Key);
	}

	public Result<K> ConvertFailure<K>()
	{
		if (IsSuccess)
		{
			throw new InvalidOperationException(Messages.ConvertFailureExceptionOnSuccess);
		}
		return Failure<K>(Error);
	}

	public static Result Failure(string error)
	{
		return new Result(isFailure: true, error);
	}

	public static Result<T> Failure<T>(string error)
	{
		return new Result<T>(isFailure: true, error, default(T));
	}

	public static Result<T, E> Failure<T, E>(E error)
	{
		return new Result<T, E>(isFailure: true, error, default(T));
	}

	public static Result FailureIf(bool isFailure, string error)
	{
		return SuccessIf(!isFailure, error);
	}

	public static Result FailureIf(Func<bool> failurePredicate, string error)
	{
		return SuccessIf(!failurePredicate(), error);
	}

	public static Result<T> FailureIf<T>(bool isFailure, T value, string error)
	{
		return SuccessIf(!isFailure, in value, error);
	}

	public static Result<T> FailureIf<T>(Func<bool> failurePredicate, in T value, string error)
	{
		return SuccessIf(!failurePredicate(), in value, error);
	}

	public static Result<T, E> FailureIf<T, E>(bool isFailure, in T value, in E error)
	{
		return SuccessIf(!isFailure, in value, in error);
	}

	public static Result<T, E> FailureIf<T, E>(Func<bool> failurePredicate, in T value, in E error)
	{
		return SuccessIf(!failurePredicate(), in value, in error);
	}

	public static async Task<Result> FailureIf(Func<Task<bool>> failurePredicate, string error)
	{
		return SuccessIf(!(await failurePredicate().DefaultAwait()), error);
	}

	public static async Task<Result<T>> FailureIf<T>(Func<Task<bool>> failurePredicate, T value, string error)
	{
		return SuccessIf(!(await failurePredicate().DefaultAwait()), in value, error);
	}

	public static async Task<Result<T, E>> FailureIf<T, E>(Func<Task<bool>> failurePredicate, T value, E error)
	{
		return SuccessIf(!(await failurePredicate().DefaultAwait()), in value, in error);
	}

	public static async ValueTask<Result> FailureIf(Func<ValueTask<bool>> failurePredicate, string error)
	{
		return SuccessIf(!(await failurePredicate()), error);
	}

	public static async ValueTask<Result<T>> FailureIf<T>(Func<ValueTask<bool>> failurePredicate, T value, string error)
	{
		return SuccessIf(!(await failurePredicate()), in value, error);
	}

	public static async ValueTask<Result<T, E>> FailureIf<T, E>(Func<ValueTask<bool>> failurePredicate, T value, E error)
	{
		return SuccessIf(!(await failurePredicate()), in value, in error);
	}

	public static Result FirstFailureOrSuccess(params Result[] results)
	{
		for (int i = 0; i < results.Length; i++)
		{
			Result result = results[i];
			if (result.IsFailure)
			{
				return result;
			}
		}
		return Success();
	}

	public static Result<T> Of<T>(T value) where T : notnull
	{
		return new Result<T>(isFailure: false, null, value);
	}

	public static Result<T> Of<T>(Func<T> func) where T : notnull
	{
		T value = func();
		return new Result<T>(isFailure: false, null, value);
	}

	public static async Task<Result<T>> Of<T>(Task<T> valueTask) where T : notnull
	{
		return new Result<T>(isFailure: false, null, await valueTask);
	}

	public static async Task<Result<T>> Of<T>(Func<Task<T>> valueTaskFunc) where T : notnull
	{
		return new Result<T>(isFailure: false, null, await valueTaskFunc());
	}

	public static Result<T, E> Of<T, E>(T value) where T : notnull
	{
		return new Result<T, E>(isFailure: false, default(E), value);
	}

	public static Result<T, E> Of<T, E>(Func<T> func) where T : notnull
	{
		T value = func();
		return new Result<T, E>(isFailure: false, default(E), value);
	}

	public static async Task<Result<T, E>> Of<T, E>(Task<T> valueTask) where T : notnull
	{
		return new Result<T, E>(isFailure: false, default(E), await valueTask);
	}

	public static async Task<Result<T, E>> Of<T, E>(Func<Task<T>> valueTaskFunc) where T : notnull
	{
		return new Result<T, E>(isFailure: false, default(E), await valueTaskFunc());
	}

	public static Result Success()
	{
		return new Result(isFailure: false, null);
	}

	public static Result<T> Success<T>(T value)
	{
		return new Result<T>(isFailure: false, null, value);
	}

	public static Result<T, E> Success<T, E>(T value)
	{
		return new Result<T, E>(isFailure: false, default(E), value);
	}

	public static UnitResult<E> Success<E>()
	{
		return new UnitResult<E>(isFailure: false, default(E));
	}

	public static Result SuccessIf(bool isSuccess, string error)
	{
		if (!isSuccess)
		{
			return Failure(error);
		}
		return Success();
	}

	public static Result SuccessIf(Func<bool> predicate, string error)
	{
		return SuccessIf(predicate(), error);
	}

	public static Result<T> SuccessIf<T>(bool isSuccess, in T value, string error)
	{
		if (!isSuccess)
		{
			return Failure<T>(error);
		}
		return Success(value);
	}

	public static Result<T> SuccessIf<T>(Func<bool> predicate, in T value, string error)
	{
		return SuccessIf(predicate(), in value, error);
	}

	public static Result<T, E> SuccessIf<T, E>(bool isSuccess, in T value, in E error)
	{
		if (!isSuccess)
		{
			return Failure<T, E>(error);
		}
		return Success<T, E>(value);
	}

	public static Result<T, E> SuccessIf<T, E>(Func<bool> predicate, in T value, in E error)
	{
		return SuccessIf(predicate(), in value, in error);
	}

	public static async Task<Result> SuccessIf(Func<Task<bool>> predicate, string error)
	{
		return SuccessIf(await predicate().DefaultAwait(), error);
	}

	public static async Task<Result<T>> SuccessIf<T>(Func<Task<bool>> predicate, T value, string error)
	{
		return SuccessIf(await predicate().DefaultAwait(), in value, error);
	}

	public static async Task<Result<T, E>> SuccessIf<T, E>(Func<Task<bool>> predicate, T value, E error)
	{
		return SuccessIf(await predicate().DefaultAwait(), in value, in error);
	}

	public static async ValueTask<Result> SuccessIf(Func<ValueTask<bool>> predicate, string error)
	{
		return SuccessIf(await predicate(), error);
	}

	public static async ValueTask<Result<T>> SuccessIf<T>(Func<ValueTask<bool>> predicate, T value, string error)
	{
		return SuccessIf(await predicate(), in value, error);
	}

	public static async ValueTask<Result<T, E>> SuccessIf<T, E>(Func<ValueTask<bool>> predicate, T value, E error)
	{
		return SuccessIf(await predicate(), in value, in error);
	}

	public override string ToString()
	{
		if (!IsSuccess)
		{
			return "Failure(" + Error + ")";
		}
		return "Success";
	}

	public static Result Try(Action action, Func<Exception, string> errorHandler = null)
	{
		if (errorHandler == null)
		{
			errorHandler = Configuration.DefaultTryErrorHandler;
		}
		try
		{
			action();
			return Success();
		}
		catch (Exception arg)
		{
			return Failure(errorHandler(arg));
		}
	}

	public static Result<T> Try<T>(Func<T> func, Func<Exception, string> errorHandler = null)
	{
		if (errorHandler == null)
		{
			errorHandler = Configuration.DefaultTryErrorHandler;
		}
		try
		{
			return Success(func());
		}
		catch (Exception arg)
		{
			return Failure<T>(errorHandler(arg));
		}
	}

	public static Result<T, E> Try<T, E>(Func<T> func, Func<Exception, E> errorHandler)
	{
		try
		{
			return Success<T, E>(func());
		}
		catch (Exception arg)
		{
			return Failure<T, E>(errorHandler(arg));
		}
	}

	public static UnitResult<E> Try<E>(Action action, Func<Exception, E> errorHandler)
	{
		try
		{
			action();
			return UnitResult.Success<E>();
		}
		catch (Exception arg)
		{
			return UnitResult.Failure<E>(errorHandler(arg));
		}
	}

	public static async Task<UnitResult<E>> Try<E>(Func<Task> action, Func<Exception, E> errorHandler)
	{
		try
		{
			await action().DefaultAwait();
			return UnitResult.Success<E>();
		}
		catch (Exception arg)
		{
			return UnitResult.Failure<E>(errorHandler(arg));
		}
	}

	public static async Task<Result> Try(Func<Task> action, Func<Exception, string> errorHandler = null)
	{
		if (errorHandler == null)
		{
			errorHandler = Configuration.DefaultTryErrorHandler;
		}
		try
		{
			await action().DefaultAwait();
			return Success();
		}
		catch (Exception arg)
		{
			return Failure(errorHandler(arg));
		}
	}

	public static async Task<Result<T>> Try<T>(Func<Task<T>> func, Func<Exception, string> errorHandler = null)
	{
		if (errorHandler == null)
		{
			errorHandler = Configuration.DefaultTryErrorHandler;
		}
		try
		{
			return Success(await func().DefaultAwait());
		}
		catch (Exception arg)
		{
			return Failure<T>(errorHandler(arg));
		}
	}

	public static async Task<Result<T, E>> Try<T, E>(Func<Task<T>> func, Func<Exception, E> errorHandler)
	{
		try
		{
			return Success<T, E>(await func().DefaultAwait());
		}
		catch (Exception arg)
		{
			return Failure<T, E>(errorHandler(arg));
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryGetError([NotNullWhen(true)][MaybeNullWhen(false)] out string error)
	{
		error = _error;
		return IsFailure;
	}

	private Result(bool isFailure, string error)
	{
		IsFailure = ResultCommonLogic.ErrorStateGuard(isFailure, error);
		_error = error;
	}

	private Result(SerializationInfo info, StreamingContext context)
	{
		SerializationValue<string> serializationValue = ResultCommonLogic.Deserialize(info);
		IsFailure = serializationValue.IsFailure;
		_error = serializationValue.Error;
	}

	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		ResultCommonLogic.GetObjectData(this, info);
	}

	public static implicit operator UnitResult<string>(Result result)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<string>();
		}
		return UnitResult.Failure<string>(result.Error);
	}
}
[Serializable]
public readonly struct Result<T> : IResult<T>, IResult<T, string>, IValue<T>, IUnitResult<string>, IResult, IError<string>, ISerializable
{
	private readonly string _error;

	private readonly T _value;

	public bool IsFailure { get; }

	public bool IsSuccess => !IsFailure;

	public string Error => ResultCommonLogic.GetErrorWithSuccessGuard(IsFailure, _error);

	public T Value
	{
		get
		{
			if (!IsSuccess)
			{
				throw new ResultFailureException(Error);
			}
			return _value;
		}
	}

	public Result ConvertFailure()
	{
		if (IsSuccess)
		{
			throw new InvalidOperationException(Result.Messages.ConvertFailureExceptionOnSuccess);
		}
		return Result.Failure(Error);
	}

	public Result<K> ConvertFailure<K>()
	{
		if (IsSuccess)
		{
			throw new InvalidOperationException(Result.Messages.ConvertFailureExceptionOnSuccess);
		}
		return Result.Failure<K>(Error);
	}

	public override string ToString()
	{
		if (!IsSuccess)
		{
			return "Failure(" + Error + ")";
		}
		return $"Success({Value})";
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryGetValue([NotNullWhen(true)][MaybeNullWhen(false)] out T value)
	{
		value = _value;
		return IsSuccess;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryGetError([NotNullWhen(true)][MaybeNullWhen(false)] out string error)
	{
		error = _error;
		return IsFailure;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryGetValue([NotNullWhen(true)][MaybeNullWhen(false)] out T value, [NotNullWhen(false)][MaybeNullWhen(true)] out string error)
	{
		value = _value;
		error = _error;
		return IsSuccess;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryGetError([NotNullWhen(true)][MaybeNullWhen(false)] out string error, [NotNullWhen(false)][MaybeNullWhen(true)] out T value)
	{
		value = _value;
		error = _error;
		return IsFailure;
	}

	internal Result(bool isFailure, string error, T value)
	{
		IsFailure = ResultCommonLogic.ErrorStateGuard(isFailure, error);
		_error = error;
		_value = value;
	}

	private Result(SerializationInfo info, StreamingContext context)
	{
		SerializationValue<string> serializationValue = ResultCommonLogic.Deserialize(info);
		IsFailure = serializationValue.IsFailure;
		_error = serializationValue.Error;
		_value = (IsFailure ? default(T) : ((T)info.GetValue("Value", typeof(T))));
	}

	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		ResultCommonLogic.GetObjectData(this, info);
	}

	public T GetValueOrDefault(T defaultValue = default(T))
	{
		if (IsFailure)
		{
			return defaultValue;
		}
		return Value;
	}

	public static implicit operator Result<T>(T value)
	{
		if (value is IResult<T> result)
		{
			string error = (result.IsFailure ? result.Error : null);
			T value2 = (result.IsSuccess ? result.Value : default(T));
			return new Result<T>(result.IsFailure, error, value2);
		}
		return Result.Success(value);
	}

	public static implicit operator Result(Result<T> result)
	{
		if (result.IsSuccess)
		{
			return Result.Success();
		}
		return Result.Failure(result.Error);
	}

	public static implicit operator UnitResult<string>(Result<T> result)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<string>();
		}
		return UnitResult.Failure<string>(result.Error);
	}
}
[Serializable]
public readonly struct Result<T, E> : IResult<T, E>, IValue<T>, IUnitResult<E>, IResult, IError<E>, ISerializable
{
	private readonly E _error;

	private readonly T _value;

	public bool IsFailure { get; }

	public bool IsSuccess => !IsFailure;

	public E Error => ResultCommonLogic.GetErrorWithSuccessGuard(IsFailure, _error);

	public T Value
	{
		get
		{
			if (!IsSuccess)
			{
				throw new ResultFailureException<E>(Error);
			}
			return _value;
		}
	}

	public Result<K, E> ConvertFailure<K>()
	{
		if (IsSuccess)
		{
			throw new InvalidOperationException(Result.Messages.ConvertFailureExceptionOnSuccess);
		}
		return Result.Failure<K, E>(Error);
	}

	public override string ToString()
	{
		if (IsSuccess)
		{
			return $"Success({Value})";
		}
		return $"Failure({Error})";
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryGetValue([NotNullWhen(true)][MaybeNullWhen(false)] out T value)
	{
		value = _value;
		return IsSuccess;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryGetError([NotNullWhen(true)][MaybeNullWhen(false)] out E error)
	{
		error = _error;
		return IsFailure;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryGetValue([NotNullWhen(true)][MaybeNullWhen(false)] out T value, [NotNullWhen(false)][MaybeNullWhen(true)] out E error)
	{
		value = _value;
		error = _error;
		return IsSuccess;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryGetError([NotNullWhen(true)][MaybeNullWhen(false)] out E error, [NotNullWhen(false)][MaybeNullWhen(true)] out T value)
	{
		value = _value;
		error = _error;
		return IsFailure;
	}

	internal Result(bool isFailure, E error, T value)
	{
		IsFailure = ResultCommonLogic.ErrorStateGuard(isFailure, error);
		_error = error;
		_value = value;
	}

	private Result(SerializationInfo info, StreamingContext context)
	{
		SerializationValue<E> serializationValue = ResultCommonLogic.Deserialize<E>(info);
		IsFailure = serializationValue.IsFailure;
		_error = serializationValue.Error;
		_value = (IsFailure ? default(T) : ((T)info.GetValue("Value", typeof(T))));
	}

	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		ResultCommonLogic.GetObjectData(this, info);
	}

	public T GetValueOrDefault(T defaultValue = default(T))
	{
		if (IsFailure)
		{
			return defaultValue;
		}
		return Value;
	}

	public static implicit operator Result<T, E>(T value)
	{
		if (value is IResult<T, E> result)
		{
			E error = (result.IsFailure ? result.Error : default(E));
			T value2 = (result.IsSuccess ? result.Value : default(T));
			return new Result<T, E>(result.IsFailure, error, value2);
		}
		return Result.Success<T, E>(value);
	}

	public static implicit operator Result<T, E>(E error)
	{
		if (error is IResult<T, E> result)
		{
			E error2 = (result.IsFailure ? result.Error : default(E));
			T value = (result.IsSuccess ? result.Value : default(T));
			return new Result<T, E>(result.IsFailure, error2, value);
		}
		return Result.Failure<T, E>(error);
	}

	public static implicit operator UnitResult<E>(Result<T, E> result)
	{
		if (result.IsSuccess)
		{
			return UnitResult.Success<E>();
		}
		return UnitResult.Failure<E>(result.Error);
	}
}
