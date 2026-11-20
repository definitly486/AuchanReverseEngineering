using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Reviews.Api.Ecom;

public class ReviewsEcomRepository
{
	private const string ReviewPopupShownCacheKey = "ReviewPopupShownCacheKey";

	private readonly ReviewsEcomService _reviewService;

	private readonly ICache _cache;

	private bool? _reviewPopupRequired;

	public ReviewsEcomRepository(ReviewsEcomService reviewService, IUserContext userContext, ICache cache)
	{
		_reviewService = reviewService;
		_cache = cache;
		userContext.AfterLoggedOut += delegate
		{
			_reviewPopupRequired = null;
			return _cache.Remove("ReviewPopupShownCacheKey");
		};
	}

	public async Task<Result<bool, DomainError>> CheckIfPopupNeeded()
	{
		if (await _cache.TryGetStruct<bool>("ReviewPopupShownCacheKey") == true)
		{
			return Result.Success<bool, DomainError>(value: false);
		}
		if (_reviewPopupRequired.HasValue)
		{
			return Result.Success<bool, DomainError>(_reviewPopupRequired.Value);
		}
		Result<bool, DomainError> result = await _reviewService.CheckIfPopupNeeded();
		bool value = result.IsSuccess && result.Value;
		_reviewPopupRequired = value;
		return Result.Success<bool, DomainError>(value);
	}

	public async Task SetReviewPopupShown()
	{
		await _cache.Save("ReviewPopupShownCacheKey", obj: true);
	}
}
