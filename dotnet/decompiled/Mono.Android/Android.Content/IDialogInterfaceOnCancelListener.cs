using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/DialogInterface$OnCancelListener", "", "Android.Content.IDialogInterfaceOnCancelListenerInvoker")]
public interface IDialogInterfaceOnCancelListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onCancel", "(Landroid/content/DialogInterface;)V", "GetOnCancel_Landroid_content_DialogInterface_Handler:Android.Content.IDialogInterfaceOnCancelListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void OnCancel(IDialogInterface? dialog);
}
