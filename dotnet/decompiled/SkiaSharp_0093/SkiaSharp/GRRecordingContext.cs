using System;

namespace SkiaSharp;

public class GRRecordingContext : SKObject, ISKReferenceCounted
{
	internal GRRecordingContext(nint h, bool owns)
		: base(h, owns)
	{
	}

	public int GetMaxSurfaceSampleCount(SKColorType colorType)
	{
		return SkiaApi.gr_recording_context_get_max_surface_sample_count_for_color_type(Handle, colorType.ToNative());
	}

	internal static GRRecordingContext GetObject(nint handle, bool owns = true, bool unrefExisting = true)
	{
		nint num = SkiaApi.gr_recording_context_get_direct_context(handle);
		if (num != IntPtr.Zero)
		{
			return GRContext.GetObject(num, owns: false, unrefExisting: false);
		}
		return SKObject.GetOrAddObject(handle, owns, unrefExisting, (nint h, bool o) => new GRRecordingContext(h, o));
	}
}
