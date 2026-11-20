using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using CSharpFunctionalExtensions.Internal;

namespace CSharpFunctionalExtensions;

[Serializable]
public readonly struct UnitResult<E> : IUnitResult<E>, IResult, IError<E>, ISerializable
{
	private readonly E _error;

	public bool IsFailure { get; }

	public bool IsSuccess => !IsFailure;

	public E Error => ResultCommonLogic.GetErrorWithSuccessGuard(IsFailure, _error);

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
		if (!IsSuccess)
		{
			return $"Failure({Error})";
		}
		return "Success";
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool TryGetError([NotNullWhen(true)][MaybeNullWhen(false)] out E error)
	{
		error = _error;
		return IsFailure;
	}

	internal UnitResult(bool isFailure, in E error)
	{
		IsFailure = ResultCommonLogic.ErrorStateGuard(isFailure, error);
		_error = error;
	}

	private UnitResult(SerializationInfo info, StreamingContext context)
	{
		SerializationValue<E> serializationValue = ResultCommonLogic.Deserialize<E>(info);
		IsFailure = serializationValue.IsFailure;
		_error = serializationValue.Error;
	}

	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		ResultCommonLogic.GetObjectData(this, info);
	}

	public static implicit operator UnitResult<E>(E error)
	{
		if (error is IUnitResult<E> unitResult)
		{
			E error2 = (unitResult.IsFailure ? unitResult.Error : default(E));
			return new UnitResult<E>(unitResult.IsFailure, in error2);
		}
		return UnitResult.Failure(in error);
	}
}
public static class UnitResult
{
	public static UnitResult<E> FailureIf<E>(bool isFailure, in E error)
	{
		return SuccessIf(!isFailure, in error);
	}

	public static UnitResult<E> FailureIf<E>(Func<bool> failurePredicate, in E error)
	{
		return SuccessIf(!failurePredicate(), in error);
	}

	public static async Task<UnitResult<E>> FailureIf<E>(Func<Task<bool>> failurePredicate, E error)
	{
		return SuccessIf(!(await failurePredicate().DefaultAwait()), in error);
	}

	public static UnitResult<E> SuccessIf<E>(bool isSuccess, in E error)
	{
		if (!isSuccess)
		{
			return Failure(in error);
		}
		return Success<E>();
	}

	public static UnitResult<E> SuccessIf<E>(Func<bool> predicate, in E error)
	{
		return SuccessIf(predicate(), in error);
	}

	public static async Task<UnitResult<E>> SuccessIf<E>(Func<Task<bool>> predicate, E error)
	{
		return SuccessIf(await predicate().DefaultAwait(), in error);
	}

	public static async ValueTask<UnitResult<E>> SuccessIf<E>(Func<ValueTask<bool>> predicate, E error)
	{
		return SuccessIf(await predicate(), in error);
	}

	public static UnitResult<E> Failure<E>(in E error)
	{
		return new UnitResult<E>(isFailure: true, in error);
	}

	public static UnitResult<E> Success<E>()
	{
		return Result.Success<E>();
	}
}
