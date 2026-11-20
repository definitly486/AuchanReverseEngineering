namespace CSharpFunctionalExtensions;

public interface IMaybe<out T>
{
	T Value { get; }

	bool HasValue { get; }

	bool HasNoValue { get; }
}
