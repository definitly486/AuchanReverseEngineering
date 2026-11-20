using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapLoadedListener", DoNotGenerateAcw = true)]
internal class IMapLoadedListenerInvoker : Java.Lang.Object, IMapLoadedListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_MapLoadedListener = new XAPeerMembers("com/yandex/mapkit/map/MapLoadedListener", typeof(IMapLoadedListenerInvoker));

	private static Delegate? cb_onMapLoaded_OnMapLoaded_Lcom_yandex_mapkit_map_MapLoadStatistics__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_MapLoadedListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_MapLoadedListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_MapLoadedListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_MapLoadedListener.ManagedPeerType;

	public IMapLoadedListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnMapLoaded_Lcom_yandex_mapkit_map_MapLoadStatistics_Handler()
	{
		if ((object)cb_onMapLoaded_OnMapLoaded_Lcom_yandex_mapkit_map_MapLoadStatistics__V == null)
		{
			cb_onMapLoaded_OnMapLoaded_Lcom_yandex_mapkit_map_MapLoadStatistics__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnMapLoaded_Lcom_yandex_mapkit_map_MapLoadStatistics_));
		}
		return cb_onMapLoaded_OnMapLoaded_Lcom_yandex_mapkit_map_MapLoadStatistics__V;
	}

	private static void n_OnMapLoaded_Lcom_yandex_mapkit_map_MapLoadStatistics_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapLoadedListener? mapLoadedListener = Java.Lang.Object.GetObject<IMapLoadedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		MapLoadStatistics p = Java.Lang.Object.GetObject<MapLoadStatistics>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapLoadedListener.OnMapLoaded(p);
	}

	public unsafe void OnMapLoaded(MapLoadStatistics p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_MapLoadedListener.InstanceMethods.InvokeAbstractVoidMethod("onMapLoaded.(Lcom/yandex/mapkit/map/MapLoadStatistics;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
