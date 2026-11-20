using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/InputListener", DoNotGenerateAcw = true)]
internal class IInputListenerInvoker : Java.Lang.Object, IInputListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_InputListener = new XAPeerMembers("com/yandex/mapkit/map/InputListener", typeof(IInputListenerInvoker));

	private static Delegate? cb_onMapLongTap_OnMapLongTap_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_geometry_Point__V;

	private static Delegate? cb_onMapTap_OnMapTap_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_geometry_Point__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_InputListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_InputListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_InputListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_InputListener.ManagedPeerType;

	public IInputListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnMapLongTap_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_geometry_Point_Handler()
	{
		if ((object)cb_onMapLongTap_OnMapLongTap_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_geometry_Point__V == null)
		{
			cb_onMapLongTap_OnMapLongTap_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_geometry_Point__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnMapLongTap_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_geometry_Point_));
		}
		return cb_onMapLongTap_OnMapLongTap_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_geometry_Point__V;
	}

	private static void n_OnMapLongTap_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_geometry_Point_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IInputListener? inputListener = Java.Lang.Object.GetObject<IInputListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMap p = Java.Lang.Object.GetObject<IMap>(native_p0, JniHandleOwnership.DoNotTransfer);
		Point p2 = Java.Lang.Object.GetObject<Point>(native_p1, JniHandleOwnership.DoNotTransfer);
		inputListener.OnMapLongTap(p, p2);
	}

	public unsafe void OnMapLongTap(IMap p0, Point p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_InputListener.InstanceMethods.InvokeAbstractVoidMethod("onMapLongTap.(Lcom/yandex/mapkit/map/Map;Lcom/yandex/mapkit/geometry/Point;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetOnMapTap_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_geometry_Point_Handler()
	{
		if ((object)cb_onMapTap_OnMapTap_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_geometry_Point__V == null)
		{
			cb_onMapTap_OnMapTap_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_geometry_Point__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnMapTap_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_geometry_Point_));
		}
		return cb_onMapTap_OnMapTap_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_geometry_Point__V;
	}

	private static void n_OnMapTap_Lcom_yandex_mapkit_map_Map_Lcom_yandex_mapkit_geometry_Point_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IInputListener? inputListener = Java.Lang.Object.GetObject<IInputListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMap p = Java.Lang.Object.GetObject<IMap>(native_p0, JniHandleOwnership.DoNotTransfer);
		Point p2 = Java.Lang.Object.GetObject<Point>(native_p1, JniHandleOwnership.DoNotTransfer);
		inputListener.OnMapTap(p, p2);
	}

	public unsafe void OnMapTap(IMap p0, Point p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_InputListener.InstanceMethods.InvokeAbstractVoidMethod("onMapTap.(Lcom/yandex/mapkit/map/Map;Lcom/yandex/mapkit/geometry/Point;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}
}
