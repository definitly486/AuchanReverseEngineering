namespace CSharpFunctionalExtensions;

public interface IResult
{
	bool IsFailure { get; }

	bool IsSuccess { get; }
}
public interface IResult<out T, out E> : IValue<T>, IUnitResult<E>, IResult, IError<E>
{
}
public interface IResult<out T> : IResult<T, string>, IValue<T>, IUnitResult<string>, IResult, IError<string>
{
}
