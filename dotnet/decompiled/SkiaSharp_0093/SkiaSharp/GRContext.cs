using System;

namespace SkiaSharp;

public class GRContext : GRRecordingContext
{
	internal GRContext(nint h, bool owns)
		: base(h, owns)
	{
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	protected override void DisposeNative()
	{
		AbandonContext();
		base.DisposeNative();
	}

	public static GRContext CreateGl(GRGlInterface backendContext)
	{
		return CreateGl(backendContext, null);
	}

	public unsafe static GRContext CreateGl(GRGlInterface backendContext, GRContextOptions options)
	{
		nint glInterface = backendContext?.Handle ?? IntPtr.Zero;
		if (options == null)
		{
			return GetObject(SkiaApi.gr_direct_context_make_gl(glInterface));
		}
		GRContextOptionsNative gRContextOptionsNative = options.ToNative();
		return GetObject(SkiaApi.gr_direct_context_make_gl_with_options(glInterface, &gRContextOptionsNative));
	}

	public void AbandonContext(bool releaseResources = false)
	{
		if (releaseResources)
		{
			SkiaApi.gr_direct_context_release_resources_and_abandon_context(Handle);
		}
		else
		{
			SkiaApi.gr_direct_context_abandon_context(Handle);
		}
	}

	public void Flush()
	{
		Flush(submit: true);
	}

	public void Flush(bool submit, bool synchronous = false)
	{
		if (submit)
		{
			SkiaApi.gr_direct_context_flush_and_submit(Handle, synchronous);
		}
		else
		{
			SkiaApi.gr_direct_context_flush(Handle);
		}
	}

	public new int GetMaxSurfaceSampleCount(SKColorType colorType)
	{
		return base.GetMaxSurfaceSampleCount(colorType);
	}

	internal new static GRContext GetObject(nint handle, bool owns = true, bool unrefExisting = true)
	{
		return SKObject.GetOrAddObject(handle, owns, unrefExisting, (nint h, bool o) => new GRContext(h, o));
	}
}
