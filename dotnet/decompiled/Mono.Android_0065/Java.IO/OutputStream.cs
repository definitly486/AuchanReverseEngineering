using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.IO;

[Register("java/io/OutputStream", DoNotGenerateAcw = true)]
public abstract class OutputStream : Java.Lang.Object, ICloseable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/io/OutputStream", typeof(OutputStream));

	private static Delegate? cb_close_Close_V;

	private static Delegate? cb_flush_Flush_V;

	private static Delegate? cb_write_Write_arrayBII_V;

	private static Delegate? cb_write_Write_arrayB_V;

	private static Delegate? cb_write_Write_I_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected OutputStream(nint javaReference, JniHandleOwnership transfer)
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
			Java.Lang.Object.GetObject<OutputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
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
	private static void n_Flush(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<OutputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Flush();
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

	public unsafe virtual void Flush()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("flush.()V", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Write_arrayBII(nint jnienv, nint native__this, nint native_b, int off, int len)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			OutputStream? outputStream = Java.Lang.Object.GetObject<OutputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_b, JniHandleOwnership.DoNotTransfer, typeof(byte));
			outputStream.Write(array, off, len);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_b);
			}
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

	public unsafe virtual void Write(byte[]? b, int off, int len)
	{
		nint num = JNIEnv.NewArray(b);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(off);
			ptr[2] = new JniArgumentValue(len);
			_members.InstanceMethods.InvokeVirtualVoidMethod("write.([BII)V", this, ptr);
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
	private static void n_Write_arrayB(nint jnienv, nint native__this, nint native_b)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			OutputStream? outputStream = Java.Lang.Object.GetObject<OutputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_b, JniHandleOwnership.DoNotTransfer, typeof(byte));
			outputStream.Write(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_b);
			}
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

	public unsafe virtual void Write(byte[]? b)
	{
		nint num = JNIEnv.NewArray(b);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("write.([B)V", this, ptr);
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
	private static void n_Write_I(nint jnienv, nint native__this, int b)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<OutputStream>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Write(b);
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

	public abstract void Write(int b);

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
	private static void n_Flush_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_Flush(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_Write_arrayB_mm_wrapper(nint jnienv, nint native__this, nint native_b)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_Write_arrayB(jnienv, native__this, native_b);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_Write_arrayBII_mm_wrapper(nint jnienv, nint native__this, nint native_b, int off, int len)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_Write_arrayBII(jnienv, native__this, native_b, off, len);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_Write_I_mm_wrapper(nint jnienv, nint native__this, int b)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_Write_I(jnienv, native__this, b);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
