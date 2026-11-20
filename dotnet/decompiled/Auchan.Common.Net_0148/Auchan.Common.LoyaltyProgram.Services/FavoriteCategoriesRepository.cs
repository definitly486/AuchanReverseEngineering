using System;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Home;
using Auchan.Common.PersonalCabinet;
using CSharpFunctionalExtensions;

namespace Auchan.Common.LoyaltyProgram.Services;

public class FavoriteCategoriesRepository
{
	private readonly FavoriteCategoriesService _service;

	private FavoriteCategoriesItemViewModel? _favoriteCategoriesCache;

	private readonly TimeSpan FavoriteCategoriesCacheTime = TimeSpan.FromHours(1);

	private DateTime? FavoriteCategoriesRequestTime { get; set; }

	public event EventHandler<EventArgs?>? FavoriteCategoriesChanged;

	public FavoriteCategoriesRepository(FavoriteCategoriesService service, IUserContext userContext)
	{
		_service = service;
		userContext.AfterLoggedOut += delegate
		{
			_favoriteCategoriesCache = null;
			FavoriteCategoriesRequestTime = null;
			return Task.CompletedTask;
		};
	}

	public async Task<Result<FavoriteCategoriesItemViewModel, DomainError>> GetFavoriteCategories()
	{
		if (FavoriteCategoriesRequestTime.HasValue)
		{
			DateTime utcNow = DateTime.UtcNow;
			DateTime? favoriteCategoriesRequestTime = FavoriteCategoriesRequestTime;
			if (utcNow - favoriteCategoriesRequestTime <= FavoriteCategoriesCacheTime && _favoriteCategoriesCache != null)
			{
				return Result.Success<FavoriteCategoriesItemViewModel, DomainError>(_favoriteCategoriesCache);
			}
		}
		Result<FavoriteCategoriesItemViewModel, DomainError> result = await _service.GetFavoriteCategories();
		if (result.IsSuccess && result.Value != null)
		{
			FavoriteCategoriesRequestTime = DateTime.UtcNow;
			_favoriteCategoriesCache = result.Value;
		}
		return result;
	}

	public async Task<Result<FavoriteCategoriesItemViewModel, DomainError>> SendCategories(string[] ids)
	{
		Result<FavoriteCategoriesItemViewModel, DomainError> result = await _service.SendCategories(ids);
		if (result.IsSuccess)
		{
			_favoriteCategoriesCache = null;
			FavoriteCategoriesRequestTime = null;
			this.FavoriteCategoriesChanged?.Invoke(this, null);
		}
		return result;
	}
}
