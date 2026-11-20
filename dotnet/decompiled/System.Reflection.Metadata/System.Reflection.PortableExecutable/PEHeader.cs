using System.Runtime.CompilerServices;

namespace System.Reflection.PortableExecutable;

public sealed class PEHeader
{
	[CompilerGenerated]
	private readonly PEMagic _003CMagic_003Ek__BackingField;

	[CompilerGenerated]
	private readonly byte _003CMajorLinkerVersion_003Ek__BackingField;

	[CompilerGenerated]
	private readonly byte _003CMinorLinkerVersion_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CSizeOfCode_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CSizeOfInitializedData_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CSizeOfUninitializedData_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CAddressOfEntryPoint_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CBaseOfCode_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CBaseOfData_003Ek__BackingField;

	[CompilerGenerated]
	private readonly ulong _003CImageBase_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CSectionAlignment_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CFileAlignment_003Ek__BackingField;

	[CompilerGenerated]
	private readonly ushort _003CMajorOperatingSystemVersion_003Ek__BackingField;

	[CompilerGenerated]
	private readonly ushort _003CMinorOperatingSystemVersion_003Ek__BackingField;

	[CompilerGenerated]
	private readonly ushort _003CMajorImageVersion_003Ek__BackingField;

	[CompilerGenerated]
	private readonly ushort _003CMinorImageVersion_003Ek__BackingField;

	[CompilerGenerated]
	private readonly ushort _003CMajorSubsystemVersion_003Ek__BackingField;

	[CompilerGenerated]
	private readonly ushort _003CMinorSubsystemVersion_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CSizeOfImage_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CSizeOfHeaders_003Ek__BackingField;

	[CompilerGenerated]
	private readonly uint _003CCheckSum_003Ek__BackingField;

	[CompilerGenerated]
	private readonly Subsystem _003CSubsystem_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DllCharacteristics _003CDllCharacteristics_003Ek__BackingField;

	[CompilerGenerated]
	private readonly ulong _003CSizeOfStackReserve_003Ek__BackingField;

	[CompilerGenerated]
	private readonly ulong _003CSizeOfStackCommit_003Ek__BackingField;

	[CompilerGenerated]
	private readonly ulong _003CSizeOfHeapReserve_003Ek__BackingField;

	[CompilerGenerated]
	private readonly ulong _003CSizeOfHeapCommit_003Ek__BackingField;

	[CompilerGenerated]
	private readonly int _003CNumberOfRvaAndSizes_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CExportTableDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CImportTableDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CResourceTableDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CExceptionTableDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CCertificateTableDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CBaseRelocationTableDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CDebugTableDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CCopyrightTableDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CGlobalPointerTableDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CThreadLocalStorageTableDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CLoadConfigTableDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CBoundImportTableDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CImportAddressTableDirectory_003Ek__BackingField;

	[CompilerGenerated]
	private readonly DirectoryEntry _003CDelayImportTableDirectory_003Ek__BackingField;

	public DirectoryEntry CorHeaderTableDirectory { get; }

	internal PEHeader(ref PEBinaryReader reader)
	{
		PEMagic pEMagic = (PEMagic)reader.ReadUInt16();
		if (pEMagic != PEMagic.PE32 && pEMagic != PEMagic.PE32Plus)
		{
			throw new BadImageFormatException("UnknownPEMagicValue");
		}
		_003CMagic_003Ek__BackingField = pEMagic;
		_003CMajorLinkerVersion_003Ek__BackingField = reader.ReadByte();
		_003CMinorLinkerVersion_003Ek__BackingField = reader.ReadByte();
		_003CSizeOfCode_003Ek__BackingField = reader.ReadInt32();
		_003CSizeOfInitializedData_003Ek__BackingField = reader.ReadInt32();
		_003CSizeOfUninitializedData_003Ek__BackingField = reader.ReadInt32();
		_003CAddressOfEntryPoint_003Ek__BackingField = reader.ReadInt32();
		_003CBaseOfCode_003Ek__BackingField = reader.ReadInt32();
		if (pEMagic == PEMagic.PE32Plus)
		{
			_003CBaseOfData_003Ek__BackingField = 0;
		}
		else
		{
			_003CBaseOfData_003Ek__BackingField = reader.ReadInt32();
		}
		if (pEMagic == PEMagic.PE32Plus)
		{
			_003CImageBase_003Ek__BackingField = reader.ReadUInt64();
		}
		else
		{
			_003CImageBase_003Ek__BackingField = reader.ReadUInt32();
		}
		_003CSectionAlignment_003Ek__BackingField = reader.ReadInt32();
		_003CFileAlignment_003Ek__BackingField = reader.ReadInt32();
		_003CMajorOperatingSystemVersion_003Ek__BackingField = reader.ReadUInt16();
		_003CMinorOperatingSystemVersion_003Ek__BackingField = reader.ReadUInt16();
		_003CMajorImageVersion_003Ek__BackingField = reader.ReadUInt16();
		_003CMinorImageVersion_003Ek__BackingField = reader.ReadUInt16();
		_003CMajorSubsystemVersion_003Ek__BackingField = reader.ReadUInt16();
		_003CMinorSubsystemVersion_003Ek__BackingField = reader.ReadUInt16();
		reader.ReadUInt32();
		_003CSizeOfImage_003Ek__BackingField = reader.ReadInt32();
		_003CSizeOfHeaders_003Ek__BackingField = reader.ReadInt32();
		_003CCheckSum_003Ek__BackingField = reader.ReadUInt32();
		_003CSubsystem_003Ek__BackingField = (Subsystem)reader.ReadUInt16();
		_003CDllCharacteristics_003Ek__BackingField = (DllCharacteristics)reader.ReadUInt16();
		if (pEMagic == PEMagic.PE32Plus)
		{
			_003CSizeOfStackReserve_003Ek__BackingField = reader.ReadUInt64();
			_003CSizeOfStackCommit_003Ek__BackingField = reader.ReadUInt64();
			_003CSizeOfHeapReserve_003Ek__BackingField = reader.ReadUInt64();
			_003CSizeOfHeapCommit_003Ek__BackingField = reader.ReadUInt64();
		}
		else
		{
			_003CSizeOfStackReserve_003Ek__BackingField = reader.ReadUInt32();
			_003CSizeOfStackCommit_003Ek__BackingField = reader.ReadUInt32();
			_003CSizeOfHeapReserve_003Ek__BackingField = reader.ReadUInt32();
			_003CSizeOfHeapCommit_003Ek__BackingField = reader.ReadUInt32();
		}
		reader.ReadUInt32();
		_003CNumberOfRvaAndSizes_003Ek__BackingField = reader.ReadInt32();
		_003CExportTableDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CImportTableDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CResourceTableDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CExceptionTableDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CCertificateTableDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CBaseRelocationTableDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CDebugTableDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CCopyrightTableDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CGlobalPointerTableDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CThreadLocalStorageTableDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CLoadConfigTableDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CBoundImportTableDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CImportAddressTableDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		_003CDelayImportTableDirectory_003Ek__BackingField = new DirectoryEntry(ref reader);
		CorHeaderTableDirectory = new DirectoryEntry(ref reader);
		new DirectoryEntry(ref reader);
	}
}
