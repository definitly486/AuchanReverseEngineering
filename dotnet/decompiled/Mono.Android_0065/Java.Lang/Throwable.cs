using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;

namespace Java.Lang;

[Register("java/lang/Throwable", DoNotGenerateAcw = true)]
public class Throwable : JavaException, IJavaObject, IDisposable, IJavaObjectEx, ISerializable, IJavaPeerable
{
	protected bool is_generated;

	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/Throwable", typeof(Throwable));

	private static Delegate? cb_getMessage_GetMessage_Ljava_lang_String_;

	private static Delegate? cb_getStackTrace_GetStackTrace_arrayLjava_lang_StackTraceElement_;

	private static Delegate? cb_setStackTrace_SetStackTrace_arrayLjava_lang_StackTraceElement__V;

	public override string StackTrace => base.StackTrace;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public new int JniIdentityHashCode => base.JniIdentityHashCode;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public new JniObjectReference PeerReference => base.PeerReference;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public nint Handle
	{
		get
		{
			JniObjectReference peerReference = PeerReference;
			if (!peerReference.IsValid)
			{
				return IntPtr.Zero;
			}
			return peerReference.Handle;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected virtual nint ThresholdClass => class_ref;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected virtual Type ThresholdType => typeof(Throwable);

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	public new unsafe virtual string? Message => JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe Throwable(nint handle, JniHandleOwnership transfer)
		: base(ref *JavaException.InvalidJniObjectReference, JniObjectReferenceOptions.None, new JniObjectReference(handle))
	{
		if (GetType() == typeof(Throwable))
		{
			is_generated = true;
		}
		SetHandle(handle, transfer);
	}

	nint IJavaObjectEx.ToLocalJniHandle()
	{
		lock (this)
		{
			JniObjectReference peerReference = PeerReference;
			if (!peerReference.IsValid)
			{
				return IntPtr.Zero;
			}
			return peerReference.NewLocalRef().Handle;
		}
	}

	public override string ToString()
	{
		return base.ToString();
	}

	internal nint GetThresholdClass()
	{
		return ThresholdClass;
	}

	internal Type GetThresholdType()
	{
		return ThresholdType;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	protected void SetHandle(nint value, JniHandleOwnership transfer)
	{
		JniObjectReference reference = new JniObjectReference(value);
		Construct(ref reference, (value != IntPtr.Zero) ? JniObjectReferenceOptions.Copy : JniObjectReferenceOptions.None);
		if (value != IntPtr.Zero)
		{
			SetJavaStackTrace(new JniObjectReference(value));
		}
		JNIEnv.DeleteRef(value, transfer);
	}

	public static Throwable FromException(System.Exception e)
	{
		if (e == null)
		{
			throw new ArgumentNullException("e");
		}
		if (e is Throwable)
		{
			return (Throwable)e;
		}
		return JavaProxyThrowable.Create(e);
	}

	~Throwable()
	{
	}

	public new void UnregisterFromRuntime()
	{
		base.UnregisterFromRuntime();
	}

	public new void Dispose()
	{
		base.Dispose();
	}

	protected override void Dispose(bool disposing)
	{
	}

	public unsafe Throwable()
		: this(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", ((object)this).GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	protected unsafe Throwable(string? message, Throwable? cause, bool enableSuppression, bool writableStackTrace)
		: this(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(message);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
			ptr[2] = new JniArgumentValue(enableSuppression ? ((sbyte)1) : ((sbyte)0));
			ptr[3] = new JniArgumentValue(writableStackTrace ? ((sbyte)1) : ((sbyte)0));
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;ZZ)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;ZZ)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(cause);
		}
	}

	public unsafe Throwable(string? message, Throwable? cause)
		: this(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(message);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(cause);
		}
	}

	public unsafe Throwable(string? message)
		: this(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (Handle != IntPtr.Zero)
		{
			return;
		}
		nint num = JNIEnv.NewString(message);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	public unsafe Throwable(Throwable? cause)
		: this(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Throwable;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Throwable;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(cause);
		}
	}

	private static Delegate GetGetMessageHandler()
	{
		return new _JniMarshal_PP_L(n_GetMessage);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetMessage(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Object.GetObject<Throwable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Message);
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

	private static Delegate GetGetStackTraceHandler()
	{
		return new _JniMarshal_PP_L(n_GetStackTrace);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetStackTrace(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Object.GetObject<Throwable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetStackTrace());
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

	public unsafe virtual StackTraceElement[] GetStackTrace()
	{
		return (StackTraceElement[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("getStackTrace.()[Ljava/lang/StackTraceElement;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(StackTraceElement));
	}

	private static Delegate GetSetStackTrace_arrayLjava_lang_StackTraceElement_Handler()
	{
		return new _JniMarshal_PPL_V(n_SetStackTrace_arrayLjava_lang_StackTraceElement_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_SetStackTrace_arrayLjava_lang_StackTraceElement_(nint jnienv, nint native__this, nint native_stackTrace)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Throwable? throwable = Object.GetObject<Throwable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			StackTraceElement[] array = (StackTraceElement[])JNIEnv.GetArray(native_stackTrace, JniHandleOwnership.DoNotTransfer, typeof(StackTraceElement));
			throwable.SetStackTrace(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_stackTrace);
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

	public unsafe virtual void SetStackTrace(StackTraceElement[] stackTrace)
	{
		nint num = JNIEnv.NewArray(stackTrace);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setStackTrace.([Ljava/lang/StackTraceElement;)V", this, ptr);
		}
		finally
		{
			if (stackTrace != null)
			{
				JNIEnv.CopyArray(num, stackTrace);
				JNIEnv.DeleteLocalRef(num);
			}
			GC.KeepAlive(stackTrace);
		}
	}
}
