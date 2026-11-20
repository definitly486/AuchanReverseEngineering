using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Com.Yandex.Mapkit.Geometry;
using Java.Interop;
using Java.Lang;

namespace Com.Yandex.Mapkit.Map;

[Register("com/yandex/mapkit/map/PolylineMapObject", DoNotGenerateAcw = true)]
internal class IPolylineMapObjectInvoker : Java.Lang.Object, IPolylineMapObject, IMapObject, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_MapObject = new XAPeerMembers("com/yandex/mapkit/map/MapObject", typeof(IPolylineMapObjectInvoker));

	private static readonly JniPeerMembers _members_com_yandex_mapkit_map_PolylineMapObject = new XAPeerMembers("com/yandex/mapkit/map/PolylineMapObject", typeof(IPolylineMapObjectInvoker));

	private static Delegate? cb_getArcApproximationStep_GetArcApproximationStep_F;

	private static Delegate? cb_setArcApproximationStep_SetArcApproximationStep_F_V;

	private static Delegate? cb_getDashLength_GetDashLength_F;

	private static Delegate? cb_setDashLength_SetDashLength_F_V;

	private static Delegate? cb_getDashOffset_GetDashOffset_F;

	private static Delegate? cb_setDashOffset_SetDashOffset_F_V;

	private static Delegate? cb_getGapLength_GetGapLength_F;

	private static Delegate? cb_setGapLength_SetGapLength_F_V;

	private static Delegate? cb_getGeometry_GetGeometry_Lcom_yandex_mapkit_geometry_Polyline_;

	private static Delegate? cb_setGeometry_SetGeometry_Lcom_yandex_mapkit_geometry_Polyline__V;

	private static Delegate? cb_getGradientLength_GetGradientLength_F;

	private static Delegate? cb_setGradientLength_SetGradientLength_F_V;

	private static Delegate? cb_isInnerOutlineEnabled_IsInnerOutlineEnabled_Z;

	private static Delegate? cb_setInnerOutlineEnabled_SetInnerOutlineEnabled_Z_V;

	private static Delegate? cb_getOutlineColor_GetOutlineColor_I;

	private static Delegate? cb_setOutlineColor_SetOutlineColor_I_V;

	private static Delegate? cb_getOutlineWidth_GetOutlineWidth_F;

	private static Delegate? cb_setOutlineWidth_SetOutlineWidth_F_V;

	private static Delegate? cb_getStrokeWidth_GetStrokeWidth_F;

	private static Delegate? cb_setStrokeWidth_SetStrokeWidth_F_V;

	private static Delegate? cb_getStyle_GetStyle_Lcom_yandex_mapkit_map_LineStyle_;

	private static Delegate? cb_setStyle_SetStyle_Lcom_yandex_mapkit_map_LineStyle__V;

	private static Delegate? cb_getTurnRadius_GetTurnRadius_F;

	private static Delegate? cb_setTurnRadius_SetTurnRadius_F_V;

	private static Delegate? cb_addArrow_AddArrow_Lcom_yandex_mapkit_geometry_PolylinePosition_FI_Lcom_yandex_mapkit_map_Arrow_;

	private static Delegate? cb_arrows_Arrows_Ljava_util_List_;

	private static Delegate? cb_getPaletteColor_GetPaletteColor_I_I;

	private static Delegate? cb_getStrokeColor_GetStrokeColor_I_I;

	private static Delegate? cb_hide_Hide_Lcom_yandex_mapkit_geometry_Subpolyline__V;

	private static Delegate? cb_hide_Hide_Ljava_util_List__V;

	private static Delegate? cb_select_Select_ILcom_yandex_mapkit_geometry_Subpolyline__V;

	private static Delegate? cb_setPaletteColor_SetPaletteColor_II_V;

	private static Delegate? cb_setStrokeColor_SetStrokeColor_I_V;

	private static Delegate? cb_setStrokeColors_SetStrokeColors_Ljava_util_List__V;

	private static Delegate? cb_setStrokeColors_SetStrokeColors_Ljava_util_List_Ljava_util_List__V;

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

	private static nint java_class_ref => _members_com_yandex_mapkit_map_PolylineMapObject.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_yandex_mapkit_map_PolylineMapObject;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_yandex_mapkit_map_PolylineMapObject.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_yandex_mapkit_map_PolylineMapObject.ManagedPeerType;

	public unsafe float ArcApproximationStep
	{
		get
		{
			return _members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractSingleMethod("getArcApproximationStep.()F", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("setArcApproximationStep.(F)V", this, ptr);
		}
	}

	public unsafe float DashLength
	{
		get
		{
			return _members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractSingleMethod("getDashLength.()F", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("setDashLength.(F)V", this, ptr);
		}
	}

	public unsafe float DashOffset
	{
		get
		{
			return _members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractSingleMethod("getDashOffset.()F", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("setDashOffset.(F)V", this, ptr);
		}
	}

	public unsafe float GapLength
	{
		get
		{
			return _members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractSingleMethod("getGapLength.()F", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("setGapLength.(F)V", this, ptr);
		}
	}

	public unsafe Polyline Geometry
	{
		get
		{
			return Java.Lang.Object.GetObject<Polyline>(_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractObjectMethod("getGeometry.()Lcom/yandex/mapkit/geometry/Polyline;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("setGeometry.(Lcom/yandex/mapkit/geometry/Polyline;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe float GradientLength
	{
		get
		{
			return _members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractSingleMethod("getGradientLength.()F", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("setGradientLength.(F)V", this, ptr);
		}
	}

	public unsafe bool InnerOutlineEnabled
	{
		get
		{
			return _members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractBooleanMethod("isInnerOutlineEnabled.()Z", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("setInnerOutlineEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe int OutlineColor
	{
		get
		{
			return _members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractInt32Method("getOutlineColor.()I", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("setOutlineColor.(I)V", this, ptr);
		}
	}

	public unsafe float OutlineWidth
	{
		get
		{
			return _members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractSingleMethod("getOutlineWidth.()F", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("setOutlineWidth.(F)V", this, ptr);
		}
	}

	public unsafe float StrokeWidth
	{
		get
		{
			return _members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractSingleMethod("getStrokeWidth.()F", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("setStrokeWidth.(F)V", this, ptr);
		}
	}

	public unsafe LineStyle Style
	{
		get
		{
			return Java.Lang.Object.GetObject<LineStyle>(_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractObjectMethod("getStyle.()Lcom/yandex/mapkit/map/LineStyle;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("setStyle.(Lcom/yandex/mapkit/map/LineStyle;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe float TurnRadius
	{
		get
		{
			return _members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractSingleMethod("getTurnRadius.()F", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("setTurnRadius.(F)V", this, ptr);
		}
	}

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

	public IPolylineMapObjectInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Obsolete]
	private static Delegate GetGetArcApproximationStepHandler()
	{
		if ((object)cb_getArcApproximationStep_GetArcApproximationStep_F == null)
		{
			cb_getArcApproximationStep_GetArcApproximationStep_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetArcApproximationStep));
		}
		return cb_getArcApproximationStep_GetArcApproximationStep_F;
	}

	[Obsolete]
	private static float n_GetArcApproximationStep(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ArcApproximationStep;
	}

	[Obsolete]
	private static Delegate GetSetArcApproximationStep_FHandler()
	{
		if ((object)cb_setArcApproximationStep_SetArcApproximationStep_F_V == null)
		{
			cb_setArcApproximationStep_SetArcApproximationStep_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetArcApproximationStep_F));
		}
		return cb_setArcApproximationStep_SetArcApproximationStep_F_V;
	}

	[Obsolete]
	private static void n_SetArcApproximationStep_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ArcApproximationStep = p0;
	}

	[Obsolete]
	private static Delegate GetGetDashLengthHandler()
	{
		if ((object)cb_getDashLength_GetDashLength_F == null)
		{
			cb_getDashLength_GetDashLength_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetDashLength));
		}
		return cb_getDashLength_GetDashLength_F;
	}

	[Obsolete]
	private static float n_GetDashLength(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DashLength;
	}

	[Obsolete]
	private static Delegate GetSetDashLength_FHandler()
	{
		if ((object)cb_setDashLength_SetDashLength_F_V == null)
		{
			cb_setDashLength_SetDashLength_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetDashLength_F));
		}
		return cb_setDashLength_SetDashLength_F_V;
	}

	[Obsolete]
	private static void n_SetDashLength_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DashLength = p0;
	}

	[Obsolete]
	private static Delegate GetGetDashOffsetHandler()
	{
		if ((object)cb_getDashOffset_GetDashOffset_F == null)
		{
			cb_getDashOffset_GetDashOffset_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetDashOffset));
		}
		return cb_getDashOffset_GetDashOffset_F;
	}

	[Obsolete]
	private static float n_GetDashOffset(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DashOffset;
	}

	[Obsolete]
	private static Delegate GetSetDashOffset_FHandler()
	{
		if ((object)cb_setDashOffset_SetDashOffset_F_V == null)
		{
			cb_setDashOffset_SetDashOffset_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetDashOffset_F));
		}
		return cb_setDashOffset_SetDashOffset_F_V;
	}

	[Obsolete]
	private static void n_SetDashOffset_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DashOffset = p0;
	}

	[Obsolete]
	private static Delegate GetGetGapLengthHandler()
	{
		if ((object)cb_getGapLength_GetGapLength_F == null)
		{
			cb_getGapLength_GetGapLength_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetGapLength));
		}
		return cb_getGapLength_GetGapLength_F;
	}

	[Obsolete]
	private static float n_GetGapLength(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GapLength;
	}

	[Obsolete]
	private static Delegate GetSetGapLength_FHandler()
	{
		if ((object)cb_setGapLength_SetGapLength_F_V == null)
		{
			cb_setGapLength_SetGapLength_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetGapLength_F));
		}
		return cb_setGapLength_SetGapLength_F_V;
	}

	[Obsolete]
	private static void n_SetGapLength_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GapLength = p0;
	}

	private static Delegate GetGetGeometryHandler()
	{
		if ((object)cb_getGeometry_GetGeometry_Lcom_yandex_mapkit_geometry_Polyline_ == null)
		{
			cb_getGeometry_GetGeometry_Lcom_yandex_mapkit_geometry_Polyline_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetGeometry));
		}
		return cb_getGeometry_GetGeometry_Lcom_yandex_mapkit_geometry_Polyline_;
	}

	private static nint n_GetGeometry(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Geometry);
	}

	private static Delegate GetSetGeometry_Lcom_yandex_mapkit_geometry_Polyline_Handler()
	{
		if ((object)cb_setGeometry_SetGeometry_Lcom_yandex_mapkit_geometry_Polyline__V == null)
		{
			cb_setGeometry_SetGeometry_Lcom_yandex_mapkit_geometry_Polyline__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetGeometry_Lcom_yandex_mapkit_geometry_Polyline_));
		}
		return cb_setGeometry_SetGeometry_Lcom_yandex_mapkit_geometry_Polyline__V;
	}

	private static void n_SetGeometry_Lcom_yandex_mapkit_geometry_Polyline_(nint jnienv, nint native__this, nint native_p0)
	{
		IPolylineMapObject? polylineMapObject = Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Polyline geometry = Java.Lang.Object.GetObject<Polyline>(native_p0, JniHandleOwnership.DoNotTransfer);
		polylineMapObject.Geometry = geometry;
	}

	[Obsolete]
	private static Delegate GetGetGradientLengthHandler()
	{
		if ((object)cb_getGradientLength_GetGradientLength_F == null)
		{
			cb_getGradientLength_GetGradientLength_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetGradientLength));
		}
		return cb_getGradientLength_GetGradientLength_F;
	}

	[Obsolete]
	private static float n_GetGradientLength(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GradientLength;
	}

	[Obsolete]
	private static Delegate GetSetGradientLength_FHandler()
	{
		if ((object)cb_setGradientLength_SetGradientLength_F_V == null)
		{
			cb_setGradientLength_SetGradientLength_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetGradientLength_F));
		}
		return cb_setGradientLength_SetGradientLength_F_V;
	}

	[Obsolete]
	private static void n_SetGradientLength_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GradientLength = p0;
	}

	[Obsolete]
	private static Delegate GetIsInnerOutlineEnabledHandler()
	{
		if ((object)cb_isInnerOutlineEnabled_IsInnerOutlineEnabled_Z == null)
		{
			cb_isInnerOutlineEnabled_IsInnerOutlineEnabled_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsInnerOutlineEnabled));
		}
		return cb_isInnerOutlineEnabled_IsInnerOutlineEnabled_Z;
	}

	[Obsolete]
	private static bool n_IsInnerOutlineEnabled(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InnerOutlineEnabled;
	}

	[Obsolete]
	private static Delegate GetSetInnerOutlineEnabled_ZHandler()
	{
		if ((object)cb_setInnerOutlineEnabled_SetInnerOutlineEnabled_Z_V == null)
		{
			cb_setInnerOutlineEnabled_SetInnerOutlineEnabled_Z_V = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZ_V(n_SetInnerOutlineEnabled_Z));
		}
		return cb_setInnerOutlineEnabled_SetInnerOutlineEnabled_Z_V;
	}

	[Obsolete]
	private static void n_SetInnerOutlineEnabled_Z(nint jnienv, nint native__this, bool p0)
	{
		Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InnerOutlineEnabled = p0;
	}

	[Obsolete]
	private static Delegate GetGetOutlineColorHandler()
	{
		if ((object)cb_getOutlineColor_GetOutlineColor_I == null)
		{
			cb_getOutlineColor_GetOutlineColor_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetOutlineColor));
		}
		return cb_getOutlineColor_GetOutlineColor_I;
	}

	[Obsolete]
	private static int n_GetOutlineColor(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OutlineColor;
	}

	[Obsolete]
	private static Delegate GetSetOutlineColor_IHandler()
	{
		if ((object)cb_setOutlineColor_SetOutlineColor_I_V == null)
		{
			cb_setOutlineColor_SetOutlineColor_I_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetOutlineColor_I));
		}
		return cb_setOutlineColor_SetOutlineColor_I_V;
	}

	[Obsolete]
	private static void n_SetOutlineColor_I(nint jnienv, nint native__this, int p0)
	{
		Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OutlineColor = p0;
	}

	[Obsolete]
	private static Delegate GetGetOutlineWidthHandler()
	{
		if ((object)cb_getOutlineWidth_GetOutlineWidth_F == null)
		{
			cb_getOutlineWidth_GetOutlineWidth_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetOutlineWidth));
		}
		return cb_getOutlineWidth_GetOutlineWidth_F;
	}

	[Obsolete]
	private static float n_GetOutlineWidth(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OutlineWidth;
	}

	[Obsolete]
	private static Delegate GetSetOutlineWidth_FHandler()
	{
		if ((object)cb_setOutlineWidth_SetOutlineWidth_F_V == null)
		{
			cb_setOutlineWidth_SetOutlineWidth_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetOutlineWidth_F));
		}
		return cb_setOutlineWidth_SetOutlineWidth_F_V;
	}

	[Obsolete]
	private static void n_SetOutlineWidth_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OutlineWidth = p0;
	}

	[Obsolete]
	private static Delegate GetGetStrokeWidthHandler()
	{
		if ((object)cb_getStrokeWidth_GetStrokeWidth_F == null)
		{
			cb_getStrokeWidth_GetStrokeWidth_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetStrokeWidth));
		}
		return cb_getStrokeWidth_GetStrokeWidth_F;
	}

	[Obsolete]
	private static float n_GetStrokeWidth(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeWidth;
	}

	[Obsolete]
	private static Delegate GetSetStrokeWidth_FHandler()
	{
		if ((object)cb_setStrokeWidth_SetStrokeWidth_F_V == null)
		{
			cb_setStrokeWidth_SetStrokeWidth_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetStrokeWidth_F));
		}
		return cb_setStrokeWidth_SetStrokeWidth_F_V;
	}

	[Obsolete]
	private static void n_SetStrokeWidth_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeWidth = p0;
	}

	private static Delegate GetGetStyleHandler()
	{
		if ((object)cb_getStyle_GetStyle_Lcom_yandex_mapkit_map_LineStyle_ == null)
		{
			cb_getStyle_GetStyle_Lcom_yandex_mapkit_map_LineStyle_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetStyle));
		}
		return cb_getStyle_GetStyle_Lcom_yandex_mapkit_map_LineStyle_;
	}

	private static nint n_GetStyle(nint jnienv, nint native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Style);
	}

	private static Delegate GetSetStyle_Lcom_yandex_mapkit_map_LineStyle_Handler()
	{
		if ((object)cb_setStyle_SetStyle_Lcom_yandex_mapkit_map_LineStyle__V == null)
		{
			cb_setStyle_SetStyle_Lcom_yandex_mapkit_map_LineStyle__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetStyle_Lcom_yandex_mapkit_map_LineStyle_));
		}
		return cb_setStyle_SetStyle_Lcom_yandex_mapkit_map_LineStyle__V;
	}

	private static void n_SetStyle_Lcom_yandex_mapkit_map_LineStyle_(nint jnienv, nint native__this, nint native_p0)
	{
		IPolylineMapObject? polylineMapObject = Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		LineStyle style = Java.Lang.Object.GetObject<LineStyle>(native_p0, JniHandleOwnership.DoNotTransfer);
		polylineMapObject.Style = style;
	}

	[Obsolete]
	private static Delegate GetGetTurnRadiusHandler()
	{
		if ((object)cb_getTurnRadius_GetTurnRadius_F == null)
		{
			cb_getTurnRadius_GetTurnRadius_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetTurnRadius));
		}
		return cb_getTurnRadius_GetTurnRadius_F;
	}

	[Obsolete]
	private static float n_GetTurnRadius(nint jnienv, nint native__this)
	{
		return Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TurnRadius;
	}

	[Obsolete]
	private static Delegate GetSetTurnRadius_FHandler()
	{
		if ((object)cb_setTurnRadius_SetTurnRadius_F_V == null)
		{
			cb_setTurnRadius_SetTurnRadius_F_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetTurnRadius_F));
		}
		return cb_setTurnRadius_SetTurnRadius_F_V;
	}

	[Obsolete]
	private static void n_SetTurnRadius_F(nint jnienv, nint native__this, float p0)
	{
		Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TurnRadius = p0;
	}

	private static Delegate GetAddArrow_Lcom_yandex_mapkit_geometry_PolylinePosition_FIHandler()
	{
		if ((object)cb_addArrow_AddArrow_Lcom_yandex_mapkit_geometry_PolylinePosition_FI_Lcom_yandex_mapkit_map_Arrow_ == null)
		{
			cb_addArrow_AddArrow_Lcom_yandex_mapkit_geometry_PolylinePosition_FI_Lcom_yandex_mapkit_map_Arrow_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLFI_L(n_AddArrow_Lcom_yandex_mapkit_geometry_PolylinePosition_FI));
		}
		return cb_addArrow_AddArrow_Lcom_yandex_mapkit_geometry_PolylinePosition_FI_Lcom_yandex_mapkit_map_Arrow_;
	}

	private static nint n_AddArrow_Lcom_yandex_mapkit_geometry_PolylinePosition_FI(nint jnienv, nint native__this, nint native_p0, float p1, int p2)
	{
		IPolylineMapObject? polylineMapObject = Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		PolylinePosition p3 = Java.Lang.Object.GetObject<PolylinePosition>(native_p0, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(polylineMapObject.AddArrow(p3, p1, p2));
	}

	public unsafe IArrow AddArrow(PolylinePosition p0, float p1, int p2)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			ptr[2] = new JniArgumentValue(p2);
			return Java.Lang.Object.GetObject<IArrow>(_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractObjectMethod("addArrow.(Lcom/yandex/mapkit/geometry/PolylinePosition;FI)Lcom/yandex/mapkit/map/Arrow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetArrowsHandler()
	{
		if ((object)cb_arrows_Arrows_Ljava_util_List_ == null)
		{
			cb_arrows_Arrows_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Arrows));
		}
		return cb_arrows_Arrows_Ljava_util_List_;
	}

	private static nint n_Arrows(nint jnienv, nint native__this)
	{
		return JavaList<IArrow>.ToLocalJniHandle(Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Arrows());
	}

	public unsafe IList<IArrow> Arrows()
	{
		return JavaList<IArrow>.FromJniHandle(_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractObjectMethod("arrows.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGetPaletteColor_IHandler()
	{
		if ((object)cb_getPaletteColor_GetPaletteColor_I_I == null)
		{
			cb_getPaletteColor_GetPaletteColor_I_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_GetPaletteColor_I));
		}
		return cb_getPaletteColor_GetPaletteColor_I_I;
	}

	private static int n_GetPaletteColor_I(nint jnienv, nint native__this, int p0)
	{
		return Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetPaletteColor(p0);
	}

	public unsafe int GetPaletteColor(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return _members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractInt32Method("getPaletteColor.(I)I", this, ptr);
	}

	private static Delegate GetGetStrokeColor_IHandler()
	{
		if ((object)cb_getStrokeColor_GetStrokeColor_I_I == null)
		{
			cb_getStrokeColor_GetStrokeColor_I_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_GetStrokeColor_I));
		}
		return cb_getStrokeColor_GetStrokeColor_I_I;
	}

	private static int n_GetStrokeColor_I(nint jnienv, nint native__this, int p0)
	{
		return Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetStrokeColor(p0);
	}

	public unsafe int GetStrokeColor(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		return _members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractInt32Method("getStrokeColor.(I)I", this, ptr);
	}

	private static Delegate GetHide_Lcom_yandex_mapkit_geometry_Subpolyline_Handler()
	{
		if ((object)cb_hide_Hide_Lcom_yandex_mapkit_geometry_Subpolyline__V == null)
		{
			cb_hide_Hide_Lcom_yandex_mapkit_geometry_Subpolyline__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Hide_Lcom_yandex_mapkit_geometry_Subpolyline_));
		}
		return cb_hide_Hide_Lcom_yandex_mapkit_geometry_Subpolyline__V;
	}

	private static void n_Hide_Lcom_yandex_mapkit_geometry_Subpolyline_(nint jnienv, nint native__this, nint native_p0)
	{
		IPolylineMapObject? polylineMapObject = Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Subpolyline p = Java.Lang.Object.GetObject<Subpolyline>(native_p0, JniHandleOwnership.DoNotTransfer);
		polylineMapObject.Hide(p);
	}

	public unsafe void Hide(Subpolyline p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("hide.(Lcom/yandex/mapkit/geometry/Subpolyline;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetHide_Ljava_util_List_Handler()
	{
		if ((object)cb_hide_Hide_Ljava_util_List__V == null)
		{
			cb_hide_Hide_Ljava_util_List__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Hide_Ljava_util_List_));
		}
		return cb_hide_Hide_Ljava_util_List__V;
	}

	private static void n_Hide_Ljava_util_List_(nint jnienv, nint native__this, nint native_p0)
	{
		IPolylineMapObject? polylineMapObject = Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<Subpolyline> p = JavaList<Subpolyline>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		polylineMapObject.Hide(p);
	}

	public unsafe void Hide(IList<Subpolyline> p0)
	{
		nint num = JavaList<Subpolyline>.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("hide.(Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSelect_ILcom_yandex_mapkit_geometry_Subpolyline_Handler()
	{
		if ((object)cb_select_Select_ILcom_yandex_mapkit_geometry_Subpolyline__V == null)
		{
			cb_select_Select_ILcom_yandex_mapkit_geometry_Subpolyline__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_Select_ILcom_yandex_mapkit_geometry_Subpolyline_));
		}
		return cb_select_Select_ILcom_yandex_mapkit_geometry_Subpolyline__V;
	}

	private static void n_Select_ILcom_yandex_mapkit_geometry_Subpolyline_(nint jnienv, nint native__this, int p0, nint native_p1)
	{
		IPolylineMapObject? polylineMapObject = Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Subpolyline p1 = Java.Lang.Object.GetObject<Subpolyline>(native_p1, JniHandleOwnership.DoNotTransfer);
		polylineMapObject.Select(p0, p1);
	}

	public unsafe void Select(int p0, Subpolyline p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("select.(ILcom/yandex/mapkit/geometry/Subpolyline;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetSetPaletteColor_IIHandler()
	{
		if ((object)cb_setPaletteColor_SetPaletteColor_II_V == null)
		{
			cb_setPaletteColor_SetPaletteColor_II_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetPaletteColor_II));
		}
		return cb_setPaletteColor_SetPaletteColor_II_V;
	}

	private static void n_SetPaletteColor_II(nint jnienv, nint native__this, int p0, int p1)
	{
		Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPaletteColor(p0, p1);
	}

	public unsafe void SetPaletteColor(int p0, int p1)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(p0);
		ptr[1] = new JniArgumentValue(p1);
		_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("setPaletteColor.(II)V", this, ptr);
	}

	private static Delegate GetSetStrokeColor_IHandler()
	{
		if ((object)cb_setStrokeColor_SetStrokeColor_I_V == null)
		{
			cb_setStrokeColor_SetStrokeColor_I_V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetStrokeColor_I));
		}
		return cb_setStrokeColor_SetStrokeColor_I_V;
	}

	private static void n_SetStrokeColor_I(nint jnienv, nint native__this, int p0)
	{
		Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStrokeColor(p0);
	}

	public unsafe void SetStrokeColor(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("setStrokeColor.(I)V", this, ptr);
	}

	private static Delegate GetSetStrokeColors_Ljava_util_List_Handler()
	{
		if ((object)cb_setStrokeColors_SetStrokeColors_Ljava_util_List__V == null)
		{
			cb_setStrokeColors_SetStrokeColors_Ljava_util_List__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetStrokeColors_Ljava_util_List_));
		}
		return cb_setStrokeColors_SetStrokeColors_Ljava_util_List__V;
	}

	private static void n_SetStrokeColors_Ljava_util_List_(nint jnienv, nint native__this, nint native_p0)
	{
		IPolylineMapObject? polylineMapObject = Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<Integer> strokeColors = JavaList<Integer>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		polylineMapObject.SetStrokeColors(strokeColors);
	}

	public unsafe void SetStrokeColors(IList<Integer> p0)
	{
		nint num = JavaList<Integer>.ToLocalJniHandle(p0);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("setStrokeColors.(Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetStrokeColors_Ljava_util_List_Ljava_util_List_Handler()
	{
		if ((object)cb_setStrokeColors_SetStrokeColors_Ljava_util_List_Ljava_util_List__V == null)
		{
			cb_setStrokeColors_SetStrokeColors_Ljava_util_List_Ljava_util_List__V = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetStrokeColors_Ljava_util_List_Ljava_util_List_));
		}
		return cb_setStrokeColors_SetStrokeColors_Ljava_util_List_Ljava_util_List__V;
	}

	private static void n_SetStrokeColors_Ljava_util_List_Ljava_util_List_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		IPolylineMapObject? polylineMapObject = Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IList<Integer> p = JavaList<Integer>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
		IList<Java.Lang.Double> p2 = JavaList<Java.Lang.Double>.FromJniHandle(native_p1, JniHandleOwnership.DoNotTransfer);
		polylineMapObject.SetStrokeColors(p, p2);
	}

	public unsafe void SetStrokeColors(IList<Integer> p0, IList<Java.Lang.Double> p1)
	{
		nint num = JavaList<Integer>.ToLocalJniHandle(p0);
		nint num2 = JavaList<Java.Lang.Double>.ToLocalJniHandle(p1);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members_com_yandex_mapkit_map_PolylineMapObject.InstanceMethods.InvokeAbstractVoidMethod("setStrokeColors.(Ljava/util/List;Ljava/util/List;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
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
		return Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Draggable;
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
		Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Draggable = p0;
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
		return Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid;
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Parent);
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
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UserData);
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
		IPolylineMapObject? polylineMapObject = Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object userData = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
		polylineMapObject.UserData = userData;
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
		return Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visible;
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
		Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visible = p0;
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
		return Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZIndex;
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
		Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ZIndex = p0;
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
		IPolylineMapObject? polylineMapObject = Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectTapListener p = Java.Lang.Object.GetObject<IMapObjectTapListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		polylineMapObject.AddTapListener(p);
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
		IPolylineMapObject? polylineMapObject = Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectTapListener p = Java.Lang.Object.GetObject<IMapObjectTapListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		polylineMapObject.RemoveTapListener(p);
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
		IPolylineMapObject? polylineMapObject = Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		IMapObjectDragListener dragListener = Java.Lang.Object.GetObject<IMapObjectDragListener>(native_p0, JniHandleOwnership.DoNotTransfer);
		polylineMapObject.SetDragListener(dragListener);
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
		IPolylineMapObject? polylineMapObject = Java.Lang.Object.GetObject<IPolylineMapObject>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Animation p1 = Java.Lang.Object.GetObject<Animation>(native_p1, JniHandleOwnership.DoNotTransfer);
		ICallback p2 = Java.Lang.Object.GetObject<ICallback>(native_p2, JniHandleOwnership.DoNotTransfer);
		polylineMapObject.SetVisible(p0, p1, p2);
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
