namespace Auchan.Common.Feedback;

public class ExternalAppsLinkCreator : IExternalAppsLinkCreator
{
	private readonly IFeedbackUserDataCollector _feedbackUserDataCollector;

	private readonly IFeedbackContactsProvider _feedbackContactsProvider;

	public string FeedbackMessageWithAppAndDeviceData => "mailto:" + _feedbackContactsProvider.Email + "?body=" + _feedbackUserDataCollector.InformationForFeedback;

	public ExternalAppsLinkCreator(IFeedbackUserDataCollector feedbackUserDataCollector, IFeedbackContactsProvider feedbackContactsProvider)
	{
		_feedbackUserDataCollector = feedbackUserDataCollector;
		_feedbackContactsProvider = feedbackContactsProvider;
	}
}
