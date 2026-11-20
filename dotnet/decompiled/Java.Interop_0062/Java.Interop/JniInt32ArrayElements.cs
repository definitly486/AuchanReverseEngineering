using System;

namespace Java.Interop;

public sealed class JniInt32ArrayElements : JniArrayElements
{
	private JniObjectReference arrayHandle;

	public new unsafe int* Elements => (int*)base.Elements;

	public unsafe ref int this[int index]
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

	internal unsafe JniInt32ArrayElements(JniObjectReference arrayHandle, int* elements, int size)
		: base((nint)elements, size)
	{
		this.arrayHandle = arrayHandle;
	}

	protected unsafe override void Synchronize(JniReleaseArrayElementsMode releaseMode)
	{
		JniEnvironment.Arrays.ReleaseIntArrayElements(arrayHandle, Elements, releaseMode);
	}
}
