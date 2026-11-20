using System;
using Android.Runtime;
using Java.Interop;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/TrustManager", "", "Javax.Net.Ssl.ITrustManagerInvoker")]
public interface ITrustManager : IJavaObject, IDisposable, IJavaPeerable
{
}
