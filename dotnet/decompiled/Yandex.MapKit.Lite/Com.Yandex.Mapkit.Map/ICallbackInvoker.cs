using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/Callback", DoNotGenerateAcw = true)]
internal class ICallbackInvoker : Java.Lang.Object, ICallback, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_Callback = new XAPeerMembers("com/yandex/mapkit/map/Callback", typeof(ICallbackInvoker));

	private static Delegate? cb_onTaskFinished_OnTaskFinished_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_Callback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_Callback;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_Callback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_Callback.ManagedPeerType;

	public ICallbackInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnTaskFinishedHandler()
	{
		if ((object)cb_onTaskFinished_OnTaskFinished_V == null)
		{
			cb_onTaskFinished_OnTaskFinished_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnTaskFinished));
		}
		return cb_onTaskFinished_OnTaskFinished_V;
	}

	private static void n_OnTaskFinished(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ICallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnTaskFinished();
	}

	public unsafe void OnTaskFinished()
	{
		_members_com_yandex_mapkit_map_Callback.InstanceMethods.InvokeAbstractVoidMethod("onTaskFinished.()V", this, null);
	}
}
