using System;
using Android.Runtime;
using Java.Interop;

namespace Android.OS;

[Register("android/os/Parcelable", "", "Android.OS.IParcelableInvoker")]
public interface IParcelable : IJavaObject, IDisposable, IJavaPeerable
{
	int DescribeContents();

	void WriteToParcel(Parcel dest, ParcelableWriteFlags flags);
}
