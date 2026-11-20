using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using AsyncAwaitBestPractices;
using Auchan.Android.AppLinks;
using Auchan.Android.PushNotifications;
using Auchan.Common.DependencyInjection;
using Auchan.Common.UniversalLinks;
using DryIoc;

namespace Auchan.Android.Helpers;

public static class AppIntentHandler
{
	private enum IntentType
	{
		Unknown,
		PushNotification,
		AppLink
	}

	private static IntentType GetType(Intent intent)
	{
		if (AndroidNotificationService.IsNotificationIntent(intent))
		{
			return IntentType.PushNotification;
		}
		if (AppLinksHelper.IsAppLinkIntent(intent) && DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<IUniversalLinksService>().ShouldHandleLink(intent.Data?.ToString() ?? ""))
		{
			return IntentType.AppLink;
		}
		return IntentType.Unknown;
	}

	public static void HandleIntent(Intent? intent)
	{
		if (intent == null)
		{
			return;
		}
		Task.Run(delegate
		{
			IntentType type = GetType(intent);
			Lazy<AndroidNotificationService> lazy = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<Lazy<AndroidNotificationService>>();
			Lazy<IUniversalLinksService> lazy2 = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<Lazy<IUniversalLinksService>>();
			switch (type)
			{
			case IntentType.PushNotification:
				lazy.Value.HandleIntent(Application.Context, intent);
				break;
			case IntentType.AppLink:
				lazy2.Value.HandleLinkOnStart(intent.Data?.ToString() ?? "").SafeFireAndForget((Action<Exception>)null, false);
				break;
			}
			string? stringExtra = intent.GetStringExtra("messageId");
			string stringExtra2 = intent.GetStringExtra("messageUniqueKey");
			if (!string.IsNullOrEmpty(stringExtra) && string.IsNullOrEmpty(stringExtra2))
			{
				lazy.Value.HandleIntent(Application.Context, intent);
			}
		}).SafeFireAndForget((Action<Exception>)null, false);
	}
}
