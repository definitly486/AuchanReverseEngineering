using System.Configuration.Assemblies;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Reflection.Internal;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32.SafeHandles;

namespace System.Reflection.Metadata;

public sealed class MetadataReader
{
	internal readonly NamespaceCache NamespaceCache;

	internal readonly MemoryBlock Block;

	internal readonly int WinMDMscorlibRef;

	private readonly object _memoryOwnerObj;

	private readonly MetadataReaderOptions _options;

	private readonly string _versionString;

	private readonly MetadataKind _metadataKind;

	private readonly MetadataStreamKind _metadataStreamKind;

	private readonly DebugMetadataHeader _debugMetadataHeader;

	internal StringHeap StringHeap;

	internal BlobHeap BlobHeap;

	internal GuidHeap GuidHeap;

	internal UserStringHeap UserStringHeap;

	internal bool IsMinimalDelta;

	private readonly TableMask _sortedTables;

	internal int[] TableRowCounts;

	internal ModuleTableReader ModuleTable;

	internal TypeRefTableReader TypeRefTable;

	internal TypeDefTableReader TypeDefTable;

	internal FieldPtrTableReader FieldPtrTable;

	internal FieldTableReader FieldTable;

	internal MethodPtrTableReader MethodPtrTable;

	internal MethodTableReader MethodDefTable;

	internal ParamPtrTableReader ParamPtrTable;

	internal ParamTableReader ParamTable;

	internal InterfaceImplTableReader InterfaceImplTable;

	internal MemberRefTableReader MemberRefTable;

	internal ConstantTableReader ConstantTable;

	internal CustomAttributeTableReader CustomAttributeTable;

	internal FieldMarshalTableReader FieldMarshalTable;

	internal DeclSecurityTableReader DeclSecurityTable;

	internal ClassLayoutTableReader ClassLayoutTable;

	internal FieldLayoutTableReader FieldLayoutTable;

	internal StandAloneSigTableReader StandAloneSigTable;

	internal EventMapTableReader EventMapTable;

	internal EventPtrTableReader EventPtrTable;

	internal EventTableReader EventTable;

	internal PropertyMapTableReader PropertyMapTable;

	internal PropertyPtrTableReader PropertyPtrTable;

	internal PropertyTableReader PropertyTable;

	internal MethodSemanticsTableReader MethodSemanticsTable;

	internal MethodImplTableReader MethodImplTable;

	internal ModuleRefTableReader ModuleRefTable;

	internal TypeSpecTableReader TypeSpecTable;

	internal ImplMapTableReader ImplMapTable;

	internal FieldRVATableReader FieldRvaTable;

	internal EnCLogTableReader EncLogTable;

	internal EnCMapTableReader EncMapTable;

	internal AssemblyTableReader AssemblyTable;

	internal AssemblyProcessorTableReader AssemblyProcessorTable;

	internal AssemblyOSTableReader AssemblyOSTable;

	internal AssemblyRefTableReader AssemblyRefTable;

	internal AssemblyRefProcessorTableReader AssemblyRefProcessorTable;

	internal AssemblyRefOSTableReader AssemblyRefOSTable;

	internal FileTableReader FileTable;

	internal ExportedTypeTableReader ExportedTypeTable;

	internal ManifestResourceTableReader ManifestResourceTable;

	internal NestedClassTableReader NestedClassTable;

	internal GenericParamTableReader GenericParamTable;

	internal MethodSpecTableReader MethodSpecTable;

	internal GenericParamConstraintTableReader GenericParamConstraintTable;

	internal DocumentTableReader DocumentTable;

	internal MethodDebugInformationTableReader MethodDebugInformationTable;

	internal LocalScopeTableReader LocalScopeTable;

	internal LocalVariableTableReader LocalVariableTable;

	internal LocalConstantTableReader LocalConstantTable;

	internal ImportScopeTableReader ImportScopeTable;

	internal StateMachineMethodTableReader StateMachineMethodTable;

	internal CustomDebugInformationTableReader CustomDebugInformationTable;

	internal static readonly byte[] WinRTPrefix = "<WinRT>"u8.ToArray();

	public MetadataStringDecoder UTF8Decoder { get; }

	public bool IsAssembly => AssemblyTable.NumberOfRows == 1;

	internal AssemblyName GetAssemblyName(StringHandle nameHandle, Version version, StringHandle cultureHandle, BlobHandle publicKeyOrTokenHandle, AssemblyHashAlgorithm assemblyHashAlgorithm, AssemblyFlags flags)
	{
		string name = GetString(nameHandle);
		string cultureName = ((!cultureHandle.IsNil) ? GetString(cultureHandle) : "");
		byte[] array = ((!publicKeyOrTokenHandle.IsNil) ? GetBlobBytes(publicKeyOrTokenHandle) : Array.Empty<byte>());
		AssemblyName assemblyName = new AssemblyName
		{
			Name = name,
			Version = version,
			CultureName = cultureName,
			HashAlgorithm = (System.Configuration.Assemblies.AssemblyHashAlgorithm)assemblyHashAlgorithm,
			Flags = GetAssemblyNameFlags(flags),
			ContentType = GetContentTypeFromAssemblyFlags(flags)
		};
		if ((flags & AssemblyFlags.PublicKey) != 0)
		{
			assemblyName.SetPublicKey(array);
		}
		else
		{
			assemblyName.SetPublicKeyToken(array);
		}
		return assemblyName;
	}

