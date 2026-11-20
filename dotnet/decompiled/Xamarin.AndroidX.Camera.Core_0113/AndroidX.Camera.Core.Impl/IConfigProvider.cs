using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/ConfigProvider", "", "AndroidX.Camera.Core.Impl.IConfigProviderInvoker")]
[JavaTypeParameters(new string[] { "C extends androidx.camera.core.impl.Config" })]
public interface IConfigProvider : IJavaObject, IDisposable, IJavaPeerable
{
	Java.Lang.Object Config
	{
		[Register("getConfig", "()Landroidx/camera/core/impl/Config;", "GetGetConfigHandler:AndroidX.Camera.Core.Impl.IConfigProviderInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}
}
