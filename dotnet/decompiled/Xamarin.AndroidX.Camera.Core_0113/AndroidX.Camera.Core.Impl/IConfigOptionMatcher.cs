using System;
using Android.Runtime;
using Java.Interop;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/Config$OptionMatcher", "", "AndroidX.Camera.Core.Impl.IConfigOptionMatcherInvoker")]
public interface IConfigOptionMatcher : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("onOptionMatched", "(Landroidx/camera/core/impl/Config$Option;)Z", "GetOnOptionMatched_Landroidx_camera_core_impl_Config_Option_Handler:AndroidX.Camera.Core.Impl.IConfigOptionMatcherInvoker, Xamarin.AndroidX.Camera.Core")]
	bool OnOptionMatched(ConfigOption p0);
}
