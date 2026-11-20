using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Request.Target;

[Register("com/bumptech/glide/request/target/SizeReadyCallback", DoNotGenerateAcw = true)]
internal class ISizeReadyCallbackInvoker : Java.Lang.Object, ISizeReadyCallback, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_request_target_SizeReadyCallback = new XAPeerMembers("com/bumptech/glide/request/target/SizeReadyCallback", typeof(ISizeReadyCallbackInvoker));

	private static Delegate? cb_onSizeReady_OnSizeReady_II_V;

	private static nint java_class_ref => _members_com_bumptech_glide_request_target_SizeReadyCallback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_request_target_SizeReadyCallback;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_request_target_SizeReadyCallback.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_request_target_SizeReadyCallback.ManagedPeerType;

	public ISizeReadyCallbackInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetOnSizeReady_IIHandler()
	{
		return new global::_JniMarshal_PPII_V(n_OnSizeReady_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnSizeReady_II(nint jnienv, nint native__this, int p0, int p1)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ISizeReadyCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnSizeReady(p0, p1);
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

	public unsafe void OnSizeReady(int p0, int p1)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(p0);
		ptr[1] = new JniArgumentValue(p1);
		_members_com_bumptech_glide_request_target_SizeReadyCallback.InstanceMethods.InvokeAbstractVoidMethod("onSizeReady.(II)V", this, ptr);
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
