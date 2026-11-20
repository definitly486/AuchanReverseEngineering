using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/DialogInterface", "", "Android.Content.IDialogInterfaceInvoker")]
public interface IDialogInterface : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("cancel", "()V", "GetCancelHandler:Android.Content.IDialogInterfaceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Cancel();

	[Register("dismiss", "()V", "GetDismissHandler:Android.Content.IDialogInterfaceInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void Dismiss();
}
