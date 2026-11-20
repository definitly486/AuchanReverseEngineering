using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Interop;
using Java.Lang;
using Java.Util;

namespace Google.Android.Material.Badge;

[Register("com/google/android/material/badge/BadgeDrawable", DoNotGenerateAcw = true)]
public class BadgeDrawable : Drawable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("com/google/android/material/badge/BadgeDrawable", typeof(BadgeDrawable));

	private static Delegate? cb_getBackgroundColor_GetBackgroundColor_I;

	private static Delegate? cb_setBackgroundColor_SetBackgroundColor_I_V;

	private static Delegate? cb_getBadgeGravity_GetBadgeGravity_I;

	private static Delegate? cb_setBadgeGravity_SetBadgeGravity_I_V;

	private static Delegate? cb_getBadgeNumberLocale_GetBadgeNumberLocale_Ljava_util_Locale_;

	private static Delegate? cb_setBadgeNumberLocale_SetBadgeNumberLocale_Ljava_util_Locale__V;

	private static Delegate? cb_getBadgeTextColor_GetBadgeTextColor_I;

	private static Delegate? cb_setBadgeTextColor_SetBadgeTextColor_I_V;

	private static Delegate? cb_getContentDescription_GetContentDescription_Ljava_lang_CharSequence_;

	private static Delegate? cb_getCustomBadgeParent_GetCustomBadgeParent_Landroid_widget_FrameLayout_;

	private static Delegate? cb_hasNumber_HasNumber_Z;

	private static Delegate? cb_hasText_HasText_Z;

	private static Delegate? cb_getHorizontalOffset_GetHorizontalOffset_I;

	private static Delegate? cb_setHorizontalOffset_SetHorizontalOffset_I_V;

	private static Delegate? cb_getHorizontalOffsetWithText_GetHorizontalOffsetWithText_I;

	private static Delegate? cb_setHorizontalOffsetWithText_SetHorizontalOffsetWithText_I_V;

	private static Delegate? cb_getHorizontalOffsetWithoutText_GetHorizontalOffsetWithoutText_I;

	private static Delegate? cb_setHorizontalOffsetWithoutText_SetHorizontalOffsetWithoutText_I_V;

	private static Delegate? cb_getHorizontalPadding_GetHorizontalPadding_I;

	private static Delegate? cb_setHorizontalPadding_SetHorizontalPadding_I_V;

	private static Delegate? cb_getLargeFontVerticalOffsetAdjustment_GetLargeFontVerticalOffsetAdjustment_I;

	private static Delegate? cb_setLargeFontVerticalOffsetAdjustment_SetLargeFontVerticalOffsetAdjustment_I_V;

	private static Delegate? cb_getMaxCharacterCount_GetMaxCharacterCount_I;

	private static Delegate? cb_setMaxCharacterCount_SetMaxCharacterCount_I_V;

	private static Delegate? cb_getMaxNumber_GetMaxNumber_I;

	private static Delegate? cb_setMaxNumber_SetMaxNumber_I_V;

	private static Delegate? cb_getNumber_GetNumber_I;

	private static Delegate? cb_setNumber_SetNumber_I_V;

	private static Delegate? cb_getOpacity_GetOpacity_I;

	private static Delegate? cb_getText_GetText_Ljava_lang_String_;

	private static Delegate? cb_setText_SetText_Ljava_lang_String__V;

	private static Delegate? cb_getVerticalOffset_GetVerticalOffset_I;

	private static Delegate? cb_setVerticalOffset_SetVerticalOffset_I_V;

	private static Delegate? cb_getVerticalOffsetWithText_GetVerticalOffsetWithText_I;

	private static Delegate? cb_setVerticalOffsetWithText_SetVerticalOffsetWithText_I_V;

	private static Delegate? cb_getVerticalOffsetWithoutText_GetVerticalOffsetWithoutText_I;

	private static Delegate? cb_setVerticalOffsetWithoutText_SetVerticalOffsetWithoutText_I_V;

	private static Delegate? cb_getVerticalPadding_GetVerticalPadding_I;

	private static Delegate? cb_setVerticalPadding_SetVerticalPadding_I_V;

	private static Delegate? cb_clearNumber_ClearNumber_V;

	private static Delegate? cb_clearText_ClearText_V;

	private static Delegate? cb_draw_Draw_Landroid_graphics_Canvas__V;

	private static Delegate? cb_onStateChange_OnStateChange_arrayI_Z;

	private static Delegate? cb_onTextSizeChange_OnTextSizeChange_V;

	private static Delegate? cb_setAlpha_SetAlpha_I_V;

	private static Delegate? cb_setAutoAdjustToWithinGrandparentBounds_SetAutoAdjustToWithinGrandparentBounds_Z_V;

	private static Delegate? cb_setBadgeWithTextShapeAppearance_SetBadgeWithTextShapeAppearance_I_V;

	private static Delegate? cb_setBadgeWithTextShapeAppearanceOverlay_SetBadgeWithTextShapeAppearanceOverlay_I_V;

	private static Delegate? cb_setBadgeWithoutTextShapeAppearance_SetBadgeWithoutTextShapeAppearance_I_V;

	private static Delegate? cb_setBadgeWithoutTextShapeAppearanceOverlay_SetBadgeWithoutTextShapeAppearanceOverlay_I_V;

	private static Delegate? cb_setColorFilter_SetColorFilter_Landroid_graphics_ColorFilter__V;

	private static Delegate? cb_setContentDescriptionExceedsMaxBadgeNumberStringResource_SetContentDescriptionExceedsMaxBadgeNumberStringResource_I_V;

	private static Delegate? cb_setContentDescriptionForText_SetContentDescriptionForText_Ljava_lang_CharSequence__V;

	private static Delegate? cb_setContentDescriptionNumberless_SetContentDescriptionNumberless_Ljava_lang_CharSequence__V;

	private static Delegate? cb_setContentDescriptionQuantityStringsResource_SetContentDescriptionQuantityStringsResource_I_V;

	private static Delegate? cb_setTextAppearance_SetTextAppearance_I_V;

	private static Delegate? cb_setVisible_SetVisible_Z_V;

	private static Delegate? cb_updateBadgeCoordinates_UpdateBadgeCoordinates_Landroid_view_View__V;

	private static Delegate? cb_updateBadgeCoordinates_UpdateBadgeCoordinates_Landroid_view_View_Landroid_view_ViewGroup__V;

	private static Delegate? cb_updateBadgeCoordinates_UpdateBadgeCoordinates_Landroid_view_View_Landroid_widget_FrameLayout__V;

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

	public unsafe virtual int BackgroundColor
	{
		[Register("getBackgroundColor", "()I", "GetGetBackgroundColorHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getBackgroundColor.()I", this, null);
		}
		[Register("setBackgroundColor", "(I)V", "GetSetBackgroundColor_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBackgroundColor.(I)V", this, ptr);
		}
	}

	public unsafe virtual int BadgeGravity
	{
		[Register("getBadgeGravity", "()I", "GetGetBadgeGravityHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getBadgeGravity.()I", this, null);
		}
		[Register("setBadgeGravity", "(I)V", "GetSetBadgeGravity_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBadgeGravity.(I)V", this, ptr);
		}
	}

	public unsafe virtual Locale BadgeNumberLocale
	{
		[Register("getBadgeNumberLocale", "()Ljava/util/Locale;", "GetGetBadgeNumberLocaleHandler")]
		get
		{
			return Java.Lang.Object.GetObject<Locale>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBadgeNumberLocale.()Ljava/util/Locale;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setBadgeNumberLocale", "(Ljava/util/Locale;)V", "GetSetBadgeNumberLocale_Ljava_util_Locale_Handler")]
		set
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setBadgeNumberLocale.(Ljava/util/Locale;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(value);
			}
		}
	}

	public unsafe virtual int BadgeTextColor
	{
		[Register("getBadgeTextColor", "()I", "GetGetBadgeTextColorHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getBadgeTextColor.()I", this, null);
		}
		[Register("setBadgeTextColor", "(I)V", "GetSetBadgeTextColor_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setBadgeTextColor.(I)V", this, ptr);
		}
	}

	public unsafe virtual ICharSequence? ContentDescriptionFormatted
	{
		[Register("getContentDescription", "()Ljava/lang/CharSequence;", "GetGetContentDescriptionHandler")]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContentDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public string? ContentDescription
	{
		get
		{
			if (ContentDescriptionFormatted != null)
			{
				return ContentDescriptionFormatted.ToString();
			}
			return null;
		}
	}

	public unsafe virtual FrameLayout? CustomBadgeParent
	{
		[Register("getCustomBadgeParent", "()Landroid/widget/FrameLayout;", "GetGetCustomBadgeParentHandler")]
		get
		{
			return Java.Lang.Object.GetObject<FrameLayout>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCustomBadgeParent.()Landroid/widget/FrameLayout;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public unsafe virtual bool HasNumber
	{
		[Register("hasNumber", "()Z", "GetHasNumberHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasNumber.()Z", this, null);
		}
	}

	public unsafe virtual bool HasText
	{
		[Register("hasText", "()Z", "GetHasTextHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasText.()Z", this, null);
		}
	}

	public unsafe virtual int HorizontalOffset
	{
		[Register("getHorizontalOffset", "()I", "GetGetHorizontalOffsetHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getHorizontalOffset.()I", this, null);
		}
		[Register("setHorizontalOffset", "(I)V", "GetSetHorizontalOffset_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalOffset.(I)V", this, ptr);
		}
	}

	public unsafe virtual int HorizontalOffsetWithText
	{
		[Register("getHorizontalOffsetWithText", "()I", "GetGetHorizontalOffsetWithTextHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getHorizontalOffsetWithText.()I", this, null);
		}
		[Register("setHorizontalOffsetWithText", "(I)V", "GetSetHorizontalOffsetWithText_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalOffsetWithText.(I)V", this, ptr);
		}
	}

	public unsafe virtual int HorizontalOffsetWithoutText
	{
		[Register("getHorizontalOffsetWithoutText", "()I", "GetGetHorizontalOffsetWithoutTextHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getHorizontalOffsetWithoutText.()I", this, null);
		}
		[Register("setHorizontalOffsetWithoutText", "(I)V", "GetSetHorizontalOffsetWithoutText_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalOffsetWithoutText.(I)V", this, ptr);
		}
	}

	public unsafe virtual int HorizontalPadding
	{
		[Register("getHorizontalPadding", "()I", "GetGetHorizontalPaddingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getHorizontalPadding.()I", this, null);
		}
		[Register("setHorizontalPadding", "(I)V", "GetSetHorizontalPadding_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalPadding.(I)V", this, ptr);
		}
	}

	public unsafe virtual int LargeFontVerticalOffsetAdjustment
	{
		[Register("getLargeFontVerticalOffsetAdjustment", "()I", "GetGetLargeFontVerticalOffsetAdjustmentHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLargeFontVerticalOffsetAdjustment.()I", this, null);
		}
		[Register("setLargeFontVerticalOffsetAdjustment", "(I)V", "GetSetLargeFontVerticalOffsetAdjustment_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLargeFontVerticalOffsetAdjustment.(I)V", this, ptr);
		}
	}

	public unsafe virtual int MaxCharacterCount
	{
		[Register("getMaxCharacterCount", "()I", "GetGetMaxCharacterCountHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxCharacterCount.()I", this, null);
		}
		[Register("setMaxCharacterCount", "(I)V", "GetSetMaxCharacterCount_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxCharacterCount.(I)V", this, ptr);
		}
	}

	public unsafe virtual int MaxNumber
	{
		[Register("getMaxNumber", "()I", "GetGetMaxNumberHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxNumber.()I", this, null);
		}
		[Register("setMaxNumber", "(I)V", "GetSetMaxNumber_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxNumber.(I)V", this, ptr);
		}
	}

	public unsafe virtual int Number
	{
		[Register("getNumber", "()I", "GetGetNumberHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getNumber.()I", this, null);
		}
		[Register("setNumber", "(I)V", "GetSetNumber_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setNumber.(I)V", this, ptr);
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

	public unsafe virtual string? Text
	{
		[Register("getText", "()Ljava/lang/String;", "GetGetTextHandler")]
		get
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getText.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
		[Register("setText", "(Ljava/lang/String;)V", "GetSetText_Ljava_lang_String_Handler")]
		set
		{
			nint num = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(num);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setText.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(num);
			}
		}
	}

	public unsafe virtual int VerticalOffset
	{
		[Register("getVerticalOffset", "()I", "GetGetVerticalOffsetHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getVerticalOffset.()I", this, null);
		}
		[Register("setVerticalOffset", "(I)V", "GetSetVerticalOffset_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalOffset.(I)V", this, ptr);
		}
	}

	public unsafe virtual int VerticalOffsetWithText
	{
		[Register("getVerticalOffsetWithText", "()I", "GetGetVerticalOffsetWithTextHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getVerticalOffsetWithText.()I", this, null);
		}
		[Register("setVerticalOffsetWithText", "(I)V", "GetSetVerticalOffsetWithText_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalOffsetWithText.(I)V", this, ptr);
		}
	}

	public unsafe virtual int VerticalOffsetWithoutText
	{
		[Register("getVerticalOffsetWithoutText", "()I", "GetGetVerticalOffsetWithoutTextHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getVerticalOffsetWithoutText.()I", this, null);
		}
		[Register("setVerticalOffsetWithoutText", "(I)V", "GetSetVerticalOffsetWithoutText_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalOffsetWithoutText.(I)V", this, ptr);
		}
	}

	public unsafe virtual int VerticalPadding
	{
		[Register("getVerticalPadding", "()I", "GetGetVerticalPaddingHandler")]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getVerticalPadding.()I", this, null);
		}
		[Register("setVerticalPadding", "(I)V", "GetSetVerticalPadding_IHandler")]
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalPadding.(I)V", this, ptr);
		}
	}

	protected BadgeDrawable(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetGetBackgroundColorHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetBackgroundColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetBackgroundColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BackgroundColor;
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

	private static Delegate GetSetBackgroundColor_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBackgroundColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBackgroundColor_I(nint jnienv, nint native__this, int backgroundColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BackgroundColor = backgroundColor;
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

	private static Delegate GetGetBadgeGravityHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetBadgeGravity);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetBadgeGravity(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BadgeGravity;
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

	private static Delegate GetSetBadgeGravity_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBadgeGravity_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBadgeGravity_I(nint jnienv, nint native__this, int gravity)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BadgeGravity = gravity;
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

	private static Delegate GetGetBadgeNumberLocaleHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetBadgeNumberLocale);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetBadgeNumberLocale(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BadgeNumberLocale);
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

	private static Delegate GetSetBadgeNumberLocale_Ljava_util_Locale_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetBadgeNumberLocale_Ljava_util_Locale_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBadgeNumberLocale_Ljava_util_Locale_(nint jnienv, nint native__this, nint native_locale)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BadgeDrawable? badgeDrawable = Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Locale badgeNumberLocale = Java.Lang.Object.GetObject<Locale>(native_locale, JniHandleOwnership.DoNotTransfer);
			badgeDrawable.BadgeNumberLocale = badgeNumberLocale;
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

	private static Delegate GetGetBadgeTextColorHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetBadgeTextColor);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetBadgeTextColor(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BadgeTextColor;
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

	private static Delegate GetSetBadgeTextColor_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBadgeTextColor_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBadgeTextColor_I(nint jnienv, nint native__this, int badgeTextColor)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BadgeTextColor = badgeTextColor;
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

	private static Delegate GetGetContentDescriptionHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetContentDescription);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContentDescription(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentDescriptionFormatted);
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

	private static Delegate GetGetCustomBadgeParentHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetCustomBadgeParent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCustomBadgeParent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CustomBadgeParent);
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

	private static Delegate GetHasNumberHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasNumber);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasNumber(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasNumber ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetHasTextHandler()
	{
		return new global::_JniMarshal_PP_B(n_HasText);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasText ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetHorizontalOffsetHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetHorizontalOffset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHorizontalOffset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalOffset;
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

	private static Delegate GetSetHorizontalOffset_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetHorizontalOffset_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHorizontalOffset_I(nint jnienv, nint native__this, int px)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalOffset = px;
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

	private static Delegate GetGetHorizontalOffsetWithTextHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetHorizontalOffsetWithText);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHorizontalOffsetWithText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalOffsetWithText;
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

	private static Delegate GetSetHorizontalOffsetWithText_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetHorizontalOffsetWithText_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHorizontalOffsetWithText_I(nint jnienv, nint native__this, int px)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalOffsetWithText = px;
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

	private static Delegate GetGetHorizontalOffsetWithoutTextHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetHorizontalOffsetWithoutText);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHorizontalOffsetWithoutText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalOffsetWithoutText;
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

	private static Delegate GetSetHorizontalOffsetWithoutText_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetHorizontalOffsetWithoutText_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHorizontalOffsetWithoutText_I(nint jnienv, nint native__this, int px)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalOffsetWithoutText = px;
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

	private static Delegate GetGetHorizontalPaddingHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetHorizontalPadding);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHorizontalPadding(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalPadding;
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

	private static Delegate GetSetHorizontalPadding_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetHorizontalPadding_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetHorizontalPadding_I(nint jnienv, nint native__this, int horizontalPadding)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalPadding = horizontalPadding;
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

	private static Delegate GetGetLargeFontVerticalOffsetAdjustmentHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetLargeFontVerticalOffsetAdjustment);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetLargeFontVerticalOffsetAdjustment(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LargeFontVerticalOffsetAdjustment;
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

	private static Delegate GetSetLargeFontVerticalOffsetAdjustment_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetLargeFontVerticalOffsetAdjustment_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetLargeFontVerticalOffsetAdjustment_I(nint jnienv, nint native__this, int px)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LargeFontVerticalOffsetAdjustment = px;
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

	private static Delegate GetGetMaxCharacterCountHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMaxCharacterCount);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMaxCharacterCount(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxCharacterCount;
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

	private static Delegate GetSetMaxCharacterCount_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMaxCharacterCount_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMaxCharacterCount_I(nint jnienv, nint native__this, int maxCharacterCount)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxCharacterCount = maxCharacterCount;
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

	private static Delegate GetGetMaxNumberHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetMaxNumber);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetMaxNumber(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxNumber;
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

	private static Delegate GetSetMaxNumber_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetMaxNumber_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetMaxNumber_I(nint jnienv, nint native__this, int maxNumber)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxNumber = maxNumber;
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

	private static Delegate GetGetNumberHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetNumber);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetNumber(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Number;
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

	private static Delegate GetSetNumber_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetNumber_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetNumber_I(nint jnienv, nint native__this, int number)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Number = number;
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
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Opacity;
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

	private static Delegate GetGetTextHandler()
	{
		return new global::_JniMarshal_PP_L(n_GetText);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Text);
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

	private static Delegate GetSetText_Ljava_lang_String_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetText_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetText_Ljava_lang_String_(nint jnienv, nint native__this, nint native_text)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BadgeDrawable? badgeDrawable = Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string text = JNIEnv.GetString(native_text, JniHandleOwnership.DoNotTransfer);
			badgeDrawable.Text = text;
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

	private static Delegate GetGetVerticalOffsetHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetVerticalOffset);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetVerticalOffset(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalOffset;
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

	private static Delegate GetSetVerticalOffset_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetVerticalOffset_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVerticalOffset_I(nint jnienv, nint native__this, int px)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalOffset = px;
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

	private static Delegate GetGetVerticalOffsetWithTextHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetVerticalOffsetWithText);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetVerticalOffsetWithText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalOffsetWithText;
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

	private static Delegate GetSetVerticalOffsetWithText_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetVerticalOffsetWithText_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVerticalOffsetWithText_I(nint jnienv, nint native__this, int px)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalOffsetWithText = px;
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

	private static Delegate GetGetVerticalOffsetWithoutTextHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetVerticalOffsetWithoutText);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetVerticalOffsetWithoutText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalOffsetWithoutText;
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

	private static Delegate GetSetVerticalOffsetWithoutText_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetVerticalOffsetWithoutText_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVerticalOffsetWithoutText_I(nint jnienv, nint native__this, int px)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalOffsetWithoutText = px;
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

	private static Delegate GetGetVerticalPaddingHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetVerticalPadding);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetVerticalPadding(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalPadding;
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

	private static Delegate GetSetVerticalPadding_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetVerticalPadding_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVerticalPadding_I(nint jnienv, nint native__this, int verticalPadding)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalPadding = verticalPadding;
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

	private static Delegate GetClearNumberHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearNumber);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearNumber(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearNumber();
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

	[Register("clearNumber", "()V", "GetClearNumberHandler")]
	public unsafe virtual void ClearNumber()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearNumber.()V", this, null);
	}

	private static Delegate GetClearTextHandler()
	{
		return new global::_JniMarshal_PP_V(n_ClearText);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ClearText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearText();
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

	[Register("clearText", "()V", "GetClearTextHandler")]
	public unsafe virtual void ClearText()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clearText.()V", this, null);
	}

	[Register("create", "(Landroid/content/Context;)Lcom/google/android/material/badge/BadgeDrawable;", "")]
	public unsafe static BadgeDrawable Create(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<BadgeDrawable>(_members.StaticMethods.InvokeObjectMethod("create.(Landroid/content/Context;)Lcom/google/android/material/badge/BadgeDrawable;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
		}
	}

	[Register("createFromResource", "(Landroid/content/Context;I)Lcom/google/android/material/badge/BadgeDrawable;", "")]
	public unsafe static BadgeDrawable CreateFromResource(Context context, int id)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(id);
			return Java.Lang.Object.GetObject<BadgeDrawable>(_members.StaticMethods.InvokeObjectMethod("createFromResource.(Landroid/content/Context;I)Lcom/google/android/material/badge/BadgeDrawable;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(context);
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
			BadgeDrawable? badgeDrawable = Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Canvas canvas = Java.Lang.Object.GetObject<Canvas>(native_canvas, JniHandleOwnership.DoNotTransfer);
			badgeDrawable.Draw(canvas);
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

	private static Delegate GetOnStateChange_arrayIHandler()
	{
		return new global::_JniMarshal_PPL_B(n_OnStateChange_arrayI);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnStateChange_arrayI(nint jnienv, nint native__this, nint native_state)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			BadgeDrawable? badgeDrawable = Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			int[] array = (int[])JNIEnv.GetArray(native_state, JniHandleOwnership.DoNotTransfer, typeof(int));
			sbyte result = (badgeDrawable.OnStateChange(array) ? ((sbyte)1) : ((sbyte)0));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_state);
			}
			return result;
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

	[Register("onStateChange", "([I)Z", "GetOnStateChange_arrayIHandler")]
	public new unsafe virtual bool OnStateChange(int[]? state)
	{
		nint num = JNIEnv.NewArray(state);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("onStateChange.([I)Z", this, ptr);
		}
		finally
		{
			if (state != null)
			{
				JNIEnv.CopyArray(num, state);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(state);
		}
	}

	private static Delegate GetOnTextSizeChangeHandler()
	{
		return new global::_JniMarshal_PP_V(n_OnTextSizeChange);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnTextSizeChange(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnTextSizeChange();
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
	[Register("onTextSizeChange", "()V", "GetOnTextSizeChangeHandler")]
	public unsafe virtual void OnTextSizeChange()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("onTextSizeChange.()V", this, null);
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
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetAlpha(alpha);
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

	private static Delegate GetSetAutoAdjustToWithinGrandparentBounds_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetAutoAdjustToWithinGrandparentBounds_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetAutoAdjustToWithinGrandparentBounds_Z(nint jnienv, nint native__this, sbyte native_autoAdjustToWithinGrandparentBounds)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BadgeDrawable? badgeDrawable = Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool autoAdjustToWithinGrandparentBounds = native_autoAdjustToWithinGrandparentBounds != 0;
			badgeDrawable.SetAutoAdjustToWithinGrandparentBounds(autoAdjustToWithinGrandparentBounds);
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

	[Register("setAutoAdjustToWithinGrandparentBounds", "(Z)V", "GetSetAutoAdjustToWithinGrandparentBounds_ZHandler")]
	public unsafe virtual void SetAutoAdjustToWithinGrandparentBounds(bool autoAdjustToWithinGrandparentBounds)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(autoAdjustToWithinGrandparentBounds ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setAutoAdjustToWithinGrandparentBounds.(Z)V", this, ptr);
	}

	private static Delegate GetSetBadgeWithTextShapeAppearance_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBadgeWithTextShapeAppearance_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBadgeWithTextShapeAppearance_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBadgeWithTextShapeAppearance(id);
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

	[Register("setBadgeWithTextShapeAppearance", "(I)V", "GetSetBadgeWithTextShapeAppearance_IHandler")]
	public unsafe virtual void SetBadgeWithTextShapeAppearance(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setBadgeWithTextShapeAppearance.(I)V", this, ptr);
	}

	private static Delegate GetSetBadgeWithTextShapeAppearanceOverlay_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBadgeWithTextShapeAppearanceOverlay_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBadgeWithTextShapeAppearanceOverlay_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBadgeWithTextShapeAppearanceOverlay(id);
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

	[Register("setBadgeWithTextShapeAppearanceOverlay", "(I)V", "GetSetBadgeWithTextShapeAppearanceOverlay_IHandler")]
	public unsafe virtual void SetBadgeWithTextShapeAppearanceOverlay(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setBadgeWithTextShapeAppearanceOverlay.(I)V", this, ptr);
	}

	private static Delegate GetSetBadgeWithoutTextShapeAppearance_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBadgeWithoutTextShapeAppearance_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBadgeWithoutTextShapeAppearance_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBadgeWithoutTextShapeAppearance(id);
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

	[Register("setBadgeWithoutTextShapeAppearance", "(I)V", "GetSetBadgeWithoutTextShapeAppearance_IHandler")]
	public unsafe virtual void SetBadgeWithoutTextShapeAppearance(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setBadgeWithoutTextShapeAppearance.(I)V", this, ptr);
	}

	private static Delegate GetSetBadgeWithoutTextShapeAppearanceOverlay_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetBadgeWithoutTextShapeAppearanceOverlay_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetBadgeWithoutTextShapeAppearanceOverlay_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetBadgeWithoutTextShapeAppearanceOverlay(id);
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

	[Register("setBadgeWithoutTextShapeAppearanceOverlay", "(I)V", "GetSetBadgeWithoutTextShapeAppearanceOverlay_IHandler")]
	public unsafe virtual void SetBadgeWithoutTextShapeAppearanceOverlay(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setBadgeWithoutTextShapeAppearanceOverlay.(I)V", this, ptr);
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
			BadgeDrawable? badgeDrawable = Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorFilter colorFilter = Java.Lang.Object.GetObject<ColorFilter>(native_colorFilter, JniHandleOwnership.DoNotTransfer);
			badgeDrawable.SetColorFilter(colorFilter);
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

	private static Delegate GetSetContentDescriptionExceedsMaxBadgeNumberStringResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetContentDescriptionExceedsMaxBadgeNumberStringResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentDescriptionExceedsMaxBadgeNumberStringResource_I(nint jnienv, nint native__this, int stringsResource)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetContentDescriptionExceedsMaxBadgeNumberStringResource(stringsResource);
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

	[Register("setContentDescriptionExceedsMaxBadgeNumberStringResource", "(I)V", "GetSetContentDescriptionExceedsMaxBadgeNumberStringResource_IHandler")]
	public unsafe virtual void SetContentDescriptionExceedsMaxBadgeNumberStringResource(int stringsResource)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(stringsResource);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setContentDescriptionExceedsMaxBadgeNumberStringResource.(I)V", this, ptr);
	}

	private static Delegate GetSetContentDescriptionForText_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetContentDescriptionForText_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentDescriptionForText_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_charSequence)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BadgeDrawable? badgeDrawable = Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence contentDescriptionForText = Java.Lang.Object.GetObject<ICharSequence>(native_charSequence, JniHandleOwnership.DoNotTransfer);
			badgeDrawable.SetContentDescriptionForText(contentDescriptionForText);
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

	[Register("setContentDescriptionForText", "(Ljava/lang/CharSequence;)V", "GetSetContentDescriptionForText_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual void SetContentDescriptionForText(ICharSequence? charSequence)
	{
		nint num = CharSequence.ToLocalJniHandle(charSequence);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setContentDescriptionForText.(Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(charSequence);
		}
	}

	public void SetContentDescriptionForText(string? charSequence)
	{
		Java.Lang.String obj = ((charSequence == null) ? null : new Java.Lang.String(charSequence));
		SetContentDescriptionForText(obj);
		obj?.Dispose();
	}

	private static Delegate GetSetContentDescriptionNumberless_Ljava_lang_CharSequence_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetContentDescriptionNumberless_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentDescriptionNumberless_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_charSequence)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BadgeDrawable? badgeDrawable = Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence contentDescriptionNumberless = Java.Lang.Object.GetObject<ICharSequence>(native_charSequence, JniHandleOwnership.DoNotTransfer);
			badgeDrawable.SetContentDescriptionNumberless(contentDescriptionNumberless);
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

	[Register("setContentDescriptionNumberless", "(Ljava/lang/CharSequence;)V", "GetSetContentDescriptionNumberless_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual void SetContentDescriptionNumberless(ICharSequence? charSequence)
	{
		nint num = CharSequence.ToLocalJniHandle(charSequence);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setContentDescriptionNumberless.(Ljava/lang/CharSequence;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(charSequence);
		}
	}

	public void SetContentDescriptionNumberless(string? charSequence)
	{
		Java.Lang.String obj = ((charSequence == null) ? null : new Java.Lang.String(charSequence));
		SetContentDescriptionNumberless(obj);
		obj?.Dispose();
	}

	private static Delegate GetSetContentDescriptionQuantityStringsResource_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetContentDescriptionQuantityStringsResource_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetContentDescriptionQuantityStringsResource_I(nint jnienv, nint native__this, int stringsResource)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetContentDescriptionQuantityStringsResource(stringsResource);
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

	[Register("setContentDescriptionQuantityStringsResource", "(I)V", "GetSetContentDescriptionQuantityStringsResource_IHandler")]
	public unsafe virtual void SetContentDescriptionQuantityStringsResource(int stringsResource)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(stringsResource);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setContentDescriptionQuantityStringsResource.(I)V", this, ptr);
	}

	private static Delegate GetSetTextAppearance_IHandler()
	{
		return new global::_JniMarshal_PPI_V(n_SetTextAppearance_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetTextAppearance_I(nint jnienv, nint native__this, int id)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTextAppearance(id);
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

	[Register("setTextAppearance", "(I)V", "GetSetTextAppearance_IHandler")]
	public unsafe virtual void SetTextAppearance(int id)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(id);
		_members.InstanceMethods.InvokeVirtualVoidMethod("setTextAppearance.(I)V", this, ptr);
	}

	private static Delegate GetSetVisible_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_SetVisible_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetVisible_Z(nint jnienv, nint native__this, sbyte native_visible)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BadgeDrawable? badgeDrawable = Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool visible = native_visible != 0;
			badgeDrawable.SetVisible(visible);
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

	[Register("setVisible", "(Z)V", "GetSetVisible_ZHandler")]
	public unsafe virtual void SetVisible(bool visible)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(visible ? ((sbyte)1) : ((sbyte)0));
		_members.InstanceMethods.InvokeVirtualVoidMethod("setVisible.(Z)V", this, ptr);
	}

	private static Delegate GetUpdateBadgeCoordinates_Landroid_view_View_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_UpdateBadgeCoordinates_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateBadgeCoordinates_Landroid_view_View_(nint jnienv, nint native__this, nint native_anchorView)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BadgeDrawable? badgeDrawable = Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View anchorView = Java.Lang.Object.GetObject<View>(native_anchorView, JniHandleOwnership.DoNotTransfer);
			badgeDrawable.UpdateBadgeCoordinates(anchorView);
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

	[Register("updateBadgeCoordinates", "(Landroid/view/View;)V", "GetUpdateBadgeCoordinates_Landroid_view_View_Handler")]
	public unsafe virtual void UpdateBadgeCoordinates(View anchorView)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(anchorView?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateBadgeCoordinates.(Landroid/view/View;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(anchorView);
		}
	}

	[Obsolete]
	private static Delegate GetUpdateBadgeCoordinates_Landroid_view_View_Landroid_view_ViewGroup_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_UpdateBadgeCoordinates_Landroid_view_View_Landroid_view_ViewGroup_);
	}

	[Obsolete]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateBadgeCoordinates_Landroid_view_View_Landroid_view_ViewGroup_(nint jnienv, nint native__this, nint native_anchorView, nint native_customBadgeParent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BadgeDrawable? badgeDrawable = Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View anchorView = Java.Lang.Object.GetObject<View>(native_anchorView, JniHandleOwnership.DoNotTransfer);
			ViewGroup customBadgeParent = Java.Lang.Object.GetObject<ViewGroup>(native_customBadgeParent, JniHandleOwnership.DoNotTransfer);
			badgeDrawable.UpdateBadgeCoordinates(anchorView, customBadgeParent);
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
	[Register("updateBadgeCoordinates", "(Landroid/view/View;Landroid/view/ViewGroup;)V", "GetUpdateBadgeCoordinates_Landroid_view_View_Landroid_view_ViewGroup_Handler")]
	public unsafe virtual void UpdateBadgeCoordinates(View anchorView, ViewGroup? customBadgeParent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(anchorView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(customBadgeParent?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateBadgeCoordinates.(Landroid/view/View;Landroid/view/ViewGroup;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(anchorView);
			GC.KeepAlive(customBadgeParent);
		}
	}

	private static Delegate GetUpdateBadgeCoordinates_Landroid_view_View_Landroid_widget_FrameLayout_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_UpdateBadgeCoordinates_Landroid_view_View_Landroid_widget_FrameLayout_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateBadgeCoordinates_Landroid_view_View_Landroid_widget_FrameLayout_(nint jnienv, nint native__this, nint native_anchorView, nint native_customBadgeParent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			BadgeDrawable? badgeDrawable = Java.Lang.Object.GetObject<BadgeDrawable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View anchorView = Java.Lang.Object.GetObject<View>(native_anchorView, JniHandleOwnership.DoNotTransfer);
			FrameLayout customBadgeParent = Java.Lang.Object.GetObject<FrameLayout>(native_customBadgeParent, JniHandleOwnership.DoNotTransfer);
			badgeDrawable.UpdateBadgeCoordinates(anchorView, customBadgeParent);
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

	[Register("updateBadgeCoordinates", "(Landroid/view/View;Landroid/widget/FrameLayout;)V", "GetUpdateBadgeCoordinates_Landroid_view_View_Landroid_widget_FrameLayout_Handler")]
	public unsafe virtual void UpdateBadgeCoordinates(View anchorView, FrameLayout? customBadgeParent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(anchorView?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(customBadgeParent?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateBadgeCoordinates.(Landroid/view/View;Landroid/widget/FrameLayout;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(anchorView);
			GC.KeepAlive(customBadgeParent);
		}
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
