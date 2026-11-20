using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/MenuItem", DoNotGenerateAcw = true)]
internal class IMenuItemInvoker : Java.Lang.Object, IMenuItem, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_view_MenuItem = new XAPeerMembers("android/view/MenuItem", typeof(IMenuItemInvoker));

	private static Delegate? cb_getActionProvider_GetActionProvider_Landroid_view_ActionProvider_;

	private static Delegate? cb_getActionView_GetActionView_Landroid_view_View_;

	private static Delegate? cb_getAlphabeticShortcut_GetAlphabeticShortcut_C;

	private static Delegate? cb_getGroupId_GetGroupId_I;

	private static Delegate? cb_hasSubMenu_HasSubMenu_Z;

	private static Delegate? cb_getIcon_GetIcon_Landroid_graphics_drawable_Drawable_;

	private static Delegate? cb_getIntent_GetIntent_Landroid_content_Intent_;

	private static Delegate? cb_isActionViewExpanded_IsActionViewExpanded_Z;

	private static Delegate? cb_isCheckable_IsCheckable_Z;

	private static Delegate? cb_isChecked_IsChecked_Z;

	private static Delegate? cb_isEnabled_IsEnabled_Z;

	private static Delegate? cb_isVisible_IsVisible_Z;

	private static Delegate? cb_getItemId_GetItemId_I;

	private static Delegate? cb_getMenuInfo_GetMenuInfo_Landroid_view_ContextMenu_ContextMenuInfo_;

	private static Delegate? cb_getNumericShortcut_GetNumericShortcut_C;

	private static Delegate? cb_getOrder_GetOrder_I;

	private static Delegate? cb_getSubMenu_GetSubMenu_Landroid_view_SubMenu_;

	private static Delegate? cb_getTitle_GetTitle_Ljava_lang_CharSequence_;

	private static Delegate? cb_getTitleCondensed_GetTitleCondensed_Ljava_lang_CharSequence_;

	private static Delegate? cb_collapseActionView_CollapseActionView_Z;

	private static Delegate? cb_expandActionView_ExpandActionView_Z;

	private static Delegate? cb_setActionProvider_SetActionProvider_Landroid_view_ActionProvider__Landroid_view_MenuItem_;

	private static Delegate? cb_setActionView_SetActionView_Landroid_view_View__Landroid_view_MenuItem_;

	private static Delegate? cb_setActionView_SetActionView_I_Landroid_view_MenuItem_;

	private static Delegate? cb_setAlphabeticShortcut_SetAlphabeticShortcut_C_Landroid_view_MenuItem_;

	private static Delegate? cb_setCheckable_SetCheckable_Z_Landroid_view_MenuItem_;

	private static Delegate? cb_setChecked_SetChecked_Z_Landroid_view_MenuItem_;

	private static Delegate? cb_setEnabled_SetEnabled_Z_Landroid_view_MenuItem_;

	private static Delegate? cb_setIcon_SetIcon_Landroid_graphics_drawable_Drawable__Landroid_view_MenuItem_;

	private static Delegate? cb_setIcon_SetIcon_I_Landroid_view_MenuItem_;

	private static Delegate? cb_setIntent_SetIntent_Landroid_content_Intent__Landroid_view_MenuItem_;

	private static Delegate? cb_setNumericShortcut_SetNumericShortcut_C_Landroid_view_MenuItem_;

	private static Delegate? cb_setOnActionExpandListener_SetOnActionExpandListener_Landroid_view_MenuItem_OnActionExpandListener__Landroid_view_MenuItem_;

	private static Delegate? cb_setOnMenuItemClickListener_SetOnMenuItemClickListener_Landroid_view_MenuItem_OnMenuItemClickListener__Landroid_view_MenuItem_;

	private static Delegate? cb_setShortcut_SetShortcut_CC_Landroid_view_MenuItem_;

	private static Delegate? cb_setShowAsAction_SetShowAsAction_I_V;

	private static Delegate? cb_setShowAsActionFlags_SetShowAsActionFlags_I_Landroid_view_MenuItem_;

	private static Delegate? cb_setTitle_SetTitle_I_Landroid_view_MenuItem_;

	private static Delegate? cb_setTitle_SetTitle_Ljava_lang_CharSequence__Landroid_view_MenuItem_;

	private static Delegate? cb_setTitleCondensed_SetTitleCondensed_Ljava_lang_CharSequence__Landroid_view_MenuItem_;

	private static Delegate? cb_setVisible_SetVisible_Z_Landroid_view_MenuItem_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_view_MenuItem;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_view_MenuItem.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_view_MenuItem.ManagedPeerType;

	public unsafe ActionProvider? ActionProvider => Java.Lang.Object.GetObject<ActionProvider>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("getActionProvider.()Landroid/view/ActionProvider;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe View? ActionView => Java.Lang.Object.GetObject<View>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("getActionView.()Landroid/view/View;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe char AlphabeticShortcut => _members_android_view_MenuItem.InstanceMethods.InvokeAbstractCharMethod("getAlphabeticShortcut.()C", this, null);

	public unsafe int GroupId => _members_android_view_MenuItem.InstanceMethods.InvokeAbstractInt32Method("getGroupId.()I", this, null);

	public unsafe bool HasSubMenu => _members_android_view_MenuItem.InstanceMethods.InvokeAbstractBooleanMethod("hasSubMenu.()Z", this, null);

	public unsafe Drawable? Icon => Java.Lang.Object.GetObject<Drawable>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("getIcon.()Landroid/graphics/drawable/Drawable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe Intent? Intent => Java.Lang.Object.GetObject<Intent>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("getIntent.()Landroid/content/Intent;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe bool IsActionViewExpanded => _members_android_view_MenuItem.InstanceMethods.InvokeAbstractBooleanMethod("isActionViewExpanded.()Z", this, null);

	public unsafe bool IsCheckable => _members_android_view_MenuItem.InstanceMethods.InvokeAbstractBooleanMethod("isCheckable.()Z", this, null);

	public unsafe bool IsChecked => _members_android_view_MenuItem.InstanceMethods.InvokeAbstractBooleanMethod("isChecked.()Z", this, null);

	public unsafe bool IsEnabled => _members_android_view_MenuItem.InstanceMethods.InvokeAbstractBooleanMethod("isEnabled.()Z", this, null);

	public unsafe bool IsVisible => _members_android_view_MenuItem.InstanceMethods.InvokeAbstractBooleanMethod("isVisible.()Z", this, null);

	public unsafe int ItemId => _members_android_view_MenuItem.InstanceMethods.InvokeAbstractInt32Method("getItemId.()I", this, null);

	public unsafe IContextMenuContextMenuInfo? MenuInfo => Java.Lang.Object.GetObject<IContextMenuContextMenuInfo>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("getMenuInfo.()Landroid/view/ContextMenu$ContextMenuInfo;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe char NumericShortcut => _members_android_view_MenuItem.InstanceMethods.InvokeAbstractCharMethod("getNumericShortcut.()C", this, null);

	public unsafe int Order => _members_android_view_MenuItem.InstanceMethods.InvokeAbstractInt32Method("getOrder.()I", this, null);

	public unsafe ISubMenu? SubMenu => Java.Lang.Object.GetObject<ISubMenu>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("getSubMenu.()Landroid/view/SubMenu;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe ICharSequence? TitleFormatted => Java.Lang.Object.GetObject<ICharSequence>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("getTitle.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe ICharSequence? TitleCondensedFormatted => Java.Lang.Object.GetObject<ICharSequence>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("getTitleCondensed.()Ljava/lang/CharSequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IMenuItemInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetActionProviderHandler()
	{
		return new _JniMarshal_PP_L(n_GetActionProvider);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetActionProvider(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ActionProvider);
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

	private static Delegate GetGetActionViewHandler()
	{
		return new _JniMarshal_PP_L(n_GetActionView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetActionView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ActionView);
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

	private static Delegate GetGetAlphabeticShortcutHandler()
	{
		return new _JniMarshal_PP_s(n_GetAlphabeticShortcut);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static ushort n_GetAlphabeticShortcut(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AlphabeticShortcut;
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

	private static Delegate GetGetGroupIdHandler()
	{
		return new _JniMarshal_PP_I(n_GetGroupId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetGroupId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GroupId;
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

	private static Delegate GetHasSubMenuHandler()
	{
		return new _JniMarshal_PP_B(n_HasSubMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_HasSubMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasSubMenu ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetIconHandler()
	{
		return new _JniMarshal_PP_L(n_GetIcon);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetIcon(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Icon);
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

	private static Delegate GetGetIntentHandler()
	{
		return new _JniMarshal_PP_L(n_GetIntent);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetIntent(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Intent);
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

	private static Delegate GetIsActionViewExpandedHandler()
	{
		return new _JniMarshal_PP_B(n_IsActionViewExpanded);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsActionViewExpanded(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsActionViewExpanded ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsCheckableHandler()
	{
		return new _JniMarshal_PP_B(n_IsCheckable);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsCheckable(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCheckable ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsCheckedHandler()
	{
		return new _JniMarshal_PP_B(n_IsChecked);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsChecked(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsChecked ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsEnabledHandler()
	{
		return new _JniMarshal_PP_B(n_IsEnabled);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsEnabled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEnabled ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetIsVisibleHandler()
	{
		return new _JniMarshal_PP_B(n_IsVisible);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsVisible(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsVisible ? ((sbyte)1) : ((sbyte)0);
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

	private static Delegate GetGetItemIdHandler()
	{
		return new _JniMarshal_PP_I(n_GetItemId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetItemId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ItemId;
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

	private static Delegate GetGetMenuInfoHandler()
	{
		return new _JniMarshal_PP_L(n_GetMenuInfo);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMenuInfo(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MenuInfo);
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

	private static Delegate GetGetNumericShortcutHandler()
	{
		return new _JniMarshal_PP_s(n_GetNumericShortcut);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static ushort n_GetNumericShortcut(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NumericShortcut;
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

	private static Delegate GetGetOrderHandler()
	{
		return new _JniMarshal_PP_I(n_GetOrder);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetOrder(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Order;
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

	private static Delegate GetGetSubMenuHandler()
	{
		return new _JniMarshal_PP_L(n_GetSubMenu);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSubMenu(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SubMenu);
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

	private static Delegate GetGetTitleHandler()
	{
		return new _JniMarshal_PP_L(n_GetTitle);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTitle(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TitleFormatted);
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

	private static Delegate GetGetTitleCondensedHandler()
	{
		return new _JniMarshal_PP_L(n_GetTitleCondensed);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetTitleCondensed(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return CharSequence.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TitleCondensedFormatted);
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

	private static Delegate GetCollapseActionViewHandler()
	{
		return new _JniMarshal_PP_B(n_CollapseActionView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CollapseActionView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CollapseActionView() ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool CollapseActionView()
	{
		return _members_android_view_MenuItem.InstanceMethods.InvokeAbstractBooleanMethod("collapseActionView.()Z", this, null);
	}

	private static Delegate GetExpandActionViewHandler()
	{
		return new _JniMarshal_PP_B(n_ExpandActionView);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ExpandActionView(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ExpandActionView() ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool ExpandActionView()
	{
		return _members_android_view_MenuItem.InstanceMethods.InvokeAbstractBooleanMethod("expandActionView.()Z", this, null);
	}

	private static Delegate GetSetActionProvider_Landroid_view_ActionProvider_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetActionProvider_Landroid_view_ActionProvider_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetActionProvider_Landroid_view_ActionProvider_(nint jnienv, nint native__this, nint native_actionProvider)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ActionProvider actionProvider = Java.Lang.Object.GetObject<ActionProvider>(native_actionProvider, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuItem.SetActionProvider(actionProvider));
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

	public unsafe IMenuItem SetActionProvider(ActionProvider? actionProvider)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(actionProvider?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setActionProvider.(Landroid/view/ActionProvider;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(actionProvider);
		}
	}

	private static Delegate GetSetActionView_Landroid_view_View_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetActionView_Landroid_view_View_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetActionView_Landroid_view_View_(nint jnienv, nint native__this, nint native_view)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			View actionView = Java.Lang.Object.GetObject<View>(native_view, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuItem.SetActionView(actionView));
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

	public unsafe IMenuItem SetActionView(View? view)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(view?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setActionView.(Landroid/view/View;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(view);
		}
	}

	private static Delegate GetSetActionView_IHandler()
	{
		return new _JniMarshal_PPI_L(n_SetActionView_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetActionView_I(nint jnienv, nint native__this, int resId)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetActionView(resId));
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

	public unsafe IMenuItem SetActionView(int resId)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(resId);
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setActionView.(I)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetAlphabeticShortcut_CHandler()
	{
		return new _JniMarshal_PPs_L(n_SetAlphabeticShortcut_C);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetAlphabeticShortcut_C(nint jnienv, nint native__this, ushort native_alphaChar)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char alphabeticShortcut = (char)native_alphaChar;
			return JNIEnv.ToLocalJniHandle(menuItem.SetAlphabeticShortcut(alphabeticShortcut));
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

	public unsafe IMenuItem SetAlphabeticShortcut(char alphaChar)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((ushort)alphaChar);
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setAlphabeticShortcut.(C)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetCheckable_ZHandler()
	{
		return new _JniMarshal_PPB_L(n_SetCheckable_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetCheckable_Z(nint jnienv, nint native__this, sbyte native_checkable)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool checkable = native_checkable != 0;
			return JNIEnv.ToLocalJniHandle(menuItem.SetCheckable(checkable));
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

	public unsafe IMenuItem SetCheckable(bool checkable)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(checkable ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setCheckable.(Z)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetChecked_ZHandler()
	{
		return new _JniMarshal_PPB_L(n_SetChecked_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetChecked_Z(nint jnienv, nint native__this, sbyte native__checked)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool flag = native__checked != 0;
			return JNIEnv.ToLocalJniHandle(menuItem.SetChecked(flag));
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

	public unsafe IMenuItem SetChecked(bool @checked)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(@checked ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setChecked.(Z)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetEnabled_ZHandler()
	{
		return new _JniMarshal_PPB_L(n_SetEnabled_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetEnabled_Z(nint jnienv, nint native__this, sbyte native_enabled)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool enabled = native_enabled != 0;
			return JNIEnv.ToLocalJniHandle(menuItem.SetEnabled(enabled));
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

	public unsafe IMenuItem SetEnabled(bool enabled)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(enabled ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setEnabled.(Z)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetIcon_Landroid_graphics_drawable_Drawable_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetIcon_Landroid_graphics_drawable_Drawable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetIcon_Landroid_graphics_drawable_Drawable_(nint jnienv, nint native__this, nint native_icon)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Drawable icon = Java.Lang.Object.GetObject<Drawable>(native_icon, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuItem.SetIcon(icon));
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

	public unsafe IMenuItem SetIcon(Drawable? icon)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(icon?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setIcon.(Landroid/graphics/drawable/Drawable;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(icon);
		}
	}

	private static Delegate GetSetIcon_IHandler()
	{
		return new _JniMarshal_PPI_L(n_SetIcon_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetIcon_I(nint jnienv, nint native__this, int iconRes)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetIcon(iconRes));
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

	public unsafe IMenuItem SetIcon(int iconRes)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(iconRes);
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setIcon.(I)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetIntent_Landroid_content_Intent_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetIntent_Landroid_content_Intent_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetIntent_Landroid_content_Intent_(nint jnienv, nint native__this, nint native_intent)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Intent intent = Java.Lang.Object.GetObject<Intent>(native_intent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuItem.SetIntent(intent));
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

	public unsafe IMenuItem SetIntent(Intent? intent)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intent?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setIntent.(Landroid/content/Intent;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(intent);
		}
	}

	private static Delegate GetSetNumericShortcut_CHandler()
	{
		return new _JniMarshal_PPs_L(n_SetNumericShortcut_C);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetNumericShortcut_C(nint jnienv, nint native__this, ushort native_numericChar)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char numericShortcut = (char)native_numericChar;
			return JNIEnv.ToLocalJniHandle(menuItem.SetNumericShortcut(numericShortcut));
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

	public unsafe IMenuItem SetNumericShortcut(char numericChar)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((ushort)numericChar);
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setNumericShortcut.(C)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetOnActionExpandListener_Landroid_view_MenuItem_OnActionExpandListener_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetOnActionExpandListener_Landroid_view_MenuItem_OnActionExpandListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetOnActionExpandListener_Landroid_view_MenuItem_OnActionExpandListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuItemOnActionExpandListener onActionExpandListener = Java.Lang.Object.GetObject<IMenuItemOnActionExpandListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuItem.SetOnActionExpandListener(onActionExpandListener));
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

	public unsafe IMenuItem SetOnActionExpandListener(IMenuItemOnActionExpandListener? listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setOnActionExpandListener.(Landroid/view/MenuItem$OnActionExpandListener;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	private static Delegate GetSetOnMenuItemClickListener_Landroid_view_MenuItem_OnMenuItemClickListener_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetOnMenuItemClickListener_Landroid_view_MenuItem_OnMenuItemClickListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetOnMenuItemClickListener_Landroid_view_MenuItem_OnMenuItemClickListener_(nint jnienv, nint native__this, nint native_menuItemClickListener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuItemOnMenuItemClickListener onMenuItemClickListener = Java.Lang.Object.GetObject<IMenuItemOnMenuItemClickListener>(native_menuItemClickListener, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuItem.SetOnMenuItemClickListener(onMenuItemClickListener));
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

	public unsafe IMenuItem SetOnMenuItemClickListener(IMenuItemOnMenuItemClickListener? menuItemClickListener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((menuItemClickListener == null) ? IntPtr.Zero : ((Java.Lang.Object)menuItemClickListener).Handle);
			return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setOnMenuItemClickListener.(Landroid/view/MenuItem$OnMenuItemClickListener;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(menuItemClickListener);
		}
	}

	private static Delegate GetSetShortcut_CCHandler()
	{
		return new _JniMarshal_PPss_L(n_SetShortcut_CC);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetShortcut_CC(nint jnienv, nint native__this, ushort native_numericChar, ushort native_alphaChar)
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
			return JNIEnv.ToLocalJniHandle(menuItem.SetShortcut(numericChar, alphaChar));
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

	public unsafe IMenuItem SetShortcut(char numericChar, char alphaChar)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue((ushort)numericChar);
		ptr[1] = new JniArgumentValue((ushort)alphaChar);
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setShortcut.(CC)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetShowAsAction_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetShowAsAction_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetShowAsAction_I(nint jnienv, nint native__this, int native_actionEnum)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetShowAsAction((ShowAsAction)native_actionEnum);
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

	public unsafe void SetShowAsAction(ShowAsAction actionEnum)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((int)actionEnum);
		_members_android_view_MenuItem.InstanceMethods.InvokeAbstractVoidMethod("setShowAsAction.(I)V", this, ptr);
	}

	private static Delegate GetSetShowAsActionFlags_IHandler()
	{
		return new _JniMarshal_PPI_L(n_SetShowAsActionFlags_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetShowAsActionFlags_I(nint jnienv, nint native__this, int native_actionEnum)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetShowAsActionFlags((ShowAsAction)native_actionEnum));
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

	public unsafe IMenuItem SetShowAsActionFlags(ShowAsAction actionEnum)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((int)actionEnum);
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setShowAsActionFlags.(I)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetTitle_IHandler()
	{
		return new _JniMarshal_PPI_L(n_SetTitle_I);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetTitle_I(nint jnienv, nint native__this, int title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetTitle(title));
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

	public unsafe IMenuItem SetTitle(int title)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(title);
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setTitle.(I)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetSetTitle_Ljava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetTitle_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetTitle_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence title = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuItem.SetTitle(title));
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

	public unsafe IMenuItem SetTitle(ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setTitle.(Ljava/lang/CharSequence;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	private static Delegate GetSetTitleCondensed_Ljava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPL_L(n_SetTitleCondensed_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetTitleCondensed_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_title)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence titleCondensed = Java.Lang.Object.GetObject<ICharSequence>(native_title, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuItem.SetTitleCondensed(titleCondensed));
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

	public unsafe IMenuItem SetTitleCondensed(ICharSequence? title)
	{
		nint num = CharSequence.ToLocalJniHandle(title);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setTitleCondensed.(Ljava/lang/CharSequence;)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(title);
		}
	}

	private static Delegate GetSetVisible_ZHandler()
	{
		return new _JniMarshal_PPB_L(n_SetVisible_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_SetVisible_Z(nint jnienv, nint native__this, sbyte native_visible)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuItem? menuItem = Java.Lang.Object.GetObject<IMenuItem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool visible = native_visible != 0;
			return JNIEnv.ToLocalJniHandle(menuItem.SetVisible(visible));
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

	public unsafe IMenuItem SetVisible(bool visible)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(visible ? ((sbyte)1) : ((sbyte)0));
		return Java.Lang.Object.GetObject<IMenuItem>(_members_android_view_MenuItem.InstanceMethods.InvokeAbstractObjectMethod("setVisible.(Z)Landroid/view/MenuItem;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
