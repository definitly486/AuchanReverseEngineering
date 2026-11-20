using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/LifecycleEventObserver", DoNotGenerateAcw = true)]
internal class ILifecycleEventObserverInvoker : Java.Lang.Object, ILifecycleEventObserver, ILifecycleObserver, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_androidx_lifecycle_LifecycleEventObserver = new XAPeerMembers("androidx/lifecycle/LifecycleEventObserver", typeof(ILifecycleEventObserverInvoker));

	private static readonly JniPeerMembers _members_androidx_lifecycle_LifecycleObserver = new XAPeerMembers("androidx/lifecycle/LifecycleObserver", typeof(ILifecycleEventObserverInvoker));

	private static Delegate? cb_onStateChanged_OnStateChanged_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Lifecycle_Event__V;

	private static nint java_class_ref => _members_androidx_lifecycle_LifecycleEventObserver.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_androidx_lifecycle_LifecycleEventObserver;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_androidx_lifecycle_LifecycleEventObserver.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_androidx_lifecycle_LifecycleEventObserver.ManagedPeerType;

	public ILifecycleEventObserverInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_OnStateChanged_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Lifecycle_Event_(nint jnienv, nint native__this, nint native_source, nint native_e)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ILifecycleEventObserver? lifecycleEventObserver = Java.Lang.Object.GetObject<ILifecycleEventObserver>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILifecycleOwner source = Java.Lang.Object.GetObject<ILifecycleOwner>(native_source, JniHandleOwnership.DoNotTransfer);
			Lifecycle.Event e = Java.Lang.Object.GetObject<Lifecycle.Event>(native_e, JniHandleOwnership.DoNotTransfer);
			lifecycleEventObserver.OnStateChanged(source, e);
		}
		catch (System.Exception e2)
		{
			runtime.OnUserUnhandledException(ref transition, e2);
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe void OnStateChanged(ILifecycleOwner source, Lifecycle.Event e)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
			ptr[1] = new JniArgumentValue(e?.Handle ?? IntPtr.Zero);
			_members_androidx_lifecycle_LifecycleEventObserver.InstanceMethods.InvokeAbstractVoidMethod("onStateChanged.(Landroidx/lifecycle/LifecycleOwner;Landroidx/lifecycle/Lifecycle$Event;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(source);
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

	[UnmanagedCallersOnly]
	private static void n_OnStateChanged_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Lifecycle_Event__mm_wrapper(nint jnienv, nint native__this, nint native_source, nint native_e)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_OnStateChanged_Landroidx_lifecycle_LifecycleOwner_Landroidx_lifecycle_Lifecycle_Event_(jnienv, native__this, native_source, native_e);
		}
		catch (System.Exception e)
		{
			Android.Runtime.AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
