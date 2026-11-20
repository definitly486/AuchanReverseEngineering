using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/Thread", DoNotGenerateAcw = true)]
public class Thread : Object, IRunnable, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("mono/java/lang/RunnableImplementor")]
	internal sealed class RunnableImplementor : Object, IRunnable, IJavaObject, IDisposable, IJavaPeerable
	{
		public Action Handler;

		private bool removable;

		private static ConditionalWeakTable<Action, RunnableImplementor> instances = new ConditionalWeakTable<Action, RunnableImplementor>();

		public RunnableImplementor(Action handler)
			: this(handler, removable: false)
		{
		}

		public RunnableImplementor(Action handler, bool removable)
			: base(JNIEnv.StartCreateInstance("mono/java/lang/RunnableImplementor", "()V"), JniHandleOwnership.TransferLocalRef)
		{
			JNIEnv.FinishCreateInstance(base.Handle, "()V");
			Handler = handler;
			this.removable = removable;
			if (removable)
			{
				lock (instances)
				{
					instances.AddOrUpdate(handler, this);
				}
			}
		}

		public void Run()
		{
			if (Handler != null)
			{
				Handler();
			}
			if (removable)
			{
				lock (instances)
				{
					if (Handler != null)
					{
						instances.Remove(Handler);
					}
				}
			}
			Dispose();
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

	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/Thread", typeof(Thread));

	private static Delegate? cb_run_Run_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public Thread(Action runHandler)
		: this(new RunnableImplementor(runHandler))
	{
	}

	public Thread(Action runHandler, string threadName)
		: this(new RunnableImplementor(runHandler), threadName)
	{
	}

	public Thread(ThreadGroup group, Action runHandler)
		: this(group, new RunnableImplementor(runHandler))
	{
	}

	public Thread(ThreadGroup group, Action runHandler, string threadName)
		: this(group, new RunnableImplementor(runHandler), threadName)
	{
	}

	public Thread(ThreadGroup group, Action runHandler, string threadName, long stackSize)
		: this(group, new RunnableImplementor(runHandler), threadName, stackSize)
	{
	}

	protected Thread(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe Thread()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(Ljava/lang/Runnable;Ljava/lang/String;)V", "")]
	public unsafe Thread(IRunnable? target, string name)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue((target == null) ? IntPtr.Zero : ((Object)target).Handle);
			ptr[1] = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Runnable;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Runnable;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(target);
		}
	}

	[Register(".ctor", "(Ljava/lang/Runnable;)V", "")]
	public unsafe Thread(IRunnable? target)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((target == null) ? IntPtr.Zero : ((Object)target).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Runnable;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Runnable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(target);
		}
	}

	[Register(".ctor", "(Ljava/lang/String;)V", "")]
	public unsafe Thread(string name)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[SupportedOSPlatform("android33.0")]
	[Register(".ctor", "(Ljava/lang/ThreadGroup;Ljava/lang/Runnable;Ljava/lang/String;JZ)V", "", ApiSince = 33)]
	public unsafe Thread(ThreadGroup? group, IRunnable? target, string name, long stackSize, bool inheritThreadLocals)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
			*ptr = new JniArgumentValue(group?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((target == null) ? IntPtr.Zero : ((Object)target).Handle);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(stackSize);
			ptr[4] = new JniArgumentValue(inheritThreadLocals ? ((sbyte)1) : ((sbyte)0));
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/ThreadGroup;Ljava/lang/Runnable;Ljava/lang/String;JZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/ThreadGroup;Ljava/lang/Runnable;Ljava/lang/String;JZ)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(group);
			GC.KeepAlive(target);
		}
	}

	[Register(".ctor", "(Ljava/lang/ThreadGroup;Ljava/lang/Runnable;Ljava/lang/String;J)V", "")]
	public unsafe Thread(ThreadGroup? group, IRunnable? target, string name, long stackSize)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(group?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((target == null) ? IntPtr.Zero : ((Object)target).Handle);
			ptr[2] = new JniArgumentValue(num);
			ptr[3] = new JniArgumentValue(stackSize);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/ThreadGroup;Ljava/lang/Runnable;Ljava/lang/String;J)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/ThreadGroup;Ljava/lang/Runnable;Ljava/lang/String;J)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(group);
			GC.KeepAlive(target);
		}
	}

	[Register(".ctor", "(Ljava/lang/ThreadGroup;Ljava/lang/Runnable;Ljava/lang/String;)V", "")]
	public unsafe Thread(ThreadGroup? group, IRunnable? target, string name)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(group?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((target == null) ? IntPtr.Zero : ((Object)target).Handle);
			ptr[2] = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/ThreadGroup;Ljava/lang/Runnable;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/ThreadGroup;Ljava/lang/Runnable;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(group);
			GC.KeepAlive(target);
		}
	}

	[Register(".ctor", "(Ljava/lang/ThreadGroup;Ljava/lang/Runnable;)V", "")]
	public unsafe Thread(ThreadGroup? group, IRunnable? target)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(group?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue((target == null) ? IntPtr.Zero : ((Object)target).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/ThreadGroup;Ljava/lang/Runnable;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/ThreadGroup;Ljava/lang/Runnable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(group);
			GC.KeepAlive(target);
		}
	}

	[Register(".ctor", "(Ljava/lang/ThreadGroup;Ljava/lang/String;)V", "")]
	public unsafe Thread(ThreadGroup? group, string name)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(group?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/ThreadGroup;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/ThreadGroup;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(group);
		}
	}

	private static Delegate GetRunHandler()
	{
		return new _JniMarshal_PP_V(n_Run);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Run(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Object.GetObject<Thread>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Run();
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

	[Register("run", "()V", "GetRunHandler")]
	public unsafe virtual void Run()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("run.()V", this, null);
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
