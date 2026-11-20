using System;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide.Load.Model;

[Register("com/bumptech/glide/load/model/LazyHeaderFactory", "", "Bumptech.Glide.Load.Model.ILazyHeaderFactoryInvoker")]
public interface ILazyHeaderFactory : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("buildHeader", "()Ljava/lang/String;", "GetBuildHeaderHandler:Bumptech.Glide.Load.Model.ILazyHeaderFactoryInvoker, Xamarin.Android.Glide")]
	string? BuildHeader();
}
