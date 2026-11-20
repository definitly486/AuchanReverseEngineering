using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Extensions;
using Auchan.Common.UniversalLinks;

namespace Auchan.Common.Ecom;

internal sealed class PromoDiscountUsecase : IPromoDiscountUsecase
{
	private string? _tooltip;

	private bool _bindingCompleted;

	private readonly Lazy<Auchan.Common.Ecom.Cart.Cart> _cart;

	private readonly Lazy<IUniversalLinksService> _universalLinksService;

	private readonly Lazy<IInfoMessageService> _infoMessageService;

	private readonly Lazy<IFullScreenDialogState> _fullScreenDialogState;

	public PromoDiscountUsecase(Lazy<Auchan.Common.Ecom.Cart.Cart> cart, Lazy<IUniversalLinksService> universalLinksService, Lazy<IInfoMessageService> infoMessageService, Lazy<IFullScreenDialogState> fullScreenDialogState)
	{
		_cart = cart;
		_universalLinksService = universalLinksService;
		_infoMessageService = infoMessageService;
		_fullScreenDialogState = fullScreenDialogState;
	}

	public void ProcessOfferChange(ProductOfferChange change, IPromoDiscountUsecaseSupport support, ICollection<IDisposable> disposables)
	{
		if (change.PromotionApplied)
		{
			_infoMessageService.Value.ShowSnackbar("Акция на товар применена", SnackbarStyle.Success);
		}
		else if (!string.IsNullOrEmpty(change.PromotionTooltip) && !_fullScreenDialogState.Value.IsVisible)
		{
			BindIfNeed(support, disposables);
			_tooltip = change.PromotionTooltip;
			support.ShowPromoTooltipCommand.Trigger(LinkedText.FromTextWithHref(change.PromotionTooltip, (Action<string>)delegate
			{
				GotoTooltipLink(change.PromotionTooltip);
			}));
		}
	}

	public async Task ProcessComboSuggection(ProductOffer offer, IPromoDiscountUsecaseSupport support, ICollection<IDisposable> disposables)
	{
		if (!(await _cart.Value.GetComboSuggestionsAsync(offer)).TryGetValue(out var value))
		{
			return;
		}
		switch (value.Status)
		{
		case ComboSuggestionStatus.Partial:
			if (_fullScreenDialogState.Value.IsVisible)
			{
				_tooltip = value.Tooltip;
				BindIfNeed(support, disposables);
				support.ShowPromoTooltipCommand.Trigger(LinkedText.FromTextWithHref(value.Tooltip, delegate(string link)
				{
					GotoTooltipLink(link);
				}));
			}
			break;
		case ComboSuggestionStatus.Fulfilled:
			_infoMessageService.Value.ShowSnackbar("Акция на товар применена", SnackbarStyle.Success);
			break;
		}
	}

	private void BindIfNeed(IPromoDiscountUsecaseSupport support, ICollection<IDisposable> disposables)
	{
		if (!_bindingCompleted)
		{
			_bindingCompleted = true;
			support.GotoTooltipLinkCommand.Subscribe(delegate
			{
				OnGotoTooltipLinkCommand();
			}).AddTo(disposables);
		}
	}

	private void OnGotoTooltipLinkCommand()
	{
		if (_tooltip != null)
		{
			string item = LinkedText.ExtractHtmlParts(_tooltip).Link;
			GotoTooltipLink(item);
		}
	}

	private void GotoTooltipLink(string link)
	{
		if (_universalLinksService.Value.ShouldHandleLink(link))
		{
			_universalLinksService.Value.HandleLink(link);
		}
	}
}
