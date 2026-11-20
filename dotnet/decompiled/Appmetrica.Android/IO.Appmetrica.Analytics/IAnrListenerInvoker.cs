using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/AnrListener", DoNotGenerateAcw = true)]
internal class IAnrListenerInvoker : Java.Lang.Object, IAnrListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_io_appmetrica_analytics_AnrListener = new XAPeerMembers("io/appmetrica/analytics/AnrListener", typeof(IAnrListenerInvoker));

	private static Delegate? cb_onAppNotResponding_OnAppNotResponding_V;

	private static nint java_class_ref => _members_io_appmetrica_analytics_AnrListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_io_appmetrica_analytics_AnrListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_io_appmetrica_analytics_AnrListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_io_appmetrica_analytics_AnrListener.ManagedPeerType;

	public IAnrListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnAppNotRespondingHandler()
	{
		if ((object)cb_onAppNotResponding_OnAppNotResponding_V == null)
		{
			cb_onAppNotResponding_OnAppNotResponding_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnAppNotResponding));
		}
		return cb_onAppNotResponding_OnAppNotResponding_V;
	}

	private static void n_OnAppNotResponding(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IAnrListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnAppNotResponding();
	}

	public unsafe void OnAppNotResponding()
	{
		_members_io_appmetrica_analytics_AnrListener.InstanceMethods.InvokeAbstractVoidMethod("onAppNotResponding.()V", this, null);
	}
}