	public unsafe static AssemblyName GetAssemblyName(string assemblyFile)
	{
		if (assemblyFile == null)
		{
			Throw.ArgumentNull("assemblyFile");
		}
		FileStream fileStream = null;
		MemoryMappedFile memoryMappedFile = null;
		MemoryMappedViewAccessor memoryMappedViewAccessor = null;
		PEReader pEReader = null;
		try
		{
			try
			{
				fileStream = new FileStream(assemblyFile, FileMode.Open, FileAccess.Read, FileShare.Read, 1, useAsync: false);
				if (fileStream.Length == 0L)
				{
					throw new BadImageFormatException("PEImageDoesNotHaveMetadata", assemblyFile);
				}
				memoryMappedFile = MemoryMappedFile.CreateFromFile(fileStream, null, fileStream.Length, MemoryMappedFileAccess.Read, HandleInheritability.None, leaveOpen: true);
				memoryMappedViewAccessor = memoryMappedFile.CreateViewAccessor(0L, 0L, MemoryMappedFileAccess.Read);
				SafeMemoryMappedViewHandle safeMemoryMappedViewHandle = memoryMappedViewAccessor.SafeMemoryMappedViewHandle;
				pEReader = new PEReader((byte*)safeMemoryMappedViewHandle.DangerousGetHandle(), (int)safeMemoryMappedViewHandle.ByteLength);
				return pEReader.GetMetadataReader(MetadataReaderOptions.None).GetAssemblyDefinition().GetAssemblyName();
			}
			finally
			{
				pEReader?.Dispose();
				memoryMappedViewAccessor?.Dispose();
				memoryMappedFile?.Dispose();
				fileStream?.Dispose();
			}
		}
		catch (InvalidOperationException ex)
		{
			throw new BadImageFormatException(ex.Message, assemblyFile, ex);
		}
	}

	private static AssemblyNameFlags GetAssemblyNameFlags(AssemblyFlags flags)
	{
		AssemblyNameFlags assemblyNameFlags = AssemblyNameFlags.None;
		if ((flags & AssemblyFlags.PublicKey) != 0)
		{
			assemblyNameFlags |= AssemblyNameFlags.PublicKey;
		}
		if ((flags & AssemblyFlags.Retargetable) != 0)
		{
			assemblyNameFlags |= AssemblyNameFlags.Retargetable;
		}
		if ((flags & AssemblyFlags.EnableJitCompileTracking) != 0)
		{
			assemblyNameFlags |= AssemblyNameFlags.EnableJITcompileTracking;
		}
		if ((flags & AssemblyFlags.DisableJitCompileOptimizer) != 0)
		{
			assemblyNameFlags |= AssemblyNameFlags.EnableJITcompileOptimizer;
		}
		return assemblyNameFlags;
	}

	private static AssemblyContentType GetContentTypeFromAssemblyFlags(AssemblyFlags flags)
	{
		return (AssemblyContentType)((int)(flags & AssemblyFlags.ContentTypeMask) >> 9);
	}

	internal unsafe MetadataReader(byte* metadata, int length, MetadataReaderOptions options, MetadataStringDecoder? utf8Decoder, object? memoryOwner)
	{
		if (length < 0)
		{
			Throw.ArgumentOutOfRange("length");
		}
		if (metadata == null)
		{
			Throw.ArgumentNull("metadata");
		}
		if (utf8Decoder == null)
		{
			utf8Decoder = MetadataStringDecoder.DefaultUTF8;
		}
		if (!(utf8Decoder.Encoding is UTF8Encoding))
		{
			Throw.InvalidArgument("MetadataStringDecoderEncodingMustBeUtf8", "utf8Decoder");
		}
		Block = new MemoryBlock(metadata, length);
		_memoryOwnerObj = memoryOwner;
		_options = options;
		UTF8Decoder = utf8Decoder;
		BlobReader memReader = new BlobReader(Block);
		ReadMetadataHeader(ref memReader, out _versionString);
		_metadataKind = GetMetadataKind(_versionString);
		StreamHeader[] streamHeaders = ReadStreamHeaders(ref memReader);
		InitializeStreamReaders(in Block, streamHeaders, out _metadataStreamKind, out var metadataTableStream, out var standalonePdbStream);
		int[] externalTableRowCounts;
		if (standalonePdbStream.Length > 0)
		{
			int pdbStreamOffset = (int)(standalonePdbStream.Pointer - metadata);
			ReadStandalonePortablePdbStream(standalonePdbStream, pdbStreamOffset, out _debugMetadataHeader, out externalTableRowCounts);
		}
		else
		{
			externalTableRowCounts = null;
		}
		BlobReader reader = new BlobReader(metadataTableStream);
		ReadMetadataTableHeader(ref reader, out var heapSizes, out var metadataTableRowCounts, out _sortedTables);
		InitializeTableReaders(reader.GetMemoryBlockAt(0, reader.RemainingBytes), heapSizes, metadataTableRowCounts, externalTableRowCounts);
		if (standalonePdbStream.Length == 0 && ModuleTable.NumberOfRows < 1)
		{
			throw new BadImageFormatException(System.SR.Format("ModuleTableInvalidNumberOfRows", ModuleTable.NumberOfRows));
		}
		NamespaceCache = new NamespaceCache(this);
		if (_metadataKind != MetadataKind.Ecma335)
		{
			WinMDMscorlibRef = FindMscorlibAssemblyRefNoProjection();
		}
	}

