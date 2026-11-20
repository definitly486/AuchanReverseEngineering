using System;
using System.Runtime.InteropServices;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace ImageViews.Photo;

[Register("com/github/chrisbanes/photoview/OnSingleFlingListener", DoNotGenerateAcw = true)]
internal class IOnSingleFlingListenerInvoker : Java.Lang.Object, IOnSingleFlingListener, IJavaObject, IDisposable
{
	internal static readonly JniPeerMembers _members = new JniPeerMembers("com/github/chrisbanes/photoview/OnSingleFlingListener", typeof(IOnSingleFlingListenerInvoker));

	private IntPtr class_ref;

	private IntPtr id_onFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF;

	private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => class_ref;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public static IOnSingleFlingListener GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IOnSingleFlingListener>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.github.chrisbanes.photoview.OnSingleFlingListener"));
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

	public IOnSingleFlingListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static bool n_OnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF(IntPtr jnienv, IntPtr native__this, IntPtr native_event1, IntPtr native_event2, float velocityX, float velocityY)
	{
		IOnSingleFlingListener? onSingleFlingListener = Java.Lang.Object.GetObject<IOnSingleFlingListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		MotionEvent @event = Java.Lang.Object.GetObject<MotionEvent>(native_event1, JniHandleOwnership.DoNotTransfer);
		MotionEvent event2 = Java.Lang.Object.GetObject<MotionEvent>(native_event2, JniHandleOwnership.DoNotTransfer);
		return onSingleFlingListener.OnFling(@event, event2, velocityX, velocityY);
	}

	public unsafe bool OnFling(MotionEvent event1, MotionEvent event2, float velocityX, float velocityY)
	{
		if (id_onFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF == IntPtr.Zero)
		{
			id_onFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF = JNIEnv.GetMethodID(class_ref, "onFling", "(Landroid/view/MotionEvent;Landroid/view/MotionEvent;FF)Z");
		}
		JValue* ptr = stackalloc JValue[4];
		*ptr = new JValue(event1?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(event2?.Handle ?? IntPtr.Zero);
		ptr[2] = new JValue(velocityX);
		ptr[3] = new JValue(velocityY);
		return JNIEnv.CallBooleanMethod(base.Handle, id_onFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF, ptr);
	}

	[UnmanagedCallersOnly]
	private static byte n_OnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF_mm_wrapper(IntPtr jnienv, IntPtr native__this, IntPtr native_event1, IntPtr native_event2, float velocityX, float velocityY)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return (byte)(n_OnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FF(jnienv, native__this, native_event1, native_event2, velocityX, velocityY) ? 1u : 0u);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
