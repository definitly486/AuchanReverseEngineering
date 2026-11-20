using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace Android.Content;

[Register("android/content/DialogInterface$OnKeyListener", "", "Android.Content.IDialogInterfaceOnKeyListenerInvoker")]
public interface IDialogInterfaceOnKeyListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onKey", "(Landroid/content/DialogInterface;ILandroid/view/KeyEvent;)Z", "GetOnKey_Landroid_content_DialogInterface_ILandroid_view_KeyEvent_Handler:Android.Content.IDialogInterfaceOnKeyListenerInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool OnKey(IDialogInterface? dialog, Keycode keyCode, KeyEvent? e);
}
