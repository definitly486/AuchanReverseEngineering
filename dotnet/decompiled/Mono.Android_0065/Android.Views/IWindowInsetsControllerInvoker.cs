using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.OS;
using Android.Runtime;
using Android.Views.Animations;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/WindowInsetsController", DoNotGenerateAcw = true, ApiSince = 30)]
internal class IWindowInsetsControllerInvoker : Java.Lang.Object, IWindowInsetsController, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_view_WindowInsetsController = new XAPeerMembers("android/view/WindowInsetsController", typeof(IWindowInsetsControllerInvoker));

	private static Delegate? cb_getSystemBarsAppearance_GetSystemBarsAppearance_I;

	private static Delegate? cb_getSystemBarsBehavior_GetSystemBarsBehavior_I;

	private static Delegate? cb_setSystemBarsBehavior_SetSystemBarsBehavior_I_V;

	private static Delegate? cb_addOnControllableInsetsChangedListener_AddOnControllableInsetsChangedListener_Landroid_view_WindowInsetsController_OnControllableInsetsChangedListener__V;

	private static Delegate? cb_controlWindowInsetsAnimation_ControlWindowInsetsAnimation_IJLandroid_view_animation_Interpolator_Landroid_os_CancellationSignal_Landroid_view_WindowInsetsAnimationControlListener__V;

	private static Delegate? cb_hide_Hide_I_V;

	private static Delegate? cb_removeOnControllableInsetsChangedListener_RemoveOnControllableInsetsChangedListener_Landroid_view_WindowInsetsController_OnControllableInsetsChangedListener__V;

	private static Delegate? cb_setSystemBarsAppearance_SetSystemBarsAppearance_II_V;

	private static Delegate? cb_show_Show_I_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_view_WindowInsetsController;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_view_WindowInsetsController.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_view_WindowInsetsController.ManagedPeerType;

	[SupportedOSPlatform("android30.0")]
	public unsafe int SystemBarsAppearance => _members_android_view_WindowInsetsController.InstanceMethods.InvokeAbstractInt32Method("getSystemBarsAppearance.()I", this, null);

	[SupportedOSPlatform("android30.0")]
	public unsafe int SystemBarsBehavior
	{
		get
		{
			return _members_android_view_WindowInsetsController.InstanceMethods.InvokeAbstractInt32Method("getSystemBarsBehavior.()I", this, null);
		}
		set
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members_android_view_WindowInsetsController.InstanceMethods.InvokeAbstractVoidMethod("setSystemBarsBehavior.(I)V", this, ptr);
		}
	}

	public IWindowInsetsControllerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetGetSystemBarsAppearanceHandler()
	{
		return new _JniMarshal_PP_I(n_GetSystemBarsAppearance);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSystemBarsAppearance(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IWindowInsetsController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SystemBarsAppearance;
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

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetGetSystemBarsBehaviorHandler()
	{
		return new _JniMarshal_PP_I(n_GetSystemBarsBehavior);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetSystemBarsBehavior(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IWindowInsetsController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SystemBarsBehavior;
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

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetSetSystemBarsBehavior_IHandler()
	{
		return new _JniMarshal_PPI_V(n_SetSystemBarsBehavior_I);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSystemBarsBehavior_I(nint jnienv, nint native__this, int behavior)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IWindowInsetsController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SystemBarsBehavior = behavior;
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

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetAddOnControllableInsetsChangedListener_Landroid_view_WindowInsetsController_OnControllableInsetsChangedListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_AddOnControllableInsetsChangedListener_Landroid_view_WindowInsetsController_OnControllableInsetsChangedListener_);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddOnControllableInsetsChangedListener_Landroid_view_WindowInsetsController_OnControllableInsetsChangedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowInsetsController? windowInsetsController = Java.Lang.Object.GetObject<IWindowInsetsController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IWindowInsetsController.IOnControllableInsetsChangedListener listener = Java.Lang.Object.GetObject<IWindowInsetsController.IOnControllableInsetsChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			windowInsetsController.AddOnControllableInsetsChangedListener(listener);
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

	[SupportedOSPlatform("android30.0")]
	public unsafe void AddOnControllableInsetsChangedListener(IWindowInsetsController.IOnControllableInsetsChangedListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members_android_view_WindowInsetsController.InstanceMethods.InvokeAbstractVoidMethod("addOnControllableInsetsChangedListener.(Landroid/view/WindowInsetsController$OnControllableInsetsChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetControlWindowInsetsAnimation_IJLandroid_view_animation_Interpolator_Landroid_os_CancellationSignal_Landroid_view_WindowInsetsAnimationControlListener_Handler()
	{
		return new _JniMarshal_PPIJLLL_V(n_ControlWindowInsetsAnimation_IJLandroid_view_animation_Interpolator_Landroid_os_CancellationSignal_Landroid_view_WindowInsetsAnimationControlListener_);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_ControlWindowInsetsAnimation_IJLandroid_view_animation_Interpolator_Landroid_os_CancellationSignal_Landroid_view_WindowInsetsAnimationControlListener_(nint jnienv, nint native__this, int types, long durationMillis, nint native_interpolator, nint native_cancellationSignal, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowInsetsController? windowInsetsController = Java.Lang.Object.GetObject<IWindowInsetsController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IInterpolator interpolator = Java.Lang.Object.GetObject<IInterpolator>(native_interpolator, JniHandleOwnership.DoNotTransfer);
			CancellationSignal cancellationSignal = Java.Lang.Object.GetObject<CancellationSignal>(native_cancellationSignal, JniHandleOwnership.DoNotTransfer);
			IWindowInsetsAnimationControlListener listener = Java.Lang.Object.GetObject<IWindowInsetsAnimationControlListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			windowInsetsController.ControlWindowInsetsAnimation(types, durationMillis, interpolator, cancellationSignal, listener);
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

	[SupportedOSPlatform("android30.0")]
	public unsafe void ControlWindowInsetsAnimation(int types, long durationMillis, IInterpolator? interpolator, CancellationSignal? cancellationSignal, IWindowInsetsAnimationControlListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(types);
			ptr[1] = new JniArgumentValue(durationMillis);
			ptr[2] = new JniArgumentValue((interpolator == null) ? IntPtr.Zero : ((Java.Lang.Object)interpolator).Handle);
			ptr[3] = new JniArgumentValue(cancellationSignal?.Handle ?? IntPtr.Zero);
			ptr[4] = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members_android_view_WindowInsetsController.InstanceMethods.InvokeAbstractVoidMethod("controlWindowInsetsAnimation.(IJLandroid/view/animation/Interpolator;Landroid/os/CancellationSignal;Landroid/view/WindowInsetsAnimationControlListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(interpolator);
			GC.KeepAlive(cancellationSignal);
			GC.KeepAlive(listener);
		}
	}

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetHide_IHandler()
	{
		return new _JniMarshal_PPI_V(n_Hide_I);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Hide_I(nint jnienv, nint native__this, int types)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IWindowInsetsController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Hide(types);
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

	[SupportedOSPlatform("android30.0")]
	public unsafe void Hide(int types)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(types);
		_members_android_view_WindowInsetsController.InstanceMethods.InvokeAbstractVoidMethod("hide.(I)V", this, ptr);
	}

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetRemoveOnControllableInsetsChangedListener_Landroid_view_WindowInsetsController_OnControllableInsetsChangedListener_Handler()
	{
		return new _JniMarshal_PPL_V(n_RemoveOnControllableInsetsChangedListener_Landroid_view_WindowInsetsController_OnControllableInsetsChangedListener_);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveOnControllableInsetsChangedListener_Landroid_view_WindowInsetsController_OnControllableInsetsChangedListener_(nint jnienv, nint native__this, nint native_listener)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowInsetsController? windowInsetsController = Java.Lang.Object.GetObject<IWindowInsetsController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IWindowInsetsController.IOnControllableInsetsChangedListener listener = Java.Lang.Object.GetObject<IWindowInsetsController.IOnControllableInsetsChangedListener>(native_listener, JniHandleOwnership.DoNotTransfer);
			windowInsetsController.RemoveOnControllableInsetsChangedListener(listener);
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

	[SupportedOSPlatform("android30.0")]
	public unsafe void RemoveOnControllableInsetsChangedListener(IWindowInsetsController.IOnControllableInsetsChangedListener listener)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((listener == null) ? IntPtr.Zero : ((Java.Lang.Object)listener).Handle);
			_members_android_view_WindowInsetsController.InstanceMethods.InvokeAbstractVoidMethod("removeOnControllableInsetsChangedListener.(Landroid/view/WindowInsetsController$OnControllableInsetsChangedListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(listener);
		}
	}

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetSetSystemBarsAppearance_IIHandler()
	{
		return new _JniMarshal_PPII_V(n_SetSystemBarsAppearance_II);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetSystemBarsAppearance_II(nint jnienv, nint native__this, int appearance, int mask)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IWindowInsetsController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetSystemBarsAppearance(appearance, mask);
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

	[SupportedOSPlatform("android30.0")]
	public unsafe void SetSystemBarsAppearance([IntDef(Flag = true, Type = "Android.Views.IWindowInsetsController", Fields = new string[] { "AppearanceLightStatusBars", "AppearanceLightNavigationBars", "AppearanceTransparentCaptionBarBackground", "AppearanceLightCaptionBars" })] int appearance, [IntDef(Flag = true, Type = "Android.Views.IWindowInsetsController", Fields = new string[] { "AppearanceLightStatusBars", "AppearanceLightNavigationBars", "AppearanceTransparentCaptionBarBackground", "AppearanceLightCaptionBars" })] int mask)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(appearance);
		ptr[1] = new JniArgumentValue(mask);
		_members_android_view_WindowInsetsController.InstanceMethods.InvokeAbstractVoidMethod("setSystemBarsAppearance.(II)V", this, ptr);
	}

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetShow_IHandler()
	{
		return new _JniMarshal_PPI_V(n_Show_I);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Show_I(nint jnienv, nint native__this, int types)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IWindowInsetsController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Show(types);
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

	[SupportedOSPlatform("android30.0")]
	public unsafe void Show(int types)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(types);
		_members_android_view_WindowInsetsController.InstanceMethods.InvokeAbstractVoidMethod("show.(I)V", this, ptr);
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
