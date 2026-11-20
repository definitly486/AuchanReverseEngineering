using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/DialogInterface$OnCancelListener", "", "Android.Content.IDialogInterfaceOnCancelListenerInvoker")]
public interface IDialogInterfaceOnCancelListener : IJavaObject, IDisposable, IJavaPeerable
{
	void OnCancel(IDialogInterface? dialog);
}
