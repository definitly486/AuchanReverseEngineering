using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Security.Cert;
using Javax.Net.Ssl;

namespace Android.Net.Http;

[Register("android/net/http/X509TrustManagerExtensions", DoNotGenerateAcw = true)]
public class X509TrustManagerExtensions : Java.Lang.Object
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("android/net/http/X509TrustManagerExtensions", typeof(X509TrustManagerExtensions));

	private static Delegate? cb_checkServerTrusted_CheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Ljava_lang_String__Ljava_util_List_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected X509TrustManagerExtensions(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "(Ljavax/net/ssl/X509TrustManager;)V", "")]
	public unsafe X509TrustManagerExtensions(IX509TrustManager? tm)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (base.Handle != IntPtr.Zero)
		{
			return;
		}
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((tm == null) ? IntPtr.Zero : ((Java.Lang.Object)tm).Handle);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljavax/net/ssl/X509TrustManager;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(Ljavax/net/ssl/X509TrustManager;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(tm);
		}
	}

	private static Delegate GetCheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLLL_L(n_CheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_CheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Ljava_lang_String_(nint jnienv, nint native__this, nint native_chain, nint native_authType, nint native_host)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			X509TrustManagerExtensions? x509TrustManagerExtensions = Java.Lang.Object.GetObject<X509TrustManagerExtensions>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			X509Certificate[] array = (X509Certificate[])JNIEnv.GetArray(native_chain, JniHandleOwnership.DoNotTransfer, typeof(X509Certificate));
			string authType = JNIEnv.GetString(native_authType, JniHandleOwnership.DoNotTransfer);
			string host = JNIEnv.GetString(native_host, JniHandleOwnership.DoNotTransfer);
			nint result = JavaList<X509Certificate>.ToLocalJniHandle(x509TrustManagerExtensions.CheckServerTrusted(array, authType, host));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_chain);
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

	[Register("checkServerTrusted", "([Ljava/security/cert/X509Certificate;Ljava/lang/String;Ljava/lang/String;)Ljava/util/List;", "GetCheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Ljava_lang_String_Handler")]
	public unsafe virtual IList<X509Certificate>? CheckServerTrusted(X509Certificate[]? chain, string? authType, string? host)
	{
		nint num = JNIEnv.NewArray(chain);
		nint num2 = JNIEnv.NewString(authType);
		nint num3 = JNIEnv.NewString(host);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(num3);
			return JavaList<X509Certificate>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("checkServerTrusted.([Ljava/security/cert/X509Certificate;Ljava/lang/String;Ljava/lang/String;)Ljava/util/List;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			if (chain != null)
			{
				JNIEnv.CopyArray(num, chain);
				JNIEnv.DeleteLocalRef(num);
			}
			JNIEnv.DeleteLocalRef(num2);
			JNIEnv.DeleteLocalRef(num3);
			GC.KeepAlive(chain);
		}
	}
}
