using System;
using Android.Runtime;
using AndroidX.Camera.Core.Internal;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/UseCaseConfig$Builder", "", "AndroidX.Camera.Core.Impl.IUseCaseConfigBuilderInvoker")]
[JavaTypeParameters(new string[] { "T extends androidx.camera.core.UseCase", "C extends androidx.camera.core.impl.UseCaseConfig<T>", "B" })]
public interface IUseCaseConfigBuilder : IExtendableBuilder, IJavaObject, IDisposable, IJavaPeerable, ITargetConfigBuilder
{
	Java.Lang.Object UseCaseConfig
	{
		[Register("getUseCaseConfig", "()Landroidx/camera/core/impl/UseCaseConfig;", "GetGetUseCaseConfigHandler:AndroidX.Camera.Core.Impl.IUseCaseConfigBuilderInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	[Register("setCaptureOptionUnpacker", "(Landroidx/camera/core/impl/CaptureConfig$OptionUnpacker;)Ljava/lang/Object;", "GetSetCaptureOptionUnpacker_Landroidx_camera_core_impl_CaptureConfig_OptionUnpacker_Handler:AndroidX.Camera.Core.Impl.IUseCaseConfigBuilderInvoker, Xamarin.AndroidX.Camera.Core")]
	Java.Lang.Object SetCaptureOptionUnpacker(CaptureConfig.IOptionUnpacker p0);

	[Register("setCaptureType", "(Landroidx/camera/core/impl/UseCaseConfigFactory$CaptureType;)Ljava/lang/Object;", "GetSetCaptureType_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_Handler:AndroidX.Camera.Core.Impl.IUseCaseConfigBuilderInvoker, Xamarin.AndroidX.Camera.Core")]
	Java.Lang.Object SetCaptureType(UseCaseConfigFactoryCaptureType p0);

	[Register("setDefaultCaptureConfig", "(Landroidx/camera/core/impl/CaptureConfig;)Ljava/lang/Object;", "GetSetDefaultCaptureConfig_Landroidx_camera_core_impl_CaptureConfig_Handler:AndroidX.Camera.Core.Impl.IUseCaseConfigBuilderInvoker, Xamarin.AndroidX.Camera.Core")]
	Java.Lang.Object SetDefaultCaptureConfig(CaptureConfig p0);

	[Register("setDefaultSessionConfig", "(Landroidx/camera/core/impl/SessionConfig;)Ljava/lang/Object;", "GetSetDefaultSessionConfig_Landroidx_camera_core_impl_SessionConfig_Handler:AndroidX.Camera.Core.Impl.IUseCaseConfigBuilderInvoker, Xamarin.AndroidX.Camera.Core")]
	Java.Lang.Object SetDefaultSessionConfig(SessionConfig p0);

	[Register("setHighResolutionDisabled", "(Z)Ljava/lang/Object;", "GetSetHighResolutionDisabled_ZHandler:AndroidX.Camera.Core.Impl.IUseCaseConfigBuilderInvoker, Xamarin.AndroidX.Camera.Core")]
	Java.Lang.Object SetHighResolutionDisabled(bool p0);

	[Register("setSessionOptionUnpacker", "(Landroidx/camera/core/impl/SessionConfig$OptionUnpacker;)Ljava/lang/Object;", "GetSetSessionOptionUnpacker_Landroidx_camera_core_impl_SessionConfig_OptionUnpacker_Handler:AndroidX.Camera.Core.Impl.IUseCaseConfigBuilderInvoker, Xamarin.AndroidX.Camera.Core")]
	Java.Lang.Object SetSessionOptionUnpacker(SessionConfig.IOptionUnpacker p0);

	[Register("setSurfaceOccupancyPriority", "(I)Ljava/lang/Object;", "GetSetSurfaceOccupancyPriority_IHandler:AndroidX.Camera.Core.Impl.IUseCaseConfigBuilderInvoker, Xamarin.AndroidX.Camera.Core")]
	Java.Lang.Object SetSurfaceOccupancyPriority(int p0);

	[Register("setZslDisabled", "(Z)Ljava/lang/Object;", "GetSetZslDisabled_ZHandler:AndroidX.Camera.Core.Impl.IUseCaseConfigBuilderInvoker, Xamarin.AndroidX.Camera.Core")]
	Java.Lang.Object SetZslDisabled(bool p0);
}
