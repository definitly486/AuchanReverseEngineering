using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Security;
using Java.Security.Cert;
using Javax.Security.Cert;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/SSLSession", DoNotGenerateAcw = true)]
internal class ISSLSessionInvoker : Java.Lang.Object, ISSLSession, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members_javax_net_ssl_SSLSession = new XAPeerMembers("javax/net/ssl/SSLSession", typeof(ISSLSessionInvoker));

	private static Delegate? cb_getApplicationBufferSize_GetApplicationBufferSize_I;

	private static Delegate? cb_getCipherSuite_GetCipherSuite_Ljava_lang_String_;

	private static Delegate? cb_getCreationTime_GetCreationTime_J;

	private static Delegate? cb_isValid_IsValid_Z;

	private static Delegate? cb_getLastAccessedTime_GetLastAccessedTime_J;

	private static Delegate? cb_getLocalPrincipal_GetLocalPrincipal_Ljava_security_Principal_;

	private static Delegate? cb_getPacketBufferSize_GetPacketBufferSize_I;

	private static Delegate? cb_getPeerHost_GetPeerHost_Ljava_lang_String_;

	private static Delegate? cb_getPeerPort_GetPeerPort_I;

	private static Delegate? cb_getPeerPrincipal_GetPeerPrincipal_Ljava_security_Principal_;

	private static Delegate? cb_getProtocol_GetProtocol_Ljava_lang_String_;

	private static Delegate? cb_getSessionContext_GetSessionContext_Ljavax_net_ssl_SSLSessionContext_;

	private static Delegate? cb_getId_GetId_arrayB;

	private static Delegate? cb_getLocalCertificates_GetLocalCertificates_arrayLjava_security_cert_Certificate_;

	private static Delegate? cb_getPeerCertificateChain_GetPeerCertificateChain_arrayLjavax_security_cert_X509Certificate_;

	private static Delegate? cb_getPeerCertificates_GetPeerCertificates_arrayLjava_security_cert_Certificate_;

	private static Delegate? cb_getValue_GetValue_Ljava_lang_String__Ljava_lang_Object_;

	private static Delegate? cb_getValueNames_GetValueNames_arrayLjava_lang_String_;

	private static Delegate? cb_invalidate_Invalidate_V;

	private static Delegate? cb_putValue_PutValue_Ljava_lang_String_Ljava_lang_Object__V;

	private static Delegate? cb_removeValue_RemoveValue_Ljava_lang_String__V;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members_javax_net_ssl_SSLSession;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override nint ThresholdClass => _members_javax_net_ssl_SSLSession.JniPeerType.PeerReference.Handle;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members_javax_net_ssl_SSLSession.ManagedPeerType;

	public unsafe int ApplicationBufferSize => _members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractInt32Method("getApplicationBufferSize.()I", this, null);

	public unsafe string? CipherSuite => JNIEnv.GetString(_members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractObjectMethod("getCipherSuite.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe long CreationTime => _members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractInt64Method("getCreationTime.()J", this, null);

	public unsafe bool IsValid => _members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractBooleanMethod("isValid.()Z", this, null);

	public unsafe long LastAccessedTime => _members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractInt64Method("getLastAccessedTime.()J", this, null);

	public unsafe IPrincipal? LocalPrincipal => Java.Lang.Object.GetObject<IPrincipal>(_members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractObjectMethod("getLocalPrincipal.()Ljava/security/Principal;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe int PacketBufferSize => _members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractInt32Method("getPacketBufferSize.()I", this, null);

	public unsafe string? PeerHost => JNIEnv.GetString(_members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractObjectMethod("getPeerHost.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe int PeerPort => _members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractInt32Method("getPeerPort.()I", this, null);

	public unsafe IPrincipal? PeerPrincipal => Java.Lang.Object.GetObject<IPrincipal>(_members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractObjectMethod("getPeerPrincipal.()Ljava/security/Principal;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe string? Protocol => JNIEnv.GetString(_members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractObjectMethod("getProtocol.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public unsafe ISSLSessionContext? SessionContext => Java.Lang.Object.GetObject<ISSLSessionContext>(_members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractObjectMethod("getSessionContext.()Ljavax/net/ssl/SSLSessionContext;", this, null).Handle, JniHandleOwnership.TransferLocalRef);

	public ISSLSessionInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetApplicationBufferSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ApplicationBufferSize;
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

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetCipherSuite(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CipherSuite);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetCreationTime(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreationTime;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static sbyte n_IsValid(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsValid ? ((sbyte)1) : ((sbyte)0);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static long n_GetLastAccessedTime(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0L;
		}
		try
		{
			return Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LastAccessedTime;
		}
		catch (System.Exception e)
		{
			runtime.OnUserUnhandledException(ref transition, e);
			return 0L;
		}
		finally
		{
			JniEnvironment.EndMarshalMethod(ref transition);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLocalPrincipal(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LocalPrincipal);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetPacketBufferSize(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PacketBufferSize;
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

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPeerHost(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PeerHost);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static int n_GetPeerPort(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PeerPort;
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

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPeerPrincipal(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PeerPrincipal);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetProtocol(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Protocol);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetSessionContext(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SessionContext);
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

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetId(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetId());
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

	public unsafe byte[]? GetId()
	{
		return (byte[])JNIEnv.GetArray(_members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractObjectMethod("getId.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetLocalCertificates(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetLocalCertificates());
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

	public unsafe Java.Security.Cert.Certificate[]? GetLocalCertificates()
	{
		return (Java.Security.Cert.Certificate[])JNIEnv.GetArray(_members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractObjectMethod("getLocalCertificates.()[Ljava/security/cert/Certificate;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Security.Cert.Certificate));
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPeerCertificateChain(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetPeerCertificateChain());
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

	public unsafe Javax.Security.Cert.X509Certificate[]? GetPeerCertificateChain()
	{
		return (Javax.Security.Cert.X509Certificate[])JNIEnv.GetArray(_members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractObjectMethod("getPeerCertificateChain.()[Ljavax/security/cert/X509Certificate;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Javax.Security.Cert.X509Certificate));
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetPeerCertificates(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetPeerCertificates());
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

	public unsafe Java.Security.Cert.Certificate[]? GetPeerCertificates()
	{
		return (Java.Security.Cert.Certificate[])JNIEnv.GetArray(_members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractObjectMethod("getPeerCertificates.()[Ljava/security/cert/Certificate;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Security.Cert.Certificate));
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetValue_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			ISSLSession? iSSLSession = Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(iSSLSession.GetValue(name));
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

	public unsafe Java.Lang.Object? GetValue(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractObjectMethod("getValue.(Ljava/lang/String;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static nint n_GetValueNames(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return 0;
		}
		try
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetValueNames());
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

	public unsafe string[]? GetValueNames()
	{
		return (string[])JNIEnv.GetArray(_members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractObjectMethod("getValueNames.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_Invalidate(nint jnienv, nint native__this)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Invalidate();
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

	public unsafe void Invalidate()
	{
		_members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractVoidMethod("invalidate.()V", this, null);
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_PutValue_Ljava_lang_String_Ljava_lang_Object_(nint jnienv, nint native__this, nint native_name, nint native_value)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ISSLSession? iSSLSession = Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			iSSLSession.PutValue(name, value);
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

	public unsafe void PutValue(string? name, Java.Lang.Object? value)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			_members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractVoidMethod("putValue.(Ljava/lang/String;Ljava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
			GC.KeepAlive(value);
		}
	}

	[DebuggerDisableUserUnhandledExceptions]
	private static void n_RemoveValue_Ljava_lang_String_(nint jnienv, nint native__this, nint native_name)
	{
		if (!JniEnvironment.BeginMarshalMethod(jnienv, out JniTransition transition, out JniRuntime runtime))
		{
			return;
		}
		try
		{
			ISSLSession? iSSLSession = Java.Lang.Object.GetObject<ISSLSession>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			iSSLSession.RemoveValue(name);
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

	public unsafe void RemoveValue(string? name)
	{
		nint num = JNIEnv.NewString(name);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(num);
			_members_javax_net_ssl_SSLSession.InstanceMethods.InvokeAbstractVoidMethod("removeValue.(Ljava/lang/String;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(num);
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

	[UnmanagedCallersOnly]
	private static int n_GetApplicationBufferSize_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetApplicationBufferSize(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetCipherSuite_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetCipherSuite(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static long n_GetCreationTime_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetCreationTime(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0L;
		}
	}

	[UnmanagedCallersOnly]
	private static sbyte n_IsValid_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_IsValid(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static long n_GetLastAccessedTime_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetLastAccessedTime(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0L;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetLocalPrincipal_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetLocalPrincipal(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetPacketBufferSize_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetPacketBufferSize(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetPeerHost_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetPeerHost(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static int n_GetPeerPort_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetPeerPort(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetPeerPrincipal_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetPeerPrincipal(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetProtocol_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetProtocol(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetSessionContext_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetSessionContext(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetId_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetId(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetLocalCertificates_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetLocalCertificates(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetPeerCertificateChain_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetPeerCertificateChain(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetPeerCertificates_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetPeerCertificates(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetValue_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_name)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetValue_Ljava_lang_String_(jnienv, native__this, native_name);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static nint n_GetValueNames_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			return n_GetValueNames(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
			return 0;
		}
	}

	[UnmanagedCallersOnly]
	private static void n_Invalidate_mm_wrapper(nint jnienv, nint native__this)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_Invalidate(jnienv, native__this);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_PutValue_Ljava_lang_String_Ljava_lang_Object__mm_wrapper(nint jnienv, nint native__this, nint native_name, nint native_value)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_PutValue_Ljava_lang_String_Ljava_lang_Object_(jnienv, native__this, native_name, native_value);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}

	[UnmanagedCallersOnly]
	private static void n_RemoveValue_Ljava_lang_String__mm_wrapper(nint jnienv, nint native__this, nint native_name)
	{
		AndroidRuntimeInternal.WaitForBridgeProcessing();
		try
		{
			n_RemoveValue_Ljava_lang_String_(jnienv, native__this, native_name);
		}
		catch (System.Exception e)
		{
			AndroidEnvironmentInternal.UnhandledException(e);
		}
	}
}
