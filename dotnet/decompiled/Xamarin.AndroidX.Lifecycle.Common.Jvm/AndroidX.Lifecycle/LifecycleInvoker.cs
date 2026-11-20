using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Lifecycle;

[Register("androidx/lifecycle/Lifecycle", DoNotGenerateAcw = true)]
internal class LifecycleInvoker : Lifecycle
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/lifecycle/Lifecycle", typeof(LifecycleInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe override State CurrentState
	{
		[Register("getCurrentState", "()Landroidx/lifecycle/Lifecycle$State;", "GetGetCurrentStateHandler")]
		get
		{
			return Java.Lang.Object.GetObject<State>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCurrentState.()Landroidx/lifecycle/Lifecycle$State;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}

	public LifecycleInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[Register("addObserver", "(Landroidx/lifecycle/LifecycleObserver;)V", "GetAddObserver_Landroidx_lifecycle_LifecycleObserver_Handler")]
	public unsafe override void AddObserver(ILifecycleObserver observer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((observer == null) ? IntPtr.Zero : ((Java.Lang.Object)observer).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("addObserver.(Landroidx/lifecycle/LifecycleObserver;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(observer);
		}
	}

	[Register("removeObserver", "(Landroidx/lifecycle/LifecycleObserver;)V", "GetRemoveObserver_Landroidx_lifecycle_LifecycleObserver_Handler")]
	public unsafe override void RemoveObserver(ILifecycleObserver observer)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((observer == null) ? IntPtr.Zero : ((Java.Lang.Object)observer).Handle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("removeObserver.(Landroidx/lifecycle/LifecycleObserver;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(observer);
		}
	}
}
