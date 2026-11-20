namespace SkiaSharp;

public class SKColorFilter : SKObject, ISKReferenceCounted
{
	private sealed class SKColorFilterStatic : SKColorFilter
	{
		internal SKColorFilterStatic(nint x)
			: base(x, owns: false)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}

	private static readonly SKColorFilter srgbToLinear;

	private static readonly SKColorFilter linearToSrgb;

	static SKColorFilter()
	{
		srgbToLinear = new SKColorFilterStatic(SkiaApi.sk_colorfilter_new_srgb_to_linear_gamma());
		linearToSrgb = new SKColorFilterStatic(SkiaApi.sk_colorfilter_new_linear_to_srgb_gamma());
	}

	internal static void EnsureStaticInstanceAreInitialized()
	{
	}

	internal SKColorFilter(nint handle, bool owns)
		: base(handle, owns)
	{
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}
}
