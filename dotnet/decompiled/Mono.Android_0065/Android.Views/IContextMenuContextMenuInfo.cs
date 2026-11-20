using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Views;

[Register("android/view/ContextMenu$ContextMenuInfo", "", "Android.Views.IContextMenuContextMenuInfoInvoker")]
public interface IContextMenuContextMenuInfo : IJavaObject, IDisposable, IJavaPeerable
{
}
