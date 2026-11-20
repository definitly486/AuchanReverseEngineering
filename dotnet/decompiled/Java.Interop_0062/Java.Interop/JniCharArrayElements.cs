using System;

namespace Java.Interop;

public sealed class JniCharArrayElements : JniArrayElements
{
	private JniObjectReference arrayHandle;

	public new unsafe char* Elements => (char*)base.Elements;

	public unsafe ref char this[int index]
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

	internal unsafe JniCharArrayElements(JniObjectReference arrayHandle, char* elements, int size)
		: base((nint)elements, size)
	{
		this.arrayHandle = arrayHandle;
	}

	protected unsafe override void Synchronize(JniReleaseArrayElementsMode releaseMode)
	{
		JniEnvironment.Arrays.ReleaseCharArrayElements(arrayHandle, Elements, releaseMode);
	}
}
