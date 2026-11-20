using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/RequestProcessor", "", "AndroidX.Camera.Core.Impl.IRequestProcessorInvoker")]
public interface IRequestProcessor : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("abortCaptures", "()V", "GetAbortCapturesHandler:AndroidX.Camera.Core.Impl.IRequestProcessorInvoker, Xamarin.AndroidX.Camera.Core")]
	void AbortCaptures();

	[Register("setRepeating", "(Landroidx/camera/core/impl/RequestProcessor$Request;Landroidx/camera/core/impl/RequestProcessor$Callback;)I", "GetSetRepeating_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_Handler:AndroidX.Camera.Core.Impl.IRequestProcessorInvoker, Xamarin.AndroidX.Camera.Core")]
	int SetRepeating(IRequestProcessorRequest p0, IRequestProcessorCallback p1);

	[Register("stopRepeating", "()V", "GetStopRepeatingHandler:AndroidX.Camera.Core.Impl.IRequestProcessorInvoker, Xamarin.AndroidX.Camera.Core")]
	void StopRepeating();

	[Register("submit", "(Landroidx/camera/core/impl/RequestProcessor$Request;Landroidx/camera/core/impl/RequestProcessor$Callback;)I", "GetSubmit_Landroidx_camera_core_impl_RequestProcessor_Request_Landroidx_camera_core_impl_RequestProcessor_Callback_Handler:AndroidX.Camera.Core.Impl.IRequestProcessorInvoker, Xamarin.AndroidX.Camera.Core")]
	int Submit(IRequestProcessorRequest p0, IRequestProcessorCallback p1);

	[Register("submit", "(Ljava/util/List;Landroidx/camera/core/impl/RequestProcessor$Callback;)I", "GetSubmit_Ljava_util_List_Landroidx_camera_core_impl_RequestProcessor_Callback_Handler:AndroidX.Camera.Core.Impl.IRequestProcessorInvoker, Xamarin.AndroidX.Camera.Core")]
	int Submit(IList<IRequestProcessorRequest> p0, IRequestProcessorCallback p1);
}
