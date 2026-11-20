using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Runtime.Image;
using Com.Yandex.Runtime.Ui_view;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapObjectCollection", DoNotGenerateAcw = true)]
internal class IMapObjectCollectionInvoker : Java.Lang.Object, IMapObjectCollection, IBaseMapObjectCollection, IMapObject, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_BaseMapObjectCollection = new XAPeerMembers("com/yandex/mapkit/map/BaseMapObjectCollection", typeof(IMapObjectCollectionInvoker));

	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_MapObject = new XAPeerMembers("com/yandex/mapkit/map/MapObject", typeof(IMapObjectCollectionInvoker));

	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_MapObjectCollection = new XAPeerMembers("com/yandex/mapkit/map/MapObjectCollection", typeof(IMapObjectCollectionInvoker));

	private static Delegate? cb_addCircle_AddCircle_Lcom_yandex_mapkit_geometry_Circle__Lcom_yandex_mapkit_map_CircleMapObject_;

	private static Delegate? cb_addClusterizedPlacemarkCollection_AddClusterizedPlacemarkCollection_Lcom_yandex_mapkit_map_ClusterListener__Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection_;

	private static Delegate? cb_addCollection_AddCollection_Lcom_yandex_mapkit_map_MapObjectCollection_;

	private static Delegate? cb_addEmptyPlacemark_AddEmptyPlacemark_Lcom_yandex_mapkit_geometry_Point__Lcom_yandex_mapkit_map_PlacemarkMapObject_;

	private static Delegate? cb_addEmptyPlacemarks_AddEmptyPlacemarks_Ljava_util_List__Ljava_util_List_;

	private static Delegate? cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_map_PlacemarkMapObject_;

	private static Delegate? cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point__Lcom_yandex_mapkit_map_PlacemarkMapObject_;

	private static Delegate? cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle__Lcom_yandex_mapkit_map_PlacemarkMapObject_;

	private static Delegate? cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider__Lcom_yandex_mapkit_map_PlacemarkMapObject_;

	private static Delegate? cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__Lcom_yandex_mapkit_map_PlacemarkMapObject_;

	private static Delegate? cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider__Lcom_yandex_mapkit_map_PlacemarkMapObject_;

	private static Delegate? cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle__Lcom_yandex_mapkit_map_PlacemarkMapObject_;

	private static Delegate? cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_map_PlacemarkCreatedCallback__Lcom_yandex_mapkit_map_PlacemarkMapObject_;

	private static Delegate? cb_addPlacemarks_AddPlacemarks_Ljava_util_List_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__Ljava_util_List_;

	private static Delegate? cb_addPolygon_AddPolygon_Lcom_yandex_mapkit_geometry_Polygon__Lcom_yandex_mapkit_map_PolygonMapObject_;

	private static Delegate? cb_addPolyline_AddPolyline_Lcom_yandex_mapkit_map_PolylineMapObject_;

	private static Delegate? cb_addPolyline_AddPolyline_Lcom_yandex_mapkit_geometry_Polyline__Lcom_yandex_mapkit_map_PolylineMapObject_;

	private static Delegate? cb_placemarksStyler_PlacemarksStyler_Lcom_yandex_mapkit_map_PlacemarksStyler_;

	private static Delegate? cb_addListener_AddListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener__V;

	private static Delegate? cb_clear_Clear_V;

	private static Delegate? cb_remove_Remove_Lcom_yandex_mapkit_map_MapObject__V;

	private static Delegate? cb_removeListener_RemoveListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener__V;

	private static Delegate? cb_traverse_Traverse_Lcom_yandex_mapkit_map_MapObjectVisitor__V;

	private static Delegate? cb_isDraggable_IsDraggable_Z;

	private static Delegate? cb_setDraggable_SetDraggable_Z_V;

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_getParent_GetParent_Lcom_yandex_mapkit_map_BaseMapObjectCollection_;

	private static Delegate? cb_getUserData_GetUserData_Ljava_lang_Object_;

	private static Delegate? cb_setUserData_SetUserData_Ljava_lang_Object__V;

	private static Delegate? cb_isVisible_IsVisible_Z;

	private static Delegate? cb_setVisible_SetVisible_Z_V;

	private static Delegate? cb_getZIndex_GetZIndex_F;

	private static Delegate? cb_setZIndex_SetZIndex_F_V;

	private static Delegate? cb_addTapListener_AddTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener__V;

	private static Delegate? cb_removeTapListener_RemoveTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener__V;

	private static Delegate? cb_setDragListener_SetDragListener_Lcom_yandex_mapkit_map_MapObjectDragListener__V;

	private static Delegate? cb_setVisible_SetVisible_ZLcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Callback__V;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_MapObjectCollection.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_MapObjectCollection;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_MapObjectCollection.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_MapObjectCollection.ManagedPeerType;

	public unsafe bool Draggable
	{
		get
		{
			return _members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractBooleanMethod("isDraggable.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractVoidMethod("setDraggable.(Z)V", this, ptr);
		}
	}

	public unsafe bool IsValid => _members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public unsafe IBaseMapObjectCollection Parent => Java.Lang.Object.GetObject<IBaseMapObjectCollection>(_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractObjectMethod("getParent.()Lcom/yandex/mapkit/map/BaseMapObjectCollection;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe Java.Lang.Object? UserData
	{
		get
		{
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractObjectMethod("getUserData.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractVoidMethod("setUserData.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe bool Visible
	{
		get
		{
			return _members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractVoidMethod("setVisible.(Z)V", this, ptr);
		}
	}

	public unsafe float ZIndex
	{
		get
		{
			return _members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractSingleMethod("getZIndex.()F", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractVoidMethod("setZIndex.(F)V", this, ptr);
		}
	}

	public IMapObjectCollectionInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetAddCircle_Lcom_yandex_mapkit_geometry_Circle_Handler()
	{
		if ((object)cb_addCircle_AddCircle_Lcom_yandex_mapkit_geometry_Circle__Lcom_yandex_mapkit_map_CircleMapObject_ == null)
		{
			cb_addCircle_AddCircle_Lcom_yandex_mapkit_geometry_Circle__Lcom_yandex_mapkit_map_CircleMapObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddCircle_Lcom_yandex_mapkit_geometry_Circle_));
		}
		return cb_addCircle_AddCircle_Lcom_yandex_mapkit_geometry_Circle__Lcom_yandex_mapkit_map_CircleMapObject_;
	}

	private static nint n_AddCircle_Lcom_yandex_mapkit_geometry_Circle_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Circle p = Java.Lang.Object.GetObject<Circle>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapObjectCollection.AddCircle(p));
	}

	public unsafe ICircleMapObject AddCircle(Circle p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ICircleMapObject>(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("addCircle.(Lcom/yandex/mapkit/geometry/Circle;)Lcom/yandex/mapkit/map/CircleMapObject;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAddClusterizedPlacemarkCollection_Lcom_yandex_mapkit_map_ClusterListener_Handler()
	{
		if ((object)cb_addClusterizedPlacemarkCollection_AddClusterizedPlacemarkCollection_Lcom_yandex_mapkit_map_ClusterListener__Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection_ == null)
		{
			cb_addClusterizedPlacemarkCollection_AddClusterizedPlacemarkCollection_Lcom_yandex_mapkit_map_ClusterListener__Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddClusterizedPlacemarkCollection_Lcom_yandex_mapkit_map_ClusterListener_));
		}
		return cb_addClusterizedPlacemarkCollection_AddClusterizedPlacemarkCollection_Lcom_yandex_mapkit_map_ClusterListener__Lcom_yandex_mapkit_map_ClusterizedPlacemarkCollection_;
	}

	private static nint n_AddClusterizedPlacemarkCollection_Lcom_yandex_mapkit_map_ClusterListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IClusterListener p = Java.Lang.Object.GetObject<IClusterListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapObjectCollection.AddClusterizedPlacemarkCollection(p));
	}

	public unsafe IClusterizedPlacemarkCollection AddClusterizedPlacemarkCollection(IClusterListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<IClusterizedPlacemarkCollection>(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("addClusterizedPlacemarkCollection.(Lcom/yandex/mapkit/map/ClusterListener;)Lcom/yandex/mapkit/map/ClusterizedPlacemarkCollection;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAddCollectionHandler()
	{
		if ((object)cb_addCollection_AddCollection_Lcom_yandex_mapkit_map_MapObjectCollection_ == null)
		{
			cb_addCollection_AddCollection_Lcom_yandex_mapkit_map_MapObjectCollection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AddCollection));
		}
		return cb_addCollection_AddCollection_Lcom_yandex_mapkit_map_MapObjectCollection_;
	}

	private static nint n_AddCollection(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddCollection());
	}

	public unsafe IMapObjectCollection AddCollection()
	{
		return Java.Lang.Object.GetObject<IMapObjectCollection>(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("addCollection.()Lcom/yandex/mapkit/map/MapObjectCollection;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete]
	private static Delegate GetAddEmptyPlacemark_Lcom_yandex_mapkit_geometry_Point_Handler()
	{
		if ((object)cb_addEmptyPlacemark_AddEmptyPlacemark_Lcom_yandex_mapkit_geometry_Point__Lcom_yandex_mapkit_map_PlacemarkMapObject_ == null)
		{
			cb_addEmptyPlacemark_AddEmptyPlacemark_Lcom_yandex_mapkit_geometry_Point__Lcom_yandex_mapkit_map_PlacemarkMapObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddEmptyPlacemark_Lcom_yandex_mapkit_geometry_Point_));
		}
		return cb_addEmptyPlacemark_AddEmptyPlacemark_Lcom_yandex_mapkit_geometry_Point__Lcom_yandex_mapkit_map_PlacemarkMapObject_;
	}

	[Obsolete]
	private static nint n_AddEmptyPlacemark_Lcom_yandex_mapkit_geometry_Point_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Point p = Java.Lang.Object.GetObject<Point>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapObjectCollection.AddEmptyPlacemark(p));
	}

	public unsafe IPlacemarkMapObject AddEmptyPlacemark(Point p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IPlacemarkMapObject>(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("addEmptyPlacemark.(Lcom/yandex/mapkit/geometry/Point;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	[Obsolete]
	private static Delegate GetAddEmptyPlacemarks_Ljava_util_List_Handler()
	{
		if ((object)cb_addEmptyPlacemarks_AddEmptyPlacemarks_Ljava_util_List__Ljava_util_List_ == null)
		{
			cb_addEmptyPlacemarks_AddEmptyPlacemarks_Ljava_util_List__Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddEmptyPlacemarks_Ljava_util_List_));
		}
		return cb_addEmptyPlacemarks_AddEmptyPlacemarks_Ljava_util_List__Ljava_util_List_;
	}

	[Obsolete]
	private static nint n_AddEmptyPlacemarks_Ljava_util_List_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<Point> p = JavaList<Point>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		return JavaList<IPlacemarkMapObject>.ToLocalJniHandle(mapObjectCollection.AddEmptyPlacemarks(p));
	}

	public unsafe IList<IPlacemarkMapObject> AddEmptyPlacemarks(IList<Point> p0)
	{
		nint num = JavaList<Point>.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return JavaList<IPlacemarkMapObject>.FromJniHandle(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("addEmptyPlacemarks.(Ljava/util/List;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAddPlacemarkHandler()
	{
		if ((object)cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_map_PlacemarkMapObject_ == null)
		{
			cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_map_PlacemarkMapObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AddPlacemark));
		}
		return cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_map_PlacemarkMapObject_;
	}

	private static nint n_AddPlacemark(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddPlacemark());
	}

	public unsafe IPlacemarkMapObject AddPlacemark()
	{
		return Java.Lang.Object.GetObject<IPlacemarkMapObject>(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("addPlacemark.()Lcom/yandex/mapkit/map/PlacemarkMapObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete]
	private static Delegate GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Handler()
	{
		if ((object)cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point__Lcom_yandex_mapkit_map_PlacemarkMapObject_ == null)
		{
			cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point__Lcom_yandex_mapkit_map_PlacemarkMapObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_));
		}
		return cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point__Lcom_yandex_mapkit_map_PlacemarkMapObject_;
	}

	[Obsolete]
	private static nint n_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Point p = Java.Lang.Object.GetObject<Point>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapObjectCollection.AddPlacemark(p));
	}

	public unsafe IPlacemarkMapObject AddPlacemark(Point p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IPlacemarkMapObject>(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("addPlacemark.(Lcom/yandex/mapkit/geometry/Point;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	[Obsolete]
	private static Delegate GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle_Handler()
	{
		if ((object)cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle__Lcom_yandex_mapkit_map_PlacemarkMapObject_ == null)
		{
			cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle__Lcom_yandex_mapkit_map_PlacemarkMapObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle_));
		}
		return cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle__Lcom_yandex_mapkit_map_PlacemarkMapObject_;
	}

	[Obsolete]
	private static nint n_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_AnimatedImageProvider_Lcom_yandex_mapkit_map_IconStyle_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Point p = Java.Lang.Object.GetObject<Point>(native_p0, JniHandleOwnership.DoNotTransfer);
		AnimatedImageProvider p2 = Java.Lang.Object.GetObject<AnimatedImageProvider>(native_p1, JniHandleOwnership.DoNotTransfer);
		IconStyle p3 = Java.Lang.Object.GetObject<IconStyle>(native_p2, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapObjectCollection.AddPlacemark(p, p2, p3));
	}

	public unsafe IPlacemarkMapObject AddPlacemark(Point p0, AnimatedImageProvider p1, IconStyle p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IPlacemarkMapObject>(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("addPlacemark.(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/runtime/image/AnimatedImageProvider;Lcom/yandex/mapkit/map/IconStyle;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}

	[Obsolete]
	private static Delegate GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider_Handler()
	{
		if ((object)cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider__Lcom_yandex_mapkit_map_PlacemarkMapObject_ == null)
		{
			cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider__Lcom_yandex_mapkit_map_PlacemarkMapObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider_));
		}
		return cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider__Lcom_yandex_mapkit_map_PlacemarkMapObject_;
	}

	[Obsolete]
	private static nint n_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Point p = Java.Lang.Object.GetObject<Point>(native_p0, JniHandleOwnership.DoNotTransfer);
		ImageProvider p2 = Java.Lang.Object.GetObject<ImageProvider>(native_p1, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapObjectCollection.AddPlacemark(p, p2));
	}

	public unsafe IPlacemarkMapObject AddPlacemark(Point p0, ImageProvider p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IPlacemarkMapObject>(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("addPlacemark.(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/runtime/image/ImageProvider;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	[Obsolete]
	private static Delegate GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Handler()
	{
		if ((object)cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__Lcom_yandex_mapkit_map_PlacemarkMapObject_ == null)
		{
			cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__Lcom_yandex_mapkit_map_PlacemarkMapObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_));
		}
		return cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__Lcom_yandex_mapkit_map_PlacemarkMapObject_;
	}

	[Obsolete]
	private static nint n_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Point p = Java.Lang.Object.GetObject<Point>(native_p0, JniHandleOwnership.DoNotTransfer);
		ImageProvider p2 = Java.Lang.Object.GetObject<ImageProvider>(native_p1, JniHandleOwnership.DoNotTransfer);
		IconStyle p3 = Java.Lang.Object.GetObject<IconStyle>(native_p2, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapObjectCollection.AddPlacemark(p, p2, p3));
	}

	public unsafe IPlacemarkMapObject AddPlacemark(Point p0, ImageProvider p1, IconStyle p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IPlacemarkMapObject>(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("addPlacemark.(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}

	[Obsolete]
	private static Delegate GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider_Handler()
	{
		if ((object)cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider__Lcom_yandex_mapkit_map_PlacemarkMapObject_ == null)
		{
			cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider__Lcom_yandex_mapkit_map_PlacemarkMapObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider_));
		}
		return cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider__Lcom_yandex_mapkit_map_PlacemarkMapObject_;
	}

	[Obsolete]
	private static nint n_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Point p = Java.Lang.Object.GetObject<Point>(native_p0, JniHandleOwnership.DoNotTransfer);
		ViewProvider p2 = Java.Lang.Object.GetObject<ViewProvider>(native_p1, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapObjectCollection.AddPlacemark(p, p2));
	}

	public unsafe IPlacemarkMapObject AddPlacemark(Point p0, ViewProvider p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IPlacemarkMapObject>(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("addPlacemark.(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/runtime/ui_view/ViewProvider;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	[Obsolete]
	private static Delegate GetAddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Handler()
	{
		if ((object)cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle__Lcom_yandex_mapkit_map_PlacemarkMapObject_ == null)
		{
			cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle__Lcom_yandex_mapkit_map_PlacemarkMapObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_));
		}
		return cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle__Lcom_yandex_mapkit_map_PlacemarkMapObject_;
	}

	[Obsolete]
	private static nint n_AddPlacemark_Lcom_yandex_mapkit_geometry_Point_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Point p = Java.Lang.Object.GetObject<Point>(native_p0, JniHandleOwnership.DoNotTransfer);
		ViewProvider p2 = Java.Lang.Object.GetObject<ViewProvider>(native_p1, JniHandleOwnership.DoNotTransfer);
		IconStyle p3 = Java.Lang.Object.GetObject<IconStyle>(native_p2, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapObjectCollection.AddPlacemark(p, p2, p3));
	}

	public unsafe IPlacemarkMapObject AddPlacemark(Point p0, ViewProvider p1, IconStyle p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IPlacemarkMapObject>(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("addPlacemark.(Lcom/yandex/mapkit/geometry/Point;Lcom/yandex/runtime/ui_view/ViewProvider;Lcom/yandex/mapkit/map/IconStyle;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}

	private static Delegate GetAddPlacemark_Lcom_yandex_mapkit_map_PlacemarkCreatedCallback_Handler()
	{
		if ((object)cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_map_PlacemarkCreatedCallback__Lcom_yandex_mapkit_map_PlacemarkMapObject_ == null)
		{
			cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_map_PlacemarkCreatedCallback__Lcom_yandex_mapkit_map_PlacemarkMapObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddPlacemark_Lcom_yandex_mapkit_map_PlacemarkCreatedCallback_));
		}
		return cb_addPlacemark_AddPlacemark_Lcom_yandex_mapkit_map_PlacemarkCreatedCallback__Lcom_yandex_mapkit_map_PlacemarkMapObject_;
	}

	private static nint n_AddPlacemark_Lcom_yandex_mapkit_map_PlacemarkCreatedCallback_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IPlacemarkCreatedCallback p = Java.Lang.Object.GetObject<IPlacemarkCreatedCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapObjectCollection.AddPlacemark(p));
	}

	public unsafe IPlacemarkMapObject AddPlacemark(IPlacemarkCreatedCallback p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<IPlacemarkMapObject>(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("addPlacemark.(Lcom/yandex/mapkit/map/PlacemarkCreatedCallback;)Lcom/yandex/mapkit/map/PlacemarkMapObject;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	[Obsolete]
	private static Delegate GetAddPlacemarks_Ljava_util_List_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Handler()
	{
		if ((object)cb_addPlacemarks_AddPlacemarks_Ljava_util_List_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__Ljava_util_List_ == null)
		{
			cb_addPlacemarks_AddPlacemarks_Ljava_util_List_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_AddPlacemarks_Ljava_util_List_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_));
		}
		return cb_addPlacemarks_AddPlacemarks_Ljava_util_List_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__Ljava_util_List_;
	}

	[Obsolete]
	private static nint n_AddPlacemarks_Ljava_util_List_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<Point> p = JavaList<Point>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		ImageProvider p2 = Java.Lang.Object.GetObject<ImageProvider>(native_p1, JniHandleOwnership.DoNotTransfer);
		IconStyle p3 = Java.Lang.Object.GetObject<IconStyle>(native_p2, JniHandleOwnership.DoNotTransfer);
		return JavaList<IPlacemarkMapObject>.ToLocalJniHandle(mapObjectCollection.AddPlacemarks(p, p2, p3));
	}

	public unsafe IList<IPlacemarkMapObject> AddPlacemarks(IList<Point> p0, ImageProvider p1, IconStyle p2)
	{
		nint num = JavaList<Point>.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
			return JavaList<IPlacemarkMapObject>.FromJniHandle(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("addPlacemarks.(Ljava/util/List;Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}

	private static Delegate GetAddPolygon_Lcom_yandex_mapkit_geometry_Polygon_Handler()
	{
		if ((object)cb_addPolygon_AddPolygon_Lcom_yandex_mapkit_geometry_Polygon__Lcom_yandex_mapkit_map_PolygonMapObject_ == null)
		{
			cb_addPolygon_AddPolygon_Lcom_yandex_mapkit_geometry_Polygon__Lcom_yandex_mapkit_map_PolygonMapObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddPolygon_Lcom_yandex_mapkit_geometry_Polygon_));
		}
		return cb_addPolygon_AddPolygon_Lcom_yandex_mapkit_geometry_Polygon__Lcom_yandex_mapkit_map_PolygonMapObject_;
	}

	private static nint n_AddPolygon_Lcom_yandex_mapkit_geometry_Polygon_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Polygon p = Java.Lang.Object.GetObject<Polygon>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapObjectCollection.AddPolygon(p));
	}

	public unsafe IPolygonMapObject AddPolygon(Polygon p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IPolygonMapObject>(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("addPolygon.(Lcom/yandex/mapkit/geometry/Polygon;)Lcom/yandex/mapkit/map/PolygonMapObject;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAddPolylineHandler()
	{
		if ((object)cb_addPolyline_AddPolyline_Lcom_yandex_mapkit_map_PolylineMapObject_ == null)
		{
			cb_addPolyline_AddPolyline_Lcom_yandex_mapkit_map_PolylineMapObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AddPolyline));
		}
		return cb_addPolyline_AddPolyline_Lcom_yandex_mapkit_map_PolylineMapObject_;
	}

	private static nint n_AddPolyline(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddPolyline());
	}

	public unsafe IPolylineMapObject AddPolyline()
	{
		return Java.Lang.Object.GetObject<IPolylineMapObject>(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("addPolyline.()Lcom/yandex/mapkit/map/PolylineMapObject;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAddPolyline_Lcom_yandex_mapkit_geometry_Polyline_Handler()
	{
		if ((object)cb_addPolyline_AddPolyline_Lcom_yandex_mapkit_geometry_Polyline__Lcom_yandex_mapkit_map_PolylineMapObject_ == null)
		{
			cb_addPolyline_AddPolyline_Lcom_yandex_mapkit_geometry_Polyline__Lcom_yandex_mapkit_map_PolylineMapObject_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_AddPolyline_Lcom_yandex_mapkit_geometry_Polyline_));
		}
		return cb_addPolyline_AddPolyline_Lcom_yandex_mapkit_geometry_Polyline__Lcom_yandex_mapkit_map_PolylineMapObject_;
	}

	private static nint n_AddPolyline_Lcom_yandex_mapkit_geometry_Polyline_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Polyline p = Java.Lang.Object.GetObject<Polyline>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapObjectCollection.AddPolyline(p));
	}

	public unsafe IPolylineMapObject AddPolyline(Polyline p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IPolylineMapObject>(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("addPolyline.(Lcom/yandex/mapkit/geometry/Polyline;)Lcom/yandex/mapkit/map/PolylineMapObject;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetPlacemarksStylerHandler()
	{
		if ((object)cb_placemarksStyler_PlacemarksStyler_Lcom_yandex_mapkit_map_PlacemarksStyler_ == null)
		{
			cb_placemarksStyler_PlacemarksStyler_Lcom_yandex_mapkit_map_PlacemarksStyler_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_PlacemarksStyler));
		}
		return cb_placemarksStyler_PlacemarksStyler_Lcom_yandex_mapkit_map_PlacemarksStyler_;
	}

	private static nint n_PlacemarksStyler(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PlacemarksStyler());
	}

	public unsafe IPlacemarksStyler PlacemarksStyler()
	{
		return Java.Lang.Object.GetObject<IPlacemarksStyler>(_members_com_yandex_mapkit_map_MapObjectCollection.InstanceMethods.InvokeAbstractObjectMethod("placemarksStyler.()Lcom/yandex/mapkit/map/PlacemarksStyler;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAddListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener_Handler()
	{
		if ((object)cb_addListener_AddListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener__V == null)
		{
			cb_addListener_AddListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener_));
		}
		return cb_addListener_AddListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener__V;
	}

	private static void n_AddListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectCollectionListener p = Java.Lang.Object.GetObject<IMapObjectCollectionListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectCollection.AddListener(p);
	}

	public unsafe void AddListener(IMapObjectCollectionListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_BaseMapObjectCollection.InstanceMethods.InvokeAbstractVoidMethod("addListener.(Lcom/yandex/mapkit/map/MapObjectCollectionListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetClearHandler()
	{
		if ((object)cb_clear_Clear_V == null)
		{
			cb_clear_Clear_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Clear));
		}
		return cb_clear_Clear_V;
	}

	private static void n_Clear(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
	}

	public unsafe void Clear()
	{
		_members_com_yandex_mapkit_map_BaseMapObjectCollection.InstanceMethods.InvokeAbstractVoidMethod("clear.()V", this, null);
	}

	private static Delegate GetRemove_Lcom_yandex_mapkit_map_MapObject_Handler()
	{
		if ((object)cb_remove_Remove_Lcom_yandex_mapkit_map_MapObject__V == null)
		{
			cb_remove_Remove_Lcom_yandex_mapkit_map_MapObject__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Remove_Lcom_yandex_mapkit_map_MapObject_));
		}
		return cb_remove_Remove_Lcom_yandex_mapkit_map_MapObject__V;
	}

	private static void n_Remove_Lcom_yandex_mapkit_map_MapObject_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObject p = Java.Lang.Object.GetObject<IMapObject>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectCollection.Remove(p);
	}

	public unsafe void Remove(IMapObject p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_BaseMapObjectCollection.InstanceMethods.InvokeAbstractVoidMethod("remove.(Lcom/yandex/mapkit/map/MapObject;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetRemoveListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener_Handler()
	{
		if ((object)cb_removeListener_RemoveListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener__V == null)
		{
			cb_removeListener_RemoveListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener_));
		}
		return cb_removeListener_RemoveListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener__V;
	}

	private static void n_RemoveListener_Lcom_yandex_mapkit_map_MapObjectCollectionListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectCollectionListener p = Java.Lang.Object.GetObject<IMapObjectCollectionListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectCollection.RemoveListener(p);
	}

	public unsafe void RemoveListener(IMapObjectCollectionListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_BaseMapObjectCollection.InstanceMethods.InvokeAbstractVoidMethod("removeListener.(Lcom/yandex/mapkit/map/MapObjectCollectionListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetTraverse_Lcom_yandex_mapkit_map_MapObjectVisitor_Handler()
	{
		if ((object)cb_traverse_Traverse_Lcom_yandex_mapkit_map_MapObjectVisitor__V == null)
		{
			cb_traverse_Traverse_Lcom_yandex_mapkit_map_MapObjectVisitor__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Traverse_Lcom_yandex_mapkit_map_MapObjectVisitor_));
		}
		return cb_traverse_Traverse_Lcom_yandex_mapkit_map_MapObjectVisitor__V;
	}

	private static void n_Traverse_Lcom_yandex_mapkit_map_MapObjectVisitor_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectVisitor p = Java.Lang.Object.GetObject<IMapObjectVisitor>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectCollection.Traverse(p);
	}

	public unsafe void Traverse(IMapObjectVisitor p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_BaseMapObjectCollection.InstanceMethods.InvokeAbstractVoidMethod("traverse.(Lcom/yandex/mapkit/map/MapObjectVisitor;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetIsDraggableHandler()
	{
		if ((object)cb_isDraggable_IsDraggable_Z == null)
		{
			cb_isDraggable_IsDraggable_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsDraggable));
		}
		return cb_isDraggable_IsDraggable_Z;
	}

	private static bool n_IsDraggable(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Draggable;
	}

	private static Delegate GetSetDraggable_ZHandler()
	{
		if ((object)cb_setDraggable_SetDraggable_Z_V == null)
		{
			cb_setDraggable_SetDraggable_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetDraggable_Z));
		}
		return cb_setDraggable_SetDraggable_Z_V;
	}

	private static void n_SetDraggable_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Draggable = p0;
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
		return Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetGetParentHandler()
	{
		if ((object)cb_getParent_GetParent_Lcom_yandex_mapkit_map_BaseMapObjectCollection_ == null)
		{
			cb_getParent_GetParent_Lcom_yandex_mapkit_map_BaseMapObjectCollection_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetParent));
		}
		return cb_getParent_GetParent_Lcom_yandex_mapkit_map_BaseMapObjectCollection_;
	}

	private static nint n_GetParent(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Parent);
	}

	private static Delegate GetGetUserDataHandler()
	{
		if ((object)cb_getUserData_GetUserData_Ljava_lang_Object_ == null)
		{
			cb_getUserData_GetUserData_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetUserData));
		}
		return cb_getUserData_GetUserData_Ljava_lang_Object_;
	}

	private static nint n_GetUserData(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UserData);
	}

	private static Delegate GetSetUserData_Ljava_lang_Object_Handler()
	{
		if ((object)cb_setUserData_SetUserData_Ljava_lang_Object__V == null)
		{
			cb_setUserData_SetUserData_Ljava_lang_Object__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetUserData_Ljava_lang_Object_));
		}
		return cb_setUserData_SetUserData_Ljava_lang_Object__V;
	}

	private static void n_SetUserData_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object userData = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectCollection.UserData = userData;
	}

	private static Delegate GetIsVisibleHandler()
	{
		if ((object)cb_isVisible_IsVisible_Z == null)
		{
			cb_isVisible_IsVisible_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsVisible));
		}
		return cb_isVisible_IsVisible_Z;
	}

	private static bool n_IsVisible(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visible;
	}

	private static Delegate GetSetVisible_ZHandler()
	{
		if ((object)cb_setVisible_SetVisible_Z_V == null)
		{
			cb_setVisible_SetVisible_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetVisible_Z));
		}
		return cb_setVisible_SetVisible_Z_V;
	}

	private static void n_SetVisible_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visible = p0;
	}

	private static Delegate GetGetZIndexHandler()
	{
		if ((object)cb_getZIndex_GetZIndex_F == null)
		{
			cb_getZIndex_GetZIndex_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetZIndex));
		}
		return cb_getZIndex_GetZIndex_F;
	}

	private static float n_GetZIndex(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZIndex;
	}

	private static Delegate GetSetZIndex_FHandler()
	{
		if ((object)cb_setZIndex_SetZIndex_F_V == null)
		{
			cb_setZIndex_SetZIndex_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetZIndex_F));
		}
		return cb_setZIndex_SetZIndex_F_V;
	}

	private static void n_SetZIndex_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZIndex = p0;
	}

	private static Delegate GetAddTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener_Handler()
	{
		if ((object)cb_addTapListener_AddTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener__V == null)
		{
			cb_addTapListener_AddTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener_));
		}
		return cb_addTapListener_AddTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener__V;
	}

	private static void n_AddTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectTapListener p = Java.Lang.Object.GetObject<IMapObjectTapListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectCollection.AddTapListener(p);
	}

	public unsafe void AddTapListener(IMapObjectTapListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractVoidMethod("addTapListener.(Lcom/yandex/mapkit/map/MapObjectTapListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetRemoveTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener_Handler()
	{
		if ((object)cb_removeTapListener_RemoveTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener__V == null)
		{
			cb_removeTapListener_RemoveTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener_));
		}
		return cb_removeTapListener_RemoveTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener__V;
	}

	private static void n_RemoveTapListener_Lcom_yandex_mapkit_map_MapObjectTapListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectTapListener p = Java.Lang.Object.GetObject<IMapObjectTapListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectCollection.RemoveTapListener(p);
	}

	public unsafe void RemoveTapListener(IMapObjectTapListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractVoidMethod("removeTapListener.(Lcom/yandex/mapkit/map/MapObjectTapListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetDragListener_Lcom_yandex_mapkit_map_MapObjectDragListener_Handler()
	{
		if ((object)cb_setDragListener_SetDragListener_Lcom_yandex_mapkit_map_MapObjectDragListener__V == null)
		{
			cb_setDragListener_SetDragListener_Lcom_yandex_mapkit_map_MapObjectDragListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetDragListener_Lcom_yandex_mapkit_map_MapObjectDragListener_));
		}
		return cb_setDragListener_SetDragListener_Lcom_yandex_mapkit_map_MapObjectDragListener__V;
	}

	private static void n_SetDragListener_Lcom_yandex_mapkit_map_MapObjectDragListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectDragListener dragListener = Java.Lang.Object.GetObject<IMapObjectDragListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapObjectCollection.SetDragListener(dragListener);
	}

	public unsafe void SetDragListener(IMapObjectDragListener? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractVoidMethod("setDragListener.(Lcom/yandex/mapkit/map/MapObjectDragListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetVisible_ZLcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Callback_Handler()
	{
		if ((object)cb_setVisible_SetVisible_ZLcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Callback__V == null)
		{
			cb_setVisible_SetVisible_ZLcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Callback__V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZLL_V(n_SetVisible_ZLcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Callback_));
		}
		return cb_setVisible_SetVisible_ZLcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Callback__V;
	}

	private static void n_SetVisible_ZLcom_yandex_mapkit_Animation_Lcom_yandex_mapkit_map_Callback_(nint jnienv, nint native__this, bool p0, nint native_p1, nint native_p2)
	{
		IMapObjectCollection? mapObjectCollection = Java.Lang.Object.GetObject<IMapObjectCollection>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Animation p1 = Java.Lang.Object.GetObject<Animation>(native_p1, JniHandleOwnership.DoNotTransfer);
		ICallback p2 = Java.Lang.Object.GetObject<ICallback>(native_p2, JniHandleOwnership.DoNotTransfer);
		mapObjectCollection.SetVisible(p0, p1, p2);
	}

	public unsafe void SetVisible(bool p0, Animation p1, ICallback? p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			_members_com_yandex_mapkit_map_MapObject.InstanceMethods.InvokeAbstractVoidMethod("setVisible.(ZLcom/yandex/mapkit/Animation;Lcom/yandex/mapkit/map/Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}
}
