using System.Runtime.CompilerServices;

namespace System.Reflection.PortableExecutable;

public sealed class CorHeader
{
	[CompilerGenerated]
	private readonly ushort _003CMajorRuntimeVersion_003Ek__BackingField;

	[CompilerGenerated]
	private readonly ushort _003CMinorRuntimeVersion_003Ek__BackingField;

	[CompilerGenerated]
	private readonly CorFlags _003CFlags_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CEntryPointTokenOrRelativeVirtualAddress_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CResourcesDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CStrongNameSignatureDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CCodeManagerTableDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CVtableFixupsDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CExportAddressTableJumpsDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CManagedNativeHeaderDirectory_003Ek__BackingField;

	public DirectoryEntry MetadataDirectory { get; }

	internal CorHeader(ref PEBinaryReader reader)
	{
		reader.ReadInt32();
		_003CMajorRuntimeVersion_003Ek__BackingField = reader.ReadUInt16();
		_003CMinorRuntimeVersion_003Ek__BackingField = reader.ReadUInt16();
		MetadataDirectory = new DirectoryEntry(ref reader);
		_003CFlags_003Ek__BackingField = (CorFlags)reader.ReadUInt32();
		_003CEntryPointTokenOrRelativeVirtualAddress_003Ek__BackingField = reader.ReadInt32();
		_003CResourcesDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CStrongNameSignatureDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CCodeManagerTableDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CVtableFixupsDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CExportAddressTableJumpsDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CManagedNativeHeaderDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
	}
}
