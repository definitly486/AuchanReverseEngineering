using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Engine.BitmapRecycle;

[Register("com/bumptech/glide/load/engine/bitmap_recycle/ArrayPool", "", "Bumptech.Glide.Load.Engine.BitmapRecycle.IArrayPoolInvoker")]
public interface IArrayPool : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("clearMemory", "()V", "GetClearMemoryHandler:Bumptech.Glide.Load.Engine.BitmapRecycle.IArrayPoolInvoker, Xamarin.Android.Glide")]
	void ClearMemory();

	[Register("get", "(ILjava/lang/Class;)Ljava/lang/Object;", "GetGet_ILjava_lang_Class_Handler:Bumptech.Glide.Load.Engine.BitmapRecycle.IArrayPoolInvoker, Xamarin.Android.Glide")]
	[JavaTypeParameters(new string[] { "T" })]
	Java.Lang.Object? Get(int p0, Class? p1);

	[Register("getExact", "(ILjava/lang/Class;)Ljava/lang/Object;", "GetGetExact_ILjava_lang_Class_Handler:Bumptech.Glide.Load.Engine.BitmapRecycle.IArrayPoolInvoker, Xamarin.Android.Glide")]
	[JavaTypeParameters(new string[] { "T" })]
	Java.Lang.Object? GetExact(int p0, Class? p1);

	[Register("put", "(Ljava/lang/Object;)V", "GetPut_Ljava_lang_Object_Handler:Bumptech.Glide.Load.Engine.BitmapRecycle.IArrayPoolInvoker, Xamarin.Android.Glide")]
	[JavaTypeParameters(new string[] { "T" })]
	void Put(Java.Lang.Object? p0);

	[Obsolete("deprecated")]
	[Register("put", "(Ljava/lang/Object;Ljava/lang/Class;)V", "GetPut_Ljava_lang_Object_Ljava_lang_Class_Handler:Bumptech.Glide.Load.Engine.BitmapRecycle.IArrayPoolInvoker, Xamarin.Android.Glide")]
	[JavaTypeParameters(new string[] { "T" })]
	void Put(Java.Lang.Object? p0, Class? p1);

	[Register("trimMemory", "(I)V", "GetTrimMemory_IHandler:Bumptech.Glide.Load.Engine.BitmapRecycle.IArrayPoolInvoker, Xamarin.Android.Glide")]
	void TrimMemory(int p0);
}
