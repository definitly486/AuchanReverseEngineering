using System.ComponentModel.DataAnnotations;

namespace CSharpFunctionalExtensions.Json.Serialization;

internal static class UnitResultDto
{
	public static UnitResultDto<E> Failure<E>(E error)
	{
		return new UnitResultDto<E>(IsSuccess: false, error);
	}

	public static UnitResultDto<E> Success<E>()
	{
		return new UnitResultDto<E>(IsSuccess: true);
	}
}
internal record UnitResultDto<E>([property: Required] bool IsSuccess, [property: Required] E? Error = default(E?));
