namespace System.Text.Json.Serialization.Metadata;

public readonly struct JsonDerivedType
{
	public Type DerivedType { get; }

	public object? TypeDiscriminator { get; }

	internal JsonDerivedType(Type derivedType, object typeDiscriminator)
	{
		DerivedType = derivedType;
		TypeDiscriminator = typeDiscriminator;
	}

	internal void Deconstruct(out Type derivedType, out object typeDiscriminator)
	{
		derivedType = DerivedType;
		typeDiscriminator = TypeDiscriminator;
	}
}
