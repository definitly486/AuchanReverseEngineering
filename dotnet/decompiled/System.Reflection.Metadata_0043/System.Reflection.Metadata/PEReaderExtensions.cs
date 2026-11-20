using System.ComponentModel;
using System.Reflection.PortableExecutable;

namespace System.Reflection.Metadata;

[EditorBrowsable(EditorBrowsableState.Never)]
public static class PEReaderExtensions
{
	public static MetadataReader GetMetadataReader(this PEReader peReader, MetadataReaderOptions options)
	{
		return peReader.GetMetadataReader(options, null);
	}

	public unsafe static MetadataReader GetMetadataReader(this PEReader peReader, MetadataReaderOptions options, MetadataStringDecoder? utf8Decoder)
	{
		if (peReader == null)
		{
			Throw.ArgumentNull("peReader");
		}
		PEMemoryBlock metadata = peReader.GetMetadata();
		return new MetadataReader(metadata.Pointer, metadata.Length, options, utf8Decoder, peReader);
	}
}
