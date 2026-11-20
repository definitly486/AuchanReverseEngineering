using System;
using System.Collections.Generic;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace AndroidX.Camera.Core.Impl;

[Register("androidx/camera/core/impl/RequestProcessor$Request", "", "AndroidX.Camera.Core.Impl.IRequestProcessorRequestInvoker")]
public interface IRequestProcessorRequest : IJavaObject, IDisposable, IJavaPeerable
{
	IConfig Parameters
	{
		[Register("getParameters", "()Landroidx/camera/core/impl/Config;", "GetGetParametersHandler:AndroidX.Camera.Core.Impl.IRequestProcessorRequestInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	IList<Integer> TargetOutputConfigIds
	{
		[Register("getTargetOutputConfigIds", "()Ljava/util/List;", "GetGetTargetOutputConfigIdsHandler:AndroidX.Camera.Core.Impl.IRequestProcessorRequestInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}

	int TemplateId
	{
		[Register("getTemplateId", "()I", "GetGetTemplateIdHandler:AndroidX.Camera.Core.Impl.IRequestProcessorRequestInvoker, Xamarin.AndroidX.Camera.Core")]
		get;
	}
}
