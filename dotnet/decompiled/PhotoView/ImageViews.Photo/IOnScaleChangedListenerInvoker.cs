using System;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace ImageViews.Photo;

[Register("com/github/chrisbanes/photoview/OnScaleChangedListener", DoNotGenerateAcw = true)]
internal class IOnScaleChangedListenerInvoker : Java.Lang.Object, IOnScaleChangedListener, IJavaObject, IDisposable
{
	internal static readonly JniPeerMembers _members = new JniPeerMembers("com/github/chrisbanes/photoview/OnScaleChangedListener", typeof(IOnScaleChangedListenerInvoker));

	private IntPtr class_ref;

	private IntPtr id_onScaleChange_FFF;

	private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => class_ref;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public static IOnScaleChangedListener GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IOnScaleChangedListener>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.github.chrisbanes.photoview.OnScaleChangedListener"));
		}
		return handle;
	}

	protected override void Dispose(bool disposing)
	{
		if (class_ref != IntPtr.Zero)
		{
			JNIEnv.DeleteGlobalRef(class_ref);
		}
		class_ref = IntPtr.Zero;
		base.Dispose(disposing);
	}

	public IOnScaleChangedListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static void n_OnScaleChange_FFF(IntPtr jnienv, IntPtr native__this, float scaleFactor, float focusX, float focusY)
	{
		Java.Lang.Object.GetObject<IOnScaleChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnScaleChange(scaleFactor, focusX, focusY);
	}

	public unsafe void OnScaleChange(float scaleFactor, float focusX, float focusY)
	{
		if (id_onScaleChange_FFF == IntPtr.Zero)
		{
			id_onScaleChange_FFF = JNIEnv.GetMethodID(class_ref, "onScaleChange", "(FFF)V");
		}
		JValue* ptr = stackalloc JValue[3];
		*ptr = new JValue(scaleFactor);
		ptr[1] = new JValue(focusX);
		ptr[2] = new JValue(focusY);
		JNIEnv.CallVoidMethod(base.Handle, id_onScaleChange_FFF, ptr);
	}

	[UnmanagedCallersOnly]
	private static void n_OnScaleChange_FFF_mm_wrapper(IntPtr jnienv, IntPtr native__this, float scaleFactor, float focusX, float focusY)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnScaleChange_FFF(jnienv, native__this, scaleFactor, focusX, focusY);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
