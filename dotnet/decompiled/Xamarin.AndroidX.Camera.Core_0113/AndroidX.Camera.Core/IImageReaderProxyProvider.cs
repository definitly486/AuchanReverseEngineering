using System;
using Android.Runtime;
using AndroidX.Camera.Core.Impl;
using Java.Interop;

namespace AndroidX.Camera.Core;

[Obsolete("While this type is 'public', Google considers it internal API and reserves the right to modify or delete it in the future. Use at your own risk.", DiagnosticId = "XAOBS001")]
[Register("androidx/camera/core/ImageReaderProxyProvider", "", "AndroidX.Camera.Core.IImageReaderProxyProviderInvoker")]
public interface IImageReaderProxyProvider : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("newInstance", "(IIIIJ)Landroidx/camera/core/impl/ImageReaderProxy;", "GetNewInstance_IIIIJHandler:AndroidX.Camera.Core.IImageReaderProxyProviderInvoker, Xamarin.AndroidX.Camera.Core")]
	IImageReaderProxy NewInstance(int p0, int p1, int p2, int p3, long p4);
}
