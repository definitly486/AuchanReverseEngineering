using System;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load.Model;

[Register("com/bumptech/glide/load/model/ModelLoader", "", "Bumptech.Glide.Load.Model.IModelLoaderInvoker")]
[JavaTypeParameters(new string[] { "Model", "Data" })]
public interface IModelLoader : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("buildLoadData", "(Ljava/lang/Object;IILcom/bumptech/glide/load/Options;)Lcom/bumptech/glide/load/model/ModelLoader$LoadData;", "GetBuildLoadData_Ljava_lang_Object_IILcom_bumptech_glide_load_Options_Handler:Bumptech.Glide.Load.Model.IModelLoaderInvoker, Xamarin.Android.Glide")]
	ModelLoaderLoadData? BuildLoadData(Java.Lang.Object p0, int p1, int p2, Options p3);

	[Register("handles", "(Ljava/lang/Object;)Z", "GetHandles_Ljava_lang_Object_Handler:Bumptech.Glide.Load.Model.IModelLoaderInvoker, Xamarin.Android.Glide")]
	bool Handles(Java.Lang.Object p0);
}
