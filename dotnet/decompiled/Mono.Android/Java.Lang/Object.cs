using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Android.Runtime;
using Java.Interop;

namespace Java.Lang;

[Serializable]
[Register("java/lang/Object", DoNotGenerateAcw = true)]
public class Object : Java.Interop.JavaObject, IJavaObject, IDisposable, IJavaObjectEx
{
	internal const DynamicallyAccessedMemberTypes Constructors = DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors;

	private static readonly JniPeerMembers _members = new XAPeerMembers("java/lang/Object", typeof(Object));

	private static Delegate? cb_clone_Clone_Ljava_lang_Object_;

	private static Delegate? cb_equals_Equals_Ljava_lang_Object__Z;

	private static Delegate? cb_finalize_JavaFinalize_V;

	private static Delegate? cb_hashCode_GetHashCode_I;

	private static Delegate? cb_toString_ToString_Ljava_lang_String_;

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
	protected virtual nint ThresholdClass => Java.Lang.Class.Object;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected virtual Type ThresholdType => typeof(Object);

	internal static nint class_ref => _members.JniPeerType.PeerReference.Handle;

	public unsafe Class Class
	{
		[Register("getClass", "()Ljava/lang/Class;", "")]
		get
		{
			return GetObject<Class>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getClass.()Ljava/lang/Class;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
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

	~Object()
	{
	}

	public unsafe Object(nint handle, JniHandleOwnership transfer)
		: base(ref *Java.Interop.JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
	{
		SetHandle(handle, transfer);
	}

	[OnDeserialized]
	internal void SetHandleOnDeserialized(StreamingContext context)
	{
		if (Handle == IntPtr.Zero)
		{
			SetHandle(JNIEnv.StartCreateInstance(GetType(), "()V"), JniHandleOwnership.TransferLocalRef);
			JNIEnv.FinishCreateInstance(Handle, "()V");
		}
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
	public new void UnregisterFromRuntime()
	{
		base.UnregisterFromRuntime();
	}

	protected override void Dispose(bool disposing)
	{
	}

	public new void Dispose()
	{
		base.Dispose();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	protected void SetHandle(nint value, JniHandleOwnership transfer)
	{
		JniObjectReference reference = new JniObjectReference(value);
		JniObjectReferenceOptions jniObjectReferenceOptions = FromJniHandleOwnership(transfer);
		JniEnvironment.Runtime.ValueManager.ConstructPeer(this, ref reference, (value != IntPtr.Zero) ? jniObjectReferenceOptions : JniObjectReferenceOptions.None);
		JNIEnv.DeleteRef(value, transfer);
	}

	private static JniObjectReferenceOptions FromJniHandleOwnership(JniHandleOwnership transfer)
	{
		JniObjectReferenceOptions jniObjectReferenceOptions = JniObjectReferenceOptions.Copy;
		if (transfer.HasFlag(JniHandleOwnership.DoNotRegister))
		{
			jniObjectReferenceOptions |= JniObjectReferenceOptions.CopyAndDoNotRegister;
		}
		return jniObjectReferenceOptions;
	}

	internal static IJavaPeerable? PeekObject(nint handle, Type? requiredType = null)
	{
		IJavaPeerable javaPeerable = JniEnvironment.Runtime.ValueManager.PeekPeer(new JniObjectReference(handle));
		if (javaPeerable == null)
		{
			return null;
		}
		if (requiredType != null && !requiredType.IsAssignableFrom(javaPeerable.GetType()))
		{
			return null;
		}
		return javaPeerable;
	}

	internal static T? PeekObject<T>(nint handle)
	{
		return (T)PeekObject(handle, typeof(T));
	}

	public static T? GetObject<T>(nint jnienv, nint handle, JniHandleOwnership transfer) where T : class, IJavaObject
	{
		JNIEnv.CheckHandle(jnienv);
		return GetObject<T>(handle, transfer);
	}

	public static T? GetObject<T>(nint handle, JniHandleOwnership transfer) where T : class, IJavaObject
	{
		return _GetObject<T>(handle, transfer);
	}

	internal static T? _GetObject<T>(nint handle, JniHandleOwnership transfer)
	{
		if (handle == IntPtr.Zero)
		{
			return default(T);
		}
		return (T)GetObject(handle, transfer, typeof(T));
	}

	internal static IJavaPeerable? GetObject(nint handle, JniHandleOwnership transfer, Type? type = null)
	{
		if (handle == IntPtr.Zero)
		{
			return null;
		}
		IJavaPeerable? result = GetPeer(handle, type);
		JNIEnv.DeleteRef(handle, transfer);
		return result;
		[UnconditionalSuppressMessage("Trimming", "IL2067:'targetType' argument does not satisfy 'DynamicallyAccessedMemberTypes.PublicConstructors', 'DynamicallyAccessedMemberTypes.NonPublicConstructors' in call to 'Java.Interop.JniRuntime.JniValueManager.GetPeer(JniObjectReference, Type)'.", Justification = "The MarkJavaObjects step preserves ctors on Java.Lang.Object subclasses.")]
		static IJavaPeerable? GetPeer(nint handle2, Type? targetType)
		{
			return JniEnvironment.Runtime.ValueManager.GetPeer(new JniObjectReference(handle2), targetType);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public T[]? ToArray<T>()
	{
		return JNIEnv.GetArray<T>(Handle);
	}

	public static Object? FromArray<T>(T[] value)
	{
		if (value == null)
		{
			return null;
		}
		return new Object(JNIEnv.NewArray(value), JniHandleOwnership.TransferLocalRef);
	}

	public static implicit operator Object(bool value)
	{
		return new Boolean(value);
	}

	[Obsolete("Use `(Java.Lang.Byte)(sbyte) value`", true)]
	public static implicit operator Object(byte value)
	{
		throw new InvalidOperationException("Should not be reached");
	}

	public static implicit operator Object(sbyte value)
	{
		return new Byte(value);
	}

	public static implicit operator Object(char value)
	{
		return new Character(value);
	}

	[Obsolete("Use `(Java.Lang.Integer)(int) value`", true)]
	public static implicit operator Object(uint value)
	{
		throw new InvalidOperationException("Should not be reached");
	}

	public static implicit operator Object(int value)
	{
		return new Integer(value);
	}

	[Obsolete("Use `(Java.Lang.Long)(long) value`", true)]
	public static implicit operator Object(ulong value)
	{
		throw new InvalidOperationException("Should not be reached");
	}

	public static implicit operator Object(long value)
	{
		return new Long(value);
	}

	public static implicit operator Object(float value)
	{
		return new Float(value);
	}

	public static implicit operator Object(double value)
	{
		return new Double(value);
	}

	public static implicit operator Object?(string? value)
	{
		if (value == null)
		{
			return null;
		}
		return new ICharSequenceInvoker(JNIEnv.NewString(value), JniHandleOwnership.TransferLocalRef);
	}

	public static explicit operator bool(Object value)
	{
		return Convert.ToBoolean(value, CultureInfo.InvariantCulture);
	}

	[Obsolete("Use `(byte)(sbyte) value`", true)]
	public static explicit operator byte(Object value)
	{
		throw new InvalidOperationException("Should not be reached");
	}

	public static explicit operator sbyte(Object value)
	{
		return Convert.ToSByte(value, CultureInfo.InvariantCulture);
	}

	public static explicit operator char(Object value)
	{
		return Convert.ToChar(value, CultureInfo.InvariantCulture);
	}

	[Obsolete("Use `(uint)(int) value`", true)]
	public static explicit operator uint(Object value)
	{
		throw new InvalidOperationException("Should not be reached");
	}

	public static explicit operator int(Object value)
	{
		return Convert.ToInt32(value, CultureInfo.InvariantCulture);
	}

	[Obsolete("Use `(ulong)(long) value`", true)]
	public static explicit operator ulong(Object value)
	{
		throw new InvalidOperationException("Should not be reached");
	}

	public static explicit operator long(Object value)
	{
		return Convert.ToInt64(value, CultureInfo.InvariantCulture);
	}

	public static explicit operator float(Object value)
	{
		return Convert.ToSingle(value, CultureInfo.InvariantCulture);
	}

	public static explicit operator double(Object value)
	{
		return Convert.ToDouble(value, CultureInfo.InvariantCulture);
	}

	public static explicit operator string?(Object? value)
	{
		if (value == null)
		{
			return null;
		}
		return Convert.ToString(value, CultureInfo.InvariantCulture);
	}

	[return: NotNullIfNotNull("value")]
	public static implicit operator Object?(Object[]? value)
	{
		if (value == null)
		{
			return null;
		}
		return new Object(JNIEnv.NewArray(value), JniHandleOwnership.TransferLocalRef);
	}

	[return: NotNullIfNotNull("value")]
	public static implicit operator Object?(bool[]? value)
	{
		if (value == null)
		{
			return null;
		}
		return new Object(JNIEnv.NewArray(value), JniHandleOwnership.TransferLocalRef);
	}

	[return: NotNullIfNotNull("value")]
	public static implicit operator Object?(byte[]? value)
	{
		if (value == null)
		{
			return null;
		}
		return new Object(JNIEnv.NewArray(value), JniHandleOwnership.TransferLocalRef);
	}

	[return: NotNullIfNotNull("value")]
	public static implicit operator Object?(char[]? value)
	{
		if (value == null)
		{
			return null;
		}
		return new Object(JNIEnv.NewArray(value), JniHandleOwnership.TransferLocalRef);
	}

	[return: NotNullIfNotNull("value")]
	public static implicit operator Object?(int[]? value)
	{
		if (value == null)
		{
			return null;
		}
		return new Object(JNIEnv.NewArray(value), JniHandleOwnership.TransferLocalRef);
	}

	[return: NotNullIfNotNull("value")]
	public static implicit operator Object?(long[]? value)
	{
		if (value == null)
		{
			return null;
		}
		return new Object(JNIEnv.NewArray(value), JniHandleOwnership.TransferLocalRef);
	}

	[return: NotNullIfNotNull("value")]
	public static implicit operator Object?(float[]? value)
	{
		if (value == null)
		{
			return null;
		}
		return new Object(JNIEnv.NewArray(value), JniHandleOwnership.TransferLocalRef);
	}

	[return: NotNullIfNotNull("value")]
	public static implicit operator Object?(double[]? value)
	{
		if (value == null)
		{
			return null;
		}
		return new Object(JNIEnv.NewArray(value), JniHandleOwnership.TransferLocalRef);
	}

	[return: NotNullIfNotNull("value")]
	public static implicit operator Object?(string[]? value)
	{
		if (value == null)
		{
			return null;
		}
		return new Object(JNIEnv.NewArray(value), JniHandleOwnership.TransferLocalRef);
	}

	public static explicit operator Object[]?(Object? value)
	{
		return value?.ToArray<Object>();
	}

	public static explicit operator bool[]?(Object? value)
	{
		return value?.ToArray<bool>();
	}

	public static explicit operator byte[]?(Object? value)
	{
		return value?.ToArray<byte>();
	}

	public static explicit operator char[]?(Object? value)
	{
		return value?.ToArray<char>();
	}

	public static explicit operator int[]?(Object? value)
	{
		return value?.ToArray<int>();
	}

	public static explicit operator long[]?(Object? value)
	{
		return value?.ToArray<long>();
	}

	public static explicit operator float[]?(Object? value)
	{
		return value?.ToArray<float>();
	}

	public static explicit operator double[]?(Object? value)
	{
		return value?.ToArray<double>();
	}

	public static explicit operator string[]?(Object? value)
	{
		return value?.ToArray<string>();
	}

	[Register(".ctor", "()V", "")]
	protected unsafe Object()
		: this(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (Handle == IntPtr.Zero)
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	private static Delegate GetCloneHandler()
	{
		return new _JniMarshal_PP_L(n_Clone);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_Clone(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(GetObject<Object>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone());
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

	[Register("clone", "()Ljava/lang/Object;", "GetCloneHandler")]
	protected unsafe virtual Object Clone()
	{
		return GetObject<Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("clone.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_Equals_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_obj)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			Object? obj = GetObject<Object>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Object obj2 = GetObject<Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return obj.Equals(obj2) ? ((sbyte)1) : ((sbyte)0);
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

	[Register("equals", "(Ljava/lang/Object;)Z", "GetEquals_Ljava_lang_Object_Handler")]
	public unsafe virtual bool Equals(Object? obj)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("equals.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(obj);
		}
	}

	private static Delegate GetJavaFinalizeHandler()
	{
		return new _JniMarshal_PP_V(n_JavaFinalize);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_JavaFinalize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			GetObject<Object>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).JavaFinalize();
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

	[Register("finalize", "()V", "GetJavaFinalizeHandler")]
	protected unsafe virtual void JavaFinalize()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("finalize.()V", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetHashCode(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return GetObject<Object>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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

	[Register("hashCode", "()I", "GetGetHashCodeHandler")]
	public unsafe override int GetHashCode()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("hashCode.()I", this, null);
	}

	[Register("notify", "()V", "")]
	public unsafe void Notify()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("notify.()V", this, null);
	}

	[Register("notifyAll", "()V", "")]
	public unsafe void NotifyAll()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("notifyAll.()V", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_ToString(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(GetObject<Object>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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

	[Register("toString", "()Ljava/lang/String;", "GetToStringHandler")]
	public unsafe override string ToString()
	{
		return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("toString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	[Register("wait", "()V", "")]
	public unsafe void Wait()
	{
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("wait.()V", this, null);
	}

	[Register("wait", "(JI)V", "")]
	public unsafe void Wait(long timeoutMillis, int nanos)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(timeoutMillis);
		ptr[1] = new JniArgumentValue(nanos);
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("wait.(JI)V", this, ptr);
	}

	[Register("wait", "(J)V", "")]
	public unsafe void Wait(long timeoutMillis)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(timeoutMillis);
		_members.InstanceMethods.InvokeNonvirtualVoidMethod("wait.(J)V", this, ptr);
	}

	[UnmanagedCallersOnly]
	private static sbyte n_Equals_Ljava_lang_Object__mm_wrapper(nint jnienv, nint native__this, nint native_obj)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_Equals_Ljava_lang_Object_(jnienv, native__this, native_obj);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetHashCode_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetHashCode(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_ToString_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_ToString(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
