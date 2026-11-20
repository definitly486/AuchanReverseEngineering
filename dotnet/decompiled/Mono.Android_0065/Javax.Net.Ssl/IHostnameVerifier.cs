using System;
using Android.Runtime;
using Java.Interop;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/HostnameVerifier", "", "Javax.Net.Ssl.IHostnameVerifierInvoker")]
public interface IHostnameVerifier : IJavaObject, IDisposable, IJavaPeerable
{
	bool Verify(string? hostname, ISSLSession? session);
}
