using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views;

[Register("android/view/SurfaceControlInputReceiver", DoNotGenerateAcw = true, ApiSince = 35)]
internal class ISurfaceControlInputReceiverInvoker : Java.Lang.Object, ISurfaceControlInputReceiver, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_android_view_SurfaceControlInputReceiver = new XAPeerMembers("android/view/SurfaceControlInputReceiver", typeof(ISurfaceControlInputReceiverInvoker));

	private static Delegate? cb_onInputEvent_OnInputEvent_Landroid_view_InputEvent__Z;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_android_view_SurfaceControlInputReceiver;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_android_view_SurfaceControlInputReceiver.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_android_view_SurfaceControlInputReceiver.ManagedPeerType;

	public ISurfaceControlInputReceiverInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[SupportedOSPlatform("android35.0")]
	private static Delegate GetOnInputEvent_Landroid_view_InputEvent_Handler()
	{
		return new _JniMarshal_PPL_B(n_OnInputEvent_Landroid_view_InputEvent_);
	}

	[SupportedOSPlatform("android35.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_OnInputEvent_Landroid_view_InputEvent_(nint jnienv, nint native__this, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISurfaceControlInputReceiver? surfaceControlInputReceiver = Java.Lang.Object.GetObject<ISurfaceControlInputReceiver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			InputEvent e = Java.Lang.Object.GetObject<InputEvent>(native_e, JniHandleOwnership.DoNotTransfer);
			return surfaceControlInputReceiver.OnInputEvent(e) ? ((sbyte)1) : ((sbyte)0);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[SupportedOSPlatform("android35.0")]
	public unsafe bool OnInputEvent(InputEvent e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			return _members_android_view_SurfaceControlInputReceiver.InstanceMethods.InvokeAbstractBooleanMethod("onInputEvent.(Landroid/view/InputEvent;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(e);
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
