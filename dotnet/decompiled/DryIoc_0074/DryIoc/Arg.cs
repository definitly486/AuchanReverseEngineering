namespace DryIoc;

public static class Arg
{
	public static string ArgIndexMethodName = "Index";

	public static TRequired Of<TRequired>()
	{
		return default(TRequired);
	}

	public static TService Of<TService, TRequired>()
	{
		return default(TService);
	}

	public static TRequired Of<TRequired>(IfUnresolved ifUnresolved)
	{
		return default(TRequired);
	}

	public static TService Of<TService, TRequired>(IfUnresolved ifUnresolved)
	{
		return default(TService);
	}

	public static TRequired Of<TRequired>(object serviceKey)
	{
		return default(TRequired);
	}

	public static TService Of<TService, TRequired>(object serviceKey)
	{
		return default(TService);
	}

	public static TRequired Of<TRequired>(string metadataKey, object metadata)
	{
		return default(TRequired);
	}

	public static TService Of<TService, TRequired>(string metadataKey, object metadata)
	{
		return default(TService);
	}

	public static TRequired Of<TRequired>(IfUnresolved ifUnresolved, object serviceKey)
	{
		return default(TRequired);
	}

	public static TService Of<TService, TRequired>(IfUnresolved ifUnresolved, object serviceKey)
	{
		return default(TService);
	}

	public static TRequired Of<TRequired>(TRequired defaultValue, IfUnresolved ifUnresolved)
	{
		return default(TRequired);
	}

	public static TRequired Of<TRequired>(TRequired defaultValue, IfUnresolved ifUnresolved, object serviceKey)
	{
		return default(TRequired);
	}

	public static T Index<T>(int argIndex)
	{
		return default(T);
	}
}
