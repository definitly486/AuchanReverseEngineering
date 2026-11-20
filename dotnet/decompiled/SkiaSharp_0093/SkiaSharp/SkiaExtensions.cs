using System;

namespace SkiaSharp;

public static class SkiaExtensions
{
	public static int GetBytesPerPixel(this SKColorType colorType)
	{
		return colorType switch
		{
			SKColorType.Unknown => 0, 
			SKColorType.Alpha8 => 1, 
			SKColorType.Gray8 => 1, 
			SKColorType.R8Unorm => 1, 
			SKColorType.Rgb565 => 2, 
			SKColorType.Argb4444 => 2, 
			SKColorType.Rg88 => 2, 
			SKColorType.Alpha16 => 2, 
			SKColorType.AlphaF16 => 2, 
			SKColorType.Bgra8888 => 4, 
			SKColorType.Bgra1010102 => 4, 
			SKColorType.Bgr101010x => 4, 
			SKColorType.Bgr101010xXR => 4, 
			SKColorType.Rgba8888 => 4, 
			SKColorType.Rgb888x => 4, 
			SKColorType.Rgba1010102 => 4, 
			SKColorType.Rgb101010x => 4, 
			SKColorType.Rg1616 => 4, 
			SKColorType.RgF16 => 4, 
			SKColorType.Srgba8888 => 4, 
			SKColorType.RgbaF16Clamped => 8, 
			SKColorType.RgbaF16 => 8, 
			SKColorType.Rgba16161616 => 8, 
			SKColorType.Rgba10x6 => 8, 
			SKColorType.RgbaF32 => 16, 
			_ => throw new ArgumentOutOfRangeException("colorType", $"Unknown color type: '{colorType}'"), 
		};
	}

	internal static SKColorTypeNative ToNative(this SKColorType colorType)
	{
		return colorType switch
		{
			SKColorType.Unknown => SKColorTypeNative.Unknown, 
			SKColorType.Alpha8 => SKColorTypeNative.Alpha8, 
			SKColorType.Rgb565 => SKColorTypeNative.Rgb565, 
			SKColorType.Argb4444 => SKColorTypeNative.Argb4444, 
			SKColorType.Rgba8888 => SKColorTypeNative.Rgba8888, 
			SKColorType.Rgb888x => SKColorTypeNative.Rgb888x, 
			SKColorType.Bgra8888 => SKColorTypeNative.Bgra8888, 
			SKColorType.Rgba1010102 => SKColorTypeNative.Rgba1010102, 
			SKColorType.Rgb101010x => SKColorTypeNative.Rgb101010x, 
			SKColorType.Gray8 => SKColorTypeNative.Gray8, 
			SKColorType.RgbaF16Clamped => SKColorTypeNative.RgbaF16Norm, 
			SKColorType.RgbaF16 => SKColorTypeNative.RgbaF16, 
			SKColorType.RgbaF32 => SKColorTypeNative.RgbaF32, 
			SKColorType.Rg88 => SKColorTypeNative.R8g8Unorm, 
			SKColorType.AlphaF16 => SKColorTypeNative.A16Float, 
			SKColorType.RgF16 => SKColorTypeNative.R16g16Float, 
			SKColorType.Alpha16 => SKColorTypeNative.A16Unorm, 
			SKColorType.Rg1616 => SKColorTypeNative.R16g16Unorm, 
			SKColorType.Rgba16161616 => SKColorTypeNative.R16g16b16a16Unorm, 
			SKColorType.Rgba10x6 => SKColorTypeNative.Rgba10x6, 
			SKColorType.Bgra1010102 => SKColorTypeNative.Bgra1010102, 
			SKColorType.Bgr101010x => SKColorTypeNative.Bgr101010x, 
			SKColorType.Bgr101010xXR => SKColorTypeNative.Bgr101010xXr, 
			SKColorType.Srgba8888 => SKColorTypeNative.Srgba8888, 
			SKColorType.R8Unorm => SKColorTypeNative.R8Unorm, 
			_ => throw new ArgumentOutOfRangeException("colorType", $"Unknown color type: '{colorType}'"), 
		};
	}

