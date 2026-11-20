using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Ecom;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Extensions;
using Auchan.Common.Recommendations.API;
using Auchan.Common.Recommendations.API.Requests;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Recommendations;

internal class ProductPostService : IProductPostService
{
	private readonly IProductPostApiService _apiService;

	private readonly IDeviceService _deviceService;

	private readonly IEcomContext _ecomContext;

	public ProductPostService(IProductPostApiService apiService, IDeviceService deviceService, IEcomContext ecomContext)
	{
		_apiService = apiService;
		_deviceService = deviceService;
		_ecomContext = ecomContext;
	}

	public async Task<Result<Unit, DomainError>> ProductPost(long gimaId, Product product, CancellationToken token)
	{
		Dictionary<string, string> basketParams = new Dictionary<string, string>
		{
			["priceType"] = product.Price?.UnitType.GetEnumMemberValue() ?? "item",
			["basketStep"] = product.BasketStep.ToString()
		};
		List<string> list = new List<string> { CreateCodesString(product.CategoryCodes) };
		ProductPostRequest obj = new ProductPostRequest
		{
			Link = new Link
			{
				Name = "session",
				Value = _deviceService.Udid
			},
			Timestamp = DateTime.UtcNow,
			ProductId = gimaId,
			StockId = _ecomContext.ActiveStore.Id.ToString(),
			Name = (product.Title ?? ""),
			Price = (product.Price?.Value ?? 0m),
			PictureUrl = "https://www.auchan.ru/f/c/insecure/w:620/plain/" + (product.ImageUrl ?? product.MediaUrls?.FirstOrDefault() ?? ""),
			Url = ((product.Code == null) ? "" : ("https://www.auchan.ru/product/" + product.Code + "/"))
		};
		Stock? stock = product.Stock;
		obj.isAvailable = (object)stock != null && stock.Qty > default(decimal);
		obj.CategoryPaths = list.ToArray();
		obj.description = product.Description?.Content ?? "";
		obj.Vendor = product.BrandName ?? "";
		obj.OldPrice = product.OldPrice?.Value ?? 0m;
		obj.BasketParams = basketParams;
		ProductPostRequest request = obj;
		return await _apiService.ProductPost(request, gimaId.ToString(), token);
	}

	public async Task<Result<Unit, DomainError>> ProductPost(long gimaId, ProductOffer product, CancellationToken token)
	{
		Dictionary<string, string> basketParams = new Dictionary<string, string>
		{
			["priceType"] = product.UnitType.GetEnumMemberValue() ?? "item",
			["basketStep"] = product.BasketStep.ToString()
		};
		List<string> list = new List<string> { CreateCodesString(product.CategoryCodes) };
		ProductPostRequest request = new ProductPostRequest
		{
			Link = new Link
			{
				Name = "session",
				Value = _deviceService.Udid
			},
			Timestamp = DateTime.UtcNow,
			ProductId = gimaId,
			StockId = _ecomContext.ActiveStore.Id.ToString(),
			Name = (product.Name ?? ""),
			Price = product.PricePerOneOrPerKilo,
			PictureUrl = "https://www.auchan.ru/f/c/insecure/w:620/plain/" + product.ImageUrl,
			Url = ((product.Code == null) ? "" : ("https://www.auchan.ru/product/" + product.Code + "/")),
			isAvailable = (product.Qty > 0m),
			CategoryPaths = list.ToArray(),
			description = "",
			Vendor = "",
			OldPrice = product.OldPricePerOneOrPerKilo.GetValueOrDefault(),
			BasketParams = basketParams
		};
		return await _apiService.ProductPost(request, gimaId.ToString(), token);
	}

	private string CreateCodesString(IEnumerable<CategoryCodeDto>? categoryCodeDtos)
	{
		List<CategoryCodeDto> list = (categoryCodeDtos ?? new List<CategoryCodeDto>()).ToList();
		string text = string.Empty;
		for (int i = 0; i < list.Count; i++)
		{
			CategoryCodeDto categoryCodeDto = list[i];
			text += categoryCodeDto.Name;
			if (i != list.Count - 1)
			{
				text += "/";
			}
		}
		return text;
	}
}
