using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Offline_cache;

[Register("com/yandex/mapkit/offline_cache/RegionListUpdatesListener", DoNotGenerateAcw = true)]
internal class IRegionListUpdatesListenerInvoker : Java.Lang.Object, IRegionListUpdatesListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_offline_cache_RegionListUpdatesListener = new XAPeerMembers("com/yandex/mapkit/offline_cache/RegionListUpdatesListener", typeof(IRegionListUpdatesListenerInvoker));

	private static Delegate? cb_onListUpdated_OnListUpdated_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_offline_cache_RegionListUpdatesListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_offline_cache_RegionListUpdatesListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_offline_cache_RegionListUpdatesListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_offline_cache_RegionListUpdatesListener.ManagedPeerType;

	public IRegionListUpdatesListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnListUpdatedHandler()
	{
		if ((object)cb_onListUpdated_OnListUpdated_V == null)
		{
			cb_onListUpdated_OnListUpdated_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnListUpdated));
		}
		return cb_onListUpdated_OnListUpdated_V;
	}

	private static void n_OnListUpdated(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IRegionListUpdatesListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnListUpdated();
	}

	public unsafe void OnListUpdated()
	{
		_members_com_yandex_mapkit_offline_cache_RegionListUpdatesListener.InstanceMethods.InvokeAbstractVoidMethod("onListUpdated.()V", this, null);
	}
}
