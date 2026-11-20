using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Content;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Activity.ContextAware;

[Register("androidx/activity/contextaware/OnContextAvailableListener", DoNotGenerateAcw = true)]
internal class IOnContextAvailableListenerInvoker : Java.Lang.Object, IOnContextAvailableListener, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_activity_contextaware_OnContextAvailableListener = new XAPeerMembers("androidx/activity/contextaware/OnContextAvailableListener", typeof(IOnContextAvailableListenerInvoker));

	private static Delegate? cb_onContextAvailable_OnContextAvailable_Landroid_content_Context__V;

	private static nint java_class_ref => _members_androidx_activity_contextaware_OnContextAvailableListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_activity_contextaware_OnContextAvailableListener;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_activity_contextaware_OnContextAvailableListener.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_activity_contextaware_OnContextAvailableListener.ManagedPeerType;

	public IOnContextAvailableListenerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnContextAvailable_Landroid_content_Context_(nint jnienv, nint native__this, nint native_context)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			IOnContextAvailableListener? onContextAvailableListener = Java.Lang.Object.GetObject<IOnContextAvailableListener>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			onContextAvailableListener.OnContextAvailable(context);
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

	public unsafe void OnContextAvailable(Context context)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
			_members_androidx_activity_contextaware_OnContextAvailableListener.InstanceMethods.InvokeAbstractVoidMethod("onContextAvailable.(Landroid/content/Context;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(context);
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

	[UnmanagedCallersOnly]
	private static void n_OnContextAvailable_Landroid_content_Context__mm_wrapper(nint jnienv, nint native__this, nint native_context)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnContextAvailable_Landroid_content_Context_(jnienv, native__this, native_context);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
