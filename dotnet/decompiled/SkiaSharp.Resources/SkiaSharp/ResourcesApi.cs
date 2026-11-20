using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SkiaSharp;

internal class ResourcesApi
{
	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint skresources_caching_resource_provider_proxy_make(nint rp);

	[LibraryImport("libSkiaSharp")]
	[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "8.0.10.36612")]
	[SkipLocalsInit]
	internal static nint skresources_data_uri_resource_provider_proxy_make(nint rp, [MarshalAs(UnmanagedType.I1)] bool predecode)
	{
		sbyte _predecode_native = (predecode ? ((sbyte)1) : ((sbyte)0));
		return __PInvoke(rp, _predecode_native);
		[DllImport("libSkiaSharp", EntryPoint = "skresources_data_uri_resource_provider_proxy_make", ExactSpelling = true)]
		static extern nint __PInvoke(nint __rp_native, sbyte __predecode_native);
	}
}
