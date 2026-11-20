using System;
using Android.Runtime;
using Java.Interop;

namespace Android.OS;

[Register("android/os/IInterface", "", "Android.OS.IInterfaceInvoker")]
public interface IInterface : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("asBinder", "()Landroid/os/IBinder;", "GetAsBinderHandler:Android.OS.IInterfaceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	IBinder? AsBinder();
}
