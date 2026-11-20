using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapObjectVisitor", DoNotGenerateAcw = true)]
internal class IMapObjectVisitorInvoker : Java.Lang.Object, IMapObjectVisitor, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_MapObjectVisitor = new XAPeerMembers("com/yandex/mapkit/map/MapObjectVisitor", typeof(IMapObjectVisitorInvoker));

	private static Delegate? cb_onCircleVisited_OnCircleVisited_Lcom_yandex_mapkit_map_CircleMapObject__V;

	private static Delegate? cb_onClusterizedCollectionVisitEnd_OnClusterizedCollectionVisitEnd_Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection__V;

	private static Delegate? cb_onClusterizedCollectionVisitStart_OnClusterizedCollectionVisitStart_Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection__Z;

	private static Delegate? cb_onCollectionVisitEnd_OnCollectionVisitEnd_Lcom_yandex_mapkit_map_MapObjectCollection__V;

	private static Delegate? cb_onCollectionVisitStart_OnCollectionVisitStart_Lcom_yandex_mapkit_map_MapObjectCollection__Z;

	private static Delegate? cb_onPlacemarkVisited_OnPlacemarkVisited_Lcom_yandex_mapkit_map_PlacemarkMapObject__V;

	private static Delegate? cb_onPolygonVisited_OnPolygonVisited_Lcom_yandex_mapkit_map_PolygonMapObject__V;

	private static Delegate? cb_onPolylineVisited_OnPolylineVisited_Lcom_yandex_mapkit_map_PolylineMapObject__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_MapObjectVisitor.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_MapObjectVisitor;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_MapObjectVisitor.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_MapObjectVisitor.ManagedPeerType;

	public IMapObjectVisitorInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnCircleVisited_Lcom_yandex_mapkit_map_CircleMapObject_Handler()
	{
		if ((object)cb_onCircleVisited_OnCircleVisited_Lcom_yandex_mapkit_map_CircleMapObject__V == null)
		{
			cb_onCircleVisited_OnCircleVisited_Lcom_yandex_mapkit_map_CircleMapObject__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnCircleVisited_Lcom_yandex_mapkit_map_CircleMapObject_));
		}
		return cb_onCircleVisited_OnCircleVisited_Lcom_yandex_mapkit_map_CircleMapObject__V;
	}

	private static void n_OnCircleVisited_Lcom_yandex_mapkit_map_CircleMapObject_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectVisitor? mapObjectVisitor = Java.Lang.Object.GetObject<IMapObjectVisitor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICircleMapObject p = Java.Lang.Object.GetObject<ICircleMapObject>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectVisitor.OnCircleVisited(p);
	}

	public unsafe void OnCircleVisited(ICircleMapObject p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapObjectVisitor.InstanceMethods.InvokeAbstractVoidMethod("onCircleVisited.(Lcom/yandex/mapkit/map/CircleMapObject;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnClusterizedCollectionVisitEnd_Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection_Handler()
	{
		if ((object)cb_onClusterizedCollectionVisitEnd_OnClusterizedCollectionVisitEnd_Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection__V == null)
		{
			cb_onClusterizedCollectionVisitEnd_OnClusterizedCollectionVisitEnd_Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnClusterizedCollectionVisitEnd_Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection_));
		}
		return cb_onClusterizedCollectionVisitEnd_OnClusterizedCollectionVisitEnd_Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection__V;
	}

	private static void n_OnClusterizedCollectionVisitEnd_Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectVisitor? mapObjectVisitor = Java.Lang.Object.GetObject<IMapObjectVisitor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IClusterizedPlacemarkCollection p = Java.Lang.Object.GetObject<IClusterizedPlacemarkCollection>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectVisitor.OnClusterizedCollectionVisitEnd(p);
	}

	public unsafe void OnClusterizedCollectionVisitEnd(IClusterizedPlacemarkCollection p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapObjectVisitor.InstanceMethods.InvokeAbstractVoidMethod("onClusterizedCollectionVisitEnd.(Lcom/yandex/mapkit/map/ClusterizedPlacemarkCollection;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnClusterizedCollectionVisitStart_Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection_Handler()
	{
		if ((object)cb_onClusterizedCollectionVisitStart_OnClusterizedCollectionVisitStart_Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection__Z == null)
		{
			cb_onClusterizedCollectionVisitStart_OnClusterizedCollectionVisitStart_Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection__Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_OnClusterizedCollectionVisitStart_Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection_));
		}
		return cb_onClusterizedCollectionVisitStart_OnClusterizedCollectionVisitStart_Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection__Z;
	}

	private static bool n_OnClusterizedCollectionVisitStart_Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectVisitor? mapObjectVisitor = Java.Lang.Object.GetObject<IMapObjectVisitor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IClusterizedPlacemarkCollection p = Java.Lang.Object.GetObject<IClusterizedPlacemarkCollection>(native_p0, JniHandleOwnership.DoNotTransfer);
		return mapObjectVisitor.OnClusterizedCollectionVisitStart(p);
	}

	public unsafe bool OnClusterizedCollectionVisitStart(IClusterizedPlacemarkCollection p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return _members_com_yandex_mapkit_map_MapObjectVisitor.InstanceMethods.InvokeAbstractBooleanMethod("onClusterizedCollectionVisitStart.(Lcom/yandex/mapkit/map/ClusterizedPlacemarkCollection;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnCollectionVisitEnd_Lcom_yandex_mapkit_map_MapObjectCollection_Handler()
	{
		if ((object)cb_onCollectionVisitEnd_OnCollectionVisitEnd_Lcom_yandex_mapkit_map_MapObjectCollection__V == null)
		{
			cb_onCollectionVisitEnd_OnCollectionVisitEnd_Lcom_yandex_mapkit_map_MapObjectCollection__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnCollectionVisitEnd_Lcom_yandex_mapkit_map_MapObjectCollection_));
		}
		return cb_onCollectionVisitEnd_OnCollectionVisitEnd_Lcom_yandex_mapkit_map_MapObjectCollection__V;
	}

	private static void n_OnCollectionVisitEnd_Lcom_yandex_mapkit_map_MapObjectCollection_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectVisitor? mapObjectVisitor = Java.Lang.Object.GetObject<IMapObjectVisitor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectCollection p = Java.Lang.Object.GetObject<IMapObjectCollection>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectVisitor.OnCollectionVisitEnd(p);
	}

	public unsafe void OnCollectionVisitEnd(IMapObjectCollection p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapObjectVisitor.InstanceMethods.InvokeAbstractVoidMethod("onCollectionVisitEnd.(Lcom/yandex/mapkit/map/MapObjectCollection;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnCollectionVisitStart_Lcom_yandex_mapkit_map_MapObjectCollection_Handler()
	{
		if ((object)cb_onCollectionVisitStart_OnCollectionVisitStart_Lcom_yandex_mapkit_map_MapObjectCollection__Z == null)
		{
			cb_onCollectionVisitStart_OnCollectionVisitStart_Lcom_yandex_mapkit_map_MapObjectCollection__Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_OnCollectionVisitStart_Lcom_yandex_mapkit_map_MapObjectCollection_));
		}
		return cb_onCollectionVisitStart_OnCollectionVisitStart_Lcom_yandex_mapkit_map_MapObjectCollection__Z;
	}

	private static bool n_OnCollectionVisitStart_Lcom_yandex_mapkit_map_MapObjectCollection_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectVisitor? mapObjectVisitor = Java.Lang.Object.GetObject<IMapObjectVisitor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectCollection p = Java.Lang.Object.GetObject<IMapObjectCollection>(native_p0, JniHandleOwnership.DoNotTransfer);
		return mapObjectVisitor.OnCollectionVisitStart(p);
	}

	public unsafe bool OnCollectionVisitStart(IMapObjectCollection p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return _members_com_yandex_mapkit_map_MapObjectVisitor.InstanceMethods.InvokeAbstractBooleanMethod("onCollectionVisitStart.(Lcom/yandex/mapkit/map/MapObjectCollection;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnPlacemarkVisited_Lcom_yandex_mapkit_map_PlacemarkMapObject_Handler()
	{
		if ((object)cb_onPlacemarkVisited_OnPlacemarkVisited_Lcom_yandex_mapkit_map_PlacemarkMapObject__V == null)
		{
			cb_onPlacemarkVisited_OnPlacemarkVisited_Lcom_yandex_mapkit_map_PlacemarkMapObject__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPlacemarkVisited_Lcom_yandex_mapkit_map_PlacemarkMapObject_));
		}
		return cb_onPlacemarkVisited_OnPlacemarkVisited_Lcom_yandex_mapkit_map_PlacemarkMapObject__V;
	}

	private static void n_OnPlacemarkVisited_Lcom_yandex_mapkit_map_PlacemarkMapObject_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectVisitor? mapObjectVisitor = Java.Lang.Object.GetObject<IMapObjectVisitor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IPlacemarkMapObject p = Java.Lang.Object.GetObject<IPlacemarkMapObject>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectVisitor.OnPlacemarkVisited(p);
	}

	public unsafe void OnPlacemarkVisited(IPlacemarkMapObject p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapObjectVisitor.InstanceMethods.InvokeAbstractVoidMethod("onPlacemarkVisited.(Lcom/yandex/mapkit/map/PlacemarkMapObject;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnPolygonVisited_Lcom_yandex_mapkit_map_PolygonMapObject_Handler()
	{
		if ((object)cb_onPolygonVisited_OnPolygonVisited_Lcom_yandex_mapkit_map_PolygonMapObject__V == null)
		{
			cb_onPolygonVisited_OnPolygonVisited_Lcom_yandex_mapkit_map_PolygonMapObject__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPolygonVisited_Lcom_yandex_mapkit_map_PolygonMapObject_));
		}
		return cb_onPolygonVisited_OnPolygonVisited_Lcom_yandex_mapkit_map_PolygonMapObject__V;
	}

	private static void n_OnPolygonVisited_Lcom_yandex_mapkit_map_PolygonMapObject_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectVisitor? mapObjectVisitor = Java.Lang.Object.GetObject<IMapObjectVisitor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IPolygonMapObject p = Java.Lang.Object.GetObject<IPolygonMapObject>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectVisitor.OnPolygonVisited(p);
	}

	public unsafe void OnPolygonVisited(IPolygonMapObject p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapObjectVisitor.InstanceMethods.InvokeAbstractVoidMethod("onPolygonVisited.(Lcom/yandex/mapkit/map/PolygonMapObject;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnPolylineVisited_Lcom_yandex_mapkit_map_PolylineMapObject_Handler()
	{
		if ((object)cb_onPolylineVisited_OnPolylineVisited_Lcom_yandex_mapkit_map_PolylineMapObject__V == null)
		{
			cb_onPolylineVisited_OnPolylineVisited_Lcom_yandex_mapkit_map_PolylineMapObject__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnPolylineVisited_Lcom_yandex_mapkit_map_PolylineMapObject_));
		}
		return cb_onPolylineVisited_OnPolylineVisited_Lcom_yandex_mapkit_map_PolylineMapObject__V;
	}

	private static void n_OnPolylineVisited_Lcom_yandex_mapkit_map_PolylineMapObject_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectVisitor? mapObjectVisitor = Java.Lang.Object.GetObject<IMapObjectVisitor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IPolylineMapObject p = Java.Lang.Object.GetObject<IPolylineMapObject>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectVisitor.OnPolylineVisited(p);
	}

	public unsafe void OnPolylineVisited(IPolylineMapObject p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapObjectVisitor.InstanceMethods.InvokeAbstractVoidMethod("onPolylineVisited.(Lcom/yandex/mapkit/map/PolylineMapObject;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
