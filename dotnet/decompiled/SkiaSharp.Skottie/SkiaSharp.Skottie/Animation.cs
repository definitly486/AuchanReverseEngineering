using System;
using SkiaSharp.SceneGraph;

namespace SkiaSharp.Skottie;

public class Animation : SKObject, ISKNonVirtualReferenceCounted, ISKReferenceCounted, ISKSkipObjectRegistration
{
	public TimeSpan Duration => TimeSpan.FromSeconds(SkottieApi.skottie_animation_get_duration(Handle));

	public unsafe SKSize Size
	{
		get
		{
			SKSize result = default(SKSize);
			SkottieApi.skottie_animation_get_size(Handle, &result);
			return result;
		}
	}

	internal Animation(nint handle, bool owns)
		: base(handle, owns)
	{
	}

	void ISKNonVirtualReferenceCounted.UnreferenceNative()
	{
		SkottieApi.skottie_animation_unref(Handle);
	}

	protected override void DisposeNative()
	{
		SkottieApi.skottie_animation_delete(Handle);
	}

	public static AnimationBuilder CreateBuilder(AnimationBuilderFlags flags = AnimationBuilderFlags.None)
	{
		return new AnimationBuilder(flags);
	}

	public unsafe void Render(SKCanvas canvas, SKRect dst)
	{
		SkottieApi.skottie_animation_render(Handle, canvas.Handle, &dst);
	}

	public void SeekFrameTime(double seconds, InvalidationController? ic = null)
	{
		SkottieApi.skottie_animation_seek_frame_time(Handle, (float)seconds, ic?.Handle ?? IntPtr.Zero);
	}

	public void SeekFrameTime(TimeSpan time, InvalidationController? ic = null)
	{
		SeekFrameTime(time.TotalSeconds, ic);
	}

	internal static Animation? GetObject(nint handle)
	{
		if (handle != IntPtr.Zero)
		{
			return new Animation(handle, owns: true);
		}
		return null;
	}
}
