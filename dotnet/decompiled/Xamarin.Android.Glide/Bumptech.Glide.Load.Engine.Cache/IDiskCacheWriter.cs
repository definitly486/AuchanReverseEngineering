using System;
using Android.Runtime;
using Java.IO;
using Java.Interop;

namespace Bumptech.Glide.Load.Engine.Cache;

[Register("com/bumptech/glide/load/engine/cache/DiskCache$Writer", "", "Bumptech.Glide.Load.Engine.Cache.IDiskCacheWriterInvoker")]
public interface IDiskCacheWriter : IJavaObject, IDisposable, IJavaPeerable
{
	[Register("write", "(Ljava/io/File;)Z", "GetWrite_Ljava_io_File_Handler:Bumptech.Glide.Load.Engine.Cache.IDiskCacheWriterInvoker, Xamarin.Android.Glide")]
	bool Write(File p0);
}
