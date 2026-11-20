using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/WindowInsetsAnimationController", DoNotGenerateAcw = true, ApiSince = 30)]
internal class IWindowInsetsAnimationControllerInvoker : Java.Lang.Object, IWindowInsetsAnimationController, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_view_WindowInsetsAnimationController = new XAPeerMembers("android/view/WindowInsetsAnimationController", typeof(IWindowInsetsAnimationControllerInvoker));

	private static Delegate? cb_getCurrentAlpha_GetCurrentAlpha_F;

	private static Delegate? cb_getCurrentFraction_GetCurrentFraction_F;

	private static Delegate? cb_getCurrentInsets_GetCurrentInsets_Landroid_graphics_Insets_;

	private static Delegate? cb_getHiddenStateInsets_GetHiddenStateInsets_Landroid_graphics_Insets_;

	private static Delegate? cb_isCancelled_IsCancelled_Z;

	private static Delegate? cb_isFinished_IsFinished_Z;

	private static Delegate? cb_getShownStateInsets_GetShownStateInsets_Landroid_graphics_Insets_;

	private static Delegate? cb_getTypes_GetTypes_I;

	private static Delegate? cb_finish_Finish_Z_V;

	private static Delegate? cb_setInsetsAndAlpha_SetInsetsAndAlpha_Landroid_graphics_Insets_FF_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_view_WindowInsetsAnimationController;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_view_WindowInsetsAnimationController.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_view_WindowInsetsAnimationController.ManagedPeerType;

	[SupportedOSPlatform("android30.0")]
	public unsafe float CurrentAlpha => _members_android_view_WindowInsetsAnimationController.InstanceMethods.InvokeAbstractSingleMethod("getCurrentAlpha.()F", this, null);

	[SupportedOSPlatform("android30.0")]
	public unsafe float CurrentFraction => _members_android_view_WindowInsetsAnimationController.InstanceMethods.InvokeAbstractSingleMethod("getCurrentFraction.()F", this, null);

	[SupportedOSPlatform("android30.0")]
	public unsafe Insets CurrentInsets => Java.Lang.Object.GetObject<Insets>(_members_android_view_WindowInsetsAnimationController.InstanceMethods.InvokeAbstractObjectMethod("getCurrentInsets.()Landroid/graphics/Insets;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	[SupportedOSPlatform("android30.0")]
	public unsafe Insets HiddenStateInsets => Java.Lang.Object.GetObject<Insets>(_members_android_view_WindowInsetsAnimationController.InstanceMethods.InvokeAbstractObjectMethod("getHiddenStateInsets.()Landroid/graphics/Insets;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	[SupportedOSPlatform("android30.0")]
	public unsafe bool IsCancelled => _members_android_view_WindowInsetsAnimationController.InstanceMethods.InvokeAbstractBooleanMethod("isCancelled.()Z", this, null);

	[SupportedOSPlatform("android30.0")]
	public unsafe bool IsFinished => _members_android_view_WindowInsetsAnimationController.InstanceMethods.InvokeAbstractBooleanMethod("isFinished.()Z", this, null);

	[SupportedOSPlatform("android30.0")]
	public unsafe Insets ShownStateInsets => Java.Lang.Object.GetObject<Insets>(_members_android_view_WindowInsetsAnimationController.InstanceMethods.InvokeAbstractObjectMethod("getShownStateInsets.()Landroid/graphics/Insets;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	[SupportedOSPlatform("android30.0")]
	public unsafe int Types => _members_android_view_WindowInsetsAnimationController.InstanceMethods.InvokeAbstractInt32Method("getTypes.()I", this, null);

	public IWindowInsetsAnimationControllerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetGetCurrentAlphaHandler()
	{
		return new _JniMarshal_PP_F(n_GetCurrentAlpha);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetCurrentAlpha(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<IWindowInsetsAnimationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentAlpha;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetGetCurrentFractionHandler()
	{
		return new _JniMarshal_PP_F(n_GetCurrentFraction);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static float n_GetCurrentFraction(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0f;
		}
		try
		{
			return Java.Lang.Object.GetObject<IWindowInsetsAnimationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentFraction;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0f;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetGetCurrentInsetsHandler()
	{
		return new _JniMarshal_PP_L(n_GetCurrentInsets);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCurrentInsets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IWindowInsetsAnimationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentInsets);
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
	private static Delegate GetGetHiddenStateInsetsHandler()
	{
		return new _JniMarshal_PP_L(n_GetHiddenStateInsets);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetHiddenStateInsets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IWindowInsetsAnimationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HiddenStateInsets);
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
	private static Delegate GetIsCancelledHandler()
	{
		return new _JniMarshal_PP_B(n_IsCancelled);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsCancelled(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IWindowInsetsAnimationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCancelled ? ((sbyte)1) : ((sbyte)0);
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
	private static Delegate GetIsFinishedHandler()
	{
		return new _JniMarshal_PP_B(n_IsFinished);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsFinished(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IWindowInsetsAnimationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsFinished ? ((sbyte)1) : ((sbyte)0);
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
	private static Delegate GetGetShownStateInsetsHandler()
	{
		return new _JniMarshal_PP_L(n_GetShownStateInsets);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetShownStateInsets(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IWindowInsetsAnimationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ShownStateInsets);
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
	private static Delegate GetGetTypesHandler()
	{
		return new _JniMarshal_PP_I(n_GetTypes);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetTypes(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IWindowInsetsAnimationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Types;
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
	private static Delegate GetFinish_ZHandler()
	{
		return new _JniMarshal_PPB_V(n_Finish_Z);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Finish_Z(nint jnienv, nint native__this, sbyte native_shown)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowInsetsAnimationController? windowInsetsAnimationController = Java.Lang.Object.GetObject<IWindowInsetsAnimationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			bool shown = native_shown != 0;
			windowInsetsAnimationController.Finish(shown);
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
	public unsafe void Finish(bool shown)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(shown ? ((sbyte)1) : ((sbyte)0));
		_members_android_view_WindowInsetsAnimationController.InstanceMethods.InvokeAbstractVoidMethod("finish.(Z)V", this, ptr);
	}

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetSetInsetsAndAlpha_Landroid_graphics_Insets_FFHandler()
	{
		return new _JniMarshal_PPLFF_V(n_SetInsetsAndAlpha_Landroid_graphics_Insets_FF);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetInsetsAndAlpha_Landroid_graphics_Insets_FF(nint jnienv, nint native__this, nint native_insets, float alpha, float fraction)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IWindowInsetsAnimationController? windowInsetsAnimationController = Java.Lang.Object.GetObject<IWindowInsetsAnimationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Insets insets = Java.Lang.Object.GetObject<Insets>(native_insets, JniHandleOwnership.DoNotTransfer);
			windowInsetsAnimationController.SetInsetsAndAlpha(insets, alpha, fraction);
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
	public unsafe void SetInsetsAndAlpha(Insets? insets, float alpha, float fraction)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(insets?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(alpha);
			ptr[2] = new JniArgumentValue(fraction);
			_members_android_view_WindowInsetsAnimationController.InstanceMethods.InvokeAbstractVoidMethod("setInsetsAndAlpha.(Landroid/graphics/Insets;FF)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(insets);
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
