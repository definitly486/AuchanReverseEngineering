using System;

namespace SkiaSharp;

public class SKSurface : SKObject, ISKReferenceCounted
{
	public SKCanvas Canvas => SKObject.OwnedBy(SKCanvas.GetObject(SkiaApi.sk_surface_get_canvas(Handle), owns: false, unrefExisting: false), this);

	internal SKSurface(nint h, bool owns)
		: base(h, owns)
	{
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	public static SKSurface Create(SKImageInfo info, nint pixels, int rowBytes)
	{
		return Create(info, pixels, rowBytes, null, null, null);
	}

	public unsafe static SKSurface Create(SKImageInfo info, nint pixels, int rowBytes, SKSurfaceReleaseDelegate releaseProc, object context, SKSurfaceProperties props)
	{
		SKImageInfoNative sKImageInfoNative = SKImageInfoNative.FromManaged(ref info);
		SKSurfaceReleaseDelegate sKSurfaceReleaseDelegate = ((releaseProc != null && context != null) ? ((SKSurfaceReleaseDelegate)delegate(nint addr, object _)
		{
			releaseProc(addr, context);
		}) : releaseProc);
		DelegateProxies.Create(sKSurfaceReleaseDelegate, out var _, out var contextPtr);
		delegate* unmanaged[Cdecl]<void*, void*, void> releaseProc2 = ((sKSurfaceReleaseDelegate != null) ? DelegateProxies.SKSurfaceRasterReleaseProxy : null);
		return GetObject(SkiaApi.sk_surface_new_raster_direct(&sKImageInfoNative, (void*)pixels, rowBytes, releaseProc2, (void*)contextPtr, props?.Handle ?? IntPtr.Zero));
	}

	public static SKSurface Create(GRContext context, GRBackendRenderTarget renderTarget, GRSurfaceOrigin origin, SKColorType colorType)
	{
		return Create((GRRecordingContext)context, renderTarget, origin, colorType);
	}

	public static SKSurface Create(GRRecordingContext context, GRBackendRenderTarget renderTarget, GRSurfaceOrigin origin, SKColorType colorType)
	{
		return Create(context, renderTarget, origin, colorType, null, null);
	}

	public static SKSurface Create(GRRecordingContext context, GRBackendRenderTarget renderTarget, GRSurfaceOrigin origin, SKColorType colorType, SKColorSpace colorspace, SKSurfaceProperties props)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (renderTarget == null)
		{
			throw new ArgumentNullException("renderTarget");
		}
		return GetObject(SkiaApi.sk_surface_new_backend_render_target(context.Handle, renderTarget.Handle, origin, colorType.ToNative(), colorspace?.Handle ?? IntPtr.Zero, props?.Handle ?? IntPtr.Zero));
	}

	internal static SKSurface GetObject(nint handle, bool owns = true, bool unrefExisting = true)
	{
		return SKObject.GetOrAddObject(handle, owns, unrefExisting, (nint h, bool o) => new SKSurface(h, o));
	}
}
