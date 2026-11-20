using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace System.Reflection.Metadata;

[DebuggerDisplay("{FullName}")]
internal sealed class AssemblyNameInfo
{
	internal readonly AssemblyNameFlags _flags;

	private string _fullName;

	public string Name { get; }

	public Version Version { get; }

	public string CultureName { get; }

	public AssemblyNameFlags Flags => _flags;

	public byte[] PublicKeyOrToken { get; }

	public string FullName
	{
		get
		{
			if (_fullName == null)
			{
				Span<char> initialBuffer = stackalloc char[256];
				ValueStringBuilder vsb = new ValueStringBuilder(initialBuffer);
				AppendFullName(ref vsb);
				_fullName = vsb.ToString();
			}
			return _fullName;
		}
	}

	internal AssemblyNameInfo(AssemblyNameParser.AssemblyNameParts parts)
	{
		Name = parts._name;
		Version = parts._version;
		CultureName = parts._cultureName;
		_flags = parts._flags;
		PublicKeyOrToken = parts._publicKeyOrToken;
	}

	internal void AppendFullName(ref ValueStringBuilder vsb)
	{
		if (_fullName != null)
		{
			vsb.Append(_fullName);
			return;
		}
		bool flag = (Flags & AssemblyNameFlags.PublicKey) != 0;
		byte[] publicKeyOrToken = PublicKeyOrToken;
		AssemblyNameFormatter.AppendDisplayName(ref vsb, Name, Version, CultureName, flag ? null : publicKeyOrToken, ExtractAssemblyNameFlags(_flags), ExtractAssemblyContentType(_flags), flag ? publicKeyOrToken : null);
	}

	public AssemblyName ToAssemblyName()
	{
		AssemblyName assemblyName = new AssemblyName();
		assemblyName.Name = Name;
		assemblyName.CultureName = CultureName;
		assemblyName.Version = Version;
		assemblyName.Flags = Flags;
		assemblyName.ContentType = ExtractAssemblyContentType(_flags);
		assemblyName.ProcessorArchitecture = ExtractProcessorArchitecture(_flags);
		if (PublicKeyOrToken != null)
		{
			if ((Flags & AssemblyNameFlags.PublicKey) != AssemblyNameFlags.None)
			{
				assemblyName.SetPublicKey(PublicKeyOrToken);
			}
			else
			{
				assemblyName.SetPublicKeyToken(PublicKeyOrToken);
			}
		}
		return assemblyName;
	}

	public static bool TryParse(ReadOnlySpan<char> assemblyName, [NotNullWhen(true)] out AssemblyNameInfo result)
	{
		AssemblyNameParser.AssemblyNameParts parts = default(AssemblyNameParser.AssemblyNameParts);
		if (!assemblyName.IsEmpty && AssemblyNameParser.TryParse(assemblyName, ref parts))
		{
			result = new AssemblyNameInfo(parts);
			return true;
		}
		result = null;
		return false;
	}

	internal static AssemblyNameFlags ExtractAssemblyNameFlags(AssemblyNameFlags combinedFlags)
	{
		return combinedFlags & (AssemblyNameFlags)(-3825);
	}

	internal static AssemblyContentType ExtractAssemblyContentType(AssemblyNameFlags flags)
	{
		return (AssemblyContentType)(((int)flags >> 9) & 7);
	}

	internal static ProcessorArchitecture ExtractProcessorArchitecture(AssemblyNameFlags flags)
	{
		return (ProcessorArchitecture)(((int)flags >> 4) & 7);
	}
}
