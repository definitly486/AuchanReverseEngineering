using System;
using System.Runtime.CompilerServices;

namespace SkiaSharp.Views.Android;

public class SKPaintSurfaceEventArgs : EventArgs
{
	[CompilerGenerated]
	private readonly SKImageInfo _003CRawInfo_003Ek__BackingField;

	public SKSurface Surface { get; }

	public SKImageInfo Info { get; }

	public SKPaintSurfaceEventArgs(SKSurface surface, SKImageInfo info, SKImageInfo rawInfo)
	{
		Surface = surface;
		Info = info;
		_003CRawInfo_003Ek__BackingField = rawInfo;
	}
}
