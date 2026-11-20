using System;
using System.Reflection;

namespace SkiaSharp;

[DefaultMember("Item")]
public class SKPath : SKObject, ISKSkipObjectRegistration
{
	internal SKPath(nint handle, bool owns)
		: base(handle, owns)
	{
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
	}

	protected override void DisposeNative()
	{
		SkiaApi.sk_path_delete(Handle);
	}

	internal static SKPath GetObject(nint handle, bool owns = true)
	{
		if (handle != IntPtr.Zero)
		{
			return new SKPath(handle, owns);
		}
		return null;
	}
}
