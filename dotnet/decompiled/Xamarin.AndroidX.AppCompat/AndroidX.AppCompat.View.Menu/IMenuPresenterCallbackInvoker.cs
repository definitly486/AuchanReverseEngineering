using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.View.Menu;

[Register("androidx/appcompat/view/menu/MenuPresenter$Callback", DoNotGenerateAcw = true)]
internal class IMenuPresenterCallbackInvoker : Java.Lang.Object, IMenuPresenterCallback, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_appcompat_view_menu_MenuPresenter_Callback = new XAPeerMembers("androidx/appcompat/view/menu/MenuPresenter$Callback", typeof(IMenuPresenterCallbackInvoker));

	private static Delegate? cb_onCloseMenu_OnCloseMenu_Landroidx_appcompat_view_menu_MenuBuilder_Z_V;

	private static Delegate? cb_onOpenSubMenu_OnOpenSubMenu_Landroidx_appcompat_view_menu_MenuBuilder__Z;

	private static nint java_class_ref => _members_androidx_appcompat_view_menu_MenuPresenter_Callback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_appcompat_view_menu_MenuPresenter_Callback;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_appcompat_view_menu_MenuPresenter_Callback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_appcompat_view_menu_MenuPresenter_Callback.ManagedPeerType;

	public IMenuPresenterCallbackInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
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
			IMenuPresenterCallback? menuPresenterCallback = Java.Lang.Object.GetObject<IMenuPresenterCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MenuBuilder p = Java.Lang.Object.GetObject<MenuBuilder>(native_p0, JniHandleOwnership.DoNotTransfer);
			bool p2 = native_p1 != 0;
			menuPresenterCallback.OnCloseMenu(p, p2);
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

	public unsafe void OnCloseMenu(MenuBuilder p0, bool p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1 ? ((sbyte)1) : ((sbyte)0));
			_members_androidx_appcompat_view_menu_MenuPresenter_Callback.InstanceMethods.InvokeAbstractVoidMethod("onCloseMenu.(Landroidx/appcompat/view/menu/MenuBuilder;Z)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetOnOpenSubMenu_Landroidx_appcompat_view_menu_MenuBuilder_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_OnOpenSubMenu_Landroidx_appcompat_view_menu_MenuBuilder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnOpenSubMenu_Landroidx_appcompat_view_menu_MenuBuilder_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuPresenterCallback? menuPresenterCallback = Java.Lang.Object.GetObject<IMenuPresenterCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MenuBuilder p = Java.Lang.Object.GetObject<MenuBuilder>(native_p0, JniHandleOwnership.DoNotTransfer);
			return menuPresenterCallback.OnOpenSubMenu(p) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool OnOpenSubMenu(MenuBuilder p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return _members_androidx_appcompat_view_menu_MenuPresenter_Callback.InstanceMethods.InvokeAbstractBooleanMethod("onOpenSubMenu.(Landroidx/appcompat/view/menu/MenuBuilder;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
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
