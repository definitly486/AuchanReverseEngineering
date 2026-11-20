using System;
using Android.Runtime;
using Java.Interop;

namespace Android.OS;

[Register("android/os/IInterface", "", "Android.OS.IInterfaceInvoker")]
public interface IInterface : IJavaObject, IDisposable, IJavaPeerable
{
	IBinder? AsBinder();
}
