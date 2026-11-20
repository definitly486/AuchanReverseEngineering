using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Data;

[Register("com/bumptech/glide/load/data/DataFetcher", "", "Bumptech.Glide.Load.Data.IDataFetcherInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IDataFetcher : IJavaObject, IDisposable, IJavaPeerable
{
	Class DataClass
	{
		[Register("getDataClass", "()Ljava/lang/Class;", "GetGetDataClassHandler:Bumptech.Glide.Load.Data.IDataFetcherInvoker, Xamarin.Android.Glide")]
		get;
	}

	DataSource DataSource
	{
		[Register("getDataSource", "()Lcom/bumptech/glide/load/DataSource;", "GetGetDataSourceHandler:Bumptech.Glide.Load.Data.IDataFetcherInvoker, Xamarin.Android.Glide")]
		get;
	}

	[Register("cancel", "()V", "GetCancelHandler:Bumptech.Glide.Load.Data.IDataFetcherInvoker, Xamarin.Android.Glide")]
	void Cancel();

	[Register("cleanup", "()V", "GetCleanupHandler:Bumptech.Glide.Load.Data.IDataFetcherInvoker, Xamarin.Android.Glide")]
	void Cleanup();

	[Register("loadData", "(Lcom/bumptech/glide/Priority;Lcom/bumptech/glide/load/data/DataFetcher$DataCallback;)V", "GetLoadData_Lcom_bumptech_glide_Priority_Lcom_bumptech_glide_load_data_DataFetcher_DataCallback_Handler:Bumptech.Glide.Load.Data.IDataFetcherInvoker, Xamarin.Android.Glide")]
	void LoadData(Priority p0, IDataFetcherDataCallback p1);
}
