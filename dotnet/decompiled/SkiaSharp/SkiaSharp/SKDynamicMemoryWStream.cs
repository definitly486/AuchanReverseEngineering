using System;

namespace SkiaSharp;

public class SKDynamicMemoryWStream : SKWStream
{
	public SKDynamicMemoryWStream()
		: base(SkiaApi.sk_dynamicmemorywstream_new(), owns: true)
	{
		if (Handle == IntPtr.Zero)
		{
			throw new InvalidOperationException("Unable to create a new SKDynamicMemoryWStream instance.");
		}
	}

	public SKData DetachAsData()
	{
		return SKData.GetObject(SkiaApi.sk_dynamicmemorywstream_detach_as_data(Handle));
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	protected override void DisposeNative()
	{
		SkiaApi.sk_dynamicmemorywstream_destroy(Handle);
	}
}
