using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Versioning;
using Android.Runtime;
using Java.Interop;
using Java.Net;
using Java.Security.Cert;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/X509ExtendedTrustManager", DoNotGenerateAcw = true, ApiSince = 24)]
[SupportedOSPlatform("android24.0")]
internal class X509ExtendedTrustManagerInvoker : X509ExtendedTrustManager
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("javax/net/ssl/X509ExtendedTrustManager", typeof(X509ExtendedTrustManagerInvoker));

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override JniPeerMembers JniPeerMembers => _members;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	protected override Type ThresholdType => _members.ManagedPeerType;

	public X509ExtendedTrustManagerInvoker(nint handle, JniHandleOwnership transfer)
		: base(handle, transfer)
	{
	}

	[SupportedOSPlatform("android24.0")]
	[Register("checkServerTrusted", "([Ljava/security/cert/X509Certificate;Ljava/lang/String;Ljava/net/Socket;)V", "GetCheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Ljava_net_Socket_Handler", ApiSince = 24)]
	public unsafe override void CheckServerTrusted(X509Certificate[]? chain, string? authType, Socket? socket)
	{
		nint num = JNIEnv.NewArray(chain);
		nint num2 = JNIEnv.NewString(authType);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(socket?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("checkServerTrusted.([Ljava/security/cert/X509Certificate;Ljava/lang/String;Ljava/net/Socket;)V", this, ptr);
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
			GC.KeepAlive(socket);
		}
	}

	[SupportedOSPlatform("android24.0")]
	[Register("checkServerTrusted", "([Ljava/security/cert/X509Certificate;Ljava/lang/String;Ljavax/net/ssl/SSLEngine;)V", "GetCheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Ljavax_net_ssl_SSLEngine_Handler", ApiSince = 24)]
	public unsafe override void CheckServerTrusted(X509Certificate[]? chain, string? authType, SSLEngine? engine)
	{
		nint num = JNIEnv.NewArray(chain);
		nint num2 = JNIEnv.NewString(authType);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			ptr[2] = new JniArgumentValue(engine?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("checkServerTrusted.([Ljava/security/cert/X509Certificate;Ljava/lang/String;Ljavax/net/ssl/SSLEngine;)V", this, ptr);
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
			GC.KeepAlive(engine);
		}
	}

	[Register("checkClientTrusted", "([Ljava/security/cert/X509Certificate;Ljava/lang/String;)V", "GetCheckClientTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Handler")]
	public unsafe override void CheckClientTrusted(X509Certificate[]? chain, string? authType)
	{
		nint num = JNIEnv.NewArray(chain);
		nint num2 = JNIEnv.NewString(authType);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeAbstractVoidMethod("checkClientTrusted.([Ljava/security/cert/X509Certificate;Ljava/lang/String;)V", this, ptr);
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

	[Register("checkServerTrusted", "([Ljava/security/cert/X509Certificate;Ljava/lang/String;)V", "GetCheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Handler")]
	public unsafe override void CheckServerTrusted(X509Certificate[]? chain, string? authType)
	{
		nint num = JNIEnv.NewArray(chain);
		nint num2 = JNIEnv.NewString(authType);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(num);
			ptr[1] = new JniArgumentValue(num2);
			_members.InstanceMethods.InvokeAbstractVoidMethod("checkServerTrusted.([Ljava/security/cert/X509Certificate;Ljava/lang/String;)V", this, ptr);
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

	[Register("getAcceptedIssuers", "()[Ljava/security/cert/X509Certificate;", "GetGetAcceptedIssuersHandler")]
	public unsafe override X509Certificate[]? GetAcceptedIssuers()
	{
		return (X509Certificate[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getAcceptedIssuers.()[Ljava/security/cert/X509Certificate;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(X509Certificate));
	}
}
