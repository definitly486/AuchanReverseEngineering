using System;
using System.IO;
using SkiaSharp.Resources;

namespace SkiaSharp.Skottie;

public sealed class AnimationBuilder : SKObject, ISKSkipObjectRegistration
{
	internal AnimationBuilder(AnimationBuilderFlags flags)
		: this(SkottieApi.skottie_animation_builder_new(flags), owns: true)
	{
	}

	internal AnimationBuilder(nint handle, bool owns)
		: base(handle, owns)
	{
	}

	public AnimationBuilder SetResourceProvider(ResourceProvider resourceProvider)
	{
		if (resourceProvider == null)
		{
			throw new ArgumentNullException("resourceProvider");
		}
		SkottieApi.skottie_animation_builder_set_resource_provider(Handle, resourceProvider.Handle);
		SKObject.Referenced(this, resourceProvider);
		return this;
	}

	public Animation? Build(Stream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		using SKData data = SKData.Create(stream);
		return Build(data);
	}

	public unsafe Animation? Build(SKData data)
	{
		if (data == null)
		{
			throw new ArgumentNullException("data");
		}
		int preambleSize = Utils.GetPreambleSize(data);
		ReadOnlySpan<byte> readOnlySpan = data.AsSpan().Slice(preambleSize);
		fixed (byte* data2 = readOnlySpan)
		{
			try
			{
				return Animation.GetObject(SkottieApi.skottie_animation_builder_make_from_data(Handle, data2, readOnlySpan.Length));
			}
			finally
			{
				GC.KeepAlive(data);
			}
		}
	}

	protected override void DisposeNative()
	{
		SkottieApi.skottie_animation_builder_delete(Handle);
	}
}
