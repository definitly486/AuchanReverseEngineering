using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/DialogInterface$OnDismissListener", "", "Android.Content.IDialogInterfaceOnDismissListenerInvoker")]
public interface IDialogInterfaceOnDismissListener : IJavaObject, IDisposable, IJavaPeerable
{
	void OnDismiss(IDialogInterface? dialog);
}