	private void ReadMetadataHeader(ref BlobReader memReader, out string versionString)
	{
		if (memReader.RemainingBytes < 16)
		{
			throw new BadImageFormatException("MetadataHeaderTooSmall");
		}
		if (memReader.ReadUInt32() != 1112167234)
		{
			throw new BadImageFormatException("MetadataSignature");
		}
		memReader.ReadUInt16();
		memReader.ReadUInt16();
		memReader.ReadUInt32();
		int num = memReader.ReadInt32();
		if (memReader.RemainingBytes < num)
		{
			throw new BadImageFormatException("NotEnoughSpaceForVersionString");
		}
		versionString = memReader.GetMemoryBlockAt(0, num).PeekUtf8NullTerminated(0, null, UTF8Decoder, out var _);
		memReader.Offset += num;
	}

	private MetadataKind GetMetadataKind(string versionString)
	{
		if ((_options & MetadataReaderOptions.Default) == 0)
		{
			return MetadataKind.Ecma335;
		}
		if (!versionString.Contains("WindowsRuntime"))
		{
			return MetadataKind.Ecma335;
		}
		if (versionString.Contains("CLR"))
		{
			return MetadataKind.ManagedWindowsMetadata;
		}
		return MetadataKind.WindowsMetadata;
	}

	private static StreamHeader[] ReadStreamHeaders(ref BlobReader memReader)
	{
		memReader.ReadUInt16();
		StreamHeader[] array = new StreamHeader[memReader.ReadInt16()];
		for (int i = 0; i < array.Length; i++)
		{
			if (memReader.RemainingBytes < 8)
			{
				throw new BadImageFormatException("StreamHeaderTooSmall");
			}
			array[i].Offset = memReader.ReadUInt32();
			array[i].Size = memReader.ReadInt32();
			array[i].Name = memReader.ReadUtf8NullTerminated();
			if (!memReader.TryAlign(4) || memReader.RemainingBytes == 0)
			{
				throw new BadImageFormatException("NotEnoughSpaceForStreamHeaderName");
			}
		}
		return array;
	}

	private void InitializeStreamReaders(in MemoryBlock metadataRoot, StreamHeader[] streamHeaders, out MetadataStreamKind metadataStreamKind, out MemoryBlock metadataTableStream, out MemoryBlock standalonePdbStream)
	{
		metadataTableStream = default(MemoryBlock);
		standalonePdbStream = default(MemoryBlock);
		metadataStreamKind = MetadataStreamKind.Illegal;
		for (int i = 0; i < streamHeaders.Length; i++)
		{
			StreamHeader streamHeader = streamHeaders[i];
			switch (streamHeader.Name)
			{
			case "#Strings":
				if (metadataRoot.Length < streamHeader.Offset + streamHeader.Size)
				{
					throw new BadImageFormatException("NotEnoughSpaceForStringStream");
				}
				StringHeap = new StringHeap(metadataRoot.GetMemoryBlockAt((int)streamHeader.Offset, streamHeader.Size), _metadataKind);
				break;
			case "#Blob":
				if (metadataRoot.Length < streamHeader.Offset + streamHeader.Size)
				{
					throw new BadImageFormatException("NotEnoughSpaceForBlobStream");
				}
				BlobHeap = new BlobHeap(metadataRoot.GetMemoryBlockAt((int)streamHeader.Offset, streamHeader.Size), _metadataKind);
				break;
			case "#GUID":
				if (metadataRoot.Length < streamHeader.Offset + streamHeader.Size)
				{
					throw new BadImageFormatException("NotEnoughSpaceForGUIDStream");
				}
				GuidHeap = new GuidHeap(metadataRoot.GetMemoryBlockAt((int)streamHeader.Offset, streamHeader.Size));
				break;
			case "#US":
				if (metadataRoot.Length < streamHeader.Offset + streamHeader.Size)
				{
					throw new BadImageFormatException("NotEnoughSpaceForBlobStream");
				}
				UserStringHeap = new UserStringHeap(metadataRoot.GetMemoryBlockAt((int)streamHeader.Offset, streamHeader.Size));
				break;
			case "#~":
				if (metadataRoot.Length < streamHeader.Offset + streamHeader.Size)
				{
					throw new BadImageFormatException("NotEnoughSpaceForMetadataStream");
				}
				metadataStreamKind = MetadataStreamKind.Compressed;
				metadataTableStream = metadataRoot.GetMemoryBlockAt((int)streamHeader.Offset, streamHeader.Size);
				break;
			case "#-":
				if (metadataRoot.Length < streamHeader.Offset + streamHeader.Size)
				{
					throw new BadImageFormatException("NotEnoughSpaceForMetadataStream");
				}
				metadataStreamKind = MetadataStreamKind.Uncompressed;
				metadataTableStream = metadataRoot.GetMemoryBlockAt((int)streamHeader.Offset, streamHeader.Size);
				break;
			case "#JTD":
				if (metadataRoot.Length < streamHeader.Offset + streamHeader.Size)
				{
					throw new BadImageFormatException("NotEnoughSpaceForMetadataStream");
				}
				IsMinimalDelta = true;
				break;
			case "#Pdb":
				if (metadataRoot.Length < streamHeader.Offset + streamHeader.Size)
				{
					throw new BadImageFormatException("NotEnoughSpaceForMetadataStream");
				}
				standalonePdbStream = metadataRoot.GetMemoryBlockAt((int)streamHeader.Offset, streamHeader.Size);
				break;
			}
		}
		if (IsMinimalDelta && metadataStreamKind != MetadataStreamKind.Uncompressed)
		{
			throw new BadImageFormatException("InvalidMetadataStreamFormat");
		}
	}

