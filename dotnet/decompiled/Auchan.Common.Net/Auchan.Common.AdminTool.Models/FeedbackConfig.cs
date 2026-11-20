namespace Auchan.Common.AdminTool.Models;

public class FeedbackConfig
{
	public string PhoneNumber { get; }

	public string Email { get; }

	public FeedbackConfig(string phoneNumber, string email)
	{
		PhoneNumber = phoneNumber;
		Email = email;
	}
}
