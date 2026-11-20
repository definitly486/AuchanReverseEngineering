using System;
using Android.Runtime;
using Google.Common.Util.Concurrent;
using Java.Interop;
using Java.Util.Concurrent;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/Observable", "", "AndroidX.Camera.Core.Impl.IObservableInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IObservable : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("addObserver", "(Ljava/util/concurrent/Executor;Landroidx/camera/core/impl/Observable$Observer;)V", "GetAddObserver_Ljava_util_concurrent_Executor_Landroidx_camera_core_impl_Observable_Observer_Handler:AndroidX.Camera.Core.Impl.IObservableInvoker, Xamarin.AndroidX.Camera.Core")]
	void AddObserver(IExecutor p0, IObservableObserver p1);

	[Register("fetchData", "()Lcom/google/common/util/concurrent/ListenableFuture;", "GetFetchDataHandler:AndroidX.Camera.Core.Impl.IObservableInvoker, Xamarin.AndroidX.Camera.Core")]
	IListenableFuture FetchData();

	[Register("removeObserver", "(Landroidx/camera/core/impl/Observable$Observer;)V", "GetRemoveObserver_Landroidx_camera_core_impl_Observable_Observer_Handler:AndroidX.Camera.Core.Impl.IObservableInvoker, Xamarin.AndroidX.Camera.Core")]
	void RemoveObserver(IObservableObserver p0);
}
