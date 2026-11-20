using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Widget;

[Register("android/widget/ListAdapter", "", "Android.Widget.IListAdapterInvoker")]
public interface IListAdapter : IAdapter, IJavaObject, IDisposable, IJavaPeerable
{
	bool AreAllItemsEnabled();

	bool IsEnabled(int position);
}
