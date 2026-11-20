using System;
using System.Collections.Generic;

namespace SkiaSharp;

public class SKBlender : SKObject, ISKReferenceCounted
{
	private sealed class SKBlenderStatic : SKBlender
	{
		internal SKBlenderStatic(nint x)
			: base(x, owns: false)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}

	private static readonly Dictionary<SKBlendMode, SKBlender> blendModeBlenders;

	static SKBlender()
	{
		Array values = Enum.GetValues(typeof(SKBlendMode));
		blendModeBlenders = new Dictionary<SKBlendMode, SKBlender>(values.Length);
		foreach (SKBlendMode item in values)
		{
			blendModeBlenders[item] = new SKBlenderStatic(SkiaApi.sk_blender_new_mode(item));
		}
	}

	internal static void EnsureStaticInstanceAreInitialized()
	{
	}

	internal SKBlender(nint handle, bool owns)
		: base(handle, owns)
	{
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}
}
