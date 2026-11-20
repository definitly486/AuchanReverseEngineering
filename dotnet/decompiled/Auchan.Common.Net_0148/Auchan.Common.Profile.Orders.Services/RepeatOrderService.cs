using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Analytics;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Extensions;
using Auchan.Common.Managers.Dialogs;
using Auchan.Common.Profile.Orders.Models;
using Auchan.Common.Recommendations;
using Auchan.Common.Recommendations.Models;
using CSharpFunctionalExtensions;
using DryIoc;

namespace Auchan.Common.Profile.Orders.Services;

public class RepeatOrderService
{
	private const string UnsuccessfulRepeatOrder = "Не удалось повторить заказ";

	private readonly IResolver _resolver;

	private readonly IDataBroker _dataBroker;

	private readonly IProductsRepository _productsRepository;

	private readonly IEcomContext _ecomContext;

	private readonly ICurrentStoreSelectDialog _currentStoreSelectDialog;

	private readonly IRecommendationsRepository _recommendationRepository;

	private readonly IInfoMessageService _infoMessageService;

	private readonly Cart _cart;

	private readonly IAgeGateDialog _ageGateDialog;

	private IReadOnlyList<ProductModel> _products = Array.Empty<ProductModel>();

	public UICommand<BrokerToken> NavigateToStaticProductListCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<BrokerToken> NavigateToRepeatPreviousOrderPopup { get; } = new UICommand<BrokerToken>();

	public UICommand ShowRepeatAdultProductWarningCommand { get; } = new UICommand();

	public UICommand NavigateToCartCommand { get; } = new UICommand();

	public event Action<VisualState>? OnStateChanged;

	public event Action? OnShowReplacement;

	public RepeatOrderService(IResolver resolver, IDataBroker dataBroker, IProductsRepository productsRepository, IEcomContext ecomContext, ICurrentStoreSelectDialog currentStoreSelectDialog, IRecommendationsRepository recommendationRepository, IInfoMessageService infoMessageService, Cart cart, IAgeGateDialog ageGateDialog)
	{
		_resolver = resolver;
		_dataBroker = dataBroker;
		_productsRepository = productsRepository;
		_ecomContext = ecomContext;
		_currentStoreSelectDialog = currentStoreSelectDialog;
		_recommendationRepository = recommendationRepository;
		_infoMessageService = infoMessageService;
		_cart = cart;
		_ageGateDialog = ageGateDialog;
	}

	public async Task OpenRepeatOrderPopup(IReadOnlyList<ProductModel> productModels, bool isAdult)
	{
		if (isAdult && _ecomContext.AgeGateAgreement != AgreeState.Yes && await _ageGateDialog.ShowAgeGateDialogAsync() != AgreeState.Yes)
		{
			return;
		}
		_products = productModels;
		this.OnStateChanged?.Invoke(VisualState.InProgress);
		if (isAdult && _ecomContext.ReceivingMethod.IsDelivery())
		{
			ShowRepeatAdultProductWarningCommand.Trigger();
			this.OnStateChanged?.Invoke(VisualState.Default);
			return;
		}
		Result<IReadOnlyList<Product>, DomainError> result = await _productsRepository.GetProductsByGimaIdAsync(_ecomContext.ActiveStore.Id.ToString(), _products.Select((ProductModel x) => x.GimaId));
		if (result.IsFailure)
		{
			this.OnStateChanged?.Invoke(VisualState.Default);
			return;
		}
		List<RepeatOrderProductModel> list = new List<RepeatOrderProductModel>();
		foreach (ProductModel productModel in _products)
		{
			string imagePath = GetPreviewImageUrl(productModel) ?? productModel.ImageUrl ?? "";
			Product product = result.Value.FirstOrDefault((Product p) => p.GimaId == productModel.GimaId);
			if (product != null)
			{
				list.Add(new RepeatOrderProductModel(product)
				{
					QtyInOrder = productModel.Qty,
					ImagePath = imagePath,
					Title = productModel.Name,
					SelectedModifications = GetSelectedModifications(productModel),
					OriginalSelectedModifications = productModel.SelectedModifications
				});
			}
			else
			{
				list.Add(new RepeatOrderProductModel(new Product
				{
					GimaId = productModel.GimaId
				})
				{
					QtyInOrder = productModel.Qty,
					ImagePath = imagePath,
					Title = productModel.Name,
					SelectedModifications = GetSelectedModifications(productModel),
					OriginalSelectedModifications = productModel.SelectedModifications
				});
			}
		}
		RepeatOrderPopupViewModel.Parameter parameter = new RepeatOrderPopupViewModel.Parameter
		{
			Available = list.Where((RepeatOrderProductModel x) => x.IsAvailable).ToList(),
			Unavailable = list.Where((RepeatOrderProductModel x) => !x.IsAvailable).ToList()
		};
		this.OnStateChanged?.Invoke(VisualState.Default);
		NavigateToRepeatPreviousOrderPopup.Trigger(_dataBroker.Push(parameter));
		RepeatOrderPopupViewModel.Result result2 = await parameter.WaitForResultAsync();
		switch (result2.Type)
		{
		case RepeatOrderPopupViewModel.ResultType.Cancel:
			break;
		case RepeatOrderPopupViewModel.ResultType.ShowReplacement:
			await ShowReplacementFor(result2.Products[0].GimaId ?? "");
			break;
		case RepeatOrderPopupViewModel.ResultType.AddToCart:
			AppAnalytics.AppMetrica.TrackEvent("addToCardPreviousOrder");
			_cart.AddItems(result2.Products, Guid.NewGuid());
			_cart.FlushPendingChanges();
			if ((await _cart.WaitForPendingChangesAsync()).IsSuccess)
			{
				NavigateToCartCommand.Trigger();
				await Task.Delay(100);
				_infoMessageService.ShowSnackbar("Товары добавлены в корзину, проверьте их перед оформлением", SnackbarStyle.Success);
			}
			else
			{
				_infoMessageService.ShowSnackbar("Не удалось повторить заказ");
			}
			break;
		default:
			throw new ArgumentOutOfRangeException();
		}
		static string? GetPreviewImageUrl(ProductModel productModel2)
		{
			return productModel2.SelectedModifications.FirstOrDefault((SelectedModification c) => !string.IsNullOrEmpty(c.Value?.PreviewImageUrl))?.Value?.PreviewImageUrl;
		}
		static List<ListItemModificationValueViewModel> GetSelectedModifications(ProductModel productModel2)
		{
			return productModel2.SelectedModifications?.Select((SelectedModification c) => new ListItemModificationValueViewModel(c.Name, c.Value?.Description ?? string.Empty))?.ToList() ?? new List<ListItemModificationValueViewModel>();
		}
	}

