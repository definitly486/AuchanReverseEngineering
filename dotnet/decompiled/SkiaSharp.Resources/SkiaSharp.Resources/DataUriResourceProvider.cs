using System;

namespace SkiaSharp.Resources;

public sealed class DataUriResourceProvider : ResourceProvider
{
	public DataUriResourceProvider(bool preDecode = false)
		: this(null, preDecode)
	{
	}

	public DataUriResourceProvider(ResourceProvider? fallbackProvider, bool preDecode = false)
		: base(Create(fallbackProvider, preDecode), owns: true)
	{
		SKObject.Referenced(this, fallbackProvider);
	}

	private static nint Create(ResourceProvider? fallbackProvider, bool preDecode = false)
	{
		return ResourcesApi.skresources_data_uri_resource_provider_proxy_make(fallbackProvider?.Handle ?? IntPtr.Zero, preDecode);
	}
}
