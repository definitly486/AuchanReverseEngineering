using System.ComponentModel;

namespace System.Text.Json.Serialization.Metadata;

[EditorBrowsable(EditorBrowsableState.Never)]
public sealed class JsonParameterInfoValues
{
	public string Name { get; init; }

	public Type ParameterType { get; init; }

	public int Position { get; init; }

	public bool HasDefaultValue { get; }

	public object? DefaultValue { get; }

	public bool IsNullable { get; init; }

	public bool IsMemberInitializer { get; init; }
}
