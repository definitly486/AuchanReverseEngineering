using System;
using Android.Runtime;
using Java.Interop;

namespace Javax.Net.Ssl;

[Register("javax/net/ssl/KeyManager", "", "Javax.Net.Ssl.IKeyManagerInvoker")]
public interface IKeyManager : IJavaObject, IDisposable, IJavaPeerable
{
}
