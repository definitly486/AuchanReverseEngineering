namespace CSharpFunctionalExtensions;

public interface IError<out E>
{
	E Error { get; }
}
