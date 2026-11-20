using System;

namespace SkiaSharp;

public class GRBackendRenderTarget : SKObject, ISKSkipObjectRegistration
{
	public bool IsValid => SkiaApi.gr_backendrendertarget_is_valid(Handle);

	public int Width => SkiaApi.gr_backendrendertarget_get_width(Handle);

	public int Height => SkiaApi.gr_backendrendertarget_get_height(Handle);

	internal GRBackendRenderTarget(nint handle, bool owns)
		: base(handle, owns)
	{
	}

	public GRBackendRenderTarget(int width, int height, int sampleCount, int stencilBits, GRGlFramebufferInfo glInfo)
		: this(IntPtr.Zero, owns: true)
	{
		CreateGl(width, height, sampleCount, stencilBits, glInfo);
	}

	private unsafe void CreateGl(int width, int height, int sampleCount, int stencilBits, GRGlFramebufferInfo glInfo)
	{
		Handle = SkiaApi.gr_backendrendertarget_new_gl(width, height, sampleCount, stencilBits, &glInfo);
		if (Handle == IntPtr.Zero)
		{
			throw new InvalidOperationException("Unable to create a new GRBackendRenderTarget instance.");
		}
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	protected override void DisposeNative()
	{
		SkiaApi.gr_backendrendertarget_delete(Handle);
	}
}
