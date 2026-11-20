using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapObjectDragListener", DoNotGenerateAcw = true)]
internal class IMapObjectDragListenerInvoker : Java.Lang.Object, IMapObjectDragListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_MapObjectDragListener = new XAPeerMembers("com/yandex/mapkit/map/MapObjectDragListener", typeof(IMapObjectDragListenerInvoker));

	private static Delegate? cb_onMapObjectDrag_OnMapObjectDrag_Lcom_yandex_mapkit_map_MapObject_Lcom_yandex_mapkit_geometry_Point__V;

	private static Delegate? cb_onMapObjectDragEnd_OnMapObjectDragEnd_Lcom_yandex_mapkit_map_MapObject__V;

	private static Delegate? cb_onMapObjectDragStart_OnMapObjectDragStart_Lcom_yandex_mapkit_map_MapObject__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_MapObjectDragListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_MapObjectDragListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_MapObjectDragListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_MapObjectDragListener.ManagedPeerType;

	public IMapObjectDragListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnMapObjectDrag_Lcom_yandex_mapkit_map_MapObject_Lcom_yandex_mapkit_geometry_Point_Handler()
	{
		if ((object)cb_onMapObjectDrag_OnMapObjectDrag_Lcom_yandex_mapkit_map_MapObject_Lcom_yandex_mapkit_geometry_Point__V == null)
		{
			cb_onMapObjectDrag_OnMapObjectDrag_Lcom_yandex_mapkit_map_MapObject_Lcom_yandex_mapkit_geometry_Point__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_OnMapObjectDrag_Lcom_yandex_mapkit_map_MapObject_Lcom_yandex_mapkit_geometry_Point_));
		}
		return cb_onMapObjectDrag_OnMapObjectDrag_Lcom_yandex_mapkit_map_MapObject_Lcom_yandex_mapkit_geometry_Point__V;
	}

	private static void n_OnMapObjectDrag_Lcom_yandex_mapkit_map_MapObject_Lcom_yandex_mapkit_geometry_Point_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IMapObjectDragListener? mapObjectDragListener = Java.Lang.Object.GetObject<IMapObjectDragListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObject p = Java.Lang.Object.GetObject<IMapObject>(native_p0, JniHandleOwnership.DoNotTransfer);
		Point p2 = Java.Lang.Object.GetObject<Point>(native_p1, JniHandleOwnership.DoNotTransfer);
		mapObjectDragListener.OnMapObjectDrag(p, p2);
	}

	public unsafe void OnMapObjectDrag(IMapObject p0, Point p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_MapObjectDragListener.InstanceMethods.InvokeAbstractVoidMethod("onMapObjectDrag.(Lcom/yandex/mapkit/map/MapObject;Lcom/yandex/mapkit/geometry/Point;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetOnMapObjectDragEnd_Lcom_yandex_mapkit_map_MapObject_Handler()
	{
		if ((object)cb_onMapObjectDragEnd_OnMapObjectDragEnd_Lcom_yandex_mapkit_map_MapObject__V == null)
		{
			cb_onMapObjectDragEnd_OnMapObjectDragEnd_Lcom_yandex_mapkit_map_MapObject__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnMapObjectDragEnd_Lcom_yandex_mapkit_map_MapObject_));
		}
		return cb_onMapObjectDragEnd_OnMapObjectDragEnd_Lcom_yandex_mapkit_map_MapObject__V;
	}

	private static void n_OnMapObjectDragEnd_Lcom_yandex_mapkit_map_MapObject_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectDragListener? mapObjectDragListener = Java.Lang.Object.GetObject<IMapObjectDragListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObject p = Java.Lang.Object.GetObject<IMapObject>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectDragListener.OnMapObjectDragEnd(p);
	}

	public unsafe void OnMapObjectDragEnd(IMapObject p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapObjectDragListener.InstanceMethods.InvokeAbstractVoidMethod("onMapObjectDragEnd.(Lcom/yandex/mapkit/map/MapObject;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnMapObjectDragStart_Lcom_yandex_mapkit_map_MapObject_Handler()
	{
		if ((object)cb_onMapObjectDragStart_OnMapObjectDragStart_Lcom_yandex_mapkit_map_MapObject__V == null)
		{
			cb_onMapObjectDragStart_OnMapObjectDragStart_Lcom_yandex_mapkit_map_MapObject__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnMapObjectDragStart_Lcom_yandex_mapkit_map_MapObject_));
		}
		return cb_onMapObjectDragStart_OnMapObjectDragStart_Lcom_yandex_mapkit_map_MapObject__V;
	}

	private static void n_OnMapObjectDragStart_Lcom_yandex_mapkit_map_MapObject_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectDragListener? mapObjectDragListener = Java.Lang.Object.GetObject<IMapObjectDragListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObject p = Java.Lang.Object.GetObject<IMapObject>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectDragListener.OnMapObjectDragStart(p);
	}

	public unsafe void OnMapObjectDragStart(IMapObject p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapObjectDragListener.InstanceMethods.InvokeAbstractVoidMethod("onMapObjectDragStart.(Lcom/yandex/mapkit/map/MapObject;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
