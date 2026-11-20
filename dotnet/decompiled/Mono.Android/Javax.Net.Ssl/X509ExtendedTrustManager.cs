using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Net;
using Java.Security.Cert;

namespace Javax.Net.Ssl;

[SupportedOSPlatform("android24.0")]
[Register("javax/net/ssl/X509ExtendedTrustManager", DoNotGenerateAcw = true, ApiSince = 24)]
public abstract class X509ExtendedTrustManager : Java.Lang.Object, IX509TrustManager, ITrustManager, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("javax/net/ssl/X509ExtendedTrustManager", typeof(X509ExtendedTrustManager));

	private static Delegate? cb_checkServerTrusted_CheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Ljava_net_Socket__V;

	private static Delegate? cb_checkServerTrusted_CheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Ljavax_net_ssl_SSLEngine__V;

	private static Delegate? cb_checkClientTrusted_CheckClientTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String__V;

	private static Delegate? cb_checkServerTrusted_CheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String__V;

	private static Delegate? cb_getAcceptedIssuers_GetAcceptedIssuers_arrayLjava_security_cert_X509Certificate_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	protected X509ExtendedTrustManager(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetCheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Ljava_net_Socket_Handler()
	{
		return new _JniMarshal_PPLLL_V(n_CheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Ljava_net_Socket_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Ljava_net_Socket_(nint jnienv, nint native__this, nint native_chain, nint native_authType, nint native_socket)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			X509ExtendedTrustManager? x509ExtendedTrustManager = Java.Lang.Object.GetObject<X509ExtendedTrustManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			X509Certificate[] array = (X509Certificate[])JNIEnv.GetArray(native_chain, JniHandleOwnership.DoNotTransfer, typeof(X509Certificate));
			string authType = JNIEnv.GetString(native_authType, JniHandleOwnership.DoNotTransfer);
			Socket socket = Java.Lang.Object.GetObject<Socket>(native_socket, JniHandleOwnership.DoNotTransfer);
			x509ExtendedTrustManager.CheckServerTrusted(array, authType, socket);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_chain);
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

	[SupportedOSPlatform("android24.0")]
	[Register("checkServerTrusted", "([Ljava/security/cert/X509Certificate;Ljava/lang/String;Ljava/net/Socket;)V", "GetCheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Ljava_net_Socket_Handler", ApiSince = 24)]
	public abstract void CheckServerTrusted(X509Certificate[]? chain, string? authType, Socket? socket);

	[SupportedOSPlatform("android24.0")]
	private static Delegate GetCheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Ljavax_net_ssl_SSLEngine_Handler()
	{
		return new _JniMarshal_PPLLL_V(n_CheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Ljavax_net_ssl_SSLEngine_);
	}

	[SupportedOSPlatform("android24.0")]
	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Ljavax_net_ssl_SSLEngine_(nint jnienv, nint native__this, nint native_chain, nint native_authType, nint native_engine)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			X509ExtendedTrustManager? x509ExtendedTrustManager = Java.Lang.Object.GetObject<X509ExtendedTrustManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			X509Certificate[] array = (X509Certificate[])JNIEnv.GetArray(native_chain, JniHandleOwnership.DoNotTransfer, typeof(X509Certificate));
			string authType = JNIEnv.GetString(native_authType, JniHandleOwnership.DoNotTransfer);
			SSLEngine engine = Java.Lang.Object.GetObject<SSLEngine>(native_engine, JniHandleOwnership.DoNotTransfer);
			x509ExtendedTrustManager.CheckServerTrusted(array, authType, engine);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_chain);
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

	[SupportedOSPlatform("android24.0")]
	[Register("checkServerTrusted", "([Ljava/security/cert/X509Certificate;Ljava/lang/String;Ljavax/net/ssl/SSLEngine;)V", "GetCheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Ljavax_net_ssl_SSLEngine_Handler", ApiSince = 24)]
	public abstract void CheckServerTrusted(X509Certificate[]? chain, string? authType, SSLEngine? engine);

	private static Delegate GetCheckClientTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_V(n_CheckClientTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CheckClientTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_(nint jnienv, nint native__this, nint native_chain, nint native_authType)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			X509ExtendedTrustManager? x509ExtendedTrustManager = Java.Lang.Object.GetObject<X509ExtendedTrustManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			X509Certificate[] array = (X509Certificate[])JNIEnv.GetArray(native_chain, JniHandleOwnership.DoNotTransfer, typeof(X509Certificate));
			string authType = JNIEnv.GetString(native_authType, JniHandleOwnership.DoNotTransfer);
			x509ExtendedTrustManager.CheckClientTrusted(array, authType);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_chain);
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

	[Register("checkClientTrusted", "([Ljava/security/cert/X509Certificate;Ljava/lang/String;)V", "GetCheckClientTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Handler")]
	public abstract void CheckClientTrusted(X509Certificate[]? chain, string? authType);

	private static Delegate GetCheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Handler()
	{
		return new _JniMarshal_PPLL_V(n_CheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_CheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_(nint jnienv, nint native__this, nint native_chain, nint native_authType)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			X509ExtendedTrustManager? x509ExtendedTrustManager = Java.Lang.Object.GetObject<X509ExtendedTrustManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			X509Certificate[] array = (X509Certificate[])JNIEnv.GetArray(native_chain, JniHandleOwnership.DoNotTransfer, typeof(X509Certificate));
			string authType = JNIEnv.GetString(native_authType, JniHandleOwnership.DoNotTransfer);
			x509ExtendedTrustManager.CheckServerTrusted(array, authType);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_chain);
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

	[Register("checkServerTrusted", "([Ljava/security/cert/X509Certificate;Ljava/lang/String;)V", "GetCheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Handler")]
	public abstract void CheckServerTrusted(X509Certificate[]? chain, string? authType);

	private static Delegate GetGetAcceptedIssuersHandler()
	{
		return new _JniMarshal_PP_L(n_GetAcceptedIssuers);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetAcceptedIssuers(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<X509ExtendedTrustManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAcceptedIssuers());
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

	[Register("getAcceptedIssuers", "()[Ljava/security/cert/X509Certificate;", "GetGetAcceptedIssuersHandler")]
	public abstract X509Certificate[]? GetAcceptedIssuers();

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
