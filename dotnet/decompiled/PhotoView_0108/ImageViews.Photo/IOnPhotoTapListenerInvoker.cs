using System;
using System.Runtime.InteropServices;
using Android.Runtime;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace ImageViews.Photo;

[Register("com/github/chrisbanes/photoview/OnPhotoTapListener", DoNotGenerateAcw = true)]
internal class IOnPhotoTapListenerInvoker : Java.Lang.Object, IOnPhotoTapListener, IJavaObject, IDisposable
{
	internal static readonly JniPeerMembers _members = new JniPeerMembers("com/github/chrisbanes/photoview/OnPhotoTapListener", typeof(IOnPhotoTapListenerInvoker));

	private IntPtr class_ref;

	private IntPtr id_onPhotoTap_Landroid_widget_ImageView_FF;

	private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => class_ref;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public static IOnPhotoTapListener GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IOnPhotoTapListener>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.github.chrisbanes.photoview.OnPhotoTapListener"));
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

	public IOnPhotoTapListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static void n_OnPhotoTap_Landroid_widget_ImageView_FF(IntPtr jnienv, IntPtr native__this, IntPtr native_view, float x, float y)
	{
		IOnPhotoTapListener? onPhotoTapListener = Java.Lang.Object.GetObject<IOnPhotoTapListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ImageView view = Java.Lang.Object.GetObject<ImageView>(native_view, JniHandleOwnership.DoNotTransfer);
		onPhotoTapListener.OnPhotoTap(view, x, y);
	}

	public unsafe void OnPhotoTap(ImageView view, float x, float y)
	{
		if (id_onPhotoTap_Landroid_widget_ImageView_FF == IntPtr.Zero)
		{
			id_onPhotoTap_Landroid_widget_ImageView_FF = JNIEnv.GetMethodID(class_ref, "onPhotoTap", "(Landroid/widget/ImageView;FF)V");
		}
		JValue* ptr = stackalloc JValue[3];
		*ptr = new JValue(view?.Handle ?? IntPtr.Zero);
		ptr[1] = new JValue(x);
		ptr[2] = new JValue(y);
		JNIEnv.CallVoidMethod(base.Handle, id_onPhotoTap_Landroid_widget_ImageView_FF, ptr);
	}

	[UnmanagedCallersOnly]
	private static void n_OnPhotoTap_Landroid_widget_ImageView_FF_mm_wrapper(IntPtr jnienv, IntPtr native__this, IntPtr native_view, float x, float y)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnPhotoTap_Landroid_widget_ImageView_FF(jnienv, native__this, native_view, x, y);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
