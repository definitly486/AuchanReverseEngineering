using System;
using Android.Graphics;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide.Load.Engine.BitmapRecycle;

[Register("com/bumptech/glide/load/engine/bitmap_recycle/BitmapPool", "", "Bumptech.Glide.Load.Engine.BitmapRecycle.IBitmapPoolInvoker")]
public interface IBitmapPool : IJavaObject, IDisposable, IJavaPeerable
{
	long MaxSize
	{
		[Register("getMaxSize", "()J", "GetGetMaxSizeHandler:Bumptech.Glide.Load.Engine.BitmapRecycle.IBitmapPoolInvoker, Xamarin.Android.Glide")]
		get;
	}

	[Register("clearMemory", "()V", "GetClearMemoryHandler:Bumptech.Glide.Load.Engine.BitmapRecycle.IBitmapPoolInvoker, Xamarin.Android.Glide")]
	void ClearMemory();

	[Register("get", "(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;", "GetGet_IILandroid_graphics_Bitmap_Config_Handler:Bumptech.Glide.Load.Engine.BitmapRecycle.IBitmapPoolInvoker, Xamarin.Android.Glide")]
	Bitmap Get(int p0, int p1, Bitmap.Config? p2);

	[Register("getDirty", "(IILandroid/graphics/Bitmap$Config;)Landroid/graphics/Bitmap;", "GetGetDirty_IILandroid_graphics_Bitmap_Config_Handler:Bumptech.Glide.Load.Engine.BitmapRecycle.IBitmapPoolInvoker, Xamarin.Android.Glide")]
	Bitmap GetDirty(int p0, int p1, Bitmap.Config? p2);

	[Register("put", "(Landroid/graphics/Bitmap;)V", "GetPut_Landroid_graphics_Bitmap_Handler:Bumptech.Glide.Load.Engine.BitmapRecycle.IBitmapPoolInvoker, Xamarin.Android.Glide")]
	void Put(Bitmap? p0);

	[Register("setSizeMultiplier", "(F)V", "GetSetSizeMultiplier_FHandler:Bumptech.Glide.Load.Engine.BitmapRecycle.IBitmapPoolInvoker, Xamarin.Android.Glide")]
	void SetSizeMultiplier(float p0);

	[Register("trimMemory", "(I)V", "GetTrimMemory_IHandler:Bumptech.Glide.Load.Engine.BitmapRecycle.IBitmapPoolInvoker, Xamarin.Android.Glide")]
	void TrimMemory(int p0);
}
