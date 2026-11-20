using System.Runtime.InteropServices;

namespace Polly.Utilities;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal readonly struct EmptyStruct
{
	internal static readonly EmptyStruct Instance;
}
