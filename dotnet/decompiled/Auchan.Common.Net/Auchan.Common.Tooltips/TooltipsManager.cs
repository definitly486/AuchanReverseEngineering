using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.AdminTool;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.LoyaltyProgram.Services;
using Auchan.Common.Navigation;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Extensions;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Tooltips;

public class TooltipsManager : ITooltipsManager
{
	private readonly IAdminContext _adminContext;

	private readonly IUserContext _userContext;

	private readonly ITooltipsRepository _tooltipsRepository;

	private readonly Lazy<FavoriteCategoriesRepository> _favoriteCategoriesRepository;

	private readonly Lazy<INavigationContext> _navigationContext;

	public TooltipsManager(IAdminContext adminContext, IUserContext userContext, ITooltipsRepository tooltipsRepository, Lazy<FavoriteCategoriesRepository> favoriteCategoriesRepository, Lazy<INavigationContext> navigationContext)
	{
		_adminContext = adminContext;
		_userContext = userContext;
		_tooltipsRepository = tooltipsRepository;
		_favoriteCategoriesRepository = favoriteCategoriesRepository;
		_navigationContext = navigationContext;
	}

	public async Task<Result<Tooltip[], DomainError>> GetTooltips()
	{
		if (_navigationContext.Value.IsNavigating || _navigationContext.Value.IsNavigatedFromStart)
		{
			return Result.Failure<Tooltip[], DomainError>(new NoDataError());
		}
		Result<Tooltip[], DomainError> result = await _tooltipsRepository.GetTooltips();
		List<Tooltip> list = new List<Tooltip>();
		if (result.IsSuccess)
		{
			list.AddRange(from t in result.Value
				where t.Target != TooltipTargetType.Unknown
				orderby t.Priority
				select t);
			if (!OperatingSystem.IsAndroidVersionAtLeast(28) || 1 == 0 || !(_adminContext.AppConfig?.PriceCheckerEnabled ?? false))
			{
				goto IL_01cd;
			}
			if (_userContext.Profile?.Audience != _adminContext.AppConfig?.PricecheckerAudience)
			{
				AppConfig appConfig = _adminContext.AppConfig;
				if (appConfig == null || appConfig.PricecheckerAudience != AudienceType.All)
				{
					goto IL_01cd;
				}
			}
			goto IL_01fa;
		}
		goto IL_0271;
		IL_0271:
		if (list.IsNullOrEmpty() || !_adminContext.ShouldShowTooltipPopup(list[0].ShowCount))
		{
			return Result.Failure<Tooltip[], DomainError>(new NoDataError());
		}
		return (list.Count > 0) ? Result.Success<Tooltip[], DomainError>(list.ToArray()) : Result.Failure<Tooltip[], DomainError>(new NoDataError());
		IL_01cd:
		list = list.Where((Tooltip x) => x.Target != TooltipTargetType.PriceChecker).ToList();
		goto IL_01fa;
		IL_01fa:
		if (_adminContext.StampsConfig?.ShowStampsBalance != true)
		{
			list = list.Where((Tooltip x) => x.Target != TooltipTargetType.Marks).ToList();
		}
		list = list.Where((Tooltip x) => _userContext.Profile?.IsAudienceOf(x.Audience) ?? false).ToList();
		goto IL_0271;
	}
}
