using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapObject", "", "Com.Yandex.Mapkit.Map.IMapObjectInvoker")]
public interface IMapObject : IJavaObject, IDisposable, IJavaPeerable
{
	bool Draggable
	{
		[Register("isDraggable", "()Z", "GetIsDraggableHandler:Com.Yandex.Mapkit.Map.IMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setDraggable", "(Z)V", "GetSetDraggable_ZHandler:Com.Yandex.Mapkit.Map.IMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Com.Yandex.Mapkit.Map.IMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
	}

	IBaseMapObjectCollection Parent
	{
		[Register("getParent", "()Lcom/yandex/mapkit/map/BaseMapObjectCollection;", "GetGetParentHandler:Com.Yandex.Mapkit.Map.IMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
	}

	Java.Lang.Object? UserData
	{
		[Register("getUserData", "()Ljava/lang/Object;", "GetGetUserDataHandler:Com.Yandex.Mapkit.Map.IMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setUserData", "(Ljava/lang/Object;)V", "GetSetUserData_Ljava_lang_Object_Handler:Com.Yandex.Mapkit.Map.IMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	bool Visible
	{
		[Register("isVisible", "()Z", "GetIsVisibleHandler:Com.Yandex.Mapkit.Map.IMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setVisible", "(Z)V", "GetSetVisible_ZHandler:Com.Yandex.Mapkit.Map.IMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	float ZIndex
	{
		[Register("getZIndex", "()F", "GetGetZIndexHandler:Com.Yandex.Mapkit.Map.IMapObjectInvoker, Yandex.MapKit.Lite")]
		get;
		[Register("setZIndex", "(F)V", "GetSetZIndex_FHandler:Com.Yandex.Mapkit.Map.IMapObjectInvoker, Yandex.MapKit.Lite")]
		set;
	}

	[Register("addTapListener", "(Lcom/yandex/mapkit/map/MapObjectTapListener;)V", "GetAddTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener_Handler:Com.Yandex.Mapkit.Map.IMapObjectInvoker, Yandex.MapKit.Lite")]
	void AddTapListener(IMapObjectTapListener p0);

	[Register("removeTapListener", "(Lcom/yandex/mapkit/map/MapObjectTapListener;)V", "GetRemoveTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener_Handler:Com.Yandex.Mapkit.Map.IMapObjectInvoker, Yandex.MapKit.Lite")]
	void RemoveTapListener(IMapObjectTapListener p0);

	[Register("setDragListener", "(Lcom/yandex/mapkit/map/MapObjectDragListener;)V", "GetSetDragListener_Lcom_yandex_mapkit_map_MapObjectDragListener_Handler:Com.Yandex.Mapkit.Map.IMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetDragListener(IMapObjectDragListener? p0);

	[Register("setVisible", "(ZLcom/yandex/mapkit/Animation;Lcom/yandex/mapkit/map/Callback;)V", "GetSetVisible_ZLcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Callback_Handler:Com.Yandex.Mapkit.Map.IMapObjectInvoker, Yandex.MapKit.Lite")]
	void SetVisible(bool p0, Animation p1, ICallback? p2);
}
