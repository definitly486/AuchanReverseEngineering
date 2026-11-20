using System.Runtime.InteropServices;
using SkiaSharp.Skottie;

namespace SkiaSharp;

internal class SkottieApi
{
	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void skottie_animation_builder_delete(nint instance);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal unsafe static extern nint skottie_animation_builder_make_from_data(nint instance, void* data, nint length);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern nint skottie_animation_builder_new(AnimationBuilderFlags flags);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void skottie_animation_builder_set_resource_provider(nint instance, nint resourceProvider);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void skottie_animation_delete(nint instance);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern double skottie_animation_get_duration(nint instance);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal unsafe static extern void skottie_animation_get_size(nint instance, SKSize* size);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal unsafe static extern void skottie_animation_render(nint instance, nint canvas, SKRect* dst);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void skottie_animation_seek_frame_time(nint instance, float t, nint ic);

	[DllImport("libSkiaSharp", ExactSpelling = true)]
	[LibraryImport("libSkiaSharp")]
	internal static extern void skottie_animation_unref(nint instance);
}
