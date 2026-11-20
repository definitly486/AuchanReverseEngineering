using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Android.OS;

[Register("android/os/Parcelable$Creator", "", "Android.OS.IParcelableCreatorInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IParcelableCreator : IJavaObject, IDisposable, IJavaPeerable
{
	Java.Lang.Object? CreateFromParcel(Parcel? source);

	Java.Lang.Object[]? NewArray(int size);
}
