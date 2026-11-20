using System;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Cache;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Tooltips;

public class TooltipsRepository : ITooltipsRepository
{
	private const string Key = "tooltips";

	private readonly ITooltipsService _tooltipsService;

	private readonly ICache _cache;

	public TooltipsRepository(ITooltipsService tooltipsService, ICache cache)
	{
		_tooltipsService = tooltipsService;
		_cache = cache;
	}

	public async Task<Result<Tooltip[], DomainError>> GetTooltips()
	{
		Tooltip[] array = await _cache.TryGet<Tooltip[]>("tooltips");
		if (array != null)
		{
			return Result.Success<Tooltip[], DomainError>(array);
		}
		Result<Tooltip[], DomainError> result = await _tooltipsService.GetTooltips();
		if (result.IsSuccess)
		{
			await _cache.Save("tooltips", result.Value, TimeSpan.FromHours(2));
		}
		return result;
	}
}
