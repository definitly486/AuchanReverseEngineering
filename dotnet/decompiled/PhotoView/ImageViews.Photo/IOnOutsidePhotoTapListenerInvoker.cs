using System;
using System.Runtime.InteropServices;
using Android.Runtime;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace ImageViews.Photo;

[Register("com/github/chrisbanes/photoview/OnOutsidePhotoTapListener", DoNotGenerateAcw = true)]
internal class IOnOutsidePhotoTapListenerInvoker : Java.Lang.Object, IOnOutsidePhotoTapListener, IJavaObject, IDisposable
{
	internal static readonly JniPeerMembers _members = new JniPeerMembers("com/github/chrisbanes/photoview/OnOutsidePhotoTapListener", typeof(IOnOutsidePhotoTapListenerInvoker));

	private IntPtr class_ref;

	private IntPtr id_onOutsidePhotoTap_Landroid_widget_ImageView_;

	private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => class_ref;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public static IOnOutsidePhotoTapListener GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IOnOutsidePhotoTapListener>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.github.chrisbanes.photoview.OnOutsidePhotoTapListener"));
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

	public IOnOutsidePhotoTapListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static void n_OnOutsidePhotoTap_Landroid_widget_ImageView_(IntPtr jnienv, IntPtr native__this, IntPtr native_imageView)
	{
		IOnOutsidePhotoTapListener? onOutsidePhotoTapListener = Java.Lang.Object.GetObject<IOnOutsidePhotoTapListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ImageView imageView = Java.Lang.Object.GetObject<ImageView>(native_imageView, JniHandleOwnership.DoNotTransfer);
		onOutsidePhotoTapListener.OnOutsidePhotoTap(imageView);
	}

	public unsafe void OnOutsidePhotoTap(ImageView imageView)
	{
		if (id_onOutsidePhotoTap_Landroid_widget_ImageView_ == IntPtr.Zero)
		{
			id_onOutsidePhotoTap_Landroid_widget_ImageView_ = JNIEnv.GetMethodID(class_ref, "onOutsidePhotoTap", "(Landroid/widget/ImageView;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(imageView?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_onOutsidePhotoTap_Landroid_widget_ImageView_, ptr);
	}

	[UnmanagedCallersOnly]
	private static void n_OnOutsidePhotoTap_Landroid_widget_ImageView__mm_wrapper(IntPtr jnienv, IntPtr native__this, IntPtr native_imageView)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnOutsidePhotoTap_Landroid_widget_ImageView_(jnienv, native__this, native_imageView);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
