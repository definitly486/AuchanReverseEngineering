using System;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/MenuProvider", "", "AndroidX.Core.View.IMenuProviderInvoker")]
public interface IMenuProvider : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/core/view/MenuProvider", typeof(IMenuProvider), isInterface: true);

	private static Delegate? cb_onMenuClosed_OnMenuClosed_Landroid_view_Menu__V;

	private static Delegate? cb_onPrepareMenu_OnPrepareMenu_Landroid_view_Menu__V;

	[Register("onCreateMenu", "(Landroid/view/Menu;Landroid/view/MenuInflater;)V", "GetOnCreateMenu_Landroid_view_Menu_Landroid_view_MenuInflater_Handler:AndroidX.Core.View.IMenuProviderInvoker, Xamarin.AndroidX.Core")]
	void OnCreateMenu(IMenu? p0, MenuInflater? p1);

	[Register("onMenuItemSelected", "(Landroid/view/MenuItem;)Z", "GetOnMenuItemSelected_Landroid_view_MenuItem_Handler:AndroidX.Core.View.IMenuProviderInvoker, Xamarin.AndroidX.Core")]
	bool OnMenuItemSelected(IMenuItem? p0);

	private static Delegate GetOnMenuClosed_Landroid_view_Menu_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnMenuClosed_Landroid_view_Menu_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnMenuClosed_Landroid_view_Menu_(nint jnienv, nint native__this, nint native_menu)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMenuProvider? menuProvider = Java.Lang.Object.GetObject<IMenuProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
			menuProvider.OnMenuClosed(menu);
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

	[Register("onMenuClosed", "(Landroid/view/Menu;)V", "GetOnMenuClosed_Landroid_view_Menu_Handler:AndroidX.Core.View.IMenuProvider, Xamarin.AndroidX.Core")]
	unsafe void OnMenuClosed(IMenu? menu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onMenuClosed.(Landroid/view/Menu;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
		}
	}

	private static Delegate GetOnPrepareMenu_Landroid_view_Menu_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_OnPrepareMenu_Landroid_view_Menu_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnPrepareMenu_Landroid_view_Menu_(nint jnienv, nint native__this, nint native_menu)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMenuProvider? menuProvider = Java.Lang.Object.GetObject<IMenuProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenu menu = Java.Lang.Object.GetObject<IMenu>(native_menu, JniHandleOwnership.DoNotTransfer);
			menuProvider.OnPrepareMenu(menu);
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

	[Register("onPrepareMenu", "(Landroid/view/Menu;)V", "GetOnPrepareMenu_Landroid_view_Menu_Handler:AndroidX.Core.View.IMenuProvider, Xamarin.AndroidX.Core")]
	unsafe void OnPrepareMenu(IMenu? menu)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((menu == null) ? IntPtr.Zero : ((Java.Lang.Object)menu).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("onPrepareMenu.(Landroid/view/Menu;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(menu);
		}
	}
}
