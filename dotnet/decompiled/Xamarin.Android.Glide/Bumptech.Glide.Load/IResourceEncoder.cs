using System;
using Android.Runtime;
using Java.Interop;

namespace Bumptech.Glide.Load;

[Register("com/bumptech/glide/load/ResourceEncoder", "", "Bumptech.Glide.Load.IResourceEncoderInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IResourceEncoder : IEncoder, IJavaObject, IDisposable, IJavaPeerable
{
	[Register("getEncodeStrategy", "(Lcom/bumptech/glide/load/Options;)Lcom/bumptech/glide/load/EncodeStrategy;", "GetGetEncodeStrategy_Lcom_bumptech_glide_load_Options_Handler:Bumptech.Glide.Load.IResourceEncoderInvoker, Xamarin.Android.Glide")]
	EncodeStrategy GetEncodeStrategy(Options p0);
}
