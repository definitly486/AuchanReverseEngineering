using System.IO;

namespace System.Reflection.Internal;

internal abstract class AbstractMemoryBlock : IDisposable
{
	public unsafe abstract byte* Pointer { get; }

	public abstract int Size { get; }

	public unsafe Stream GetStream()
	{
		return new UnmanagedMemoryStream(Pointer, Size);
	}

	public abstract void Dispose();
}
