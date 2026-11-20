using System;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide.Load.Model;

[Register("com/bumptech/glide/load/model/ModelLoaderFactory", "", "Bumptech.Glide.Load.Model.IModelLoaderFactoryInvoker")]
[JavaTypeParameters(new string[] { "T", "Y" })]
public interface IModelLoaderFactory : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("build", "(Lcom/bumptech/glide/load/model/MultiModelLoaderFactory;)Lcom/bumptech/glide/load/model/ModelLoader;", "GetBuild_Lcom_bumptech_glide_load_model_MultiModelLoaderFactory_Handler:Bumptech.Glide.Load.Model.IModelLoaderFactoryInvoker, Xamarin.Android.Glide")]
	IModelLoader Build(MultiModelLoaderFactory p0);

	[Register("teardown", "()V", "GetTeardownHandler:Bumptech.Glide.Load.Model.IModelLoaderFactoryInvoker, Xamarin.Android.Glide")]
	void Teardown();
}
