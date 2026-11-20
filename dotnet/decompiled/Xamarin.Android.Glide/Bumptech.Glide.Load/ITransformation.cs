using System;
using Android.Content;
using Android.Runtime;
using Bumptech.Glide.Load.Engine;
using Java.Interop;

namespace Bumptech.Glide.Load;

[Register("com/bumptech/glide/load/Transformation", "", "Bumptech.Glide.Load.ITransformationInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface ITransformation : IKey, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("transform", "(Landroid/content/Context;Lcom/bumptech/glide/load/engine/Resource;II)Lcom/bumptech/glide/load/engine/Resource;", "GetTransform_Landroid_content_Context_Lcom_bumptech_glide_load_engine_Resource_IIHandler:Bumptech.Glide.Load.ITransformationInvoker, Xamarin.Android.Glide")]
	IResource Transform(Context p0, IResource p1, int p2, int p3);
}
