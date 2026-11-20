using System;
using System.Runtime.CompilerServices;

namespace SkiaSharp.Views.Android;

public class SKPaintGLSurfaceEventArgs : EventArgs
{
	[CompilerGenerated]
	private GRBackendRenderTarget _003CBackendRenderTarget_003Ek__BackingField;

	[CompilerGenerated]
	private GRSurfaceOrigin _003COrigin_003Ek__BackingField;

	[CompilerGenerated]
	private SKImageInfo _003CRawInfo_003Ek__BackingField;

	public SKSurface Surface { get; private set; }

	private GRBackendRenderTarget BackendRenderTarget
	{
		[CompilerGenerated]
		set
		{
			_003CBackendRenderTarget_003Ek__BackingField = value;
		}
	}

	public SKColorType ColorType { get; private set; }

	private GRSurfaceOrigin Origin
	{
		[CompilerGenerated]
		set
		{
			_003COrigin_003Ek__BackingField = value;
		}
	}

	public SKImageInfo Info { get; private set; }

	private SKImageInfo RawInfo
	{
		[CompilerGenerated]
		set
		{
			_003CRawInfo_003Ek__BackingField = value;
		}
	}

	public SKPaintGLSurfaceEventArgs(SKSurface surface, GRBackendRenderTarget renderTarget, GRSurfaceOrigin origin, SKColorType colorType)
	{
		Surface = surface;
		BackendRenderTarget = renderTarget;
		ColorType = colorType;
		Origin = origin;
		Info = new SKImageInfo(renderTarget.Width, renderTarget.Height, ColorType);
		RawInfo = Info;
	}
}
