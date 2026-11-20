using System;

namespace Java.Interop;

public sealed class JniSByteArrayElements : JniArrayElements
{
	private JniObjectReference arrayHandle;

	public new unsafe sbyte* Elements => (sbyte*)base.Elements;

	public unsafe ref sbyte this[int index]
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

	internal unsafe JniSByteArrayElements(JniObjectReference arrayHandle, sbyte* elements, int size)
		: base((nint)elements, size)
	{
		this.arrayHandle = arrayHandle;
	}

	protected unsafe override void Synchronize(JniReleaseArrayElementsMode releaseMode)
	{
		JniEnvironment.Arrays.ReleaseByteArrayElements(arrayHandle, Elements, releaseMode);
	}
}
