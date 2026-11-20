using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/CameraListener", DoNotGenerateAcw = true)]
internal class ICameraListenerInvoker : Java.Lang.Object, ICameraListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_CameraListener = new XAPeerMembers("com/yandex/mapkit/map/CameraListener", typeof(ICameraListenerInvoker));

	private static Delegate? cb_onCameraPositionChanged_OnCameraPositionChanged_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_map_CameraPosition_Lcom_yandex_mapkit_map_CameraUpdateReason_Z_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_CameraListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_CameraListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_CameraListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_CameraListener.ManagedPeerType;

	public ICameraListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnCameraPositionChanged_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_map_CameraPosition_Lcom_yandex_mapkit_map_CameraUpdateReason_ZHandler()
	{
		if ((object)cb_onCameraPositionChanged_OnCameraPositionChanged_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_map_CameraPosition_Lcom_yandex_mapkit_map_CameraUpdateReason_Z_V == null)
		{
			cb_onCameraPositionChanged_OnCameraPositionChanged_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_map_CameraPosition_Lcom_yandex_mapkit_map_CameraUpdateReason_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLZ_V(n_OnCameraPositionChanged_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_map_CameraPosition_Lcom_yandex_mapkit_map_CameraUpdateReason_Z));
		}
		return cb_onCameraPositionChanged_OnCameraPositionChanged_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_map_CameraPosition_Lcom_yandex_mapkit_map_CameraUpdateReason_Z_V;
	}

	private static void n_OnCameraPositionChanged_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_map_CameraPosition_Lcom_yandex_mapkit_map_CameraUpdateReason_Z(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2, bool p3)
	{
		ICameraListener? cameraListener = Java.Lang.Object.GetObject<ICameraListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMap p4 = Java.Lang.Object.GetObject<IMap>(native_p0, JniHandleOwnership.DoNotTransfer);
		CameraPosition p5 = Java.Lang.Object.GetObject<CameraPosition>(native_p1, JniHandleOwnership.DoNotTransfer);
		CameraUpdateReason p6 = Java.Lang.Object.GetObject<CameraUpdateReason>(native_p2, JniHandleOwnership.DoNotTransfer);
		cameraListener.OnCameraPositionChanged(p4, p5, p6, p3);
	}

	public unsafe void OnCameraPositionChanged(IMap p0, CameraPosition p1, CameraUpdateReason p2, bool p3)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(p3);
			_members_com_yandex_mapkit_map_CameraListener.InstanceMethods.InvokeAbstractVoidMethod("onCameraPositionChanged.(Lcom/yandex/mapkit/map/Map;Lcom/yandex/mapkit/map/CameraPosition;Lcom/yandex/mapkit/map/CameraUpdateReason;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}
}
