using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/CameraBounds", DoNotGenerateAcw = true)]
internal class ICameraBoundsInvoker : Java.Lang.Object, ICameraBounds, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_CameraBounds = new XAPeerMembers("com/yandex/mapkit/map/CameraBounds", typeof(ICameraBoundsInvoker));

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_getLatLngBounds_GetLatLngBounds_Lcom_yandex_mapkit_geometry_BoundingBox_;

	private static Delegate? cb_setLatLngBounds_SetLatLngBounds_Lcom_yandex_mapkit_geometry_BoundingBox__V;

	private static Delegate? cb_getMaxZoom_GetMaxZoom_F;

	private static Delegate? cb_getMinZoom_GetMinZoom_F;

	private static Delegate? cb_resetMinMaxZoomPreference_ResetMinMaxZoomPreference_V;

	private static Delegate? cb_setMaxZoomPreference_SetMaxZoomPreference_F_V;

	private static Delegate? cb_setMinZoomPreference_SetMinZoomPreference_F_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_CameraBounds.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_CameraBounds;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_CameraBounds.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_CameraBounds.ManagedPeerType;

	public unsafe bool IsValid => _members_com_yandex_mapkit_map_CameraBounds.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public unsafe BoundingBox? LatLngBounds
	{
		get
		{
			return Java.Lang.Object.GetObject<BoundingBox>(_members_com_yandex_mapkit_map_CameraBounds.InstanceMethods.InvokeAbstractObjectMethod("getLatLngBounds.()Lcom/yandex/mapkit/geometry/BoundingBox;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_map_CameraBounds.InstanceMethods.InvokeAbstractVoidMethod("setLatLngBounds.(Lcom/yandex/mapkit/geometry/BoundingBox;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe float MaxZoom => _members_com_yandex_mapkit_map_CameraBounds.InstanceMethods.InvokeAbstractSingleMethod("getMaxZoom.()F", this, null);

	public unsafe float MinZoom => _members_com_yandex_mapkit_map_CameraBounds.InstanceMethods.InvokeAbstractSingleMethod("getMinZoom.()F", this, null);

	public ICameraBoundsInvoker(nint handle, JniHandleOwnership transfer)
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
		return Java.Lang.Object.GetObject<ICameraBounds>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetGetLatLngBoundsHandler()
	{
		if ((object)cb_getLatLngBounds_GetLatLngBounds_Lcom_yandex_mapkit_geometry_BoundingBox_ == null)
		{
			cb_getLatLngBounds_GetLatLngBounds_Lcom_yandex_mapkit_geometry_BoundingBox_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLatLngBounds));
		}
		return cb_getLatLngBounds_GetLatLngBounds_Lcom_yandex_mapkit_geometry_BoundingBox_;
	}

	private static nint n_GetLatLngBounds(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICameraBounds>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LatLngBounds);
	}

	private static Delegate GetSetLatLngBounds_Lcom_yandex_mapkit_geometry_BoundingBox_Handler()
	{
		if ((object)cb_setLatLngBounds_SetLatLngBounds_Lcom_yandex_mapkit_geometry_BoundingBox__V == null)
		{
			cb_setLatLngBounds_SetLatLngBounds_Lcom_yandex_mapkit_geometry_BoundingBox__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetLatLngBounds_Lcom_yandex_mapkit_geometry_BoundingBox_));
		}
		return cb_setLatLngBounds_SetLatLngBounds_Lcom_yandex_mapkit_geometry_BoundingBox__V;
	}

	private static void n_SetLatLngBounds_Lcom_yandex_mapkit_geometry_BoundingBox_(nint jnienv, nint native__this, nint native_p0)
	{
		ICameraBounds? cameraBounds = Java.Lang.Object.GetObject<ICameraBounds>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		BoundingBox latLngBounds = Java.Lang.Object.GetObject<BoundingBox>(native_p0, JniHandleOwnership.DoNotTransfer);
		cameraBounds.LatLngBounds = latLngBounds;
	}

	private static Delegate GetGetMaxZoomHandler()
	{
		if ((object)cb_getMaxZoom_GetMaxZoom_F == null)
		{
			cb_getMaxZoom_GetMaxZoom_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetMaxZoom));
		}
		return cb_getMaxZoom_GetMaxZoom_F;
	}

	private static float n_GetMaxZoom(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraBounds>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxZoom;
	}

	private static Delegate GetGetMinZoomHandler()
	{
		if ((object)cb_getMinZoom_GetMinZoom_F == null)
		{
			cb_getMinZoom_GetMinZoom_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetMinZoom));
		}
		return cb_getMinZoom_GetMinZoom_F;
	}

	private static float n_GetMinZoom(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<ICameraBounds>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinZoom;
	}

	private static Delegate GetResetMinMaxZoomPreferenceHandler()
	{
		if ((object)cb_resetMinMaxZoomPreference_ResetMinMaxZoomPreference_V == null)
		{
			cb_resetMinMaxZoomPreference_ResetMinMaxZoomPreference_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ResetMinMaxZoomPreference));
		}
		return cb_resetMinMaxZoomPreference_ResetMinMaxZoomPreference_V;
	}

	private static void n_ResetMinMaxZoomPreference(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<ICameraBounds>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetMinMaxZoomPreference();
	}

	public unsafe void ResetMinMaxZoomPreference()
	{
		_members_com_yandex_mapkit_map_CameraBounds.InstanceMethods.InvokeAbstractVoidMethod("resetMinMaxZoomPreference.()V", this, null);
	}

	private static Delegate GetSetMaxZoomPreference_FHandler()
	{
		if ((object)cb_setMaxZoomPreference_SetMaxZoomPreference_F_V == null)
		{
			cb_setMaxZoomPreference_SetMaxZoomPreference_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetMaxZoomPreference_F));
		}
		return cb_setMaxZoomPreference_SetMaxZoomPreference_F_V;
	}

	private static void n_SetMaxZoomPreference_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<ICameraBounds>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMaxZoomPreference(p0);
	}

	public unsafe void SetMaxZoomPreference(float p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_com_yandex_mapkit_map_CameraBounds.InstanceMethods.InvokeAbstractVoidMethod("setMaxZoomPreference.(F)V", this, ptr);
	}

	private static Delegate GetSetMinZoomPreference_FHandler()
	{
		if ((object)cb_setMinZoomPreference_SetMinZoomPreference_F_V == null)
		{
			cb_setMinZoomPreference_SetMinZoomPreference_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetMinZoomPreference_F));
		}
		return cb_setMinZoomPreference_SetMinZoomPreference_F_V;
	}

	private static void n_SetMinZoomPreference_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<ICameraBounds>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMinZoomPreference(p0);
	}

	public unsafe void SetMinZoomPreference(float p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_com_yandex_mapkit_map_CameraBounds.InstanceMethods.InvokeAbstractVoidMethod("setMinZoomPreference.(F)V", this, ptr);
	}
}
