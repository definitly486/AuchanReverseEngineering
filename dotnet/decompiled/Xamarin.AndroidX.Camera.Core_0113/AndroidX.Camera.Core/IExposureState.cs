using System;
using Android.Runtime;
using Android.Util;
using Java.Interop;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ExposureState", "", "AndroidX.Camera.Core.IExposureStateInvoker")]
public interface IExposureState : IJavaObject, IDisposable, IJavaPeerable
{
	int ExposureCompensationIndex
	{
		[Register("getExposureCompensationIndex", "()I", "GetGetExposureCompensationIndexHandler:AndroidX.Camera.Core.IExposureStateInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	Android.Util.Range ExposureCompensationRange
	{
		[Register("getExposureCompensationRange", "()Landroid/util/Range;", "GetGetExposureCompensationRangeHandler:AndroidX.Camera.Core.IExposureStateInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	Rational ExposureCompensationStep
	{
		[Register("getExposureCompensationStep", "()Landroid/util/Rational;", "GetGetExposureCompensationStepHandler:AndroidX.Camera.Core.IExposureStateInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	bool IsExposureCompensationSupported
	{
		[Register("isExposureCompensationSupported", "()Z", "GetIsExposureCompensationSupportedHandler:AndroidX.Camera.Core.IExposureStateInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}
}
