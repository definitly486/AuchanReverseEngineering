using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/MenuItem$OnActionExpandListener", "", "Android.Views.IMenuItemOnActionExpandListenerInvoker")]
public interface IMenuItemOnActionExpandListener : IJavaObject, IDisposable, IJavaPeerable
{
	bool OnMenuItemActionCollapse(IMenuItem item);

	bool OnMenuItemActionExpand(IMenuItem item);
}
