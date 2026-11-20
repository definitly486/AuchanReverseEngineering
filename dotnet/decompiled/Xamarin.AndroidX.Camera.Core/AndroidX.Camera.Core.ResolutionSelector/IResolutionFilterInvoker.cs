using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Util;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.ResolutionSelector;

[Register("androidx/camera/core/resolutionselector/ResolutionFilter", DoNotGenerateAcw = true)]
internal class IResolutionFilterInvoker : Java.Lang.Object, IResolutionFilter, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/resolutionselector/ResolutionFilter", typeof(IResolutionFilterInvoker));

	private nint class_ref;

	private static Delegate? cb_filter_Ljava_util_List_I;

	private nint id_filter_Ljava_util_List_I;

	private static nint java_class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => class_ref;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public static IResolutionFilter? GetObject(nint handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<IResolutionFilter>(handle, transfer);
	}

	private static nint Validate(nint handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.camera.core.resolutionselector.ResolutionFilter'.");
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

	public IResolutionFilterInvoker(nint handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		nint objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	private static Delegate GetFilter_Ljava_util_List_IHandler()
	{
		if ((object)cb_filter_Ljava_util_List_I == null)
		{
			cb_filter_Ljava_util_List_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_Filter_Ljava_util_List_I));
		}
		return cb_filter_Ljava_util_List_I;
	}

	private static nint n_Filter_Ljava_util_List_I(nint jnienv, nint native__this, nint native_p0, int p1)
	{
		IResolutionFilter? resolutionFilter = Java.Lang.Object.GetObject<IResolutionFilter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<Size> p2 = JavaList<Size>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		return JavaList<Size>.ToLocalJniHandle(resolutionFilter.Filter(p2, p1));
	}

	public unsafe IList<Size> Filter(IList<Size> p0, int p1)
	{
		if (id_filter_Ljava_util_List_I == IntPtr.Zero)
		{
			id_filter_Ljava_util_List_I = JNIEnv.GetMethodID(class_ref, "filter", "(Ljava/util/List;I)Ljava/util/List;");
		}
		nint num = JavaList<Size>.ToLocalJniHandle(p0);
		JValue* ptr = stackalloc JValue[2];
		*ptr = new JValue(num);
		ptr[1] = new JValue(p1);
		IList<Size>? result = JavaList<Size>.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_filter_Ljava_util_List_I, ptr), JniHandleOwnership.TransferLocalRef);
		JNIEnv.DeleteLocalRef(num);
		return result;
	}
}
