using System;
using Auchan.Common.Base;
using Auchan.Common.Ecom.CtmShelves.Models;

namespace Auchan.Common.Ecom.CtmShelves.ViewModels;

public sealed class CtmBannerItemViewModel : BaseItemViewModel
{
	private readonly Shelf _shelf;

	public ShelfBanner Banner => _shelf.Banner ?? throw new NotImplementedException("dead code");

	public bool IsButtonVisible => Banner.Button != null;

	public CtmBannerItemViewModel(Shelf shelf)
	{
		if (shelf.Banner == null)
		{
			throw new ArgumentException("Banner is null");
		}
		_shelf = shelf;
	}

	public void OnClick()
	{
		Banner.Button?.ButtonLink.Activate(_shelf);
	}
}
