namespace CSharpFunctionalExtensions;

public interface IUnitResult<out E> : IResult, IError<E>
{
}
