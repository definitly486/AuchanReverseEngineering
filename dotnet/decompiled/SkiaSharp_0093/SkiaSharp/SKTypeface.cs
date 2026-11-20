namespace SkiaSharp;

public class SKTypeface : SKObject, ISKReferenceCounted
{
	private sealed class SKTypefaceStatic : SKTypeface
	{
		internal SKTypefaceStatic(nint x)
			: base(x, owns: false)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}

	private static readonly SKTypeface defaultTypeface;

	static SKTypeface()
	{
		defaultTypeface = new SKTypefaceStatic(SkiaApi.sk_typeface_ref_default());
	}

	internal static void EnsureStaticInstanceAreInitialized()
	{
	}

	internal SKTypeface(nint handle, bool owns)
		: base(handle, owns)
	{
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}
}
