using System;
using Auchan.Common.AdminTool.Models;
using Auchan.Common.Common;

namespace Auchan.Common.Home;

public class UserNotificationBanner : IIdentifiable
{
	private const string SoftUpdateBoldHtmlText = "<b>Скачайте новую версию</b>";

	public bool IsSoftUpdate { get; }

	public string HtmlText { get; }

	public Action? OnSoftUpdateClicked { get; }

	private UserNotificationBanner(string text, bool isSoftUpdate, Action? onSoftUpdateClicked = null)
	{
		HtmlText = text;
		IsSoftUpdate = isSoftUpdate;
		OnSoftUpdateClicked = onSoftUpdateClicked;
	}

	public static UserNotificationBanner? CreateOrNull(AppConfig? appConfig, Action onSoftUpdateClicked)
	{
		if (appConfig != null && appConfig.MainInformerText != null)
		{
			return new UserNotificationBanner(appConfig.MainInformerText, isSoftUpdate: false);
		}
		if (appConfig?.AppVersion != null)
		{
			return new UserNotificationBanner(appConfig.AppVersion.BannerMessage + " <b>Скачайте новую версию</b>", isSoftUpdate: true, onSoftUpdateClicked);
		}
		return null;
	}

	string IIdentifiable.GetId()
	{
		return $"userNotificationBanner:{HtmlText.GetHashCode()}";
	}
}