	private async Task ShowReplacementFor(string gimaId)
	{
		Result<(IAlgorithm, IReadOnlyList<ProductWithAnalyticsInfo>), DomainError> result = await Task.Run(() => _recommendationRepository.GetFirstAvailableAsync(new global::_003C_003Ez__ReadOnlyArray<IAlgorithm>(new IAlgorithm[2]
		{
			AnalogsOutOfStockProductsAlgorithm.Create(_resolver, new AnalogsOutOfStockProductsArgument
			{
				ProductIds = new global::_003C_003Ez__ReadOnlySingleElementList<string>(gimaId),
				BlockId = "analogs",
				Title = "Замена товара"
			}),
			AlternativesAlgorithm.Create(_resolver, new AlternativesArgument
			{
				ProductIds = new global::_003C_003Ez__ReadOnlySingleElementList<string>(gimaId),
				BlockId = "alternative",
				Title = "Замена товара"
			})
		})));
		(IAlgorithm, IReadOnlyList<ProductWithAnalyticsInfo>) value;
		if (result.TryGetError(out var _))
		{
			this.OnStateChanged?.Invoke(VisualState.InProgress);
			_infoMessageService.ShowSnackbar("Не удалось подобрать товары.");
			await Task.Delay(1500);
			this.OnStateChanged?.Invoke(VisualState.Default);
			await OpenRepeatOrderPopup(_products, isAdult: false);
		}
		else if (result.TryGetValue(out value))
		{
			IReadOnlyList<ProductWithAnalyticsInfo> item = value.Item2;
			if (item.Count == 0)
			{
				this.OnStateChanged?.Invoke(VisualState.InProgress);
				_infoMessageService.ShowSnackbar("Не удалось подобрать товары.");
				await Task.Delay(1500);
				this.OnStateChanged?.Invoke(VisualState.Default);
				await OpenRepeatOrderPopup(_products, isAdult: false);
			}
			else
			{
				NavigateToStaticProductListCommand.Trigger(_dataBroker.Push(new StaticProductListViewModel.Parameter
				{
					Title = "Замена товара",
					Items = item
				}));
				this.OnShowReplacement?.Invoke();
			}
		}
	}

	public async Task ShowAddressSelection()
	{
		await _currentStoreSelectDialog.ShowSelectAddressDialog(new AddressViewModel.Parameter
		{
			ReceivingMethod = ReceivingMethod.Pickup
		});
		if (!_ecomContext.ReceivingMethod.IsDelivery())
		{
			await OpenRepeatOrderPopup(_products, isAdult: false);
		}
	}
}
