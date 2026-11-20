using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CSharpFunctionalExtensions.Internal;

internal static class ResultCommonLogic
{
	internal static void GetObjectDataCommon(IResult result, SerializationInfo info)
	{
		info.AddValue("IsFailure", result.IsFailure);
		info.AddValue("IsSuccess", result.IsSuccess);
	}

	internal static void GetObjectData(Result result, SerializationInfo info)
	{
		GetObjectDataCommon(result, info);
		if (result.IsFailure)
		{
			info.AddValue("Error", result.Error);
		}
	}

	internal static void GetObjectData<T>(Result<T> result, SerializationInfo info)
	{
		GetObjectDataCommon(result, info);
		if (result.IsFailure)
		{
			info.AddValue("Error", result.Error);
		}
		if (result.IsSuccess)
		{
			info.AddValue("Value", result.Value);
		}
	}

	internal static void GetObjectData<T, E>(Result<T, E> result, SerializationInfo info)
	{
		GetObjectDataCommon(result, info);
		if (result.IsFailure)
		{
			info.AddValue("Error", result.Error);
		}
		if (result.IsSuccess)
		{
			info.AddValue("Value", result.Value);
		}
	}

	internal static void GetObjectData<E>(UnitResult<E> result, SerializationInfo info)
	{
		GetObjectDataCommon(result, info);
		if (result.IsFailure)
		{
			info.AddValue("Error", result.Error);
		}
	}

	internal static bool ErrorStateGuard<E>(bool isFailure, E error)
	{
		if (isFailure)
		{
			if (error == null || (error is string && error.Equals(string.Empty)))
			{
				throw new ArgumentNullException("error", Result.Messages.ErrorObjectIsNotProvidedForFailure);
			}
		}
		else if (!EqualityComparer<E>.Default.Equals(error, default(E)))
		{
			throw new ArgumentException(Result.Messages.ErrorObjectIsProvidedForSuccess, "error");
		}
		return isFailure;
	}

	internal static E GetErrorWithSuccessGuard<E>(bool isFailure, E error)
	{
		if (!isFailure)
		{
			throw new ResultSuccessException();
		}
		return error;
	}

	internal static SerializationValue<string> Deserialize(SerializationInfo info)
	{
		return Deserialize<string>(info);
	}

	internal static SerializationValue<E> Deserialize<E>(SerializationInfo info)
	{
		bool boolean = info.GetBoolean("IsFailure");
		E error = (boolean ? ((E)info.GetValue("Error", typeof(E))) : default(E));
		return new SerializationValue<E>(boolean, error);
	}
}
