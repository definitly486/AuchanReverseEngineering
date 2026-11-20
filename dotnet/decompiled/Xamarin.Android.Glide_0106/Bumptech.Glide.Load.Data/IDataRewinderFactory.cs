using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Data;

[Register("com/bumptech/glide/load/data/DataRewinder$Factory", "", "Bumptech.Glide.Load.Data.IDataRewinderFactoryInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IDataRewinderFactory : IJavaObject, IDisposable, IJavaPeerable
{
	Class DataClass
	{
		[Register("getDataClass", "()Ljava/lang/Class;", "GetGetDataClassHandler:Bumptech.Glide.Load.Data.IDataRewinderFactoryInvoker, Xamarin.Android.Glide")]
		get;
	}

	[Register("build", "(Ljava/lang/Object;)Lcom/bumptech/glide/load/data/DataRewinder;", "GetBuild_Ljava_lang_Object_Handler:Bumptech.Glide.Load.Data.IDataRewinderFactoryInvoker, Xamarin.Android.Glide")]
	IDataRewinder Build(Java.Lang.Object p0);
}
