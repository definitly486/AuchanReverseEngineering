using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/DialogInterface$OnShowListener", "", "Android.Content.IDialogInterfaceOnShowListenerInvoker")]
public interface IDialogInterfaceOnShowListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onShow", "(Landroid/content/DialogInterface;)V", "GetOnShow_Landroid_content_DialogInterface_Handler:Android.Content.IDialogInterfaceOnShowListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void OnShow(IDialogInterface? dialog);
}
