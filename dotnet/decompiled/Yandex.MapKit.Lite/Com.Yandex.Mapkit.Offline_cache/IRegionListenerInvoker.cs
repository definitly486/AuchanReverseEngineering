using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Offline_cache;

[Register("com/yandex/mapkit/offline_cache/RegionListener", DoNotGenerateAcw = true)]
internal class IRegionListenerInvoker : Java.Lang.Object, IRegionListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_offline_cache_RegionListener = new XAPeerMembers("com/yandex/mapkit/offline_cache/RegionListener", typeof(IRegionListenerInvoker));

	private static Delegate? cb_onRegionProgress_OnRegionProgress_I_V;

	private static Delegate? cb_onRegionStateChanged_OnRegionStateChanged_I_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_offline_cache_RegionListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_offline_cache_RegionListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_offline_cache_RegionListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_offline_cache_RegionListener.ManagedPeerType;

	public IRegionListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnRegionProgress_IHandler()
	{
		if ((object)cb_onRegionProgress_OnRegionProgress_I_V == null)
		{
			cb_onRegionProgress_OnRegionProgress_I_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnRegionProgress_I));
		}
		return cb_onRegionProgress_OnRegionProgress_I_V;
	}

	private static void n_OnRegionProgress_I(nint jnienv, nint native__this, int p0)
	{
		Java.Lang.Object.GetObject<IRegionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnRegionProgress(p0);
	}

	public unsafe void OnRegionProgress(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_com_yandex_mapkit_offline_cache_RegionListener.InstanceMethods.InvokeAbstractVoidMethod("onRegionProgress.(I)V", this, ptr);
	}

	private static Delegate GetOnRegionStateChanged_IHandler()
	{
		if ((object)cb_onRegionStateChanged_OnRegionStateChanged_I_V == null)
		{
			cb_onRegionStateChanged_OnRegionStateChanged_I_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_OnRegionStateChanged_I));
		}
		return cb_onRegionStateChanged_OnRegionStateChanged_I_V;
	}

	private static void n_OnRegionStateChanged_I(nint jnienv, nint native__this, int p0)
	{
		Java.Lang.Object.GetObject<IRegionListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnRegionStateChanged(p0);
	}

	public unsafe void OnRegionStateChanged(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_com_yandex_mapkit_offline_cache_RegionListener.InstanceMethods.InvokeAbstractVoidMethod("onRegionStateChanged.(I)V", this, ptr);
	}
}
