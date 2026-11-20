using System;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace ImageViews.Photo;

[Register("com/github/chrisbanes/photoview/OnViewDragListener", DoNotGenerateAcw = true)]
internal class IOnViewDragListenerInvoker : Java.Lang.Object, IOnViewDragListener, IJavaObject, IDisposable
{
	internal static readonly JniPeerMembers _members = new JniPeerMembers("com/github/chrisbanes/photoview/OnViewDragListener", typeof(IOnViewDragListenerInvoker));

	private IntPtr class_ref;

	private IntPtr id_onDrag_FF;

	private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

	public override JniPeerMembers JniPeerMembers => _members;

	protected override IntPtr ThresholdClass => class_ref;

	protected override Type ThresholdType => _members.ManagedPeerType;

	public static IOnViewDragListener GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IOnViewDragListener>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.github.chrisbanes.photoview.OnViewDragListener"));
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

	public IOnViewDragListenerInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static void n_OnDrag_FF(IntPtr jnienv, IntPtr native__this, float deltaX, float deltaY)
	{
		Java.Lang.Object.GetObject<IOnViewDragListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnDrag(deltaX, deltaY);
	}

	public unsafe void OnDrag(float deltaX, float deltaY)
	{
		if (id_onDrag_FF == IntPtr.Zero)
		{
			id_onDrag_FF = JNIEnv.GetMethodID(class_ref, "onDrag", "(FF)V");
		}
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(deltaX);
		ptr[1] = new JValue(deltaY);
		JNIEnv.CallVoidMethod(base.Handle, id_onDrag_FF, ptr);
	}

	[UnmanagedCallersOnly]
	private static void n_OnDrag_FF_mm_wrapper(IntPtr jnienv, IntPtr native__this, float deltaX, float deltaY)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnDrag_FF(jnienv, native__this, deltaX, deltaY);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
