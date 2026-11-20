using System;
using Android.Runtime;
using Java.Interop;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/HostnameVerifier", "", "Javax.Net.Ssl.IHostnameVerifierInvoker")]
public interface IHostnameVerifier : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("verify", "(Ljava/lang/String;Ljavax/net/ssl/SSLSession;)Z", "GetVerify_Ljava_lang_String_Ljavax_net_ssl_SSLSession_Handler:Javax.Net.Ssl.IHostnameVerifierInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool Verify(string? hostname, ISSLSession? session);
}
