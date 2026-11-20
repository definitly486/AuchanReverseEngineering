using System;
using System.Collections.Immutable;
using Newtonsoft.Json;

namespace Auchan.Common.Common;

public sealed class ReadOnlyEquatableListConverter<T> : JsonConverter where T : IEquatable<T>
{
	public override bool CanConvert(Type objectType)
	{
		return objectType == typeof(ReadOnlyEquatableList<T>);
	}

	public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
	{
		return new ReadOnlyEquatableList<T>(serializer.Deserialize<ImmutableArray<T>>(reader));
	}

	public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
	{
		serializer.Serialize(writer, value);
	}
}
