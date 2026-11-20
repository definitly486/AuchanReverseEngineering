using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Analytics.Digenetica.DTO;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Extensions;
using Auchan.Common.PersonalCabinet;
using Newtonsoft.Json;

namespace Auchan.Common.Analytics.Digenetica;

internal class DigeneticaAnalytics : IDigeneticaAnalytics
{
	private const string API_KEY = "06U4652632";

	private const string CHANNEL = "MOBILE_APP";

	private readonly Lazy<IDigeneticaApi> _api;

	private readonly Lazy<IUserContext> _userContext;

	private readonly Lazy<IEcomContext> _ecomContext;

	private readonly Lazy<IAdminContext> _adminContext;

	public DigeneticaAnalytics(Lazy<IDigeneticaApi> api, Lazy<IUserContext> userContext, Lazy<IEcomContext> ecomContext, Lazy<IAdminContext> adminContext)
	{
		_api = api;
		_userContext = userContext;
		_ecomContext = ecomContext;
		_adminContext = adminContext;
	}

	public void ViewHome()
	{
		SendEvent(GetBaseEventDTO<BaseEventDTO>("HOME_PAGE_VIEW"));
	}

	public void ViewProduct(Product product, IReadOnlyList<string>? breadcrumbs)
	{
		ProductDetailsDTO baseEventDTO = GetBaseEventDTO<ProductDetailsDTO>("PRODUCT_VIEW");
		baseEventDTO.Availability = (product.Stock?.Qty ?? 0m) > 0m;
		baseEventDTO.ProductId = product.GimaId ?? string.Empty;
		baseEventDTO.Breadcrumbs = breadcrumbs;
		baseEventDTO.ProductName = product.Title ?? "";
		SendEvent(baseEventDTO);
	}

	public void ViewProduct(long gimaId, string productName)
	{
		ProductDetailsDTO baseEventDTO = GetBaseEventDTO<ProductDetailsDTO>("PRODUCT_VIEW");
		baseEventDTO.Availability = true;
		baseEventDTO.ProductId = gimaId.ToString();
		baseEventDTO.ProductName = productName;
		SendEvent(baseEventDTO);
	}

	public void ViewProductsListing(long categoryId, int page, string categoryName, IReadOnlyList<Product> products, IReadOnlyList<string> breadcrumbs)
	{
		CategoryDTO baseEventDTO = GetBaseEventDTO<CategoryDTO>("CATEGORY_VIEW");
		baseEventDTO.Page = page.ToString();
		baseEventDTO.CategoryId = categoryId.ToString();
		baseEventDTO.ProductIds = products.Select((Product p) => p.GimaId ?? string.Empty).ToImmutableList();
		baseEventDTO.Breadcrumbs = breadcrumbs;
		baseEventDTO.CategoryName = categoryName;
		SendEvent(baseEventDTO);
	}

	public void Search(string query, int page, IReadOnlyList<Product> products)
	{
		SearchDTO baseEventDTO = GetBaseEventDTO<SearchDTO>("SEARCH_EVENT");
		baseEventDTO.Query = query;
		baseEventDTO.Page = page.ToString();
		baseEventDTO.ProductIds = products.SelectNotNull((Product p) => p.GimaId).ToImmutableList();
		SendEvent(baseEventDTO);
	}

	public void ViewCart(decimal total, decimal subtotal, Guid cartId, IReadOnlyList<ProductOffer> products)
	{
		if (!(total <= 0m) && !(subtotal <= 0m))
		{
			CartDTO baseEventDTO = GetBaseEventDTO<CartDTO>("CART_VIEW");
			baseEventDTO.Total = total.ToString("F2", CultureInfo.InvariantCulture);
			baseEventDTO.Subtotal = subtotal.ToString("F2", CultureInfo.InvariantCulture);
			baseEventDTO.CartId = cartId.ToString();
			baseEventDTO.CartItems = (from p in products
				let st = p.Price * p.Qty
				where st > 0m
				select new CartItemDTO
				{
					ProductId = (p.GimaId ?? string.Empty),
					Price = ((p.OldPrice.HasValue && p.OldPrice.Value != 0m) ? p.OldPrice.Value.ToString("F2", CultureInfo.InvariantCulture) : p.Price.ToString("F2", CultureInfo.InvariantCulture)),
					SalePrice = p.Price.ToString("F2", CultureInfo.InvariantCulture),
					ProductName = p.Name,
					Quantity = Convert.ToInt64(Math.Floor(p.Qty / p.BasketStep)),
					Subtotal = st.ToString("F2", CultureInfo.InvariantCulture)
				}).ToImmutableList();
			SendEvent(baseEventDTO);
		}
	}

	public void OrderSuccess(Guid cartId, IReadOnlyList<OrderDetailsDto> orderDetails)
	{
		foreach (OrderDetailsDto orderDetail in orderDetails)
		{
			if ((orderDetail.Deliveries?.Count ?? 0) < 1)
			{
				continue;
			}
			foreach (Delivery delivery in orderDetail.Deliveries)
			{
				foreach (ProductShort product in delivery.Products)
				{
					ViewProduct(product.AuchanCode, product.Name);
				}
			}
			OrderSuccessDTO baseEventDTO = GetBaseEventDTO<OrderSuccessDTO>("ORDER_SUCCESS");
			decimal num = default(decimal);
			if ((orderDetail.Payments?.Count ?? 0) > 0)
			{
				num = orderDetail.Payments.First().Sum.Value;
			}
			baseEventDTO.Total = num.ToString("F2", CultureInfo.InvariantCulture);
			baseEventDTO.Subtotal = num.ToString("F2", CultureInfo.InvariantCulture);
			baseEventDTO.OrderId = orderDetail.Order.Id.ToString();
			baseEventDTO.CartId = cartId.ToString();
			baseEventDTO.CartItems = orderDetail.Deliveries.First().Products.Select((ProductShort p) => new CartItemDTO
			{
				ProductId = p.AuchanCode.ToString(),
				Price = (p.Price / p.Qty).ToString("F2", CultureInfo.InvariantCulture),
				SalePrice = (p.Price / p.Qty).ToString("F2", CultureInfo.InvariantCulture),
				ProductName = p.Name,
				Quantity = Convert.ToInt64(Math.Floor(p.Qty / p.BasketStep)),
				Subtotal = p.Price.ToString("F2", CultureInfo.InvariantCulture)
			}).ToImmutableList();
			SendEvent(baseEventDTO);
		}
	}

	private void SendEvent(object body)
	{
		AppConfig appConfig = _adminContext.Value.AppConfig;
		if (appConfig != null && appConfig.DigeneticaEnabled)
		{
			Task.Run(() => SendEventAsync(JsonConvert.SerializeObject(body))).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private async Task SendEventAsync(string serializedBody)
	{
		try
		{
			await _api.Value.TrackEvent(serializedBody);
		}
		catch (Exception)
		{
		}
	}

	private T GetBaseEventDTO<T>(string eventType) where T : BaseEventDTO, new()
	{
		return new T
		{
			EventType = eventType,
			SessionId = _userContext.Value.SessionId,
			UserGUID = _userContext.Value.UserGUID,
			UserId = _userContext.Value.Profile?.ClientAccountId,
			RegionId = _ecomContext.Value.ActiveStore.Id.ToString(),
			ApiKey = "06U4652632",
			Channel = "MOBILE_APP"
		};
	}
}
