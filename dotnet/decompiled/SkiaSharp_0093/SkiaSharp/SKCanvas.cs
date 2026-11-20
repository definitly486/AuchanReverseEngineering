using System;

namespace SkiaSharp;

public class SKCanvas : SKObject
{
	public GRRecordingContext? Context => GRRecordingContext.GetObject(SkiaApi.sk_get_recording_context(Handle), owns: false, unrefExisting: false);

	public int SaveCount => SkiaApi.sk_canvas_get_save_count(Handle);

	internal SKCanvas(nint handle, bool owns)
		: base(handle, owns)
	{
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	protected override void DisposeNative()
	{
		SkiaApi.sk_canvas_destroy(Handle);
	}

	public int Save()
	{
		if (Handle == IntPtr.Zero)
		{
			throw new ObjectDisposedException("SKCanvas");
		}
		return SkiaApi.sk_canvas_save(Handle);
	}

	public void Clear(SKColor color)
	{
		SkiaApi.sk_canvas_clear(Handle, (uint)color);
	}

	public void RestoreToCount(int count)
	{
		SkiaApi.sk_canvas_restore_to_count(Handle, count);
	}

	public void Scale(float s)
	{
		if (s != 1f)
		{
			SkiaApi.sk_canvas_scale(Handle, s, s);
		}
	}

	public void Flush()
	{
		(Context as GRContext)?.Flush();
	}

	internal static SKCanvas GetObject(nint handle, bool owns = true, bool unrefExisting = true)
	{
		return SKObject.GetOrAddObject(handle, owns, unrefExisting, (nint h, bool o) => new SKCanvas(h, o));
	}
}
