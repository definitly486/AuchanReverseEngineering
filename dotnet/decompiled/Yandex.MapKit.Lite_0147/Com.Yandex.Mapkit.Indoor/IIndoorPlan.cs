using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace Com.Yandex.Mapkit.Indoor;

[Register("com/yandex/mapkit/indoor/IndoorPlan", "", "Com.Yandex.Mapkit.Indoor.IIndoorPlanInvoker")]
public interface IIndoorPlan : IJavaObject, IDisposable, IJavaPeerable
{
	string ActiveLevelId
	{
		[Register("getActiveLevelId", "()Ljava/lang/String;", "GetGetActiveLevelIdHandler:Com.Yandex.Mapkit.Indoor.IIndoorPlanInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setActiveLevelId", "(Ljava/lang/String;)V", "GetSetActiveLevelId_Ljava_lang_String_Handler:Com.Yandex.Mapkit.Indoor.IIndoorPlanInvoker, Yandex.MapKit.Lite")]
		set;
	}

	IList<IndoorLevel> Levels
	{
		[Register("getLevels", "()Ljava/util/List;", "GetGetLevelsHandler:Com.Yandex.Mapkit.Indoor.IIndoorPlanInvoker, Yandex.MapKit.Lite")]
		get;
	}
}
