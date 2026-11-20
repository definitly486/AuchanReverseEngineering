using System.Collections.Generic;
using Auchan.Common.Ecom.DTO;
using Newtonsoft.Json;

namespace Auchan.Common.Profile;

public class FavoritesDtos
{
	public class DeleteDto
	{
		[JsonProperty("errors")]
		public List<ErrorDto>? Errors { get; set; }
	}

	public class AddDto
	{
		[JsonProperty("errors")]
		public List<ErrorDto>? Errors { get; set; }
	}

	public class AddRequestDto
	{
		[JsonProperty("gima_id")]
		public string? GimaId { get; set; }
	}

	public class FavoritesDto
	{
		[JsonProperty("items")]
		public List<ProductDto>? Items { get; set; }
	}

	public class FavoritesRequestDto
	{
		[JsonProperty("field")]
		public string? OrderField { get; set; }

		[JsonProperty("direction")]
		public string? OrderDirection { get; set; }
	}

	public class FavoriteFieldsDto
	{
		[JsonProperty("sort")]
		public List<SortDto>? Sorts { get; set; }

		[JsonProperty("errors")]
		public List<ErrorDto>? Errors { get; set; }
	}

	public class SortDto
	{
		[JsonProperty("name")]
		public string? Name { get; set; }

		[JsonProperty("field")]
		public string? Field { get; set; }

		[JsonProperty("direction")]
		public string? Direction { get; set; }
	}

	public class ErrorDto
	{
		[JsonProperty("code")]
		public string? Code { get; set; }

		[JsonProperty("message")]
		public string? Message { get; set; }
	}
}
