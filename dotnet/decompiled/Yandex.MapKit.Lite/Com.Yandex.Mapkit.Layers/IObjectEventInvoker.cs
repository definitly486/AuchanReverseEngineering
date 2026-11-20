using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/ObjectEvent", DoNotGenerateAcw = true)]
internal class IObjectEventInvoker : Java.Lang.Object, IObjectEvent, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_layers_ObjectEvent = new XAPeerMembers("com/yandex/mapkit/layers/ObjectEvent", typeof(IObjectEventInvoker));

	private static Delegate? cb_isValid_IsValid_Z;

	private static nint java_class_ref => _members_com_yandex_mapkit_layers_ObjectEvent.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_layers_ObjectEvent;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_layers_ObjectEvent.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_layers_ObjectEvent.ManagedPeerType;

	public unsafe bool IsValid => _members_com_yandex_mapkit_layers_ObjectEvent.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public IObjectEventInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsValidHandler()
	{
		if ((object)cb_isValid_IsValid_Z == null)
		{
			cb_isValid_IsValid_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsValid));
		}
		return cb_isValid_IsValid_Z;
	}

	private static bool n_IsValid(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IObjectEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}
}
