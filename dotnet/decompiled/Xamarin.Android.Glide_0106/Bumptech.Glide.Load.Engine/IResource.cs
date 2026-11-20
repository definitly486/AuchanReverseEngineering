using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Engine;

[Register("com/bumptech/glide/load/engine/Resource", "", "Bumptech.Glide.Load.Engine.IResourceInvoker")]
[JavaTypeParameters(new string[] { "Z" })]
public interface IResource : IJavaObject, IDisposable, IJavaPeerable
{
	Class ResourceClass
	{
		[Register("getResourceClass", "()Ljava/lang/Class;", "GetGetResourceClassHandler:Bumptech.Glide.Load.Engine.IResourceInvoker, Xamarin.Android.Glide")]
		get;
	}

	int Size
	{
		[Register("getSize", "()I", "GetGetSizeHandler:Bumptech.Glide.Load.Engine.IResourceInvoker, Xamarin.Android.Glide")]
		get;
	}

	[Register("get", "()Ljava/lang/Object;", "GetGetHandler:Bumptech.Glide.Load.Engine.IResourceInvoker, Xamarin.Android.Glide")]
	Java.Lang.Object Get();

	[Register("recycle", "()V", "GetRecycleHandler:Bumptech.Glide.Load.Engine.IResourceInvoker, Xamarin.Android.Glide")]
	void Recycle();
}
