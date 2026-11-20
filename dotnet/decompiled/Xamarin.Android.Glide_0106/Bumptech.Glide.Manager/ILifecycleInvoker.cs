using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Manager;

[Register("com/bumptech/glide/manager/Lifecycle", DoNotGenerateAcw = true)]
internal class ILifecycleInvoker : Java.Lang.Object, ILifecycle, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_com_bumptech_glide_manager_Lifecycle = new XAPeerMembers("com/bumptech/glide/manager/Lifecycle", typeof(ILifecycleInvoker));

	private static Delegate? cb_addListener_AddListener_Lcom_bumptech_glide_manager_LifecycleListener__V;

	private static Delegate? cb_removeListener_RemoveListener_Lcom_bumptech_glide_manager_LifecycleListener__V;

	private static nint java_class_ref => _members_com_bumptech_glide_manager_Lifecycle.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_com_bumptech_glide_manager_Lifecycle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_com_bumptech_glide_manager_Lifecycle.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_com_bumptech_glide_manager_Lifecycle.ManagedPeerType;

	public ILifecycleInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetAddListener_Lcom_bumptech_glide_manager_LifecycleListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_AddListener_Lcom_bumptech_glide_manager_LifecycleListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_AddListener_Lcom_bumptech_glide_manager_LifecycleListener_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ILifecycle? lifecycle = Java.Lang.Object.GetObject<ILifecycle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILifecycleListener p = Java.Lang.Object.GetObject<ILifecycleListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			lifecycle.AddListener(p);
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

	public unsafe void AddListener(ILifecycleListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_bumptech_glide_manager_Lifecycle.InstanceMethods.InvokeAbstractVoidMethod("addListener.(Lcom/bumptech/glide/manager/LifecycleListener;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(p0);
		}
	}

	private static Delegate GetRemoveListener_Lcom_bumptech_glide_manager_LifecycleListener_Handler()
	{
		return new global::_JniMarshal_PPL_V(n_RemoveListener_Lcom_bumptech_glide_manager_LifecycleListener_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveListener_Lcom_bumptech_glide_manager_LifecycleListener_(nint jnienv, nint native__this, nint native_p0)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ILifecycle? lifecycle = Java.Lang.Object.GetObject<ILifecycle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ILifecycleListener p = Java.Lang.Object.GetObject<ILifecycleListener>(native_p0, JniHandleOwnership.DoNotTransfer);
			lifecycle.RemoveListener(p);
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

	public unsafe void RemoveListener(ILifecycleListener p0)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members_com_bumptech_glide_manager_Lifecycle.InstanceMethods.InvokeAbstractVoidMethod("removeListener.(Lcom/bumptech/glide/manager/LifecycleListener;)V", this, ptr);
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
