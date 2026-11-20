namespace SkiaSharp;

public class SKFontManager : SKObject, ISKReferenceCounted
{
	private sealed class SKFontManagerStatic : SKFontManager
	{
		internal SKFontManagerStatic(nint x)
			: base(x, owns: false)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}

	private static readonly SKFontManager defaultManager;

	static SKFontManager()
	{
		defaultManager = new SKFontManagerStatic(SkiaApi.sk_fontmgr_ref_default());
	}

	internal static void EnsureStaticInstanceAreInitialized()
	{
	}

	internal SKFontManager(nint handle, bool owns)
		: base(handle, owns)
	{
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}
}
