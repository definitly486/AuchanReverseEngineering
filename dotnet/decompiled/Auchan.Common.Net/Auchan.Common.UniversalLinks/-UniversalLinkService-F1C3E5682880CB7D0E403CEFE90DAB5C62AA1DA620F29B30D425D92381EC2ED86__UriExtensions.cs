using System;

namespace Auchan.Common.UniversalLinks;

internal static class _003CUniversalLinkService_003EF1C3E5682880CB7D0E403CEFE90DAB5C62AA1DA620F29B30D425D92381EC2ED86__UriExtensions
{
	public static string CleanupLocalPath(this Uri @this)
	{
		return @this.LocalPath.Trim('/');
	}
}
