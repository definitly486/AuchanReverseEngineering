using System.Globalization;

namespace Auchan.Common.Profile.Cases;

public static class CaseStatusExtensions
{
	public static CaseStatus Parse(string? rawStatus)
	{
		if (string.IsNullOrWhiteSpace(rawStatus))
		{
			return CaseStatus.Unknown;
		}
		if (int.TryParse(rawStatus.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out var result))
		{
			return result switch
			{
				1 => CaseStatus.InProgress, 
				2 => CaseStatus.Closed, 
				3 => CaseStatus.WaitingForReply, 
				4 => CaseStatus.Resolved, 
				_ => CaseStatus.Unknown, 
			};
		}
		return CaseStatus.Unknown;
	}

	public static string GetDisplayText(CaseStatus status, string? rawStatus, string? solutionDateText)
	{
		switch (status)
		{
		case CaseStatus.InProgress:
			if (!string.IsNullOrWhiteSpace(solutionDateText))
			{
				return "В работе до " + solutionDateText;
			}
			return "В работе";
		case CaseStatus.Closed:
			return "Закрыто";
		case CaseStatus.WaitingForReply:
			return "Ждём вашего ответа";
		case CaseStatus.Resolved:
			return "Решено";
		default:
			if (!string.IsNullOrWhiteSpace(rawStatus))
			{
				return rawStatus;
			}
			return "Неизвестно";
		}
	}
}
