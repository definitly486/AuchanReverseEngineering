using System.Buffers;
using System.ComponentModel;
using System.Configuration.Assemblies;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using Mono;

namespace System.Reflection;

public sealed class AssemblyName : ICloneable, IDeserializationCallback, ISerializable
{
	private string _name;

	private byte[] _publicKey;

	private byte[] _publicKeyToken;

	private CultureInfo _cultureInfo;

	private string _codeBase;

	private Version _version;

	private AssemblyHashAlgorithm _hashAlgorithm;

	private AssemblyVersionCompatibility _versionCompatibility;

	private AssemblyNameFlags _flags;

	[CompilerGenerated]
	private static SearchValues<char> _003CUnreservedReserved_003Ek__BackingField;

	public string? Name
	{
		get
		{
			return _name;
		}
		set
		{
			_name = value;
		}
	}

	public Version? Version
	{
		get
		{
			return _version;
		}
		set
		{
			_version = value;
		}
	}

	public CultureInfo? CultureInfo
	{
		get
		{
			return _cultureInfo;
		}
		set
		{
			_cultureInfo = value;
		}
	}

	public string? CultureName
	{
		get
		{
			return _cultureInfo?.Name;
		}
		set
		{
			_cultureInfo = ((value == null) ? null : new CultureInfo(value));
		}
	}

