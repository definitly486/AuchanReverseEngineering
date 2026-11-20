using System;

namespace SkiaSharp.Resources;

public sealed class CachingResourceProvider : ResourceProvider
{
	public CachingResourceProvider(ResourceProvider resourceProvider)
		: base(Create(resourceProvider), owns: true)
	{
		SKObject.Referenced(this, resourceProvider);
	}

	private static nint Create(ResourceProvider resourceProvider)
	{
		if (resourceProvider == null)
		{
			throw new ArgumentNullException("resourceProvider");
		}
		return ResourcesApi.skresources_caching_resource_provider_proxy_make(resourceProvider.Handle);
	}
}
