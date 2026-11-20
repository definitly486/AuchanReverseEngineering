using System;
using Android.Runtime;
using Java.Interop;

namespace Android.OS;

[Register("android/os/Parcelable", "", "Android.OS.IParcelableInvoker")]
public interface IParcelable : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("describeContents", "()I", "GetDescribeContentsHandler:Android.OS.IParcelableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	int DescribeContents();

	[Register("writeToParcel", "(Landroid/os/Parcel;I)V", "GetWriteToParcel_Landroid_os_Parcel_IHandler:Android.OS.IParcelableInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void WriteToParcel(Parcel dest, ParcelableWriteFlags flags);
}