	[Obsolete("AssemblyName.CodeBase and AssemblyName.EscapedCodeBase are obsolete. Using them for loading an assembly is not supported.", DiagnosticId = "SYSLIB0044", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public string? CodeBase
	{
		[RequiresAssemblyFiles("The code will return an empty string for assemblies embedded in a single-file app")]
		get
		{
			return _codeBase;
		}
		set
		{
			_codeBase = value;
		}
	}

	[Obsolete("AssemblyName.CodeBase and AssemblyName.EscapedCodeBase are obsolete. Using them for loading an assembly is not supported.", DiagnosticId = "SYSLIB0044", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[RequiresAssemblyFiles("The code will return an empty string for assemblies embedded in a single-file app")]
	public string? EscapedCodeBase
	{
		get
		{
			if (_codeBase == null)
			{
				return null;
			}
			return EscapeCodeBase(_codeBase);
		}
	}

	[Obsolete("AssemblyName members HashAlgorithm, ProcessorArchitecture, and VersionCompatibility are obsolete and not supported.", DiagnosticId = "SYSLIB0037", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public ProcessorArchitecture ProcessorArchitecture
	{
		get
		{
			int num = (int)(_flags & (AssemblyNameFlags)112) >> 4;
			if (num > 5)
			{
				num = 0;
			}
			return (ProcessorArchitecture)num;
		}
		set
		{
			int num = (int)(value & (ProcessorArchitecture)7);
			if (num <= 5)
			{
				_flags = (AssemblyNameFlags)((long)_flags & 0xFFFFFF0FL);
				_flags |= (AssemblyNameFlags)(num << 4);
			}
		}
	}

	public AssemblyContentType ContentType
	{
		get
		{
			int num = (int)(_flags & (AssemblyNameFlags)3584) >> 9;
			if (num > 1)
			{
				num = 0;
			}
			return (AssemblyContentType)num;
		}
		set
		{
			int num = (int)(value & (AssemblyContentType)7);
			if (num <= 1)
			{
				_flags = (AssemblyNameFlags)((long)_flags & 0xFFFFF1FFL);
				_flags |= (AssemblyNameFlags)(num << 9);
			}
		}
	}

	public AssemblyNameFlags Flags
	{
		get
		{
			return _flags & (AssemblyNameFlags)(-3825);
		}
		set
		{
			_flags &= (AssemblyNameFlags)3824;
			_flags |= value & (AssemblyNameFlags)(-3825);
		}
	}

	[Obsolete("AssemblyName members HashAlgorithm, ProcessorArchitecture, and VersionCompatibility are obsolete and not supported.", DiagnosticId = "SYSLIB0037", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public AssemblyHashAlgorithm HashAlgorithm
	{
		get
		{
			return _hashAlgorithm;
		}
		set
		{
			_hashAlgorithm = value;
		}
	}

	[Obsolete("AssemblyName members HashAlgorithm, ProcessorArchitecture, and VersionCompatibility are obsolete and not supported.", DiagnosticId = "SYSLIB0037", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public AssemblyVersionCompatibility VersionCompatibility
	{
		get
		{
			return _versionCompatibility;
		}
		set
		{
			_versionCompatibility = value;
		}
	}

	[Obsolete("Strong name signing is not supported and throws PlatformNotSupportedException.", DiagnosticId = "SYSLIB0017", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	public StrongNameKeyPair? KeyPair
	{
		get
		{
			throw new PlatformNotSupportedException("PlatformNotSupported_StrongNameSigning");
		}
		set
		{
			throw new PlatformNotSupportedException("PlatformNotSupported_StrongNameSigning");
		}
	}

	public string FullName
	{
		get
		{
			if (string.IsNullOrEmpty(Name))
			{
				return string.Empty;
			}
			byte[] pkt = _publicKeyToken ?? AssemblyNameHelpers.ComputePublicKeyToken(_publicKey);
			return AssemblyNameFormatter.ComputeDisplayName(Name, Version, CultureName, pkt, Flags, ContentType);
		}
	}

	private static SearchValues<char> UnreservedReserved => _003CUnreservedReserved_003Ek__BackingField ?? (_003CUnreservedReserved_003Ek__BackingField = SearchValues.Create("!#$&'()*+,-./0123456789:;=?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[]_abcdefghijklmnopqrstuvwxyz~".AsSpan()));

	internal unsafe static AssemblyName Create(nint monoAssembly, string codeBase)
	{
		AssemblyName assemblyName = new AssemblyName();
		MonoAssemblyName* nativeName = GetNativeName(monoAssembly);
		assemblyName.FillName(nativeName, codeBase, addVersion: true, addPublickey: true, defaultToken: true);
		return assemblyName;
	}

	internal unsafe void FillName(MonoAssemblyName* native, string codeBase, bool addVersion, bool addPublickey, bool defaultToken)
	{
		_name = Marshal.PtrToStringUTF8(native->name);
		_flags = (AssemblyNameFlags)native->flags;
		_hashAlgorithm = (AssemblyHashAlgorithm)native->hash_alg;
		_versionCompatibility = AssemblyVersionCompatibility.SameMachine;
		if (addVersion)
		{
			int num = ((native->build == 65535) ? (-1) : native->build);
			int num2 = ((native->revision == 65535) ? (-1) : native->revision);
			if (num == -1)
			{
				_version = new Version(native->major, native->minor);
			}
			else if (num2 == -1)
			{
				_version = new Version(native->major, native->minor, num);
			}
			else
			{
				_version = new Version(native->major, native->minor, num, num2);
			}
		}
		_codeBase = codeBase;
		if (native->culture != IntPtr.Zero)
		{
			_cultureInfo = System.Globalization.CultureInfo.GetCultureInfo(Marshal.PtrToStringUTF8(native->culture));
		}
		if (native->public_key != IntPtr.Zero)
		{
			_publicKey = DecodeBlobArray(native->public_key);
			_flags |= AssemblyNameFlags.PublicKey;
		}
		else if (addPublickey)
		{
			_publicKey = Array.Empty<byte>();
			_flags |= AssemblyNameFlags.PublicKey;
		}
		if (*native->public_key_token != 0)
		{
			byte[] array = new byte[8];
			int i = 0;
			int num3 = 0;
			for (; i < 8; i++)
			{
				array[i] = (byte)((HexConverter.FromChar(native->public_key_token[num3++]) << 4) | HexConverter.FromChar(native->public_key_token[num3++]));
			}
			_publicKeyToken = array;
		}
		else if (defaultToken)
		{
			_publicKeyToken = Array.Empty<byte>();
		}
	}

	private unsafe static int DecodeBlobSize(nint in_ptr, out nint out_ptr)
	{
		byte* ptr = (byte*)in_ptr;
		uint result;
		if ((*ptr & 0x80) == 0)
		{
			result = (uint)(*ptr & 0x7F);
			ptr++;
		}
		else if ((*ptr & 0x40) == 0)
		{
			result = (uint)(((*ptr & 0x3F) << 8) + ptr[1]);
			ptr += 2;
		}
		else
		{
			result = (uint)(((*ptr & 0x1F) << 24) + (ptr[1] << 16) + (ptr[2] << 8) + ptr[3]);
			ptr += 4;
		}
		out_ptr = (nint)ptr;
		return (int)result;
	}

	internal static byte[] DecodeBlobArray(nint ptr)
	{
		nint out_ptr;
		int num = DecodeBlobSize(ptr, out out_ptr);
		byte[] array = new byte[num];
		Marshal.Copy(out_ptr, array, 0, num);
		return array;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	internal static extern void FreeAssemblyName(ref MonoAssemblyName name, bool freeStruct);

	[MethodImpl(MethodImplOptions.InternalCall)]
	private unsafe static extern MonoAssemblyName* GetNativeName(nint assemblyPtr);

	public AssemblyName(string assemblyName)
		: this()
	{
		ArgumentException.ThrowIfNullOrEmpty(assemblyName, "assemblyName");
		if (assemblyName[0] == '\0')
		{
			throw new ArgumentException("Format_StringZeroLength");
		}
		AssemblyNameParser.AssemblyNameParts assemblyNameParts = AssemblyNameParser.Parse(assemblyName);
		_name = assemblyNameParts._name;
		_version = assemblyNameParts._version;
		_flags = assemblyNameParts._flags;
		if ((assemblyNameParts._flags & AssemblyNameFlags.PublicKey) != AssemblyNameFlags.None)
		{
			_publicKey = assemblyNameParts._publicKeyOrToken;
		}
		else
		{
			_publicKeyToken = assemblyNameParts._publicKeyOrToken;
		}
		if (assemblyNameParts._cultureName != null)
		{
			_cultureInfo = new CultureInfo(assemblyNameParts._cultureName);
		}
	}

	public AssemblyName()
	{
		_versionCompatibility = AssemblyVersionCompatibility.SameMachine;
	}

	public object Clone()
	{
		return new AssemblyName
		{
			_name = _name,
			_publicKey = (byte[])_publicKey?.Clone(),
			_publicKeyToken = (byte[])_publicKeyToken?.Clone(),
			_cultureInfo = _cultureInfo,
			_version = _version,
			_flags = _flags,
			_codeBase = _codeBase,
			_hashAlgorithm = _hashAlgorithm,
			_versionCompatibility = _versionCompatibility
		};
	}

	public static AssemblyName GetAssemblyName(string assemblyFile)
	{
		return GetAssemblyNameInternal(null, assemblyFile);
		[UnsafeAccessor(UnsafeAccessorKind.StaticMethod, Name = "GetAssemblyName")]
		static extern AssemblyName GetAssemblyNameInternal([UnsafeAccessorType("System.Reflection.Metadata.MetadataReader, System.Reflection.Metadata")] object _, string assemblyFile);
	}

	public byte[]? GetPublicKey()
	{
		return _publicKey;
	}

	public void SetPublicKey(byte[]? publicKey)
	{
		_publicKey = publicKey;
		if (publicKey == null)
		{
			_flags &= ~AssemblyNameFlags.PublicKey;
		}
		else
		{
			_flags |= AssemblyNameFlags.PublicKey;
		}
	}

	public byte[]? GetPublicKeyToken()
	{
		return _publicKeyToken ?? (_publicKeyToken = AssemblyNameHelpers.ComputePublicKeyToken(_publicKey));
	}

	public void SetPublicKeyToken(byte[]? publicKeyToken)
	{
		_publicKeyToken = publicKeyToken;
	}

	public override string ToString()
	{
		string fullName = FullName;
		if (fullName == null)
		{
			return base.ToString();
		}
		return fullName;
	}

	[Obsolete("This API supports obsolete formatter-based serialization. It should not be called or extended by application code.", DiagnosticId = "SYSLIB0051", UrlFormat = "https://aka.ms/dotnet-warnings/{0}")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException();
	}

	public void OnDeserialization(object? sender)
	{
		throw new PlatformNotSupportedException();
	}

	public static bool ReferenceMatchesDefinition(AssemblyName? reference, AssemblyName? definition)
	{
		if (reference == definition)
		{
			return true;
		}
		ArgumentNullException.ThrowIfNull(reference, "reference");
		ArgumentNullException.ThrowIfNull(definition, "definition");
		string? obj = reference.Name ?? string.Empty;
		string value = definition.Name ?? string.Empty;
		return obj.Equals(value, StringComparison.OrdinalIgnoreCase);
	}

	internal static string EscapeCodeBase(string codebase)
	{
		if (codebase == null)
		{
			return string.Empty;
		}
		int num = codebase.AsSpan().IndexOfAnyExcept(UnreservedReserved);
		if (num < 0)
		{
			return codebase;
		}
		Span<char> initialBuffer = stackalloc char[512];
		ValueStringBuilder vsb = new ValueStringBuilder(initialBuffer);
		vsb.EnsureCapacity(codebase.Length);
		EscapeStringToBuilder(codebase.AsSpan(num), ref vsb);
		string result = string.Concat(codebase.AsSpan(0, num), vsb.AsSpan());
		vsb.Dispose();
		return result;
	}

	internal static void EscapeStringToBuilder(scoped ReadOnlySpan<char> stringToEscape, ref ValueStringBuilder vsb)
	{
		Span<byte> destination = stackalloc byte[4];
		while (!stringToEscape.IsEmpty)
		{
			char c = stringToEscape[0];
			if (!char.IsAscii(c))
			{
				if (Rune.DecodeFromUtf16(stringToEscape, out var result, out var charsConsumed) != OperationStatus.Done)
				{
					result = Rune.ReplacementChar;
				}
				stringToEscape = stringToEscape.Slice(charsConsumed);
				result.TryEncodeToUtf8(destination, out var bytesWritten);
				Span<byte> span = destination.Slice(0, bytesWritten);
				for (int i = 0; i < span.Length; i++)
				{
					PercentEncodeByte(span[i], ref vsb);
				}
			}
			else if (!UnreservedReserved.Contains(c))
			{
				PercentEncodeByte((byte)c, ref vsb);
				stringToEscape = stringToEscape.Slice(1);
			}
			else
			{
				int num = stringToEscape.IndexOfAnyExcept(UnreservedReserved);
				if (num < 0)
				{
					num = stringToEscape.Length;
				}
				vsb.Append(stringToEscape.Slice(0, num));
				stringToEscape = stringToEscape.Slice(num);
			}
		}
	}

	internal static void PercentEncodeByte(byte ch, ref ValueStringBuilder vsb)
	{
		vsb.Append('%');
		HexConverter.ToCharsBuffer(ch, vsb.AppendSpan(2));
	}
}
