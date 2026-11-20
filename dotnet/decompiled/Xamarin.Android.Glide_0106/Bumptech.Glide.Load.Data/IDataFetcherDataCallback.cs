using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Data;

[Register("com/bumptech/glide/load/data/DataFetcher$DataCallback", "", "Bumptech.Glide.Load.Data.IDataFetcherDataCallbackInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IDataFetcherDataCallback : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onDataReady", "(Ljava/lang/Object;)V", "GetOnDataReady_Ljava_lang_Object_Handler:Bumptech.Glide.Load.Data.IDataFetcherDataCallbackInvoker, Xamarin.Android.Glide")]
	void OnDataReady(Java.Lang.Object? p0);

	[Register("onLoadFailed", "(Ljava/lang/Exception;)V", "GetOnLoadFailed_Ljava_lang_Exception_Handler:Bumptech.Glide.Load.Data.IDataFetcherDataCallbackInvoker, Xamarin.Android.Glide")]
	void OnLoadFailed(Java.Lang.Exception p0);
}