	internal static SKColorType FromNative(this SKColorTypeNative colorType)
	{
		return colorType switch
		{
			SKColorTypeNative.Unknown => SKColorType.Unknown, 
			SKColorTypeNative.Alpha8 => SKColorType.Alpha8, 
			SKColorTypeNative.Rgb565 => SKColorType.Rgb565, 
			SKColorTypeNative.Argb4444 => SKColorType.Argb4444, 
			SKColorTypeNative.Rgba8888 => SKColorType.Rgba8888, 
			SKColorTypeNative.Rgb888x => SKColorType.Rgb888x, 
			SKColorTypeNative.Bgra8888 => SKColorType.Bgra8888, 
			SKColorTypeNative.Rgba1010102 => SKColorType.Rgba1010102, 
			SKColorTypeNative.Rgb101010x => SKColorType.Rgb101010x, 
			SKColorTypeNative.Gray8 => SKColorType.Gray8, 
			SKColorTypeNative.RgbaF16Norm => SKColorType.RgbaF16Clamped, 
			SKColorTypeNative.RgbaF16 => SKColorType.RgbaF16, 
			SKColorTypeNative.RgbaF32 => SKColorType.RgbaF32, 
			SKColorTypeNative.R8g8Unorm => SKColorType.Rg88, 
			SKColorTypeNative.A16Float => SKColorType.AlphaF16, 
			SKColorTypeNative.R16g16Float => SKColorType.RgF16, 
			SKColorTypeNative.A16Unorm => SKColorType.Alpha16, 
			SKColorTypeNative.R16g16Unorm => SKColorType.Rg1616, 
			SKColorTypeNative.R16g16b16a16Unorm => SKColorType.Rgba16161616, 
			SKColorTypeNative.Rgba10x6 => SKColorType.Rgba10x6, 
			SKColorTypeNative.Bgra1010102 => SKColorType.Bgra1010102, 
			SKColorTypeNative.Bgr101010x => SKColorType.Bgr101010x, 
			SKColorTypeNative.Bgr101010xXr => SKColorType.Bgr101010xXR, 
			SKColorTypeNative.Srgba8888 => SKColorType.Srgba8888, 
			SKColorTypeNative.R8Unorm => SKColorType.R8Unorm, 
			_ => throw new ArgumentOutOfRangeException("colorType", $"Unknown color type: '{colorType}'"), 
		};
	}

	public static uint ToGlSizedFormat(this SKColorType colorType)
	{
		return colorType switch
		{
			SKColorType.Unknown => 0u, 
			SKColorType.Alpha8 => 32828u, 
			SKColorType.Gray8 => 32832u, 
			SKColorType.Rgb565 => 36194u, 
			SKColorType.Argb4444 => 32854u, 
			SKColorType.Rgba8888 => 32856u, 
			SKColorType.Rgb888x => 32849u, 
			SKColorType.Bgra8888 => 37793u, 
			SKColorType.Rgba1010102 => 32857u, 
			SKColorType.AlphaF16 => 33325u, 
			SKColorType.RgbaF16 => 34842u, 
			SKColorType.RgbaF16Clamped => 34842u, 
			SKColorType.Alpha16 => 33322u, 
			SKColorType.Rg1616 => 33324u, 
			SKColorType.Rgba16161616 => 32859u, 
			SKColorType.Rgba10x6 => 0u, 
			SKColorType.RgF16 => 33327u, 
			SKColorType.Rg88 => 33323u, 
			SKColorType.Rgb101010x => 0u, 
			SKColorType.RgbaF32 => 0u, 
			SKColorType.Bgra1010102 => 0u, 
			SKColorType.Bgr101010x => 0u, 
			SKColorType.Bgr101010xXR => 0u, 
			SKColorType.Srgba8888 => 35907u, 
			SKColorType.R8Unorm => 33321u, 
			_ => throw new ArgumentOutOfRangeException("colorType", $"Unknown color type: '{colorType}'"), 
		};
	}
}
