using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/DialogInterface$OnMultiChoiceClickListener", "", "Android.Content.IDialogInterfaceOnMultiChoiceClickListenerInvoker")]
public interface IDialogInterfaceOnMultiChoiceClickListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onClick", "(Landroid/content/DialogInterface;IZ)V", "GetOnClick_Landroid_content_DialogInterface_IZHandler:Android.Content.IDialogInterfaceOnMultiChoiceClickListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void OnClick(IDialogInterface? dialog, int which, bool isChecked);
}
