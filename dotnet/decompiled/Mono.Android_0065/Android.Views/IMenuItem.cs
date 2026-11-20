using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/MenuItem", "", "Android.Views.IMenuItemInvoker")]
public interface IMenuItem : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/MenuItem", typeof(IMenuItem), isInterface: true);

	private static Delegate? cb_getAlphabeticModifiers_GetAlphabeticModifiers_I;

	private static Delegate? cb_getContentDescription_GetContentDescription_Ljava_lang_CharSequence_;

	private static Delegate? cb_getIconTintBlendMode_GetIconTintBlendMode_Landroid_graphics_BlendMode_;

	private static Delegate? cb_getIconTintList_GetIconTintList_Landroid_content_res_ColorStateList_;

	private static Delegate? cb_getIconTintMode_GetIconTintMode_Landroid_graphics_PorterDuff_Mode_;

	private static Delegate? cb_getNumericModifiers_GetNumericModifiers_I;

	private static Delegate? cb_getTooltipText_GetTooltipText_Ljava_lang_CharSequence_;

	private static Delegate? cb_setAlphabeticShortcut_SetAlphabeticShortcut_CI_Landroid_view_MenuItem_;

	private static Delegate? cb_setContentDescription_SetContentDescription_Ljava_lang_CharSequence__Landroid_view_MenuItem_;

	private static Delegate? cb_setIconTintBlendMode_SetIconTintBlendMode_Landroid_graphics_BlendMode__Landroid_view_MenuItem_;

	private static Delegate? cb_setIconTintList_SetIconTintList_Landroid_content_res_ColorStateList__Landroid_view_MenuItem_;

	private static Delegate? cb_setIconTintMode_SetIconTintMode_Landroid_graphics_PorterDuff_Mode__Landroid_view_MenuItem_;

	private static Delegate? cb_setNumericShortcut_SetNumericShortcut_CI_Landroid_view_MenuItem_;

	private static Delegate? cb_setShortcut_SetShortcut_CCII_Landroid_view_MenuItem_;

	private static Delegate? cb_setTooltipText_SetTooltipText_Ljava_lang_CharSequence__Landroid_view_MenuItem_;

	ActionProvider? ActionProvider { get; }

	View? ActionView { get; }

	char AlphabeticShortcut { get; }

	int GroupId { get; }

	bool HasSubMenu { get; }

	Drawable? Icon { get; }

	Intent? Intent { get; }

	bool IsActionViewExpanded { get; }

	bool IsCheckable { get; }

	bool IsChecked { get; }

	bool IsEnabled { get; }

	bool IsVisible { get; }

	int ItemId { get; }

	IContextMenuContextMenuInfo? MenuInfo { get; }

	char NumericShortcut { get; }

	int Order { get; }

	ISubMenu? SubMenu { get; }

	ICharSequence? TitleFormatted { get; }

	ICharSequence? TitleCondensedFormatted { get; }

	[SupportedOSPlatform("android26.0")]
	unsafe int AlphabeticModifiers => _members.InstanceMethods.InvokeVirtualInt32Method("getAlphabeticModifiers.()I", this, null);

	[SupportedOSPlatform("android26.0")]
	unsafe ICharSequence? ContentDescriptionFormatted => Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContentDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	[SupportedOSPlatform("android26.0")]
	string? ContentDescription
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

	[SupportedOSPlatform("android29.0")]
	unsafe BlendMode? IconTintBlendMode => Java.Lang.Object.GetObject<BlendMode>(_members.InstanceMethods.InvokeVirtualObjectMethod("getIconTintBlendMode.()Landroid/graphics/BlendMode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	[SupportedOSPlatform("android26.0")]
	unsafe ColorStateList? IconTintList => Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getIconTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	[SupportedOSPlatform("android26.0")]
	unsafe PorterDuff.Mode? IconTintMode => Java.Lang.Object.GetObject<PorterDuff.Mode>(_members.InstanceMethods.InvokeVirtualObjectMethod("getIconTintMode.()Landroid/graphics/PorterDuff$Mode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	[SupportedOSPlatform("android26.0")]
	unsafe int NumericModifiers => _members.InstanceMethods.InvokeVirtualInt32Method("getNumericModifiers.()I", this, null);

	[SupportedOSPlatform("android26.0")]
	unsafe ICharSequence? TooltipTextFormatted => Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTooltipText.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	[SupportedOSPlatform("android26.0")]
	string? TooltipText
	{
		get
		{
			if (TooltipTextFormatted != null)
			{
				return TooltipTextFormatted.ToString();
			}
			return null;
		}
	}

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetGetAlphabeticModifiersHandler()
	{
		return new _JniMarshal_PP_I(n_GetAlphabeticModifiers);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetAlphabeticModifiers(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AlphabeticModifiers;
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

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetGetContentDescriptionHandler()
	{
		return new _JniMarshal_PP_L(n_GetContentDescription);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetContentDescription(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContentDescriptionFormatted);
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

	[SupportedOSPlatform("android29.0")]
	private static Delegate GetGetIconTintBlendModeHandler()
	{
		return new _JniMarshal_PP_L(n_GetIconTintBlendMode);
	}

	[SupportedOSPlatform("android29.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetIconTintBlendMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconTintBlendMode);
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

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetGetIconTintListHandler()
	{
		return new _JniMarshal_PP_L(n_GetIconTintList);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetIconTintList(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconTintList);
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

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetGetIconTintModeHandler()
	{
		return new _JniMarshal_PP_L(n_GetIconTintMode);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetIconTintMode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IconTintMode);
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

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetGetNumericModifiersHandler()
	{
		return new _JniMarshal_PP_I(n_GetNumericModifiers);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetNumericModifiers(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NumericModifiers;
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

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetGetTooltipTextHandler()
	{
		return new _JniMarshal_PP_L(n_GetTooltipText);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTooltipText(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TooltipTextFormatted);
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

	bool CollapseActionView();

	bool ExpandActionView();

	IMenuItem SetActionProvider(ActionProvider? actionProvider);

	IMenuItem SetActionView(View? view);

	IMenuItem SetActionView(int resId);

	IMenuItem SetAlphabeticShortcut(char alphaChar);

	IMenuItem SetCheckable(bool checkable);

	IMenuItem SetChecked(bool @checked);

	IMenuItem SetEnabled(bool enabled);

	IMenuItem SetIcon(Drawable? icon);

	IMenuItem SetIcon(int iconRes);

	IMenuItem SetIntent(Intent? intent);

	IMenuItem SetNumericShortcut(char numericChar);

	IMenuItem SetOnActionExpandListener(IMenuItemOnActionExpandListener? listener);

	IMenuItem SetOnMenuItemClickListener(IMenuItemOnMenuItemClickListener? menuItemClickListener);

	IMenuItem SetShortcut(char numericChar, char alphaChar);

	void SetShowAsAction(ShowAsAction actionEnum);

	IMenuItem SetShowAsActionFlags(ShowAsAction actionEnum);

	IMenuItem SetTitle(int title);

	IMenuItem SetTitle(ICharSequence? title);

	IMenuItem SetTitleCondensed(ICharSequence? title);

	IMenuItem SetVisible(bool visible);

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetSetAlphabeticShortcut_CIHandler()
	{
		return new _JniMarshal_PPsI_L(n_SetAlphabeticShortcut_CI);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetAlphabeticShortcut_CI(nint jnienv, nint native__this, ushort native_alphaChar, int alphaModifiers)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char alphaChar = (char)native_alphaChar;
			return JNIEnv.ToLocalJniHandle(menuItem.SetAlphabeticShortcut(alphaChar, alphaModifiers));
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

	[SupportedOSPlatform("android26.0")]
	unsafe IMenuItem SetAlphabeticShortcut(char alphaChar, int alphaModifiers)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue((ushort)alphaChar);
		ptr[1] = new JniArgumentValue(alphaModifiers);
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("setAlphabeticShortcut.(CI)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetSetContentDescription_Ljava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetContentDescription_Ljava_lang_CharSequence_);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetContentDescription_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_contentDescription)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence contentDescription = Java.Lang.Object.GetObject<ICharSequence>(native_contentDescription, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuItem.SetContentDescription(contentDescription));
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

	[SupportedOSPlatform("android26.0")]
	unsafe IMenuItem SetContentDescription(ICharSequence? contentDescription)
	{
		nint num = CharSequence.ToLocalJniHandle(contentDescription);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("setContentDescription.(Ljava/lang/CharSequence;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(contentDescription);
		}
	}

	[SupportedOSPlatform("android26.0")]
	IMenuItem SetContentDescription(string? contentDescription)
	{
		Java.Lang.String obj = ((contentDescription == null) ? null : new Java.Lang.String(contentDescription));
		IMenuItem result = SetContentDescription(obj);
		obj?.Dispose();
		return result;
	}

	[SupportedOSPlatform("android29.0")]
	private static Delegate GetSetIconTintBlendMode_Landroid_graphics_BlendMode_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetIconTintBlendMode_Landroid_graphics_BlendMode_);
	}

	[SupportedOSPlatform("android29.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetIconTintBlendMode_Landroid_graphics_BlendMode_(nint jnienv, nint native__this, nint native_blendMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BlendMode iconTintBlendMode = Java.Lang.Object.GetObject<BlendMode>(native_blendMode, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuItem.SetIconTintBlendMode(iconTintBlendMode));
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

	[SupportedOSPlatform("android29.0")]
	unsafe IMenuItem SetIconTintBlendMode(BlendMode? blendMode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(blendMode?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("setIconTintBlendMode.(Landroid/graphics/BlendMode;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(blendMode);
		}
	}

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetSetIconTintList_Landroid_content_res_ColorStateList_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetIconTintList_Landroid_content_res_ColorStateList_);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetIconTintList_Landroid_content_res_ColorStateList_(nint jnienv, nint native__this, nint native_tint)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ColorStateList iconTintList = Java.Lang.Object.GetObject<ColorStateList>(native_tint, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuItem.SetIconTintList(iconTintList));
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

	[SupportedOSPlatform("android26.0")]
	unsafe IMenuItem SetIconTintList(ColorStateList? tint)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tint?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("setIconTintList.(Landroid/content/res/ColorStateList;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(tint);
		}
	}

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetSetIconTintMode_Landroid_graphics_PorterDuff_Mode_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetIconTintMode_Landroid_graphics_PorterDuff_Mode_);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetIconTintMode_Landroid_graphics_PorterDuff_Mode_(nint jnienv, nint native__this, nint native_tintMode)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			PorterDuff.Mode iconTintMode = Java.Lang.Object.GetObject<PorterDuff.Mode>(native_tintMode, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuItem.SetIconTintMode(iconTintMode));
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

	[SupportedOSPlatform("android26.0")]
	unsafe IMenuItem SetIconTintMode(PorterDuff.Mode? tintMode)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(tintMode?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("setIconTintMode.(Landroid/graphics/PorterDuff$Mode;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(tintMode);
		}
	}

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetSetNumericShortcut_CIHandler()
	{
		return new _JniMarshal_PPsI_L(n_SetNumericShortcut_CI);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetNumericShortcut_CI(nint jnienv, nint native__this, ushort native_numericChar, int numericModifiers)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char numericChar = (char)native_numericChar;
			return JNIEnv.ToLocalJniHandle(menuItem.SetNumericShortcut(numericChar, numericModifiers));
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

	[SupportedOSPlatform("android26.0")]
	unsafe IMenuItem SetNumericShortcut(char numericChar, int numericModifiers)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue((ushort)numericChar);
		ptr[1] = new JniArgumentValue(numericModifiers);
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("setNumericShortcut.(CI)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetSetShortcut_CCIIHandler()
	{
		return new _JniMarshal_PPssII_L(n_SetShortcut_CCII);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetShortcut_CCII(nint jnienv, nint native__this, ushort native_numericChar, ushort native_alphaChar, int numericModifiers, int alphaModifiers)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char numericChar = (char)native_numericChar;
			char alphaChar = (char)native_alphaChar;
			return JNIEnv.ToLocalJniHandle(menuItem.SetShortcut(numericChar, alphaChar, numericModifiers, alphaModifiers));
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

	[SupportedOSPlatform("android26.0")]
	unsafe IMenuItem SetShortcut(char numericChar, char alphaChar, int numericModifiers, int alphaModifiers)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
		*ptr = new JniArgumentValue((ushort)numericChar);
		ptr[1] = new JniArgumentValue((ushort)alphaChar);
		ptr[2] = new JniArgumentValue(numericModifiers);
		ptr[3] = new JniArgumentValue(alphaModifiers);
		return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("setShortcut.(CCII)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[SupportedOSPlatform("android26.0")]
	private static Delegate GetSetTooltipText_Ljava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetTooltipText_Ljava_lang_CharSequence_);
	}

	[SupportedOSPlatform("android26.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetTooltipText_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_tooltipText)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence tooltipText = Java.Lang.Object.GetObject<ICharSequence>(native_tooltipText, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuItem.SetTooltipText(tooltipText));
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

	[SupportedOSPlatform("android26.0")]
	unsafe IMenuItem SetTooltipText(ICharSequence? tooltipText)
	{
		nint num = CharSequence.ToLocalJniHandle(tooltipText);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IMenuItem>(_members.InstanceMethods.InvokeVirtualObjectMethod("setTooltipText.(Ljava/lang/CharSequence;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(tooltipText);
		}
	}

	[SupportedOSPlatform("android26.0")]
	IMenuItem SetTooltipText(string? tooltipText)
	{
		Java.Lang.String obj = ((tooltipText == null) ? null : new Java.Lang.String(tooltipText));
		IMenuItem result = SetTooltipText(obj);
		obj?.Dispose();
		return result;
	}
}
