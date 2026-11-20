using System.Runtime.InteropServices;

namespace System.Reflection;

[StructLayout(LayoutKind.Sequential)]
internal sealed class LoaderAllocator
{
	private LoaderAllocatorScout m_scout;

	private object[] m_slots;

	private object[] m_hashes;

	private int m_nslots;

	private LoaderAllocator(nint native)
	{
		m_scout = new LoaderAllocatorScout(native);
	}
}
