namespace DryIoc.ImTools;

public struct Opt<T>
{
	public readonly T Value;

	public readonly bool HasValue;

	public static implicit operator Opt<T>(T value)
	{
		return new Opt<T>(value);
	}

	public Opt(T value)
	{
		HasValue = true;
		Value = value;
	}

	public T OrDefault(T defaultValue = default(T))
	{
		if (!HasValue)
		{
			return defaultValue;
		}
		return Value;
	}
}
