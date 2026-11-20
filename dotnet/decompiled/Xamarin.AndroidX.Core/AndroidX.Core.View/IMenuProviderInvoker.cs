using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Android.Views;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Core.View;

[Register("androidx/core/view/MenuProvider", DoNotGenerateAcw = true)]
internal class IMenuProviderInvoker : Java.Lang.Object, IMenuProvider, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_core_view_MenuProvider = new XAPeerMembers("androidx/core/view/MenuProvider", typeof(IMenuProviderInvoker));

	private static Delegate? cb_onCreateMenu_OnCreateMenu_Landroid_view_Menu_Landroid_view_MenuInflater__V;

	private static Delegate? cb_onMenuItemSelected_OnMenuItemSelected_Landroid_view_MenuItem__Z;

	private static nint java_class_ref => _members_androidx_core_view_MenuProvider.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_core_view_MenuProvider;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_core_view_MenuProvider.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_core_view_MenuProvider.ManagedPeerType;

	public IMenuProviderInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnCreateMenu_Landroid_view_Menu_Landroid_view_MenuInflater_Handler()
	{
		return new global::_JniMarshal_PPLL_V(n_OnCreateMenu_Landroid_view_Menu_Landroid_view_MenuInflater_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnCreateMenu_Landroid_view_Menu_Landroid_view_MenuInflater_(nint jnienv, nint native__this, nint native_p0, nint native_p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMenuProvider? menuProvider = Java.Lang.Object.GetObject<IMenuProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenu p = Java.Lang.Object.GetObject<IMenu>(native_p0, JniHandleOwnership.DoNotTransfer);
			MenuInflater p2 = Java.Lang.Object.GetObject<MenuInflater>(native_p1, JniHandleOwnership.DoNotTransfer);
			menuProvider.OnCreateMenu(p, p2);
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

	public unsafe void OnCreateMenu(IMenu? p0, MenuInflater? p1)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members_androidx_core_view_MenuProvider.InstanceMethods.InvokeAbstractVoidMethod("onCreateMenu.(Landroid/view/Menu;Landroid/view/MenuInflater;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}

	private static Delegate GetOnMenuItemSelected_Landroid_view_MenuItem_Handler()
	{
		return new global::_JniMarshal_PPL_B(n_OnMenuItemSelected_Landroid_view_MenuItem_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnMenuItemSelected_Landroid_view_MenuItem_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			IMenuProvider? menuProvider = Java.Lang.Object.GetObject<IMenuProvider>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IMenuItem p = Java.Lang.Object.GetObject<IMenuItem>(native_p0, JniHandleOwnership.DoNotTransfer);
			return menuProvider.OnMenuItemSelected(p) ? ((sbyte)1) : ((sbyte)0);
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

	public unsafe bool OnMenuItemSelected(IMenuItem? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return _members_androidx_core_view_MenuProvider.InstanceMethods.InvokeAbstractBooleanMethod("onMenuItemSelected.(Landroid/view/MenuItem;)Z", this, ptr);
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
