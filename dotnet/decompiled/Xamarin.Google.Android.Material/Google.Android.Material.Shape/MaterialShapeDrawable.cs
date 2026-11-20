using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Google.Android.Material.Elevation;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Shape;

[Register("com/google/android/material/shape/MaterialShapeDrawable", DoNotGenerateAcw = true)]
public class MaterialShapeDrawable : Drawable, IJavaObject, IDisposable, IJavaPeerable
{
	[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("com/google/android/material/shape/MaterialShapeDrawable$MaterialShapeDrawableState", DoNotGenerateAcw = true)]
	protected internal class MaterialShapeDrawableState : ConstantState
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/shape/MaterialShapeDrawable$MaterialShapeDrawableState", typeof(MaterialShapeDrawableState));

		private static Delegate? cb_getChangingConfigurations_GetChangingConfigurations_I;

		private static Delegate? cb_newDrawable_NewDrawable_Landroid_graphics_drawable_Drawable_;

		internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override ConfigChanges ChangingConfigurations
		{
			[Register("getChangingConfigurations", "()I", "GetGetChangingConfigurationsHandler")]
			get
			{
				return (ConfigChanges)_members.InstanceMethods.InvokeVirtualInt32Method("getChangingConfigurations.()I", this, null);
			}
		}

		protected MaterialShapeDrawableState(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/graphics/drawable/Drawable$ConstantState;)V", "")]
		public unsafe MaterialShapeDrawableState(ConstantState orig)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(orig?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/graphics/drawable/Drawable$ConstantState;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/graphics/drawable/Drawable$ConstantState;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(orig);
			}
		}

		[Register(".ctor", "(Lcom/google/android/material/shape/ShapeAppearanceModel;Lcom/google/android/material/elevation/ElevationOverlayProvider;)V", "")]
		public unsafe MaterialShapeDrawableState(ShapeAppearanceModel shapeAppearanceModel, ElevationOverlayProvider? elevationOverlayProvider)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(shapeAppearanceModel?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(elevationOverlayProvider?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/material/shape/ShapeAppearanceModel;Lcom/google/android/material/elevation/ElevationOverlayProvider;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/material/shape/ShapeAppearanceModel;Lcom/google/android/material/elevation/ElevationOverlayProvider;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(shapeAppearanceModel);
				GC.KeepAlive(elevationOverlayProvider);
			}
		}

		private static Delegate GetGetChangingConfigurationsHandler()
		{
			return new global::_JniMarshal_PP_I(n_GetChangingConfigurations);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static int n_GetChangingConfigurations(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return (int)Java.Lang.Object.GetObject<MaterialShapeDrawableState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ChangingConfigurations;
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		private static Delegate GetNewDrawableHandler()
		{
			return new global::_JniMarshal_PP_L(n_NewDrawable);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static nint n_NewDrawable(nint jnienv, nint native__this)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return 0;
			}
			try
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialShapeDrawableState>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NewDrawable());
			}
			catch (System.Exception e)
			{
				runtime.OnUserUnhandledException(ref transition, e);
				return 0;
			}
			finally
			{
				JniEnvironment.EndMarshalMethod(ref transition);
			}
		}

		[Register("newDrawable", "()Landroid/graphics/drawable/Drawable;", "GetNewDrawableHandler")]
		public unsafe override Drawable NewDrawable()
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("newDrawable.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/shape/MaterialShapeDrawable", typeof(MaterialShapeDrawable));

	private static Delegate? cb_getBottomLeftCornerResolvedSize_GetBottomLeftCornerResolvedSize_F;

	private static Delegate? cb_getBottomRightCornerResolvedSize_GetBottomRightCornerResolvedSize_F;

	private static Delegate? cb_getBoundsAsRectF_GetBoundsAsRectF_Landroid_graphics_RectF_;

	private static Delegate? cb_getElevation_GetElevation_F;

	private static Delegate? cb_setElevation_SetElevation_F_V;

	private static Delegate? cb_getFillColor_GetFillColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setFillColor_SetFillColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getInterpolation_GetInterpolation_F;

	private static Delegate? cb_setInterpolation_SetInterpolation_F_V;

	private static Delegate? cb_isElevationOverlayEnabled_IsElevationOverlayEnabled_Z;

	private static Delegate? cb_isElevationOverlayInitialized_IsElevationOverlayInitialized_Z;

	private static Delegate? cb_isRoundRect_IsRoundRect_Z;

	private static Delegate? cb_getOpacity_GetOpacity_I;

	private static Delegate? cb_getPaintStyle_GetPaintStyle_Landroid_graphics_Paint_Style_;

	private static Delegate? cb_setPaintStyle_SetPaintStyle_Landroid_graphics_Paint_Style__V;

	private static Delegate? cb_getParentAbsoluteElevation_GetParentAbsoluteElevation_F;

	private static Delegate? cb_setParentAbsoluteElevation_SetParentAbsoluteElevation_F_V;

	private static Delegate? cb_getResolvedTintColor_GetResolvedTintColor_I;

	private static Delegate? cb_getScale_GetScale_F;

	private static Delegate? cb_setScale_SetScale_F_V;

	private static Delegate? cb_getShadowCompatRotation_GetShadowCompatRotation_I;

	private static Delegate? cb_setShadowCompatRotation_SetShadowCompatRotation_I_V;

	private static Delegate? cb_getShadowCompatibilityMode_GetShadowCompatibilityMode_I;

	private static Delegate? cb_setShadowCompatibilityMode_SetShadowCompatibilityMode_I_V;

	private static Delegate? cb_getShadowElevation_GetShadowElevation_I;

	private static Delegate? cb_setShadowElevation_SetShadowElevation_I_V;

	private static Delegate? cb_isShadowEnabled_IsShadowEnabled_Z;

	private static Delegate? cb_setShadowEnabled_SetShadowEnabled_Z_V;

	private static Delegate? cb_getShadowOffsetX_GetShadowOffsetX_I;

	private static Delegate? cb_getShadowOffsetY_GetShadowOffsetY_I;

	private static Delegate? cb_getShadowRadius_GetShadowRadius_I;

	private static Delegate? cb_setShadowRadius_SetShadowRadius_I_V;

	private static Delegate? cb_getShadowVerticalOffset_GetShadowVerticalOffset_I;

	private static Delegate? cb_setShadowVerticalOffset_SetShadowVerticalOffset_I_V;

	private static Delegate? cb_getShapeAppearanceModel_GetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_;

	private static Delegate? cb_setShapeAppearanceModel_SetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel__V;

	private static Delegate? cb_getShapedViewModel_GetShapedViewModel_Lcom_google_android_material_shape_ShapePathModel_;

	private static Delegate? cb_setShapedViewModel_SetShapedViewModel_Lcom_google_android_material_shape_ShapePathModel__V;

	private static Delegate? cb_getStrokeColor_GetStrokeColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setStrokeColor_SetStrokeColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getStrokeTintList_GetStrokeTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_getStrokeWidth_GetStrokeWidth_F;

	private static Delegate? cb_setStrokeWidth_SetStrokeWidth_F_V;

	private static Delegate? cb_getTintList_GetTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_getTopLeftCornerResolvedSize_GetTopLeftCornerResolvedSize_F;

	private static Delegate? cb_getTopRightCornerResolvedSize_GetTopRightCornerResolvedSize_F;

	private static Delegate? cb_getTranslationZ_GetTranslationZ_F;

	private static Delegate? cb_setTranslationZ_SetTranslationZ_F_V;

	private static Delegate? cb_compositeElevationOverlayIfNeeded_CompositeElevationOverlayIfNeeded_I_I;

	private static Delegate? cb_draw_Draw_Landroid_graphics_Canvas__V;

	private static Delegate? cb_drawShape_DrawShape_Landroid_graphics_Canvas_Landroid_graphics_Paint_Landroid_graphics_Path_Landroid_graphics_RectF__V;

	private static Delegate? cb_drawStrokeShape_DrawStrokeShape_Landroid_graphics_Canvas__V;

	private static Delegate? cb_getPathForSize_GetPathForSize_IILandroid_graphics_Path__V;

	private static Delegate? cb_getZ_GetZ_F;

	private static Delegate? cb_initializeElevationOverlay_InitializeElevationOverlay_Landroid_content_Context__V;

	private static Delegate? cb_isPointInTransparentRegion_IsPointInTransparentRegion_II_Z;

	private static Delegate? cb_requiresCompatShadow_RequiresCompatShadow_Z;

	private static Delegate? cb_setAlpha_SetAlpha_I_V;

	private static Delegate? cb_setColorFilter_SetColorFilter_Landroid_graphics_ColorFilter__V;

	private static Delegate? cb_setCornerSize_SetCornerSize_Lcom_google_android_material_shape_CornerSize__V;

	private static Delegate? cb_setCornerSize_SetCornerSize_F_V;

	private static Delegate? cb_setEdgeIntersectionCheckEnable_SetEdgeIntersectionCheckEnable_Z_V;

	private static Delegate? cb_setPadding_SetPadding_IIII_V;

	private static Delegate? cb_setShadowBitmapDrawingEnable_SetShadowBitmapDrawingEnable_Z_V;

	private static Delegate? cb_setShadowColor_SetShadowColor_I_V;

	private static Delegate? cb_setStroke_SetStroke_FLandroid_content_res_ColorStateList__V;

	private static Delegate? cb_setStroke_SetStroke_FI_V;

	private static Delegate? cb_setStrokeTint_SetStrokeTint_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_setStrokeTint_SetStrokeTint_I_V;

	private static Delegate? cb_setUseTintColorForShadow_SetUseTintColorForShadow_Z_V;

	private static Delegate? cb_setZ_SetZ_F_V;

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual float BottomLeftCornerResolvedSize
	{
		[Register("getBottomLeftCornerResolvedSize", "()F", "GetGetBottomLeftCornerResolvedSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getBottomLeftCornerResolvedSize.()F", this, null);
		}
	}

	public unsafe virtual float BottomRightCornerResolvedSize
	{
		[Register("getBottomRightCornerResolvedSize", "()F", "GetGetBottomRightCornerResolvedSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getBottomRightCornerResolvedSize.()F", this, null);
		}
	}

	protected unsafe virtual RectF BoundsAsRectF
	{
		[Register("getBoundsAsRectF", "()Landroid/graphics/RectF;", "GetGetBoundsAsRectFHandler")]
		get
		{
			return Java.Lang.Object.GetObject<RectF>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBoundsAsRectF.()Landroid/graphics/RectF;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual float Elevation
	{
		[Register("getElevation", "()F", "GetGetElevationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getElevation.()F", this, null);
		}
		[Register("setElevation", "(F)V", "GetSetElevation_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setElevation.(F)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? FillColor
	{
		[Register("getFillColor", "()Landroid/content/res/ColorStateList;", "GetGetFillColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getFillColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setFillColor", "(Landroid/content/res/ColorStateList;)V", "GetSetFillColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setFillColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual float Interpolation
	{
		[Register("getInterpolation", "()F", "GetGetInterpolationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getInterpolation.()F", this, null);
		}
		[Register("setInterpolation", "(F)V", "GetSetInterpolation_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInterpolation.(F)V", this, ptr);
		}
	}

	public unsafe virtual bool IsElevationOverlayEnabled
	{
		[Register("isElevationOverlayEnabled", "()Z", "GetIsElevationOverlayEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isElevationOverlayEnabled.()Z", this, null);
		}
	}

	public unsafe virtual bool IsElevationOverlayInitialized
	{
		[Register("isElevationOverlayInitialized", "()Z", "GetIsElevationOverlayInitializedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isElevationOverlayInitialized.()Z", this, null);
		}
	}

	public unsafe virtual bool IsRoundRect
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("isRoundRect", "()Z", "GetIsRoundRectHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRoundRect.()Z", this, null);
		}
	}

	public unsafe override int Opacity
	{
		[Register("getOpacity", "()I", "GetGetOpacityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getOpacity.()I", this, null);
		}
	}

	public unsafe virtual Paint.Style? PaintStyle
	{
		[Register("getPaintStyle", "()Landroid/graphics/Paint$Style;", "GetGetPaintStyleHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Paint.Style>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPaintStyle.()Landroid/graphics/Paint$Style;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setPaintStyle", "(Landroid/graphics/Paint$Style;)V", "GetSetPaintStyle_Landroid_graphics_Paint_Style_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setPaintStyle.(Landroid/graphics/Paint$Style;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual float ParentAbsoluteElevation
	{
		[Register("getParentAbsoluteElevation", "()F", "GetGetParentAbsoluteElevationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getParentAbsoluteElevation.()F", this, null);
		}
		[Register("setParentAbsoluteElevation", "(F)V", "GetSetParentAbsoluteElevation_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setParentAbsoluteElevation.(F)V", this, ptr);
		}
	}

	public unsafe virtual int ResolvedTintColor
	{
		[Register("getResolvedTintColor", "()I", "GetGetResolvedTintColorHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getResolvedTintColor.()I", this, null);
		}
	}

	public unsafe virtual float Scale
	{
		[Register("getScale", "()F", "GetGetScaleHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getScale.()F", this, null);
		}
		[Register("setScale", "(F)V", "GetSetScale_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setScale.(F)V", this, ptr);
		}
	}

	public unsafe virtual int ShadowCompatRotation
	{
		[Register("getShadowCompatRotation", "()I", "GetGetShadowCompatRotationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getShadowCompatRotation.()I", this, null);
		}
		[Register("setShadowCompatRotation", "(I)V", "GetSetShadowCompatRotation_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setShadowCompatRotation.(I)V", this, ptr);
		}
	}

	public unsafe virtual int ShadowCompatibilityMode
	{
		[Register("getShadowCompatibilityMode", "()I", "GetGetShadowCompatibilityModeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getShadowCompatibilityMode.()I", this, null);
		}
		[Register("setShadowCompatibilityMode", "(I)V", "GetSetShadowCompatibilityMode_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setShadowCompatibilityMode.(I)V", this, ptr);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual int ShadowElevation
	{
		[Register("getShadowElevation", "()I", "GetGetShadowElevationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getShadowElevation.()I", this, null);
		}
		[Register("setShadowElevation", "(I)V", "GetSetShadowElevation_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setShadowElevation.(I)V", this, ptr);
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual bool ShadowEnabled
	{
		[Register("isShadowEnabled", "()Z", "GetIsShadowEnabledHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isShadowEnabled.()Z", this, null);
		}
		[Register("setShadowEnabled", "(Z)V", "GetSetShadowEnabled_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setShadowEnabled.(Z)V", this, ptr);
		}
	}

	public unsafe virtual int ShadowOffsetX
	{
		[Register("getShadowOffsetX", "()I", "GetGetShadowOffsetXHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getShadowOffsetX.()I", this, null);
		}
	}

	public unsafe virtual int ShadowOffsetY
	{
		[Register("getShadowOffsetY", "()I", "GetGetShadowOffsetYHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getShadowOffsetY.()I", this, null);
		}
	}

	public unsafe virtual int ShadowRadius
	{
		[Register("getShadowRadius", "()I", "GetGetShadowRadiusHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getShadowRadius.()I", this, null);
		}
		[Obsolete("deprecated")]
		[Register("setShadowRadius", "(I)V", "GetSetShadowRadius_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setShadowRadius.(I)V", this, ptr);
		}
	}

	public unsafe virtual int ShadowVerticalOffset
	{
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("getShadowVerticalOffset", "()I", "GetGetShadowVerticalOffsetHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getShadowVerticalOffset.()I", this, null);
		}
		[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
		[Register("setShadowVerticalOffset", "(I)V", "GetSetShadowVerticalOffset_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setShadowVerticalOffset.(I)V", this, ptr);
		}
	}

	public unsafe virtual ShapeAppearanceModel ShapeAppearanceModel
	{
		[Register("getShapeAppearanceModel", "()Lcom/google/android/material/shape/ShapeAppearanceModel;", "GetGetShapeAppearanceModelHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ShapeAppearanceModel>(_members.InstanceMethods.InvokeVirtualObjectMethod("getShapeAppearanceModel.()Lcom/google/android/material/shape/ShapeAppearanceModel;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setShapeAppearanceModel", "(Lcom/google/android/material/shape/ShapeAppearanceModel;)V", "GetSetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setShapeAppearanceModel.(Lcom/google/android/material/shape/ShapeAppearanceModel;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	[Obsolete("deprecated")]
	public unsafe virtual ShapePathModel? ShapedViewModel
	{
		[Register("getShapedViewModel", "()Lcom/google/android/material/shape/ShapePathModel;", "GetGetShapedViewModelHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ShapePathModel>(_members.InstanceMethods.InvokeVirtualObjectMethod("getShapedViewModel.()Lcom/google/android/material/shape/ShapePathModel;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setShapedViewModel", "(Lcom/google/android/material/shape/ShapePathModel;)V", "GetSetShapedViewModel_Lcom_google_android_material_shape_ShapePathModel_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setShapedViewModel.(Lcom/google/android/material/shape/ShapePathModel;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ColorStateList? StrokeColor
	{
		[Register("getStrokeColor", "()Landroid/content/res/ColorStateList;", "GetGetStrokeColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStrokeColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setStrokeColor", "(Landroid/content/res/ColorStateList;)V", "GetSetStrokeColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setStrokeColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ColorStateList? StrokeTintList
	{
		[Register("getStrokeTintList", "()Landroid/content/res/ColorStateList;", "GetGetStrokeTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getStrokeTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual float StrokeWidth
	{
		[Register("getStrokeWidth", "()F", "GetGetStrokeWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getStrokeWidth.()F", this, null);
		}
		[Register("setStrokeWidth", "(F)V", "GetSetStrokeWidth_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStrokeWidth.(F)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? TintList
	{
		[Register("getTintList", "()Landroid/content/res/ColorStateList;", "GetGetTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual float TopLeftCornerResolvedSize
	{
		[Register("getTopLeftCornerResolvedSize", "()F", "GetGetTopLeftCornerResolvedSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getTopLeftCornerResolvedSize.()F", this, null);
		}
	}

	public unsafe virtual float TopRightCornerResolvedSize
	{
		[Register("getTopRightCornerResolvedSize", "()F", "GetGetTopRightCornerResolvedSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getTopRightCornerResolvedSize.()F", this, null);
		}
	}

	public unsafe virtual float TranslationZ
	{
		[Register("getTranslationZ", "()F", "GetGetTranslationZHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getTranslationZ.()F", this, null);
		}
		[Register("setTranslationZ", "(F)V", "GetSetTranslationZ_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTranslationZ.(F)V", this, ptr);
		}
	}

	protected MaterialShapeDrawable(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe MaterialShapeDrawable()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;II)V", "")]
	public unsafe MaterialShapeDrawable(Context context, IAttributeSet? attrs, int defStyleAttr, int defStyleRes)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			ptr[3] = new JniArgumentValue(defStyleRes);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;II)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Lcom/google/android/material/shape/MaterialShapeDrawable$MaterialShapeDrawableState;)V", "")]
	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	protected unsafe MaterialShapeDrawable(MaterialShapeDrawableState drawableState)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawableState?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/material/shape/MaterialShapeDrawable$MaterialShapeDrawableState;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/material/shape/MaterialShapeDrawable$MaterialShapeDrawableState;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(drawableState);
		}
	}

	[Register(".ctor", "(Lcom/google/android/material/shape/ShapeAppearanceModel;)V", "")]
	public unsafe MaterialShapeDrawable(ShapeAppearanceModel shapeAppearanceModel)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(shapeAppearanceModel?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/material/shape/ShapeAppearanceModel;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/material/shape/ShapeAppearanceModel;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(shapeAppearanceModel);
		}
	}

	[Register(".ctor", "(Lcom/google/android/material/shape/ShapePathModel;)V", "")]
	[Obsolete("deprecated")]
	public unsafe MaterialShapeDrawable(ShapePathModel shapePathModel)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(shapePathModel?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Lcom/google/android/material/shape/ShapePathModel;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Lcom/google/android/material/shape/ShapePathModel;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(shapePathModel);
		}
	}

	private static Delegate GetGetBottomLeftCornerResolvedSizeHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetBottomLeftCornerResolvedSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetBottomLeftCornerResolvedSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BottomLeftCornerResolvedSize;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetBottomRightCornerResolvedSizeHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetBottomRightCornerResolvedSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetBottomRightCornerResolvedSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BottomRightCornerResolvedSize;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetBoundsAsRectFHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetBoundsAsRectF);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBoundsAsRectF(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BoundsAsRectF);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetElevationHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetElevation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetElevation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Elevation;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetElevation_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetElevation_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetElevation_F(nint jnienv, nint native__this, float elevation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Elevation = elevation;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetFillColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetFillColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetFillColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FillColor);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetFillColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetFillColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFillColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_fillColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList fillColor = Java.Lang.Object.GetObject<ColorStateList>(native_fillColor, JniHandleOwnership.DoNotTransfer);
			materialShapeDrawable.FillColor = fillColor;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetInterpolationHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetInterpolation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetInterpolation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Interpolation;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetInterpolation_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetInterpolation_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInterpolation_F(nint jnienv, nint native__this, float interpolation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Interpolation = interpolation;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsElevationOverlayEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsElevationOverlayEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsElevationOverlayEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsElevationOverlayEnabled ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsElevationOverlayInitializedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsElevationOverlayInitialized);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsElevationOverlayInitialized(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsElevationOverlayInitialized ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetIsRoundRectHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsRoundRect);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsRoundRect(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsRoundRect ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetOpacityHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetOpacity);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetOpacity(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Opacity;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetPaintStyleHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetPaintStyle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPaintStyle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PaintStyle);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetPaintStyle_Landroid_graphics_Paint_Style_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetPaintStyle_Landroid_graphics_Paint_Style_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPaintStyle_Landroid_graphics_Paint_Style_(nint jnienv, nint native__this, nint native_paintStyle)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Paint.Style paintStyle = Java.Lang.Object.GetObject<Paint.Style>(native_paintStyle, JniHandleOwnership.DoNotTransfer);
			materialShapeDrawable.PaintStyle = paintStyle;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetParentAbsoluteElevationHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetParentAbsoluteElevation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetParentAbsoluteElevation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ParentAbsoluteElevation;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetParentAbsoluteElevation_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetParentAbsoluteElevation_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetParentAbsoluteElevation_F(nint jnienv, nint native__this, float parentAbsoluteElevation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ParentAbsoluteElevation = parentAbsoluteElevation;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetResolvedTintColorHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetResolvedTintColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetResolvedTintColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResolvedTintColor;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetScaleHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetScale);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetScale(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Scale;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetScale_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetScale_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetScale_F(nint jnienv, nint native__this, float scale)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Scale = scale;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetShadowCompatRotationHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetShadowCompatRotation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetShadowCompatRotation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShadowCompatRotation;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetShadowCompatRotation_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetShadowCompatRotation_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShadowCompatRotation_I(nint jnienv, nint native__this, int shadowRotation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShadowCompatRotation = shadowRotation;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetShadowCompatibilityModeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetShadowCompatibilityMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetShadowCompatibilityMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShadowCompatibilityMode;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetShadowCompatibilityMode_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetShadowCompatibilityMode_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShadowCompatibilityMode_I(nint jnienv, nint native__this, int mode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShadowCompatibilityMode = mode;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete]
	private static Delegate GetGetShadowElevationHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetShadowElevation);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetShadowElevation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShadowElevation;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete]
	private static Delegate GetSetShadowElevation_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetShadowElevation_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShadowElevation_I(nint jnienv, nint native__this, int shadowElevation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShadowElevation = shadowElevation;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete]
	private static Delegate GetIsShadowEnabledHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsShadowEnabled);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsShadowEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShadowEnabled ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete]
	private static Delegate GetSetShadowEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetShadowEnabled_Z);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShadowEnabled_Z(nint jnienv, nint native__this, sbyte native_shadowEnabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool shadowEnabled = native_shadowEnabled != 0;
			materialShapeDrawable.ShadowEnabled = shadowEnabled;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetShadowOffsetXHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetShadowOffsetX);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetShadowOffsetX(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShadowOffsetX;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetShadowOffsetYHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetShadowOffsetY);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetShadowOffsetY(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShadowOffsetY;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetShadowRadiusHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetShadowRadius);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetShadowRadius(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShadowRadius;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete]
	private static Delegate GetSetShadowRadius_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetShadowRadius_I);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShadowRadius_I(nint jnienv, nint native__this, int shadowRadius)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShadowRadius = shadowRadius;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetShadowVerticalOffsetHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetShadowVerticalOffset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetShadowVerticalOffset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShadowVerticalOffset;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetShadowVerticalOffset_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetShadowVerticalOffset_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShadowVerticalOffset_I(nint jnienv, nint native__this, int shadowOffset)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShadowVerticalOffset = shadowOffset;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetShapeAppearanceModelHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetShapeAppearanceModel);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetShapeAppearanceModel(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShapeAppearanceModel);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_(nint jnienv, nint native__this, nint native_shapeAppearanceModel)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ShapeAppearanceModel shapeAppearanceModel = Java.Lang.Object.GetObject<ShapeAppearanceModel>(native_shapeAppearanceModel, JniHandleOwnership.DoNotTransfer);
			materialShapeDrawable.ShapeAppearanceModel = shapeAppearanceModel;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete]
	private static Delegate GetGetShapedViewModelHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetShapedViewModel);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetShapedViewModel(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShapedViewModel);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete]
	private static Delegate GetSetShapedViewModel_Lcom_google_android_material_shape_ShapePathModel_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetShapedViewModel_Lcom_google_android_material_shape_ShapePathModel_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShapedViewModel_Lcom_google_android_material_shape_ShapePathModel_(nint jnienv, nint native__this, nint native_shapedViewModel)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ShapePathModel shapedViewModel = Java.Lang.Object.GetObject<ShapePathModel>(native_shapedViewModel, JniHandleOwnership.DoNotTransfer);
			materialShapeDrawable.ShapedViewModel = shapedViewModel;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetStrokeColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetStrokeColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStrokeColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeColor);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetStrokeColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStrokeColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStrokeColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_strokeColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList strokeColor = Java.Lang.Object.GetObject<ColorStateList>(native_strokeColor, JniHandleOwnership.DoNotTransfer);
			materialShapeDrawable.StrokeColor = strokeColor;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetStrokeTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetStrokeTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStrokeTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeTintList);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetStrokeWidthHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetStrokeWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetStrokeWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeWidth;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetStrokeWidth_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetStrokeWidth_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStrokeWidth_F(nint jnienv, nint native__this, float strokeWidth)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StrokeWidth = strokeWidth;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TintList);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetTopLeftCornerResolvedSizeHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetTopLeftCornerResolvedSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetTopLeftCornerResolvedSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TopLeftCornerResolvedSize;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetTopRightCornerResolvedSizeHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetTopRightCornerResolvedSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetTopRightCornerResolvedSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TopRightCornerResolvedSize;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetGetTranslationZHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetTranslationZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetTranslationZ(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TranslationZ;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	private static Delegate GetSetTranslationZ_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetTranslationZ_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTranslationZ_F(nint jnienv, nint native__this, float translationZ)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TranslationZ = translationZ;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("calculatePathForSize", "(Landroid/graphics/RectF;Landroid/graphics/Path;)V", "")]
	protected unsafe void CalculatePathForSize(RectF bounds, Path path)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(bounds?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(path?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("calculatePathForSize.(Landroid/graphics/RectF;Landroid/graphics/Path;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(bounds);
			GC.KeepAlive(path);
		}
	}

	private static Delegate GetCompositeElevationOverlayIfNeeded_IHandler()
	{
		return new global::_JniMarshal_PPI_I(n_CompositeElevationOverlayIfNeeded_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_CompositeElevationOverlayIfNeeded_I(nint jnienv, nint native__this, int backgroundColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompositeElevationOverlayIfNeeded(backgroundColor);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("compositeElevationOverlayIfNeeded", "(I)I", "GetCompositeElevationOverlayIfNeeded_IHandler")]
	protected unsafe virtual int CompositeElevationOverlayIfNeeded(int backgroundColor)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(backgroundColor);
		return _members.InstanceMethods.InvokeVirtualInt32Method("compositeElevationOverlayIfNeeded.(I)I", this, ptr);
	}

	[Register("createWithElevationOverlay", "(Landroid/content/Context;)Lcom/google/android/material/shape/MaterialShapeDrawable;", "")]
	public unsafe static MaterialShapeDrawable CreateWithElevationOverlay(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(_members.StaticMethods.InvokeObjectMethod("createWithElevationOverlay.(Landroid/content/Context;)Lcom/google/android/material/shape/MaterialShapeDrawable;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("createWithElevationOverlay", "(Landroid/content/Context;F)Lcom/google/android/material/shape/MaterialShapeDrawable;", "")]
	public unsafe static MaterialShapeDrawable CreateWithElevationOverlay(Context context, float elevation)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(elevation);
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(_members.StaticMethods.InvokeObjectMethod("createWithElevationOverlay.(Landroid/content/Context;F)Lcom/google/android/material/shape/MaterialShapeDrawable;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("createWithElevationOverlay", "(Landroid/content/Context;FLandroid/content/res/ColorStateList;)Lcom/google/android/material/shape/MaterialShapeDrawable;", "")]
	public unsafe static MaterialShapeDrawable CreateWithElevationOverlay(Context context, float elevation, ColorStateList? backgroundTint)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(elevation);
			ptr[2] = new JniArgumentValue(backgroundTint?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(_members.StaticMethods.InvokeObjectMethod("createWithElevationOverlay.(Landroid/content/Context;FLandroid/content/res/ColorStateList;)Lcom/google/android/material/shape/MaterialShapeDrawable;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(backgroundTint);
		}
	}

	private static Delegate GetDraw_Landroid_graphics_Canvas_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Draw_Landroid_graphics_Canvas_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Draw_Landroid_graphics_Canvas_(nint jnienv, nint native__this, nint native_canvas)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_canvas, JniHandleOwnership.DoNotTransfer);
			materialShapeDrawable.Draw(canvas);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("draw", "(Landroid/graphics/Canvas;)V", "GetDraw_Landroid_graphics_Canvas_Handler")]
	public unsafe override void Draw(Canvas canvas)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(canvas?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("draw.(Landroid/graphics/Canvas;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(canvas);
		}
	}

	private static Delegate GetDrawShape_Landroid_graphics_Canvas_Landroid_graphics_Paint_Landroid_graphics_Path_Landroid_graphics_RectF_Handler()
	{
		return new global::_JniMarshal_PPLLLL_V(n_DrawShape_Landroid_graphics_Canvas_Landroid_graphics_Paint_Landroid_graphics_Path_Landroid_graphics_RectF_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DrawShape_Landroid_graphics_Canvas_Landroid_graphics_Paint_Landroid_graphics_Path_Landroid_graphics_RectF_(nint jnienv, nint native__this, nint native_canvas, nint native_paint, nint native_path, nint native_bounds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_canvas, JniHandleOwnership.DoNotTransfer);
			Paint paint = Java.Lang.Object.GetObject<Paint>(native_paint, JniHandleOwnership.DoNotTransfer);
			Path path = Java.Lang.Object.GetObject<Path>(native_path, JniHandleOwnership.DoNotTransfer);
			RectF bounds = Java.Lang.Object.GetObject<RectF>(native_bounds, JniHandleOwnership.DoNotTransfer);
			materialShapeDrawable.DrawShape(canvas, paint, path, bounds);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("drawShape", "(Landroid/graphics/Canvas;Landroid/graphics/Paint;Landroid/graphics/Path;Landroid/graphics/RectF;)V", "GetDrawShape_Landroid_graphics_Canvas_Landroid_graphics_Paint_Landroid_graphics_Path_Landroid_graphics_RectF_Handler")]
	protected unsafe virtual void DrawShape(Canvas canvas, Paint paint, Path path, RectF bounds)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(canvas?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(paint?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(path?.Handle ?? IntPtr.Zero);
			ptr[3] = new JniArgumentValue(bounds?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("drawShape.(Landroid/graphics/Canvas;Landroid/graphics/Paint;Landroid/graphics/Path;Landroid/graphics/RectF;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(canvas);
			GC.KeepAlive(paint);
			GC.KeepAlive(path);
			GC.KeepAlive(bounds);
		}
	}

	private static Delegate GetDrawStrokeShape_Landroid_graphics_Canvas_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_DrawStrokeShape_Landroid_graphics_Canvas_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_DrawStrokeShape_Landroid_graphics_Canvas_(nint jnienv, nint native__this, nint native_canvas)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_canvas, JniHandleOwnership.DoNotTransfer);
			materialShapeDrawable.DrawStrokeShape(canvas);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("drawStrokeShape", "(Landroid/graphics/Canvas;)V", "GetDrawStrokeShape_Landroid_graphics_Canvas_Handler")]
	protected unsafe virtual void DrawStrokeShape(Canvas canvas)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(canvas?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("drawStrokeShape.(Landroid/graphics/Canvas;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(canvas);
		}
	}

	[Obsolete]
	private static Delegate GetGetPathForSize_IILandroid_graphics_Path_Handler()
	{
		return new global::_JniMarshal_PPIIL_V(n_GetPathForSize_IILandroid_graphics_Path_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetPathForSize_IILandroid_graphics_Path_(nint jnienv, nint native__this, int width, int height, nint native_path)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Path path = Java.Lang.Object.GetObject<Path>(native_path, JniHandleOwnership.DoNotTransfer);
			materialShapeDrawable.GetPathForSize(width, height, path);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("deprecated")]
	[Register("getPathForSize", "(IILandroid/graphics/Path;)V", "GetGetPathForSize_IILandroid_graphics_Path_Handler")]
	public unsafe virtual void GetPathForSize(int width, int height, Path path)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(width);
			ptr[1] = new JniArgumentValue(height);
			ptr[2] = new JniArgumentValue(path?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getPathForSize.(IILandroid/graphics/Path;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(path);
		}
	}

	private static Delegate GetGetZHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetZ(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetZ();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("getZ", "()F", "GetGetZHandler")]
	public unsafe virtual float GetZ()
	{
		return _members.InstanceMethods.InvokeVirtualSingleMethod("getZ.()F", this, null);
	}

	private static Delegate GetInitializeElevationOverlay_Landroid_content_Context_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_InitializeElevationOverlay_Landroid_content_Context_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_InitializeElevationOverlay_Landroid_content_Context_(nint jnienv, nint native__this, nint native_context)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			materialShapeDrawable.InitializeElevationOverlay(context);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("initializeElevationOverlay", "(Landroid/content/Context;)V", "GetInitializeElevationOverlay_Landroid_content_Context_Handler")]
	public unsafe virtual void InitializeElevationOverlay(Context? context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("initializeElevationOverlay.(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	private static Delegate GetIsPointInTransparentRegion_IIHandler()
	{
		return new global::_JniMarshal_PPII_B(n_IsPointInTransparentRegion_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsPointInTransparentRegion_II(nint jnienv, nint native__this, int x, int y)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsPointInTransparentRegion(x, y) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("isPointInTransparentRegion", "(II)Z", "GetIsPointInTransparentRegion_IIHandler")]
	public unsafe virtual bool IsPointInTransparentRegion(int x, int y)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(x);
		ptr[1] = new JniArgumentValue(y);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPointInTransparentRegion.(II)Z", this, ptr);
	}

	private static Delegate GetRequiresCompatShadowHandler()
	{
		return new global::_JniMarshal_PP_B(n_RequiresCompatShadow);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_RequiresCompatShadow(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RequiresCompatShadow() ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("requiresCompatShadow", "()Z", "GetRequiresCompatShadowHandler")]
	public unsafe virtual bool RequiresCompatShadow()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("requiresCompatShadow.()Z", this, null);
	}

	private static Delegate GetSetAlpha_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetAlpha_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAlpha_I(nint jnienv, nint native__this, int alpha)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAlpha(alpha);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setAlpha", "(I)V", "GetSetAlpha_IHandler")]
	public unsafe override void SetAlpha(int alpha)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(alpha);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setAlpha.(I)V", this, ptr);
	}

	private static Delegate GetSetColorFilter_Landroid_graphics_ColorFilter_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetColorFilter_Landroid_graphics_ColorFilter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetColorFilter_Landroid_graphics_ColorFilter_(nint jnienv, nint native__this, nint native_colorFilter)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorFilter colorFilter = Java.Lang.Object.GetObject<ColorFilter>(native_colorFilter, JniHandleOwnership.DoNotTransfer);
			materialShapeDrawable.SetColorFilter(colorFilter);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setColorFilter", "(Landroid/graphics/ColorFilter;)V", "GetSetColorFilter_Landroid_graphics_ColorFilter_Handler")]
	public unsafe override void SetColorFilter(ColorFilter? colorFilter)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(colorFilter?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setColorFilter.(Landroid/graphics/ColorFilter;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(colorFilter);
		}
	}

	private static Delegate GetSetCornerSize_Lcom_google_android_material_shape_CornerSize_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCornerSize_Lcom_google_android_material_shape_CornerSize_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCornerSize_Lcom_google_android_material_shape_CornerSize_(nint jnienv, nint native__this, nint native_cornerSize)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICornerSize cornerSize = Java.Lang.Object.GetObject<ICornerSize>(native_cornerSize, JniHandleOwnership.DoNotTransfer);
			materialShapeDrawable.SetCornerSize(cornerSize);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setCornerSize", "(Lcom/google/android/material/shape/CornerSize;)V", "GetSetCornerSize_Lcom_google_android_material_shape_CornerSize_Handler")]
	public unsafe virtual void SetCornerSize(ICornerSize cornerSize)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((cornerSize == null) ? IntPtr.Zero : ((Java.Lang.Object)cornerSize).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCornerSize.(Lcom/google/android/material/shape/CornerSize;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cornerSize);
		}
	}

	private static Delegate GetSetCornerSize_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetCornerSize_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCornerSize_F(nint jnienv, nint native__this, float cornerSize)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCornerSize(cornerSize);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setCornerSize", "(F)V", "GetSetCornerSize_FHandler")]
	public unsafe virtual void SetCornerSize(float cornerSize)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(cornerSize);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCornerSize.(F)V", this, ptr);
	}

	private static Delegate GetSetEdgeIntersectionCheckEnable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetEdgeIntersectionCheckEnable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEdgeIntersectionCheckEnable_Z(nint jnienv, nint native__this, sbyte native_enable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool edgeIntersectionCheckEnable = native_enable != 0;
			materialShapeDrawable.SetEdgeIntersectionCheckEnable(edgeIntersectionCheckEnable);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("setEdgeIntersectionCheckEnable", "(Z)V", "GetSetEdgeIntersectionCheckEnable_ZHandler")]
	public unsafe virtual void SetEdgeIntersectionCheckEnable(bool enable)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enable ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setEdgeIntersectionCheckEnable.(Z)V", this, ptr);
	}

	private static Delegate GetSetPadding_IIIIHandler()
	{
		return new global::_JniMarshal_PPIIII_V(n_SetPadding_IIII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetPadding_IIII(nint jnienv, nint native__this, int left, int top, int right, int bottom)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPadding(left, top, right, bottom);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setPadding", "(IIII)V", "GetSetPadding_IIIIHandler")]
	public unsafe virtual void SetPadding(int left, int top, int right, int bottom)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue(left);
		ptr[1] = new JniArgumentValue(top);
		ptr[2] = new JniArgumentValue(right);
		ptr[3] = new JniArgumentValue(bottom);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setPadding.(IIII)V", this, ptr);
	}

	private static Delegate GetSetShadowBitmapDrawingEnable_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetShadowBitmapDrawingEnable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShadowBitmapDrawingEnable_Z(nint jnienv, nint native__this, sbyte native_enable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool shadowBitmapDrawingEnable = native_enable != 0;
			materialShapeDrawable.SetShadowBitmapDrawingEnable(shadowBitmapDrawingEnable);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Obsolete("While this member is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
	[Register("setShadowBitmapDrawingEnable", "(Z)V", "GetSetShadowBitmapDrawingEnable_ZHandler")]
	public unsafe virtual void SetShadowBitmapDrawingEnable(bool enable)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enable ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setShadowBitmapDrawingEnable.(Z)V", this, ptr);
	}

	private static Delegate GetSetShadowColor_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetShadowColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShadowColor_I(nint jnienv, nint native__this, int shadowColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetShadowColor(shadowColor);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setShadowColor", "(I)V", "GetSetShadowColor_IHandler")]
	public unsafe virtual void SetShadowColor(int shadowColor)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(shadowColor);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setShadowColor.(I)V", this, ptr);
	}

	private static Delegate GetSetStroke_FLandroid_content_res_ColorStateList_Handler()
	{
		return new _JniMarshal_PPFL_V(n_SetStroke_FLandroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStroke_FLandroid_content_res_ColorStateList_(nint jnienv, nint native__this, float strokeWidth, nint native_strokeColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList strokeColor = Java.Lang.Object.GetObject<ColorStateList>(native_strokeColor, JniHandleOwnership.DoNotTransfer);
			materialShapeDrawable.SetStroke(strokeWidth, strokeColor);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setStroke", "(FLandroid/content/res/ColorStateList;)V", "GetSetStroke_FLandroid_content_res_ColorStateList_Handler")]
	public unsafe virtual void SetStroke(float strokeWidth, ColorStateList? strokeColor)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(strokeWidth);
			ptr[1] = new JniArgumentValue(strokeColor?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStroke.(FLandroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(strokeColor);
		}
	}

	private static Delegate GetSetStroke_FIHandler()
	{
		return new _JniMarshal_PPFI_V(n_SetStroke_FI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStroke_FI(nint jnienv, nint native__this, float strokeWidth, int strokeColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStroke(strokeWidth, strokeColor);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setStroke", "(FI)V", "GetSetStroke_FIHandler")]
	public unsafe virtual void SetStroke(float strokeWidth, int strokeColor)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(strokeWidth);
		ptr[1] = new JniArgumentValue(strokeColor);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setStroke.(FI)V", this, ptr);
	}

	private static Delegate GetSetStrokeTint_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetStrokeTint_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStrokeTint_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_tintList)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList strokeTint = Java.Lang.Object.GetObject<ColorStateList>(native_tintList, JniHandleOwnership.DoNotTransfer);
			materialShapeDrawable.SetStrokeTint(strokeTint);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setStrokeTint", "(Landroid/content/res/ColorStateList;)V", "GetSetStrokeTint_Landroid_content_res_ColorStateList_Handler")]
	public unsafe virtual void SetStrokeTint(ColorStateList? tintList)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tintList?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStrokeTint.(Landroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tintList);
		}
	}

	private static Delegate GetSetStrokeTint_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetStrokeTint_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStrokeTint_I(nint jnienv, nint native__this, int tintColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetStrokeTint(tintColor);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setStrokeTint", "(I)V", "GetSetStrokeTint_IHandler")]
	public unsafe virtual void SetStrokeTint(int tintColor)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(tintColor);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setStrokeTint.(I)V", this, ptr);
	}

	private static Delegate GetSetUseTintColorForShadow_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetUseTintColorForShadow_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetUseTintColorForShadow_Z(nint jnienv, nint native__this, sbyte native_useTintColorForShadow)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			MaterialShapeDrawable? materialShapeDrawable = Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool useTintColorForShadow = native_useTintColorForShadow != 0;
			materialShapeDrawable.SetUseTintColorForShadow(useTintColorForShadow);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setUseTintColorForShadow", "(Z)V", "GetSetUseTintColorForShadow_ZHandler")]
	public unsafe virtual void SetUseTintColorForShadow(bool useTintColorForShadow)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(useTintColorForShadow ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setUseTintColorForShadow.(Z)V", this, ptr);
	}

	private static Delegate GetSetZ_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetZ_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetZ_F(nint jnienv, nint native__this, float z)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<MaterialShapeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetZ(z);
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("setZ", "(F)V", "GetSetZ_FHandler")]
	public unsafe virtual void SetZ(float z)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(z);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setZ.(F)V", this, ptr);
	}

	int IJavaPeerable.get_JniIdentityHashCode()
	{
		return base.JniIdentityHashCode;
	}

	JniObjectReference IJavaPeerable.get_PeerReference()
	{
		return base.PeerReference;
	}

	void IJavaPeerable.UnregisterFromRuntime()
	{
		UnregisterFromRuntime();
	}
}
