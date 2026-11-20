using System.Runtime.InteropServices;

namespace System.Runtime;

[StructLayout(LayoutKind.Sequential, Size = 1)]
internal struct GCFrameRegistration
{
	public unsafe GCFrameRegistration(void* allocation, uint elemCount, bool areByRefs = true)
	{
	}
}
