using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/DialogInterface$OnDismissListener", "", "Android.Content.IDialogInterfaceOnDismissListenerInvoker")]
public interface IDialogInterfaceOnDismissListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onDismiss", "(Landroid/content/DialogInterface;)V", "GetOnDismiss_Landroid_content_DialogInterface_Handler:Android.Content.IDialogInterfaceOnDismissListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void OnDismiss(IDialogInterface? dialog);
}
