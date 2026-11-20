using System.Runtime.Versioning;

namespace Android.Graphics;

public enum ImageFormatType
{
	[SupportedOSPlatform("android29.0")]
	DepthJpeg = 1768253795,
	[SupportedOSPlatform("android23.0")]
	DepthPointCloud = 257,
	[SupportedOSPlatform("android23.0")]
	Depth16 = 1144402265,
	[SupportedOSPlatform("android23.0")]
	FlexRgb888 = 41,
	[SupportedOSPlatform("android23.0")]
	FlexRgba8888 = 42,
	[SupportedOSPlatform("android29.0")]
	Heic = 1212500294,
	[SupportedOSPlatform("android36.0")]
	HeicUltrahdr = 4102,
	Jpeg = 256,
	[SupportedOSPlatform("android34.0")]
	JpegR = 4101,
	Nv16 = 16,
	Nv21 = 17,
	[SupportedOSPlatform("android23.0")]
	Private = 34,
	[SupportedOSPlatform("android24.0")]
	RawPrivate = 36,
	RawSensor = 32,
	Raw10 = 37,
	[SupportedOSPlatform("android23.0")]
	Raw12 = 38,
	Rgb565 = 4,
	Unknown = 0,
	[SupportedOSPlatform("android29.0")]
	Y8 = 538982489,
	[SupportedOSPlatform("android31.0")]
	YcbcrP010 = 54,
	[SupportedOSPlatform("android36.0")]
	YcbcrP210 = 60,
	Yuv420888 = 35,
	[SupportedOSPlatform("android23.0")]
	Yuv422888 = 39,
	[SupportedOSPlatform("android23.0")]
	Yuv444888 = 40,
	Yuy2 = 20,
	Yv12 = 842094169
}
