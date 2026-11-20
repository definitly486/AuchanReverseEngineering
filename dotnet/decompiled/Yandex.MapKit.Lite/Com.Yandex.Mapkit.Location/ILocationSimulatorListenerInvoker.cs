using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/LocationSimulatorListener", DoNotGenerateAcw = true)]
internal class ILocationSimulatorListenerInvoker : Java.Lang.Object, ILocationSimulatorListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_location_LocationSimulatorListener = new XAPeerMembers("com/yandex/mapkit/location/LocationSimulatorListener", typeof(ILocationSimulatorListenerInvoker));

	private static Delegate? cb_onSimulationFinished_OnSimulationFinished_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_location_LocationSimulatorListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_location_LocationSimulatorListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_location_LocationSimulatorListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_location_LocationSimulatorListener.ManagedPeerType;

	public ILocationSimulatorListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnSimulationFinishedHandler()
	{
		if ((object)cb_onSimulationFinished_OnSimulationFinished_V == null)
		{
			cb_onSimulationFinished_OnSimulationFinished_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnSimulationFinished));
		}
		return cb_onSimulationFinished_OnSimulationFinished_V;
	}

	private static void n_OnSimulationFinished(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ILocationSimulatorListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSimulationFinished();
	}

	public unsafe void OnSimulationFinished()
	{
		_members_com_yandex_mapkit_location_LocationSimulatorListener.InstanceMethods.InvokeAbstractVoidMethod("onSimulationFinished.()V", this, null);
	}
}
