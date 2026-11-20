using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Security;
using Java.Security.Cert;
using Javax.Security.Cert;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/SSLSession", "", "Javax.Net.Ssl.ISSLSessionInvoker")]
public interface ISSLSession : IJavaObject, IDisposable, IJavaPeerable
{
	int ApplicationBufferSize
	{
		[Register("getApplicationBufferSize", "()I", "GetGetApplicationBufferSizeHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	string? CipherSuite
	{
		[Register("getCipherSuite", "()Ljava/lang/String;", "GetGetCipherSuiteHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	long CreationTime
	{
		[Register("getCreationTime", "()J", "GetGetCreationTimeHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	bool IsValid
	{
		[Register("isValid", "()Z", "GetIsValidHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	long LastAccessedTime
	{
		[Register("getLastAccessedTime", "()J", "GetGetLastAccessedTimeHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	IPrincipal? LocalPrincipal
	{
		[Register("getLocalPrincipal", "()Ljava/security/Principal;", "GetGetLocalPrincipalHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	int PacketBufferSize
	{
		[Register("getPacketBufferSize", "()I", "GetGetPacketBufferSizeHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	string? PeerHost
	{
		[Register("getPeerHost", "()Ljava/lang/String;", "GetGetPeerHostHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	int PeerPort
	{
		[Register("getPeerPort", "()I", "GetGetPeerPortHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	IPrincipal? PeerPrincipal
	{
		[Register("getPeerPrincipal", "()Ljava/security/Principal;", "GetGetPeerPrincipalHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	string? Protocol
	{
		[Register("getProtocol", "()Ljava/lang/String;", "GetGetProtocolHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	ISSLSessionContext? SessionContext
	{
		[Register("getSessionContext", "()Ljavax/net/ssl/SSLSessionContext;", "GetGetSessionContextHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	[Register("getId", "()[B", "GetGetIdHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	byte[]? GetId();

	[Register("getLocalCertificates", "()[Ljava/security/cert/Certificate;", "GetGetLocalCertificatesHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Java.Security.Cert.Certificate[]? GetLocalCertificates();

	[Register("getPeerCertificateChain", "()[Ljavax/security/cert/X509Certificate;", "GetGetPeerCertificateChainHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Javax.Security.Cert.X509Certificate[]? GetPeerCertificateChain();

	[Register("getPeerCertificates", "()[Ljava/security/cert/Certificate;", "GetGetPeerCertificatesHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Java.Security.Cert.Certificate[]? GetPeerCertificates();

	[Register("getValue", "(Ljava/lang/String;)Ljava/lang/Object;", "GetGetValue_Ljava_lang_String_Handler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Java.Lang.Object? GetValue(string? name);

	[Register("getValueNames", "()[Ljava/lang/String;", "GetGetValueNamesHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	string[]? GetValueNames();

	[Register("invalidate", "()V", "GetInvalidateHandler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Invalidate();

	[Register("putValue", "(Ljava/lang/String;Ljava/lang/Object;)V", "GetPutValue_Ljava_lang_String_Ljava_lang_Object_Handler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void PutValue(string? name, Java.Lang.Object? value);

	[Register("removeValue", "(Ljava/lang/String;)V", "GetRemoveValue_Ljava_lang_String_Handler:Javax.Net.Ssl.ISSLSessionInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void RemoveValue(string? name);
}
