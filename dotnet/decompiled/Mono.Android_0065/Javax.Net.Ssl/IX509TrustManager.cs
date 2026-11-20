using System;
using Android.Runtime;
using Java.Interop;
using Java.Security.Cert;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/X509TrustManager", "", "Javax.Net.Ssl.IX509TrustManagerInvoker")]
public interface IX509TrustManager : ITrustManager, IJavaObject, IDisposable, IJavaPeerable
{
	void CheckClientTrusted(X509Certificate[]? chain, string? authType);

	void CheckServerTrusted(X509Certificate[]? chain, string? authType);

	X509Certificate[]? GetAcceptedIssuers();
}
