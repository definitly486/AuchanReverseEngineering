using System;
using Android.Runtime;
using Android.Views;
using Java.Interop;

namespace Android.Widget;

[Register("android/widget/SpinnerAdapter", "", "Android.Widget.ISpinnerAdapterInvoker")]
public interface ISpinnerAdapter : IAdapter, IJavaObject, IDisposable, IJavaPeerable
{
	View? GetDropDownView(int position, View? convertView, ViewGroup? parent);
}
