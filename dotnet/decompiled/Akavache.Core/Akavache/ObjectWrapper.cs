namespace Akavache;

internal class ObjectWrapper<T> : IObjectWrapper
{
	public T? Value { get; set; }

	public ObjectWrapper()
	{
	}

	public ObjectWrapper(T value)
	{
		Value = value;
	}
}
