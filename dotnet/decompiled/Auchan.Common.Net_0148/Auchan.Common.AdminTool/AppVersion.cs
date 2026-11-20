using Auchan.Common.AdminTool.DTO;

namespace Auchan.Common.AdminTool;

public class AppVersion
{
	public string Current { get; }

	public string New { get; }

	public string UpdateId { get; }

	public string BannerMessage { get; }

	public string PopupMessage { get; }

	public string PopupTitle { get; }

	public bool IsPopupAutoFirstShown { get; }

	public AppVersion(AppVersionDto appVersionDto)
	{
		Current = appVersionDto.Current;
		New = appVersionDto.New;
		UpdateId = appVersionDto.UpdateId;
		BannerMessage = appVersionDto.BannerMessage;
		PopupMessage = appVersionDto.PopupMessage;
		PopupTitle = appVersionDto.PopupTitle;
		IsPopupAutoFirstShown = appVersionDto.IsPopupAutoFirstShown;
	}
}
