using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Extensions;

public static class ResultExtensions
{
	public static Result<NT, NE> Map<T, E, NT, NE>(this Result<T, E> result, Func<T, NT> valueMap, Func<E, NE> errorMap)
	{
		if (!result.IsSuccess)
		{
			return Result.Failure<NT, NE>(errorMap(result.Error));
		}
		return Result.Success<NT, NE>(valueMap(result.Value));
	}

	public static async Task<Result<NT, NE>> MapAsync<T, E, NT, NE>(this Result<T, E> result, Func<T, Task<NT>> valueMap, Func<E, NE> errorMap)
	{
		return (!result.IsSuccess) ? Result.Failure<NT, NE>(errorMap(result.Error)) : Result.Success<NT, NE>(await valueMap(result.Value));
	}

	public static Result<T, E> EnsureNotNull<T, E>(this Result<T?, E> result, E error) where T : class
	{
		if (!result.IsSuccess)
		{
			return Result.Failure<T, E>(result.Error);
		}
		if (result.Value != null)
		{
			return Result.Success<T, E>(result.Value);
		}
		return Result.Failure<T, E>(error);
	}

	public static async Task<Result<T, E>> EnsureAsync<T, E>(this Result<T, E> result, Func<T, bool> predicate, Func<T, Task<E>> errorFunc)
	{
		return (!result.IsFailure && !predicate(result.Value)) ? Result.Failure<T, E>(await errorFunc(result.Value)) : result;
	}

	public static async Task<Result<T, E>> EnsureAsync<T, E>(this Result<T, E> result, Func<T, Task<bool>> predicate, Func<T, Task<E>> errorFunc)
	{
		bool flag = result.IsFailure;
		if (!flag)
		{
			flag = await predicate(result.Value);
		}
		return (!flag) ? Result.Failure<T, E>(await errorFunc(result.Value)) : result;
	}
}
