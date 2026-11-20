using System;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide.Manager;

[Register("com/bumptech/glide/manager/ConnectivityMonitor$ConnectivityListener", "", "Bumptech.Glide.Manager.IConnectivityMonitorConnectivityListenerInvoker")]
public interface IConnectivityMonitorConnectivityListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onConnectivityChanged", "(Z)V", "GetOnConnectivityChanged_ZHandler:Bumptech.Glide.Manager.IConnectivityMonitorConnectivityListenerInvoker, Xamarin.Android.Glide")]
	void OnConnectivityChanged(bool p0);
}
