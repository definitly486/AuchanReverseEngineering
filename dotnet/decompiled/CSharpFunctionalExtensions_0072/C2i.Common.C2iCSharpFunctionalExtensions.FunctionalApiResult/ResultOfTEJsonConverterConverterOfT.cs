using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.Json.Serialization;

namespace C2i.Common.C2iCSharpFunctionalExtensions.FunctionalApiResult;

internal class ResultOfTEJsonConverterConverterOfT<TValue, TError> : JsonConverter<Result<TValue, TError>>
{
	public override Result<TValue, TError> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		try
		{
			return ToResultTE(JsonSerializer.Deserialize<ResultDto<TValue, TError>>(ref reader, options));
		}
		catch (JsonException)
		{
			return Result.Failure<TValue, TError>(default(TError));
		}
	}

	public override void Write(Utf8JsonWriter writer, Result<TValue, TError> value, JsonSerializerOptions options)
	{
		JsonSerializer.Serialize(writer, ToResultTEDto(value), options);
	}

	private static Result<TValue, TError> ToResultTE(ResultDto<TValue, TError>? resultDto)
	{
		if ((object)resultDto == null)
		{
			return Result.Failure<TValue, TError>(default(TError));
		}
		if (!resultDto.IsSuccess)
		{
			return Result.Failure<TValue, TError>(resultDto.Error);
		}
		return Result.Success<TValue, TError>(resultDto.Value);
	}

	private static ResultDto<TValue, TError> ToResultTEDto(Result<TValue, TError> result)
	{
		if (!result.IsSuccess)
		{
			return ResultDto.Failure<TValue, TError>(result.Error);
		}
		return ResultDto.Success<TValue, TError>(result.Value);
	}
}
