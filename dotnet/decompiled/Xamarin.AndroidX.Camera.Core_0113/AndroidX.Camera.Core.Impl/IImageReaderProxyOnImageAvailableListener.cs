using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Camera.Core.Impl;

[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
[Register("androidx/camera/core/impl/ImageReaderProxy$OnImageAvailableListener", "", "AndroidX.Camera.Core.Impl.IImageReaderProxyOnImageAvailableListenerInvoker")]
public interface IImageReaderProxyOnImageAvailableListener : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onImageAvailable", "(Landroidx/camera/core/impl/ImageReaderProxy;)V", "GetOnImageAvailable_Landroidx_camera_core_impl_ImageReaderProxy_Handler:AndroidX.Camera.Core.Impl.IImageReaderProxyOnImageAvailableListenerInvoker, Xamarin.AndroidX.Camera.Core")]
	void OnImageAvailable(IImageReaderProxy p0);
}
