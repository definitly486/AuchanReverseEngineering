using Java.Lang;

namespace Android.Runtime;

[Register("mono/android/runtime/JavaObject")]
internal sealed class JavaObject : Object
{
	private object inst;

	public object Instance => inst;

	public JavaObject(object inst)
		: base(JNIEnv.StartCreateInstance("mono/android/runtime/JavaObject", "()V"), JniHandleOwnership.TransferLocalRef)
	{
		JNIEnv.FinishCreateInstance(base.Handle, "()V");
		this.inst = inst;
	}

	public override bool Equals(Object? obj)
	{
		if (obj is JavaObject javaObject)
		{
			return javaObject.inst == inst;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return inst.GetHashCode();
	}

	public override string? ToString()
	{
		if (inst == null)
		{
			return "";
		}
		return inst.ToString();
	}
}
