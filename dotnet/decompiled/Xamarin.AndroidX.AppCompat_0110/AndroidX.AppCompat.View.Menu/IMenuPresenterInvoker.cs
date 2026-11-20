using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.View.Menu;

[Register("androidx/appcompat/view/menu/MenuPresenter", DoNotGenerateAcw = true)]
internal class IMenuPresenterInvoker : Java.Lang.Object, IMenuPresenter, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_appcompat_view_menu_MenuPresenter = new XAPeerMembers("androidx/appcompat/view/menu/MenuPresenter", typeof(IMenuPresenterInvoker));

	private static Delegate? cb_getId_GetId_I;

	private static Delegate? cb_collapseItemActionView_CollapseItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl__Z;

	private static Delegate? cb_expandItemActionView_ExpandItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl__Z;

	private static Delegate? cb_flagActionItems_FlagActionItems_Z;

	private static Delegate? cb_getMenuView_GetMenuView_Landroid_view_ViewGroup__Landroidx_appcompat_view_menu_MenuView_;

	private static Delegate? cb_initForMenu_InitForMenu_Landroid_content_Context_Landroidx_appcompat_view_menu_MenuBuilder__V;

	private static Delegate? cb_onCloseMenu_OnCloseMenu_Landroidx_appcompat_view_menu_MenuBuilder_Z_V;

	private static Delegate? cb_onRestoreInstanceState_OnRestoreInstanceState_Landroid_os_Parcelable__V;

	private static Delegate? cb_onSaveInstanceState_OnSaveInstanceState_Landroid_os_Parcelable_;

	private static Delegate? cb_onSubMenuSelected_OnSubMenuSelected_Landroidx_appcompat_view_menu_SubMenuBuilder__Z;

	private static Delegate? cb_setCallback_SetCallback_Landroidx_appcompat_view_menu_MenuPresenter_Callback__V;

	private static Delegate? cb_updateMenuView_UpdateMenuView_Z_V;

	private static nint java_class_ref => _members_androidx_appcompat_view_menu_MenuPresenter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_appcompat_view_menu_MenuPresenter;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_appcompat_view_menu_MenuPresenter.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_appcompat_view_menu_MenuPresenter.ManagedPeerType;

	public unsafe int Id => _members_androidx_appcompat_view_menu_MenuPresenter.InstanceMethods.InvokeAbstractInt32Method("getId.()I", this, null);

	public IMenuPresenterInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetIdHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetId);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id;
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

	private static Delegate GetCollapseItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl_Handler()
	{
		return new global::_JniMarshal_PPLL_B(n_CollapseItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_CollapseItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuPresenter? menuPresenter = Java.Lang.Object.GetObject<IMenuPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MenuBuilder p = Java.Lang.Object.GetObject<MenuBuilder>(native_p0, JniHandleOwnership.DoNotTransfer);
			MenuItemImpl p2 = Java.Lang.Object.GetObject<MenuItemImpl>(native_p1, JniHandleOwnership.DoNotTransfer);
			return menuPresenter.CollapseItemActionView(p, p2) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool CollapseItemActionView(MenuBuilder? p0, MenuItemImpl? p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			return _members_androidx_appcompat_view_menu_MenuPresenter.InstanceMethods.InvokeAbstractBooleanMethod("collapseItemActionView.(Landroidx/appcompat/view/menu/MenuBuilder;Landroidx/appcompat/view/menu/MenuItemImpl;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetExpandItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl_Handler()
	{
		return new global::_JniMarshal_PPLL_B(n_ExpandItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_ExpandItemActionView_Landroidx_appcompat_view_menu_MenuBuilder_Landroidx_appcompat_view_menu_MenuItemImpl_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuPresenter? menuPresenter = Java.Lang.Object.GetObject<IMenuPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MenuBuilder p = Java.Lang.Object.GetObject<MenuBuilder>(native_p0, JniHandleOwnership.DoNotTransfer);
			MenuItemImpl p2 = Java.Lang.Object.GetObject<MenuItemImpl>(native_p1, JniHandleOwnership.DoNotTransfer);
			return menuPresenter.ExpandItemActionView(p, p2) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool ExpandItemActionView(MenuBuilder? p0, MenuItemImpl? p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			return _members_androidx_appcompat_view_menu_MenuPresenter.InstanceMethods.InvokeAbstractBooleanMethod("expandItemActionView.(Landroidx/appcompat/view/menu/MenuBuilder;Landroidx/appcompat/view/menu/MenuItemImpl;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetFlagActionItemsHandler()
	{
		return new global::_JniMarshal_PP_B(n_FlagActionItems);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_FlagActionItems(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FlagActionItems() ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool FlagActionItems()
	{
		return _members_androidx_appcompat_view_menu_MenuPresenter.InstanceMethods.InvokeAbstractBooleanMethod("flagActionItems.()Z", this, null);
	}

	private static Delegate GetGetMenuView_Landroid_view_ViewGroup_Handler()
	{
		return new global::_JniMarshal_PPL_L(n_GetMenuView_Landroid_view_ViewGroup_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMenuView_Landroid_view_ViewGroup_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuPresenter? menuPresenter = Java.Lang.Object.GetObject<IMenuPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ViewGroup p = Java.Lang.Object.GetObject<ViewGroup>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(menuPresenter.GetMenuView(p));
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

	public unsafe IMenuView? GetMenuView(ViewGroup? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IMenuView>(_members_androidx_appcompat_view_menu_MenuPresenter.InstanceMethods.InvokeAbstractObjectMethod("getMenuView.(Landroid/view/ViewGroup;)Landroidx/appcompat/view/menu/MenuView;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetInitForMenu_Landroid_content_Context_Landroidx_appcompat_view_menu_MenuBuilder_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_InitForMenu_Landroid_content_Context_Landroidx_appcompat_view_menu_MenuBuilder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_InitForMenu_Landroid_content_Context_Landroidx_appcompat_view_menu_MenuBuilder_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMenuPresenter? menuPresenter = Java.Lang.Object.GetObject<IMenuPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context p = Java.Lang.Object.GetObject<Context>(native_p0, JniHandleOwnership.DoNotTransfer);
			MenuBuilder p2 = Java.Lang.Object.GetObject<MenuBuilder>(native_p1, JniHandleOwnership.DoNotTransfer);
			menuPresenter.InitForMenu(p, p2);
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

	public unsafe void InitForMenu(Context? p0, MenuBuilder? p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_androidx_appcompat_view_menu_MenuPresenter.InstanceMethods.InvokeAbstractVoidMethod("initForMenu.(Landroid/content/Context;Landroidx/appcompat/view/menu/MenuBuilder;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetOnCloseMenu_Landroidx_appcompat_view_menu_MenuBuilder_ZHandler()
	{
		return new global::_JniMarshal_PPLB_V(n_OnCloseMenu_Landroidx_appcompat_view_menu_MenuBuilder_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnCloseMenu_Landroidx_appcompat_view_menu_MenuBuilder_Z(nint jnienv, nint native__this, nint native_p0, sbyte native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMenuPresenter? menuPresenter = Java.Lang.Object.GetObject<IMenuPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MenuBuilder p = Java.Lang.Object.GetObject<MenuBuilder>(native_p0, JniHandleOwnership.DoNotTransfer);
			bool p2 = native_p1 != 0;
			menuPresenter.OnCloseMenu(p, p2);
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

	public unsafe void OnCloseMenu(MenuBuilder? p0, bool p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1 ? ((sbyte)1) : ((sbyte)0));
			_members_androidx_appcompat_view_menu_MenuPresenter.InstanceMethods.InvokeAbstractVoidMethod("onCloseMenu.(Landroidx/appcompat/view/menu/MenuBuilder;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnRestoreInstanceState_Landroid_os_Parcelable_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnRestoreInstanceState_Landroid_os_Parcelable_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnRestoreInstanceState_Landroid_os_Parcelable_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMenuPresenter? menuPresenter = Java.Lang.Object.GetObject<IMenuPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IParcelable p = Java.Lang.Object.GetObject<IParcelable>(native_p0, JniHandleOwnership.DoNotTransfer);
			menuPresenter.OnRestoreInstanceState(p);
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

	public unsafe void OnRestoreInstanceState(IParcelable? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_androidx_appcompat_view_menu_MenuPresenter.InstanceMethods.InvokeAbstractVoidMethod("onRestoreInstanceState.(Landroid/os/Parcelable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnSaveInstanceStateHandler()
	{
		return new global::_JniMarshal_PP_L(n_OnSaveInstanceState);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_OnSaveInstanceState(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMenuPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSaveInstanceState());
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

	public unsafe IParcelable? OnSaveInstanceState()
	{
		return Java.Lang.Object.GetObject<IParcelable>(_members_androidx_appcompat_view_menu_MenuPresenter.InstanceMethods.InvokeAbstractObjectMethod("onSaveInstanceState.()Landroid/os/Parcelable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetOnSubMenuSelected_Landroidx_appcompat_view_menu_SubMenuBuilder_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_OnSubMenuSelected_Landroidx_appcompat_view_menu_SubMenuBuilder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnSubMenuSelected_Landroidx_appcompat_view_menu_SubMenuBuilder_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuPresenter? menuPresenter = Java.Lang.Object.GetObject<IMenuPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SubMenuBuilder p = Java.Lang.Object.GetObject<SubMenuBuilder>(native_p0, JniHandleOwnership.DoNotTransfer);
			return menuPresenter.OnSubMenuSelected(p) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool OnSubMenuSelected(SubMenuBuilder? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return _members_androidx_appcompat_view_menu_MenuPresenter.InstanceMethods.InvokeAbstractBooleanMethod("onSubMenuSelected.(Landroidx/appcompat/view/menu/SubMenuBuilder;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetSetCallback_Landroidx_appcompat_view_menu_MenuPresenter_Callback_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_SetCallback_Landroidx_appcompat_view_menu_MenuPresenter_Callback_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetCallback_Landroidx_appcompat_view_menu_MenuPresenter_Callback_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMenuPresenter? menuPresenter = Java.Lang.Object.GetObject<IMenuPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuPresenterCallback callback = Java.Lang.Object.GetObject<IMenuPresenterCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			menuPresenter.SetCallback(callback);
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

	public unsafe void SetCallback(IMenuPresenterCallback? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_androidx_appcompat_view_menu_MenuPresenter.InstanceMethods.InvokeAbstractVoidMethod("setCallback.(Landroidx/appcompat/view/menu/MenuPresenter$Callback;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetUpdateMenuView_ZHandler()
	{
		return new global::_JniMarshal_PPB_V(n_UpdateMenuView_Z);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_UpdateMenuView_Z(nint jnienv, nint native__this, sbyte native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMenuPresenter? menuPresenter = Java.Lang.Object.GetObject<IMenuPresenter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool p = native_p0 != 0;
			menuPresenter.UpdateMenuView(p);
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

	public unsafe void UpdateMenuView(bool p0)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(p0 ? ((sbyte)1) : ((sbyte)0));
		_members_androidx_appcompat_view_menu_MenuPresenter.InstanceMethods.InvokeAbstractVoidMethod("updateMenuView.(Z)V", this, ptr);
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
