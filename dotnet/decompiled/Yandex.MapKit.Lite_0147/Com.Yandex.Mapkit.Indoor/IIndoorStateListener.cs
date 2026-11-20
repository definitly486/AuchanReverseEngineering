using System;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Indoor;

[Register("com/yandex/mapkit/indoor/IndoorStateListener", "", "Com.Yandex.Mapkit.Indoor.IIndoorStateListenerInvoker")]
public interface IIndoorStateListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onActiveLevelChanged", "(Ljava/lang/String;)V", "GetOnActiveLevelChanged_Ljava_lang_String_Handler:Com.Yandex.Mapkit.Indoor.IIndoorStateListenerInvoker, Yandex.MapKit.Lite")]
	void OnActiveLevelChanged(string p0);

	[Register("onActivePlanFocused", "(Lcom/yandex/mapkit/indoor/IndoorPlan;)V", "GetOnActivePlanFocused_Lcom_yandex_mapkit_indoor_IndoorPlan_Handler:Com.Yandex.Mapkit.Indoor.IIndoorStateListenerInvoker, Yandex.MapKit.Lite")]
	void OnActivePlanFocused(IIndoorPlan p0);

	[Register("onActivePlanLeft", "()V", "GetOnActivePlanLeftHandler:Com.Yandex.Mapkit.Indoor.IIndoorStateListenerInvoker, Yandex.MapKit.Lite")]
	void OnActivePlanLeft();
}
