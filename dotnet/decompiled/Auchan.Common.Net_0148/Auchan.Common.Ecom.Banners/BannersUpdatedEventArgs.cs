using System;
using System.Collections.Generic;
using Auchan.Common.Ecom.Banners.Models;

namespace Auchan.Common.Ecom.Banners;

public sealed class BannersUpdatedEventArgs : EventArgs
{
	public required IReadOnlyDictionary<BannerType, IReadOnlyList<Banner>> Banners { get; init; }
}
