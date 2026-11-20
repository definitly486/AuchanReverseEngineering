using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Cart;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.Extensions;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Ecom.Products.ViewModels;
using CSharpFunctionalExtensions;
using Microsoft.Maui.Devices;
using Newtonsoft.Json;

namespace Auchan.Common.Streams;

public class StreamViewModel : ScreenViewModel
{
	public class Parameter
	{
		public string? StreamUrl { get; set; }

		[JsonConstructor]
		public Parameter()
		{
		}

		public Parameter(string applicationID, string streamId)
		{
			StreamUrl = ((DeviceInfo.Platform == DevicePlatform.iOS || DeviceInfo.Platform == DevicePlatform.Android) ? ("https://app.shopstory.live/sdk/?wv=1&x-force-appid=" + applicationID + "#/translation/" + streamId) : ("https://app.shopstory.live/sdk/?x-force-appid=$" + applicationID + "#/translation/$" + streamId));
		}
	}

	public enum VisualState
	{
		Default,
		InProgress,
		Error
	}

	private readonly IProductsRepository _productsRepository;

	private readonly IEcomContext _ecomContext;

	private readonly Cart _cart;

	private readonly CheckProductUseCase _checkUseCase;

	private readonly TaskQueue _addItemQueue = new TaskQueue();

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	public readonly string Title = "LIVE";

	public readonly string ErrorTitle = "Упс! Что-то пошло не так.";

	public readonly string ErrorMessage = "Небольшие технические проблемы,\nпопробуйте обновить экран.";

	public readonly string StreamUrl;

	public readonly UICommand<ProductDetailsViewModel.Parameter, ProductDetailsViewModel.Parameter> NavigateToProductDetailsCommand = new UICommand<ProductDetailsViewModel.Parameter, ProductDetailsViewModel.Parameter>((ProductDetailsViewModel.Parameter p) => p);

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	}

	public StreamViewModel(Parameter parameter, IProductsRepository productsRepository, IEcomContext ecomContext, Cart cart, CheckProductUseCase checkUseCase)
	{
		_productsRepository = productsRepository;
		_ecomContext = ecomContext;
		_cart = cart;
		_checkUseCase = checkUseCase;
		StreamUrl = parameter.StreamUrl;
	}

	public void OnError()
	{
		State = VisualState.Error;
	}

	public void OnRetry()
	{
		State = VisualState.Default;
	}

	public async Task OnAddProductClicked(StreamsDtos.ProductJSDto productJsDto)
	{
		if (productJsDto.FeedProductId == null)
		{
			return;
		}
		int id = _ecomContext.ActiveStore.Id;
		Result<IReadOnlyList<Product>, DomainError> result = await _productsRepository.GetProductsByGimaIdAsync(id.ToString(), new string[1] { productJsDto.FeedProductId });
		if (!result.IsSuccess)
		{
			return;
		}
		Product product = result.Value.FirstOrDefault();
		if (product != null)
		{
			_addItemQueue.Enqueue(() => AddOneItemToCartAsync(product)).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private async Task AddOneItemToCartAsync(Product product)
	{
		decimal value = (product.Modifications.Any() ? _cart.Items.Where((ProductOffer i) => i.Id == product.Id).Sum((ProductOffer c) => c.Qty) : (_cart.Items.FirstOrDefault((ProductOffer i) => i.Id == product.Id)?.Qty ?? 0m));
		ProductOffer productOffer = product.CreateOffer(value, new List<SelectedModification>());
		if (await _checkUseCase.CanAdd(product, productOffer))
		{
			_cart.AddItem(productOffer, Guid.NewGuid());
			_cart.Update(Guid.NewGuid()).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public async Task OnOpenProductClicked(StreamsDtos.ProductJSDto productJsDto)
	{
		if (productJsDto.FeedProductId == null)
		{
			return;
		}
		int id = _ecomContext.ActiveStore.Id;
		Result<IReadOnlyList<Product>, DomainError> result = await _productsRepository.GetProductsByGimaIdAsync(id.ToString(), new string[1] { productJsDto.FeedProductId });
		if (result.IsSuccess)
		{
			Product product = result.Value.FirstOrDefault();
			if (product != null)
			{
				NavigateToProductDetailsCommand.Trigger(new ProductDetailsViewModel.Parameter(product));
			}
		}
	}
}
