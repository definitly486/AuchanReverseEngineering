using System;
using System.Collections.Generic;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;

namespace Com.Yandex.Mapkit.Location;

[Register("com/yandex/mapkit/location/LocationSimulator", "", "Com.Yandex.Mapkit.Location.ILocationSimulatorInvoker")]
public interface ILocationSimulator : ILocationManager, IJavaObject, IDisposable, IJavaPeerable
{
	bool IsActive
	{
		[Register("isActive", "()Z", "GetIsActiveHandler:Com.Yandex.Mapkit.Location.ILocationSimulatorInvoker, Yandex.MapKit.Lite")]
		get;
	}

	IList<SimulationSettings> Settings
	{
		[Register("getSettings", "()Ljava/util/List;", "GetGetSettingsHandler:Com.Yandex.Mapkit.Location.ILocationSimulatorInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setSettings", "(Ljava/util/List;)V", "GetSetSettings_Ljava_util_List_Handler:Com.Yandex.Mapkit.Location.ILocationSimulatorInvoker, Yandex.MapKit.Lite")]
		set;
	}

	double Speed
	{
		[Register("getSpeed", "()D", "GetGetSpeedHandler:Com.Yandex.Mapkit.Location.ILocationSimulatorInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setSpeed", "(D)V", "GetSetSpeed_DHandler:Com.Yandex.Mapkit.Location.ILocationSimulatorInvoker, Yandex.MapKit.Lite")]
		set;
	}

	[Register("polylinePosition", "()Lcom/yandex/mapkit/geometry/PolylinePosition;", "GetPolylinePositionHandler:Com.Yandex.Mapkit.Location.ILocationSimulatorInvoker, Yandex.MapKit.Lite")]
	PolylinePosition PolylinePosition();

	[Register("startSimulation", "(Ljava/util/List;)V", "GetStartSimulation_Ljava_util_List_Handler:Com.Yandex.Mapkit.Location.ILocationSimulatorInvoker, Yandex.MapKit.Lite")]
	void StartSimulation(IList<SimulationSettings> p0);

	[Register("stopSimulation", "()V", "GetStopSimulationHandler:Com.Yandex.Mapkit.Location.ILocationSimulatorInvoker, Yandex.MapKit.Lite")]
	void StopSimulation();

	[Register("subscribeForSimulatorEvents", "(Lcom/yandex/mapkit/location/LocationSimulatorListener;)V", "GetSubscribeForSimulatorEvents_Lcom_yandex_mapkit_location_LocationSimulatorListener_Handler:Com.Yandex.Mapkit.Location.ILocationSimulatorInvoker, Yandex.MapKit.Lite")]
	void SubscribeForSimulatorEvents(ILocationSimulatorListener p0);

	[Register("unsubscribeFromSimulatorEvents", "(Lcom/yandex/mapkit/location/LocationSimulatorListener;)V", "GetUnsubscribeFromSimulatorEvents_Lcom_yandex_mapkit_location_LocationSimulatorListener_Handler:Com.Yandex.Mapkit.Location.ILocationSimulatorInvoker, Yandex.MapKit.Lite")]
	void UnsubscribeFromSimulatorEvents(ILocationSimulatorListener p0);
}
