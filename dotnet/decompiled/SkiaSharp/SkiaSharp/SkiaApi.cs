using System.CodeDom.Compiler;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SkiaSharp;

internal class SkiaApi
{
	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void gr_backendrendertarget_delete(nint rendertarget);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern int gr_backendrendertarget_get_height(nint rendertarget);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern int gr_backendrendertarget_get_width(nint rendertarget);

	[LibraryImport("libSkiaSharp")]
	[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "8.0.10.36612")]
	[SkipLocalsInit]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static bool gr_backendrendertarget_is_valid(nint rendertarget)
	{
		sbyte b = __PInvoke(rendertarget);
		return b != 0;
		[DllImport("libSkiaSharp", EntryPoint = "gr_backendrendertarget_is_valid", ExactSpelling = true)]
		static extern sbyte __PInvoke(nint __rendertarget_native);
	}

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal unsafe static extern nint gr_backendrendertarget_new_gl(int width, int height, int samples, int stencils, GRGlFramebufferInfo* glInfo);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void gr_direct_context_abandon_context(nint context);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void gr_direct_context_flush(nint context);

	[LibraryImport("libSkiaSharp")]
	[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "8.0.10.36612")]
	[SkipLocalsInit]
	internal static void gr_direct_context_flush_and_submit(nint context, [MarshalAs(UnmanagedType.I1)] bool syncCpu)
	{
		sbyte _syncCpu_native = (syncCpu ? ((sbyte)1) : ((sbyte)0));
		__PInvoke(context, _syncCpu_native);
		[DllImport("libSkiaSharp", EntryPoint = "gr_direct_context_flush_and_submit", ExactSpelling = true)]
		static extern void __PInvoke(nint __context_native, sbyte __syncCpu_native);
	}

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint gr_direct_context_make_gl(nint glInterface);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal unsafe static extern nint gr_direct_context_make_gl_with_options(nint glInterface, GRContextOptionsNative* options);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void gr_direct_context_release_resources_and_abandon_context(nint context);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint gr_glinterface_create_native_interface();

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint gr_recording_context_get_direct_context(nint context);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern int gr_recording_context_get_max_surface_sample_count_for_color_type(nint context, SKColorTypeNative colorType);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint sk_blender_new_mode(SKBlendMode mode);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void sk_canvas_clear(nint ccanvas, uint color);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void sk_canvas_destroy(nint ccanvas);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern int sk_canvas_get_save_count(nint ccanvas);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void sk_canvas_restore_to_count(nint ccanvas, int saveCount);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern int sk_canvas_save(nint ccanvas);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void sk_canvas_scale(nint ccanvas, float sx, float sy);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint sk_get_recording_context(nint canvas);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint sk_colorfilter_new_linear_to_srgb_gamma();

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint sk_colorfilter_new_srgb_to_linear_gamma();

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint sk_colorspace_new_srgb();

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint sk_colorspace_new_srgb_linear();

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void sk_colorspace_unref(nint colorspace);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal unsafe static extern void* sk_data_get_data(nint param0);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint sk_data_get_size(nint param0);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint sk_data_new_empty();

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint sk_data_new_from_stream(nint stream, nint length);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void sk_data_unref(nint param0);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern SKColorTypeNative sk_colortype_get_default_8888();

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void sk_refcnt_safe_unref(nint refcnt);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern int sk_version_get_increment();

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern int sk_version_get_milestone();

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void sk_path_delete(nint param0);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal unsafe static extern void sk_color_get_bit_shift(int* a, int* r, int* g, int* b);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern uint sk_color_premultiply(uint color);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern uint sk_color_unpremultiply(uint pmcolor);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void sk_dynamicmemorywstream_destroy(nint cstream);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint sk_dynamicmemorywstream_detach_as_data(nint cstream);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint sk_dynamicmemorywstream_new();

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint sk_stream_get_position(nint cstream);

	[LibraryImport("libSkiaSharp")]
	[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "8.0.10.36612")]
	[SkipLocalsInit]
	[return: MarshalAs(UnmanagedType.I1)]
	internal static bool sk_stream_seek(nint cstream, nint position)
	{
		sbyte b = __PInvoke(cstream, position);
		return b != 0;
		[DllImport("libSkiaSharp", EntryPoint = "sk_stream_seek", ExactSpelling = true)]
		static extern sbyte __PInvoke(nint __cstream_native, nint __position_native);
	}

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void sk_wstream_flush(nint cstream);

	[LibraryImport("libSkiaSharp")]
	[GeneratedCode("Microsoft.Interop.LibraryImportGenerator", "8.0.10.36612")]
	[SkipLocalsInit]
	[return: MarshalAs(UnmanagedType.I1)]
	internal unsafe static bool sk_wstream_write(nint cstream, void* buffer, nint size)
	{
		sbyte b = __PInvoke(cstream, buffer, size);
		return b != 0;
		[DllImport("libSkiaSharp", EntryPoint = "sk_wstream_write", ExactSpelling = true)]
		static extern unsafe sbyte __PInvoke(nint __cstream_native, void* __buffer_native, nint __size_native);
	}

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint sk_surface_get_canvas(nint param0);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint sk_surface_new_backend_render_target(nint context, nint target, GRSurfaceOrigin origin, SKColorTypeNative colorType, nint colorspace, nint props);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal unsafe static extern nint sk_surface_new_raster_direct(SKImageInfoNative* param0, void* pixels, nint rowBytes, void* releaseProc, void* context, nint props);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint sk_fontmgr_ref_default();

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint sk_typeface_ref_default();

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void sk_manageddrawable_set_procs(SKManagedDrawableDelegates procs);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void sk_managedstream_destroy(nint s);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal unsafe static extern nint sk_managedstream_new(void* context);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void sk_managedstream_set_procs(SKManagedStreamDelegates procs);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void sk_managedwstream_set_procs(SKManagedWStreamDelegates procs);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void sk_managedtracememorydump_set_procs(SKManagedTraceMemoryDumpDelegates procs);
}
