using System.Runtime.InteropServices;

namespace Mono;

internal static class RuntimeStructs
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal struct MonoClass
	{
	}

	internal struct GenericParamInfo
	{
		internal unsafe MonoClass* pklass;

		internal nint name;

		internal ushort flags;

		internal uint token;

		internal unsafe MonoClass** constraints;
	}

	internal struct GPtrArray
	{
		internal unsafe nint* data;

		internal int len;
	}
}
