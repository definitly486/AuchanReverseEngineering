using System;
using System.IO;

namespace SkiaSharp;

public class SKData : SKObject, ISKNonVirtualReferenceCounted, ISKReferenceCounted
{
	private sealed class SKDataStatic : SKData
	{
		internal SKDataStatic(nint x)
			: base(x, owns: false)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}

	private static readonly SKData empty;

	public long Size => SkiaApi.sk_data_get_size(Handle);

	public unsafe nint Data => (nint)SkiaApi.sk_data_get_data(Handle);

	static SKData()
	{
		empty = new SKDataStatic(SkiaApi.sk_data_new_empty());
	}

	internal static void EnsureStaticInstanceAreInitialized()
	{
	}

	internal SKData(nint x, bool owns)
		: base(x, owns)
	{
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	void ISKNonVirtualReferenceCounted.UnreferenceNative()
	{
		SkiaApi.sk_data_unref(Handle);
	}

	public static SKData Create(Stream stream)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		if (stream.CanSeek)
		{
			return Create(stream, stream.Length - stream.Position);
		}
		using SKDynamicMemoryWStream sKDynamicMemoryWStream = new SKDynamicMemoryWStream();
		using (SKManagedStream sKManagedStream = new SKManagedStream(stream))
		{
			sKManagedStream.CopyTo(sKDynamicMemoryWStream);
		}
		return sKDynamicMemoryWStream.DetachAsData();
	}

	public static SKData Create(Stream stream, long length)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		using SKManagedStream stream2 = new SKManagedStream(stream);
		return Create(stream2, length);
	}

	public static SKData Create(SKStream stream, long length)
	{
		if (stream == null)
		{
			throw new ArgumentNullException("stream");
		}
		try
		{
			return GetObject(SkiaApi.sk_data_new_from_stream(stream.Handle, (nint)length));
		}
		finally
		{
			GC.KeepAlive(stream);
		}
	}

	public unsafe ReadOnlySpan<byte> AsSpan()
	{
		return new ReadOnlySpan<byte>((void*)Data, (int)Size);
	}

	internal static SKData GetObject(nint handle)
	{
		return SKObject.GetOrAddObject(handle, (nint h, bool o) => new SKData(h, o));
	}
}
