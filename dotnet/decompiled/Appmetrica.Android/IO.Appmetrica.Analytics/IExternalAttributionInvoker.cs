using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace IO.Appmetrica.Analytics;

[Register("io/appmetrica/analytics/ExternalAttribution", DoNotGenerateAcw = true)]
internal class IExternalAttributionInvoker : Java.Lang.Object, IExternalAttribution, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_io_appmetrica_analytics_ExternalAttribution = new XAPeerMembers("io/appmetrica/analytics/ExternalAttribution", typeof(IExternalAttributionInvoker));

	private static Delegate? cb_toBytes_ToBytes_arrayB;

	private static nint java_class_ref => _members_io_appmetrica_analytics_ExternalAttribution.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_io_appmetrica_analytics_ExternalAttribution;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_io_appmetrica_analytics_ExternalAttribution.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_io_appmetrica_analytics_ExternalAttribution.ManagedPeerType;

	public IExternalAttributionInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetToBytesHandler()
	{
		if ((object)cb_toBytes_ToBytes_arrayB == null)
		{
			cb_toBytes_ToBytes_arrayB = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToBytes));
		}
		return cb_toBytes_ToBytes_arrayB;
	}

	private static nint n_ToBytes(nint jnienv, nint native__this)
	{
		return JNIEnv.NewArray(Java.Lang.Object.GetObject<IExternalAttribution>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToBytes());
	}

	public unsafe byte[]? ToBytes()
	{
		return (byte[])JNIEnv.GetArray(_members_io_appmetrica_analytics_ExternalAttribution.InstanceMethods.InvokeAbstractObjectMethod("toBytes.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
	}
}
