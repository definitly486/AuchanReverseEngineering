namespace System.Text.Json.Serialization;

internal abstract class JsonDictionaryConverter<TDictionary> : JsonResumableConverter<TDictionary>
{
	protected internal abstract bool OnWriteResume(Utf8JsonWriter writer, TDictionary dictionary, JsonSerializerOptions options, ref WriteStack state);
}
