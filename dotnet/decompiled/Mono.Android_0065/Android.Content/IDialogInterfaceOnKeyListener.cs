using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace Android.Content;

[Register("android/content/DialogInterface$OnKeyListener", "", "Android.Content.IDialogInterfaceOnKeyListenerInvoker")]
public interface IDialogInterfaceOnKeyListener : IJavaObject, IDisposable, IJavaPeerable
{
	bool OnKey(IDialogInterface? dialog, Keycode keyCode, KeyEvent? e);
}
