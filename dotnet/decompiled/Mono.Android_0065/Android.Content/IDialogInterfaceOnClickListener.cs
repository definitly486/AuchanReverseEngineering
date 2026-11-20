using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/DialogInterface$OnClickListener", "", "Android.Content.IDialogInterfaceOnClickListenerInvoker")]
public interface IDialogInterfaceOnClickListener : IJavaObject, IDisposable, IJavaPeerable
{
	void OnClick(IDialogInterface? dialog, int which);
}
