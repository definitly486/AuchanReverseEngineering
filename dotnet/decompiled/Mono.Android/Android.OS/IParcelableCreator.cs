using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.OS;

[Register("android/os/Parcelable$Creator", "", "Android.OS.IParcelableCreatorInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IParcelableCreator : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("createFromParcel", "(Landroid/os/Parcel;)Ljava/lang/Object;", "GetCreateFromParcel_Landroid_os_Parcel_Handler:Android.OS.IParcelableCreatorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Java.Lang.Object? CreateFromParcel(Parcel? source);

	[Register("newArray", "(I)[Ljava/lang/Object;", "GetNewArray_IHandler:Android.OS.IParcelableCreatorInvoker, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	Java.Lang.Object[]? NewArray(int size);
}