	private void ReadMetadataTableHeader(ref BlobReader reader, out HeapSizes heapSizes, out int[] metadataTableRowCounts, out TableMask sortedTables)
	{
		if (reader.RemainingBytes < 24)
		{
			throw new BadImageFormatException("MetadataTableHeaderTooSmall");
		}
		reader.ReadUInt32();
		reader.ReadByte();
		reader.ReadByte();
		heapSizes = (HeapSizes)reader.ReadByte();
		reader.ReadByte();
		ulong num = reader.ReadUInt64();
		sortedTables = (TableMask)reader.ReadUInt64();
		ulong num2 = 71811071505072127uL;
		if ((num & ~num2) != 0L)
		{
			throw new BadImageFormatException(System.SR.Format("UnknownTables", num));
		}
		if (_metadataStreamKind == MetadataStreamKind.Compressed && (num & 0x804800A8u) != 0L)
		{
			throw new BadImageFormatException("IllegalTablesInCompressedMetadataStream");
		}
		metadataTableRowCounts = ReadMetadataTableRowCounts(ref reader, num);
		if ((heapSizes & HeapSizes.ExtraData) == HeapSizes.ExtraData)
		{
			reader.ReadUInt32();
		}
	}

	private static int[] ReadMetadataTableRowCounts(ref BlobReader memReader, ulong presentTableMask)
	{
		ulong num = 1uL;
		int[] array = new int[MetadataTokens.TableCount];
		for (int i = 0; i < array.Length; i++)
		{
			if ((presentTableMask & num) != 0L)
			{
				if (memReader.RemainingBytes < 4)
				{
					throw new BadImageFormatException("TableRowCountSpaceTooSmall");
				}
				uint num2 = memReader.ReadUInt32();
				if (num2 > 16777215)
				{
					throw new BadImageFormatException(System.SR.Format("InvalidRowCount", num2));
				}
				array[i] = (int)num2;
			}
			num <<= 1;
		}
		return array;
	}

	internal static void ReadStandalonePortablePdbStream(MemoryBlock pdbStreamBlock, int pdbStreamOffset, out DebugMetadataHeader debugMetadataHeader, out int[] externalTableRowCounts)
	{
		BlobReader memReader = new BlobReader(pdbStreamBlock);
		byte[] array = memReader.ReadBytes(20);
		uint num = memReader.ReadUInt32();
		int num2 = (int)(num & 0xFFFFFF);
		if (num != 0 && ((num & 0x7F000000) != 100663296 || num2 == 0))
		{
			throw new BadImageFormatException(System.SR.Format("InvalidEntryPointToken", num));
		}
		ulong num3 = memReader.ReadUInt64();
		if ((num3 & 0xFFFFE036C04800A8uL) != 0L)
		{
			throw new BadImageFormatException(System.SR.Format("UnknownTables", num3));
		}
		externalTableRowCounts = ReadMetadataTableRowCounts(ref memReader, num3);
		debugMetadataHeader = new DebugMetadataHeader(ImmutableCollectionsMarshal.AsImmutableArray(array), MethodDefinitionHandle.FromRowId(num2), pdbStreamOffset);
	}

