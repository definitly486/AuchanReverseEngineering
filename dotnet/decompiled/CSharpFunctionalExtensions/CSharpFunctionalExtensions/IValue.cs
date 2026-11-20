namespace CSharpFunctionalExtensions;

public interface IValue<out T>
{
	T Value { get; }
}
