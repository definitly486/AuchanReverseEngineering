using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapObjectTapListener", DoNotGenerateAcw = true)]
internal class IMapObjectTapListenerInvoker : Java.Lang.Object, IMapObjectTapListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_MapObjectTapListener = new XAPeerMembers("com/yandex/mapkit/map/MapObjectTapListener", typeof(IMapObjectTapListenerInvoker));

	private static Delegate? cb_onMapObjectTap_OnMapObjectTap_Lcom_yandex_mapkit_map_MapObject_Lcom_yandex_mapkit_geometry_Point__Z;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_MapObjectTapListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_MapObjectTapListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_MapObjectTapListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_MapObjectTapListener.ManagedPeerType;

	public IMapObjectTapListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static bool n_OnMapObjectTap_Lcom_yandex_mapkit_map_MapObject_Lcom_yandex_mapkit_geometry_Point_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IMapObjectTapListener? mapObjectTapListener = Java.Lang.Object.GetObject<IMapObjectTapListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObject p = Java.Lang.Object.GetObject<IMapObject>(native_p0, JniHandleOwnership.DoNotTransfer);
		Point p2 = Java.Lang.Object.GetObject<Point>(native_p1, JniHandleOwnership.DoNotTransfer);
		return mapObjectTapListener.OnMapObjectTap(p, p2);
	}

	public unsafe bool OnMapObjectTap(IMapObject p0, Point p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			return _members_com_yandex_mapkit_map_MapObjectTapListener.InstanceMethods.InvokeAbstractBooleanMethod("onMapObjectTap.(Lcom/yandex/mapkit/map/MapObject;Lcom/yandex/mapkit/geometry/Point;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	[UnmanagedCallersOnly]
	private static byte n_OnMapObjectTap_Lcom_yandex_mapkit_map_MapObject_Lcom_yandex_mapkit_geometry_Point__mm_wrapper(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return (byte)(n_OnMapObjectTap_Lcom_yandex_mapkit_map_MapObject_Lcom_yandex_mapkit_geometry_Point_(jnienv, native__this, native_p0, native_p1) ? 1u : 0u);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
