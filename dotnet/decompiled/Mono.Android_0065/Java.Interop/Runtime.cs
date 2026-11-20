using Android.Runtime;

namespace Java.Interop;

public static class Runtime
{
	public static bool IsGCUserPeer(nint value)
	{
		return JNIEnv.IsGCUserPeer(value);
	}
}
