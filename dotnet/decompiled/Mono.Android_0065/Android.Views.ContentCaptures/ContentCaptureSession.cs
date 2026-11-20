using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.Views.ContentCaptures;

[SupportedOSPlatform("android29.0")]
[Register("android/view/contentcapture/ContentCaptureSession", DoNotGenerateAcw = true, ApiSince = 29)]
public abstract class ContentCaptureSession : Java.Lang.Object, IAutoCloseable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/view/contentcapture/ContentCaptureSession", typeof(ContentCaptureSession));

	private static Delegate? cb_close_Close_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected ContentCaptureSession(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[SupportedOSPlatform("android29.0")]
	private static Delegate GetCloseHandler()
	{
		return new _JniMarshal_PP_V(n_Close);
	}

	[SupportedOSPlatform("android29.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Close(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ContentCaptureSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
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

	[SupportedOSPlatform("android29.0")]
	public unsafe virtual void Close()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
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
