using System;

namespace Refit;

[AttributeUsage(AttributeTargets.Parameter)]
public class BodyAttribute : Attribute
{
	public bool? Buffered { get; }

	public BodySerializationMethod SerializationMethod { get; }

	public BodyAttribute()
	{
	}

	public BodyAttribute(bool buffered)
	{
		Buffered = buffered;
	}

	public BodyAttribute(BodySerializationMethod serializationMethod, bool buffered)
	{
		SerializationMethod = serializationMethod;
		Buffered = buffered;
	}

	public BodyAttribute(BodySerializationMethod serializationMethod = BodySerializationMethod.Default)
	{
		SerializationMethod = serializationMethod;
	}
}
