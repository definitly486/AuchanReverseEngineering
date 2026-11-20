using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpFunctionalExtensions.Json.Serialization;

internal class ResultJsonConverter : JsonConverter<Result>
{
	public override Result Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		try
		{
			return ToResult(JsonSerializer.Deserialize<ResultDto>(ref reader, options));
		}
		catch (JsonException)
		{
			return Result.Failure(DtoMessages.ContentJsonNotResult);
		}
	}

	public override void Write(Utf8JsonWriter writer, Result value, JsonSerializerOptions options)
	{
		JsonSerializer.Serialize(writer, ToResultDto(value), options);
	}

	private static Result ToResult(ResultDto? resultDto)
	{
		if ((object)resultDto == null)
		{
			return Result.Failure(DtoMessages.ContentJsonNotResult);
		}
		if (!resultDto.IsSuccess)
		{
			return Result.Failure(resultDto.Error);
		}
		return Result.Success();
	}

	private static ResultDto ToResultDto(Result result)
	{
		if (!result.IsSuccess)
		{
			return ResultDto.Failure(result.Error);
		}
		return ResultDto.Success();
	}
}
