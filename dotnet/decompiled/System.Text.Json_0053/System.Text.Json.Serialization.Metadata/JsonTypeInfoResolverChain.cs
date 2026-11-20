using System.Runtime.CompilerServices;

namespace System.Text.Json.Serialization.Metadata;

internal class JsonTypeInfoResolverChain : ConfigurationList<IJsonTypeInfoResolver>, IJsonTypeInfoResolver
{
	public override bool IsReadOnly => true;

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnCollectionModifying()
	{
		throw new NotSupportedException("Linked away");
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
	{
		throw new NotSupportedException("Linked away");
	}
}
