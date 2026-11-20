using System;

namespace Auchan.Common.PersonalCabinet.DomainModels;

public class SignUpCachedData
{
	public string? PhoneText { get; }

	public string FirstName { get; }

	public string EmailText { get; }

	public Gender SelectedGender { get; }

	public DateTime? Birthday { get; }

	public bool SubscriptionFlag { get; }

	public SignUpCachedData(string? phoneText, string firstName, string emailText, Gender selectedGender, DateTime? birthday, bool subscriptionFlag)
	{
		PhoneText = phoneText;
		FirstName = firstName;
		EmailText = emailText;
		SelectedGender = selectedGender;
		Birthday = birthday;
		SubscriptionFlag = subscriptionFlag;
	}
}
