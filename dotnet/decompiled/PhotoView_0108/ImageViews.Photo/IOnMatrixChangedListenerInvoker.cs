using System;
using System.Runtime.InteropServices;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace ImageViews.Photo;

[Register("com/github/chrisbanes/photoview/OnMatrixChangedListener", DoNotGenerateAcw = true)]
internal class IOnMatrixChangedListenerInvoker : Java.Lang.Object, IOnMatrixChangedListener, IJavaObject, IDisposable
{
	internal static readonly JniPeerMembers _members = new JniPeerMembers("com/github/chrisbanes/photoview/OnMatrixChangedListener", typeof(IOnMatrixChangedListenerInvoker));

	private IntPtr class_ref;

	private IntPtr id_onMatrixChanged_Landroid_graphics_RectF_;

	private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => class_ref;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public static IOnMatrixChangedListener GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IOnMatrixChangedListener>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.github.chrisbanes.photoview.OnMatrixChangedListener"));
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

	public IOnMatrixChangedListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static void n_OnMatrixChanged_Landroid_graphics_RectF_(IntPtr jnienv, IntPtr native__this, IntPtr native_rect)
	{
		IOnMatrixChangedListener? onMatrixChangedListener = Java.Lang.Object.GetObject<IOnMatrixChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		RectF rect = Java.Lang.Object.GetObject<RectF>(native_rect, JniHandleOwnership.DoNotTransfer);
		onMatrixChangedListener.OnMatrixChanged(rect);
	}

	public unsafe void OnMatrixChanged(RectF rect)
	{
		if (id_onMatrixChanged_Landroid_graphics_RectF_ == IntPtr.Zero)
		{
			id_onMatrixChanged_Landroid_graphics_RectF_ = JNIEnv.GetMethodID(class_ref, "onMatrixChanged", "(Landroid/graphics/RectF;)V");
		}
		JValue* ptr = stackalloc JValue[1];
		*ptr = new JValue(rect?.Handle ?? IntPtr.Zero);
		JNIEnv.CallVoidMethod(base.Handle, id_onMatrixChanged_Landroid_graphics_RectF_, ptr);
	}

	[UnmanagedCallersOnly]
	private static void n_OnMatrixChanged_Landroid_graphics_RectF__mm_wrapper(IntPtr jnienv, IntPtr native__this, IntPtr native_rect)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnMatrixChanged_Landroid_graphics_RectF_(jnienv, native__this, native_rect);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
