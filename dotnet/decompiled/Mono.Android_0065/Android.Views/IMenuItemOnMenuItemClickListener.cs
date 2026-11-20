using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/MenuItem$OnMenuItemClickListener", "", "Android.Views.IMenuItemOnMenuItemClickListenerInvoker")]
public interface IMenuItemOnMenuItemClickListener : IJavaObject, IDisposable, IJavaPeerable
{
	bool OnMenuItemClick(IMenuItem item);
}
