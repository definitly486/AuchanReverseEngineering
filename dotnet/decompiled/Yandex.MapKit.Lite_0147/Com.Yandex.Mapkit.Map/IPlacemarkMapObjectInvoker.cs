using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Graphics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Runtime.Image;
using Com.Yandex.Runtime.Ui_view;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/PlacemarkMapObject", DoNotGenerateAcw = true)]
internal class IPlacemarkMapObjectInvoker : Java.Lang.Object, IPlacemarkMapObject, IMapObject, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_MapObject = new XAPeerMembers("com/yandex/mapkit/map/MapObject", typeof(IPlacemarkMapObjectInvoker));

	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_PlacemarkMapObject = new XAPeerMembers("com/yandex/mapkit/map/PlacemarkMapObject", typeof(IPlacemarkMapObjectInvoker));

	private static Delegate? cb_getDirection_GetDirection_F;

	private static Delegate? cb_setDirection_SetDirection_F_V;

	private static Delegate? cb_getGeometry_GetGeometry_Lcom_yandex_mapkit_geometry_Point_;

	private static Delegate? cb_setGeometry_SetGeometry_Lcom_yandex_mapkit_geometry_Point__V;

	private static Delegate? cb_getOpacity_GetOpacity_F;

	private static Delegate? cb_setOpacity_SetOpacity_F_V;

	private static Delegate? cb_getText_GetText_Lcom_yandex_mapkit_map_PlacemarkText_;

	private static Delegate? cb_setIcon_SetIcon_Lcom_yandex_runtime_image_ImageProvider__V;

	private static Delegate? cb_setIcon_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_Callback__V;

	private static Delegate? cb_setIcon_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__V;

	private static Delegate? cb_setIcon_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V;

	private static Delegate? cb_setIconStyle_SetIconStyle_Lcom_yandex_mapkit_map_IconStyle__V;

	private static Delegate? cb_setScaleFunction_SetScaleFunction_Ljava_util_List__V;

	private static Delegate? cb_setText_SetText_Ljava_lang_String__V;

	private static Delegate? cb_setText_SetText_Ljava_lang_String_Lcom_yandex_mapkit_map_TextStyle__V;

	private static Delegate? cb_setTextStyle_SetTextStyle_Lcom_yandex_mapkit_map_TextStyle__V;

	private static Delegate? cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider__V;

	private static Delegate? cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_Callback__V;

	private static Delegate? cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle__V;

	private static Delegate? cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V;

	private static Delegate? cb_useAnimation_UseAnimation_Lcom_yandex_mapkit_map_PlacemarkAnimation_;

	private static Delegate? cb_useCompositeIcon_UseCompositeIcon_Lcom_yandex_mapkit_map_CompositeIcon_;

	private static Delegate? cb_useIcon_UseIcon_Lcom_yandex_mapkit_map_Icon_;

	private static Delegate? cb_useModel_UseModel_Lcom_yandex_mapkit_map_Model_;

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

	private static nint java_class_ref => _members_com_yandex_mapkit_map_PlacemarkMapObject.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_PlacemarkMapObject;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_PlacemarkMapObject.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_PlacemarkMapObject.ManagedPeerType;

	public unsafe float Direction
	{
		get
		{
			return _members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractSingleMethod("getDirection.()F", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractVoidMethod("setDirection.(F)V", this, ptr);
		}
	}

	public unsafe Com.Yandex.Mapkit.Geometry.Point Geometry
	{
		get
		{
			return Java.Lang.Object.GetObject<Com.Yandex.Mapkit.Geometry.Point>(_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractObjectMethod("getGeometry.()Lcom/yandex/mapkit/geometry/Point;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractVoidMethod("setGeometry.(Lcom/yandex/mapkit/geometry/Point;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe float Opacity
	{
		get
		{
			return _members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractSingleMethod("getOpacity.()F", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractVoidMethod("setOpacity.(F)V", this, ptr);
		}
	}

	public unsafe IPlacemarkText Text => Java.Lang.Object.GetObject<IPlacemarkText>(_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractObjectMethod("getText.()Lcom/yandex/mapkit/map/PlacemarkText;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

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

	public IPlacemarkMapObjectInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetDirectionHandler()
	{
		if ((object)cb_getDirection_GetDirection_F == null)
		{
			cb_getDirection_GetDirection_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetDirection));
		}
		return cb_getDirection_GetDirection_F;
	}

	private static float n_GetDirection(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Direction;
	}

	private static Delegate GetSetDirection_FHandler()
	{
		if ((object)cb_setDirection_SetDirection_F_V == null)
		{
			cb_setDirection_SetDirection_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetDirection_F));
		}
		return cb_setDirection_SetDirection_F_V;
	}

	private static void n_SetDirection_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Direction = p0;
	}

	private static Delegate GetGetGeometryHandler()
	{
		if ((object)cb_getGeometry_GetGeometry_Lcom_yandex_mapkit_geometry_Point_ == null)
		{
			cb_getGeometry_GetGeometry_Lcom_yandex_mapkit_geometry_Point_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetGeometry));
		}
		return cb_getGeometry_GetGeometry_Lcom_yandex_mapkit_geometry_Point_;
	}

	private static nint n_GetGeometry(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Geometry);
	}

	private static Delegate GetSetGeometry_Lcom_yandex_mapkit_geometry_Point_Handler()
	{
		if ((object)cb_setGeometry_SetGeometry_Lcom_yandex_mapkit_geometry_Point__V == null)
		{
			cb_setGeometry_SetGeometry_Lcom_yandex_mapkit_geometry_Point__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetGeometry_Lcom_yandex_mapkit_geometry_Point_));
		}
		return cb_setGeometry_SetGeometry_Lcom_yandex_mapkit_geometry_Point__V;
	}

	private static void n_SetGeometry_Lcom_yandex_mapkit_geometry_Point_(nint jnienv, nint native__this, nint native_p0)
	{
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Com.Yandex.Mapkit.Geometry.Point geometry = Java.Lang.Object.GetObject<Com.Yandex.Mapkit.Geometry.Point>(native_p0, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.Geometry = geometry;
	}

	private static Delegate GetGetOpacityHandler()
	{
		if ((object)cb_getOpacity_GetOpacity_F == null)
		{
			cb_getOpacity_GetOpacity_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetOpacity));
		}
		return cb_getOpacity_GetOpacity_F;
	}

	private static float n_GetOpacity(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Opacity;
	}

	private static Delegate GetSetOpacity_FHandler()
	{
		if ((object)cb_setOpacity_SetOpacity_F_V == null)
		{
			cb_setOpacity_SetOpacity_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetOpacity_F));
		}
		return cb_setOpacity_SetOpacity_F_V;
	}

	private static void n_SetOpacity_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Opacity = p0;
	}

	private static Delegate GetGetTextHandler()
	{
		if ((object)cb_getText_GetText_Lcom_yandex_mapkit_map_PlacemarkText_ == null)
		{
			cb_getText_GetText_Lcom_yandex_mapkit_map_PlacemarkText_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetText));
		}
		return cb_getText_GetText_Lcom_yandex_mapkit_map_PlacemarkText_;
	}

	private static nint n_GetText(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Text);
	}

	private static Delegate GetSetIcon_Lcom_yandex_runtime_image_ImageProvider_Handler()
	{
		if ((object)cb_setIcon_SetIcon_Lcom_yandex_runtime_image_ImageProvider__V == null)
		{
			cb_setIcon_SetIcon_Lcom_yandex_runtime_image_ImageProvider__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetIcon_Lcom_yandex_runtime_image_ImageProvider_));
		}
		return cb_setIcon_SetIcon_Lcom_yandex_runtime_image_ImageProvider__V;
	}

	private static void n_SetIcon_Lcom_yandex_runtime_image_ImageProvider_(nint jnienv, nint native__this, nint native_p0)
	{
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ImageProvider icon = Java.Lang.Object.GetObject<ImageProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.SetIcon(icon);
	}

	public unsafe void SetIcon(ImageProvider p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractVoidMethod("setIcon.(Lcom/yandex/runtime/image/ImageProvider;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_Callback_Handler()
	{
		if ((object)cb_setIcon_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_Callback__V == null)
		{
			cb_setIcon_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_Callback__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_Callback_));
		}
		return cb_setIcon_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_Callback__V;
	}

	private static void n_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_Callback_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ImageProvider p = Java.Lang.Object.GetObject<ImageProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		ICallback p2 = Java.Lang.Object.GetObject<ICallback>(native_p1, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.SetIcon(p, p2);
	}

	public unsafe void SetIcon(ImageProvider p0, ICallback p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractVoidMethod("setIcon.(Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetSetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Handler()
	{
		if ((object)cb_setIcon_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__V == null)
		{
			cb_setIcon_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_));
		}
		return cb_setIcon_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle__V;
	}

	private static void n_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ImageProvider p = Java.Lang.Object.GetObject<ImageProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		IconStyle p2 = Java.Lang.Object.GetObject<IconStyle>(native_p1, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.SetIcon(p, p2);
	}

	public unsafe void SetIcon(ImageProvider p0, IconStyle p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractVoidMethod("setIcon.(Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetSetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_Handler()
	{
		if ((object)cb_setIcon_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V == null)
		{
			cb_setIcon_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_));
		}
		return cb_setIcon_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V;
	}

	private static void n_SetIcon_Lcom_yandex_runtime_image_ImageProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
	{
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ImageProvider p = Java.Lang.Object.GetObject<ImageProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		IconStyle p2 = Java.Lang.Object.GetObject<IconStyle>(native_p1, JniHandleOwnership.DoNotTransfer);
		ICallback p3 = Java.Lang.Object.GetObject<ICallback>(native_p2, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.SetIcon(p, p2, p3);
	}

	public unsafe void SetIcon(ImageProvider p0, IconStyle p1, ICallback p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractVoidMethod("setIcon.(Lcom/yandex/runtime/image/ImageProvider;Lcom/yandex/mapkit/map/IconStyle;Lcom/yandex/mapkit/map/Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}

	private static Delegate GetSetIconStyle_Lcom_yandex_mapkit_map_IconStyle_Handler()
	{
		if ((object)cb_setIconStyle_SetIconStyle_Lcom_yandex_mapkit_map_IconStyle__V == null)
		{
			cb_setIconStyle_SetIconStyle_Lcom_yandex_mapkit_map_IconStyle__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetIconStyle_Lcom_yandex_mapkit_map_IconStyle_));
		}
		return cb_setIconStyle_SetIconStyle_Lcom_yandex_mapkit_map_IconStyle__V;
	}

	private static void n_SetIconStyle_Lcom_yandex_mapkit_map_IconStyle_(nint jnienv, nint native__this, nint native_p0)
	{
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IconStyle iconStyle = Java.Lang.Object.GetObject<IconStyle>(native_p0, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.SetIconStyle(iconStyle);
	}

	public unsafe void SetIconStyle(IconStyle p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractVoidMethod("setIconStyle.(Lcom/yandex/mapkit/map/IconStyle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetScaleFunction_Ljava_util_List_Handler()
	{
		if ((object)cb_setScaleFunction_SetScaleFunction_Ljava_util_List__V == null)
		{
			cb_setScaleFunction_SetScaleFunction_Ljava_util_List__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetScaleFunction_Ljava_util_List_));
		}
		return cb_setScaleFunction_SetScaleFunction_Ljava_util_List__V;
	}

	private static void n_SetScaleFunction_Ljava_util_List_(nint jnienv, nint native__this, nint native_p0)
	{
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<PointF> scaleFunction = JavaList<PointF>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.SetScaleFunction(scaleFunction);
	}

	public unsafe void SetScaleFunction(IList<PointF> p0)
	{
		nint num = JavaList<PointF>.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractVoidMethod("setScaleFunction.(Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetText_Ljava_lang_String_Handler()
	{
		if ((object)cb_setText_SetText_Ljava_lang_String__V == null)
		{
			cb_setText_SetText_Ljava_lang_String__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetText_Ljava_lang_String_));
		}
		return cb_setText_SetText_Ljava_lang_String__V;
	}

	private static void n_SetText_Ljava_lang_String_(nint jnienv, nint native__this, nint native_p0)
	{
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string text = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.SetText(text);
	}

	public unsafe void SetText(string p0)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractVoidMethod("setText.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	private static Delegate GetSetText_Ljava_lang_String_Lcom_yandex_mapkit_map_TextStyle_Handler()
	{
		if ((object)cb_setText_SetText_Ljava_lang_String_Lcom_yandex_mapkit_map_TextStyle__V == null)
		{
			cb_setText_SetText_Ljava_lang_String_Lcom_yandex_mapkit_map_TextStyle__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetText_Ljava_lang_String_Lcom_yandex_mapkit_map_TextStyle_));
		}
		return cb_setText_SetText_Ljava_lang_String_Lcom_yandex_mapkit_map_TextStyle__V;
	}

	private static void n_SetText_Ljava_lang_String_Lcom_yandex_mapkit_map_TextStyle_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
		TextStyle p2 = Java.Lang.Object.GetObject<TextStyle>(native_p1, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.SetText(p, p2);
	}

	public unsafe void SetText(string p0, TextStyle p1)
	{
		nint num = JNIEnv.NewString(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractVoidMethod("setText.(Ljava/lang/String;Lcom/yandex/mapkit/map/TextStyle;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetSetTextStyle_Lcom_yandex_mapkit_map_TextStyle_Handler()
	{
		if ((object)cb_setTextStyle_SetTextStyle_Lcom_yandex_mapkit_map_TextStyle__V == null)
		{
			cb_setTextStyle_SetTextStyle_Lcom_yandex_mapkit_map_TextStyle__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetTextStyle_Lcom_yandex_mapkit_map_TextStyle_));
		}
		return cb_setTextStyle_SetTextStyle_Lcom_yandex_mapkit_map_TextStyle__V;
	}

	private static void n_SetTextStyle_Lcom_yandex_mapkit_map_TextStyle_(nint jnienv, nint native__this, nint native_p0)
	{
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		TextStyle textStyle = Java.Lang.Object.GetObject<TextStyle>(native_p0, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.SetTextStyle(textStyle);
	}

	public unsafe void SetTextStyle(TextStyle p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractVoidMethod("setTextStyle.(Lcom/yandex/mapkit/map/TextStyle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetView_Lcom_yandex_runtime_ui_view_ViewProvider_Handler()
	{
		if ((object)cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider__V == null)
		{
			cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_));
		}
		return cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider__V;
	}

	private static void n_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_(nint jnienv, nint native__this, nint native_p0)
	{
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ViewProvider view = Java.Lang.Object.GetObject<ViewProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.SetView(view);
	}

	public unsafe void SetView(ViewProvider p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractVoidMethod("setView.(Lcom/yandex/runtime/ui_view/ViewProvider;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_Callback_Handler()
	{
		if ((object)cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_Callback__V == null)
		{
			cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_Callback__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_Callback_));
		}
		return cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_Callback__V;
	}

	private static void n_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_Callback_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ViewProvider p = Java.Lang.Object.GetObject<ViewProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		ICallback p2 = Java.Lang.Object.GetObject<ICallback>(native_p1, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.SetView(p, p2);
	}

	public unsafe void SetView(ViewProvider p0, ICallback p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractVoidMethod("setView.(Lcom/yandex/runtime/ui_view/ViewProvider;Lcom/yandex/mapkit/map/Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetSetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Handler()
	{
		if ((object)cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle__V == null)
		{
			cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_));
		}
		return cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle__V;
	}

	private static void n_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ViewProvider p = Java.Lang.Object.GetObject<ViewProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		IconStyle p2 = Java.Lang.Object.GetObject<IconStyle>(native_p1, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.SetView(p, p2);
	}

	public unsafe void SetView(ViewProvider p0, IconStyle p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractVoidMethod("setView.(Lcom/yandex/runtime/ui_view/ViewProvider;Lcom/yandex/mapkit/map/IconStyle;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetSetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_Handler()
	{
		if ((object)cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V == null)
		{
			cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_));
		}
		return cb_setView_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback__V;
	}

	private static void n_SetView_Lcom_yandex_runtime_ui_view_ViewProvider_Lcom_yandex_mapkit_map_IconStyle_Lcom_yandex_mapkit_map_Callback_(nint jnienv, nint native__this, nint native_p0, nint native_p1, nint native_p2)
	{
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ViewProvider p = Java.Lang.Object.GetObject<ViewProvider>(native_p0, JniHandleOwnership.DoNotTransfer);
		IconStyle p2 = Java.Lang.Object.GetObject<IconStyle>(native_p1, JniHandleOwnership.DoNotTransfer);
		ICallback p3 = Java.Lang.Object.GetObject<ICallback>(native_p2, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.SetView(p, p2, p3);
	}

	public unsafe void SetView(ViewProvider p0, IconStyle p1, ICallback p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
			_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractVoidMethod("setView.(Lcom/yandex/runtime/ui_view/ViewProvider;Lcom/yandex/mapkit/map/IconStyle;Lcom/yandex/mapkit/map/Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			GC.KeepAlive(p2);
		}
	}

	private static Delegate GetUseAnimationHandler()
	{
		if ((object)cb_useAnimation_UseAnimation_Lcom_yandex_mapkit_map_PlacemarkAnimation_ == null)
		{
			cb_useAnimation_UseAnimation_Lcom_yandex_mapkit_map_PlacemarkAnimation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_UseAnimation));
		}
		return cb_useAnimation_UseAnimation_Lcom_yandex_mapkit_map_PlacemarkAnimation_;
	}

	private static nint n_UseAnimation(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseAnimation());
	}

	public unsafe IPlacemarkAnimation UseAnimation()
	{
		return Java.Lang.Object.GetObject<IPlacemarkAnimation>(_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractObjectMethod("useAnimation.()Lcom/yandex/mapkit/map/PlacemarkAnimation;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetUseCompositeIconHandler()
	{
		if ((object)cb_useCompositeIcon_UseCompositeIcon_Lcom_yandex_mapkit_map_CompositeIcon_ == null)
		{
			cb_useCompositeIcon_UseCompositeIcon_Lcom_yandex_mapkit_map_CompositeIcon_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_UseCompositeIcon));
		}
		return cb_useCompositeIcon_UseCompositeIcon_Lcom_yandex_mapkit_map_CompositeIcon_;
	}

	private static nint n_UseCompositeIcon(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseCompositeIcon());
	}

	public unsafe ICompositeIcon UseCompositeIcon()
	{
		return Java.Lang.Object.GetObject<ICompositeIcon>(_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractObjectMethod("useCompositeIcon.()Lcom/yandex/mapkit/map/CompositeIcon;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetUseIconHandler()
	{
		if ((object)cb_useIcon_UseIcon_Lcom_yandex_mapkit_map_Icon_ == null)
		{
			cb_useIcon_UseIcon_Lcom_yandex_mapkit_map_Icon_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_UseIcon));
		}
		return cb_useIcon_UseIcon_Lcom_yandex_mapkit_map_Icon_;
	}

	private static nint n_UseIcon(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseIcon());
	}

	public unsafe IIcon UseIcon()
	{
		return Java.Lang.Object.GetObject<IIcon>(_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractObjectMethod("useIcon.()Lcom/yandex/mapkit/map/Icon;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetUseModelHandler()
	{
		if ((object)cb_useModel_UseModel_Lcom_yandex_mapkit_map_Model_ == null)
		{
			cb_useModel_UseModel_Lcom_yandex_mapkit_map_Model_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_UseModel));
		}
		return cb_useModel_UseModel_Lcom_yandex_mapkit_map_Model_;
	}

	private static nint n_UseModel(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseModel());
	}

	public unsafe IModel UseModel()
	{
		return Java.Lang.Object.GetObject<IModel>(_members_com_yandex_mapkit_map_PlacemarkMapObject.InstanceMethods.InvokeAbstractObjectMethod("useModel.()Lcom/yandex/mapkit/map/Model;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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
		return Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Draggable;
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
		Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Draggable = p0;
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
		return Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Parent);
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UserData);
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
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object userData = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.UserData = userData;
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
		return Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visible;
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
		Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visible = p0;
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
		return Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZIndex;
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
		Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZIndex = p0;
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
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectTapListener p = Java.Lang.Object.GetObject<IMapObjectTapListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.AddTapListener(p);
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
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectTapListener p = Java.Lang.Object.GetObject<IMapObjectTapListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.RemoveTapListener(p);
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
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectDragListener dragListener = Java.Lang.Object.GetObject<IMapObjectDragListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.SetDragListener(dragListener);
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
		IPlacemarkMapObject? placemarkMapObject = Java.Lang.Object.GetObject<IPlacemarkMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Animation p1 = Java.Lang.Object.GetObject<Animation>(native_p1, JniHandleOwnership.DoNotTransfer);
		ICallback p2 = Java.Lang.Object.GetObject<ICallback>(native_p2, JniHandleOwnership.DoNotTransfer);
		placemarkMapObject.SetVisible(p0, p1, p2);
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
