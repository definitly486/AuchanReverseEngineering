using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace System.Reflection.Metadata;

public sealed class DebugMetadataHeader
{
	[CompilerGenerated]
	private readonly ImmutableArray<byte> _003CId_003Ek__BackingField;

	[CompilerGenerated]
	private readonly MethodDefinitionHandle _003CEntryPoint_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CIdStartOffset_003Ek__BackingField;

	internal DebugMetadataHeader(ImmutableArray<byte> id, MethodDefinitionHandle entryPoint, int idStartOffset)
	{
		_003CId_003Ek__BackingField = id;
		_003CEntryPoint_003Ek__BackingField = entryPoint;
		_003CIdStartOffset_003Ek__BackingField = idStartOffset;
	}
}
