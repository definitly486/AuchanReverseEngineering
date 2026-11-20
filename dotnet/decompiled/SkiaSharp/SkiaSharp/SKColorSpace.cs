namespace SkiaSharp;

public class SKColorSpace : SKObject, ISKNonVirtualReferenceCounted, ISKReferenceCounted
{
	private sealed class SKColorSpaceStatic : SKColorSpace
	{
		internal SKColorSpaceStatic(nint x)
			: base(x, owns: false)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}

	private static readonly SKColorSpace srgb;

	private static readonly SKColorSpace srgbLinear;

	static SKColorSpace()
	{
		srgb = new SKColorSpaceStatic(SkiaApi.sk_colorspace_new_srgb());
		srgbLinear = new SKColorSpaceStatic(SkiaApi.sk_colorspace_new_srgb_linear());
	}

	internal static void EnsureStaticInstanceAreInitialized()
	{
	}

	internal SKColorSpace(nint handle, bool owns)
		: base(handle, owns)
	{
	}

	void ISKNonVirtualReferenceCounted.UnreferenceNative()
	{
		SkiaApi.sk_colorspace_unref(Handle);
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}
}
