using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Mapkit.Location;
using Com.Yandex.Mapkit.Map;
using Com.Yandex.Mapkit.Offline_cache;
using Com.Yandex.Mapkit.Storage;
using Com.Yandex.Mapkit.Traffic;
using Com.Yandex.Mapkit.User_location;
using Com.Yandex.Runtime.View;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit;

[Register("com/yandex/mapkit/MapKit", DoNotGenerateAcw = true)]
internal class IMapKitInvoker : Java.Lang.Object, IMapKit, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_MapKit = new XAPeerMembers("com/yandex/mapkit/MapKit", typeof(IMapKitInvoker));

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_getOfflineCacheManager_GetOfflineCacheManager_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_;

	private static Delegate? cb_getStorageManager_GetStorageManager_Lcom_yandex_mapkit_storage_StorageManager_;

	private static Delegate? cb_getVersion_GetVersion_Ljava_lang_String_;

	private static Delegate? cb_createDummyLocationManager_CreateDummyLocationManager_Lcom_yandex_mapkit_location_DummyLocationManager_;

	private static Delegate? cb_createLocationManager_CreateLocationManager_Lcom_yandex_mapkit_location_LocationManager_;

	private static Delegate? cb_createLocationSimulator_CreateLocationSimulator_Lcom_yandex_mapkit_location_LocationSimulator_;

	private static Delegate? cb_createLocationSimulator_CreateLocationSimulator_Lcom_yandex_mapkit_geometry_Polyline__Lcom_yandex_mapkit_location_LocationSimulator_;

	private static Delegate? cb_createMapWindow_CreateMapWindow_Lcom_yandex_runtime_view_PlatformView__Lcom_yandex_mapkit_map_MapWindow_;

	private static Delegate? cb_createMapWindow_CreateMapWindow_Lcom_yandex_runtime_view_PlatformView_F_Lcom_yandex_mapkit_map_MapWindow_;

	private static Delegate? cb_createTrafficLayer_CreateTrafficLayer_Lcom_yandex_mapkit_map_MapWindow__Lcom_yandex_mapkit_traffic_TrafficLayer_;

	private static Delegate? cb_createUserLocationLayer_CreateUserLocationLayer_Lcom_yandex_mapkit_map_MapWindow__Lcom_yandex_mapkit_user_location_UserLocationLayer_;

	private static Delegate? cb_onStart_OnStart_V;

	private static Delegate? cb_onStop_OnStop_V;

	private static Delegate? cb_onTerminate_OnTerminate_V;

	private static Delegate? cb_resetLocationManagerToDefault_ResetLocationManagerToDefault_V;

	private static Delegate? cb_setApiKey_SetApiKey_Ljava_lang_String__V;

	private static Delegate? cb_setLocationManager_SetLocationManager_Lcom_yandex_mapkit_location_LocationManager__V;

	private static Delegate? cb_setUserId_SetUserId_Ljava_lang_String__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_MapKit.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_MapKit;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_MapKit.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_MapKit.ManagedPeerType;

	public unsafe bool IsValid => _members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public unsafe IOfflineCacheManager OfflineCacheManager => Java.Lang.Object.GetObject<IOfflineCacheManager>(_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractObjectMethod("getOfflineCacheManager.()Lcom/yandex/mapkit/offline_cache/OfflineCacheManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe IStorageManager StorageManager => Java.Lang.Object.GetObject<IStorageManager>(_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractObjectMethod("getStorageManager.()Lcom/yandex/mapkit/storage/StorageManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string Version => JNIEnv.GetString(_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractObjectMethod("getVersion.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IMapKitInvoker(nint handle, JniHandleOwnership transfer)
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
		return Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetGetOfflineCacheManagerHandler()
	{
		if ((object)cb_getOfflineCacheManager_GetOfflineCacheManager_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ == null)
		{
			cb_getOfflineCacheManager_GetOfflineCacheManager_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOfflineCacheManager));
		}
		return cb_getOfflineCacheManager_GetOfflineCacheManager_Lcom_yandex_mapkit_offline_cache_OfflineCacheManager_;
	}

	private static nint n_GetOfflineCacheManager(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OfflineCacheManager);
	}

	private static Delegate GetGetStorageManagerHandler()
	{
		if ((object)cb_getStorageManager_GetStorageManager_Lcom_yandex_mapkit_storage_StorageManager_ == null)
		{
			cb_getStorageManager_GetStorageManager_Lcom_yandex_mapkit_storage_StorageManager_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetStorageManager));
		}
		return cb_getStorageManager_GetStorageManager_Lcom_yandex_mapkit_storage_StorageManager_;
	}

	private static nint n_GetStorageManager(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StorageManager);
	}

	private static Delegate GetGetVersionHandler()
	{
		if ((object)cb_getVersion_GetVersion_Ljava_lang_String_ == null)
		{
			cb_getVersion_GetVersion_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetVersion));
		}
		return cb_getVersion_GetVersion_Ljava_lang_String_;
	}

	private static nint n_GetVersion(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Version);
	}

	private static Delegate GetCreateDummyLocationManagerHandler()
	{
		if ((object)cb_createDummyLocationManager_CreateDummyLocationManager_Lcom_yandex_mapkit_location_DummyLocationManager_ == null)
		{
			cb_createDummyLocationManager_CreateDummyLocationManager_Lcom_yandex_mapkit_location_DummyLocationManager_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateDummyLocationManager));
		}
		return cb_createDummyLocationManager_CreateDummyLocationManager_Lcom_yandex_mapkit_location_DummyLocationManager_;
	}

	private static nint n_CreateDummyLocationManager(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateDummyLocationManager());
	}

	public unsafe IDummyLocationManager CreateDummyLocationManager()
	{
		return Java.Lang.Object.GetObject<IDummyLocationManager>(_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractObjectMethod("createDummyLocationManager.()Lcom/yandex/mapkit/location/DummyLocationManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetCreateLocationManagerHandler()
	{
		if ((object)cb_createLocationManager_CreateLocationManager_Lcom_yandex_mapkit_location_LocationManager_ == null)
		{
			cb_createLocationManager_CreateLocationManager_Lcom_yandex_mapkit_location_LocationManager_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateLocationManager));
		}
		return cb_createLocationManager_CreateLocationManager_Lcom_yandex_mapkit_location_LocationManager_;
	}

	private static nint n_CreateLocationManager(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateLocationManager());
	}

	public unsafe ILocationManager CreateLocationManager()
	{
		return Java.Lang.Object.GetObject<ILocationManager>(_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractObjectMethod("createLocationManager.()Lcom/yandex/mapkit/location/LocationManager;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetCreateLocationSimulatorHandler()
	{
		if ((object)cb_createLocationSimulator_CreateLocationSimulator_Lcom_yandex_mapkit_location_LocationSimulator_ == null)
		{
			cb_createLocationSimulator_CreateLocationSimulator_Lcom_yandex_mapkit_location_LocationSimulator_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateLocationSimulator));
		}
		return cb_createLocationSimulator_CreateLocationSimulator_Lcom_yandex_mapkit_location_LocationSimulator_;
	}

	private static nint n_CreateLocationSimulator(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateLocationSimulator());
	}

	public unsafe ILocationSimulator CreateLocationSimulator()
	{
		return Java.Lang.Object.GetObject<ILocationSimulator>(_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractObjectMethod("createLocationSimulator.()Lcom/yandex/mapkit/location/LocationSimulator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetCreateLocationSimulator_Lcom_yandex_mapkit_geometry_Polyline_Handler()
	{
		if ((object)cb_createLocationSimulator_CreateLocationSimulator_Lcom_yandex_mapkit_geometry_Polyline__Lcom_yandex_mapkit_location_LocationSimulator_ == null)
		{
			cb_createLocationSimulator_CreateLocationSimulator_Lcom_yandex_mapkit_geometry_Polyline__Lcom_yandex_mapkit_location_LocationSimulator_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CreateLocationSimulator_Lcom_yandex_mapkit_geometry_Polyline_));
		}
		return cb_createLocationSimulator_CreateLocationSimulator_Lcom_yandex_mapkit_geometry_Polyline__Lcom_yandex_mapkit_location_LocationSimulator_;
	}

	private static nint n_CreateLocationSimulator_Lcom_yandex_mapkit_geometry_Polyline_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapKit? mapKit = Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Polyline p = Java.Lang.Object.GetObject<Polyline>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapKit.CreateLocationSimulator(p));
	}

	public unsafe ILocationSimulator CreateLocationSimulator(Polyline p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ILocationSimulator>(_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractObjectMethod("createLocationSimulator.(Lcom/yandex/mapkit/geometry/Polyline;)Lcom/yandex/mapkit/location/LocationSimulator;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetCreateMapWindow_Lcom_yandex_runtime_view_PlatformView_Handler()
	{
		if ((object)cb_createMapWindow_CreateMapWindow_Lcom_yandex_runtime_view_PlatformView__Lcom_yandex_mapkit_map_MapWindow_ == null)
		{
			cb_createMapWindow_CreateMapWindow_Lcom_yandex_runtime_view_PlatformView__Lcom_yandex_mapkit_map_MapWindow_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CreateMapWindow_Lcom_yandex_runtime_view_PlatformView_));
		}
		return cb_createMapWindow_CreateMapWindow_Lcom_yandex_runtime_view_PlatformView__Lcom_yandex_mapkit_map_MapWindow_;
	}

	private static nint n_CreateMapWindow_Lcom_yandex_runtime_view_PlatformView_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapKit? mapKit = Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IPlatformView p = Java.Lang.Object.GetObject<IPlatformView>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapKit.CreateMapWindow(p));
	}

	public unsafe IMapWindow CreateMapWindow(IPlatformView p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<IMapWindow>(_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractObjectMethod("createMapWindow.(Lcom/yandex/runtime/view/PlatformView;)Lcom/yandex/mapkit/map/MapWindow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetCreateMapWindow_Lcom_yandex_runtime_view_PlatformView_FHandler()
	{
		if ((object)cb_createMapWindow_CreateMapWindow_Lcom_yandex_runtime_view_PlatformView_F_Lcom_yandex_mapkit_map_MapWindow_ == null)
		{
			cb_createMapWindow_CreateMapWindow_Lcom_yandex_runtime_view_PlatformView_F_Lcom_yandex_mapkit_map_MapWindow_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLF_L(n_CreateMapWindow_Lcom_yandex_runtime_view_PlatformView_F));
		}
		return cb_createMapWindow_CreateMapWindow_Lcom_yandex_runtime_view_PlatformView_F_Lcom_yandex_mapkit_map_MapWindow_;
	}

	private static nint n_CreateMapWindow_Lcom_yandex_runtime_view_PlatformView_F(nint jnienv, nint native__this, nint native_p0, float p1)
	{
		IMapKit? mapKit = Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IPlatformView p2 = Java.Lang.Object.GetObject<IPlatformView>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapKit.CreateMapWindow(p2, p1));
	}

	public unsafe IMapWindow CreateMapWindow(IPlatformView p0, float p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue(p1);
			return Java.Lang.Object.GetObject<IMapWindow>(_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractObjectMethod("createMapWindow.(Lcom/yandex/runtime/view/PlatformView;F)Lcom/yandex/mapkit/map/MapWindow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetCreateTrafficLayer_Lcom_yandex_mapkit_map_MapWindow_Handler()
	{
		if ((object)cb_createTrafficLayer_CreateTrafficLayer_Lcom_yandex_mapkit_map_MapWindow__Lcom_yandex_mapkit_traffic_TrafficLayer_ == null)
		{
			cb_createTrafficLayer_CreateTrafficLayer_Lcom_yandex_mapkit_map_MapWindow__Lcom_yandex_mapkit_traffic_TrafficLayer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CreateTrafficLayer_Lcom_yandex_mapkit_map_MapWindow_));
		}
		return cb_createTrafficLayer_CreateTrafficLayer_Lcom_yandex_mapkit_map_MapWindow__Lcom_yandex_mapkit_traffic_TrafficLayer_;
	}

	private static nint n_CreateTrafficLayer_Lcom_yandex_mapkit_map_MapWindow_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapKit? mapKit = Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapWindow p = Java.Lang.Object.GetObject<IMapWindow>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapKit.CreateTrafficLayer(p));
	}

	public unsafe ITrafficLayer CreateTrafficLayer(IMapWindow p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<ITrafficLayer>(_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractObjectMethod("createTrafficLayer.(Lcom/yandex/mapkit/map/MapWindow;)Lcom/yandex/mapkit/traffic/TrafficLayer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetCreateUserLocationLayer_Lcom_yandex_mapkit_map_MapWindow_Handler()
	{
		if ((object)cb_createUserLocationLayer_CreateUserLocationLayer_Lcom_yandex_mapkit_map_MapWindow__Lcom_yandex_mapkit_user_location_UserLocationLayer_ == null)
		{
			cb_createUserLocationLayer_CreateUserLocationLayer_Lcom_yandex_mapkit_map_MapWindow__Lcom_yandex_mapkit_user_location_UserLocationLayer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CreateUserLocationLayer_Lcom_yandex_mapkit_map_MapWindow_));
		}
		return cb_createUserLocationLayer_CreateUserLocationLayer_Lcom_yandex_mapkit_map_MapWindow__Lcom_yandex_mapkit_user_location_UserLocationLayer_;
	}

	private static nint n_CreateUserLocationLayer_Lcom_yandex_mapkit_map_MapWindow_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapKit? mapKit = Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapWindow p = Java.Lang.Object.GetObject<IMapWindow>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapKit.CreateUserLocationLayer(p));
	}

	public unsafe IUserLocationLayer CreateUserLocationLayer(IMapWindow p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<IUserLocationLayer>(_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractObjectMethod("createUserLocationLayer.(Lcom/yandex/mapkit/map/MapWindow;)Lcom/yandex/mapkit/user_location/UserLocationLayer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnStartHandler()
	{
		if ((object)cb_onStart_OnStart_V == null)
		{
			cb_onStart_OnStart_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnStart));
		}
		return cb_onStart_OnStart_V;
	}

	private static void n_OnStart(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStart();
	}

	public unsafe void OnStart()
	{
		_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractVoidMethod("onStart.()V", this, null);
	}

	private static Delegate GetOnStopHandler()
	{
		if ((object)cb_onStop_OnStop_V == null)
		{
			cb_onStop_OnStop_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnStop));
		}
		return cb_onStop_OnStop_V;
	}

	private static void n_OnStop(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStop();
	}

	public unsafe void OnStop()
	{
		_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractVoidMethod("onStop.()V", this, null);
	}

	private static Delegate GetOnTerminateHandler()
	{
		if ((object)cb_onTerminate_OnTerminate_V == null)
		{
			cb_onTerminate_OnTerminate_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnTerminate));
		}
		return cb_onTerminate_OnTerminate_V;
	}

	private static void n_OnTerminate(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnTerminate();
	}

	public unsafe void OnTerminate()
	{
		_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractVoidMethod("onTerminate.()V", this, null);
	}

	private static Delegate GetResetLocationManagerToDefaultHandler()
	{
		if ((object)cb_resetLocationManagerToDefault_ResetLocationManagerToDefault_V == null)
		{
			cb_resetLocationManagerToDefault_ResetLocationManagerToDefault_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ResetLocationManagerToDefault));
		}
		return cb_resetLocationManagerToDefault_ResetLocationManagerToDefault_V;
	}

	private static void n_ResetLocationManagerToDefault(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetLocationManagerToDefault();
	}

	public unsafe void ResetLocationManagerToDefault()
	{
		_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractVoidMethod("resetLocationManagerToDefault.()V", this, null);
	}

	private static Delegate GetSetApiKey_Ljava_lang_String_Handler()
	{
		if ((object)cb_setApiKey_SetApiKey_Ljava_lang_String__V == null)
		{
			cb_setApiKey_SetApiKey_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetApiKey_Ljava_lang_String_));
		}
		return cb_setApiKey_SetApiKey_Ljava_lang_String__V;
	}

	private static void n_SetApiKey_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapKit? mapKit = Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string apiKey = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		mapKit.SetApiKey(apiKey);
	}

	public unsafe void SetApiKey(string p0)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractVoidMethod("setApiKey.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetLocationManager_Lcom_yandex_mapkit_location_LocationManager_Handler()
	{
		if ((object)cb_setLocationManager_SetLocationManager_Lcom_yandex_mapkit_location_LocationManager__V == null)
		{
			cb_setLocationManager_SetLocationManager_Lcom_yandex_mapkit_location_LocationManager__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetLocationManager_Lcom_yandex_mapkit_location_LocationManager_));
		}
		return cb_setLocationManager_SetLocationManager_Lcom_yandex_mapkit_location_LocationManager__V;
	}

	private static void n_SetLocationManager_Lcom_yandex_mapkit_location_LocationManager_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapKit? mapKit = Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ILocationManager locationManager = Java.Lang.Object.GetObject<ILocationManager>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapKit.SetLocationManager(locationManager);
	}

	public unsafe void SetLocationManager(ILocationManager p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractVoidMethod("setLocationManager.(Lcom/yandex/mapkit/location/LocationManager;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetUserId_Ljava_lang_String_Handler()
	{
		if ((object)cb_setUserId_SetUserId_Ljava_lang_String__V == null)
		{
			cb_setUserId_SetUserId_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetUserId_Ljava_lang_String_));
		}
		return cb_setUserId_SetUserId_Ljava_lang_String__V;
	}

	private static void n_SetUserId_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapKit? mapKit = Java.Lang.Object.GetObject<IMapKit>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string userId = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		mapKit.SetUserId(userId);
	}

	public unsafe void SetUserId(string p0)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_com_yandex_mapkit_MapKit.InstanceMethods.InvokeAbstractVoidMethod("setUserId.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}
}
