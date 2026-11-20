namespace SkiaSharp;

public abstract class SKStreamAsset : SKStreamSeekable
{
	internal SKStreamAsset(nint handle, bool owns)
		: base(handle, owns)
	{
	}
}
