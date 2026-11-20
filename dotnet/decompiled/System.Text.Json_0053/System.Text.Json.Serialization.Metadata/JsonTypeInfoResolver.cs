namespace System.Text.Json.Serialization.Metadata;

public static class JsonTypeInfoResolver
{
	internal static IJsonTypeInfoResolver Empty { get; } = new EmptyJsonTypeInfoResolver();

	internal static bool IsCompatibleWithOptions(this IJsonTypeInfoResolver resolver, JsonSerializerOptions options)
	{
		if (resolver is IBuiltInJsonTypeInfoResolver builtInJsonTypeInfoResolver)
		{
			return builtInJsonTypeInfoResolver.IsCompatibleWithOptions(options);
		}
		return false;
	}
}
