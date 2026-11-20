using Auchan.Common.Common;

namespace Auchan.Common.Feedback;

public class FeedbackUserDataCollector : IFeedbackUserDataCollector
{
	private IDeviceService _deviceService;

	public string InformationForFeedback => "Версия МП и ОС: " + _deviceService.AppVersionBuildNumberAndOSVersion + ", ID устройства: " + _deviceService.Udid;

	public FeedbackUserDataCollector(IDeviceService deviceService)
	{
		_deviceService = deviceService;
	}
}
