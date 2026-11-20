using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.OS;

[Register("android/os/Handler", DoNotGenerateAcw = true)]
public class Handler : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/os/Handler", typeof(Handler));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public unsafe Looper Looper => Java.Lang.Object.GetObject<Looper>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLooper.()Landroid/os/Looper;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public bool Post(Action action)
	{
		Thread.RunnableImplementor runnableImplementor = new Thread.RunnableImplementor(action, removable: true);
		if (Post(runnableImplementor))
		{
			return true;
		}
		runnableImplementor.Dispose();
		return false;
	}

	protected Handler(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[ObsoletedOSPlatform("android30.0")]
	public unsafe Handler()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	public unsafe Handler(Looper looper)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(looper?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/os/Looper;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Landroid/os/Looper;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(looper);
		}
	}

	public unsafe bool Post(IRunnable r)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((r == null) ? IntPtr.Zero : ((Java.Lang.Object)r).Handle);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("post.(Ljava/lang/Runnable;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(r);
		}
	}

	public unsafe bool PostDelayed(IRunnable r, long delayMillis)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((r == null) ? IntPtr.Zero : ((Java.Lang.Object)r).Handle);
			ptr[1] = new JniArgumentValue(delayMillis);
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("postDelayed.(Ljava/lang/Runnable;J)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(r);
		}
	}
}
