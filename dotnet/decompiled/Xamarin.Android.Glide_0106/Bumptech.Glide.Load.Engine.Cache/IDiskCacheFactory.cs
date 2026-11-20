using System;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide.Load.Engine.Cache;

[Register("com/bumptech/glide/load/engine/cache/DiskCache$Factory", "", "Bumptech.Glide.Load.Engine.Cache.IDiskCacheFactoryInvoker")]
public interface IDiskCacheFactory : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("build", "()Lcom/bumptech/glide/load/engine/cache/DiskCache;", "GetBuildHandler:Bumptech.Glide.Load.Engine.Cache.IDiskCacheFactoryInvoker, Xamarin.Android.Glide")]
	IDiskCache? Build();
}
