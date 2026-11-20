using System;
using Android.Runtime;
using Java.Interop;
using Java.Util;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/SSLSessionContext", "", "Javax.Net.Ssl.ISSLSessionContextInvoker")]
public interface ISSLSessionContext : IJavaObject, IDisposable, IJavaPeerable
{
	IEnumeration? Ids { get; }

	int SessionCacheSize { get; set; }

	int SessionTimeout { get; set; }

	ISSLSession? GetSession(byte[]? sessionId);
}
