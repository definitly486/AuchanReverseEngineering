using System;

namespace Java.Interop;

public abstract class JniArrayElements : IDisposable
{
	private nint elements;

	private int size;

	internal bool IsDisposed => elements == IntPtr.Zero;

	public nint Elements
	{
		get
		{
			if (IsDisposed)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
			return elements;
		}
	}

	internal JniArrayElements(nint elements, int size)
	{
		if (elements == IntPtr.Zero)
		{
			throw new ArgumentException("'elements' must not be IntPtr.Zero.", "elements");
		}
		this.elements = elements;
		this.size = size;
	}

	protected abstract void Synchronize(JniReleaseArrayElementsMode releaseMode);

	public void Release(JniReleaseArrayElementsMode releaseMode)
	{
		if (IsDisposed)
		{
			throw new ObjectDisposedException(GetType().FullName);
		}
		Synchronize(releaseMode);
		elements = IntPtr.Zero;
	}

	public void Dispose()
	{
		if (!IsDisposed)
		{
			Release(JniReleaseArrayElementsMode.Default);
		}
	}
}
