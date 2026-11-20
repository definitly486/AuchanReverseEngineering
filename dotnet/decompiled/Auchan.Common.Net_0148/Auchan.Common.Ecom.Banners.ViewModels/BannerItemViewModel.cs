using System;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Banners.Models;

namespace Auchan.Common.Ecom.Banners.ViewModels;

public sealed class BannerItemViewModel : BaseItemViewModel, IEquatable<BannerItemViewModel>, IIdentifiable
{
	public Banner Banner { get; }

	public int Position { get; }

	public BannerItemViewModel(Banner banner, int position)
	{
		Banner = banner;
		Position = position;
	}

	public bool Equals(BannerItemViewModel? other)
	{
		if (other == null)
		{
			return false;
		}
		return Banner.Equals(other.Banner);
	}

	string IIdentifiable.GetId()
	{
		return $"banner:{Banner.Id}";
	}
}
