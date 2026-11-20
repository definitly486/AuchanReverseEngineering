using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Data;

[Register("com/bumptech/glide/load/data/DataRewinder", "", "Bumptech.Glide.Load.Data.IDataRewinderInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IDataRewinder : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("cleanup", "()V", "GetCleanupHandler:Bumptech.Glide.Load.Data.IDataRewinderInvoker, Xamarin.Android.Glide")]
	void Cleanup();

	[Register("rewindAndGet", "()Ljava/lang/Object;", "GetRewindAndGetHandler:Bumptech.Glide.Load.Data.IDataRewinderInvoker, Xamarin.Android.Glide")]
	Java.Lang.Object RewindAndGet();
}
