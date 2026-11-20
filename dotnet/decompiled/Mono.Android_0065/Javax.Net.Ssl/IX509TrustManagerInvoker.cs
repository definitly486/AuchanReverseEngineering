using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Security.Cert;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/X509TrustManager", DoNotGenerateAcw = true)]
internal class IX509TrustManagerInvoker : Java.Lang.Object, IX509TrustManager, ITrustManager, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_javax_net_ssl_TrustManager = new XAPeerMembers("javax/net/ssl/TrustManager", typeof(IX509TrustManagerInvoker));

	private static readonly JniPeerMembers _members_javax_net_ssl_X509TrustManager = new XAPeerMembers("javax/net/ssl/X509TrustManager", typeof(IX509TrustManagerInvoker));

	private static Delegate? cb_checkClientTrusted_CheckClientTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String__V;

	private static Delegate? cb_checkServerTrusted_CheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String__V;

	private static Delegate? cb_getAcceptedIssuers_GetAcceptedIssuers_arrayLjava_security_cert_X509Certificate_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_javax_net_ssl_X509TrustManager;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_javax_net_ssl_X509TrustManager.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_javax_net_ssl_X509TrustManager.ManagedPeerType;

	public IX509TrustManagerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
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
			IX509TrustManager? iX509TrustManager = Java.Lang.Object.GetObject<IX509TrustManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			X509Certificate[] array = (X509Certificate[])JNIEnv.GetArray(native_chain, JniHandleOwnership.DoNotTransfer, typeof(X509Certificate));
			string authType = JNIEnv.GetString(native_authType, JniHandleOwnership.DoNotTransfer);
			iX509TrustManager.CheckClientTrusted(array, authType);
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

	public unsafe void CheckClientTrusted(X509Certificate[]? chain, string? authType)
	{
		nint num = JNIEnv.NewArray(chain);
		nint num2 = JNIEnv.NewString(authType);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members_javax_net_ssl_X509TrustManager.InstanceMethods.InvokeAbstractVoidMethod("checkClientTrusted.([Ljava/security/cert/X509Certificate;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			if (chain != null)
			{
				JNIEnv.CopyArray(num, chain);
				JNIEnv.DeleteLocalRef(num);
			}
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(chain);
		}
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
			IX509TrustManager? iX509TrustManager = Java.Lang.Object.GetObject<IX509TrustManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			X509Certificate[] array = (X509Certificate[])JNIEnv.GetArray(native_chain, JniHandleOwnership.DoNotTransfer, typeof(X509Certificate));
			string authType = JNIEnv.GetString(native_authType, JniHandleOwnership.DoNotTransfer);
			iX509TrustManager.CheckServerTrusted(array, authType);
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

	public unsafe void CheckServerTrusted(X509Certificate[]? chain, string? authType)
	{
		nint num = JNIEnv.NewArray(chain);
		nint num2 = JNIEnv.NewString(authType);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members_javax_net_ssl_X509TrustManager.InstanceMethods.InvokeAbstractVoidMethod("checkServerTrusted.([Ljava/security/cert/X509Certificate;Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			if (chain != null)
			{
				JNIEnv.CopyArray(num, chain);
				JNIEnv.DeleteLocalRef(num);
			}
			JNIEnv.DeleteLocalRef(num2);
			GC.KeepAlive(chain);
		}
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
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IX509TrustManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetAcceptedIssuers());
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

	public unsafe X509Certificate[]? GetAcceptedIssuers()
	{
		return (X509Certificate[])JNIEnv.GetArray(_members_javax_net_ssl_X509TrustManager.InstanceMethods.InvokeAbstractObjectMethod("getAcceptedIssuers.()[Ljava/security/cert/X509Certificate;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(X509Certificate));
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

	[UnmanagedCallersOnly]
	private static void n_CheckClientTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_chain, nint native_authType)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_CheckClientTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_(jnienv, native__this, native_chain, native_authType);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_CheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_chain, nint native_authType)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_CheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_(jnienv, native__this, native_chain, native_authType);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetAcceptedIssuers_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetAcceptedIssuers(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}
}
