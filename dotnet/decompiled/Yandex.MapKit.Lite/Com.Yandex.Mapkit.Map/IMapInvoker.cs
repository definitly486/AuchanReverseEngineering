using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Mapkit.Geometry.Geo;
using Com.Yandex.Mapkit.Indoor;
using Com.Yandex.Mapkit.Layers;
using Com.Yandex.Mapkit.Logo;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/Map", DoNotGenerateAcw = true)]
internal class IMapInvoker : Java.Lang.Object, IMap, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_Map = new XAPeerMembers("com/yandex/mapkit/map/Map", typeof(IMapInvoker));

	private static Delegate? cb_isAwesomeModelsEnabled_IsAwesomeModelsEnabled_Z;

	private static Delegate? cb_setAwesomeModelsEnabled_SetAwesomeModelsEnabled_Z_V;

	private static Delegate? cb_getCameraBounds_GetCameraBounds_Lcom_yandex_mapkit_map_CameraBounds_;

	private static Delegate? cb_getCameraPosition_GetCameraPosition_Lcom_yandex_mapkit_map_CameraPosition_;

	private static Delegate? cb_isFastTapEnabled_IsFastTapEnabled_Z;

	private static Delegate? cb_setFastTapEnabled_SetFastTapEnabled_Z_V;

	private static Delegate? cb_isHdModeEnabled_IsHdModeEnabled_Z;

	private static Delegate? cb_setHdModeEnabled_SetHdModeEnabled_Z_V;

	private static Delegate? cb_isIndoorEnabled_IsIndoorEnabled_Z;

	private static Delegate? cb_setIndoorEnabled_SetIndoorEnabled_Z_V;

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_getLogo_GetLogo_Lcom_yandex_mapkit_logo_Logo_;

	private static Delegate? cb_getMapObjects_GetMapObjects_Lcom_yandex_mapkit_map_RootMapObjectCollection_;

	private static Delegate? cb_getMapType_GetMapType_Lcom_yandex_mapkit_map_MapType_;

	private static Delegate? cb_setMapType_SetMapType_Lcom_yandex_mapkit_map_MapType__V;

	private static Delegate? cb_getMode_GetMode_Lcom_yandex_mapkit_map_MapMode_;

	private static Delegate? cb_setMode_SetMode_Lcom_yandex_mapkit_map_MapMode__V;

	private static Delegate? cb_isNightModeEnabled_IsNightModeEnabled_Z;

	private static Delegate? cb_setNightModeEnabled_SetNightModeEnabled_Z_V;

	private static Delegate? cb_getPoiLimit_GetPoiLimit_Ljava_lang_Integer_;

	private static Delegate? cb_setPoiLimit_SetPoiLimit_Ljava_lang_Integer__V;

	private static Delegate? cb_isRotateGesturesEnabled_IsRotateGesturesEnabled_Z;

	private static Delegate? cb_setRotateGesturesEnabled_SetRotateGesturesEnabled_Z_V;

	private static Delegate? cb_isScrollGesturesEnabled_IsScrollGesturesEnabled_Z;

	private static Delegate? cb_setScrollGesturesEnabled_SetScrollGesturesEnabled_Z_V;

	private static Delegate? cb_isTiltGesturesEnabled_IsTiltGesturesEnabled_Z;

	private static Delegate? cb_setTiltGesturesEnabled_SetTiltGesturesEnabled_Z_V;

	private static Delegate? cb_getVisibleRegion_GetVisibleRegion_Lcom_yandex_mapkit_map_VisibleRegion_;

	private static Delegate? cb_isZoomGesturesEnabled_IsZoomGesturesEnabled_Z;

	private static Delegate? cb_setZoomGesturesEnabled_SetZoomGesturesEnabled_Z_V;

	private static Delegate? cb_addCameraListener_AddCameraListener_Lcom_yandex_mapkit_map_CameraListener__V;

	private static Delegate? cb_addIndoorStateListener_AddIndoorStateListener_Lcom_yandex_mapkit_indoor_IndoorStateListener__V;

	private static Delegate? cb_addInputListener_AddInputListener_Lcom_yandex_mapkit_map_InputListener__V;

	private static Delegate? cb_addMapObjectLayer_AddMapObjectLayer_Ljava_lang_String__Lcom_yandex_mapkit_map_RootMapObjectCollection_;

	private static Delegate? cb_addTapListener_AddTapListener_Lcom_yandex_mapkit_layers_GeoObjectTapListener__V;

	private static Delegate? cb_addTileLayer_AddTileLayer_Ljava_lang_String_Lcom_yandex_mapkit_layers_LayerOptions_Lcom_yandex_mapkit_map_CreateTileDataSource__Lcom_yandex_mapkit_layers_Layer_;

	private static Delegate? cb_cameraPosition_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry__Lcom_yandex_mapkit_map_CameraPosition_;

	private static Delegate? cb_cameraPosition_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_Lcom_yandex_mapkit_ScreenRect__Lcom_yandex_mapkit_map_CameraPosition_;

	private static Delegate? cb_cameraPosition_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_FFLcom_yandex_mapkit_ScreenRect__Lcom_yandex_mapkit_map_CameraPosition_;

	private static Delegate? cb_deselectGeoObject_DeselectGeoObject_V;

	private static Delegate? cb_move_Move_Lcom_yandex_mapkit_map_CameraPosition__V;

	private static Delegate? cb_move_Move_Lcom_yandex_mapkit_map_CameraPosition_Lcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Map_CameraCallback__V;

	private static Delegate? cb_projection_Projection_Lcom_yandex_mapkit_geometry_geo_Projection_;

	private static Delegate? cb_removeCameraListener_RemoveCameraListener_Lcom_yandex_mapkit_map_CameraListener__V;

	private static Delegate? cb_removeIndoorStateListener_RemoveIndoorStateListener_Lcom_yandex_mapkit_indoor_IndoorStateListener__V;

	private static Delegate? cb_removeInputListener_RemoveInputListener_Lcom_yandex_mapkit_map_InputListener__V;

	private static Delegate? cb_removeTapListener_RemoveTapListener_Lcom_yandex_mapkit_layers_GeoObjectTapListener__V;

	private static Delegate? cb_resetMapStyles_ResetMapStyles_V;

	private static Delegate? cb_selectGeoObject_SelectGeoObject_Lcom_yandex_mapkit_map_GeoObjectSelectionMetadata__V;

	private static Delegate? cb_set2DMode_Set2DMode_Z_V;

	private static Delegate? cb_setMapLoadedListener_SetMapLoadedListener_Lcom_yandex_mapkit_map_MapLoadedListener__V;

	private static Delegate? cb_setMapStyle_SetMapStyle_ILjava_lang_String__Z;

	private static Delegate? cb_setMapStyle_SetMapStyle_Ljava_lang_String__Z;

	private static Delegate? cb_startTileLoadMetricsCapture_StartTileLoadMetricsCapture_V;

	private static Delegate? cb_stopTileLoadMetricsCapture_StopTileLoadMetricsCapture_Ljava_lang_String_;

	private static Delegate? cb_visibleRegion_InvokeVisibleRegion_Lcom_yandex_mapkit_map_CameraPosition__Lcom_yandex_mapkit_map_VisibleRegion_;

	private static Delegate? cb_wipe_Wipe_V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_Map.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_Map;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_Map.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_Map.ManagedPeerType;

	public unsafe bool AwesomeModelsEnabled
	{
		get
		{
			return _members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractBooleanMethod("isAwesomeModelsEnabled.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("setAwesomeModelsEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe ICameraBounds CameraBounds => Java.Lang.Object.GetObject<ICameraBounds>(_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractObjectMethod("getCameraBounds.()Lcom/yandex/mapkit/map/CameraBounds;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe CameraPosition CameraPosition => Java.Lang.Object.GetObject<CameraPosition>(_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractObjectMethod("getCameraPosition.()Lcom/yandex/mapkit/map/CameraPosition;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe bool FastTapEnabled
	{
		get
		{
			return _members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractBooleanMethod("isFastTapEnabled.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("setFastTapEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe bool HdModeEnabled
	{
		get
		{
			return _members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractBooleanMethod("isHdModeEnabled.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("setHdModeEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe bool IndoorEnabled
	{
		get
		{
			return _members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractBooleanMethod("isIndoorEnabled.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("setIndoorEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe bool IsValid => _members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public unsafe ILogo Logo => Java.Lang.Object.GetObject<ILogo>(_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractObjectMethod("getLogo.()Lcom/yandex/mapkit/logo/Logo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IRootMapObjectCollection MapObjects => Java.Lang.Object.GetObject<IRootMapObjectCollection>(_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractObjectMethod("getMapObjects.()Lcom/yandex/mapkit/map/RootMapObjectCollection;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe MapType MapType
	{
		get
		{
			return Java.Lang.Object.GetObject<MapType>(_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractObjectMethod("getMapType.()Lcom/yandex/mapkit/map/MapType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("setMapType.(Lcom/yandex/mapkit/map/MapType;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe MapMode Mode
	{
		get
		{
			return Java.Lang.Object.GetObject<MapMode>(_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractObjectMethod("getMode.()Lcom/yandex/mapkit/map/MapMode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("setMode.(Lcom/yandex/mapkit/map/MapMode;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe bool NightModeEnabled
	{
		get
		{
			return _members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractBooleanMethod("isNightModeEnabled.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("setNightModeEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe Integer? PoiLimit
	{
		get
		{
			return Java.Lang.Object.GetObject<Integer>(_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractObjectMethod("getPoiLimit.()Ljava/lang/Integer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("setPoiLimit.(Ljava/lang/Integer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe bool RotateGesturesEnabled
	{
		get
		{
			return _members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractBooleanMethod("isRotateGesturesEnabled.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("setRotateGesturesEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe bool ScrollGesturesEnabled
	{
		get
		{
			return _members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractBooleanMethod("isScrollGesturesEnabled.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("setScrollGesturesEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe bool TiltGesturesEnabled
	{
		get
		{
			return _members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractBooleanMethod("isTiltGesturesEnabled.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("setTiltGesturesEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe VisibleRegion VisibleRegion => Java.Lang.Object.GetObject<VisibleRegion>(_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractObjectMethod("getVisibleRegion.()Lcom/yandex/mapkit/map/VisibleRegion;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe bool ZoomGesturesEnabled
	{
		get
		{
			return _members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractBooleanMethod("isZoomGesturesEnabled.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("setZoomGesturesEnabled.(Z)V", this, ptr);
		}
	}

	public IMapInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetIsAwesomeModelsEnabledHandler()
	{
		if ((object)cb_isAwesomeModelsEnabled_IsAwesomeModelsEnabled_Z == null)
		{
			cb_isAwesomeModelsEnabled_IsAwesomeModelsEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsAwesomeModelsEnabled));
		}
		return cb_isAwesomeModelsEnabled_IsAwesomeModelsEnabled_Z;
	}

	private static bool n_IsAwesomeModelsEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AwesomeModelsEnabled;
	}

	private static Delegate GetSetAwesomeModelsEnabled_ZHandler()
	{
		if ((object)cb_setAwesomeModelsEnabled_SetAwesomeModelsEnabled_Z_V == null)
		{
			cb_setAwesomeModelsEnabled_SetAwesomeModelsEnabled_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetAwesomeModelsEnabled_Z));
		}
		return cb_setAwesomeModelsEnabled_SetAwesomeModelsEnabled_Z_V;
	}

	private static void n_SetAwesomeModelsEnabled_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AwesomeModelsEnabled = p0;
	}

	private static Delegate GetGetCameraBoundsHandler()
	{
		if ((object)cb_getCameraBounds_GetCameraBounds_Lcom_yandex_mapkit_map_CameraBounds_ == null)
		{
			cb_getCameraBounds_GetCameraBounds_Lcom_yandex_mapkit_map_CameraBounds_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCameraBounds));
		}
		return cb_getCameraBounds_GetCameraBounds_Lcom_yandex_mapkit_map_CameraBounds_;
	}

	private static nint n_GetCameraBounds(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraBounds);
	}

	private static Delegate GetGetCameraPositionHandler()
	{
		if ((object)cb_getCameraPosition_GetCameraPosition_Lcom_yandex_mapkit_map_CameraPosition_ == null)
		{
			cb_getCameraPosition_GetCameraPosition_Lcom_yandex_mapkit_map_CameraPosition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCameraPosition));
		}
		return cb_getCameraPosition_GetCameraPosition_Lcom_yandex_mapkit_map_CameraPosition_;
	}

	private static nint n_GetCameraPosition(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CameraPosition);
	}

	private static Delegate GetIsFastTapEnabledHandler()
	{
		if ((object)cb_isFastTapEnabled_IsFastTapEnabled_Z == null)
		{
			cb_isFastTapEnabled_IsFastTapEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsFastTapEnabled));
		}
		return cb_isFastTapEnabled_IsFastTapEnabled_Z;
	}

	private static bool n_IsFastTapEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FastTapEnabled;
	}

	private static Delegate GetSetFastTapEnabled_ZHandler()
	{
		if ((object)cb_setFastTapEnabled_SetFastTapEnabled_Z_V == null)
		{
			cb_setFastTapEnabled_SetFastTapEnabled_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetFastTapEnabled_Z));
		}
		return cb_setFastTapEnabled_SetFastTapEnabled_Z_V;
	}

	private static void n_SetFastTapEnabled_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FastTapEnabled = p0;
	}

	private static Delegate GetIsHdModeEnabledHandler()
	{
		if ((object)cb_isHdModeEnabled_IsHdModeEnabled_Z == null)
		{
			cb_isHdModeEnabled_IsHdModeEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsHdModeEnabled));
		}
		return cb_isHdModeEnabled_IsHdModeEnabled_Z;
	}

	private static bool n_IsHdModeEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HdModeEnabled;
	}

	private static Delegate GetSetHdModeEnabled_ZHandler()
	{
		if ((object)cb_setHdModeEnabled_SetHdModeEnabled_Z_V == null)
		{
			cb_setHdModeEnabled_SetHdModeEnabled_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetHdModeEnabled_Z));
		}
		return cb_setHdModeEnabled_SetHdModeEnabled_Z_V;
	}

	private static void n_SetHdModeEnabled_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HdModeEnabled = p0;
	}

	private static Delegate GetIsIndoorEnabledHandler()
	{
		if ((object)cb_isIndoorEnabled_IsIndoorEnabled_Z == null)
		{
			cb_isIndoorEnabled_IsIndoorEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsIndoorEnabled));
		}
		return cb_isIndoorEnabled_IsIndoorEnabled_Z;
	}

	private static bool n_IsIndoorEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IndoorEnabled;
	}

	private static Delegate GetSetIndoorEnabled_ZHandler()
	{
		if ((object)cb_setIndoorEnabled_SetIndoorEnabled_Z_V == null)
		{
			cb_setIndoorEnabled_SetIndoorEnabled_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetIndoorEnabled_Z));
		}
		return cb_setIndoorEnabled_SetIndoorEnabled_Z_V;
	}

	private static void n_SetIndoorEnabled_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IndoorEnabled = p0;
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
		return Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetGetLogoHandler()
	{
		if ((object)cb_getLogo_GetLogo_Lcom_yandex_mapkit_logo_Logo_ == null)
		{
			cb_getLogo_GetLogo_Lcom_yandex_mapkit_logo_Logo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLogo));
		}
		return cb_getLogo_GetLogo_Lcom_yandex_mapkit_logo_Logo_;
	}

	private static nint n_GetLogo(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Logo);
	}

	private static Delegate GetGetMapObjectsHandler()
	{
		if ((object)cb_getMapObjects_GetMapObjects_Lcom_yandex_mapkit_map_RootMapObjectCollection_ == null)
		{
			cb_getMapObjects_GetMapObjects_Lcom_yandex_mapkit_map_RootMapObjectCollection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMapObjects));
		}
		return cb_getMapObjects_GetMapObjects_Lcom_yandex_mapkit_map_RootMapObjectCollection_;
	}

	private static nint n_GetMapObjects(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MapObjects);
	}

	private static Delegate GetGetMapTypeHandler()
	{
		if ((object)cb_getMapType_GetMapType_Lcom_yandex_mapkit_map_MapType_ == null)
		{
			cb_getMapType_GetMapType_Lcom_yandex_mapkit_map_MapType_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMapType));
		}
		return cb_getMapType_GetMapType_Lcom_yandex_mapkit_map_MapType_;
	}

	private static nint n_GetMapType(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MapType);
	}

	private static Delegate GetSetMapType_Lcom_yandex_mapkit_map_MapType_Handler()
	{
		if ((object)cb_setMapType_SetMapType_Lcom_yandex_mapkit_map_MapType__V == null)
		{
			cb_setMapType_SetMapType_Lcom_yandex_mapkit_map_MapType__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetMapType_Lcom_yandex_mapkit_map_MapType_));
		}
		return cb_setMapType_SetMapType_Lcom_yandex_mapkit_map_MapType__V;
	}

	private static void n_SetMapType_Lcom_yandex_mapkit_map_MapType_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		MapType mapType = Java.Lang.Object.GetObject<MapType>(native_p0, JniHandleOwnership.DoNotTransfer);
		map.MapType = mapType;
	}

	private static Delegate GetGetModeHandler()
	{
		if ((object)cb_getMode_GetMode_Lcom_yandex_mapkit_map_MapMode_ == null)
		{
			cb_getMode_GetMode_Lcom_yandex_mapkit_map_MapMode_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMode));
		}
		return cb_getMode_GetMode_Lcom_yandex_mapkit_map_MapMode_;
	}

	private static nint n_GetMode(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Mode);
	}

	private static Delegate GetSetMode_Lcom_yandex_mapkit_map_MapMode_Handler()
	{
		if ((object)cb_setMode_SetMode_Lcom_yandex_mapkit_map_MapMode__V == null)
		{
			cb_setMode_SetMode_Lcom_yandex_mapkit_map_MapMode__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetMode_Lcom_yandex_mapkit_map_MapMode_));
		}
		return cb_setMode_SetMode_Lcom_yandex_mapkit_map_MapMode__V;
	}

	private static void n_SetMode_Lcom_yandex_mapkit_map_MapMode_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		MapMode mode = Java.Lang.Object.GetObject<MapMode>(native_p0, JniHandleOwnership.DoNotTransfer);
		map.Mode = mode;
	}

	private static Delegate GetIsNightModeEnabledHandler()
	{
		if ((object)cb_isNightModeEnabled_IsNightModeEnabled_Z == null)
		{
			cb_isNightModeEnabled_IsNightModeEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsNightModeEnabled));
		}
		return cb_isNightModeEnabled_IsNightModeEnabled_Z;
	}

	private static bool n_IsNightModeEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NightModeEnabled;
	}

	private static Delegate GetSetNightModeEnabled_ZHandler()
	{
		if ((object)cb_setNightModeEnabled_SetNightModeEnabled_Z_V == null)
		{
			cb_setNightModeEnabled_SetNightModeEnabled_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetNightModeEnabled_Z));
		}
		return cb_setNightModeEnabled_SetNightModeEnabled_Z_V;
	}

	private static void n_SetNightModeEnabled_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NightModeEnabled = p0;
	}

	private static Delegate GetGetPoiLimitHandler()
	{
		if ((object)cb_getPoiLimit_GetPoiLimit_Ljava_lang_Integer_ == null)
		{
			cb_getPoiLimit_GetPoiLimit_Ljava_lang_Integer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPoiLimit));
		}
		return cb_getPoiLimit_GetPoiLimit_Ljava_lang_Integer_;
	}

	private static nint n_GetPoiLimit(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PoiLimit);
	}

	private static Delegate GetSetPoiLimit_Ljava_lang_Integer_Handler()
	{
		if ((object)cb_setPoiLimit_SetPoiLimit_Ljava_lang_Integer__V == null)
		{
			cb_setPoiLimit_SetPoiLimit_Ljava_lang_Integer__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetPoiLimit_Ljava_lang_Integer_));
		}
		return cb_setPoiLimit_SetPoiLimit_Ljava_lang_Integer__V;
	}

	private static void n_SetPoiLimit_Ljava_lang_Integer_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Integer poiLimit = Java.Lang.Object.GetObject<Integer>(native_p0, JniHandleOwnership.DoNotTransfer);
		map.PoiLimit = poiLimit;
	}

	private static Delegate GetIsRotateGesturesEnabledHandler()
	{
		if ((object)cb_isRotateGesturesEnabled_IsRotateGesturesEnabled_Z == null)
		{
			cb_isRotateGesturesEnabled_IsRotateGesturesEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsRotateGesturesEnabled));
		}
		return cb_isRotateGesturesEnabled_IsRotateGesturesEnabled_Z;
	}

	private static bool n_IsRotateGesturesEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RotateGesturesEnabled;
	}

	private static Delegate GetSetRotateGesturesEnabled_ZHandler()
	{
		if ((object)cb_setRotateGesturesEnabled_SetRotateGesturesEnabled_Z_V == null)
		{
			cb_setRotateGesturesEnabled_SetRotateGesturesEnabled_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetRotateGesturesEnabled_Z));
		}
		return cb_setRotateGesturesEnabled_SetRotateGesturesEnabled_Z_V;
	}

	private static void n_SetRotateGesturesEnabled_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RotateGesturesEnabled = p0;
	}

	private static Delegate GetIsScrollGesturesEnabledHandler()
	{
		if ((object)cb_isScrollGesturesEnabled_IsScrollGesturesEnabled_Z == null)
		{
			cb_isScrollGesturesEnabled_IsScrollGesturesEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsScrollGesturesEnabled));
		}
		return cb_isScrollGesturesEnabled_IsScrollGesturesEnabled_Z;
	}

	private static bool n_IsScrollGesturesEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScrollGesturesEnabled;
	}

	private static Delegate GetSetScrollGesturesEnabled_ZHandler()
	{
		if ((object)cb_setScrollGesturesEnabled_SetScrollGesturesEnabled_Z_V == null)
		{
			cb_setScrollGesturesEnabled_SetScrollGesturesEnabled_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetScrollGesturesEnabled_Z));
		}
		return cb_setScrollGesturesEnabled_SetScrollGesturesEnabled_Z_V;
	}

	private static void n_SetScrollGesturesEnabled_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScrollGesturesEnabled = p0;
	}

	private static Delegate GetIsTiltGesturesEnabledHandler()
	{
		if ((object)cb_isTiltGesturesEnabled_IsTiltGesturesEnabled_Z == null)
		{
			cb_isTiltGesturesEnabled_IsTiltGesturesEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsTiltGesturesEnabled));
		}
		return cb_isTiltGesturesEnabled_IsTiltGesturesEnabled_Z;
	}

	private static bool n_IsTiltGesturesEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TiltGesturesEnabled;
	}

	private static Delegate GetSetTiltGesturesEnabled_ZHandler()
	{
		if ((object)cb_setTiltGesturesEnabled_SetTiltGesturesEnabled_Z_V == null)
		{
			cb_setTiltGesturesEnabled_SetTiltGesturesEnabled_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetTiltGesturesEnabled_Z));
		}
		return cb_setTiltGesturesEnabled_SetTiltGesturesEnabled_Z_V;
	}

	private static void n_SetTiltGesturesEnabled_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TiltGesturesEnabled = p0;
	}

	private static Delegate GetGetVisibleRegionHandler()
	{
		if ((object)cb_getVisibleRegion_GetVisibleRegion_Lcom_yandex_mapkit_map_VisibleRegion_ == null)
		{
			cb_getVisibleRegion_GetVisibleRegion_Lcom_yandex_mapkit_map_VisibleRegion_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetVisibleRegion));
		}
		return cb_getVisibleRegion_GetVisibleRegion_Lcom_yandex_mapkit_map_VisibleRegion_;
	}

	private static nint n_GetVisibleRegion(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VisibleRegion);
	}

	private static Delegate GetIsZoomGesturesEnabledHandler()
	{
		if ((object)cb_isZoomGesturesEnabled_IsZoomGesturesEnabled_Z == null)
		{
			cb_isZoomGesturesEnabled_IsZoomGesturesEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsZoomGesturesEnabled));
		}
		return cb_isZoomGesturesEnabled_IsZoomGesturesEnabled_Z;
	}

	private static bool n_IsZoomGesturesEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZoomGesturesEnabled;
	}

	private static Delegate GetSetZoomGesturesEnabled_ZHandler()
	{
		if ((object)cb_setZoomGesturesEnabled_SetZoomGesturesEnabled_Z_V == null)
		{
			cb_setZoomGesturesEnabled_SetZoomGesturesEnabled_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetZoomGesturesEnabled_Z));
		}
		return cb_setZoomGesturesEnabled_SetZoomGesturesEnabled_Z_V;
	}

	private static void n_SetZoomGesturesEnabled_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZoomGesturesEnabled = p0;
	}

	private static Delegate GetAddCameraListener_Lcom_yandex_mapkit_map_CameraListener_Handler()
	{
		if ((object)cb_addCameraListener_AddCameraListener_Lcom_yandex_mapkit_map_CameraListener__V == null)
		{
			cb_addCameraListener_AddCameraListener_Lcom_yandex_mapkit_map_CameraListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddCameraListener_Lcom_yandex_mapkit_map_CameraListener_));
		}
		return cb_addCameraListener_AddCameraListener_Lcom_yandex_mapkit_map_CameraListener__V;
	}

	private static void n_AddCameraListener_Lcom_yandex_mapkit_map_CameraListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICameraListener p = Java.Lang.Object.GetObject<ICameraListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		map.AddCameraListener(p);
	}

	public unsafe void AddCameraListener(ICameraListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("addCameraListener.(Lcom/yandex/mapkit/map/CameraListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAddIndoorStateListener_Lcom_yandex_mapkit_indoor_IndoorStateListener_Handler()
	{
		if ((object)cb_addIndoorStateListener_AddIndoorStateListener_Lcom_yandex_mapkit_indoor_IndoorStateListener__V == null)
		{
			cb_addIndoorStateListener_AddIndoorStateListener_Lcom_yandex_mapkit_indoor_IndoorStateListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddIndoorStateListener_Lcom_yandex_mapkit_indoor_IndoorStateListener_));
		}
		return cb_addIndoorStateListener_AddIndoorStateListener_Lcom_yandex_mapkit_indoor_IndoorStateListener__V;
	}

	private static void n_AddIndoorStateListener_Lcom_yandex_mapkit_indoor_IndoorStateListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IIndoorStateListener p = Java.Lang.Object.GetObject<IIndoorStateListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		map.AddIndoorStateListener(p);
	}

	public unsafe void AddIndoorStateListener(IIndoorStateListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("addIndoorStateListener.(Lcom/yandex/mapkit/indoor/IndoorStateListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAddInputListener_Lcom_yandex_mapkit_map_InputListener_Handler()
	{
		if ((object)cb_addInputListener_AddInputListener_Lcom_yandex_mapkit_map_InputListener__V == null)
		{
			cb_addInputListener_AddInputListener_Lcom_yandex_mapkit_map_InputListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddInputListener_Lcom_yandex_mapkit_map_InputListener_));
		}
		return cb_addInputListener_AddInputListener_Lcom_yandex_mapkit_map_InputListener__V;
	}

	private static void n_AddInputListener_Lcom_yandex_mapkit_map_InputListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IInputListener p = Java.Lang.Object.GetObject<IInputListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		map.AddInputListener(p);
	}

	public unsafe void AddInputListener(IInputListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("addInputListener.(Lcom/yandex/mapkit/map/InputListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAddMapObjectLayer_Ljava_lang_String_Handler()
	{
		if ((object)cb_addMapObjectLayer_AddMapObjectLayer_Ljava_lang_String__Lcom_yandex_mapkit_map_RootMapObjectCollection_ == null)
		{
			cb_addMapObjectLayer_AddMapObjectLayer_Ljava_lang_String__Lcom_yandex_mapkit_map_RootMapObjectCollection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddMapObjectLayer_Ljava_lang_String_));
		}
		return cb_addMapObjectLayer_AddMapObjectLayer_Ljava_lang_String__Lcom_yandex_mapkit_map_RootMapObjectCollection_;
	}

	private static nint n_AddMapObjectLayer_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(map.AddMapObjectLayer(p));
	}

	public unsafe IRootMapObjectCollection AddMapObjectLayer(string p0)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IRootMapObjectCollection>(_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractObjectMethod("addMapObjectLayer.(Ljava/lang/String;)Lcom/yandex/mapkit/map/RootMapObjectCollection;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetAddTapListener_Lcom_yandex_mapkit_layers_GeoObjectTapListener_Handler()
	{
		if ((object)cb_addTapListener_AddTapListener_Lcom_yandex_mapkit_layers_GeoObjectTapListener__V == null)
		{
			cb_addTapListener_AddTapListener_Lcom_yandex_mapkit_layers_GeoObjectTapListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddTapListener_Lcom_yandex_mapkit_layers_GeoObjectTapListener_));
		}
		return cb_addTapListener_AddTapListener_Lcom_yandex_mapkit_layers_GeoObjectTapListener__V;
	}

	private static void n_AddTapListener_Lcom_yandex_mapkit_layers_GeoObjectTapListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IGeoObjectTapListener p = Java.Lang.Object.GetObject<IGeoObjectTapListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		map.AddTapListener(p);
	}

	public unsafe void AddTapListener(IGeoObjectTapListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("addTapListener.(Lcom/yandex/mapkit/layers/GeoObjectTapListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAddTileLayer_Ljava_lang_String_Lcom_yandex_mapkit_layers_LayerOptions_Lcom_yandex_mapkit_map_CreateTileDataSource_Handler()
	{
		if ((object)cb_addTileLayer_AddTileLayer_Ljava_lang_String_Lcom_yandex_mapkit_layers_LayerOptions_Lcom_yandex_mapkit_map_CreateTileDataSource__Lcom_yandex_mapkit_layers_Layer_ == null)
		{
			cb_addTileLayer_AddTileLayer_Ljava_lang_String_Lcom_yandex_mapkit_layers_LayerOptions_Lcom_yandex_mapkit_map_CreateTileDataSource__Lcom_yandex_mapkit_layers_Layer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_AddTileLayer_Ljava_lang_String_Lcom_yandex_mapkit_layers_LayerOptions_Lcom_yandex_mapkit_map_CreateTileDataSource_));
		}
		return cb_addTileLayer_AddTileLayer_Ljava_lang_String_Lcom_yandex_mapkit_layers_LayerOptions_Lcom_yandex_mapkit_map_CreateTileDataSource__Lcom_yandex_mapkit_layers_Layer_;
	}

	private static nint n_AddTileLayer_Ljava_lang_String_Lcom_yandex_mapkit_layers_LayerOptions_Lcom_yandex_mapkit_map_CreateTileDataSource_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		LayerOptions p2 = Java.Lang.Object.GetObject<LayerOptions>(native_p1, JniHandleOwnership.DoNotTransfer);
		ICreateTileDataSource p3 = Java.Lang.Object.GetObject<ICreateTileDataSource>(native_p2, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(map.AddTileLayer(p, p2, p3));
	}

	public unsafe ILayer AddTileLayer(string p0, LayerOptions p1, ICreateTileDataSource p2)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			return Java.Lang.Object.GetObject<ILayer>(_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractObjectMethod("addTileLayer.(Ljava/lang/String;Lcom/yandex/mapkit/layers/LayerOptions;Lcom/yandex/mapkit/map/CreateTileDataSource;)Lcom/yandex/mapkit/layers/Layer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}

	private static Delegate GetInvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_Handler()
	{
		if ((object)cb_cameraPosition_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry__Lcom_yandex_mapkit_map_CameraPosition_ == null)
		{
			cb_cameraPosition_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry__Lcom_yandex_mapkit_map_CameraPosition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_));
		}
		return cb_cameraPosition_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry__Lcom_yandex_mapkit_map_CameraPosition_;
	}

	private static nint n_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Com.Yandex.Mapkit.Geometry.Geometry p = Java.Lang.Object.GetObject<Com.Yandex.Mapkit.Geometry.Geometry>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(map.InvokeCameraPosition(p));
	}

	public unsafe CameraPosition InvokeCameraPosition(Com.Yandex.Mapkit.Geometry.Geometry p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<CameraPosition>(_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractObjectMethod("cameraPosition.(Lcom/yandex/mapkit/geometry/Geometry;)Lcom/yandex/mapkit/map/CameraPosition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetInvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_Lcom_yandex_mapkit_ScreenRect_Handler()
	{
		if ((object)cb_cameraPosition_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_Lcom_yandex_mapkit_ScreenRect__Lcom_yandex_mapkit_map_CameraPosition_ == null)
		{
			cb_cameraPosition_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_Lcom_yandex_mapkit_ScreenRect__Lcom_yandex_mapkit_map_CameraPosition_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_Lcom_yandex_mapkit_ScreenRect_));
		}
		return cb_cameraPosition_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_Lcom_yandex_mapkit_ScreenRect__Lcom_yandex_mapkit_map_CameraPosition_;
	}

	private static nint n_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_Lcom_yandex_mapkit_ScreenRect_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Com.Yandex.Mapkit.Geometry.Geometry p = Java.Lang.Object.GetObject<Com.Yandex.Mapkit.Geometry.Geometry>(native_p0, JniHandleOwnership.DoNotTransfer);
		ScreenRect p2 = Java.Lang.Object.GetObject<ScreenRect>(native_p1, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(map.InvokeCameraPosition(p, p2));
	}

	public unsafe CameraPosition InvokeCameraPosition(Com.Yandex.Mapkit.Geometry.Geometry p0, ScreenRect p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<CameraPosition>(_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractObjectMethod("cameraPosition.(Lcom/yandex/mapkit/geometry/Geometry;Lcom/yandex/mapkit/ScreenRect;)Lcom/yandex/mapkit/map/CameraPosition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetInvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_FFLcom_yandex_mapkit_ScreenRect_Handler()
	{
		if ((object)cb_cameraPosition_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_FFLcom_yandex_mapkit_ScreenRect__Lcom_yandex_mapkit_map_CameraPosition_ == null)
		{
			cb_cameraPosition_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_FFLcom_yandex_mapkit_ScreenRect__Lcom_yandex_mapkit_map_CameraPosition_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLFFL_L(n_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_FFLcom_yandex_mapkit_ScreenRect_));
		}
		return cb_cameraPosition_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_FFLcom_yandex_mapkit_ScreenRect__Lcom_yandex_mapkit_map_CameraPosition_;
	}

	private static nint n_InvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_FFLcom_yandex_mapkit_ScreenRect_(nint jnienv, nint native__this, nint native_p0, float p1, float p2, nint native_p3)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Com.Yandex.Mapkit.Geometry.Geometry p3 = Java.Lang.Object.GetObject<Com.Yandex.Mapkit.Geometry.Geometry>(native_p0, JniHandleOwnership.DoNotTransfer);
		ScreenRect p4 = Java.Lang.Object.GetObject<ScreenRect>(native_p3, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(map.InvokeCameraPosition(p3, p1, p2, p4));
	}

	public unsafe CameraPosition InvokeCameraPosition(Com.Yandex.Mapkit.Geometry.Geometry p0, float p1, float p2, ScreenRect? p3)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			ptr[2] = new JniArgumentValue(p2);
			ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<CameraPosition>(_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractObjectMethod("cameraPosition.(Lcom/yandex/mapkit/geometry/Geometry;FFLcom/yandex/mapkit/ScreenRect;)Lcom/yandex/mapkit/map/CameraPosition;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p3);
		}
	}

	private static Delegate GetDeselectGeoObjectHandler()
	{
		if ((object)cb_deselectGeoObject_DeselectGeoObject_V == null)
		{
			cb_deselectGeoObject_DeselectGeoObject_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_DeselectGeoObject));
		}
		return cb_deselectGeoObject_DeselectGeoObject_V;
	}

	private static void n_DeselectGeoObject(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeselectGeoObject();
	}

	public unsafe void DeselectGeoObject()
	{
		_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("deselectGeoObject.()V", this, null);
	}

	private static Delegate GetMove_Lcom_yandex_mapkit_map_CameraPosition_Handler()
	{
		if ((object)cb_move_Move_Lcom_yandex_mapkit_map_CameraPosition__V == null)
		{
			cb_move_Move_Lcom_yandex_mapkit_map_CameraPosition__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Move_Lcom_yandex_mapkit_map_CameraPosition_));
		}
		return cb_move_Move_Lcom_yandex_mapkit_map_CameraPosition__V;
	}

	private static void n_Move_Lcom_yandex_mapkit_map_CameraPosition_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		CameraPosition p = Java.Lang.Object.GetObject<CameraPosition>(native_p0, JniHandleOwnership.DoNotTransfer);
		map.Move(p);
	}

	public unsafe void Move(CameraPosition p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("move.(Lcom/yandex/mapkit/map/CameraPosition;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetMove_Lcom_yandex_mapkit_map_CameraPosition_Lcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Map_CameraCallback_Handler()
	{
		if ((object)cb_move_Move_Lcom_yandex_mapkit_map_CameraPosition_Lcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Map_CameraCallback__V == null)
		{
			cb_move_Move_Lcom_yandex_mapkit_map_CameraPosition_Lcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Map_CameraCallback__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_Move_Lcom_yandex_mapkit_map_CameraPosition_Lcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Map_CameraCallback_));
		}
		return cb_move_Move_Lcom_yandex_mapkit_map_CameraPosition_Lcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Map_CameraCallback__V;
	}

	private static void n_Move_Lcom_yandex_mapkit_map_CameraPosition_Lcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Map_CameraCallback_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		CameraPosition p = Java.Lang.Object.GetObject<CameraPosition>(native_p0, JniHandleOwnership.DoNotTransfer);
		Animation p2 = Java.Lang.Object.GetObject<Animation>(native_p1, JniHandleOwnership.DoNotTransfer);
		IMap.ICameraCallback p3 = Java.Lang.Object.GetObject<IMap.ICameraCallback>(native_p2, JniHandleOwnership.DoNotTransfer);
		map.Move(p, p2, p3);
	}

	public unsafe void Move(CameraPosition p0, Animation p1, IMap.ICameraCallback? p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("move.(Lcom/yandex/mapkit/map/CameraPosition;Lcom/yandex/mapkit/Animation;Lcom/yandex/mapkit/map/Map$CameraCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}

	private static Delegate GetProjectionHandler()
	{
		if ((object)cb_projection_Projection_Lcom_yandex_mapkit_geometry_geo_Projection_ == null)
		{
			cb_projection_Projection_Lcom_yandex_mapkit_geometry_geo_Projection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Projection));
		}
		return cb_projection_Projection_Lcom_yandex_mapkit_geometry_geo_Projection_;
	}

	private static nint n_Projection(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Projection());
	}

	public unsafe IProjection Projection()
	{
		return Java.Lang.Object.GetObject<IProjection>(_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractObjectMethod("projection.()Lcom/yandex/mapkit/geometry/geo/Projection;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetRemoveCameraListener_Lcom_yandex_mapkit_map_CameraListener_Handler()
	{
		if ((object)cb_removeCameraListener_RemoveCameraListener_Lcom_yandex_mapkit_map_CameraListener__V == null)
		{
			cb_removeCameraListener_RemoveCameraListener_Lcom_yandex_mapkit_map_CameraListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveCameraListener_Lcom_yandex_mapkit_map_CameraListener_));
		}
		return cb_removeCameraListener_RemoveCameraListener_Lcom_yandex_mapkit_map_CameraListener__V;
	}

	private static void n_RemoveCameraListener_Lcom_yandex_mapkit_map_CameraListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ICameraListener p = Java.Lang.Object.GetObject<ICameraListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		map.RemoveCameraListener(p);
	}

	public unsafe void RemoveCameraListener(ICameraListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("removeCameraListener.(Lcom/yandex/mapkit/map/CameraListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetRemoveIndoorStateListener_Lcom_yandex_mapkit_indoor_IndoorStateListener_Handler()
	{
		if ((object)cb_removeIndoorStateListener_RemoveIndoorStateListener_Lcom_yandex_mapkit_indoor_IndoorStateListener__V == null)
		{
			cb_removeIndoorStateListener_RemoveIndoorStateListener_Lcom_yandex_mapkit_indoor_IndoorStateListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveIndoorStateListener_Lcom_yandex_mapkit_indoor_IndoorStateListener_));
		}
		return cb_removeIndoorStateListener_RemoveIndoorStateListener_Lcom_yandex_mapkit_indoor_IndoorStateListener__V;
	}

	private static void n_RemoveIndoorStateListener_Lcom_yandex_mapkit_indoor_IndoorStateListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IIndoorStateListener p = Java.Lang.Object.GetObject<IIndoorStateListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		map.RemoveIndoorStateListener(p);
	}

	public unsafe void RemoveIndoorStateListener(IIndoorStateListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("removeIndoorStateListener.(Lcom/yandex/mapkit/indoor/IndoorStateListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetRemoveInputListener_Lcom_yandex_mapkit_map_InputListener_Handler()
	{
		if ((object)cb_removeInputListener_RemoveInputListener_Lcom_yandex_mapkit_map_InputListener__V == null)
		{
			cb_removeInputListener_RemoveInputListener_Lcom_yandex_mapkit_map_InputListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveInputListener_Lcom_yandex_mapkit_map_InputListener_));
		}
		return cb_removeInputListener_RemoveInputListener_Lcom_yandex_mapkit_map_InputListener__V;
	}

	private static void n_RemoveInputListener_Lcom_yandex_mapkit_map_InputListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IInputListener p = Java.Lang.Object.GetObject<IInputListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		map.RemoveInputListener(p);
	}

	public unsafe void RemoveInputListener(IInputListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("removeInputListener.(Lcom/yandex/mapkit/map/InputListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetRemoveTapListener_Lcom_yandex_mapkit_layers_GeoObjectTapListener_Handler()
	{
		if ((object)cb_removeTapListener_RemoveTapListener_Lcom_yandex_mapkit_layers_GeoObjectTapListener__V == null)
		{
			cb_removeTapListener_RemoveTapListener_Lcom_yandex_mapkit_layers_GeoObjectTapListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveTapListener_Lcom_yandex_mapkit_layers_GeoObjectTapListener_));
		}
		return cb_removeTapListener_RemoveTapListener_Lcom_yandex_mapkit_layers_GeoObjectTapListener__V;
	}

	private static void n_RemoveTapListener_Lcom_yandex_mapkit_layers_GeoObjectTapListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IGeoObjectTapListener p = Java.Lang.Object.GetObject<IGeoObjectTapListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		map.RemoveTapListener(p);
	}

	public unsafe void RemoveTapListener(IGeoObjectTapListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("removeTapListener.(Lcom/yandex/mapkit/layers/GeoObjectTapListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetResetMapStylesHandler()
	{
		if ((object)cb_resetMapStyles_ResetMapStyles_V == null)
		{
			cb_resetMapStyles_ResetMapStyles_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ResetMapStyles));
		}
		return cb_resetMapStyles_ResetMapStyles_V;
	}

	private static void n_ResetMapStyles(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetMapStyles();
	}

	public unsafe void ResetMapStyles()
	{
		_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("resetMapStyles.()V", this, null);
	}

	private static Delegate GetSelectGeoObject_Lcom_yandex_mapkit_map_GeoObjectSelectionMetadata_Handler()
	{
		if ((object)cb_selectGeoObject_SelectGeoObject_Lcom_yandex_mapkit_map_GeoObjectSelectionMetadata__V == null)
		{
			cb_selectGeoObject_SelectGeoObject_Lcom_yandex_mapkit_map_GeoObjectSelectionMetadata__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SelectGeoObject_Lcom_yandex_mapkit_map_GeoObjectSelectionMetadata_));
		}
		return cb_selectGeoObject_SelectGeoObject_Lcom_yandex_mapkit_map_GeoObjectSelectionMetadata__V;
	}

	private static void n_SelectGeoObject_Lcom_yandex_mapkit_map_GeoObjectSelectionMetadata_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GeoObjectSelectionMetadata p = Java.Lang.Object.GetObject<GeoObjectSelectionMetadata>(native_p0, JniHandleOwnership.DoNotTransfer);
		map.SelectGeoObject(p);
	}

	public unsafe void SelectGeoObject(GeoObjectSelectionMetadata p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("selectGeoObject.(Lcom/yandex/mapkit/map/GeoObjectSelectionMetadata;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSet2DMode_ZHandler()
	{
		if ((object)cb_set2DMode_Set2DMode_Z_V == null)
		{
			cb_set2DMode_Set2DMode_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_Set2DMode_Z));
		}
		return cb_set2DMode_Set2DMode_Z_V;
	}

	private static void n_Set2DMode_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Set2DMode(p0);
	}

	public unsafe void Set2DMode(bool p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("set2DMode.(Z)V", this, ptr);
	}

	private static Delegate GetSetMapLoadedListener_Lcom_yandex_mapkit_map_MapLoadedListener_Handler()
	{
		if ((object)cb_setMapLoadedListener_SetMapLoadedListener_Lcom_yandex_mapkit_map_MapLoadedListener__V == null)
		{
			cb_setMapLoadedListener_SetMapLoadedListener_Lcom_yandex_mapkit_map_MapLoadedListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetMapLoadedListener_Lcom_yandex_mapkit_map_MapLoadedListener_));
		}
		return cb_setMapLoadedListener_SetMapLoadedListener_Lcom_yandex_mapkit_map_MapLoadedListener__V;
	}

	private static void n_SetMapLoadedListener_Lcom_yandex_mapkit_map_MapLoadedListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapLoadedListener mapLoadedListener = Java.Lang.Object.GetObject<IMapLoadedListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		map.SetMapLoadedListener(mapLoadedListener);
	}

	public unsafe void SetMapLoadedListener(IMapLoadedListener? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("setMapLoadedListener.(Lcom/yandex/mapkit/map/MapLoadedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetMapStyle_ILjava_lang_String_Handler()
	{
		if ((object)cb_setMapStyle_SetMapStyle_ILjava_lang_String__Z == null)
		{
			cb_setMapStyle_SetMapStyle_ILjava_lang_String__Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_Z(n_SetMapStyle_ILjava_lang_String_));
		}
		return cb_setMapStyle_SetMapStyle_ILjava_lang_String__Z;
	}

	private static bool n_SetMapStyle_ILjava_lang_String_(nint jnienv, nint native__this, int p0, nint native_p1)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p1 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
		return map.SetMapStyle(p0, p1);
	}

	public unsafe bool SetMapStyle(int p0, string p1)
	{
		nint num = JNIEnv.NewString(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(num);
			return _members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractBooleanMethod("setMapStyle.(ILjava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetMapStyle_Ljava_lang_String_Handler()
	{
		if ((object)cb_setMapStyle_SetMapStyle_Ljava_lang_String__Z == null)
		{
			cb_setMapStyle_SetMapStyle_Ljava_lang_String__Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_SetMapStyle_Ljava_lang_String_));
		}
		return cb_setMapStyle_SetMapStyle_Ljava_lang_String__Z;
	}

	private static bool n_SetMapStyle_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string mapStyle = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		return map.SetMapStyle(mapStyle);
	}

	public unsafe bool SetMapStyle(string p0)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractBooleanMethod("setMapStyle.(Ljava/lang/String;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetStartTileLoadMetricsCaptureHandler()
	{
		if ((object)cb_startTileLoadMetricsCapture_StartTileLoadMetricsCapture_V == null)
		{
			cb_startTileLoadMetricsCapture_StartTileLoadMetricsCapture_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_StartTileLoadMetricsCapture));
		}
		return cb_startTileLoadMetricsCapture_StartTileLoadMetricsCapture_V;
	}

	private static void n_StartTileLoadMetricsCapture(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartTileLoadMetricsCapture();
	}

	public unsafe void StartTileLoadMetricsCapture()
	{
		_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("startTileLoadMetricsCapture.()V", this, null);
	}

	private static Delegate GetStopTileLoadMetricsCaptureHandler()
	{
		if ((object)cb_stopTileLoadMetricsCapture_StopTileLoadMetricsCapture_Ljava_lang_String_ == null)
		{
			cb_stopTileLoadMetricsCapture_StopTileLoadMetricsCapture_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_StopTileLoadMetricsCapture));
		}
		return cb_stopTileLoadMetricsCapture_StopTileLoadMetricsCapture_Ljava_lang_String_;
	}

	private static nint n_StopTileLoadMetricsCapture(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopTileLoadMetricsCapture());
	}

	public unsafe string StopTileLoadMetricsCapture()
	{
		return JNIEnv.GetString(_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractObjectMethod("stopTileLoadMetricsCapture.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetInvokeVisibleRegion_Lcom_yandex_mapkit_map_CameraPosition_Handler()
	{
		if ((object)cb_visibleRegion_InvokeVisibleRegion_Lcom_yandex_mapkit_map_CameraPosition__Lcom_yandex_mapkit_map_VisibleRegion_ == null)
		{
			cb_visibleRegion_InvokeVisibleRegion_Lcom_yandex_mapkit_map_CameraPosition__Lcom_yandex_mapkit_map_VisibleRegion_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_InvokeVisibleRegion_Lcom_yandex_mapkit_map_CameraPosition_));
		}
		return cb_visibleRegion_InvokeVisibleRegion_Lcom_yandex_mapkit_map_CameraPosition__Lcom_yandex_mapkit_map_VisibleRegion_;
	}

	private static nint n_InvokeVisibleRegion_Lcom_yandex_mapkit_map_CameraPosition_(nint jnienv, nint native__this, nint native_p0)
	{
		IMap? map = Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		CameraPosition p = Java.Lang.Object.GetObject<CameraPosition>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(map.InvokeVisibleRegion(p));
	}

	public unsafe VisibleRegion InvokeVisibleRegion(CameraPosition p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<VisibleRegion>(_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractObjectMethod("visibleRegion.(Lcom/yandex/mapkit/map/CameraPosition;)Lcom/yandex/mapkit/map/VisibleRegion;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetWipeHandler()
	{
		if ((object)cb_wipe_Wipe_V == null)
		{
			cb_wipe_Wipe_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Wipe));
		}
		return cb_wipe_Wipe_V;
	}

	private static void n_Wipe(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IMap>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Wipe();
	}

	public unsafe void Wipe()
	{
		_members_com_yandex_mapkit_map_Map.InstanceMethods.InvokeAbstractVoidMethod("wipe.()V", this, null);
	}
}
