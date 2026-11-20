namespace SkiaSharp.Resources;

public abstract class ResourceProvider : SKObject, ISKReferenceCounted, ISKSkipObjectRegistration
{
	internal ResourceProvider(nint handle, bool owns)
		: base(handle, owns)
	{
	}
}
