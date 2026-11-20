using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Net;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Ecom.Cart.Errors;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.Cart.StampsWithdraw;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Cart;

public class RemoteCartService
{
	private readonly IEcomApi _api;

	private readonly IRequestExecutor _requestExecutor;

	public RemoteCartService(IEcomApi api, IRequestExecutor requestExecutor)
	{
		_api = api;
		_requestExecutor = requestExecutor;
	}

	public async Task<Result<StampDiscountModel?, DomainError>> StampDiscount()
	{
		Result<StampDiscountDto, ServiceError> result = await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel tokenModel) => _api.CartStampDiscount(tokenModel.Token, cancellationToken));
		if (result.IsFailure && result.Error is UnsuccessfulStatusCodeError { StatusCode: HttpStatusCode.OK, HttpMessage: not null } unsuccessfulStatusCodeError && unsuccessfulStatusCodeError.HttpMessage.ToLower().Contains("\"data\":"))
		{
			return Result.Success<StampDiscountModel, DomainError>(null);
		}
		return result.Map((StampDiscountDto x) => x.Map(), (ServiceError err) => err.ToBaseDomainError());
	}

	private Task RemoveInvalidProducts(IReadOnlyList<ProductOffer> invalidProducts)
	{
		if (invalidProducts.Count != 0)
		{
			List<ProductOffer> list = new List<ProductOffer>();
			list.AddRange(invalidProducts.Select((ProductOffer i) => i with
			{
				Qty = 0m
			}));
			return ChangeItemsWithChangeHandling(new _003C_003Ez__ReadOnlyList<ProductOffer>(list));
		}
		return Task.CompletedTask;
	}

	public async Task<Result<CartModel, DomainError>> PrepareForCheckout()
	{
		return await (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel tokenModel) => _api.CartNoCache(tokenModel.Token, cancellationToken))).MapAsync(async delegate(CartDto dto)
		{
			(CartModel cartModel, IReadOnlyList<ProductOffer> invalidProducts) mappedResult = dto.ValidateAndMap();
			await RemoveInvalidProducts(mappedResult.invalidProducts);
			return mappedResult.cartModel;
		}, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<ChangeItemsResult, DomainError>> ChangeItemsWithChangeHandling(IReadOnlyList<ProductOffer> products)
	{
		string message;
		return (await _requestExecutor.ExecuteWithToken(delegate(CancellationToken cancellationToken, TokenModel tokenModel)
		{
			IEcomApi api = _api;
			string token = tokenModel.Token;
			CartItemsChangeRequest cartItemsChangeRequest = new CartItemsChangeRequest();
			List<CartItemsChangeRequest.ItemDto> list = new List<CartItemsChangeRequest.ItemDto>();
			list.AddRange(products.Select((ProductOffer p) => new CartItemsChangeRequest.ItemDto
			{
				Id = p.Id,
				ProductId = ((p.ProductId == 0L) ? ((long?)null) : new long?(p.ProductId)),
				Qty = p.Qty,
				BasketStep = p.BasketStep,
				SelectedModifications = p.SelectedModifications.ToDto(),
				Comment = p.Comment,
				IsSelected = p.IsSelected
			}));
			cartItemsChangeRequest.Items = new _003C_003Ez__ReadOnlyList<CartItemsChangeRequest.ItemDto>(list);
			cartItemsChangeRequest.CanChangeOffer = true;
			return api.ChangeItems(token, cartItemsChangeRequest, cancellationToken);
		})).Map((CartItemsChangedDto x) => x, (ServiceError err) => err.ToBaseDomainError()).Ensure((CartItemsChangedDto x) => !TryExtractChangeErrorMessage(x, out message), delegate(CartItemsChangedDto x)
		{
			TryExtractChangeErrorMessage(x, out message);
			return new CartNotChanged
			{
				Message = message
			};
		}).Map((CartItemsChangedDto dto) => new ChangeItemsResult
		{
			Items = dto.Data.Items.Select((CartItemsChangedDto.ItemDto i) => i.Map()).ToImmutableList(),
			Changes = (dto.Data.Changed ?? Array.Empty<CartItemsChangedDto.ChangedDto>()).Select((CartItemsChangedDto.ChangedDto i) => i.Map()).ToImmutableList()
		});
	}

	public async Task<Result<Unit, DomainError>> AddCommentToItem(ProductOffer productOffer, string? comment)
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel tokenModel) => _api.AddCommentToItem(tokenModel.Token, new CartItemAddCommentRequest
		{
			Items = new ProductOfferBaseDto[1]
			{
				new ProductOfferBaseDto
				{
					OfferId = productOffer.Id,
					ProductId = ((productOffer.ProductId == 0L) ? ((long?)null) : new long?(productOffer.ProductId)),
					SelectedModifications = productOffer.SelectedModifications.ToDto(),
					Comment = comment
				}
			}
		}, cancellationToken))).Map((object dto) => Unit.Default, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<CartModel, DomainError>> ClearCart()
	{
		return await (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel tokenModel) => _api.ClearCart(tokenModel.Token, cancellationToken))).MapAsync(async delegate(CartDto dto)
		{
			(CartModel cartModel, IReadOnlyList<ProductOffer> invalidProducts) mappedResult = dto.ValidateAndMap();
			await RemoveInvalidProducts(mappedResult.invalidProducts);
			return mappedResult.cartModel;
		}, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<Unit, DomainError>> ClearAdultProductFromCart()
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken, TokenModel tokenModel) => _api.ClearAdultProductFromCart(tokenModel.Token, cancellationToken))).Map((CartClearResponseDto dto) => Unit.Default, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<CartItemsChangedDto, DomainError>> ChangeItems(IReadOnlyList<ProductOffer> products)
	{
		return (await _requestExecutor.ExecuteWithToken(delegate(CancellationToken cancellationToken, TokenModel tokenModel)
		{
			IEcomApi api = _api;
			string token = tokenModel.Token;
			CartItemsChangeRequest cartItemsChangeRequest = new CartItemsChangeRequest();
			List<CartItemsChangeRequest.ItemDto> list = new List<CartItemsChangeRequest.ItemDto>();
			list.AddRange(products.Select((ProductOffer p) => new CartItemsChangeRequest.ItemDto
			{
				Id = p.Id,
				ProductId = p.ProductId,
				Qty = p.Qty,
				BasketStep = p.BasketStep,
				SelectedModifications = p.SelectedModifications.ToDto(),
				Comment = p.Comment,
				IsSelected = p.IsSelected
			}));
			cartItemsChangeRequest.Items = new _003C_003Ez__ReadOnlyList<CartItemsChangeRequest.ItemDto>(list);
			cartItemsChangeRequest.CanChangeOffer = true;
			return api.ChangeItems(token, cartItemsChangeRequest, cancellationToken);
		})).Map((CartItemsChangedDto dto) => dto, (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<Unit, DomainError>> SetAllItemsSelected(bool selected, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken ct, TokenModel tm) => _api.SetAllSelected(tm.Token, new SelectAllRequestDto
		{
			IsSelected = selected
		}, ct), TokenLevel.L80, cancellationToken)).Map((object dto) => Unit.Default, (ServiceError err) => err.ToBaseDomainError());
	}

	private static bool TryExtractChangeErrorMessage(Result<CartItemsChangedDto, ServiceError> apiResult, out string message)
	{
		if (apiResult.IsSuccess)
		{
			CartItemsChangedDto.ChangedDto changedDto = apiResult.Value.Data.Changed?.FirstOrDefault((CartItemsChangedDto.ChangedDto c) => !c.IsAddedToCart);
			if ((object)changedDto != null)
			{
				string text = changedDto.Messages.FirstOrDefault();
				if (text != null)
				{
					message = text;
					return true;
				}
			}
		}
		message = string.Empty;
		return false;
	}

	public async Task<Result<ShareCartModel, DomainError>> ShareCart(CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken2, TokenModel tokenModel) => _api.ShareCart(tokenModel.Token, cancellationToken2), TokenLevel.L80, cancellationToken)).Map((ShareCartResponseDto dto) => dto.ToModel(), (ServiceError err) => err.ToBaseDomainError());
	}

	public async Task<Result<SharedCartModel, DomainError>> GetSharedCart(string cartToken, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await _requestExecutor.ExecuteWithToken<SharedCartResponseDto, SharedCartErrorDto>((CancellationToken cancellationToken2, TokenModel tokenModel) => _api.GetSharedCart(tokenModel.Token, cartToken, cancellationToken2), TokenLevel.L80, cancellationToken)).Map((SharedCartResponseDto dto) => dto.ToModel(), (ServiceError err) => err.ToSharedCartError());
	}

	public async Task<Result<ComboSuggestion, DomainError>> GetComboSuggestionsAsync(ProductOffer offer, CancellationToken cancellationToken = default(CancellationToken))
	{
		return (await _requestExecutor.ExecuteWithToken((CancellationToken cancellationToken2, TokenModel tokenModel) => _api.GetComboSuggestionsAsync(tokenModel.Token, new ComboSuggestionsRequestDto
		{
			Item = new ComboSuggestionsRequestDto.ItemDto
			{
				OfferId = offer.Id.Value,
				ProductId = offer.ProductId
			}
		}))).Ensure((ComboSuggestionsResponseDto dto) => dto.IsValid(), (ComboSuggestionsResponseDto _) => new ApiContractError()).Map((ComboSuggestionsResponseDto dto) => dto.Map(), (ServiceError err) => err.ToBaseDomainError());
	}
}
