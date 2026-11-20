using System;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide.Manager;

[Register("com/bumptech/glide/manager/ConnectivityMonitor", "", "Bumptech.Glide.Manager.IConnectivityMonitorInvoker")]
public interface IConnectivityMonitor : ILifecycleListener, IJavaObject, IDisposable, IJavaPeerable
{
}
