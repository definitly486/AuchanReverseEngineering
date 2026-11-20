using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpFunctionalExtensions.Json.Serialization;

internal class UnitResultJsonConverterOfT<E> : JsonConverter<UnitResult<E>>
{
	public override UnitResult<E> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		try
		{
			return ToUnitResult(JsonSerializer.Deserialize<UnitResultDto<E>>(ref reader, options));
		}
		catch (JsonException)
		{
			return UnitResult.Failure<E>(default(E));
		}
	}

	public override void Write(Utf8JsonWriter writer, UnitResult<E> value, JsonSerializerOptions options)
	{
		JsonSerializer.Serialize(writer, ToUnitResultDto(value), options);
	}

	private static UnitResult<E> ToUnitResult(UnitResultDto<E>? resultDto)
	{
		if ((object)resultDto != null)
		{
			if (resultDto.IsSuccess)
			{
				return UnitResult.Success<E>();
			}
			if (resultDto.Error != null)
			{
				return UnitResult.Failure<E>(resultDto.Error);
			}
		}
		return UnitResult.Failure<E>(default(E));
	}

	private static UnitResultDto<E> ToUnitResultDto(UnitResult<E> unitResult)
	{
		if (!unitResult.IsSuccess)
		{
			return UnitResultDto.Failure(unitResult.Error);
		}
		return UnitResultDto.Success<E>();
	}
}
