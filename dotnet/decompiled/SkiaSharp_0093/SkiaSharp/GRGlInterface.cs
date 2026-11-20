using System;

namespace SkiaSharp;

public class GRGlInterface : SKObject, ISKReferenceCounted, ISKSkipObjectRegistration
{
	internal GRGlInterface(nint h, bool owns)
		: base(h, owns)
	{
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	public static GRGlInterface Create()
	{
		return CreateGl() ?? null;
	}

	private static GRGlInterface CreateGl()
	{
		return GetObject(SkiaApi.gr_glinterface_create_native_interface());
	}

	internal static GRGlInterface GetObject(nint handle)
	{
		if (handle != IntPtr.Zero)
		{
			return new GRGlInterface(handle, owns: true);
		}
		return null;
	}
}
