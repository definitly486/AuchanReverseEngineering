using System;
using Android.Runtime;
using AndroidX.Camera.Core.Impl;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core;

[Register("androidx/camera/core/ExtendableBuilder", "", "AndroidX.Camera.Core.IExtendableBuilderInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IExtendableBuilder : IJavaObject, IDisposable, IJavaPeerable
{
	IMutableConfig MutableConfig
	{
		[Register("getMutableConfig", "()Landroidx/camera/core/impl/MutableConfig;", "GetGetMutableConfigHandler:AndroidX.Camera.Core.IExtendableBuilderInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	[Register("build", "()Ljava/lang/Object;", "GetBuildHandler:AndroidX.Camera.Core.IExtendableBuilderInvoker, Xamarin.AndroidX.Camera.Core")]
	Java.Lang.Object Build();
}
