using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Map;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.User_location;

[Register("com/yandex/mapkit/user_location/UserLocationView", DoNotGenerateAcw = true)]
internal class IUserLocationViewInvoker : Java.Lang.Object, IUserLocationView, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_user_location_UserLocationView = new XAPeerMembers("com/yandex/mapkit/user_location/UserLocationView", typeof(IUserLocationViewInvoker));

	private static Delegate? cb_getAccuracyCircle_GetAccuracyCircle_Lcom_yandex_mapkit_map_CircleMapObject_;

	private static Delegate? cb_getArrow_GetArrow_Lcom_yandex_mapkit_map_PlacemarkMapObject_;

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_getPin_GetPin_Lcom_yandex_mapkit_map_PlacemarkMapObject_;

	private static nint java_class_ref => _members_com_yandex_mapkit_user_location_UserLocationView.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_user_location_UserLocationView;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_user_location_UserLocationView.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_user_location_UserLocationView.ManagedPeerType;

	public unsafe ICircleMapObject AccuracyCircle => Java.Lang.Object.GetObject<ICircleMapObject>(_members_com_yandex_mapkit_user_location_UserLocationView.InstanceMethods.InvokeAbstractObjectMethod("getAccuracyCircle.()Lcom/yandex/mapkit/map/CircleMapObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IPlacemarkMapObject Arrow => Java.Lang.Object.GetObject<IPlacemarkMapObject>(_members_com_yandex_mapkit_user_location_UserLocationView.InstanceMethods.InvokeAbstractObjectMethod("getArrow.()Lcom/yandex/mapkit/map/PlacemarkMapObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe bool IsValid => _members_com_yandex_mapkit_user_location_UserLocationView.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public unsafe IPlacemarkMapObject Pin => Java.Lang.Object.GetObject<IPlacemarkMapObject>(_members_com_yandex_mapkit_user_location_UserLocationView.InstanceMethods.InvokeAbstractObjectMethod("getPin.()Lcom/yandex/mapkit/map/PlacemarkMapObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IUserLocationViewInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetAccuracyCircleHandler()
	{
		if ((object)cb_getAccuracyCircle_GetAccuracyCircle_Lcom_yandex_mapkit_map_CircleMapObject_ == null)
		{
			cb_getAccuracyCircle_GetAccuracyCircle_Lcom_yandex_mapkit_map_CircleMapObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAccuracyCircle));
		}
		return cb_getAccuracyCircle_GetAccuracyCircle_Lcom_yandex_mapkit_map_CircleMapObject_;
	}

	private static nint n_GetAccuracyCircle(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUserLocationView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AccuracyCircle);
	}

	private static Delegate GetGetArrowHandler()
	{
		if ((object)cb_getArrow_GetArrow_Lcom_yandex_mapkit_map_PlacemarkMapObject_ == null)
		{
			cb_getArrow_GetArrow_Lcom_yandex_mapkit_map_PlacemarkMapObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetArrow));
		}
		return cb_getArrow_GetArrow_Lcom_yandex_mapkit_map_PlacemarkMapObject_;
	}

	private static nint n_GetArrow(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUserLocationView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Arrow);
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
		return Java.Lang.Object.GetObject<IUserLocationView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetGetPinHandler()
	{
		if ((object)cb_getPin_GetPin_Lcom_yandex_mapkit_map_PlacemarkMapObject_ == null)
		{
			cb_getPin_GetPin_Lcom_yandex_mapkit_map_PlacemarkMapObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPin));
		}
		return cb_getPin_GetPin_Lcom_yandex_mapkit_map_PlacemarkMapObject_;
	}

	private static nint n_GetPin(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUserLocationView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Pin);
	}
}
