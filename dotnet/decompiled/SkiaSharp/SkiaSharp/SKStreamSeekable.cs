namespace SkiaSharp;

public abstract class SKStreamSeekable : SKStreamRewindable
{
	internal SKStreamSeekable(nint handle, bool owns)
		: base(handle, owns)
	{
	}
}
