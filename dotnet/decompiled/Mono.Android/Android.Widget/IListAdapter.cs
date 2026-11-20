using System;
using Android.Runtime;
using Java.Interop;

namespace Android.Widget;

[Register("android/widget/ListAdapter", "", "Android.Widget.IListAdapterInvoker")]
public interface IListAdapter : IAdapter, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("areAllItemsEnabled", "()Z", "GetAreAllItemsEnabledHandler:Android.Widget.IListAdapterInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool AreAllItemsEnabled();

	[Register("isEnabled", "(I)Z", "GetIsEnabled_IHandler:Android.Widget.IListAdapterInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	bool IsEnabled(int position);
}
