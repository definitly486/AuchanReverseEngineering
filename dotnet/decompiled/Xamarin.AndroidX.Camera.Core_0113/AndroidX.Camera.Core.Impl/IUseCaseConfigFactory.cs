using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/UseCaseConfigFactory", "", "AndroidX.Camera.Core.Impl.IUseCaseConfigFactoryInvoker")]
public interface IUseCaseConfigFactory : IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/camera/core/impl/UseCaseConfigFactory", typeof(IUseCaseConfigFactory), isInterface: true);

	[Register("EMPTY_INSTANCE")]
	static IUseCaseConfigFactory? EmptyInstance => Java.Lang.Object.GetObject<IUseCaseConfigFactory>(_members.StaticFields.GetObjectValue("EMPTY_INSTANCE.Landroidx/camera/core/impl/UseCaseConfigFactory;").Handle, JniHandleOwnership.TransferLocalRef);

	[Register("getConfig", "(Landroidx/camera/core/impl/UseCaseConfigFactory$CaptureType;I)Landroidx/camera/core/impl/Config;", "GetGetConfig_Landroidx_camera_core_impl_UseCaseConfigFactory_CaptureType_IHandler:AndroidX.Camera.Core.Impl.IUseCaseConfigFactoryInvoker, Xamarin.AndroidX.Camera.Core")]
	IConfig? GetConfig(UseCaseConfigFactoryCaptureType p0, int p1);
}
