using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Content.Res;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.Slider;

[Register("com/google/android/material/slider/Slider", DoNotGenerateAcw = true)]
public class Slider : View
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/slider/Slider", typeof(Slider));

	private static Delegate? cb_getAccessibilityClassName_GetAccessibilityClassName_Ljava_lang_CharSequence_;

	private static Delegate? cb_getActiveThumbIndex_GetActiveThumbIndex_I;

	private static Delegate? cb_getFocusedThumbIndex_GetFocusedThumbIndex_I;

	private static Delegate? cb_setFocusedThumbIndex_SetFocusedThumbIndex_I_V;

	private static Delegate? cb_getHaloRadius_GetHaloRadius_I;

	private static Delegate? cb_setHaloRadius_SetHaloRadius_I_V;

	private static Delegate? cb_getHaloTintList_GetHaloTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setHaloTintList_SetHaloTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_hasLabelFormatter_HasLabelFormatter_Z;

	private static Delegate? cb_getLabelBehavior_GetLabelBehavior_I;

	private static Delegate? cb_setLabelBehavior_SetLabelBehavior_I_V;

	private static Delegate? cb_getMinSeparation_GetMinSeparation_F;

	private static Delegate? cb_getStepSize_GetStepSize_F;

	private static Delegate? cb_setStepSize_SetStepSize_F_V;

	private static Delegate? cb_getThumbElevation_GetThumbElevation_F;

	private static Delegate? cb_setThumbElevation_SetThumbElevation_F_V;

	private static Delegate? cb_getThumbHeight_GetThumbHeight_I;

	private static Delegate? cb_setThumbHeight_SetThumbHeight_I_V;

	private static Delegate? cb_getThumbRadius_GetThumbRadius_I;

	private static Delegate? cb_setThumbRadius_SetThumbRadius_I_V;

	private static Delegate? cb_getThumbStrokeColor_GetThumbStrokeColor_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setThumbStrokeColor_SetThumbStrokeColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getThumbStrokeWidth_GetThumbStrokeWidth_F;

	private static Delegate? cb_setThumbStrokeWidth_SetThumbStrokeWidth_F_V;

	private static Delegate? cb_getThumbTintList_GetThumbTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setThumbTintList_SetThumbTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getThumbTrackGapSize_GetThumbTrackGapSize_I;

	private static Delegate? cb_setThumbTrackGapSize_SetThumbTrackGapSize_I_V;

	private static Delegate? cb_getThumbWidth_GetThumbWidth_I;

	private static Delegate? cb_setThumbWidth_SetThumbWidth_I_V;

	private static Delegate? cb_getTickActiveRadius_GetTickActiveRadius_I;

	private static Delegate? cb_setTickActiveRadius_SetTickActiveRadius_I_V;

	private static Delegate? cb_getTickActiveTintList_GetTickActiveTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setTickActiveTintList_SetTickActiveTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getTickInactiveRadius_GetTickInactiveRadius_I;

	private static Delegate? cb_setTickInactiveRadius_SetTickInactiveRadius_I_V;

	private static Delegate? cb_getTickInactiveTintList_GetTickInactiveTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setTickInactiveTintList_SetTickInactiveTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getTickTintList_GetTickTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setTickTintList_SetTickTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_isTickVisible_IsTickVisible_Z;

	private static Delegate? cb_setTickVisible_SetTickVisible_Z_V;

	private static Delegate? cb_getTrackActiveTintList_GetTrackActiveTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setTrackActiveTintList_SetTrackActiveTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getTrackHeight_GetTrackHeight_I;

	private static Delegate? cb_setTrackHeight_SetTrackHeight_I_V;

	private static Delegate? cb_getTrackInactiveTintList_GetTrackInactiveTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setTrackInactiveTintList_SetTrackInactiveTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getTrackInsideCornerSize_GetTrackInsideCornerSize_I;

	private static Delegate? cb_setTrackInsideCornerSize_SetTrackInsideCornerSize_I_V;

	private static Delegate? cb_getTrackSidePadding_GetTrackSidePadding_I;

	private static Delegate? cb_getTrackStopIndicatorSize_GetTrackStopIndicatorSize_I;

	private static Delegate? cb_setTrackStopIndicatorSize_SetTrackStopIndicatorSize_I_V;

	private static Delegate? cb_getTrackTintList_GetTrackTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setTrackTintList_SetTrackTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getTrackWidth_GetTrackWidth_I;

	private static Delegate? cb_getValue_GetValue_F;

	private static Delegate? cb_setValue_SetValue_F_V;

	private static Delegate? cb_getValueFrom_GetValueFrom_F;

	private static Delegate? cb_setValueFrom_SetValueFrom_F_V;

	private static Delegate? cb_getValueTo_GetValueTo_F;

	private static Delegate? cb_setValueTo_SetValueTo_F_V;

	private static Delegate? cb_clearOnChangeListeners_ClearOnChangeListeners_V;

	private static Delegate? cb_clearOnSliderTouchListeners_ClearOnSliderTouchListeners_V;

	private static Delegate? cb_dispatchHoverEvent_DispatchHoverEvent_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_dispatchKeyEvent_DispatchKeyEvent_Landroid_view_KeyEvent__Z;

	private static Delegate? cb_onKeyDown_OnKeyDown_ILandroid_view_KeyEvent__Z;

	private static Delegate? cb_onKeyUp_OnKeyUp_ILandroid_view_KeyEvent__Z;

	private static Delegate? cb_onTouchEvent_OnTouchEvent_Landroid_view_MotionEvent__Z;

	private static Delegate? cb_pickActiveThumb_PickActiveThumb_Z;

	private static Delegate? cb_setCustomThumbDrawable_SetCustomThumbDrawable_Landroid_graphics_drawable_Drawable__V;

	private static Delegate? cb_setCustomThumbDrawable_SetCustomThumbDrawable_I_V;

	private static Delegate? cb_setEnabled_SetEnabled_Z_V;

	private static Delegate? cb_setHaloRadiusResource_SetHaloRadiusResource_I_V;

	private static Delegate? cb_setLabelFormatter_SetLabelFormatter_Lcom_google_android_material_slider_LabelFormatter__V;

	private static Delegate? cb_setThumbElevationResource_SetThumbElevationResource_I_V;

	private static Delegate? cb_setThumbHeightResource_SetThumbHeightResource_I_V;

	private static Delegate? cb_setThumbRadiusResource_SetThumbRadiusResource_I_V;

	private static Delegate? cb_setThumbStrokeColorResource_SetThumbStrokeColorResource_I_V;

	private static Delegate? cb_setThumbStrokeWidthResource_SetThumbStrokeWidthResource_I_V;

	private static Delegate? cb_setThumbWidthResource_SetThumbWidthResource_I_V;

	private static Delegate? cb_setActiveThumbIndex_SetActiveThumbIndex_I_V;

	private static Delegate? cb_setSeparationUnit_SetSeparationUnit_I_V;

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

	public unsafe override ICharSequence AccessibilityClassNameFormatted
	{
		[Register("getAccessibilityClassName", "()Ljava/lang/CharSequence;", "GetGetAccessibilityClassNameHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAccessibilityClassName.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int ActiveThumbIndex
	{
		[Register("getActiveThumbIndex", "()I", "GetGetActiveThumbIndexHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getActiveThumbIndex.()I", this, null);
		}
	}

	public unsafe virtual int FocusedThumbIndex
	{
		[Register("getFocusedThumbIndex", "()I", "GetGetFocusedThumbIndexHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getFocusedThumbIndex.()I", this, null);
		}
		[Register("setFocusedThumbIndex", "(I)V", "GetSetFocusedThumbIndex_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFocusedThumbIndex.(I)V", this, ptr);
		}
	}

	public unsafe virtual int HaloRadius
	{
		[Register("getHaloRadius", "()I", "GetGetHaloRadiusHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getHaloRadius.()I", this, null);
		}
		[Register("setHaloRadius", "(I)V", "GetSetHaloRadius_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHaloRadius.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList HaloTintList
	{
		[Register("getHaloTintList", "()Landroid/content/res/ColorStateList;", "GetGetHaloTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHaloTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setHaloTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetHaloTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHaloTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool HasLabelFormatter
	{
		[Register("hasLabelFormatter", "()Z", "GetHasLabelFormatterHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasLabelFormatter.()Z", this, null);
		}
	}

	public unsafe virtual int LabelBehavior
	{
		[Register("getLabelBehavior", "()I", "GetGetLabelBehaviorHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLabelBehavior.()I", this, null);
		}
		[Register("setLabelBehavior", "(I)V", "GetSetLabelBehavior_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLabelBehavior.(I)V", this, ptr);
		}
	}

	protected unsafe virtual float MinSeparation
	{
		[Register("getMinSeparation", "()F", "GetGetMinSeparationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getMinSeparation.()F", this, null);
		}
	}

	public unsafe virtual float StepSize
	{
		[Register("getStepSize", "()F", "GetGetStepSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getStepSize.()F", this, null);
		}
		[Register("setStepSize", "(F)V", "GetSetStepSize_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStepSize.(F)V", this, ptr);
		}
	}

	public unsafe virtual float ThumbElevation
	{
		[Register("getThumbElevation", "()F", "GetGetThumbElevationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getThumbElevation.()F", this, null);
		}
		[Register("setThumbElevation", "(F)V", "GetSetThumbElevation_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbElevation.(F)V", this, ptr);
		}
	}

	public unsafe virtual int ThumbHeight
	{
		[Register("getThumbHeight", "()I", "GetGetThumbHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getThumbHeight.()I", this, null);
		}
		[Register("setThumbHeight", "(I)V", "GetSetThumbHeight_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbHeight.(I)V", this, ptr);
		}
	}

	public unsafe virtual int ThumbRadius
	{
		[Register("getThumbRadius", "()I", "GetGetThumbRadiusHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getThumbRadius.()I", this, null);
		}
		[Register("setThumbRadius", "(I)V", "GetSetThumbRadius_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbRadius.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? ThumbStrokeColor
	{
		[Register("getThumbStrokeColor", "()Landroid/content/res/ColorStateList;", "GetGetThumbStrokeColorHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getThumbStrokeColor.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setThumbStrokeColor", "(Landroid/content/res/ColorStateList;)V", "GetSetThumbStrokeColor_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbStrokeColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual float ThumbStrokeWidth
	{
		[Register("getThumbStrokeWidth", "()F", "GetGetThumbStrokeWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getThumbStrokeWidth.()F", this, null);
		}
		[Register("setThumbStrokeWidth", "(F)V", "GetSetThumbStrokeWidth_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbStrokeWidth.(F)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList ThumbTintList
	{
		[Register("getThumbTintList", "()Landroid/content/res/ColorStateList;", "GetGetThumbTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getThumbTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setThumbTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetThumbTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int ThumbTrackGapSize
	{
		[Register("getThumbTrackGapSize", "()I", "GetGetThumbTrackGapSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getThumbTrackGapSize.()I", this, null);
		}
		[Register("setThumbTrackGapSize", "(I)V", "GetSetThumbTrackGapSize_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbTrackGapSize.(I)V", this, ptr);
		}
	}

	public unsafe virtual int ThumbWidth
	{
		[Register("getThumbWidth", "()I", "GetGetThumbWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getThumbWidth.()I", this, null);
		}
		[Register("setThumbWidth", "(I)V", "GetSetThumbWidth_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbWidth.(I)V", this, ptr);
		}
	}

	public unsafe virtual int TickActiveRadius
	{
		[Register("getTickActiveRadius", "()I", "GetGetTickActiveRadiusHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTickActiveRadius.()I", this, null);
		}
		[Register("setTickActiveRadius", "(I)V", "GetSetTickActiveRadius_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTickActiveRadius.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList TickActiveTintList
	{
		[Register("getTickActiveTintList", "()Landroid/content/res/ColorStateList;", "GetGetTickActiveTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTickActiveTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTickActiveTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetTickActiveTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTickActiveTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int TickInactiveRadius
	{
		[Register("getTickInactiveRadius", "()I", "GetGetTickInactiveRadiusHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTickInactiveRadius.()I", this, null);
		}
		[Register("setTickInactiveRadius", "(I)V", "GetSetTickInactiveRadius_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTickInactiveRadius.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList TickInactiveTintList
	{
		[Register("getTickInactiveTintList", "()Landroid/content/res/ColorStateList;", "GetGetTickInactiveTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTickInactiveTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTickInactiveTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetTickInactiveTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTickInactiveTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ColorStateList TickTintList
	{
		[Register("getTickTintList", "()Landroid/content/res/ColorStateList;", "GetGetTickTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTickTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTickTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetTickTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTickTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool TickVisible
	{
		[Register("isTickVisible", "()Z", "GetIsTickVisibleHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isTickVisible.()Z", this, null);
		}
		[Register("setTickVisible", "(Z)V", "GetSetTickVisible_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTickVisible.(Z)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList TrackActiveTintList
	{
		[Register("getTrackActiveTintList", "()Landroid/content/res/ColorStateList;", "GetGetTrackActiveTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTrackActiveTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTrackActiveTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetTrackActiveTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTrackActiveTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int TrackHeight
	{
		[Register("getTrackHeight", "()I", "GetGetTrackHeightHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTrackHeight.()I", this, null);
		}
		[Register("setTrackHeight", "(I)V", "GetSetTrackHeight_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTrackHeight.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList TrackInactiveTintList
	{
		[Register("getTrackInactiveTintList", "()Landroid/content/res/ColorStateList;", "GetGetTrackInactiveTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTrackInactiveTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTrackInactiveTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetTrackInactiveTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTrackInactiveTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int TrackInsideCornerSize
	{
		[Register("getTrackInsideCornerSize", "()I", "GetGetTrackInsideCornerSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTrackInsideCornerSize.()I", this, null);
		}
		[Register("setTrackInsideCornerSize", "(I)V", "GetSetTrackInsideCornerSize_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTrackInsideCornerSize.(I)V", this, ptr);
		}
	}

	public unsafe virtual int TrackSidePadding
	{
		[Register("getTrackSidePadding", "()I", "GetGetTrackSidePaddingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTrackSidePadding.()I", this, null);
		}
	}

	public unsafe virtual int TrackStopIndicatorSize
	{
		[Register("getTrackStopIndicatorSize", "()I", "GetGetTrackStopIndicatorSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTrackStopIndicatorSize.()I", this, null);
		}
		[Register("setTrackStopIndicatorSize", "(I)V", "GetSetTrackStopIndicatorSize_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setTrackStopIndicatorSize.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList TrackTintList
	{
		[Register("getTrackTintList", "()Landroid/content/res/ColorStateList;", "GetGetTrackTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTrackTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setTrackTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetTrackTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setTrackTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int TrackWidth
	{
		[Register("getTrackWidth", "()I", "GetGetTrackWidthHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getTrackWidth.()I", this, null);
		}
	}

	public unsafe virtual float Value
	{
		[Register("getValue", "()F", "GetGetValueHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getValue.()F", this, null);
		}
		[Register("setValue", "(F)V", "GetSetValue_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setValue.(F)V", this, ptr);
		}
	}

	public unsafe virtual float ValueFrom
	{
		[Register("getValueFrom", "()F", "GetGetValueFromHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getValueFrom.()F", this, null);
		}
		[Register("setValueFrom", "(F)V", "GetSetValueFrom_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setValueFrom.(F)V", this, ptr);
		}
	}

	public unsafe virtual float ValueTo
	{
		[Register("getValueTo", "()F", "GetGetValueToHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getValueTo.()F", this, null);
		}
		[Register("setValueTo", "(F)V", "GetSetValueTo_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setValueTo.(F)V", this, ptr);
		}
	}

	protected Slider(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe Slider(Context context)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;)V", "")]
	public unsafe Slider(Context context, IAttributeSet? attrs)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	[Register(".ctor", "(Landroid/content/Context;Landroid/util/AttributeSet;I)V", "")]
	public unsafe Slider(Context context, IAttributeSet? attrs, int defStyleAttr)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((attrs == null) ? IntPtr.Zero : ((Java.Lang.Object)attrs).Handle);
			ptr[2] = new JniArgumentValue(defStyleAttr);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroid/util/AttributeSet;I)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
			GC.KeepAlive(attrs);
		}
	}

	private static Delegate GetGetAccessibilityClassNameHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetAccessibilityClassName);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAccessibilityClassName(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AccessibilityClassNameFormatted);
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

	private static Delegate GetGetActiveThumbIndexHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetActiveThumbIndex);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetActiveThumbIndex(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ActiveThumbIndex;
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

	private static Delegate GetGetFocusedThumbIndexHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetFocusedThumbIndex);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetFocusedThumbIndex(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FocusedThumbIndex;
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

	private static Delegate GetSetFocusedThumbIndex_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetFocusedThumbIndex_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetFocusedThumbIndex_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FocusedThumbIndex = p0;
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

	private static Delegate GetGetHaloRadiusHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetHaloRadius);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHaloRadius(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HaloRadius;
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

	private static Delegate GetSetHaloRadius_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetHaloRadius_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHaloRadius_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HaloRadius = p0;
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

	private static Delegate GetGetHaloTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetHaloTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetHaloTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HaloTintList);
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

	private static Delegate GetSetHaloTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetHaloTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHaloTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList haloTintList = Java.Lang.Object.GetObject<ColorStateList>(native_p0, JniHandleOwnership.DoNotTransfer);
			slider.HaloTintList = haloTintList;
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

	private static Delegate GetHasLabelFormatterHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasLabelFormatter);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasLabelFormatter(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasLabelFormatter ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetLabelBehaviorHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetLabelBehavior);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLabelBehavior(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LabelBehavior;
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

	private static Delegate GetSetLabelBehavior_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetLabelBehavior_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLabelBehavior_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LabelBehavior = p0;
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

	private static Delegate GetGetMinSeparationHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetMinSeparation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetMinSeparation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinSeparation;
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

	private static Delegate GetGetStepSizeHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetStepSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetStepSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StepSize;
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

	private static Delegate GetSetStepSize_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetStepSize_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStepSize_F(nint jnienv, nint native__this, float p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StepSize = p0;
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

	private static Delegate GetGetThumbElevationHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetThumbElevation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetThumbElevation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbElevation;
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

	private static Delegate GetSetThumbElevation_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetThumbElevation_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbElevation_F(nint jnienv, nint native__this, float p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbElevation = p0;
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

	private static Delegate GetGetThumbHeightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetThumbHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetThumbHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbHeight;
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

	private static Delegate GetSetThumbHeight_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetThumbHeight_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbHeight_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbHeight = p0;
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

	private static Delegate GetGetThumbRadiusHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetThumbRadius);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetThumbRadius(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbRadius;
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

	private static Delegate GetSetThumbRadius_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetThumbRadius_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbRadius_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbRadius = p0;
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

	private static Delegate GetGetThumbStrokeColorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetThumbStrokeColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetThumbStrokeColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbStrokeColor);
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

	private static Delegate GetSetThumbStrokeColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetThumbStrokeColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbStrokeColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList thumbStrokeColor = Java.Lang.Object.GetObject<ColorStateList>(native_p0, JniHandleOwnership.DoNotTransfer);
			slider.ThumbStrokeColor = thumbStrokeColor;
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

	private static Delegate GetGetThumbStrokeWidthHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetThumbStrokeWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetThumbStrokeWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbStrokeWidth;
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

	private static Delegate GetSetThumbStrokeWidth_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetThumbStrokeWidth_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbStrokeWidth_F(nint jnienv, nint native__this, float p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbStrokeWidth = p0;
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

	private static Delegate GetGetThumbTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetThumbTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetThumbTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbTintList);
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

	private static Delegate GetSetThumbTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetThumbTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList thumbTintList = Java.Lang.Object.GetObject<ColorStateList>(native_p0, JniHandleOwnership.DoNotTransfer);
			slider.ThumbTintList = thumbTintList;
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

	private static Delegate GetGetThumbTrackGapSizeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetThumbTrackGapSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetThumbTrackGapSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbTrackGapSize;
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

	private static Delegate GetSetThumbTrackGapSize_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetThumbTrackGapSize_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbTrackGapSize_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbTrackGapSize = p0;
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

	private static Delegate GetGetThumbWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetThumbWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetThumbWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbWidth;
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

	private static Delegate GetSetThumbWidth_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetThumbWidth_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbWidth_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThumbWidth = p0;
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

	private static Delegate GetGetTickActiveRadiusHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTickActiveRadius);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTickActiveRadius(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TickActiveRadius;
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

	private static Delegate GetSetTickActiveRadius_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTickActiveRadius_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTickActiveRadius_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TickActiveRadius = p0;
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

	private static Delegate GetGetTickActiveTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTickActiveTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTickActiveTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TickActiveTintList);
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

	private static Delegate GetSetTickActiveTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTickActiveTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTickActiveTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList tickActiveTintList = Java.Lang.Object.GetObject<ColorStateList>(native_p0, JniHandleOwnership.DoNotTransfer);
			slider.TickActiveTintList = tickActiveTintList;
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

	private static Delegate GetGetTickInactiveRadiusHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTickInactiveRadius);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTickInactiveRadius(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TickInactiveRadius;
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

	private static Delegate GetSetTickInactiveRadius_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTickInactiveRadius_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTickInactiveRadius_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TickInactiveRadius = p0;
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

	private static Delegate GetGetTickInactiveTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTickInactiveTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTickInactiveTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TickInactiveTintList);
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

	private static Delegate GetSetTickInactiveTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTickInactiveTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTickInactiveTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList tickInactiveTintList = Java.Lang.Object.GetObject<ColorStateList>(native_p0, JniHandleOwnership.DoNotTransfer);
			slider.TickInactiveTintList = tickInactiveTintList;
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

	private static Delegate GetGetTickTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTickTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTickTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TickTintList);
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

	private static Delegate GetSetTickTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTickTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTickTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList tickTintList = Java.Lang.Object.GetObject<ColorStateList>(native_p0, JniHandleOwnership.DoNotTransfer);
			slider.TickTintList = tickTintList;
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

	private static Delegate GetIsTickVisibleHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsTickVisible);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsTickVisible(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TickVisible ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetTickVisible_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetTickVisible_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTickVisible_Z(nint jnienv, nint native__this, sbyte native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool tickVisible = native_p0 != 0;
			slider.TickVisible = tickVisible;
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

	private static Delegate GetGetTrackActiveTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTrackActiveTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTrackActiveTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrackActiveTintList);
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

	private static Delegate GetSetTrackActiveTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTrackActiveTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTrackActiveTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList trackActiveTintList = Java.Lang.Object.GetObject<ColorStateList>(native_p0, JniHandleOwnership.DoNotTransfer);
			slider.TrackActiveTintList = trackActiveTintList;
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

	private static Delegate GetGetTrackHeightHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTrackHeight);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTrackHeight(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrackHeight;
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

	private static Delegate GetSetTrackHeight_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTrackHeight_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTrackHeight_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrackHeight = p0;
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

	private static Delegate GetGetTrackInactiveTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTrackInactiveTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTrackInactiveTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrackInactiveTintList);
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

	private static Delegate GetSetTrackInactiveTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTrackInactiveTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTrackInactiveTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList trackInactiveTintList = Java.Lang.Object.GetObject<ColorStateList>(native_p0, JniHandleOwnership.DoNotTransfer);
			slider.TrackInactiveTintList = trackInactiveTintList;
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

	private static Delegate GetGetTrackInsideCornerSizeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTrackInsideCornerSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTrackInsideCornerSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrackInsideCornerSize;
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

	private static Delegate GetSetTrackInsideCornerSize_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTrackInsideCornerSize_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTrackInsideCornerSize_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrackInsideCornerSize = p0;
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

	private static Delegate GetGetTrackSidePaddingHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTrackSidePadding);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTrackSidePadding(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrackSidePadding;
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

	private static Delegate GetGetTrackStopIndicatorSizeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTrackStopIndicatorSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTrackStopIndicatorSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrackStopIndicatorSize;
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

	private static Delegate GetSetTrackStopIndicatorSize_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTrackStopIndicatorSize_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTrackStopIndicatorSize_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrackStopIndicatorSize = p0;
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

	private static Delegate GetGetTrackTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetTrackTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTrackTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrackTintList);
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

	private static Delegate GetSetTrackTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetTrackTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTrackTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList trackTintList = Java.Lang.Object.GetObject<ColorStateList>(native_p0, JniHandleOwnership.DoNotTransfer);
			slider.TrackTintList = trackTintList;
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

	private static Delegate GetGetTrackWidthHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetTrackWidth);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTrackWidth(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TrackWidth;
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

	private static Delegate GetGetValueHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetValue);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetValue(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value;
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

	private static Delegate GetSetValue_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetValue_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetValue_F(nint jnienv, nint native__this, float value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value = value;
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

	private static Delegate GetGetValueFromHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetValueFrom);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetValueFrom(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ValueFrom;
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

	private static Delegate GetSetValueFrom_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetValueFrom_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetValueFrom_F(nint jnienv, nint native__this, float p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ValueFrom = p0;
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

	private static Delegate GetGetValueToHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetValueTo);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetValueTo(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ValueTo;
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

	private static Delegate GetSetValueTo_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetValueTo_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetValueTo_F(nint jnienv, nint native__this, float p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ValueTo = p0;
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

	private static Delegate GetClearOnChangeListenersHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearOnChangeListeners);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearOnChangeListeners(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearOnChangeListeners();
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

	[Register("clearOnChangeListeners", "()V", "GetClearOnChangeListenersHandler")]
	public unsafe virtual void ClearOnChangeListeners()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearOnChangeListeners.()V", this, null);
	}

	private static Delegate GetClearOnSliderTouchListenersHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearOnSliderTouchListeners);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearOnSliderTouchListeners(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearOnSliderTouchListeners();
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

	[Register("clearOnSliderTouchListeners", "()V", "GetClearOnSliderTouchListenersHandler")]
	public unsafe virtual void ClearOnSliderTouchListeners()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearOnSliderTouchListeners.()V", this, null);
	}

	private static Delegate GetDispatchHoverEvent_Landroid_view_MotionEvent_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_DispatchHoverEvent_Landroid_view_MotionEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DispatchHoverEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent p = Java.Lang.Object.GetObject<MotionEvent>(native_p0, JniHandleOwnership.DoNotTransfer);
			return slider.DispatchHoverEvent(p) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("dispatchHoverEvent", "(Landroid/view/MotionEvent;)Z", "GetDispatchHoverEvent_Landroid_view_MotionEvent_Handler")]
	public new unsafe virtual bool DispatchHoverEvent(MotionEvent p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchHoverEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetDispatchKeyEvent_Landroid_view_KeyEvent_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_DispatchKeyEvent_Landroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_DispatchKeyEvent_Landroid_view_KeyEvent_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_p0, JniHandleOwnership.DoNotTransfer);
			return slider.DispatchKeyEvent(e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("dispatchKeyEvent", "(Landroid/view/KeyEvent;)Z", "GetDispatchKeyEvent_Landroid_view_KeyEvent_Handler")]
	public unsafe override bool DispatchKeyEvent(KeyEvent p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("dispatchKeyEvent.(Landroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnKeyDown_ILandroid_view_KeyEvent_Handler()
	{
		return new global::_JniMarshal_PPIL_B(n_OnKeyDown_ILandroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnKeyDown_ILandroid_view_KeyEvent_(nint jnienv, nint native__this, int native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_p1, JniHandleOwnership.DoNotTransfer);
			return slider.OnKeyDown((Keycode)native_p0, e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onKeyDown", "(ILandroid/view/KeyEvent;)Z", "GetOnKeyDown_ILandroid_view_KeyEvent_Handler")]
	public unsafe override bool OnKeyDown(Keycode p0, KeyEvent p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((int)p0);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onKeyDown.(ILandroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetOnKeyUp_ILandroid_view_KeyEvent_Handler()
	{
		return new global::_JniMarshal_PPIL_B(n_OnKeyUp_ILandroid_view_KeyEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnKeyUp_ILandroid_view_KeyEvent_(nint jnienv, nint native__this, int native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			KeyEvent e = Java.Lang.Object.GetObject<KeyEvent>(native_p1, JniHandleOwnership.DoNotTransfer);
			return slider.OnKeyUp((Keycode)native_p0, e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onKeyUp", "(ILandroid/view/KeyEvent;)Z", "GetOnKeyUp_ILandroid_view_KeyEvent_Handler")]
	public unsafe override bool OnKeyUp(Keycode p0, KeyEvent p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((int)p0);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onKeyUp.(ILandroid/view/KeyEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetOnTouchEvent_Landroid_view_MotionEvent_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_OnTouchEvent_Landroid_view_MotionEvent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnTouchEvent_Landroid_view_MotionEvent_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionEvent e = Java.Lang.Object.GetObject<MotionEvent>(native_p0, JniHandleOwnership.DoNotTransfer);
			return slider.OnTouchEvent(e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[Register("onTouchEvent", "(Landroid/view/MotionEvent;)Z", "GetOnTouchEvent_Landroid_view_MotionEvent_Handler")]
	public unsafe override bool OnTouchEvent(MotionEvent p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onTouchEvent.(Landroid/view/MotionEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetPickActiveThumbHandler()
	{
		return new global::_JniMarshal_PP_B(n_PickActiveThumb);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_PickActiveThumb(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PickActiveThumb() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("pickActiveThumb", "()Z", "GetPickActiveThumbHandler")]
	protected unsafe virtual bool PickActiveThumb()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("pickActiveThumb.()Z", this, null);
	}

	private static Delegate GetSetCustomThumbDrawable_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCustomThumbDrawable_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomThumbDrawable_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_drawable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable customThumbDrawable = Java.Lang.Object.GetObject<Drawable>(native_drawable, JniHandleOwnership.DoNotTransfer);
			slider.SetCustomThumbDrawable(customThumbDrawable);
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

	[Register("setCustomThumbDrawable", "(Landroid/graphics/drawable/Drawable;)V", "GetSetCustomThumbDrawable_Landroid_graphics_drawable_Drawable_Handler")]
	public unsafe virtual void SetCustomThumbDrawable(Drawable drawable)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(drawable?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCustomThumbDrawable.(Landroid/graphics/drawable/Drawable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(drawable);
		}
	}

	private static Delegate GetSetCustomThumbDrawable_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCustomThumbDrawable_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomThumbDrawable_I(nint jnienv, nint native__this, int drawableResId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCustomThumbDrawable(drawableResId);
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

	[Register("setCustomThumbDrawable", "(I)V", "GetSetCustomThumbDrawable_IHandler")]
	public unsafe virtual void SetCustomThumbDrawable(int drawableResId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(drawableResId);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCustomThumbDrawable.(I)V", this, ptr);
	}

	private static Delegate GetSetEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEnabled_Z(nint jnienv, nint native__this, sbyte native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool enabled = native_p0 != 0;
			slider.SetEnabled(enabled);
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

	[Register("setEnabled", "(Z)V", "GetSetEnabled_ZHandler")]
	public unsafe void SetEnabled(bool p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0 ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setEnabled.(Z)V", this, ptr);
	}

	private static Delegate GetSetHaloRadiusResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetHaloRadiusResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHaloRadiusResource_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHaloRadiusResource(p0);
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

	[Register("setHaloRadiusResource", "(I)V", "GetSetHaloRadiusResource_IHandler")]
	public unsafe virtual void SetHaloRadiusResource(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHaloRadiusResource.(I)V", this, ptr);
	}

	private static Delegate GetSetLabelFormatter_Lcom_google_android_material_slider_LabelFormatter_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetLabelFormatter_Lcom_google_android_material_slider_LabelFormatter_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLabelFormatter_Lcom_google_android_material_slider_LabelFormatter_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Slider? slider = Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILabelFormatter labelFormatter = Java.Lang.Object.GetObject<ILabelFormatter>(native_p0, JniHandleOwnership.DoNotTransfer);
			slider.SetLabelFormatter(labelFormatter);
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

	[Register("setLabelFormatter", "(Lcom/google/android/material/slider/LabelFormatter;)V", "GetSetLabelFormatter_Lcom_google_android_material_slider_LabelFormatter_Handler")]
	public unsafe virtual void SetLabelFormatter(ILabelFormatter? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLabelFormatter.(Lcom/google/android/material/slider/LabelFormatter;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetThumbElevationResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetThumbElevationResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbElevationResource_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetThumbElevationResource(p0);
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

	[Register("setThumbElevationResource", "(I)V", "GetSetThumbElevationResource_IHandler")]
	public unsafe virtual void SetThumbElevationResource(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbElevationResource.(I)V", this, ptr);
	}

	private static Delegate GetSetThumbHeightResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetThumbHeightResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbHeightResource_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetThumbHeightResource(p0);
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

	[Register("setThumbHeightResource", "(I)V", "GetSetThumbHeightResource_IHandler")]
	public unsafe virtual void SetThumbHeightResource(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbHeightResource.(I)V", this, ptr);
	}

	private static Delegate GetSetThumbRadiusResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetThumbRadiusResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbRadiusResource_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetThumbRadiusResource(p0);
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

	[Register("setThumbRadiusResource", "(I)V", "GetSetThumbRadiusResource_IHandler")]
	public unsafe virtual void SetThumbRadiusResource(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbRadiusResource.(I)V", this, ptr);
	}

	private static Delegate GetSetThumbStrokeColorResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetThumbStrokeColorResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbStrokeColorResource_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetThumbStrokeColorResource(p0);
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

	[Register("setThumbStrokeColorResource", "(I)V", "GetSetThumbStrokeColorResource_IHandler")]
	public unsafe virtual void SetThumbStrokeColorResource(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbStrokeColorResource.(I)V", this, ptr);
	}

	private static Delegate GetSetThumbStrokeWidthResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetThumbStrokeWidthResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbStrokeWidthResource_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetThumbStrokeWidthResource(p0);
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

	[Register("setThumbStrokeWidthResource", "(I)V", "GetSetThumbStrokeWidthResource_IHandler")]
	public unsafe virtual void SetThumbStrokeWidthResource(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbStrokeWidthResource.(I)V", this, ptr);
	}

	private static Delegate GetSetThumbWidthResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetThumbWidthResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetThumbWidthResource_I(nint jnienv, nint native__this, int p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetThumbWidthResource(p0);
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

	[Register("setThumbWidthResource", "(I)V", "GetSetThumbWidthResource_IHandler")]
	public unsafe virtual void SetThumbWidthResource(int p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setThumbWidthResource.(I)V", this, ptr);
	}

	private static Delegate GetSetActiveThumbIndex_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetActiveThumbIndex_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetActiveThumbIndex_I(nint jnienv, nint native__this, int index)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetActiveThumbIndex(index);
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

	[Register("setActiveThumbIndex", "(I)V", "GetSetActiveThumbIndex_IHandler")]
	protected unsafe virtual void SetActiveThumbIndex(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setActiveThumbIndex.(I)V", this, ptr);
	}

	private static Delegate GetSetSeparationUnit_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSeparationUnit_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSeparationUnit_I(nint jnienv, nint native__this, int separationUnit)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Slider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSeparationUnit(separationUnit);
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

	[Register("setSeparationUnit", "(I)V", "GetSetSeparationUnit_IHandler")]
	protected unsafe virtual void SetSeparationUnit(int separationUnit)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(separationUnit);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setSeparationUnit.(I)V", this, ptr);
	}
}
