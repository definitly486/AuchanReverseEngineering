using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Window;

[Register("android/window/OnBackInvokedCallback", DoNotGenerateAcw = true, ApiSince = 33)]
internal class IOnBackInvokedCallbackInvoker : Java.Lang.Object, IOnBackInvokedCallback, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_window_OnBackInvokedCallback = new XAPeerMembers("android/window/OnBackInvokedCallback", typeof(IOnBackInvokedCallbackInvoker));

	private static Delegate? cb_onBackInvoked_OnBackInvoked_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_window_OnBackInvokedCallback;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_window_OnBackInvokedCallback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_window_OnBackInvokedCallback.ManagedPeerType;

	public IOnBackInvokedCallbackInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[SupportedOSPlatform("android33.0")]
	private static Delegate GetOnBackInvokedHandler()
	{
		return new _JniMarshal_PP_V(n_OnBackInvoked);
	}

	[SupportedOSPlatform("android33.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnBackInvoked(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<IOnBackInvokedCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnBackInvoked();
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

	[SupportedOSPlatform("android33.0")]
	public unsafe void OnBackInvoked()
	{
		_members_android_window_OnBackInvokedCallback.InstanceMethods.InvokeAbstractVoidMethod("onBackInvoked.()V", this, null);
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
