using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Java.Security;

[Register("java/security/Key", DoNotGenerateAcw = true)]
internal class IKeyInvoker : Java.Lang.Object, IKey, ISerializable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_java_io_Serializable = new XAPeerMembers("java/io/Serializable", typeof(IKeyInvoker));

	private static readonly JniPeerMembers _members_java_security_Key = new XAPeerMembers("java/security/Key", typeof(IKeyInvoker));

	private static Delegate? cb_getAlgorithm_GetAlgorithm_Ljava_lang_String_;

	private static Delegate? cb_getFormat_GetFormat_Ljava_lang_String_;

	private static Delegate? cb_getEncoded_GetEncoded_arrayB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_java_security_Key;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_java_security_Key.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_java_security_Key.ManagedPeerType;

	public unsafe string? Algorithm => JNIEnv.GetString(_members_java_security_Key.InstanceMethods.InvokeAbstractObjectMethod("getAlgorithm.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? Format => JNIEnv.GetString(_members_java_security_Key.InstanceMethods.InvokeAbstractObjectMethod("getFormat.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public IKeyInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	private static Delegate GetGetAlgorithmHandler()
	{
		return new _JniMarshal_PP_L(n_GetAlgorithm);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAlgorithm(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Algorithm);
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

	private static Delegate GetGetFormatHandler()
	{
		return new _JniMarshal_PP_L(n_GetFormat);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetFormat(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Format);
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

	private static Delegate GetGetEncodedHandler()
	{
		return new _JniMarshal_PP_L(n_GetEncoded);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetEncoded(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IKey>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetEncoded());
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

	public unsafe byte[]? GetEncoded()
	{
		return (byte[])JNIEnv.GetArray(_members_java_security_Key.InstanceMethods.InvokeAbstractObjectMethod("getEncoded.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
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
