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

	ActionProvider? ActionProvider
	{
		[Register("getActionProvider", "()Landroid/view/ActionProvider;", "GetGetActionProviderHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	View? ActionView
	{
		[Register("getActionView", "()Landroid/view/View;", "GetGetActionViewHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	char AlphabeticShortcut
	{
		[Register("getAlphabeticShortcut", "()C", "GetGetAlphabeticShortcutHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	int GroupId
	{
		[Register("getGroupId", "()I", "GetGetGroupIdHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool HasSubMenu
	{
		[Register("hasSubMenu", "()Z", "GetHasSubMenuHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	Drawable? Icon
	{
		[Register("getIcon", "()Landroid/graphics/drawable/Drawable;", "GetGetIconHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	Intent? Intent
	{
		[Register("getIntent", "()Landroid/content/Intent;", "GetGetIntentHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsActionViewExpanded
	{
		[Register("isActionViewExpanded", "()Z", "GetIsActionViewExpandedHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsCheckable
	{
		[Register("isCheckable", "()Z", "GetIsCheckableHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsChecked
	{
		[Register("isChecked", "()Z", "GetIsCheckedHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsEnabled
	{
		[Register("isEnabled", "()Z", "GetIsEnabledHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsVisible
	{
		[Register("isVisible", "()Z", "GetIsVisibleHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	int ItemId
	{
		[Register("getItemId", "()I", "GetGetItemIdHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	IContextMenuContextMenuInfo? MenuInfo
	{
		[Register("getMenuInfo", "()Landroid/view/ContextMenu$ContextMenuInfo;", "GetGetMenuInfoHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	char NumericShortcut
	{
		[Register("getNumericShortcut", "()C", "GetGetNumericShortcutHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	int Order
	{
		[Register("getOrder", "()I", "GetGetOrderHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	ISubMenu? SubMenu
	{
		[Register("getSubMenu", "()Landroid/view/SubMenu;", "GetGetSubMenuHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	ICharSequence? TitleFormatted
	{
		[Register("getTitle", "()Ljava/lang/CharSequence;", "GetGetTitleHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	ICharSequence? TitleCondensedFormatted
	{
		[Register("getTitleCondensed", "()Ljava/lang/CharSequence;", "GetGetTitleCondensedHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[SupportedOSPlatform("android26.0")]
	unsafe int AlphabeticModifiers
	{
		[Register("getAlphabeticModifiers", "()I", "GetGetAlphabeticModifiersHandler:Android.Views.IMenuItem, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getAlphabeticModifiers.()I", this, null);
		}
	}

	[SupportedOSPlatform("android26.0")]
	unsafe ICharSequence? ContentDescriptionFormatted
	{
		[Register("getContentDescription", "()Ljava/lang/CharSequence;", "GetGetContentDescriptionHandler:Android.Views.IMenuItem, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getContentDescription.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

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
	unsafe BlendMode? IconTintBlendMode
	{
		[Register("getIconTintBlendMode", "()Landroid/graphics/BlendMode;", "GetGetIconTintBlendModeHandler:Android.Views.IMenuItem, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 29)]
		get
		{
			return Java.Lang.Object.GetObject<BlendMode>(_members.InstanceMethods.InvokeVirtualObjectMethod("getIconTintBlendMode.()Landroid/graphics/BlendMode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[SupportedOSPlatform("android26.0")]
	unsafe ColorStateList? IconTintList
	{
		[Register("getIconTintList", "()Landroid/content/res/ColorStateList;", "GetGetIconTintListHandler:Android.Views.IMenuItem, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
		get
		{
			return Java.Lang.Object.GetObject<ColorStateList>(_members.InstanceMethods.InvokeVirtualObjectMethod("getIconTintList.()Landroid/content/res/ColorStateList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[SupportedOSPlatform("android26.0")]
	unsafe PorterDuff.Mode? IconTintMode
	{
		[Register("getIconTintMode", "()Landroid/graphics/PorterDuff$Mode;", "GetGetIconTintModeHandler:Android.Views.IMenuItem, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
		get
		{
			return Java.Lang.Object.GetObject<PorterDuff.Mode>(_members.InstanceMethods.InvokeVirtualObjectMethod("getIconTintMode.()Landroid/graphics/PorterDuff$Mode;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	[SupportedOSPlatform("android26.0")]
	unsafe int NumericModifiers
	{
		[Register("getNumericModifiers", "()I", "GetGetNumericModifiersHandler:Android.Views.IMenuItem, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
		get
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getNumericModifiers.()I", this, null);
		}
	}

	[SupportedOSPlatform("android26.0")]
	unsafe ICharSequence? TooltipTextFormatted
	{
		[Register("getTooltipText", "()Ljava/lang/CharSequence;", "GetGetTooltipTextHandler:Android.Views.IMenuItem, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
		get
		{
			return Java.Lang.Object.GetObject<ICharSequence>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTooltipText.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

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

	[Register("collapseActionView", "()Z", "GetCollapseActionViewHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool CollapseActionView();

	[Register("expandActionView", "()Z", "GetExpandActionViewHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool ExpandActionView();

	[Register("setActionProvider", "(Landroid/view/ActionProvider;)Landroid/view/MenuItem;", "GetSetActionProvider_Landroid_view_ActionProvider_Handler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetActionProvider(ActionProvider? actionProvider);

	[Register("setActionView", "(Landroid/view/View;)Landroid/view/MenuItem;", "GetSetActionView_Landroid_view_View_Handler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetActionView(View? view);

	[Register("setActionView", "(I)Landroid/view/MenuItem;", "GetSetActionView_IHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetActionView(int resId);

	[Register("setAlphabeticShortcut", "(C)Landroid/view/MenuItem;", "GetSetAlphabeticShortcut_CHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetAlphabeticShortcut(char alphaChar);

	[Register("setCheckable", "(Z)Landroid/view/MenuItem;", "GetSetCheckable_ZHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetCheckable(bool checkable);

	[Register("setChecked", "(Z)Landroid/view/MenuItem;", "GetSetChecked_ZHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetChecked(bool @checked);

	[Register("setEnabled", "(Z)Landroid/view/MenuItem;", "GetSetEnabled_ZHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetEnabled(bool enabled);

	[Register("setIcon", "(Landroid/graphics/drawable/Drawable;)Landroid/view/MenuItem;", "GetSetIcon_Landroid_graphics_drawable_Drawable_Handler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetIcon(Drawable? icon);

	[Register("setIcon", "(I)Landroid/view/MenuItem;", "GetSetIcon_IHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetIcon(int iconRes);

	[Register("setIntent", "(Landroid/content/Intent;)Landroid/view/MenuItem;", "GetSetIntent_Landroid_content_Intent_Handler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetIntent(Intent? intent);

	[Register("setNumericShortcut", "(C)Landroid/view/MenuItem;", "GetSetNumericShortcut_CHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetNumericShortcut(char numericChar);

	[Register("setOnActionExpandListener", "(Landroid/view/MenuItem$OnActionExpandListener;)Landroid/view/MenuItem;", "GetSetOnActionExpandListener_Landroid_view_MenuItem_OnActionExpandListener_Handler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetOnActionExpandListener(IMenuItemOnActionExpandListener? listener);

	[Register("setOnMenuItemClickListener", "(Landroid/view/MenuItem$OnMenuItemClickListener;)Landroid/view/MenuItem;", "GetSetOnMenuItemClickListener_Landroid_view_MenuItem_OnMenuItemClickListener_Handler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetOnMenuItemClickListener(IMenuItemOnMenuItemClickListener? menuItemClickListener);

	[Register("setShortcut", "(CC)Landroid/view/MenuItem;", "GetSetShortcut_CCHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetShortcut(char numericChar, char alphaChar);

	[Register("setShowAsAction", "(I)V", "GetSetShowAsAction_IHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void SetShowAsAction(ShowAsAction actionEnum);

	[Register("setShowAsActionFlags", "(I)Landroid/view/MenuItem;", "GetSetShowAsActionFlags_IHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetShowAsActionFlags(ShowAsAction actionEnum);

	[Register("setTitle", "(I)Landroid/view/MenuItem;", "GetSetTitle_IHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetTitle(int title);

	[Register("setTitle", "(Ljava/lang/CharSequence;)Landroid/view/MenuItem;", "GetSetTitle_Ljava_lang_CharSequence_Handler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetTitle(ICharSequence? title);

	[Register("setTitleCondensed", "(Ljava/lang/CharSequence;)Landroid/view/MenuItem;", "GetSetTitleCondensed_Ljava_lang_CharSequence_Handler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IMenuItem SetTitleCondensed(ICharSequence? title);

	[Register("setVisible", "(Z)Landroid/view/MenuItem;", "GetSetVisible_ZHandler:Android.Views.IMenuItemInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
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
	[Register("setAlphabeticShortcut", "(CI)Landroid/view/MenuItem;", "GetSetAlphabeticShortcut_CIHandler:Android.Views.IMenuItem, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
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
	[Register("setContentDescription", "(Ljava/lang/CharSequence;)Landroid/view/MenuItem;", "GetSetContentDescription_Ljava_lang_CharSequence_Handler:Android.Views.IMenuItem, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
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
	[Register("setIconTintBlendMode", "(Landroid/graphics/BlendMode;)Landroid/view/MenuItem;", "GetSetIconTintBlendMode_Landroid_graphics_BlendMode_Handler:Android.Views.IMenuItem, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 29)]
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
	[Register("setIconTintList", "(Landroid/content/res/ColorStateList;)Landroid/view/MenuItem;", "GetSetIconTintList_Landroid_content_res_ColorStateList_Handler:Android.Views.IMenuItem, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
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
	[Register("setIconTintMode", "(Landroid/graphics/PorterDuff$Mode;)Landroid/view/MenuItem;", "GetSetIconTintMode_Landroid_graphics_PorterDuff_Mode_Handler:Android.Views.IMenuItem, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
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
	[Register("setNumericShortcut", "(CI)Landroid/view/MenuItem;", "GetSetNumericShortcut_CIHandler:Android.Views.IMenuItem, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
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
	[Register("setShortcut", "(CCII)Landroid/view/MenuItem;", "GetSetShortcut_CCIIHandler:Android.Views.IMenuItem, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
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
	[Register("setTooltipText", "(Ljava/lang/CharSequence;)Landroid/view/MenuItem;", "GetSetTooltipText_Ljava_lang_CharSequence_Handler:Android.Views.IMenuItem, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null", ApiSince = 26)]
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
