using System;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;

namespace Bumptech.Glide.Load;

[Register("com/bumptech/glide/load/Encoder", "", "Bumptech.Glide.Load.IEncoderInvoker")]
[JavaTypeParameters(new string[] { "T" })]
public interface IEncoder : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("encode", "(Ljava/lang/Object;Ljava/io/File;Lcom/bumptech/glide/load/Options;)Z", "GetEncode_Ljava_lang_Object_Ljava_io_File_Lcom_bumptech_glide_load_Options_Handler:Bumptech.Glide.Load.IEncoderInvoker, Xamarin.Android.Glide")]
	bool Encode(Java.Lang.Object p0, File p1, Options p2);
}
