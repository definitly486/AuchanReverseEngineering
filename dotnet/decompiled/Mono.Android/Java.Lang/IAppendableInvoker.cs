using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/Appendable", DoNotGenerateAcw = true)]
internal class IAppendableInvoker : Object, IAppendable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_lang_Appendable = new XAPeerMembers("java/lang/Appendable", typeof(IAppendableInvoker));

	private static Delegate? cb_append_Append_C_Ljava_lang_Appendable_;

	private static Delegate? cb_append_Append_Ljava_lang_CharSequence_II_Ljava_lang_Appendable_;

	private static Delegate? cb_append_Append_Ljava_lang_CharSequence__Ljava_lang_Appendable_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_lang_Appendable;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_lang_Appendable.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_lang_Appendable.ManagedPeerType;

	public IAppendableInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
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
			IAppendable? appendable = Object.GetObject<IAppendable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			char c = (char)native_c;
			return JNIEnv.ToLocalJniHandle(appendable.Append(c));
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

	public unsafe IAppendable Append(char c)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue((ushort)c);
		return Object.GetObject<IAppendable>(_members_java_lang_Appendable.InstanceMethods.InvokeAbstractObjectMethod("append.(C)Ljava/lang/Appendable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
			IAppendable? appendable = Object.GetObject<IAppendable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence csq = Object.GetObject<ICharSequence>(native_csq, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(appendable.Append(csq, start, end));
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

	public unsafe IAppendable Append(ICharSequence? csq, int start, int end)
	{
		nint num = CharSequence.ToLocalJniHandle(csq);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(start);
			ptr[2] = new JniArgumentValue(end);
			return Object.GetObject<IAppendable>(_members_java_lang_Appendable.InstanceMethods.InvokeAbstractObjectMethod("append.(Ljava/lang/CharSequence;II)Ljava/lang/Appendable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
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
			IAppendable? appendable = Object.GetObject<IAppendable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICharSequence csq = Object.GetObject<ICharSequence>(native_csq, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(appendable.Append(csq));
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

	public unsafe IAppendable Append(ICharSequence? csq)
	{
		nint num = CharSequence.ToLocalJniHandle(csq);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Object.GetObject<IAppendable>(_members_java_lang_Appendable.InstanceMethods.InvokeAbstractObjectMethod("append.(Ljava/lang/CharSequence;)Ljava/lang/Appendable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(csq);
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
