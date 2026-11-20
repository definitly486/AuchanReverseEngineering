using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/DialogInterface$OnMultiChoiceClickListener", "", "Android.Content.IDialogInterfaceOnMultiChoiceClickListenerInvoker")]
public interface IDialogInterfaceOnMultiChoiceClickListener : IJavaObject, IDisposable, IJavaPeerable
{
	void OnClick(IDialogInterface? dialog, int which, bool isChecked);
}
