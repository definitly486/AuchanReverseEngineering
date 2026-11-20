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

[Register("com/yandex/mapkit/map/Map", "", "Com.Yandex.Mapkit.Map.IMapInvoker")]
public interface IMap : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/yandex/mapkit/map/Map$CameraCallback", "", "Com.Yandex.Mapkit.Map.IMap/ICameraCallbackInvoker")]
	public interface ICameraCallback : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onMoveFinished", "(Z)V", "GetOnMoveFinished_ZHandler:Com.Yandex.Mapkit.Map.IMap/ICameraCallbackInvoker, Yandex.MapKit.Lite")]
		void OnMoveFinished(bool p0);
	}

	[Register("com/yandex/mapkit/map/Map$CameraCallback", DoNotGenerateAcw = true)]
	internal class ICameraCallbackInvoker : Java.Lang.Object, ICameraCallback, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members_com_yandex_mapkit_map_Map_CameraCallback = new XAPeerMembers("com/yandex/mapkit/map/Map$CameraCallback", typeof(ICameraCallbackInvoker));

		private static Delegate? cb_onMoveFinished_OnMoveFinished_Z_V;

		private static nint java_class_ref => _members_com_yandex_mapkit_map_Map_CameraCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_Map_CameraCallback;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members_com_yandex_mapkit_map_Map_CameraCallback.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members_com_yandex_mapkit_map_Map_CameraCallback.ManagedPeerType;

		public ICameraCallbackInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		private static Delegate GetOnMoveFinished_ZHandler()
		{
			if ((object)cb_onMoveFinished_OnMoveFinished_Z_V == null)
			{
				cb_onMoveFinished_OnMoveFinished_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_OnMoveFinished_Z));
			}
			return cb_onMoveFinished_OnMoveFinished_Z_V;
		}

		private static void n_OnMoveFinished_Z(nint jnienv, nint native__this, bool p0)
		{
			Java.Lang.Object.GetObject<ICameraCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnMoveFinished(p0);
		}

		public unsafe void OnMoveFinished(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			_members_com_yandex_mapkit_map_Map_CameraCallback.InstanceMethods.InvokeAbstractVoidMethod("onMoveFinished.(Z)V", this, ptr);
		}
	}

	bool AwesomeModelsEnabled
	{
		[Register("isAwesomeModelsEnabled", "()Z", "GetIsAwesomeModelsEnabledHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setAwesomeModelsEnabled", "(Z)V", "GetSetAwesomeModelsEnabled_ZHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		set;
	}

	ICameraBounds CameraBounds
	{
		[Register("getCameraBounds", "()Lcom/yandex/mapkit/map/CameraBounds;", "GetGetCameraBoundsHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
	}

	CameraPosition CameraPosition
	{
		[Register("getCameraPosition", "()Lcom/yandex/mapkit/map/CameraPosition;", "GetGetCameraPositionHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
	}

	bool FastTapEnabled
	{
		[Register("isFastTapEnabled", "()Z", "GetIsFastTapEnabledHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setFastTapEnabled", "(Z)V", "GetSetFastTapEnabled_ZHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool HdModeEnabled
	{
		[Register("isHdModeEnabled", "()Z", "GetIsHdModeEnabledHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setHdModeEnabled", "(Z)V", "GetSetHdModeEnabled_ZHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool IndoorEnabled
	{
		[Register("isIndoorEnabled", "()Z", "GetIsIndoorEnabledHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setIndoorEnabled", "(Z)V", "GetSetIndoorEnabled_ZHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
	}

	ILogo Logo
	{
		[Register("getLogo", "()Lcom/yandex/mapkit/logo/Logo;", "GetGetLogoHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
	}

	IRootMapObjectCollection MapObjects
	{
		[Register("getMapObjects", "()Lcom/yandex/mapkit/map/RootMapObjectCollection;", "GetGetMapObjectsHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
	}

	MapType MapType
	{
		[Register("getMapType", "()Lcom/yandex/mapkit/map/MapType;", "GetGetMapTypeHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setMapType", "(Lcom/yandex/mapkit/map/MapType;)V", "GetSetMapType_Lcom_yandex_mapkit_map_MapType_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		set;
	}

	MapMode Mode
	{
		[Register("getMode", "()Lcom/yandex/mapkit/map/MapMode;", "GetGetModeHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setMode", "(Lcom/yandex/mapkit/map/MapMode;)V", "GetSetMode_Lcom_yandex_mapkit_map_MapMode_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool NightModeEnabled
	{
		[Register("isNightModeEnabled", "()Z", "GetIsNightModeEnabledHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setNightModeEnabled", "(Z)V", "GetSetNightModeEnabled_ZHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		set;
	}

	Integer? PoiLimit
	{
		[Register("getPoiLimit", "()Ljava/lang/Integer;", "GetGetPoiLimitHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setPoiLimit", "(Ljava/lang/Integer;)V", "GetSetPoiLimit_Ljava_lang_Integer_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool RotateGesturesEnabled
	{
		[Register("isRotateGesturesEnabled", "()Z", "GetIsRotateGesturesEnabledHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setRotateGesturesEnabled", "(Z)V", "GetSetRotateGesturesEnabled_ZHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool ScrollGesturesEnabled
	{
		[Register("isScrollGesturesEnabled", "()Z", "GetIsScrollGesturesEnabledHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setScrollGesturesEnabled", "(Z)V", "GetSetScrollGesturesEnabled_ZHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool TiltGesturesEnabled
	{
		[Register("isTiltGesturesEnabled", "()Z", "GetIsTiltGesturesEnabledHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setTiltGesturesEnabled", "(Z)V", "GetSetTiltGesturesEnabled_ZHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		set;
	}

	VisibleRegion VisibleRegion
	{
		[Register("getVisibleRegion", "()Lcom/yandex/mapkit/map/VisibleRegion;", "GetGetVisibleRegionHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
	}

	bool ZoomGesturesEnabled
	{
		[Register("isZoomGesturesEnabled", "()Z", "GetIsZoomGesturesEnabledHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setZoomGesturesEnabled", "(Z)V", "GetSetZoomGesturesEnabled_ZHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
		set;
	}

	[Register("addCameraListener", "(Lcom/yandex/mapkit/map/CameraListener;)V", "GetAddCameraListener_Lcom_yandex_mapkit_map_CameraListener_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	void AddCameraListener(ICameraListener p0);

	[Register("addIndoorStateListener", "(Lcom/yandex/mapkit/indoor/IndoorStateListener;)V", "GetAddIndoorStateListener_Lcom_yandex_mapkit_indoor_IndoorStateListener_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	void AddIndoorStateListener(IIndoorStateListener p0);

	[Register("addInputListener", "(Lcom/yandex/mapkit/map/InputListener;)V", "GetAddInputListener_Lcom_yandex_mapkit_map_InputListener_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	void AddInputListener(IInputListener p0);

	[Register("addMapObjectLayer", "(Ljava/lang/String;)Lcom/yandex/mapkit/map/RootMapObjectCollection;", "GetAddMapObjectLayer_Ljava_lang_String_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	IRootMapObjectCollection AddMapObjectLayer(string p0);

	[Register("addTapListener", "(Lcom/yandex/mapkit/layers/GeoObjectTapListener;)V", "GetAddTapListener_Lcom_yandex_mapkit_layers_GeoObjectTapListener_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	void AddTapListener(IGeoObjectTapListener p0);

	[Register("addTileLayer", "(Ljava/lang/String;Lcom/yandex/mapkit/layers/LayerOptions;Lcom/yandex/mapkit/map/CreateTileDataSource;)Lcom/yandex/mapkit/layers/Layer;", "GetAddTileLayer_Ljava_lang_String_Lcom_yandex_mapkit_layers_LayerOptions_Lcom_yandex_mapkit_map_CreateTileDataSource_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	ILayer AddTileLayer(string p0, LayerOptions p1, ICreateTileDataSource p2);

	[Register("cameraPosition", "(Lcom/yandex/mapkit/geometry/Geometry;)Lcom/yandex/mapkit/map/CameraPosition;", "GetInvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	CameraPosition InvokeCameraPosition(Com.Yandex.Mapkit.Geometry.Geometry p0);

	[Register("cameraPosition", "(Lcom/yandex/mapkit/geometry/Geometry;Lcom/yandex/mapkit/ScreenRect;)Lcom/yandex/mapkit/map/CameraPosition;", "GetInvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_Lcom_yandex_mapkit_ScreenRect_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	CameraPosition InvokeCameraPosition(Com.Yandex.Mapkit.Geometry.Geometry p0, ScreenRect p1);

	[Register("cameraPosition", "(Lcom/yandex/mapkit/geometry/Geometry;FFLcom/yandex/mapkit/ScreenRect;)Lcom/yandex/mapkit/map/CameraPosition;", "GetInvokeCameraPosition_Lcom_yandex_mapkit_geometry_Geometry_FFLcom_yandex_mapkit_ScreenRect_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	CameraPosition InvokeCameraPosition(Com.Yandex.Mapkit.Geometry.Geometry p0, float p1, float p2, ScreenRect? p3);

	[Register("deselectGeoObject", "()V", "GetDeselectGeoObjectHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	void DeselectGeoObject();

	[Register("move", "(Lcom/yandex/mapkit/map/CameraPosition;)V", "GetMove_Lcom_yandex_mapkit_map_CameraPosition_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	void Move(CameraPosition p0);

	[Register("move", "(Lcom/yandex/mapkit/map/CameraPosition;Lcom/yandex/mapkit/Animation;Lcom/yandex/mapkit/map/Map$CameraCallback;)V", "GetMove_Lcom_yandex_mapkit_map_CameraPosition_Lcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Map_CameraCallback_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	void Move(CameraPosition p0, Animation p1, ICameraCallback? p2);

	[Register("projection", "()Lcom/yandex/mapkit/geometry/geo/Projection;", "GetProjectionHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	IProjection Projection();

	[Register("removeCameraListener", "(Lcom/yandex/mapkit/map/CameraListener;)V", "GetRemoveCameraListener_Lcom_yandex_mapkit_map_CameraListener_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	void RemoveCameraListener(ICameraListener p0);

	[Register("removeIndoorStateListener", "(Lcom/yandex/mapkit/indoor/IndoorStateListener;)V", "GetRemoveIndoorStateListener_Lcom_yandex_mapkit_indoor_IndoorStateListener_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	void RemoveIndoorStateListener(IIndoorStateListener p0);

	[Register("removeInputListener", "(Lcom/yandex/mapkit/map/InputListener;)V", "GetRemoveInputListener_Lcom_yandex_mapkit_map_InputListener_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	void RemoveInputListener(IInputListener p0);

	[Register("removeTapListener", "(Lcom/yandex/mapkit/layers/GeoObjectTapListener;)V", "GetRemoveTapListener_Lcom_yandex_mapkit_layers_GeoObjectTapListener_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	void RemoveTapListener(IGeoObjectTapListener p0);

	[Register("resetMapStyles", "()V", "GetResetMapStylesHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	void ResetMapStyles();

	[Register("selectGeoObject", "(Lcom/yandex/mapkit/map/GeoObjectSelectionMetadata;)V", "GetSelectGeoObject_Lcom_yandex_mapkit_map_GeoObjectSelectionMetadata_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	void SelectGeoObject(GeoObjectSelectionMetadata p0);

	[Register("set2DMode", "(Z)V", "GetSet2DMode_ZHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	void Set2DMode(bool p0);

	[Register("setMapLoadedListener", "(Lcom/yandex/mapkit/map/MapLoadedListener;)V", "GetSetMapLoadedListener_Lcom_yandex_mapkit_map_MapLoadedListener_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	void SetMapLoadedListener(IMapLoadedListener? p0);

	[Register("setMapStyle", "(ILjava/lang/String;)Z", "GetSetMapStyle_ILjava_lang_String_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	bool SetMapStyle(int p0, string p1);

	[Register("setMapStyle", "(Ljava/lang/String;)Z", "GetSetMapStyle_Ljava_lang_String_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	bool SetMapStyle(string p0);

	[Register("startTileLoadMetricsCapture", "()V", "GetStartTileLoadMetricsCaptureHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	void StartTileLoadMetricsCapture();

	[Register("stopTileLoadMetricsCapture", "()Ljava/lang/String;", "GetStopTileLoadMetricsCaptureHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	string StopTileLoadMetricsCapture();

	[Register("visibleRegion", "(Lcom/yandex/mapkit/map/CameraPosition;)Lcom/yandex/mapkit/map/VisibleRegion;", "GetInvokeVisibleRegion_Lcom_yandex_mapkit_map_CameraPosition_Handler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	VisibleRegion InvokeVisibleRegion(CameraPosition p0);

	[Register("wipe", "()V", "GetWipeHandler:Com.Yandex.Mapkit.Map.IMapInvoker, Yandex.MapKit.Lite")]
	void Wipe();
}
