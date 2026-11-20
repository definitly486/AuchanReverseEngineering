using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.AppCompat.View.Menu;

[Register("androidx/appcompat/view/menu/MenuView", DoNotGenerateAcw = true)]
internal class IMenuViewInvoker : Java.Lang.Object, IMenuView, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_appcompat_view_menu_MenuView = new XAPeerMembers("androidx/appcompat/view/menu/MenuView", typeof(IMenuViewInvoker));

	private static Delegate? cb_getWindowAnimations_GetWindowAnimations_I;

	private static Delegate? cb_initialize_Initialize_Landroidx_appcompat_view_menu_MenuBuilder__V;

	private static nint java_class_ref => _members_androidx_appcompat_view_menu_MenuView.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_appcompat_view_menu_MenuView;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_appcompat_view_menu_MenuView.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_appcompat_view_menu_MenuView.ManagedPeerType;

	public unsafe int WindowAnimations => _members_androidx_appcompat_view_menu_MenuView.InstanceMethods.InvokeAbstractInt32Method("getWindowAnimations.()I", this, null);

	public IMenuViewInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetWindowAnimationsHandler()
	{
		return new global::_JniMarshal_PP_I(n_GetWindowAnimations);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetWindowAnimations(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WindowAnimations;
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

	private static Delegate GetInitialize_Landroidx_appcompat_view_menu_MenuBuilder_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_Initialize_Landroidx_appcompat_view_menu_MenuBuilder_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Initialize_Landroidx_appcompat_view_menu_MenuBuilder_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IMenuView? menuView = Java.Lang.Object.GetObject<IMenuView>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			MenuBuilder p = Java.Lang.Object.GetObject<MenuBuilder>(native_p0, JniHandleOwnership.DoNotTransfer);
			menuView.Initialize(p);
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

	public unsafe void Initialize(MenuBuilder? p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members_androidx_appcompat_view_menu_MenuView.InstanceMethods.InvokeAbstractVoidMethod("initialize.(Landroidx/appcompat/view/menu/MenuBuilder;)V", this, ptr);
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
