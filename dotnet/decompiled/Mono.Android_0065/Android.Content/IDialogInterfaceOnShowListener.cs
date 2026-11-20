using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/DialogInterface$OnShowListener", "", "Android.Content.IDialogInterfaceOnShowListenerInvoker")]
public interface IDialogInterfaceOnShowListener : IJavaObject, IDisposable, IJavaPeerable
{
	void OnShow(IDialogInterface? dialog);
}
