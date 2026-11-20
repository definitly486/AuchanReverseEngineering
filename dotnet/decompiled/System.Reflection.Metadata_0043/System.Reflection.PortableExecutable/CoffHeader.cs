using System.Runtime.CompilerServices;

namespace System.Reflection.PortableExecutable;

public sealed class CoffHeader
{
	[CompilerGenerated]
	private readonly Machine _003CMachine_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CTimeDateStamp_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CPointerToSymbolTable_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CNumberOfSymbols_003Ek__BackingField;

	[CompilerGenerated]
	private readonly Characteristics _003CCharacteristics_003Ek__BackingField;

	public short NumberOfSections { get; }

	public short SizeOfOptionalHeader { get; }

	internal CoffHeader(ref PEBinaryReader reader)
	{
		_003CMachine_003Ek__BackingField = (Machine)reader.ReadUInt16();
		NumberOfSections = reader.ReadInt16();
		_003CTimeDateStamp_003Ek__BackingField = reader.ReadInt32();
		_003CPointerToSymbolTable_003Ek__BackingField = reader.ReadInt32();
		_003CNumberOfSymbols_003Ek__BackingField = reader.ReadInt32();
		SizeOfOptionalHeader = reader.ReadInt16();
		_003CCharacteristics_003Ek__BackingField = (Characteristics)reader.ReadUInt16();
	}
}
