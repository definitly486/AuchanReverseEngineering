using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/ClusterTapListener", DoNotGenerateAcw = true)]
internal class IClusterTapListenerInvoker : Java.Lang.Object, IClusterTapListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_ClusterTapListener = new XAPeerMembers("com/yandex/mapkit/map/ClusterTapListener", typeof(IClusterTapListenerInvoker));

	private static Delegate? cb_onClusterTap_OnClusterTap_Lcom_yandex_mapkit_map_Cluster__Z;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_ClusterTapListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_ClusterTapListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_ClusterTapListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_ClusterTapListener.ManagedPeerType;

	public IClusterTapListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnClusterTap_Lcom_yandex_mapkit_map_Cluster_Handler()
	{
		if ((object)cb_onClusterTap_OnClusterTap_Lcom_yandex_mapkit_map_Cluster__Z == null)
		{
			cb_onClusterTap_OnClusterTap_Lcom_yandex_mapkit_map_Cluster__Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_OnClusterTap_Lcom_yandex_mapkit_map_Cluster_));
		}
		return cb_onClusterTap_OnClusterTap_Lcom_yandex_mapkit_map_Cluster__Z;
	}

	private static bool n_OnClusterTap_Lcom_yandex_mapkit_map_Cluster_(nint jnienv, nint native__this, nint native_p0)
	{
		IClusterTapListener? clusterTapListener = Java.Lang.Object.GetObject<IClusterTapListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICluster p = Java.Lang.Object.GetObject<ICluster>(native_p0, JniHandleOwnership.DoNotTransfer);
		return clusterTapListener.OnClusterTap(p);
	}

	public unsafe bool OnClusterTap(ICluster p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return _members_com_yandex_mapkit_map_ClusterTapListener.InstanceMethods.InvokeAbstractBooleanMethod("onClusterTap.(Lcom/yandex/mapkit/map/Cluster;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
