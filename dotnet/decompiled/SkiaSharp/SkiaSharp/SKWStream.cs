namespace SkiaSharp;

public abstract class SKWStream : SKObject
{
	internal SKWStream(nint handle, bool owns)
		: base(handle, owns)
	{
	}

	public unsafe virtual bool Write(byte[] buffer, int size)
	{
		fixed (byte* buffer2 = buffer)
		{
			return SkiaApi.sk_wstream_write(Handle, buffer2, size);
		}
	}

	public virtual void Flush()
	{
		SkiaApi.sk_wstream_flush(Handle);
	}
}
