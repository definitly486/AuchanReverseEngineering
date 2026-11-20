using System.Runtime.CompilerServices;

namespace System.Reflection.PortableExecutable;

public readonly struct SectionHeader
{
	[CompilerGenerated]
	private readonly int _003CPointerToRelocations_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CPointerToLineNumbers_003Ek__BackingField;

	[CompilerGenerated]
	private readonly ushort _003CNumberOfRelocations_003Ek__BackingField;

	[CompilerGenerated]
	private readonly ushort _003CNumberOfLineNumbers_003Ek__BackingField;

	[CompilerGenerated]
	private readonly SectionCharacteristics _003CSectionCharacteristics_003Ek__BackingField;

	public string Name { get; }

	public int VirtualSize { get; }

	public int VirtualAddress { get; }

	public int SizeOfRawData { get; }

	public int PointerToRawData { get; }

	internal SectionHeader(ref PEBinaryReader reader)
	{
		Name = reader.ReadNullPaddedUTF8(8);
		VirtualSize = reader.ReadInt32();
		VirtualAddress = reader.ReadInt32();
		SizeOfRawData = reader.ReadInt32();
		PointerToRawData = reader.ReadInt32();
		_003CPointerToRelocations_003Ek__BackingField = reader.ReadInt32();
		_003CPointerToLineNumbers_003Ek__BackingField = reader.ReadInt32();
		_003CNumberOfRelocations_003Ek__BackingField = reader.ReadUInt16();
		_003CNumberOfLineNumbers_003Ek__BackingField = reader.ReadUInt16();
		_003CSectionCharacteristics_003Ek__BackingField = (SectionCharacteristics)reader.ReadUInt32();
	}
}
