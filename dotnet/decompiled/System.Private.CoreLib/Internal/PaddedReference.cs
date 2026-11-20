using System.Runtime.InteropServices;

namespace Internal;

[StructLayout(LayoutKind.Explicit, Size = 128)]
internal struct PaddedReference
{
	[FieldOffset(0)]
	public object Object;
}
