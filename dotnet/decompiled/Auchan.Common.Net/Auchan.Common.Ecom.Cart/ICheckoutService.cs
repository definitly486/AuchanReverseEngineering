using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Cart;

public interface ICheckoutService
{
	Task<Result<RecalculateResult, DomainError>> RecalculateAsync(string? promocode, long? points, string? timeslotId, bool? stampDiscount, CancellationToken cancellationToken = default(CancellationToken));

	Task<Result<CheckoutCommitResultDto, DomainError>> Commit(CheckoutCommitDto commitData);

	Task<Result<CheckoutData, DomainError>> GetDataAsync(string? promoCode = null, long? points = null, bool? stampDiscount = null);

	Task<Result<CheckoutOrderDetails, DomainError>> OrderData(string orderId);

	Task<Result<CheckoutOrderDetails, DomainError>[]> OrderData(IEnumerable<string> orderIds);
}
