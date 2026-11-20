using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Com.Yandex.Mapkit.Location;
using Com.Yandex.Mapkit.Map;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.User_location;

[Register("com/yandex/mapkit/user_location/UserLocationLayer", DoNotGenerateAcw = true)]
internal class IUserLocationLayerInvoker : Java.Lang.Object, IUserLocationLayer, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_user_location_UserLocationLayer = new XAPeerMembers("com/yandex/mapkit/user_location/UserLocationLayer", typeof(IUserLocationLayerInvoker));

	private static Delegate? cb_isAutoZoomEnabled_IsAutoZoomEnabled_Z;

	private static Delegate? cb_setAutoZoomEnabled_SetAutoZoomEnabled_Z_V;

	private static Delegate? cb_isHeadingModeActive_IsHeadingModeActive_Z;

	private static Delegate? cb_setHeadingModeActive_SetHeadingModeActive_Z_V;

	private static Delegate? cb_isAnchorEnabled_IsAnchorEnabled_Z;

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_isVisible_IsVisible_Z;

	private static Delegate? cb_setVisible_SetVisible_Z_V;

	private static Delegate? cb_cameraPosition_CameraPosition_Lcom_yandex_mapkit_map_CameraPosition_;

	private static Delegate? cb_resetAnchor_ResetAnchor_V;

	private static Delegate? cb_setAnchor_SetAnchor_Landroid_graphics_PointF_Landroid_graphics_PointF__V;

	private static Delegate? cb_setDefaultSource_SetDefaultSource_V;

	private static Delegate? cb_setObjectListener_SetObjectListener_Lcom_yandex_mapkit_user_location_UserLocationObjectListener__V;

	private static Delegate? cb_setSource_SetSource_Lcom_yandex_mapkit_location_LocationViewSource__V;

	private static Delegate? cb_setTapListener_SetTapListener_Lcom_yandex_mapkit_user_location_UserLocationTapListener__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_user_location_UserLocationLayer.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_user_location_UserLocationLayer;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_user_location_UserLocationLayer.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_user_location_UserLocationLayer.ManagedPeerType;

	public unsafe bool AutoZoomEnabled
	{
		get
		{
			return _members_com_yandex_mapkit_user_location_UserLocationLayer.InstanceMethods.InvokeAbstractBooleanMethod("isAutoZoomEnabled.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_user_location_UserLocationLayer.InstanceMethods.InvokeAbstractVoidMethod("setAutoZoomEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe bool HeadingModeActive
	{
		get
		{
			return _members_com_yandex_mapkit_user_location_UserLocationLayer.InstanceMethods.InvokeAbstractBooleanMethod("isHeadingModeActive.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_user_location_UserLocationLayer.InstanceMethods.InvokeAbstractVoidMethod("setHeadingModeActive.(Z)V", this, ptr);
		}
	}

	public unsafe bool IsAnchorEnabled => _members_com_yandex_mapkit_user_location_UserLocationLayer.InstanceMethods.InvokeAbstractBooleanMethod("isAnchorEnabled.()Z", this, null);

	public unsafe bool IsValid => _members_com_yandex_mapkit_user_location_UserLocationLayer.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public unsafe bool Visible
	{
		get
		{
			return _members_com_yandex_mapkit_user_location_UserLocationLayer.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_user_location_UserLocationLayer.InstanceMethods.InvokeAbstractVoidMethod("setVisible.(Z)V", this, ptr);
		}
	}

	public IUserLocationLayerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsAutoZoomEnabledHandler()
	{
		if ((object)cb_isAutoZoomEnabled_IsAutoZoomEnabled_Z == null)
		{
			cb_isAutoZoomEnabled_IsAutoZoomEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsAutoZoomEnabled));
		}
		return cb_isAutoZoomEnabled_IsAutoZoomEnabled_Z;
	}

	private static bool n_IsAutoZoomEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IUserLocationLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AutoZoomEnabled;
	}

	private static Delegate GetSetAutoZoomEnabled_ZHandler()
	{
		if ((object)cb_setAutoZoomEnabled_SetAutoZoomEnabled_Z_V == null)
		{
			cb_setAutoZoomEnabled_SetAutoZoomEnabled_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetAutoZoomEnabled_Z));
		}
		return cb_setAutoZoomEnabled_SetAutoZoomEnabled_Z_V;
	}

	private static void n_SetAutoZoomEnabled_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IUserLocationLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AutoZoomEnabled = p0;
	}

	private static Delegate GetIsHeadingModeActiveHandler()
	{
		if ((object)cb_isHeadingModeActive_IsHeadingModeActive_Z == null)
		{
			cb_isHeadingModeActive_IsHeadingModeActive_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsHeadingModeActive));
		}
		return cb_isHeadingModeActive_IsHeadingModeActive_Z;
	}

	private static bool n_IsHeadingModeActive(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IUserLocationLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HeadingModeActive;
	}

	private static Delegate GetSetHeadingModeActive_ZHandler()
	{
		if ((object)cb_setHeadingModeActive_SetHeadingModeActive_Z_V == null)
		{
			cb_setHeadingModeActive_SetHeadingModeActive_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetHeadingModeActive_Z));
		}
		return cb_setHeadingModeActive_SetHeadingModeActive_Z_V;
	}

	private static void n_SetHeadingModeActive_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IUserLocationLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HeadingModeActive = p0;
	}

	private static Delegate GetIsAnchorEnabledHandler()
	{
		if ((object)cb_isAnchorEnabled_IsAnchorEnabled_Z == null)
		{
			cb_isAnchorEnabled_IsAnchorEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsAnchorEnabled));
		}
		return cb_isAnchorEnabled_IsAnchorEnabled_Z;
	}

	private static bool n_IsAnchorEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IUserLocationLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsAnchorEnabled;
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
		return Java.Lang.Object.GetObject<IUserLocationLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetIsVisibleHandler()
	{
		if ((object)cb_isVisible_IsVisible_Z == null)
		{
			cb_isVisible_IsVisible_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsVisible));
		}
		return cb_isVisible_IsVisible_Z;
	}

	private static bool n_IsVisible(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IUserLocationLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visible;
	}

	private static Delegate GetSetVisible_ZHandler()
	{
		if ((object)cb_setVisible_SetVisible_Z_V == null)
		{
			cb_setVisible_SetVisible_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetVisible_Z));
		}
		return cb_setVisible_SetVisible_Z_V;
	}

	private static void n_SetVisible_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IUserLocationLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visible = p0;
	}

	private static Delegate GetCameraPositionHandler()
	{
		if ((object)cb_cameraPosition_CameraPosition_Lcom_yandex_mapkit_map_CameraPosition_ == null)
		{
			cb_cameraPosition_CameraPosition_Lcom_yandex_mapkit_map_CameraPosition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CameraPosition));
		}
		return cb_cameraPosition_CameraPosition_Lcom_yandex_mapkit_map_CameraPosition_;
	}

	private static nint n_CameraPosition(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IUserLocationLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraPosition());
	}

	public unsafe CameraPosition? CameraPosition()
	{
		return Java.Lang.Object.GetObject<CameraPosition>(_members_com_yandex_mapkit_user_location_UserLocationLayer.InstanceMethods.InvokeAbstractObjectMethod("cameraPosition.()Lcom/yandex/mapkit/map/CameraPosition;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetResetAnchorHandler()
	{
		if ((object)cb_resetAnchor_ResetAnchor_V == null)
		{
			cb_resetAnchor_ResetAnchor_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ResetAnchor));
		}
		return cb_resetAnchor_ResetAnchor_V;
	}

	private static void n_ResetAnchor(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IUserLocationLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetAnchor();
	}

	public unsafe void ResetAnchor()
	{
		_members_com_yandex_mapkit_user_location_UserLocationLayer.InstanceMethods.InvokeAbstractVoidMethod("resetAnchor.()V", this, null);
	}

	private static Delegate GetSetAnchor_Landroid_graphics_PointF_Landroid_graphics_PointF_Handler()
	{
		if ((object)cb_setAnchor_SetAnchor_Landroid_graphics_PointF_Landroid_graphics_PointF__V == null)
		{
			cb_setAnchor_SetAnchor_Landroid_graphics_PointF_Landroid_graphics_PointF__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetAnchor_Landroid_graphics_PointF_Landroid_graphics_PointF_));
		}
		return cb_setAnchor_SetAnchor_Landroid_graphics_PointF_Landroid_graphics_PointF__V;
	}

	private static void n_SetAnchor_Landroid_graphics_PointF_Landroid_graphics_PointF_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IUserLocationLayer? userLocationLayer = Java.Lang.Object.GetObject<IUserLocationLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		PointF p = Java.Lang.Object.GetObject<PointF>(native_p0, JniHandleOwnership.DoNotTransfer);
		PointF p2 = Java.Lang.Object.GetObject<PointF>(native_p1, JniHandleOwnership.DoNotTransfer);
		userLocationLayer.SetAnchor(p, p2);
	}

	public unsafe void SetAnchor(PointF p0, PointF p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_user_location_UserLocationLayer.InstanceMethods.InvokeAbstractVoidMethod("setAnchor.(Landroid/graphics/PointF;Landroid/graphics/PointF;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetSetDefaultSourceHandler()
	{
		if ((object)cb_setDefaultSource_SetDefaultSource_V == null)
		{
			cb_setDefaultSource_SetDefaultSource_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_SetDefaultSource));
		}
		return cb_setDefaultSource_SetDefaultSource_V;
	}

	private static void n_SetDefaultSource(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IUserLocationLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDefaultSource();
	}

	public unsafe void SetDefaultSource()
	{
		_members_com_yandex_mapkit_user_location_UserLocationLayer.InstanceMethods.InvokeAbstractVoidMethod("setDefaultSource.()V", this, null);
	}

	private static Delegate GetSetObjectListener_Lcom_yandex_mapkit_user_location_UserLocationObjectListener_Handler()
	{
		if ((object)cb_setObjectListener_SetObjectListener_Lcom_yandex_mapkit_user_location_UserLocationObjectListener__V == null)
		{
			cb_setObjectListener_SetObjectListener_Lcom_yandex_mapkit_user_location_UserLocationObjectListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetObjectListener_Lcom_yandex_mapkit_user_location_UserLocationObjectListener_));
		}
		return cb_setObjectListener_SetObjectListener_Lcom_yandex_mapkit_user_location_UserLocationObjectListener__V;
	}

	private static void n_SetObjectListener_Lcom_yandex_mapkit_user_location_UserLocationObjectListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IUserLocationLayer? userLocationLayer = Java.Lang.Object.GetObject<IUserLocationLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IUserLocationObjectListener objectListener = Java.Lang.Object.GetObject<IUserLocationObjectListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		userLocationLayer.SetObjectListener(objectListener);
	}

	public unsafe void SetObjectListener(IUserLocationObjectListener? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_user_location_UserLocationLayer.InstanceMethods.InvokeAbstractVoidMethod("setObjectListener.(Lcom/yandex/mapkit/user_location/UserLocationObjectListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetSource_Lcom_yandex_mapkit_location_LocationViewSource_Handler()
	{
		if ((object)cb_setSource_SetSource_Lcom_yandex_mapkit_location_LocationViewSource__V == null)
		{
			cb_setSource_SetSource_Lcom_yandex_mapkit_location_LocationViewSource__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetSource_Lcom_yandex_mapkit_location_LocationViewSource_));
		}
		return cb_setSource_SetSource_Lcom_yandex_mapkit_location_LocationViewSource__V;
	}

	private static void n_SetSource_Lcom_yandex_mapkit_location_LocationViewSource_(nint jnienv, nint native__this, nint native_p0)
	{
		IUserLocationLayer? userLocationLayer = Java.Lang.Object.GetObject<IUserLocationLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ILocationViewSource source = Java.Lang.Object.GetObject<ILocationViewSource>(native_p0, JniHandleOwnership.DoNotTransfer);
		userLocationLayer.SetSource(source);
	}

	public unsafe void SetSource(ILocationViewSource? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_user_location_UserLocationLayer.InstanceMethods.InvokeAbstractVoidMethod("setSource.(Lcom/yandex/mapkit/location/LocationViewSource;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetTapListener_Lcom_yandex_mapkit_user_location_UserLocationTapListener_Handler()
	{
		if ((object)cb_setTapListener_SetTapListener_Lcom_yandex_mapkit_user_location_UserLocationTapListener__V == null)
		{
			cb_setTapListener_SetTapListener_Lcom_yandex_mapkit_user_location_UserLocationTapListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetTapListener_Lcom_yandex_mapkit_user_location_UserLocationTapListener_));
		}
		return cb_setTapListener_SetTapListener_Lcom_yandex_mapkit_user_location_UserLocationTapListener__V;
	}

	private static void n_SetTapListener_Lcom_yandex_mapkit_user_location_UserLocationTapListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IUserLocationLayer? userLocationLayer = Java.Lang.Object.GetObject<IUserLocationLayer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IUserLocationTapListener tapListener = Java.Lang.Object.GetObject<IUserLocationTapListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		userLocationLayer.SetTapListener(tapListener);
	}

	public unsafe void SetTapListener(IUserLocationTapListener? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_user_location_UserLocationLayer.InstanceMethods.InvokeAbstractVoidMethod("setTapListener.(Lcom/yandex/mapkit/user_location/UserLocationTapListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
