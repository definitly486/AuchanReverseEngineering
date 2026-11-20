using Auchan.Common.AdminTool;

namespace Auchan.Common.Feedback;

public class FeedbackContactsProvider : IFeedbackContactsProvider
{
	private readonly IAdminContext _adminContext;

	public string Email => _adminContext.AppConfig?.FeedbackConfig?.Email ?? "service@auchan.ru";

	public string Phone => _adminContext.AppConfig?.FeedbackConfig?.PhoneNumber ?? "88007005800";

	public FeedbackContactsProvider(IAdminContext adminContext)
	{
		_adminContext = adminContext;
	}
}
