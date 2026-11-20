using System;
using Android.Runtime;
using Java.Interop;
using Java.Util;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/SSLSessionContext", "", "Javax.Net.Ssl.ISSLSessionContextInvoker")]
public interface ISSLSessionContext : IJavaObject, IDisposable, IJavaPeerable
{
	IEnumeration? Ids
	{
		[Register("getIds", "()Ljava/util/Enumeration;", "GetGetIdsHandler:Javax.Net.Ssl.ISSLSessionContextInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
	}

	int SessionCacheSize
	{
		[Register("getSessionCacheSize", "()I", "GetGetSessionCacheSizeHandler:Javax.Net.Ssl.ISSLSessionContextInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
		[Register("setSessionCacheSize", "(I)V", "GetSetSessionCacheSize_IHandler:Javax.Net.Ssl.ISSLSessionContextInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		set;
	}

	int SessionTimeout
	{
		[Register("getSessionTimeout", "()I", "GetGetSessionTimeoutHandler:Javax.Net.Ssl.ISSLSessionContextInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		get;
		[Register("setSessionTimeout", "(I)V", "GetSetSessionTimeout_IHandler:Javax.Net.Ssl.ISSLSessionContextInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
		set;
	}

	[Register("getSession", "([B)Ljavax/net/ssl/SSLSession;", "GetGetSession_arrayBHandler:Javax.Net.Ssl.ISSLSessionContextInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	ISSLSession? GetSession(byte[]? sessionId);
}
