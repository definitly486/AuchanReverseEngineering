using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.ProducModels;
using Auchan.Common.Ecom.Search.DTO;
using Auchan.Common.Ecom.Search.Models;
using Auchan.Common.Extensions;

namespace Auchan.Common.Ecom.Search.Infrastructure;

public static class SearchMapper
{
	public static SearchResult Map(this SearchResultDTO dto)
	{
		return new SearchResult
		{
			Items = MapItems(dto),
			Filters = MapFilters(dto),
			SelectedFilters = dto.SelectedFilters?.ToDictionary((KeyValuePair<string, object> kvp) => kvp.Key, (KeyValuePair<string, object> kvp) => kvp.Value),
			Sort = dto.Sort,
			Count = dto.Count
		};
	}

	private static Dictionary<string, CategoryWithProduct>? MapItems(SearchResultDTO dto)
	{
		if (dto.Items == null)
		{
			return null;
		}
		Dictionary<string, CategoryWithProduct> dictionary = new Dictionary<string, CategoryWithProduct>();
		foreach (CategoryWithProductDto item in dto.Items)
		{
			dictionary.Add("blank", item.Map());
		}
		return dictionary;
	}

	private static IReadOnlyList<SearchFilter>? MapFilters(SearchResultDTO dto)
	{
		if (dto.Filters == null || dto.Filters.Count < 1)
		{
			return null;
		}
		return dto.Filters.Select(Map).ToImmutableList();
	}

	private static SearchFilter Map(this SearchResultFilterDTO dto)
	{
		return new SearchFilter
		{
			Name = dto.Name,
			Code = dto.Code,
			Type = dto.Type,
			Sort = dto.Sort,
			Min = dto.Min,
			Max = dto.Max,
			Disabled = dto.Disabled,
			Items = dto.Items?.Select((SearchResultFilterMultiItemDTO item) => new SearchFilterMultiItem
			{
				Name = item.Name,
				Code = item.Code,
				Disabled = item.Disabled,
				Counter = item.Counter
			}).ToImmutableList(),
			Informer = dto.Informer
		};
	}

	public static SearchAutohintsResult Map(this SearchAutohintsResultDTO dto)
	{
		return new SearchAutohintsResult
		{
			Query = dto.Data.Query,
			Correction = dto.Data.Correction,
			Populars = dto.Data.Populars.Select((SearchAutohintsPopularsResultDTO d) => new SearchAutohintPopular
			{
				Text = d.Text.ReplacePercentIfNeeded(),
				Amount = d.Amount
			}).ToImmutableList(),
			Autofills = dto.Data.Autofills.Select((SearchAutohintsFillsResultDTO d) => new SearchAutohintAutofill
			{
				Text = d.Text.ReplacePercentIfNeeded(),
				FullText = d.FullText.ReplacePercentIfNeeded()
			}).ToImmutableList(),
			Categories = dto.Data.Categories.Select((SearchAutohintsCategoriesResultDTO d) => new SearchAutohintCategory
			{
				Id = d.Id,
				Code = d.Code,
				Name = d.Name
			}).ToImmutableList()
		};
	}
}
