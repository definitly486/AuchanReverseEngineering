using System;
using Android.Runtime;
using Java.Interop;
using Java.Security.Cert;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/X509TrustManager", "", "Javax.Net.Ssl.IX509TrustManagerInvoker")]
public interface IX509TrustManager : ITrustManager, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("checkClientTrusted", "([Ljava/security/cert/X509Certificate;Ljava/lang/String;)V", "GetCheckClientTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Handler:Javax.Net.Ssl.IX509TrustManagerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void CheckClientTrusted(X509Certificate[]? chain, string? authType);

	[Register("checkServerTrusted", "([Ljava/security/cert/X509Certificate;Ljava/lang/String;)V", "GetCheckServerTrusted_arrayLjava_security_cert_X509Certificate_Ljava_lang_String_Handler:Javax.Net.Ssl.IX509TrustManagerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void CheckServerTrusted(X509Certificate[]? chain, string? authType);

	[Register("getAcceptedIssuers", "()[Ljava/security/cert/X509Certificate;", "GetGetAcceptedIssuersHandler:Javax.Net.Ssl.IX509TrustManagerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	X509Certificate[]? GetAcceptedIssuers();
}
