using System.Runtime.CompilerServices;

namespace CSharpFunctionalExtensions.Json.Serialization;

internal record ResultDto(bool IsSuccess, string? Error)
{
	public static ResultDto Success()
	{
		return new ResultDto(IsSuccess: true, null);
	}

	public static ResultDto Failure(string error)
	{
		return new ResultDto(IsSuccess: false, error);
	}

	public static ResultDto<TValue> Success<TValue>(TValue value)
	{
		return new ResultDto<TValue>(IsSuccess: true, value, null);
	}

	public static ResultDto<TValue> Failure<TValue>(string error)
	{
		return new ResultDto<TValue>(IsSuccess: false, default(TValue), error);
	}

	public static ResultDto<TValue, TError> Success<TValue, TError>(TValue value)
	{
		return new ResultDto<TValue, TError>(IsSuccess: true, value, default(TError));
	}

	public static ResultDto<TValue, TError> Failure<TValue, TError>(TError error)
	{
		return new ResultDto<TValue, TError>(IsSuccess: false, default(TValue), error);
	}
}
internal record ResultDto<TValue> : ResultDto<TValue, string>
{
	public ResultDto(bool IsSuccess, TValue Value, string? Error)
		: base(IsSuccess, Value, Error)
	{
	}

	[CompilerGenerated]
	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	[CompilerGenerated]
	protected ResultDto(ResultDto<TValue> original)
		: base((ResultDto<TValue, string>)original)
	{
	}

	[CompilerGenerated]
	public new void Deconstruct(out bool IsSuccess, out TValue Value, out string? Error)
	{
		IsSuccess = base.IsSuccess;
		Value = base.Value;
		Error = base.Error;
	}
}
internal record ResultDto<TValue, TError>(bool IsSuccess, TValue Value, TError? Error);
