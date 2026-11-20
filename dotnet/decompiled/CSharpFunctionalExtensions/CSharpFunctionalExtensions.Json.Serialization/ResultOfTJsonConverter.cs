using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpFunctionalExtensions.Json.Serialization;

internal class ResultOfTJsonConverter<T> : JsonConverter<Result<T>>
{
	public override Result<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		try
		{
			return ToResult(JsonSerializer.Deserialize<ResultDto<T>>(ref reader, options));
		}
		catch (JsonException)
		{
			return Result.Failure<T>(DtoMessages.ContentJsonNotResult);
		}
	}

	public override void Write(Utf8JsonWriter writer, Result<T> value, JsonSerializerOptions options)
	{
		JsonSerializer.Serialize(writer, ToResultDto(value), options);
	}

	private static Result<T> ToResult(ResultDto<T>? resultDto)
	{
		if ((object)resultDto != null)
		{
			if (resultDto.IsSuccess)
			{
				return Result.Success(resultDto.Value);
			}
			if (resultDto.Error != null)
			{
				return Result.Failure<T>(resultDto.Error);
			}
			return Result.Failure<T>("ResultDto was not successful and ErrorMessage is null");
		}
		return Result.Failure<T>(DtoMessages.ContentJsonNotResult);
	}

	private static ResultDto<T> ToResultDto(Result<T> result)
	{
		if (!result.IsSuccess)
		{
			return ResultDto.Failure<T>(result.Error);
		}
		return ResultDto.Success(result.Value);
	}
}
