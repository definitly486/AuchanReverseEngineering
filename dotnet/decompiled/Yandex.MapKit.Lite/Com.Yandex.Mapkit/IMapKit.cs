using System;
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

namespace Com.Yandex.Mapkit;

[Register("com/yandex/mapkit/MapKit", "", "Com.Yandex.Mapkit.IMapKitInvoker")]
public interface IMapKit : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
		get;
	}

	IOfflineCacheManager OfflineCacheManager
	{
		[Register("getOfflineCacheManager", "()Lcom/yandex/mapkit/offline_cache/OfflineCacheManager;", "GetGetOfflineCacheManagerHandler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
		get;
	}

	IStorageManager StorageManager
	{
		[Register("getStorageManager", "()Lcom/yandex/mapkit/storage/StorageManager;", "GetGetStorageManagerHandler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
		get;
	}

	string Version
	{
		[Register("getVersion", "()Ljava/lang/String;", "GetGetVersionHandler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
		get;
	}

	[Register("createDummyLocationManager", "()Lcom/yandex/mapkit/location/DummyLocationManager;", "GetCreateDummyLocationManagerHandler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
	IDummyLocationManager CreateDummyLocationManager();

	[Register("createLocationManager", "()Lcom/yandex/mapkit/location/LocationManager;", "GetCreateLocationManagerHandler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
	ILocationManager CreateLocationManager();

	[Register("createLocationSimulator", "()Lcom/yandex/mapkit/location/LocationSimulator;", "GetCreateLocationSimulatorHandler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
	ILocationSimulator CreateLocationSimulator();

	[Register("createLocationSimulator", "(Lcom/yandex/mapkit/geometry/Polyline;)Lcom/yandex/mapkit/location/LocationSimulator;", "GetCreateLocationSimulator_Lcom_yandex_mapkit_geometry_Polyline_Handler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
	ILocationSimulator CreateLocationSimulator(Polyline p0);

	[Register("createMapWindow", "(Lcom/yandex/runtime/view/PlatformView;)Lcom/yandex/mapkit/map/MapWindow;", "GetCreateMapWindow_Lcom_yandex_runtime_view_PlatformView_Handler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
	IMapWindow CreateMapWindow(IPlatformView p0);

	[Register("createMapWindow", "(Lcom/yandex/runtime/view/PlatformView;F)Lcom/yandex/mapkit/map/MapWindow;", "GetCreateMapWindow_Lcom_yandex_runtime_view_PlatformView_FHandler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
	IMapWindow CreateMapWindow(IPlatformView p0, float p1);

	[Register("createTrafficLayer", "(Lcom/yandex/mapkit/map/MapWindow;)Lcom/yandex/mapkit/traffic/TrafficLayer;", "GetCreateTrafficLayer_Lcom_yandex_mapkit_map_MapWindow_Handler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
	ITrafficLayer CreateTrafficLayer(IMapWindow p0);

	[Register("createUserLocationLayer", "(Lcom/yandex/mapkit/map/MapWindow;)Lcom/yandex/mapkit/user_location/UserLocationLayer;", "GetCreateUserLocationLayer_Lcom_yandex_mapkit_map_MapWindow_Handler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
	IUserLocationLayer CreateUserLocationLayer(IMapWindow p0);

	[Register("onStart", "()V", "GetOnStartHandler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
	void OnStart();

	[Register("onStop", "()V", "GetOnStopHandler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
	void OnStop();

	[Register("onTerminate", "()V", "GetOnTerminateHandler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
	void OnTerminate();

	[Register("resetLocationManagerToDefault", "()V", "GetResetLocationManagerToDefaultHandler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
	void ResetLocationManagerToDefault();

	[Register("setApiKey", "(Ljava/lang/String;)V", "GetSetApiKey_Ljava_lang_String_Handler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
	void SetApiKey(string p0);

	[Register("setLocationManager", "(Lcom/yandex/mapkit/location/LocationManager;)V", "GetSetLocationManager_Lcom_yandex_mapkit_location_LocationManager_Handler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
	void SetLocationManager(ILocationManager p0);

	[Register("setUserId", "(Ljava/lang/String;)V", "GetSetUserId_Ljava_lang_String_Handler:Com.Yandex.Mapkit.IMapKitInvoker, Yandex.MapKit.Lite")]
	void SetUserId(string p0);
}
