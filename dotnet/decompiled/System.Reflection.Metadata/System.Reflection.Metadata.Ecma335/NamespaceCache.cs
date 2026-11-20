namespace System.Reflection.Metadata.Ecma335;

internal sealed class NamespaceCache
{
	private readonly MetadataReader _metadataReader;

	private readonly object _namespaceTableAndListLock = new object();

	internal NamespaceCache(MetadataReader reader)
	{
		_metadataReader = reader;
	}
}
