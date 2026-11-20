using System;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Products;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.PriceChecker;

public class PriceChecker(PriceCheckerService priceCheckerService, IUserContext userContext, IAdminContext adminContext, Lazy<IProductsRepository> productsRepository)
{
	public async Task<Result<ValidationResult, ValidationError>> Validate(Store store, string barcode)
	{
		if (!long.TryParse(barcode, out var result))
		{
			return new ValidationError
			{
				Barcode = barcode
			};
		}
		PriceCheckerRequestDto requestDto = new PriceCheckerRequestDto
		{
			Ean = result,
			ClientId = (userContext.Profile?.ClientAccountId ?? ""),
			IsEmployee = (userContext.Profile?.IsAuchanEmployee ?? false),
			MerchantId = store.Id
		};
		Result<PriceCheckerResponseDto, PriceCheckerError> result2 = await priceCheckerService.ProductByEan(requestDto);
		SendAnalytics(store, barcode, result2);
		if (result2.TryGetValue(out var value))
		{
			if (!value.Data.IsOnline)
			{
				return value.Data.Map();
			}
			if ((await productsRepository.Value.GetProductDetailAsync(null, store.Id, value.Data.GimaId, "online", PriceCheckerChannel.Offline)).TryGetValue(out var value2) && value2.IsActive)
			{
				Price? price = value2.Price;
				if ((object)price != null && price.Value > default(decimal))
				{
					return new ValidationResult
					{
						Product = value2,
						IsOnline = true,
						Barcode = barcode
					};
				}
			}
		}
		return new ValidationError
		{
			Barcode = barcode
		};
	}

	private void SendAnalytics(Store store, string barcode, Result<PriceCheckerResponseDto, PriceCheckerError> result)
	{
		if (adminContext.AppConfig.PriceCheckerMWEventsEnabled)
		{
			PriceCheckerMiddleWareEventDto obj = new PriceCheckerMiddleWareEventDto
			{
				Name = "price_check"
			};
			ValueDto valueDto = new ValueDto
			{
				ClientId = (userContext.Profile?.ClientAccountId ?? string.Empty),
				StoreId = store.Id.ToString(),
				Ean = barcode,
				Name = (result.IsSuccess ? result.Value.Data.Name : "")
			};
			int num = ((!result.IsSuccess) ? result.Error.StatusCode : ((!(result.Value.Data == null)) ? 200 : 418));
			valueDto.ResponseCode = num;
			obj.ValueDto = valueDto;
			PriceCheckerMiddleWareEventDto requestDto = obj;
			priceCheckerService.Events(requestDto).SafeFireAndForget((Action<Exception>)null, false);
		}
	}
}
