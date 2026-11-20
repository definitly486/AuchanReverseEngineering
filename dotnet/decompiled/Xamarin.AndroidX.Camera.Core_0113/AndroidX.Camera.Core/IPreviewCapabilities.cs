using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/PreviewCapabilities", "", "AndroidX.Camera.Core.IPreviewCapabilitiesInvoker")]
public interface IPreviewCapabilities : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsStabilizationSupported
	{
		[Register("isStabilizationSupported", "()Z", "GetIsStabilizationSupportedHandler:AndroidX.Camera.Core.IPreviewCapabilitiesInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}
}
