using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/DialogInterface$OnClickListener", "", "Android.Content.IDialogInterfaceOnClickListenerInvoker")]
public interface IDialogInterfaceOnClickListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onClick", "(Landroid/content/DialogInterface;I)V", "GetOnClick_Landroid_content_DialogInterface_IHandler:Android.Content.IDialogInterfaceOnClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void OnClick(IDialogInterface? dialog, int which);
}
