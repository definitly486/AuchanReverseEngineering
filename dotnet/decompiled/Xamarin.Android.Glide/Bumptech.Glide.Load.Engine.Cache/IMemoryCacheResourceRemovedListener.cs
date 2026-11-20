using System;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide.Load.Engine.Cache;

[Register("com/bumptech/glide/load/engine/cache/MemoryCache$ResourceRemovedListener", "", "Bumptech.Glide.Load.Engine.Cache.IMemoryCacheResourceRemovedListenerInvoker")]
public interface IMemoryCacheResourceRemovedListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onResourceRemoved", "(Lcom/bumptech/glide/load/engine/Resource;)V", "GetOnResourceRemoved_Lcom_bumptech_glide_load_engine_Resource_Handler:Bumptech.Glide.Load.Engine.Cache.IMemoryCacheResourceRemovedListenerInvoker, Xamarin.Android.Glide")]
	void OnResourceRemoved(IResource p0);
}
