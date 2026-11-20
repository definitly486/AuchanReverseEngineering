using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ImageCaptureCapabilities", "", "AndroidX.Camera.Core.IImageCaptureCapabilitiesInvoker")]
public interface IImageCaptureCapabilities : IJavaObject, IDisposable, IJavaPeerable
{
	bool IsCaptureProcessProgressSupported
	{
		[Register("isCaptureProcessProgressSupported", "()Z", "GetIsCaptureProcessProgressSupportedHandler:AndroidX.Camera.Core.IImageCaptureCapabilitiesInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	bool IsPostviewSupported
	{
		[Register("isPostviewSupported", "()Z", "GetIsPostviewSupportedHandler:AndroidX.Camera.Core.IImageCaptureCapabilitiesInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	ICollection<Integer> SupportedOutputFormats
	{
		[Register("getSupportedOutputFormats", "()Ljava/util/Set;", "GetGetSupportedOutputFormatsHandler:AndroidX.Camera.Core.IImageCaptureCapabilitiesInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}
}
