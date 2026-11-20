namespace SkiaSharp;

public abstract class SKStream : SKObject
{
	internal SKStream(nint handle, bool owns)
		: base(handle, owns)
	{
	}
}
