using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.IO;

[Register("java/io/PrintWriter", DoNotGenerateAcw = true)]
public class PrintWriter : Writer
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/io/PrintWriter", typeof(PrintWriter));

	private static Delegate? cb_close_Close_V;

	private static Delegate? cb_flush_Flush_V;

	private static Delegate? cb_write_Write_arrayCII_V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected PrintWriter(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	private static Delegate GetCloseHandler()
	{
		return new _JniMarshal_PP_V(n_Close);
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
			Java.Lang.Object.GetObject<PrintWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
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

	public unsafe override void Close()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
	}

	private static Delegate GetFlushHandler()
	{
		return new _JniMarshal_PP_V(n_Flush);
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
			Java.Lang.Object.GetObject<PrintWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Flush();
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

	public unsafe override void Flush()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("flush.()V", this, null);
	}

	private static Delegate GetWrite_arrayCIIHandler()
	{
		return new _JniMarshal_PPLII_V(n_Write_arrayCII);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Write_arrayCII(nint jnienv, nint native__this, nint native_buf, int off, int len)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			PrintWriter? printWriter = Java.Lang.Object.GetObject<PrintWriter>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char[] array = (char[])JNIEnv.GetArray(native_buf, JniHandleOwnership.DoNotTransfer, typeof(char));
			printWriter.Write(array, off, len);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_buf);
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

	public unsafe override void Write(char[]? buf, int off, int len)
	{
		nint num = JNIEnv.NewArray(buf);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(off);
			ptr[2] = new JniArgumentValue(len);
			_members.InstanceMethods.InvokeVirtualVoidMethod("write.([CII)V", this, ptr);
		}
		finally
		{
			if (buf != null)
			{
				JNIEnv.CopyArray(num, buf);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(buf);
		}
	}
}
