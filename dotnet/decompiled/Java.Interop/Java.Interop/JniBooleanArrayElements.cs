using System;

namespace Java.Interop;

public sealed class JniBooleanArrayElements : JniArrayElements
{
	private JniObjectReference arrayHandle;

	public new unsafe bool* Elements => (bool*)base.Elements;

	public unsafe ref bool this[int index]
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

	internal unsafe JniBooleanArrayElements(JniObjectReference arrayHandle, bool* elements, int size)
		: base((nint)elements, size)
	{
		this.arrayHandle = arrayHandle;
	}

	protected unsafe override void Synchronize(JniReleaseArrayElementsMode releaseMode)
	{
		JniEnvironment.Arrays.ReleaseBooleanArrayElements(arrayHandle, Elements, releaseMode);
	}
}
