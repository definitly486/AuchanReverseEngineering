using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.IO;

[Register("java/io/InputStream", DoNotGenerateAcw = true)]
public abstract class InputStream : Java.Lang.Object, ICloseable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/io/InputStream", typeof(InputStream));

	private static Delegate? cb_close_Close_V;

	private static Delegate? cb_read_Read_I;

	private static Delegate? cb_read_Read_arrayBII_I;

	private static Delegate? cb_read_Read_arrayB_I;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected InputStream(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Close(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<InputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
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

	public unsafe virtual void Close()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Read(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<InputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Read();
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public abstract int Read();

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Read_arrayBII(nint jnienv, nint native__this, nint native_b, int off, int len)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			InputStream? inputStream = Java.Lang.Object.GetObject<InputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_b, JniHandleOwnership.DoNotTransfer, typeof(byte));
			int result = inputStream.Read(array, off, len);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_b);
			}
			return result;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe virtual int Read(byte[]? b, int off, int len)
	{
		nint num = JNIEnv.NewArray(b);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(off);
			ptr[2] = new JniArgumentValue(len);
			return _members.InstanceMethods.InvokeVirtualInt32Method("read.([BII)I", this, ptr);
		}
		finally
		{
			if (b != null)
			{
				JNIEnv.CopyArray(num, b);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(b);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_Read_arrayB(nint jnienv, nint native__this, nint native_b)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			InputStream? inputStream = Java.Lang.Object.GetObject<InputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_b, JniHandleOwnership.DoNotTransfer, typeof(byte));
			int result = inputStream.Read(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_b);
			}
			return result;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	public unsafe virtual int Read(byte[]? b)
	{
		nint num = JNIEnv.NewArray(b);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return _members.InstanceMethods.InvokeVirtualInt32Method("read.([B)I", this, ptr);
		}
		finally
		{
			if (b != null)
			{
				JNIEnv.CopyArray(num, b);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(b);
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
	private static void n_Close_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_Close(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static int n_Read_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_Read(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_Read_arrayB_mm_wrapper(nint jnienv, nint native__this, nint native_b)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_Read_arrayB(jnienv, native__this, native_b);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_Read_arrayBII_mm_wrapper(nint jnienv, nint native__this, nint native_b, int off, int len)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_Read_arrayBII(jnienv, native__this, native_b, off, len);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
