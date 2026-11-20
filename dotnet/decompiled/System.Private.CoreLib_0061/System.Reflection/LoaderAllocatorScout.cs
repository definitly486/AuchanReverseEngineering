using System.Runtime.CompilerServices;

namespace System.Reflection;

internal sealed class LoaderAllocatorScout
{
	internal nint m_native;

	[MethodImpl(MethodImplOptions.InternalCall)]
	private static extern bool Destroy(nint native);

	internal LoaderAllocatorScout(nint native)
	{
		m_native = native;
	}

	~LoaderAllocatorScout()
	{
		if (!Destroy(m_native))
		{
			GC.ReRegisterForFinalize(this);
		}
	}
}
