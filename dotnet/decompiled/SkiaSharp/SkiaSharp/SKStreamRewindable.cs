namespace SkiaSharp;

public abstract class SKStreamRewindable : SKStream
{
	internal SKStreamRewindable(nint handle, bool owns)
		: base(handle, owns)
	{
	}
}
