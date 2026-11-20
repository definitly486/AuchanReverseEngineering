using System;

namespace Java.Interop;

public sealed class JniInt16ArrayElements : JniArrayElements
{
	private JniObjectReference arrayHandle;

	public new unsafe short* Elements => (short*)base.Elements;

	public unsafe ref short this[int index]
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

	internal unsafe JniInt16ArrayElements(JniObjectReference arrayHandle, short* elements, int size)
		: base((nint)elements, size)
	{
		this.arrayHandle = arrayHandle;
	}

	protected unsafe override void Synchronize(JniReleaseArrayElementsMode releaseMode)
	{
		JniEnvironment.Arrays.ReleaseShortArrayElements(arrayHandle, Elements, releaseMode);
	}
}
