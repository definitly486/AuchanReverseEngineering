using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Java.IO;

[Register("java/io/Writer", DoNotGenerateAcw = true)]
public abstract class Writer : Java.Lang.Object, ICloseable, IJavaObject, IDisposable, IJavaPeerable, IAppendable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/io/Writer", typeof(Writer));

	private static Delegate? cb_append_Append_C_Ljava_lang_Appendable_;

	private static Delegate? cb_append_Append_Ljava_lang_CharSequence_II_Ljava_lang_Appendable_;

	private static Delegate? cb_append_Append_Ljava_lang_CharSequence__Ljava_lang_Appendable_;

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

	protected Writer(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	protected unsafe Writer()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetAppend_CHandler()
	{
		return new _JniMarshal_PPs_L(n_Append_C);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Append_C(nint jnienv, nint native__this, ushort native_c)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Writer? writer = Java.Lang.Object.GetObject<Writer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char c = (char)native_c;
			return JNIEnv.ToLocalJniHandle(writer.Append(c));
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

	[Register("append", "(C)Ljava/lang/Appendable;", "GetAppend_CHandler")]
	public unsafe virtual IAppendable? Append(char c)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((ushort)c);
		return Java.Lang.Object.GetObject<IAppendable>(_members.InstanceMethods.InvokeVirtualObjectMethod("append.(C)Ljava/lang/Appendable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetAppend_Ljava_lang_CharSequence_IIHandler()
	{
		return new _JniMarshal_PPLII_L(n_Append_Ljava_lang_CharSequence_II);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Append_Ljava_lang_CharSequence_II(nint jnienv, nint native__this, nint native_csq, int start, int end)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Writer? writer = Java.Lang.Object.GetObject<Writer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence csq = Java.Lang.Object.GetObject<ICharSequence>(native_csq, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(writer.Append(csq, start, end));
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

	[Register("append", "(Ljava/lang/CharSequence;II)Ljava/lang/Appendable;", "GetAppend_Ljava_lang_CharSequence_IIHandler")]
	public unsafe virtual IAppendable? Append(ICharSequence? csq, int start, int end)
	{
		nint num = CharSequence.ToLocalJniHandle(csq);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(end);
			return Java.Lang.Object.GetObject<IAppendable>(_members.InstanceMethods.InvokeVirtualObjectMethod("append.(Ljava/lang/CharSequence;II)Ljava/lang/Appendable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(csq);
		}
	}

	private static Delegate GetAppend_Ljava_lang_CharSequence_Handler()
	{
		return new _JniMarshal_PPL_L(n_Append_Ljava_lang_CharSequence_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Append_Ljava_lang_CharSequence_(nint jnienv, nint native__this, nint native_csq)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Writer? writer = Java.Lang.Object.GetObject<Writer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence csq = Java.Lang.Object.GetObject<ICharSequence>(native_csq, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(writer.Append(csq));
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

	[Register("append", "(Ljava/lang/CharSequence;)Ljava/lang/Appendable;", "GetAppend_Ljava_lang_CharSequence_Handler")]
	public unsafe virtual IAppendable? Append(ICharSequence? csq)
	{
		nint num = CharSequence.ToLocalJniHandle(csq);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<IAppendable>(_members.InstanceMethods.InvokeVirtualObjectMethod("append.(Ljava/lang/CharSequence;)Ljava/lang/Appendable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(csq);
		}
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
			Java.Lang.Object.GetObject<Writer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
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

	[Register("close", "()V", "GetCloseHandler")]
	public abstract void Close();

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Flush(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<Writer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Flush();
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

	[Register("flush", "()V", "GetFlushHandler")]
	public abstract void Flush();

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Write_arrayCII(nint jnienv, nint native__this, nint native_cbuf, int off, int len)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Writer? writer = Java.Lang.Object.GetObject<Writer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char[] array = (char[])JNIEnv.GetArray(native_cbuf, JniHandleOwnership.DoNotTransfer, typeof(char));
			writer.Write(array, off, len);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_cbuf);
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

	[Register("write", "([CII)V", "GetWrite_arrayCIIHandler")]
	public abstract void Write(char[]? cbuf, int off, int len);

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
	private static void n_Write_arrayCII_mm_wrapper(nint jnienv, nint native__this, nint native_cbuf, int off, int len)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_Write_arrayCII(jnienv, native__this, native_cbuf, off, len);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
