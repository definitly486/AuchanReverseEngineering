using System;
using Android.Content;
using AndroidX.Core.App;
using AsyncAwaitBestPractices;
using Auchan.Common.Analytics.Loymax;
using Auchan.Common.UniversalLinks;

namespace Auchan.Android.PushNotifications;

public sealed class AndroidNotificationService
{
	public const string NotificationChannelId = "auchan_notification_channel";

	private readonly IUniversalLinksService _appLinks;

	private readonly LoymaxPushTokenService _loymaxPushTokenService;

	public AndroidNotificationService(IUniversalLinksService appLinks, LoymaxPushTokenService loymaxPushTokenService)
	{
		_appLinks = appLinks;
		_loymaxPushTokenService = loymaxPushTokenService;
	}

	public void HandleIntent(Context context, Intent intent)
	{
		NotificationManagerCompat? notificationManagerCompat = NotificationManagerCompat.From(context);
		int intExtra = intent.GetIntExtra("notificationId", 1);
		notificationManagerCompat.Cancel(intExtra);
		string stringExtra = intent.GetStringExtra("messageId");
		string? stringExtra2 = intent.GetStringExtra("messageUniqueKey");
		string stringExtra3 = intent.GetStringExtra("clickUrl");
		if (string.IsNullOrEmpty(stringExtra2))
		{
			_loymaxPushTokenService.OnPushClicked(stringExtra);
		}
		if (_appLinks.ShouldHandleLink(stringExtra3))
		{
			_appLinks.HandleLinkOnStart(stringExtra3, UniversalLinkSource.Push).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public static bool IsNotificationIntent(Intent? intent)
	{
		if (intent == null)
		{
			return false;
		}
		return !string.IsNullOrWhiteSpace(intent.GetStringExtra("messageUniqueKey"));
	}
}
