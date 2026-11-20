using System;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide.Load.Engine.Cache;

[Register("com/bumptech/glide/load/engine/cache/MemoryCache", "", "Bumptech.Glide.Load.Engine.Cache.IMemoryCacheInvoker")]
public interface IMemoryCache : IJavaObject, IDisposable, IJavaPeerable
{
	long CurrentSize
	{
		[Register("getCurrentSize", "()J", "GetGetCurrentSizeHandler:Bumptech.Glide.Load.Engine.Cache.IMemoryCacheInvoker, Xamarin.Android.Glide")]
		get;
	}

	long MaxSize
	{
		[Register("getMaxSize", "()J", "GetGetMaxSizeHandler:Bumptech.Glide.Load.Engine.Cache.IMemoryCacheInvoker, Xamarin.Android.Glide")]
		get;
	}

	[Register("clearMemory", "()V", "GetClearMemoryHandler:Bumptech.Glide.Load.Engine.Cache.IMemoryCacheInvoker, Xamarin.Android.Glide")]
	void ClearMemory();

	[Register("put", "(Lcom/bumptech/glide/load/Key;Lcom/bumptech/glide/load/engine/Resource;)Lcom/bumptech/glide/load/engine/Resource;", "GetPut_Lcom_bumptech_glide_load_Key_Lcom_bumptech_glide_load_engine_Resource_Handler:Bumptech.Glide.Load.Engine.Cache.IMemoryCacheInvoker, Xamarin.Android.Glide")]
	IResource? Put(IKey p0, IResource? p1);

	[Register("remove", "(Lcom/bumptech/glide/load/Key;)Lcom/bumptech/glide/load/engine/Resource;", "GetRemove_Lcom_bumptech_glide_load_Key_Handler:Bumptech.Glide.Load.Engine.Cache.IMemoryCacheInvoker, Xamarin.Android.Glide")]
	IResource? Remove(IKey p0);

	[Register("setResourceRemovedListener", "(Lcom/bumptech/glide/load/engine/cache/MemoryCache$ResourceRemovedListener;)V", "GetSetResourceRemovedListener_Lcom_bumptech_glide_load_engine_cache_MemoryCache_ResourceRemovedListener_Handler:Bumptech.Glide.Load.Engine.Cache.IMemoryCacheInvoker, Xamarin.Android.Glide")]
	void SetResourceRemovedListener(IMemoryCacheResourceRemovedListener p0);

	[Register("setSizeMultiplier", "(F)V", "GetSetSizeMultiplier_FHandler:Bumptech.Glide.Load.Engine.Cache.IMemoryCacheInvoker, Xamarin.Android.Glide")]
	void SetSizeMultiplier(float p0);

	[Register("trimMemory", "(I)V", "GetTrimMemory_IHandler:Bumptech.Glide.Load.Engine.Cache.IMemoryCacheInvoker, Xamarin.Android.Glide")]
	void TrimMemory(int p0);
}
