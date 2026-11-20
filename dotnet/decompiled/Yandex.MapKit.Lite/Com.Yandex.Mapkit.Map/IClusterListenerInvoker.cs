using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/ClusterListener", DoNotGenerateAcw = true)]
internal class IClusterListenerInvoker : Java.Lang.Object, IClusterListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_ClusterListener = new XAPeerMembers("com/yandex/mapkit/map/ClusterListener", typeof(IClusterListenerInvoker));

	private static Delegate? cb_onClusterAdded_OnClusterAdded_Lcom_yandex_mapkit_map_Cluster__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_ClusterListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_ClusterListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_ClusterListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_ClusterListener.ManagedPeerType;

	public IClusterListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnClusterAdded_Lcom_yandex_mapkit_map_Cluster_Handler()
	{
		if ((object)cb_onClusterAdded_OnClusterAdded_Lcom_yandex_mapkit_map_Cluster__V == null)
		{
			cb_onClusterAdded_OnClusterAdded_Lcom_yandex_mapkit_map_Cluster__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnClusterAdded_Lcom_yandex_mapkit_map_Cluster_));
		}
		return cb_onClusterAdded_OnClusterAdded_Lcom_yandex_mapkit_map_Cluster__V;
	}

	private static void n_OnClusterAdded_Lcom_yandex_mapkit_map_Cluster_(nint jnienv, nint native__this, nint native_p0)
	{
		IClusterListener? clusterListener = Java.Lang.Object.GetObject<IClusterListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICluster p = Java.Lang.Object.GetObject<ICluster>(native_p0, JniHandleOwnership.DoNotTransfer);
		clusterListener.OnClusterAdded(p);
	}

	public unsafe void OnClusterAdded(ICluster p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_ClusterListener.InstanceMethods.InvokeAbstractVoidMethod("onClusterAdded.(Lcom/yandex/mapkit/map/Cluster;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
