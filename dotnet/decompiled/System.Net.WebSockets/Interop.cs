using System.IO.Compression;
using System.Runtime.InteropServices;

internal static class Interop
{
	internal static class ZLib
	{
		[DllImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_DeflateInit2_", ExactSpelling = true)]
		[LibraryImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_DeflateInit2_")]
		internal unsafe static extern ZLibNative.ErrorCode DeflateInit2_(ZLibNative.ZStream* stream, ZLibNative.CompressionLevel level, ZLibNative.CompressionMethod method, int windowBits, int memLevel, ZLibNative.CompressionStrategy strategy);

		[DllImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_Deflate", ExactSpelling = true)]
		[LibraryImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_Deflate")]
		internal unsafe static extern ZLibNative.ErrorCode Deflate(ZLibNative.ZStream* stream, ZLibNative.FlushCode flush);

		[DllImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_DeflateEnd", ExactSpelling = true)]
		[LibraryImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_DeflateEnd")]
		internal unsafe static extern ZLibNative.ErrorCode DeflateEnd(ZLibNative.ZStream* stream);

		[DllImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_InflateInit2_", ExactSpelling = true)]
		[LibraryImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_InflateInit2_")]
		internal unsafe static extern ZLibNative.ErrorCode InflateInit2_(ZLibNative.ZStream* stream, int windowBits);

		[DllImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_Inflate", ExactSpelling = true)]
		[LibraryImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_Inflate")]
		internal unsafe static extern ZLibNative.ErrorCode Inflate(ZLibNative.ZStream* stream, ZLibNative.FlushCode flush);

		[DllImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_InflateEnd", ExactSpelling = true)]
		[LibraryImport("libSystem.IO.Compression.Native", EntryPoint = "CompressionNative_InflateEnd")]
		internal unsafe static extern ZLibNative.ErrorCode InflateEnd(ZLibNative.ZStream* stream);
	}
}
