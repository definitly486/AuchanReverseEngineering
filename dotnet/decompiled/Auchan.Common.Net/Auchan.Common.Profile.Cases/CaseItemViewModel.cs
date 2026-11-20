using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Auchan.Common.Profile.Cases.Api;

namespace Auchan.Common.Profile.Cases;

public sealed class CaseItemViewModel
{
	public string Id { get; }

	public string Number { get; }

	public string NumberText { get; }

	public string RawStatus { get; }

	public CaseStatus Status { get; }

	public string StatusText { get; }

	public string TopicsText { get; }

	public string CreatedOnText { get; }

	public string? SolutionDateText { get; }

	public bool HasTopics { get; }

	public bool HasCreatedOn { get; }

	public CaseItemViewModel(CasesDtos.CaseDto dto)
	{
		Id = dto.Id ?? string.Empty;
		Number = dto.Number ?? string.Empty;
		RawStatus = dto.Status ?? string.Empty;
		NumberText = (string.IsNullOrWhiteSpace(Number) ? string.Empty : ("№" + Number));
		CreatedOnText = FormatDate(dto.CreatedOn, "dd.MM.yyyy") ?? string.Empty;
		SolutionDateText = FormatDate(dto.SolutionDate, "dd.MM");
		Status = CaseStatusExtensions.Parse(RawStatus);
		StatusText = CaseStatusExtensions.GetDisplayText(Status, RawStatus, SolutionDateText);
		TopicsText = BuildTopics(dto.CategoryFeedbackForm, dto.TopicFeedbackForm);
		HasTopics = !string.IsNullOrWhiteSpace(TopicsText);
		HasCreatedOn = !string.IsNullOrWhiteSpace(CreatedOnText);
	}

	private static string BuildTopics(string? category, string? topic)
	{
		List<string> list = new List<string>();
		if (!string.IsNullOrWhiteSpace(category))
		{
			list.Add(category.Trim());
		}
		if (!string.IsNullOrWhiteSpace(topic))
		{
			list.Add(topic.Trim());
		}
		if (list.Count != 0)
		{
			return string.Join(" • ", list);
		}
		return string.Empty;
	}

	private static string? FormatDate(string? raw, string format)
	{
		DateTimeOffset? dateTimeOffset = TryParseDate(raw);
		if (!dateTimeOffset.HasValue)
		{
			return null;
		}
		return dateTimeOffset.Value.ToString(format, CultureInfo.InvariantCulture);
	}

	private static DateTimeOffset? TryParseDate(string? raw)
	{
		if (string.IsNullOrWhiteSpace(raw))
		{
			return null;
		}
		if (DateTimeOffset.TryParse(raw, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out var result))
		{
			return result;
		}
		string text = NormalizeDate(raw);
		if (!string.Equals(text, raw, StringComparison.Ordinal) && DateTimeOffset.TryParse(text, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal | DateTimeStyles.AssumeUniversal, out result))
		{
			return result;
		}
		return null;
	}

	private static string NormalizeDate(string raw)
	{
		string text = raw.Trim();
		string text2 = string.Empty;
		if (text.EndsWith("Z", StringComparison.OrdinalIgnoreCase))
		{
			text2 = "Z";
			text = text.Substring(0, text.Length - 1);
		}
		int num = text.LastIndexOf(':');
		if (num < 0)
		{
			return raw;
		}
		string text3 = text.Substring(num + 1);
		if (text3.Length <= 2 || text3.Any((char c) => !char.IsDigit(c)))
		{
			return raw;
		}
		string text4 = text3.Substring(0, 2);
		string text5 = text3.Substring(2);
		return text.Substring(0, num + 1) + text4 + "." + text5 + text2;
	}
}
