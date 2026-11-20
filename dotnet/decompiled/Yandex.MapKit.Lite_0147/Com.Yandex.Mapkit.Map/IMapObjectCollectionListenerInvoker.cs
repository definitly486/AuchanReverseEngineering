using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapObjectCollectionListener", DoNotGenerateAcw = true)]
internal class IMapObjectCollectionListenerInvoker : Java.Lang.Object, IMapObjectCollectionListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_MapObjectCollectionListener = new XAPeerMembers("com/yandex/mapkit/map/MapObjectCollectionListener", typeof(IMapObjectCollectionListenerInvoker));

	private static Delegate? cb_onMapObjectAdded_OnMapObjectAdded_Lcom_yandex_mapkit_map_MapObject__V;

	private static Delegate? cb_onMapObjectRemoved_OnMapObjectRemoved_Lcom_yandex_mapkit_map_MapObject__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_MapObjectCollectionListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_MapObjectCollectionListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_MapObjectCollectionListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_MapObjectCollectionListener.ManagedPeerType;

	public IMapObjectCollectionListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnMapObjectAdded_Lcom_yandex_mapkit_map_MapObject_Handler()
	{
		if ((object)cb_onMapObjectAdded_OnMapObjectAdded_Lcom_yandex_mapkit_map_MapObject__V == null)
		{
			cb_onMapObjectAdded_OnMapObjectAdded_Lcom_yandex_mapkit_map_MapObject__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnMapObjectAdded_Lcom_yandex_mapkit_map_MapObject_));
		}
		return cb_onMapObjectAdded_OnMapObjectAdded_Lcom_yandex_mapkit_map_MapObject__V;
	}

	private static void n_OnMapObjectAdded_Lcom_yandex_mapkit_map_MapObject_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollectionListener? mapObjectCollectionListener = Java.Lang.Object.GetObject<IMapObjectCollectionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObject p = Java.Lang.Object.GetObject<IMapObject>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectCollectionListener.OnMapObjectAdded(p);
	}

	public unsafe void OnMapObjectAdded(IMapObject p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapObjectCollectionListener.InstanceMethods.InvokeAbstractVoidMethod("onMapObjectAdded.(Lcom/yandex/mapkit/map/MapObject;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnMapObjectRemoved_Lcom_yandex_mapkit_map_MapObject_Handler()
	{
		if ((object)cb_onMapObjectRemoved_OnMapObjectRemoved_Lcom_yandex_mapkit_map_MapObject__V == null)
		{
			cb_onMapObjectRemoved_OnMapObjectRemoved_Lcom_yandex_mapkit_map_MapObject__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnMapObjectRemoved_Lcom_yandex_mapkit_map_MapObject_));
		}
		return cb_onMapObjectRemoved_OnMapObjectRemoved_Lcom_yandex_mapkit_map_MapObject__V;
	}

	private static void n_OnMapObjectRemoved_Lcom_yandex_mapkit_map_MapObject_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollectionListener? mapObjectCollectionListener = Java.Lang.Object.GetObject<IMapObjectCollectionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObject p = Java.Lang.Object.GetObject<IMapObject>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectCollectionListener.OnMapObjectRemoved(p);
	}

	public unsafe void OnMapObjectRemoved(IMapObject p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapObjectCollectionListener.InstanceMethods.InvokeAbstractVoidMethod("onMapObjectRemoved.(Lcom/yandex/mapkit/map/MapObject;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
