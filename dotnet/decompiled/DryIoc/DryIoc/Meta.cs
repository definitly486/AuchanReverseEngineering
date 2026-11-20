namespace DryIoc;

public sealed class Meta<T, TMetadata>
{
	public readonly T Value;

	public readonly TMetadata Metadata;

	public Meta(T value, TMetadata metadata)
	{
		Value = value;
		Metadata = metadata;
	}
}
