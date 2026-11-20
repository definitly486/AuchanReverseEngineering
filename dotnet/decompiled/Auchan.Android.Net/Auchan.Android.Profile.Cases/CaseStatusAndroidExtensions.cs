using Auchan.Common.Profile.Cases;

namespace Auchan.Android.Profile.Cases;

internal static class CaseStatusAndroidExtensions
{
	public static int GetBackgroundArgb(this CaseStatus status)
	{
		return status switch
		{
			CaseStatus.InProgress => 2131099681, 
			CaseStatus.WaitingForReply => 2131100545, 
			CaseStatus.Resolved => 2131100611, 
			CaseStatus.Closed => 2131099847, 
			_ => 2131099847, 
		};
	}

	public static int GetTextArgb(this CaseStatus status)
	{
		return status switch
		{
			CaseStatus.InProgress => 2131100550, 
			CaseStatus.WaitingForReply => 2131099697, 
			CaseStatus.Resolved => 2131099697, 
			CaseStatus.Closed => 2131100600, 
			_ => 2131100600, 
		};
	}
}
