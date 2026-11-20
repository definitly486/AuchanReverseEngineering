using System.Collections.Generic;
using Newtonsoft.Json;

namespace Auchan.Common.Profile.Cases.Api;

public class CasesDtos
{
	public class CasesRequestDto
	{
		[JsonProperty("pagination")]
		public PaginationRequestDto? Pagination { get; set; }
	}

	public class PaginationRequestDto
	{
		[JsonProperty("offset")]
		public int Offset { get; set; }

		[JsonProperty("limit")]
		public int Limit { get; set; }
	}

	public class CasesResponseDto
	{
		[JsonProperty("data")]
		public CasesDataDto? Data { get; set; }

		[JsonProperty("meta")]
		public CasesMetaDto? Meta { get; set; }
	}

	public class CaseDetailsResponseDto
	{
		[JsonProperty("data")]
		public CaseDetailsDataDto? Data { get; set; }
	}

	public class CasesDataDto
	{
		[JsonProperty("cases")]
		public List<CaseDto>? Cases { get; set; }
	}

	public class CaseDto
	{
		[JsonProperty("id")]
		public string? Id { get; set; }

		[JsonProperty("number")]
		public string? Number { get; set; }

		[JsonProperty("created_on")]
		public string? CreatedOn { get; set; }

		[JsonProperty("category_feedback_form")]
		public string? CategoryFeedbackForm { get; set; }

		[JsonProperty("topic_feedback_form")]
		public string? TopicFeedbackForm { get; set; }

		[JsonProperty("status")]
		public string? Status { get; set; }

		[JsonProperty("solution_date")]
		public string? SolutionDate { get; set; }
	}

	public class CaseDetailsDataDto
	{
		[JsonProperty("case")]
		public CaseDetailsDto? Case { get; set; }

		[JsonProperty("answers")]
		public List<CaseAnswerDto>? Answers { get; set; }
	}

	public class CaseDetailsDto
	{
		[JsonProperty("id")]
		public string? Id { get; set; }

		[JsonProperty("number")]
		public string? Number { get; set; }

		[JsonProperty("created_on")]
		public string? CreatedOn { get; set; }

		[JsonProperty("category_feedback_form")]
		public string? CategoryFeedbackForm { get; set; }

		[JsonProperty("topic_feedback_form")]
		public string? TopicFeedbackForm { get; set; }

		[JsonProperty("status")]
		public string? Status { get; set; }

		[JsonProperty("solution_date")]
		public string? SolutionDate { get; set; }

		[JsonProperty("close_date")]
		public string? CloseDate { get; set; }

		[JsonProperty("rating")]
		public int? Rating { get; set; }

		[JsonProperty("description")]
		public string? Description { get; set; }
	}

	public class CaseAnswerDto
	{
		[JsonProperty("date")]
		public string? Date { get; set; }

		[JsonProperty("text")]
		public string? Text { get; set; }
	}

	public class CasesMetaDto
	{
		[JsonProperty("pagination")]
		public PaginationResponseDto? Pagination { get; set; }
	}

	public class PaginationResponseDto
	{
		[JsonProperty("limit")]
		public int? Limit { get; set; }

		[JsonProperty("type")]
		public string? Type { get; set; }

		[JsonProperty("total")]
		public int? Total { get; set; }

		[JsonProperty("offset")]
		public int? Offset { get; set; }
	}
}
