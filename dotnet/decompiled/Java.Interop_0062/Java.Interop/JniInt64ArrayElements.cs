using System;

namespace Java.Interop;

public sealed class JniInt64ArrayElements : JniArrayElements
{
	private JniObjectReference arrayHandle;

	public new unsafe long* Elements => (long*)base.Elements;

	public unsafe ref long this[int index]
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

	internal unsafe JniInt64ArrayElements(JniObjectReference arrayHandle, long* elements, int size)
		: base((nint)elements, size)
	{
		this.arrayHandle = arrayHandle;
	}

	protected unsafe override void Synchronize(JniReleaseArrayElementsMode releaseMode)
	{
		JniEnvironment.Arrays.ReleaseLongArrayElements(arrayHandle, Elements, releaseMode);
	}
}
