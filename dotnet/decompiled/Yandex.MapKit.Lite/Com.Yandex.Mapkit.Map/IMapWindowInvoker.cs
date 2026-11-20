using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Com.Yandex.Mapkit.UI;
using Com.Yandex.Runtime.View;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/MapWindow", DoNotGenerateAcw = true)]
internal class IMapWindowInvoker : Java.Lang.Object, IMapWindow, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_MapWindow = new XAPeerMembers("com/yandex/mapkit/map/MapWindow", typeof(IMapWindowInvoker));

	private static Delegate? cb_getFocusPoint_GetFocusPoint_Lcom_yandex_mapkit_ScreenPoint_;

	private static Delegate? cb_setFocusPoint_SetFocusPoint_Lcom_yandex_mapkit_ScreenPoint__V;

	private static Delegate? cb_getFocusRect_GetFocusRect_Lcom_yandex_mapkit_ScreenRect_;

	private static Delegate? cb_setFocusRect_SetFocusRect_Lcom_yandex_mapkit_ScreenRect__V;

	private static Delegate? cb_getFocusRegion_GetFocusRegion_Lcom_yandex_mapkit_map_VisibleRegion_;

	private static Delegate? cb_getGestureFocusPoint_GetGestureFocusPoint_Lcom_yandex_mapkit_ScreenPoint_;

	private static Delegate? cb_setGestureFocusPoint_SetGestureFocusPoint_Lcom_yandex_mapkit_ScreenPoint__V;

	private static Delegate? cb_getGestureFocusPointMode_GetGestureFocusPointMode_Lcom_yandex_mapkit_map_GestureFocusPointMode_;

	private static Delegate? cb_setGestureFocusPointMode_SetGestureFocusPointMode_Lcom_yandex_mapkit_map_GestureFocusPointMode__V;

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_getMap_GetMap_Lcom_yandex_mapkit_map_Map_;

	private static Delegate? cb_getPointOfView_GetPointOfView_Lcom_yandex_mapkit_map_PointOfView_;

	private static Delegate? cb_setPointOfView_SetPointOfView_Lcom_yandex_mapkit_map_PointOfView__V;

	private static Delegate? cb_getScaleFactor_GetScaleFactor_F;

	private static Delegate? cb_setScaleFactor_SetScaleFactor_F_V;

	private static Delegate? cb_addRasterScreenOverlay_AddRasterScreenOverlay_Lcom_yandex_mapkit_ui_Overlay_;

	private static Delegate? cb_addSizeChangedListener_AddSizeChangedListener_Lcom_yandex_mapkit_map_SizeChangedListener__V;

	private static Delegate? cb_addSurface_AddSurface_Lcom_yandex_runtime_view_Surface__V;

	private static Delegate? cb_height_Height_I;

	private static Delegate? cb_removeSizeChangedListener_RemoveSizeChangedListener_Lcom_yandex_mapkit_map_SizeChangedListener__V;

	private static Delegate? cb_removeSurface_RemoveSurface_Lcom_yandex_runtime_view_Surface__V;

	private static Delegate? cb_screenToWorld_ScreenToWorld_Lcom_yandex_mapkit_ScreenPoint__Lcom_yandex_mapkit_geometry_Point_;

	private static Delegate? cb_setMaxFps_SetMaxFps_F_V;

	private static Delegate? cb_startMemoryMetricsCapture_StartMemoryMetricsCapture_V;

	private static Delegate? cb_startPerformanceMetricsCapture_StartPerformanceMetricsCapture_V;

	private static Delegate? cb_stopMemoryMetricsCapture_StopMemoryMetricsCapture_Ljava_lang_String_;

	private static Delegate? cb_stopPerformanceMetricsCapture_StopPerformanceMetricsCapture_Ljava_lang_String_;

	private static Delegate? cb_width_Width_I;

	private static Delegate? cb_worldToScreen_WorldToScreen_Lcom_yandex_mapkit_geometry_Point__Lcom_yandex_mapkit_ScreenPoint_;

	private static nint java_class_ref => _members_com_yandex_mapkit_map_MapWindow.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_MapWindow;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_MapWindow.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_MapWindow.ManagedPeerType;

	public unsafe ScreenPoint? FocusPoint
	{
		get
		{
			return Java.Lang.Object.GetObject<ScreenPoint>(_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractObjectMethod("getFocusPoint.()Lcom/yandex/mapkit/ScreenPoint;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractVoidMethod("setFocusPoint.(Lcom/yandex/mapkit/ScreenPoint;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe ScreenRect? FocusRect
	{
		get
		{
			return Java.Lang.Object.GetObject<ScreenRect>(_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractObjectMethod("getFocusRect.()Lcom/yandex/mapkit/ScreenRect;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractVoidMethod("setFocusRect.(Lcom/yandex/mapkit/ScreenRect;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe VisibleRegion FocusRegion => Java.Lang.Object.GetObject<VisibleRegion>(_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractObjectMethod("getFocusRegion.()Lcom/yandex/mapkit/map/VisibleRegion;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe ScreenPoint? GestureFocusPoint
	{
		get
		{
			return Java.Lang.Object.GetObject<ScreenPoint>(_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractObjectMethod("getGestureFocusPoint.()Lcom/yandex/mapkit/ScreenPoint;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractVoidMethod("setGestureFocusPoint.(Lcom/yandex/mapkit/ScreenPoint;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe GestureFocusPointMode GestureFocusPointMode
	{
		get
		{
			return Java.Lang.Object.GetObject<GestureFocusPointMode>(_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractObjectMethod("getGestureFocusPointMode.()Lcom/yandex/mapkit/map/GestureFocusPointMode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractVoidMethod("setGestureFocusPointMode.(Lcom/yandex/mapkit/map/GestureFocusPointMode;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe bool IsValid => _members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public unsafe IMap Map => Java.Lang.Object.GetObject<IMap>(_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractObjectMethod("getMap.()Lcom/yandex/mapkit/map/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe PointOfView PointOfView
	{
		get
		{
			return Java.Lang.Object.GetObject<PointOfView>(_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractObjectMethod("getPointOfView.()Lcom/yandex/mapkit/map/PointOfView;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractVoidMethod("setPointOfView.(Lcom/yandex/mapkit/map/PointOfView;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe float ScaleFactor
	{
		get
		{
			return _members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractSingleMethod("getScaleFactor.()F", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractVoidMethod("setScaleFactor.(F)V", this, ptr);
		}
	}

	public IMapWindowInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetFocusPointHandler()
	{
		if ((object)cb_getFocusPoint_GetFocusPoint_Lcom_yandex_mapkit_ScreenPoint_ == null)
		{
			cb_getFocusPoint_GetFocusPoint_Lcom_yandex_mapkit_ScreenPoint_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFocusPoint));
		}
		return cb_getFocusPoint_GetFocusPoint_Lcom_yandex_mapkit_ScreenPoint_;
	}

	private static nint n_GetFocusPoint(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FocusPoint);
	}

	private static Delegate GetSetFocusPoint_Lcom_yandex_mapkit_ScreenPoint_Handler()
	{
		if ((object)cb_setFocusPoint_SetFocusPoint_Lcom_yandex_mapkit_ScreenPoint__V == null)
		{
			cb_setFocusPoint_SetFocusPoint_Lcom_yandex_mapkit_ScreenPoint__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetFocusPoint_Lcom_yandex_mapkit_ScreenPoint_));
		}
		return cb_setFocusPoint_SetFocusPoint_Lcom_yandex_mapkit_ScreenPoint__V;
	}

	private static void n_SetFocusPoint_Lcom_yandex_mapkit_ScreenPoint_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapWindow? mapWindow = Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ScreenPoint focusPoint = Java.Lang.Object.GetObject<ScreenPoint>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapWindow.FocusPoint = focusPoint;
	}

	private static Delegate GetGetFocusRectHandler()
	{
		if ((object)cb_getFocusRect_GetFocusRect_Lcom_yandex_mapkit_ScreenRect_ == null)
		{
			cb_getFocusRect_GetFocusRect_Lcom_yandex_mapkit_ScreenRect_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFocusRect));
		}
		return cb_getFocusRect_GetFocusRect_Lcom_yandex_mapkit_ScreenRect_;
	}

	private static nint n_GetFocusRect(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FocusRect);
	}

	private static Delegate GetSetFocusRect_Lcom_yandex_mapkit_ScreenRect_Handler()
	{
		if ((object)cb_setFocusRect_SetFocusRect_Lcom_yandex_mapkit_ScreenRect__V == null)
		{
			cb_setFocusRect_SetFocusRect_Lcom_yandex_mapkit_ScreenRect__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetFocusRect_Lcom_yandex_mapkit_ScreenRect_));
		}
		return cb_setFocusRect_SetFocusRect_Lcom_yandex_mapkit_ScreenRect__V;
	}

	private static void n_SetFocusRect_Lcom_yandex_mapkit_ScreenRect_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapWindow? mapWindow = Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ScreenRect focusRect = Java.Lang.Object.GetObject<ScreenRect>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapWindow.FocusRect = focusRect;
	}

	private static Delegate GetGetFocusRegionHandler()
	{
		if ((object)cb_getFocusRegion_GetFocusRegion_Lcom_yandex_mapkit_map_VisibleRegion_ == null)
		{
			cb_getFocusRegion_GetFocusRegion_Lcom_yandex_mapkit_map_VisibleRegion_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetFocusRegion));
		}
		return cb_getFocusRegion_GetFocusRegion_Lcom_yandex_mapkit_map_VisibleRegion_;
	}

	private static nint n_GetFocusRegion(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FocusRegion);
	}

	private static Delegate GetGetGestureFocusPointHandler()
	{
		if ((object)cb_getGestureFocusPoint_GetGestureFocusPoint_Lcom_yandex_mapkit_ScreenPoint_ == null)
		{
			cb_getGestureFocusPoint_GetGestureFocusPoint_Lcom_yandex_mapkit_ScreenPoint_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetGestureFocusPoint));
		}
		return cb_getGestureFocusPoint_GetGestureFocusPoint_Lcom_yandex_mapkit_ScreenPoint_;
	}

	private static nint n_GetGestureFocusPoint(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GestureFocusPoint);
	}

	private static Delegate GetSetGestureFocusPoint_Lcom_yandex_mapkit_ScreenPoint_Handler()
	{
		if ((object)cb_setGestureFocusPoint_SetGestureFocusPoint_Lcom_yandex_mapkit_ScreenPoint__V == null)
		{
			cb_setGestureFocusPoint_SetGestureFocusPoint_Lcom_yandex_mapkit_ScreenPoint__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetGestureFocusPoint_Lcom_yandex_mapkit_ScreenPoint_));
		}
		return cb_setGestureFocusPoint_SetGestureFocusPoint_Lcom_yandex_mapkit_ScreenPoint__V;
	}

	private static void n_SetGestureFocusPoint_Lcom_yandex_mapkit_ScreenPoint_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapWindow? mapWindow = Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ScreenPoint gestureFocusPoint = Java.Lang.Object.GetObject<ScreenPoint>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapWindow.GestureFocusPoint = gestureFocusPoint;
	}

	private static Delegate GetGetGestureFocusPointModeHandler()
	{
		if ((object)cb_getGestureFocusPointMode_GetGestureFocusPointMode_Lcom_yandex_mapkit_map_GestureFocusPointMode_ == null)
		{
			cb_getGestureFocusPointMode_GetGestureFocusPointMode_Lcom_yandex_mapkit_map_GestureFocusPointMode_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetGestureFocusPointMode));
		}
		return cb_getGestureFocusPointMode_GetGestureFocusPointMode_Lcom_yandex_mapkit_map_GestureFocusPointMode_;
	}

	private static nint n_GetGestureFocusPointMode(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GestureFocusPointMode);
	}

	private static Delegate GetSetGestureFocusPointMode_Lcom_yandex_mapkit_map_GestureFocusPointMode_Handler()
	{
		if ((object)cb_setGestureFocusPointMode_SetGestureFocusPointMode_Lcom_yandex_mapkit_map_GestureFocusPointMode__V == null)
		{
			cb_setGestureFocusPointMode_SetGestureFocusPointMode_Lcom_yandex_mapkit_map_GestureFocusPointMode__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetGestureFocusPointMode_Lcom_yandex_mapkit_map_GestureFocusPointMode_));
		}
		return cb_setGestureFocusPointMode_SetGestureFocusPointMode_Lcom_yandex_mapkit_map_GestureFocusPointMode__V;
	}

	private static void n_SetGestureFocusPointMode_Lcom_yandex_mapkit_map_GestureFocusPointMode_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapWindow? mapWindow = Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		GestureFocusPointMode gestureFocusPointMode = Java.Lang.Object.GetObject<GestureFocusPointMode>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapWindow.GestureFocusPointMode = gestureFocusPointMode;
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
		return Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
	}

	private static Delegate GetGetMapHandler()
	{
		if ((object)cb_getMap_GetMap_Lcom_yandex_mapkit_map_Map_ == null)
		{
			cb_getMap_GetMap_Lcom_yandex_mapkit_map_Map_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMap));
		}
		return cb_getMap_GetMap_Lcom_yandex_mapkit_map_Map_;
	}

	private static nint n_GetMap(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Map);
	}

	private static Delegate GetGetPointOfViewHandler()
	{
		if ((object)cb_getPointOfView_GetPointOfView_Lcom_yandex_mapkit_map_PointOfView_ == null)
		{
			cb_getPointOfView_GetPointOfView_Lcom_yandex_mapkit_map_PointOfView_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetPointOfView));
		}
		return cb_getPointOfView_GetPointOfView_Lcom_yandex_mapkit_map_PointOfView_;
	}

	private static nint n_GetPointOfView(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PointOfView);
	}

	private static Delegate GetSetPointOfView_Lcom_yandex_mapkit_map_PointOfView_Handler()
	{
		if ((object)cb_setPointOfView_SetPointOfView_Lcom_yandex_mapkit_map_PointOfView__V == null)
		{
			cb_setPointOfView_SetPointOfView_Lcom_yandex_mapkit_map_PointOfView__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetPointOfView_Lcom_yandex_mapkit_map_PointOfView_));
		}
		return cb_setPointOfView_SetPointOfView_Lcom_yandex_mapkit_map_PointOfView__V;
	}

	private static void n_SetPointOfView_Lcom_yandex_mapkit_map_PointOfView_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapWindow? mapWindow = Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		PointOfView pointOfView = Java.Lang.Object.GetObject<PointOfView>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapWindow.PointOfView = pointOfView;
	}

	private static Delegate GetGetScaleFactorHandler()
	{
		if ((object)cb_getScaleFactor_GetScaleFactor_F == null)
		{
			cb_getScaleFactor_GetScaleFactor_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetScaleFactor));
		}
		return cb_getScaleFactor_GetScaleFactor_F;
	}

	private static float n_GetScaleFactor(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScaleFactor;
	}

	private static Delegate GetSetScaleFactor_FHandler()
	{
		if ((object)cb_setScaleFactor_SetScaleFactor_F_V == null)
		{
			cb_setScaleFactor_SetScaleFactor_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetScaleFactor_F));
		}
		return cb_setScaleFactor_SetScaleFactor_F_V;
	}

	private static void n_SetScaleFactor_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ScaleFactor = p0;
	}

	private static Delegate GetAddRasterScreenOverlayHandler()
	{
		if ((object)cb_addRasterScreenOverlay_AddRasterScreenOverlay_Lcom_yandex_mapkit_ui_Overlay_ == null)
		{
			cb_addRasterScreenOverlay_AddRasterScreenOverlay_Lcom_yandex_mapkit_ui_Overlay_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AddRasterScreenOverlay));
		}
		return cb_addRasterScreenOverlay_AddRasterScreenOverlay_Lcom_yandex_mapkit_ui_Overlay_;
	}

	private static nint n_AddRasterScreenOverlay(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AddRasterScreenOverlay());
	}

	public unsafe IOverlay AddRasterScreenOverlay()
	{
		return Java.Lang.Object.GetObject<IOverlay>(_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractObjectMethod("addRasterScreenOverlay.()Lcom/yandex/mapkit/ui/Overlay;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAddSizeChangedListener_Lcom_yandex_mapkit_map_SizeChangedListener_Handler()
	{
		if ((object)cb_addSizeChangedListener_AddSizeChangedListener_Lcom_yandex_mapkit_map_SizeChangedListener__V == null)
		{
			cb_addSizeChangedListener_AddSizeChangedListener_Lcom_yandex_mapkit_map_SizeChangedListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddSizeChangedListener_Lcom_yandex_mapkit_map_SizeChangedListener_));
		}
		return cb_addSizeChangedListener_AddSizeChangedListener_Lcom_yandex_mapkit_map_SizeChangedListener__V;
	}

	private static void n_AddSizeChangedListener_Lcom_yandex_mapkit_map_SizeChangedListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapWindow? mapWindow = Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ISizeChangedListener p = Java.Lang.Object.GetObject<ISizeChangedListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapWindow.AddSizeChangedListener(p);
	}

	public unsafe void AddSizeChangedListener(ISizeChangedListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractVoidMethod("addSizeChangedListener.(Lcom/yandex/mapkit/map/SizeChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetAddSurface_Lcom_yandex_runtime_view_Surface_Handler()
	{
		if ((object)cb_addSurface_AddSurface_Lcom_yandex_runtime_view_Surface__V == null)
		{
			cb_addSurface_AddSurface_Lcom_yandex_runtime_view_Surface__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddSurface_Lcom_yandex_runtime_view_Surface_));
		}
		return cb_addSurface_AddSurface_Lcom_yandex_runtime_view_Surface__V;
	}

	private static void n_AddSurface_Lcom_yandex_runtime_view_Surface_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapWindow? mapWindow = Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ISurface p = Java.Lang.Object.GetObject<ISurface>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapWindow.AddSurface(p);
	}

	public unsafe void AddSurface(ISurface p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractVoidMethod("addSurface.(Lcom/yandex/runtime/view/Surface;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetHeightHandler()
	{
		if ((object)cb_height_Height_I == null)
		{
			cb_height_Height_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_Height));
		}
		return cb_height_Height_I;
	}

	private static int n_Height(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height();
	}

	public unsafe int Height()
	{
		return _members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractInt32Method("height.()I", this, null);
	}

	private static Delegate GetRemoveSizeChangedListener_Lcom_yandex_mapkit_map_SizeChangedListener_Handler()
	{
		if ((object)cb_removeSizeChangedListener_RemoveSizeChangedListener_Lcom_yandex_mapkit_map_SizeChangedListener__V == null)
		{
			cb_removeSizeChangedListener_RemoveSizeChangedListener_Lcom_yandex_mapkit_map_SizeChangedListener__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveSizeChangedListener_Lcom_yandex_mapkit_map_SizeChangedListener_));
		}
		return cb_removeSizeChangedListener_RemoveSizeChangedListener_Lcom_yandex_mapkit_map_SizeChangedListener__V;
	}

	private static void n_RemoveSizeChangedListener_Lcom_yandex_mapkit_map_SizeChangedListener_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapWindow? mapWindow = Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ISizeChangedListener p = Java.Lang.Object.GetObject<ISizeChangedListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapWindow.RemoveSizeChangedListener(p);
	}

	public unsafe void RemoveSizeChangedListener(ISizeChangedListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractVoidMethod("removeSizeChangedListener.(Lcom/yandex/mapkit/map/SizeChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetRemoveSurface_Lcom_yandex_runtime_view_Surface_Handler()
	{
		if ((object)cb_removeSurface_RemoveSurface_Lcom_yandex_runtime_view_Surface__V == null)
		{
			cb_removeSurface_RemoveSurface_Lcom_yandex_runtime_view_Surface__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveSurface_Lcom_yandex_runtime_view_Surface_));
		}
		return cb_removeSurface_RemoveSurface_Lcom_yandex_runtime_view_Surface__V;
	}

	private static void n_RemoveSurface_Lcom_yandex_runtime_view_Surface_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapWindow? mapWindow = Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ISurface p = Java.Lang.Object.GetObject<ISurface>(native_p0, JniHandleOwnership.DoNotTransfer);
		mapWindow.RemoveSurface(p);
	}

	public unsafe void RemoveSurface(ISurface p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractVoidMethod("removeSurface.(Lcom/yandex/runtime/view/Surface;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetScreenToWorld_Lcom_yandex_mapkit_ScreenPoint_Handler()
	{
		if ((object)cb_screenToWorld_ScreenToWorld_Lcom_yandex_mapkit_ScreenPoint__Lcom_yandex_mapkit_geometry_Point_ == null)
		{
			cb_screenToWorld_ScreenToWorld_Lcom_yandex_mapkit_ScreenPoint__Lcom_yandex_mapkit_geometry_Point_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ScreenToWorld_Lcom_yandex_mapkit_ScreenPoint_));
		}
		return cb_screenToWorld_ScreenToWorld_Lcom_yandex_mapkit_ScreenPoint__Lcom_yandex_mapkit_geometry_Point_;
	}

	private static nint n_ScreenToWorld_Lcom_yandex_mapkit_ScreenPoint_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapWindow? mapWindow = Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		ScreenPoint p = Java.Lang.Object.GetObject<ScreenPoint>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapWindow.ScreenToWorld(p));
	}

	public unsafe Point? ScreenToWorld(ScreenPoint p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Point>(_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractObjectMethod("screenToWorld.(Lcom/yandex/mapkit/ScreenPoint;)Lcom/yandex/mapkit/geometry/Point;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetMaxFps_FHandler()
	{
		if ((object)cb_setMaxFps_SetMaxFps_F_V == null)
		{
			cb_setMaxFps_SetMaxFps_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetMaxFps_F));
		}
		return cb_setMaxFps_SetMaxFps_F_V;
	}

	private static void n_SetMaxFps_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMaxFps(p0);
	}

	public unsafe void SetMaxFps(float p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractVoidMethod("setMaxFps.(F)V", this, ptr);
	}

	private static Delegate GetStartMemoryMetricsCaptureHandler()
	{
		if ((object)cb_startMemoryMetricsCapture_StartMemoryMetricsCapture_V == null)
		{
			cb_startMemoryMetricsCapture_StartMemoryMetricsCapture_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_StartMemoryMetricsCapture));
		}
		return cb_startMemoryMetricsCapture_StartMemoryMetricsCapture_V;
	}

	private static void n_StartMemoryMetricsCapture(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartMemoryMetricsCapture();
	}

	public unsafe void StartMemoryMetricsCapture()
	{
		_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractVoidMethod("startMemoryMetricsCapture.()V", this, null);
	}

	private static Delegate GetStartPerformanceMetricsCaptureHandler()
	{
		if ((object)cb_startPerformanceMetricsCapture_StartPerformanceMetricsCapture_V == null)
		{
			cb_startPerformanceMetricsCapture_StartPerformanceMetricsCapture_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_StartPerformanceMetricsCapture));
		}
		return cb_startPerformanceMetricsCapture_StartPerformanceMetricsCapture_V;
	}

	private static void n_StartPerformanceMetricsCapture(nint jnienv, nint native__this)
	{
		Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartPerformanceMetricsCapture();
	}

	public unsafe void StartPerformanceMetricsCapture()
	{
		_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractVoidMethod("startPerformanceMetricsCapture.()V", this, null);
	}

	private static Delegate GetStopMemoryMetricsCaptureHandler()
	{
		if ((object)cb_stopMemoryMetricsCapture_StopMemoryMetricsCapture_Ljava_lang_String_ == null)
		{
			cb_stopMemoryMetricsCapture_StopMemoryMetricsCapture_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_StopMemoryMetricsCapture));
		}
		return cb_stopMemoryMetricsCapture_StopMemoryMetricsCapture_Ljava_lang_String_;
	}

	private static nint n_StopMemoryMetricsCapture(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopMemoryMetricsCapture());
	}

	public unsafe string StopMemoryMetricsCapture()
	{
		return JNIEnv.GetString(_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractObjectMethod("stopMemoryMetricsCapture.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetStopPerformanceMetricsCaptureHandler()
	{
		if ((object)cb_stopPerformanceMetricsCapture_StopPerformanceMetricsCapture_Ljava_lang_String_ == null)
		{
			cb_stopPerformanceMetricsCapture_StopPerformanceMetricsCapture_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_StopPerformanceMetricsCapture));
		}
		return cb_stopPerformanceMetricsCapture_StopPerformanceMetricsCapture_Ljava_lang_String_;
	}

	private static nint n_StopPerformanceMetricsCapture(nint jnienv, nint native__this)
	{
		return JNIEnv.NewString(Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StopPerformanceMetricsCapture());
	}

	public unsafe string StopPerformanceMetricsCapture()
	{
		return JNIEnv.GetString(_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractObjectMethod("stopPerformanceMetricsCapture.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetWidthHandler()
	{
		if ((object)cb_width_Width_I == null)
		{
			cb_width_Width_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_Width));
		}
		return cb_width_Width_I;
	}

	private static int n_Width(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Width();
	}

	public unsafe int Width()
	{
		return _members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractInt32Method("width.()I", this, null);
	}

	private static Delegate GetWorldToScreen_Lcom_yandex_mapkit_geometry_Point_Handler()
	{
		if ((object)cb_worldToScreen_WorldToScreen_Lcom_yandex_mapkit_geometry_Point__Lcom_yandex_mapkit_ScreenPoint_ == null)
		{
			cb_worldToScreen_WorldToScreen_Lcom_yandex_mapkit_geometry_Point__Lcom_yandex_mapkit_ScreenPoint_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WorldToScreen_Lcom_yandex_mapkit_geometry_Point_));
		}
		return cb_worldToScreen_WorldToScreen_Lcom_yandex_mapkit_geometry_Point__Lcom_yandex_mapkit_ScreenPoint_;
	}

	private static nint n_WorldToScreen_Lcom_yandex_mapkit_geometry_Point_(nint jnienv, nint native__this, nint native_p0)
	{
		IMapWindow? mapWindow = Java.Lang.Object.GetObject<IMapWindow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Point p = Java.Lang.Object.GetObject<Point>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(mapWindow.WorldToScreen(p));
	}

	public unsafe ScreenPoint? WorldToScreen(Point p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<ScreenPoint>(_members_com_yandex_mapkit_map_MapWindow.InstanceMethods.InvokeAbstractObjectMethod("worldToScreen.(Lcom/yandex/mapkit/geometry/Point;)Lcom/yandex/mapkit/ScreenPoint;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}
}
