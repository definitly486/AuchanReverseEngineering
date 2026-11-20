using System;

namespace Java.Interop;

public sealed class JniSingleArrayElements : JniArrayElements
{
	private JniObjectReference arrayHandle;

	public new unsafe float* Elements => (float*)base.Elements;

	public unsafe ref float this[int index]
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

	internal unsafe JniSingleArrayElements(JniObjectReference arrayHandle, float* elements, int size)
		: base((nint)elements, size)
	{
		this.arrayHandle = arrayHandle;
	}

	protected unsafe override void Synchronize(JniReleaseArrayElementsMode releaseMode)
	{
		JniEnvironment.Arrays.ReleaseFloatArrayElements(arrayHandle, Elements, releaseMode);
	}
}
