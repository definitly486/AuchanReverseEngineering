using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/PlacemarksStyler", DoNotGenerateAcw = true)]
internal class IPlacemarksStylerInvoker : Java.Lang.Object, IPlacemarksStyler, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_PlacemarksStyler = new XAPeerMembers("com/yandex/mapkit/map/PlacemarksStyler", typeof(IPlacemarksStylerInvoker));

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_setScaleFunction_SetScaleFunction_Ljava_util_List__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_PlacemarksStyler.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_PlacemarksStyler;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_PlacemarksStyler.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_PlacemarksStyler.ManagedPeerType;

	public unsafe bool IsValid => _members_com_yandex_mapkit_map_PlacemarksStyler.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public IPlacemarksStylerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsValidHandler()
	{
		if ((object)cb_isValid_IsValid_Z == null)
		{
			cb_isValid_IsValid_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsValid));
		}
		return cb_isValid_IsValid_Z;
	}

	private static bool n_IsValid(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPlacemarksStyler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetSetScaleFunction_Ljava_util_List_Handler()
	{
		if ((object)cb_setScaleFunction_SetScaleFunction_Ljava_util_List__V == null)
		{
			cb_setScaleFunction_SetScaleFunction_Ljava_util_List__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetScaleFunction_Ljava_util_List_));
		}
		return cb_setScaleFunction_SetScaleFunction_Ljava_util_List__V;
	}

	private static void n_SetScaleFunction_Ljava_util_List_(nint jnienv, nint native__this, nint native_p0)
	{
		IPlacemarksStyler? placemarksStyler = Java.Lang.Object.GetObject<IPlacemarksStyler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<PointF> scaleFunction = JavaList<PointF>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		placemarksStyler.SetScaleFunction(scaleFunction);
	}

	public unsafe void SetScaleFunction(IList<PointF> p0)
	{
		nint num = JavaList<PointF>.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_com_yandex_mapkit_map_PlacemarksStyler.InstanceMethods.InvokeAbstractVoidMethod("setScaleFunction.(Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}
}
