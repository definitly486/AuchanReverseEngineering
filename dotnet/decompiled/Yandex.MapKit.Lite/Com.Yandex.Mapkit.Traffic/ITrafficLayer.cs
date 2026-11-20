using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Traffic;

[Register("com/yandex/mapkit/traffic/TrafficLayer", "", "Com.Yandex.Mapkit.Traffic.ITrafficLayerInvoker")]
public interface ITrafficLayer : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Traffic.ITrafficLayerInvoker, Yandex.MapKit.Lite")]
		get;
	}

	bool TrafficVisible
	{
		[Register("isTrafficVisible", "()Z", "GetIsTrafficVisibleHandler:Com.Yandex.Mapkit.Traffic.ITrafficLayerInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setTrafficVisible", "(Z)V", "GetSetTrafficVisible_ZHandler:Com.Yandex.Mapkit.Traffic.ITrafficLayerInvoker, Yandex.MapKit.Lite")]
		set;
	}

	[Register("addTrafficListener", "(Lcom/yandex/mapkit/traffic/TrafficListener;)V", "GetAddTrafficListener_Lcom_yandex_mapkit_traffic_TrafficListener_Handler:Com.Yandex.Mapkit.Traffic.ITrafficLayerInvoker, Yandex.MapKit.Lite")]
	void AddTrafficListener(ITrafficListener p0);

	[Register("removeTrafficListener", "(Lcom/yandex/mapkit/traffic/TrafficListener;)V", "GetRemoveTrafficListener_Lcom_yandex_mapkit_traffic_TrafficListener_Handler:Com.Yandex.Mapkit.Traffic.ITrafficLayerInvoker, Yandex.MapKit.Lite")]
	void RemoveTrafficListener(ITrafficListener p0);

	[Register("resetTrafficStyles", "()V", "GetResetTrafficStylesHandler:Com.Yandex.Mapkit.Traffic.ITrafficLayerInvoker, Yandex.MapKit.Lite")]
	void ResetTrafficStyles();

	[Register("setTrafficStyle", "(ILjava/lang/String;)Z", "GetSetTrafficStyle_ILjava_lang_String_Handler:Com.Yandex.Mapkit.Traffic.ITrafficLayerInvoker, Yandex.MapKit.Lite")]
	bool SetTrafficStyle(int p0, string p1);

	[Register("setTrafficStyle", "(Ljava/lang/String;)Z", "GetSetTrafficStyle_Ljava_lang_String_Handler:Com.Yandex.Mapkit.Traffic.ITrafficLayerInvoker, Yandex.MapKit.Lite")]
	bool SetTrafficStyle(string p0);
}
