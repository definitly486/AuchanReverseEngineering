using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Layers;

[Register("com/yandex/mapkit/layers/GeoObjectTapEvent", DoNotGenerateAcw = true)]
internal class IGeoObjectTapEventInvoker : Java.Lang.Object, IGeoObjectTapEvent, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_layers_GeoObjectTapEvent = new XAPeerMembers("com/yandex/mapkit/layers/GeoObjectTapEvent", typeof(IGeoObjectTapEventInvoker));

	private static Delegate? cb_getGeoObject_GetGeoObject_Lcom_yandex_mapkit_GeoObject_;

	private static Delegate? cb_isValid_IsValid_Z;

	private static nint java_class_ref => _members_com_yandex_mapkit_layers_GeoObjectTapEvent.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_layers_GeoObjectTapEvent;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_layers_GeoObjectTapEvent.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_layers_GeoObjectTapEvent.ManagedPeerType;

	public unsafe GeoObject GeoObject => Java.Lang.Object.GetObject<GeoObject>(_members_com_yandex_mapkit_layers_GeoObjectTapEvent.InstanceMethods.InvokeAbstractObjectMethod("getGeoObject.()Lcom/yandex/mapkit/GeoObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe bool IsValid => _members_com_yandex_mapkit_layers_GeoObjectTapEvent.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public IGeoObjectTapEventInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetGeoObjectHandler()
	{
		if ((object)cb_getGeoObject_GetGeoObject_Lcom_yandex_mapkit_GeoObject_ == null)
		{
			cb_getGeoObject_GetGeoObject_Lcom_yandex_mapkit_GeoObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetGeoObject));
		}
		return cb_getGeoObject_GetGeoObject_Lcom_yandex_mapkit_GeoObject_;
	}

	private static nint n_GetGeoObject(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IGeoObjectTapEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GeoObject);
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
		return Java.Lang.Object.GetObject<IGeoObjectTapEvent>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}
}
