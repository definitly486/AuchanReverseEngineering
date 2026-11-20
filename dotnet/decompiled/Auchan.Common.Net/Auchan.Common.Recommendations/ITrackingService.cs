using System.Collections.Generic;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.LoyaltyProgram.Models;
using Auchan.Common.PersonalCabinet.DomainModels;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Recommendations;

public interface ITrackingService
{
	Task<Result<Unit, DomainError>> ViewProduct(long gimaId, CancellationToken token);

	Task<Result<Unit, DomainError>> AddToCart(long gimaId, CancellationToken token);

	Task<Result<Unit, DomainError>> Order(IReadOnlyList<ProductShort> products, int storeId, string transactionId, CancellationToken token);

	Task<Result<Unit, DomainError>> ViewCategory(long categoryId, CancellationToken token);

	Task<Result<Unit, DomainError>> ViewCategoryByPath(string categoryPath, CancellationToken token);

	Task<Result<Unit, DomainError>> Search(string query, CancellationToken token);

	Task<Result<Unit, DomainError>> RecommendationTap(long gimaId, string blockId, CancellationToken token = default(CancellationToken));

	Task<Result<Unit, DomainError>> RecommendationAddedToBasket(long gimaId, string blockId, CancellationToken token = default(CancellationToken));

	Task<Result<Unit, DomainError>> RecommendationBlockViewed(string blockId, CancellationToken token = default(CancellationToken));

	Task<Result<Unit, DomainError>> SetCustomer(ProfileModel profile, LoyaltyCardEntity card, CancellationToken token = default(CancellationToken));

	Task<Result<Unit, DomainError>> ProductPlacementViewed(string contentId, CancellationToken token = default(CancellationToken));

	Task<Result<Unit, DomainError>> ProductPlacementClicked(string contentId, CancellationToken token = default(CancellationToken));
}
