using System;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Java.Security.Cert;

[Register("java/security/cert/Certificate", DoNotGenerateAcw = true)]
public abstract class Certificate : Java.Lang.Object, ISerializable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("java/security/cert/Certificate", typeof(Certificate));

	private static Delegate? cb_getEncoded_GetEncoded_arrayB;

	private static Delegate? cb_toString_ToString_Ljava_lang_String_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected Certificate(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
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
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<Certificate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetEncoded());
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

	[Register("getEncoded", "()[B", "GetGetEncodedHandler")]
	public abstract byte[]? GetEncoded();

	private static Delegate GetToStringHandler()
	{
		return new _JniMarshal_PP_L(n_ToString);
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<Certificate>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
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
	public new abstract string? ToString();

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
