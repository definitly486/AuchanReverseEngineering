using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Java.Util.Concurrent;

namespace Google.Common.Util.Concurrent;

[Register("com/google/common/util/concurrent/ListenableFuture", "", "Google.Common.Util.Concurrent.IListenableFutureInvoker")]
[JavaTypeParameters(new string[] { "V" })]
public interface IListenableFuture : IFuture, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("addListener", "(Ljava/lang/Runnable;Ljava/util/concurrent/Executor;)V", "GetAddListener_Ljava_lang_Runnable_Ljava_util_concurrent_Executor_Handler:Google.Common.Util.Concurrent.IListenableFutureInvoker, Xamarin.Google.Guava.ListenableFuture")]
	void AddListener(IRunnable p0, IExecutor p1);
}
