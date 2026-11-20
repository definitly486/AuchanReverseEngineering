using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Content;

[Register("android/content/DialogInterface", "", "Android.Content.IDialogInterfaceInvoker")]
public interface IDialogInterface : IJavaObject, IDisposable, IJavaPeerable
{
	void Cancel();

	void Dismiss();
}