	private int GetReferenceSize(int[] rowCounts, TableIndex index)
	{
		if ((long)rowCounts[(uint)index] >= 65536L || IsMinimalDelta)
		{
			return 4;
		}
		return 2;
	}

	private void InitializeTableReaders(MemoryBlock metadataTablesMemoryBlock, HeapSizes heapSizes, int[] rowCounts, int[] externalRowCountsOpt)
	{
		TableRowCounts = rowCounts;
		int fieldRefSize = ((GetReferenceSize(rowCounts, TableIndex.FieldPtr) > 2) ? 4 : GetReferenceSize(rowCounts, TableIndex.Field));
		int methodRefSize = ((GetReferenceSize(rowCounts, TableIndex.MethodPtr) > 2) ? 4 : GetReferenceSize(rowCounts, TableIndex.MethodDef));
		int paramRefSize = ((GetReferenceSize(rowCounts, TableIndex.ParamPtr) > 2) ? 4 : GetReferenceSize(rowCounts, TableIndex.Param));
		int eventRefSize = ((GetReferenceSize(rowCounts, TableIndex.EventPtr) > 2) ? 4 : GetReferenceSize(rowCounts, TableIndex.Event));
		int propertyRefSize = ((GetReferenceSize(rowCounts, TableIndex.PropertyPtr) > 2) ? 4 : GetReferenceSize(rowCounts, TableIndex.Property));
		int typeDefOrRefRefSize = ComputeCodedTokenSize(16384, rowCounts, TableMask.TypeRef | TableMask.TypeDef | TableMask.TypeSpec);
		int hasConstantRefSize = ComputeCodedTokenSize(16384, rowCounts, TableMask.Field | TableMask.Param | TableMask.Property);
		int hasCustomAttributeRefSize = ComputeCodedTokenSize(2048, rowCounts, TableMask.Module | TableMask.TypeRef | TableMask.TypeDef | TableMask.Field | TableMask.MethodDef | TableMask.Param | TableMask.InterfaceImpl | TableMask.MemberRef | TableMask.DeclSecurity | TableMask.StandAloneSig | TableMask.Event | TableMask.Property | TableMask.ModuleRef | TableMask.TypeSpec | TableMask.Assembly | TableMask.AssemblyRef | TableMask.File | TableMask.ExportedType | TableMask.ManifestResource | TableMask.GenericParam | TableMask.MethodSpec | TableMask.GenericParamConstraint);
		int hasFieldMarshalRefSize = ComputeCodedTokenSize(32768, rowCounts, TableMask.Field | TableMask.Param);
		int hasDeclSecurityRefSize = ComputeCodedTokenSize(16384, rowCounts, TableMask.TypeDef | TableMask.MethodDef | TableMask.Assembly);
		int memberRefParentRefSize = ComputeCodedTokenSize(8192, rowCounts, TableMask.TypeRef | TableMask.TypeDef | TableMask.MethodDef | TableMask.ModuleRef | TableMask.TypeSpec);
		int hasSemanticRefSize = ComputeCodedTokenSize(32768, rowCounts, TableMask.Event | TableMask.Property);
		int methodDefOrRefRefSize = ComputeCodedTokenSize(32768, rowCounts, TableMask.MethodDef | TableMask.MemberRef);
		int memberForwardedRefSize = ComputeCodedTokenSize(32768, rowCounts, TableMask.Field | TableMask.MethodDef);
		int implementationRefSize = ComputeCodedTokenSize(16384, rowCounts, TableMask.AssemblyRef | TableMask.File | TableMask.ExportedType);
		int customAttributeTypeRefSize = ComputeCodedTokenSize(8192, rowCounts, TableMask.MethodDef | TableMask.MemberRef);
		int resolutionScopeRefSize = ComputeCodedTokenSize(16384, rowCounts, TableMask.Module | TableMask.TypeRef | TableMask.ModuleRef | TableMask.AssemblyRef);
		int typeOrMethodDefRefSize = ComputeCodedTokenSize(32768, rowCounts, TableMask.TypeDef | TableMask.MethodDef);
		int stringHeapRefSize = (((heapSizes & HeapSizes.StringHeapLarge) == HeapSizes.StringHeapLarge) ? 4 : 2);
		int guidHeapRefSize = (((heapSizes & HeapSizes.GuidHeapLarge) == HeapSizes.GuidHeapLarge) ? 4 : 2);
		int blobHeapRefSize = (((heapSizes & HeapSizes.BlobHeapLarge) == HeapSizes.BlobHeapLarge) ? 4 : 2);
		int num = 0;
		ModuleTable = new ModuleTableReader(rowCounts[0], stringHeapRefSize, guidHeapRefSize, metadataTablesMemoryBlock, num);
		num += ModuleTable.Block.Length;
		TypeRefTable = new TypeRefTableReader(rowCounts[1], resolutionScopeRefSize, stringHeapRefSize, metadataTablesMemoryBlock, num);
		num += TypeRefTable.Block.Length;
		TypeDefTable = new TypeDefTableReader(rowCounts[2], fieldRefSize, methodRefSize, typeDefOrRefRefSize, stringHeapRefSize, metadataTablesMemoryBlock, num);
		num += TypeDefTable.Block.Length;
		FieldPtrTable = new FieldPtrTableReader(rowCounts[3], GetReferenceSize(rowCounts, TableIndex.Field), metadataTablesMemoryBlock, num);
		num += FieldPtrTable.Block.Length;
		FieldTable = new FieldTableReader(rowCounts[4], stringHeapRefSize, blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += FieldTable.Block.Length;
		MethodPtrTable = new MethodPtrTableReader(rowCounts[5], GetReferenceSize(rowCounts, TableIndex.MethodDef), metadataTablesMemoryBlock, num);
		num += MethodPtrTable.Block.Length;
		MethodDefTable = new MethodTableReader(rowCounts[6], paramRefSize, stringHeapRefSize, blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += MethodDefTable.Block.Length;
		ParamPtrTable = new ParamPtrTableReader(rowCounts[7], GetReferenceSize(rowCounts, TableIndex.Param), metadataTablesMemoryBlock, num);
		num += ParamPtrTable.Block.Length;
		ParamTable = new ParamTableReader(rowCounts[8], stringHeapRefSize, metadataTablesMemoryBlock, num);
		num += ParamTable.Block.Length;
		InterfaceImplTable = new InterfaceImplTableReader(rowCounts[9], IsDeclaredSorted(TableMask.InterfaceImpl), GetReferenceSize(rowCounts, TableIndex.TypeDef), typeDefOrRefRefSize, metadataTablesMemoryBlock, num);
		num += InterfaceImplTable.Block.Length;
		MemberRefTable = new MemberRefTableReader(rowCounts[10], memberRefParentRefSize, stringHeapRefSize, blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += MemberRefTable.Block.Length;
		ConstantTable = new ConstantTableReader(rowCounts[11], IsDeclaredSorted(TableMask.Constant), hasConstantRefSize, blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += ConstantTable.Block.Length;
		CustomAttributeTable = new CustomAttributeTableReader(rowCounts[12], IsDeclaredSorted(TableMask.CustomAttribute), hasCustomAttributeRefSize, customAttributeTypeRefSize, blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += CustomAttributeTable.Block.Length;
		FieldMarshalTable = new FieldMarshalTableReader(rowCounts[13], IsDeclaredSorted(TableMask.FieldMarshal), hasFieldMarshalRefSize, blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += FieldMarshalTable.Block.Length;
		DeclSecurityTable = new DeclSecurityTableReader(rowCounts[14], IsDeclaredSorted(TableMask.DeclSecurity), hasDeclSecurityRefSize, blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += DeclSecurityTable.Block.Length;
		ClassLayoutTable = new ClassLayoutTableReader(rowCounts[15], IsDeclaredSorted(TableMask.ClassLayout), GetReferenceSize(rowCounts, TableIndex.TypeDef), metadataTablesMemoryBlock, num);
		num += ClassLayoutTable.Block.Length;
		FieldLayoutTable = new FieldLayoutTableReader(rowCounts[16], IsDeclaredSorted(TableMask.FieldLayout), GetReferenceSize(rowCounts, TableIndex.Field), metadataTablesMemoryBlock, num);
		num += FieldLayoutTable.Block.Length;
		StandAloneSigTable = new StandAloneSigTableReader(rowCounts[17], blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += StandAloneSigTable.Block.Length;
		EventMapTable = new EventMapTableReader(rowCounts[18], GetReferenceSize(rowCounts, TableIndex.TypeDef), eventRefSize, metadataTablesMemoryBlock, num);
		num += EventMapTable.Block.Length;
		EventPtrTable = new EventPtrTableReader(rowCounts[19], GetReferenceSize(rowCounts, TableIndex.Event), metadataTablesMemoryBlock, num);
		num += EventPtrTable.Block.Length;
		EventTable = new EventTableReader(rowCounts[20], typeDefOrRefRefSize, stringHeapRefSize, metadataTablesMemoryBlock, num);
		num += EventTable.Block.Length;
		PropertyMapTable = new PropertyMapTableReader(rowCounts[21], GetReferenceSize(rowCounts, TableIndex.TypeDef), propertyRefSize, metadataTablesMemoryBlock, num);
		num += PropertyMapTable.Block.Length;
		PropertyPtrTable = new PropertyPtrTableReader(rowCounts[22], GetReferenceSize(rowCounts, TableIndex.Property), metadataTablesMemoryBlock, num);
		num += PropertyPtrTable.Block.Length;
		PropertyTable = new PropertyTableReader(rowCounts[23], stringHeapRefSize, blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += PropertyTable.Block.Length;
		MethodSemanticsTable = new MethodSemanticsTableReader(rowCounts[24], IsDeclaredSorted(TableMask.MethodSemantics), GetReferenceSize(rowCounts, TableIndex.MethodDef), hasSemanticRefSize, metadataTablesMemoryBlock, num);
		num += MethodSemanticsTable.Block.Length;
		MethodImplTable = new MethodImplTableReader(rowCounts[25], IsDeclaredSorted(TableMask.MethodImpl), GetReferenceSize(rowCounts, TableIndex.TypeDef), methodDefOrRefRefSize, metadataTablesMemoryBlock, num);
		num += MethodImplTable.Block.Length;
		ModuleRefTable = new ModuleRefTableReader(rowCounts[26], stringHeapRefSize, metadataTablesMemoryBlock, num);
		num += ModuleRefTable.Block.Length;
		TypeSpecTable = new TypeSpecTableReader(rowCounts[27], blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += TypeSpecTable.Block.Length;
		ImplMapTable = new ImplMapTableReader(rowCounts[28], IsDeclaredSorted(TableMask.ImplMap), GetReferenceSize(rowCounts, TableIndex.ModuleRef), memberForwardedRefSize, stringHeapRefSize, metadataTablesMemoryBlock, num);
		num += ImplMapTable.Block.Length;
		FieldRvaTable = new FieldRVATableReader(rowCounts[29], IsDeclaredSorted(TableMask.FieldRva), GetReferenceSize(rowCounts, TableIndex.Field), metadataTablesMemoryBlock, num);
		num += FieldRvaTable.Block.Length;
		EncLogTable = new EnCLogTableReader(rowCounts[30], metadataTablesMemoryBlock, num, _metadataStreamKind);
		num += EncLogTable.Block.Length;
		EncMapTable = new EnCMapTableReader(rowCounts[31], metadataTablesMemoryBlock, num);
		num += EncMapTable.Block.Length;
		AssemblyTable = new AssemblyTableReader(rowCounts[32], stringHeapRefSize, blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += AssemblyTable.Block.Length;
		AssemblyProcessorTable = new AssemblyProcessorTableReader(rowCounts[33], metadataTablesMemoryBlock, num);
		num += AssemblyProcessorTable.Block.Length;
		AssemblyOSTable = new AssemblyOSTableReader(rowCounts[34], metadataTablesMemoryBlock, num);
		num += AssemblyOSTable.Block.Length;
		AssemblyRefTable = new AssemblyRefTableReader(rowCounts[35], stringHeapRefSize, blobHeapRefSize, metadataTablesMemoryBlock, num, _metadataKind);
		num += AssemblyRefTable.Block.Length;
		AssemblyRefProcessorTable = new AssemblyRefProcessorTableReader(rowCounts[36], GetReferenceSize(rowCounts, TableIndex.AssemblyRef), metadataTablesMemoryBlock, num);
		num += AssemblyRefProcessorTable.Block.Length;
		AssemblyRefOSTable = new AssemblyRefOSTableReader(rowCounts[37], GetReferenceSize(rowCounts, TableIndex.AssemblyRef), metadataTablesMemoryBlock, num);
		num += AssemblyRefOSTable.Block.Length;
		FileTable = new FileTableReader(rowCounts[38], stringHeapRefSize, blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += FileTable.Block.Length;
		ExportedTypeTable = new ExportedTypeTableReader(rowCounts[39], implementationRefSize, stringHeapRefSize, metadataTablesMemoryBlock, num);
		num += ExportedTypeTable.Block.Length;
		ManifestResourceTable = new ManifestResourceTableReader(rowCounts[40], implementationRefSize, stringHeapRefSize, metadataTablesMemoryBlock, num);
		num += ManifestResourceTable.Block.Length;
		NestedClassTable = new NestedClassTableReader(rowCounts[41], IsDeclaredSorted(TableMask.NestedClass), GetReferenceSize(rowCounts, TableIndex.TypeDef), metadataTablesMemoryBlock, num);
		num += NestedClassTable.Block.Length;
		GenericParamTable = new GenericParamTableReader(rowCounts[42], IsDeclaredSorted(TableMask.GenericParam), typeOrMethodDefRefSize, stringHeapRefSize, metadataTablesMemoryBlock, num);
		num += GenericParamTable.Block.Length;
		MethodSpecTable = new MethodSpecTableReader(rowCounts[43], methodDefOrRefRefSize, blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += MethodSpecTable.Block.Length;
		GenericParamConstraintTable = new GenericParamConstraintTableReader(rowCounts[44], IsDeclaredSorted(TableMask.GenericParamConstraint), GetReferenceSize(rowCounts, TableIndex.GenericParam), typeDefOrRefRefSize, metadataTablesMemoryBlock, num);
		num += GenericParamConstraintTable.Block.Length;
		int[] rowCounts2 = ((externalRowCountsOpt != null) ? CombineRowCounts(rowCounts, externalRowCountsOpt, TableIndex.Document) : rowCounts);
		int referenceSize = GetReferenceSize(rowCounts2, TableIndex.MethodDef);
		int hasCustomDebugInformationRefSize = ComputeCodedTokenSize(2048, rowCounts2, TableMask.Module | TableMask.TypeRef | TableMask.TypeDef | TableMask.Field | TableMask.MethodDef | TableMask.Param | TableMask.InterfaceImpl | TableMask.MemberRef | TableMask.DeclSecurity | TableMask.StandAloneSig | TableMask.Event | TableMask.Property | TableMask.ModuleRef | TableMask.TypeSpec | TableMask.Assembly | TableMask.AssemblyRef | TableMask.File | TableMask.ExportedType | TableMask.ManifestResource | TableMask.GenericParam | TableMask.MethodSpec | TableMask.GenericParamConstraint | TableMask.Document | TableMask.LocalScope | TableMask.LocalVariable | TableMask.LocalConstant | TableMask.ImportScope);
		DocumentTable = new DocumentTableReader(rowCounts[48], guidHeapRefSize, blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += DocumentTable.Block.Length;
		MethodDebugInformationTable = new MethodDebugInformationTableReader(rowCounts[49], GetReferenceSize(rowCounts, TableIndex.Document), blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += MethodDebugInformationTable.Block.Length;
		LocalScopeTable = new LocalScopeTableReader(rowCounts[50], IsDeclaredSorted(TableMask.LocalScope), referenceSize, GetReferenceSize(rowCounts, TableIndex.ImportScope), GetReferenceSize(rowCounts, TableIndex.LocalVariable), GetReferenceSize(rowCounts, TableIndex.LocalConstant), metadataTablesMemoryBlock, num);
		num += LocalScopeTable.Block.Length;
		LocalVariableTable = new LocalVariableTableReader(rowCounts[51], stringHeapRefSize, metadataTablesMemoryBlock, num);
		num += LocalVariableTable.Block.Length;
		LocalConstantTable = new LocalConstantTableReader(rowCounts[52], stringHeapRefSize, blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += LocalConstantTable.Block.Length;
		ImportScopeTable = new ImportScopeTableReader(rowCounts[53], GetReferenceSize(rowCounts, TableIndex.ImportScope), blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += ImportScopeTable.Block.Length;
		StateMachineMethodTable = new StateMachineMethodTableReader(rowCounts[54], IsDeclaredSorted(TableMask.StateMachineMethod), referenceSize, metadataTablesMemoryBlock, num);
		num += StateMachineMethodTable.Block.Length;
		CustomDebugInformationTable = new CustomDebugInformationTableReader(rowCounts[55], IsDeclaredSorted(TableMask.CustomDebugInformation), hasCustomDebugInformationRefSize, guidHeapRefSize, blobHeapRefSize, metadataTablesMemoryBlock, num);
		num += CustomDebugInformationTable.Block.Length;
		if (num > metadataTablesMemoryBlock.Length)
		{
			throw new BadImageFormatException("MetadataTablesTooSmall");
		}
	}

	private static int[] CombineRowCounts(int[] local, int[] external, TableIndex firstLocalTableIndex)
	{
		int[] array = new int[local.Length];
		for (int i = 0; i < (int)firstLocalTableIndex; i++)
		{
			array[i] = external[i];
		}
		for (int j = (int)firstLocalTableIndex; j < array.Length; j++)
		{
			array[j] = local[j];
		}
		return array;
	}

	private int ComputeCodedTokenSize(int largeRowSize, int[] rowCounts, TableMask tablesReferenced)
	{
		if (IsMinimalDelta)
		{
			return 4;
		}
		bool flag = true;
		ulong num = (ulong)tablesReferenced;
		for (int i = 0; i < MetadataTokens.TableCount; i++)
		{
			if ((num & 1) != 0L)
			{
				flag = flag && rowCounts[i] < largeRowSize;
			}
			num >>= 1;
		}
		if (!flag)
		{
			return 4;
		}
		return 2;
	}

	private bool IsDeclaredSorted(TableMask index)
	{
		return (_sortedTables & index) != 0;
	}

	public AssemblyDefinition GetAssemblyDefinition()
	{
		if (!IsAssembly)
		{
			throw new InvalidOperationException("MetadataImageDoesNotRepresentAnAssembly");
		}
		return new AssemblyDefinition(this);
	}

	public string GetString(StringHandle handle)
	{
		return StringHeap.GetString(handle, UTF8Decoder);
	}

	public byte[] GetBlobBytes(BlobHandle handle)
	{
		return BlobHeap.GetBytes(handle);
	}

	private int FindMscorlibAssemblyRefNoProjection()
	{
		for (int i = 1; i <= AssemblyRefTable.NumberOfNonVirtualRows; i++)
		{
			if (StringHeap.EqualsRaw(AssemblyRefTable.GetName(i), "mscorlib"))
			{
				return i;
			}
		}
		throw new BadImageFormatException("WinMDMissingMscorlibRef");
	}
}
