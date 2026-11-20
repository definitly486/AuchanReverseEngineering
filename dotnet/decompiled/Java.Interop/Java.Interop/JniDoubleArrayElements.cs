using System;

namespace Java.Interop;

public sealed class JniDoubleArrayElements : JniArrayElements
{
	private JniObjectReference arrayHandle;

	public new unsafe double* Elements => (double*)base.Elements;

	public unsafe ref double this[int index]
	{
		get
		{
			if (base.IsDisposed)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
			return ref Elements[index];
		}
	}

	internal unsafe JniDoubleArrayElements(JniObjectReference arrayHandle, double* elements, int size)
		: base((nint)elements, size)
	{
		this.arrayHandle = arrayHandle;
	}

	protected unsafe override void Synchronize(JniReleaseArrayElementsMode releaseMode)
	{
		JniEnvironment.Arrays.ReleaseDoubleArrayElements(arrayHandle, Elements, releaseMode);
	}
}
