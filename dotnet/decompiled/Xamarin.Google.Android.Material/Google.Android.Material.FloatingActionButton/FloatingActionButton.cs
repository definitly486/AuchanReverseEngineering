using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Animation;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Util;
using AndroidX.CoordinatorLayout.Widget;
using Google.Android.Material.Animation;
using Google.Android.Material.Internal;
using Google.Android.Material.Shape;
using Java.Interop;
using Java.Lang;

namespace Google.Android.Material.FloatingActionButton;

[Register("com/google/android/material/floatingactionbutton/FloatingActionButton", DoNotGenerateAcw = true)]
public class FloatingActionButton : VisibilityAwareImageButton, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("com/google/android/material/floatingactionbutton/FloatingActionButton$OnVisibilityChangedListener", DoNotGenerateAcw = true)]
	public abstract class OnVisibilityChangedListener : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/floatingactionbutton/FloatingActionButton$OnVisibilityChangedListener", typeof(OnVisibilityChangedListener));

		private static Delegate? cb_onHidden_OnHidden_Lcom_google_android_material_floatingactionbutton_FloatingActionButton__V;

		private static Delegate? cb_onShown_OnShown_Lcom_google_android_material_floatingactionbutton_FloatingActionButton__V;

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

		protected OnVisibilityChangedListener(nint javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OnVisibilityChangedListener()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle == IntPtr.Zero)
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnHidden_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnHidden_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnHidden_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_(nint jnienv, nint native__this, nint native_fab)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				OnVisibilityChangedListener? onVisibilityChangedListener = Java.Lang.Object.GetObject<OnVisibilityChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FloatingActionButton fab = Java.Lang.Object.GetObject<FloatingActionButton>(native_fab, JniHandleOwnership.DoNotTransfer);
				onVisibilityChangedListener.OnHidden(fab);
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

		[Register("onHidden", "(Lcom/google/android/material/floatingactionbutton/FloatingActionButton;)V", "GetOnHidden_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_Handler")]
		public unsafe virtual void OnHidden(FloatingActionButton? fab)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(fab?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onHidden.(Lcom/google/android/material/floatingactionbutton/FloatingActionButton;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fab);
			}
		}

		private static Delegate GetOnShown_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_Handler()
		{
			return new global::_JniMarshal_PPL_V(n_OnShown_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_);
		}

		[DebuggerDisableUserUnhandledExceptions]
		private static void n_OnShown_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_(nint jnienv, nint native__this, nint native_fab)
		{
			if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
			{
				return;
			}
			try
			{
				OnVisibilityChangedListener? onVisibilityChangedListener = Java.Lang.Object.GetObject<OnVisibilityChangedListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				FloatingActionButton fab = Java.Lang.Object.GetObject<FloatingActionButton>(native_fab, JniHandleOwnership.DoNotTransfer);
				onVisibilityChangedListener.OnShown(fab);
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

		[Register("onShown", "(Lcom/google/android/material/floatingactionbutton/FloatingActionButton;)V", "GetOnShown_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_Handler")]
		public unsafe virtual void OnShown(FloatingActionButton? fab)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(fab?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onShown.(Lcom/google/android/material/floatingactionbutton/FloatingActionButton;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(fab);
			}
		}
	}

	[Register("com/google/android/material/floatingactionbutton/FloatingActionButton$OnVisibilityChangedListener", DoNotGenerateAcw = true)]
	internal class OnVisibilityChangedListenerInvoker : OnVisibilityChangedListener
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/floatingactionbutton/FloatingActionButton$OnVisibilityChangedListener", typeof(OnVisibilityChangedListenerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public OnVisibilityChangedListenerInvoker(nint handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}

	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/floatingactionbutton/FloatingActionButton", typeof(FloatingActionButton));

	private static Delegate? cb_getCompatElevation_GetCompatElevation_F;

	private static Delegate? cb_setCompatElevation_SetCompatElevation_F_V;

	private static Delegate? cb_getCompatHoveredFocusedTranslationZ_GetCompatHoveredFocusedTranslationZ_F;

	private static Delegate? cb_setCompatHoveredFocusedTranslationZ_SetCompatHoveredFocusedTranslationZ_F_V;

	private static Delegate? cb_getCompatPressedTranslationZ_GetCompatPressedTranslationZ_F;

	private static Delegate? cb_setCompatPressedTranslationZ_SetCompatPressedTranslationZ_F_V;

	private static Delegate? cb_getContentBackground_GetContentBackground_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_getCustomSize_GetCustomSize_I;

	private static Delegate? cb_setCustomSize_SetCustomSize_I_V;

	private static Delegate? cb_getExpandedComponentIdHint_GetExpandedComponentIdHint_I;

	private static Delegate? cb_setExpandedComponentIdHint_SetExpandedComponentIdHint_I_V;

	private static Delegate? cb_getHideMotionSpec_GetHideMotionSpec_Lcom_google_android_material_animation_MotionSpec_;

	private static Delegate? cb_setHideMotionSpec_SetHideMotionSpec_Lcom_google_android_material_animation_MotionSpec__V;

	private static Delegate? cb_isExpanded_IsExpanded_Z;

	private static Delegate? cb_isOrWillBeHidden_IsOrWillBeHidden_Z;

	private static Delegate? cb_isOrWillBeShown_IsOrWillBeShown_Z;

	private static Delegate? cb_getRippleColor_GetRippleColor_I;

	private static Delegate? cb_setRippleColor_SetRippleColor_I_V;

	private static Delegate? cb_getRippleColorStateList_GetRippleColorStateList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_getShapeAppearanceModel_GetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_;

	private static Delegate? cb_setShapeAppearanceModel_SetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel__V;

	private static Delegate? cb_getShowMotionSpec_GetShowMotionSpec_Lcom_google_android_material_animation_MotionSpec_;

	private static Delegate? cb_setShowMotionSpec_SetShowMotionSpec_Lcom_google_android_material_animation_MotionSpec__V;

	private static Delegate? cb_getSize_GetSize_I;

	private static Delegate? cb_setSize_SetSize_I_V;

	private static Delegate? cb_getSupportBackgroundTintList_GetSupportBackgroundTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setSupportBackgroundTintList_SetSupportBackgroundTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getSupportBackgroundTintMode_GetSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_;

	private static Delegate? cb_setSupportBackgroundTintMode_SetSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode__V;

	private static Delegate? cb_getSupportImageTintList_GetSupportImageTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_setSupportImageTintList_SetSupportImageTintList_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_getSupportImageTintMode_GetSupportImageTintMode_Landroid_graphics_PorterDuff_Mode_;

	private static Delegate? cb_setSupportImageTintMode_SetSupportImageTintMode_Landroid_graphics_PorterDuff_Mode__V;

	private static Delegate? cb_getUseCompatPadding_GetUseCompatPadding_Z;

	private static Delegate? cb_setUseCompatPadding_SetUseCompatPadding_Z_V;

	private static Delegate? cb_addOnHideAnimationListener_AddOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener__V;

	private static Delegate? cb_addOnShowAnimationListener_AddOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener__V;

	private static Delegate? cb_addTransformationCallback_AddTransformationCallback_Lcom_google_android_material_animation_TransformationCallback__V;

	private static Delegate? cb_clearCustomSize_ClearCustomSize_V;

	private static Delegate? cb_getBehavior_GetBehavior_Landroidx_coordinatorlayout_widget_CoordinatorLayout_Behavior_;

	private static Delegate? cb_getContentRect_GetContentRect_Landroid_graphics_Rect__Z;

	private static Delegate? cb_getMeasuredContentRect_GetMeasuredContentRect_Landroid_graphics_Rect__V;

	private static Delegate? cb_hide_Hide_V;

	private static Delegate? cb_hide_Hide_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener__V;

	private static Delegate? cb_removeOnHideAnimationListener_RemoveOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener__V;

	private static Delegate? cb_removeOnShowAnimationListener_RemoveOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener__V;

	private static Delegate? cb_removeTransformationCallback_RemoveTransformationCallback_Lcom_google_android_material_animation_TransformationCallback__V;

	private static Delegate? cb_setCompatElevationResource_SetCompatElevationResource_I_V;

	private static Delegate? cb_setCompatHoveredFocusedTranslationZResource_SetCompatHoveredFocusedTranslationZResource_I_V;

	private static Delegate? cb_setCompatPressedTranslationZResource_SetCompatPressedTranslationZResource_I_V;

	private static Delegate? cb_setEnsureMinTouchTargetSize_SetEnsureMinTouchTargetSize_Z_V;

	private static Delegate? cb_setExpanded_SetExpanded_Z_Z;

	private static Delegate? cb_setHideMotionSpecResource_SetHideMotionSpecResource_I_V;

	private static Delegate? cb_setMaxImageSize_SetMaxImageSize_I_V;

	private static Delegate? cb_setRippleColor_SetRippleColor_Landroid_content_res_ColorStateList__V;

	private static Delegate? cb_setShadowPaddingEnabled_SetShadowPaddingEnabled_Z_V;

	private static Delegate? cb_setShowMotionSpecResource_SetShowMotionSpecResource_I_V;

	private static Delegate? cb_shouldEnsureMinTouchTargetSize_ShouldEnsureMinTouchTargetSize_Z;

	private static Delegate? cb_show_Show_V;

	private static Delegate? cb_show_Show_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener__V;

	internal new static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe virtual float CompatElevation
	{
		[Register("getCompatElevation", "()F", "GetGetCompatElevationHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getCompatElevation.()F", this, null);
		}
		[Register("setCompatElevation", "(F)V", "GetSetCompatElevation_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCompatElevation.(F)V", this, ptr);
		}
	}

	public unsafe virtual float CompatHoveredFocusedTranslationZ
	{
		[Register("getCompatHoveredFocusedTranslationZ", "()F", "GetGetCompatHoveredFocusedTranslationZHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getCompatHoveredFocusedTranslationZ.()F", this, null);
		}
		[Register("setCompatHoveredFocusedTranslationZ", "(F)V", "GetSetCompatHoveredFocusedTranslationZ_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCompatHoveredFocusedTranslationZ.(F)V", this, ptr);
		}
	}

	public unsafe virtual float CompatPressedTranslationZ
	{
		[Register("getCompatPressedTranslationZ", "()F", "GetGetCompatPressedTranslationZHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getCompatPressedTranslationZ.()F", this, null);
		}
		[Register("setCompatPressedTranslationZ", "(F)V", "GetSetCompatPressedTranslationZ_FHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCompatPressedTranslationZ.(F)V", this, ptr);
		}
	}

	public unsafe virtual Drawable? ContentBackground
	{
		[Register("getContentBackground", "()Landroid/graphics/drawable/Drawable;", "GetGetContentBackgroundHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Drawable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContentBackground.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual int CustomSize
	{
		[Register("getCustomSize", "()I", "GetGetCustomSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getCustomSize.()I", this, null);
		}
		[Register("setCustomSize", "(I)V", "GetSetCustomSize_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCustomSize.(I)V", this, ptr);
		}
	}

	public unsafe virtual int ExpandedComponentIdHint
	{
		[Register("getExpandedComponentIdHint", "()I", "GetGetExpandedComponentIdHintHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getExpandedComponentIdHint.()I", this, null);
		}
		[Register("setExpandedComponentIdHint", "(I)V", "GetSetExpandedComponentIdHint_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setExpandedComponentIdHint.(I)V", this, ptr);
		}
	}

	public unsafe virtual MotionSpec? HideMotionSpec
	{
		[Register("getHideMotionSpec", "()Lcom/google/android/material/animation/MotionSpec;", "GetGetHideMotionSpecHandler")]
		get
		{
			return Java.Lang.Object.GetObject<MotionSpec>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHideMotionSpec.()Lcom/google/android/material/animation/MotionSpec;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setHideMotionSpec", "(Lcom/google/android/material/animation/MotionSpec;)V", "GetSetHideMotionSpec_Lcom_google_android_material_animation_MotionSpec_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHideMotionSpec.(Lcom/google/android/material/animation/MotionSpec;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool IsExpanded
	{
		[Register("isExpanded", "()Z", "GetIsExpandedHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isExpanded.()Z", this, null);
		}
	}

	public unsafe virtual bool IsOrWillBeHidden
	{
		[Register("isOrWillBeHidden", "()Z", "GetIsOrWillBeHiddenHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isOrWillBeHidden.()Z", this, null);
		}
	}

	public unsafe virtual bool IsOrWillBeShown
	{
		[Register("isOrWillBeShown", "()Z", "GetIsOrWillBeShownHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("isOrWillBeShown.()Z", this, null);
		}
	}

	public unsafe virtual int RippleColor
	{
		[Obsolete("deprecated")]
		[Register("getRippleColor", "()I", "GetGetRippleColorHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getRippleColor.()I", this, null);
		}
		[Register("setRippleColor", "(I)V", "GetSetRippleColor_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRippleColor.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? RippleColorStateList
	{
		[Register("getRippleColorStateList", "()Landroid/content/res/ColorStateList;", "GetGetRippleColorStateListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRippleColorStateList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
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

	public unsafe virtual MotionSpec? ShowMotionSpec
	{
		[Register("getShowMotionSpec", "()Lcom/google/android/material/animation/MotionSpec;", "GetGetShowMotionSpecHandler")]
		get
		{
			return Java.Lang.Object.GetObject<MotionSpec>(_members.InstanceMethods.InvokeVirtualObjectMethod("getShowMotionSpec.()Lcom/google/android/material/animation/MotionSpec;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setShowMotionSpec", "(Lcom/google/android/material/animation/MotionSpec;)V", "GetSetShowMotionSpec_Lcom_google_android_material_animation_MotionSpec_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setShowMotionSpec.(Lcom/google/android/material/animation/MotionSpec;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int Size
	{
		[Register("getSize", "()I", "GetGetSizeHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getSize.()I", this, null);
		}
		[Register("setSize", "(I)V", "GetSetSize_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSize.(I)V", this, ptr);
		}
	}

	public unsafe virtual ColorStateList? SupportBackgroundTintList
	{
		[Register("getSupportBackgroundTintList", "()Landroid/content/res/ColorStateList;", "GetGetSupportBackgroundTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportBackgroundTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setSupportBackgroundTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetSupportBackgroundTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportBackgroundTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual PorterDuff.Mode? SupportBackgroundTintMode
	{
		[Register("getSupportBackgroundTintMode", "()Landroid/graphics/PorterDuff$Mode;", "GetGetSupportBackgroundTintModeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<PorterDuff.Mode>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportBackgroundTintMode.()Landroid/graphics/PorterDuff$Mode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setSupportBackgroundTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportBackgroundTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual ColorStateList? SupportImageTintList
	{
		[Register("getSupportImageTintList", "()Landroid/content/res/ColorStateList;", "GetGetSupportImageTintListHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportImageTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setSupportImageTintList", "(Landroid/content/res/ColorStateList;)V", "GetSetSupportImageTintList_Landroid_content_res_ColorStateList_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportImageTintList.(Landroid/content/res/ColorStateList;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual PorterDuff.Mode? SupportImageTintMode
	{
		[Register("getSupportImageTintMode", "()Landroid/graphics/PorterDuff$Mode;", "GetGetSupportImageTintModeHandler")]
		get
		{
			return Java.Lang.Object.GetObject<PorterDuff.Mode>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSupportImageTintMode.()Landroid/graphics/PorterDuff$Mode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setSupportImageTintMode", "(Landroid/graphics/PorterDuff$Mode;)V", "GetSetSupportImageTintMode_Landroid_graphics_PorterDuff_Mode_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSupportImageTintMode.(Landroid/graphics/PorterDuff$Mode;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual bool UseCompatPadding
	{
		[Register("getUseCompatPadding", "()Z", "GetGetUseCompatPaddingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getUseCompatPadding.()Z", this, null);
		}
		[Register("setUseCompatPadding", "(Z)V", "GetSetUseCompatPadding_ZHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value ? ((sbyte)1) : ((sbyte)0));
			_members.InstanceMethods.InvokeVirtualVoidMethod("setUseCompatPadding.(Z)V", this, ptr);
		}
	}

	protected FloatingActionButton(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Landroid/content/Context;)V", "")]
	public unsafe FloatingActionButton(Context context)
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
	public unsafe FloatingActionButton(Context context, IAttributeSet? attrs)
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
	public unsafe FloatingActionButton(Context context, IAttributeSet? attrs, int defStyleAttr)
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

	private static Delegate GetGetCompatElevationHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetCompatElevation);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetCompatElevation(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompatElevation;
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

	private static Delegate GetSetCompatElevation_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetCompatElevation_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCompatElevation_F(nint jnienv, nint native__this, float elevation)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompatElevation = elevation;
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

	private static Delegate GetGetCompatHoveredFocusedTranslationZHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetCompatHoveredFocusedTranslationZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetCompatHoveredFocusedTranslationZ(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompatHoveredFocusedTranslationZ;
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

	private static Delegate GetSetCompatHoveredFocusedTranslationZ_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetCompatHoveredFocusedTranslationZ_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCompatHoveredFocusedTranslationZ_F(nint jnienv, nint native__this, float translationZ)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompatHoveredFocusedTranslationZ = translationZ;
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

	private static Delegate GetGetCompatPressedTranslationZHandler()
	{
		return new global::_JniMarshal_PP_F(n_GetCompatPressedTranslationZ);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetCompatPressedTranslationZ(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompatPressedTranslationZ;
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

	private static Delegate GetSetCompatPressedTranslationZ_FHandler()
	{
		return new global::_JniMarshal_PPF_V(n_SetCompatPressedTranslationZ_F);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCompatPressedTranslationZ_F(nint jnienv, nint native__this, float translationZ)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompatPressedTranslationZ = translationZ;
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

	private static Delegate GetGetContentBackgroundHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetContentBackground);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContentBackground(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentBackground);
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

	private static Delegate GetGetCustomSizeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetCustomSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetCustomSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CustomSize;
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

	private static Delegate GetSetCustomSize_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCustomSize_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCustomSize_I(nint jnienv, nint native__this, int size)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CustomSize = size;
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

	private static Delegate GetGetExpandedComponentIdHintHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetExpandedComponentIdHint);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetExpandedComponentIdHint(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExpandedComponentIdHint;
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

	private static Delegate GetSetExpandedComponentIdHint_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetExpandedComponentIdHint_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetExpandedComponentIdHint_I(nint jnienv, nint native__this, int expandedComponentIdHint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExpandedComponentIdHint = expandedComponentIdHint;
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

	private static Delegate GetGetHideMotionSpecHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetHideMotionSpec);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetHideMotionSpec(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HideMotionSpec);
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

	private static Delegate GetSetHideMotionSpec_Lcom_google_android_material_animation_MotionSpec_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetHideMotionSpec_Lcom_google_android_material_animation_MotionSpec_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHideMotionSpec_Lcom_google_android_material_animation_MotionSpec_(nint jnienv, nint native__this, nint native_spec)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionSpec hideMotionSpec = Java.Lang.Object.GetObject<MotionSpec>(native_spec, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.HideMotionSpec = hideMotionSpec;
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

	private static Delegate GetIsExpandedHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsExpanded);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsExpanded(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsExpanded ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsOrWillBeHiddenHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsOrWillBeHidden);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsOrWillBeHidden(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOrWillBeHidden ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsOrWillBeShownHandler()
	{
		return new global::_JniMarshal_PP_B(n_IsOrWillBeShown);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsOrWillBeShown(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOrWillBeShown ? ((sbyte)1) : ((sbyte)0);
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
	private static Delegate GetGetRippleColorHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetRippleColor);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetRippleColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RippleColor;
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

	private static Delegate GetSetRippleColor_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetRippleColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRippleColor_I(nint jnienv, nint native__this, int color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RippleColor = color;
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

	private static Delegate GetGetRippleColorStateListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetRippleColorStateList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetRippleColorStateList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RippleColorStateList);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShapeAppearanceModel);
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
	private static void n_SetShapeAppearanceModel_Lcom_google_android_material_shape_ShapeAppearanceModel_(nint jnienv, nint native__this, nint native_shapeAppearance)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ShapeAppearanceModel shapeAppearanceModel = Java.Lang.Object.GetObject<ShapeAppearanceModel>(native_shapeAppearance, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.ShapeAppearanceModel = shapeAppearanceModel;
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

	private static Delegate GetGetShowMotionSpecHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetShowMotionSpec);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetShowMotionSpec(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShowMotionSpec);
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

	private static Delegate GetSetShowMotionSpec_Lcom_google_android_material_animation_MotionSpec_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetShowMotionSpec_Lcom_google_android_material_animation_MotionSpec_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShowMotionSpec_Lcom_google_android_material_animation_MotionSpec_(nint jnienv, nint native__this, nint native_spec)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MotionSpec showMotionSpec = Java.Lang.Object.GetObject<MotionSpec>(native_spec, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.ShowMotionSpec = showMotionSpec;
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

	private static Delegate GetGetSizeHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size;
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

	private static Delegate GetSetSize_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetSize_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSize_I(nint jnienv, nint native__this, int size)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size = size;
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

	private static Delegate GetGetSupportBackgroundTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSupportBackgroundTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSupportBackgroundTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportBackgroundTintList);
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

	private static Delegate GetSetSupportBackgroundTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSupportBackgroundTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSupportBackgroundTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_tint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList supportBackgroundTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tint, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SupportBackgroundTintList = supportBackgroundTintList;
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

	private static Delegate GetGetSupportBackgroundTintModeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSupportBackgroundTintMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSupportBackgroundTintMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportBackgroundTintMode);
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

	private static Delegate GetSetSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSupportBackgroundTintMode_Landroid_graphics_PorterDuff_Mode_(nint jnienv, nint native__this, nint native_tintMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode supportBackgroundTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_tintMode, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SupportBackgroundTintMode = supportBackgroundTintMode;
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

	private static Delegate GetGetSupportImageTintListHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSupportImageTintList);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSupportImageTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportImageTintList);
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

	private static Delegate GetSetSupportImageTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSupportImageTintList_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSupportImageTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_tint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList supportImageTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tint, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SupportImageTintList = supportImageTintList;
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

	private static Delegate GetGetSupportImageTintModeHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetSupportImageTintMode);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSupportImageTintMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SupportImageTintMode);
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

	private static Delegate GetSetSupportImageTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetSupportImageTintMode_Landroid_graphics_PorterDuff_Mode_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSupportImageTintMode_Landroid_graphics_PorterDuff_Mode_(nint jnienv, nint native__this, nint native_tintMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode supportImageTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_tintMode, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SupportImageTintMode = supportImageTintMode;
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

	private static Delegate GetGetUseCompatPaddingHandler()
	{
		return new global::_JniMarshal_PP_B(n_GetUseCompatPadding);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetUseCompatPadding(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UseCompatPadding ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetSetUseCompatPadding_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetUseCompatPadding_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetUseCompatPadding_Z(nint jnienv, nint native__this, sbyte native_useCompatPadding)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool useCompatPadding = native_useCompatPadding != 0;
			floatingActionButton.UseCompatPadding = useCompatPadding;
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

	private static Delegate GetAddOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animator.IAnimatorListener listener = Java.Lang.Object.GetObject<Animator.IAnimatorListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.AddOnHideAnimationListener(listener);
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

	[Register("addOnHideAnimationListener", "(Landroid/animation/Animator$AnimatorListener;)V", "GetAddOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_Handler")]
	public unsafe virtual void AddOnHideAnimationListener(Animator.IAnimatorListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnHideAnimationListener.(Landroid/animation/Animator$AnimatorListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animator.IAnimatorListener listener = Java.Lang.Object.GetObject<Animator.IAnimatorListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.AddOnShowAnimationListener(listener);
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

	[Register("addOnShowAnimationListener", "(Landroid/animation/Animator$AnimatorListener;)V", "GetAddOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_Handler")]
	public unsafe virtual void AddOnShowAnimationListener(Animator.IAnimatorListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addOnShowAnimationListener.(Landroid/animation/Animator$AnimatorListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetAddTransformationCallback_Lcom_google_android_material_animation_TransformationCallback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddTransformationCallback_Lcom_google_android_material_animation_TransformationCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddTransformationCallback_Lcom_google_android_material_animation_TransformationCallback_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITransformationCallback listener = Java.Lang.Object.GetObject<ITransformationCallback>(native_listener, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.AddTransformationCallback(listener);
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

	[Register("addTransformationCallback", "(Lcom/google/android/material/animation/TransformationCallback;)V", "GetAddTransformationCallback_Lcom_google_android_material_animation_TransformationCallback_Handler")]
	public unsafe virtual void AddTransformationCallback(ITransformationCallback listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("addTransformationCallback.(Lcom/google/android/material/animation/TransformationCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetClearCustomSizeHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearCustomSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearCustomSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearCustomSize();
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

	[Register("clearCustomSize", "()V", "GetClearCustomSizeHandler")]
	public unsafe virtual void ClearCustomSize()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearCustomSize.()V", this, null);
	}

	private static Delegate GetGetBehaviorHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetBehavior);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBehavior(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetBehavior());
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

	[Register("getBehavior", "()Landroidx/coordinatorlayout/widget/CoordinatorLayout$Behavior;", "GetGetBehaviorHandler")]
	public unsafe virtual CoordinatorLayout.Behavior GetBehavior()
	{
		return Java.Lang.Object.GetObject<CoordinatorLayout.Behavior>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBehavior.()Landroidx/coordinatorlayout/widget/CoordinatorLayout$Behavior;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Obsolete]
	private static Delegate GetGetContentRect_Landroid_graphics_Rect_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_GetContentRect_Landroid_graphics_Rect_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_GetContentRect_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_rect)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect rect = Java.Lang.Object.GetObject<Rect>(native_rect, JniHandleOwnership.DoNotTransfer);
			return floatingActionButton.GetContentRect(rect) ? ((sbyte)1) : ((sbyte)0);
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

	[Obsolete("deprecated")]
	[Register("getContentRect", "(Landroid/graphics/Rect;)Z", "GetGetContentRect_Landroid_graphics_Rect_Handler")]
	public unsafe virtual bool GetContentRect(Rect rect)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(rect?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getContentRect.(Landroid/graphics/Rect;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(rect);
		}
	}

	private static Delegate GetGetMeasuredContentRect_Landroid_graphics_Rect_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_GetMeasuredContentRect_Landroid_graphics_Rect_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_GetMeasuredContentRect_Landroid_graphics_Rect_(nint jnienv, nint native__this, nint native_rect)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Rect rect = Java.Lang.Object.GetObject<Rect>(native_rect, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.GetMeasuredContentRect(rect);
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

	[Register("getMeasuredContentRect", "(Landroid/graphics/Rect;)V", "GetGetMeasuredContentRect_Landroid_graphics_Rect_Handler")]
	public unsafe virtual void GetMeasuredContentRect(Rect rect)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(rect?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getMeasuredContentRect.(Landroid/graphics/Rect;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(rect);
		}
	}

	private static Delegate GetHideHandler()
	{
		return new global::_JniMarshal_PP_V(n_Hide);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Hide(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Hide();
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

	[Register("hide", "()V", "GetHideHandler")]
	public unsafe virtual void Hide()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("hide.()V", this, null);
	}

	private static Delegate GetHide_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Hide_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Hide_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OnVisibilityChangedListener listener = Java.Lang.Object.GetObject<OnVisibilityChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.Hide(listener);
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

	[Register("hide", "(Lcom/google/android/material/floatingactionbutton/FloatingActionButton$OnVisibilityChangedListener;)V", "GetHide_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_Handler")]
	public unsafe virtual void Hide(OnVisibilityChangedListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("hide.(Lcom/google/android/material/floatingactionbutton/FloatingActionButton$OnVisibilityChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animator.IAnimatorListener listener = Java.Lang.Object.GetObject<Animator.IAnimatorListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.RemoveOnHideAnimationListener(listener);
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

	[Register("removeOnHideAnimationListener", "(Landroid/animation/Animator$AnimatorListener;)V", "GetRemoveOnHideAnimationListener_Landroid_animation_Animator_AnimatorListener_Handler")]
	public unsafe virtual void RemoveOnHideAnimationListener(Animator.IAnimatorListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnHideAnimationListener.(Landroid/animation/Animator$AnimatorListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Animator.IAnimatorListener listener = Java.Lang.Object.GetObject<Animator.IAnimatorListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.RemoveOnShowAnimationListener(listener);
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

	[Register("removeOnShowAnimationListener", "(Landroid/animation/Animator$AnimatorListener;)V", "GetRemoveOnShowAnimationListener_Landroid_animation_Animator_AnimatorListener_Handler")]
	public unsafe virtual void RemoveOnShowAnimationListener(Animator.IAnimatorListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeOnShowAnimationListener.(Landroid/animation/Animator$AnimatorListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetRemoveTransformationCallback_Lcom_google_android_material_animation_TransformationCallback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveTransformationCallback_Lcom_google_android_material_animation_TransformationCallback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveTransformationCallback_Lcom_google_android_material_animation_TransformationCallback_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ITransformationCallback listener = Java.Lang.Object.GetObject<ITransformationCallback>(native_listener, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.RemoveTransformationCallback(listener);
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

	[Register("removeTransformationCallback", "(Lcom/google/android/material/animation/TransformationCallback;)V", "GetRemoveTransformationCallback_Lcom_google_android_material_animation_TransformationCallback_Handler")]
	public unsafe virtual void RemoveTransformationCallback(ITransformationCallback listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeTransformationCallback.(Lcom/google/android/material/animation/TransformationCallback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetCompatElevationResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCompatElevationResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCompatElevationResource_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCompatElevationResource(id);
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

	[Register("setCompatElevationResource", "(I)V", "GetSetCompatElevationResource_IHandler")]
	public unsafe virtual void SetCompatElevationResource(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCompatElevationResource.(I)V", this, ptr);
	}

	private static Delegate GetSetCompatHoveredFocusedTranslationZResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCompatHoveredFocusedTranslationZResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCompatHoveredFocusedTranslationZResource_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCompatHoveredFocusedTranslationZResource(id);
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

	[Register("setCompatHoveredFocusedTranslationZResource", "(I)V", "GetSetCompatHoveredFocusedTranslationZResource_IHandler")]
	public unsafe virtual void SetCompatHoveredFocusedTranslationZResource(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCompatHoveredFocusedTranslationZResource.(I)V", this, ptr);
	}

	private static Delegate GetSetCompatPressedTranslationZResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetCompatPressedTranslationZResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCompatPressedTranslationZResource_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetCompatPressedTranslationZResource(id);
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

	[Register("setCompatPressedTranslationZResource", "(I)V", "GetSetCompatPressedTranslationZResource_IHandler")]
	public unsafe virtual void SetCompatPressedTranslationZResource(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setCompatPressedTranslationZResource.(I)V", this, ptr);
	}

	private static Delegate GetSetEnsureMinTouchTargetSize_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetEnsureMinTouchTargetSize_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetEnsureMinTouchTargetSize_Z(nint jnienv, nint native__this, sbyte native_flag)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool ensureMinTouchTargetSize = native_flag != 0;
			floatingActionButton.SetEnsureMinTouchTargetSize(ensureMinTouchTargetSize);
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

	[Register("setEnsureMinTouchTargetSize", "(Z)V", "GetSetEnsureMinTouchTargetSize_ZHandler")]
	public unsafe virtual void SetEnsureMinTouchTargetSize(bool flag)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(flag ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setEnsureMinTouchTargetSize.(Z)V", this, ptr);
	}

	private static Delegate GetSetExpanded_ZHandler()
	{
		return new global::_JniMarshal_PPB_B(n_SetExpanded_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_SetExpanded_Z(nint jnienv, nint native__this, sbyte native_expanded)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool expanded = native_expanded != 0;
			return floatingActionButton.SetExpanded(expanded) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("setExpanded", "(Z)Z", "GetSetExpanded_ZHandler")]
	public unsafe virtual bool SetExpanded(bool expanded)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(expanded ? ((sbyte)1) : ((sbyte)0));
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("setExpanded.(Z)Z", this, ptr);
	}

	private static Delegate GetSetHideMotionSpecResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetHideMotionSpecResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHideMotionSpecResource_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHideMotionSpecResource(id);
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

	[Register("setHideMotionSpecResource", "(I)V", "GetSetHideMotionSpecResource_IHandler")]
	public unsafe virtual void SetHideMotionSpecResource(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setHideMotionSpecResource.(I)V", this, ptr);
	}

	private static Delegate GetSetMaxImageSize_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMaxImageSize_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMaxImageSize_I(nint jnienv, nint native__this, int imageSize)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMaxImageSize(imageSize);
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

	[Register("setMaxImageSize", "(I)V", "GetSetMaxImageSize_IHandler")]
	public unsafe virtual void SetMaxImageSize(int imageSize)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(imageSize);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxImageSize.(I)V", this, ptr);
	}

	private static Delegate GetSetRippleColor_Landroid_content_res_ColorStateList_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetRippleColor_Landroid_content_res_ColorStateList_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetRippleColor_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_color)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList rippleColor = Java.Lang.Object.GetObject<ColorStateList>(native_color, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.SetRippleColor(rippleColor);
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

	[Register("setRippleColor", "(Landroid/content/res/ColorStateList;)V", "GetSetRippleColor_Landroid_content_res_ColorStateList_Handler")]
	public unsafe virtual void SetRippleColor(ColorStateList? color)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(color?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRippleColor.(Landroid/content/res/ColorStateList;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(color);
		}
	}

	private static Delegate GetSetShadowPaddingEnabled_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetShadowPaddingEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShadowPaddingEnabled_Z(nint jnienv, nint native__this, sbyte native_shadowPaddingEnabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool shadowPaddingEnabled = native_shadowPaddingEnabled != 0;
			floatingActionButton.SetShadowPaddingEnabled(shadowPaddingEnabled);
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
	[Register("setShadowPaddingEnabled", "(Z)V", "GetSetShadowPaddingEnabled_ZHandler")]
	public unsafe virtual void SetShadowPaddingEnabled(bool shadowPaddingEnabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(shadowPaddingEnabled ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setShadowPaddingEnabled.(Z)V", this, ptr);
	}

	private static Delegate GetSetShowMotionSpecResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetShowMotionSpecResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShowMotionSpecResource_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetShowMotionSpecResource(id);
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

	[Register("setShowMotionSpecResource", "(I)V", "GetSetShowMotionSpecResource_IHandler")]
	public unsafe virtual void SetShowMotionSpecResource(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setShowMotionSpecResource.(I)V", this, ptr);
	}

	private static Delegate GetShouldEnsureMinTouchTargetSizeHandler()
	{
		return new global::_JniMarshal_PP_B(n_ShouldEnsureMinTouchTargetSize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ShouldEnsureMinTouchTargetSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShouldEnsureMinTouchTargetSize() ? ((sbyte)1) : ((sbyte)0);
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

	[Register("shouldEnsureMinTouchTargetSize", "()Z", "GetShouldEnsureMinTouchTargetSizeHandler")]
	public unsafe virtual bool ShouldEnsureMinTouchTargetSize()
	{
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("shouldEnsureMinTouchTargetSize.()Z", this, null);
	}

	private static Delegate GetShowHandler()
	{
		return new global::_JniMarshal_PP_V(n_Show);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Show(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Show();
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

	[Register("show", "()V", "GetShowHandler")]
	public unsafe virtual void Show()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("show.()V", this, null);
	}

	private static Delegate GetShow_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Show_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Show_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			FloatingActionButton? floatingActionButton = Java.Lang.Object.GetObject<FloatingActionButton>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OnVisibilityChangedListener listener = Java.Lang.Object.GetObject<OnVisibilityChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			floatingActionButton.Show(listener);
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

	[Register("show", "(Lcom/google/android/material/floatingactionbutton/FloatingActionButton$OnVisibilityChangedListener;)V", "GetShow_Lcom_google_android_material_floatingactionbutton_FloatingActionButton_OnVisibilityChangedListener_Handler")]
	public unsafe virtual void Show(OnVisibilityChangedListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(listener?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("show.(Lcom/google/android/material/floatingactionbutton/FloatingActionButton$OnVisibilityChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}
}
