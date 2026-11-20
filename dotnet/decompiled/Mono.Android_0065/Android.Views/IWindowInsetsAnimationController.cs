using System;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/WindowInsetsAnimationController", "", "Android.Views.IWindowInsetsAnimationControllerInvoker", ApiSince = 30)]
public interface IWindowInsetsAnimationController : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/WindowInsetsAnimationController", typeof(IWindowInsetsAnimationController), isInterface: true);

	private static Delegate? cb_isReady_IsReady_Z;

	float CurrentAlpha
	{
		[SupportedOSPlatform("android30.0")]
		get;
	}

	float CurrentFraction
	{
		[SupportedOSPlatform("android30.0")]
		get;
	}

	Insets CurrentInsets
	{
		[SupportedOSPlatform("android30.0")]
		get;
	}

	Insets HiddenStateInsets
	{
		[SupportedOSPlatform("android30.0")]
		get;
	}

	bool IsCancelled
	{
		[SupportedOSPlatform("android30.0")]
		get;
	}

	bool IsFinished
	{
		[SupportedOSPlatform("android30.0")]
		get;
	}

	Insets ShownStateInsets
	{
		[SupportedOSPlatform("android30.0")]
		get;
	}

	int Types
	{
		[SupportedOSPlatform("android30.0")]
		get;
	}

	[SupportedOSPlatform("android30.0")]
	unsafe bool IsReady => _members.InstanceMethods.InvokeVirtualBooleanMethod("isReady.()Z", this, null);

	[SupportedOSPlatform("android30.0")]
	private static Delegate GetIsReadyHandler()
	{
		return new _JniMarshal_PP_B(n_IsReady);
	}

	[SupportedOSPlatform("android30.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsReady(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<IWindowInsetsAnimationController>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsReady ? ((sbyte)1) : ((sbyte)0);
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
	void Finish(bool shown);

	[SupportedOSPlatform("android30.0")]
	void SetInsetsAndAlpha(Insets? insets, float alpha, float fraction);
}
