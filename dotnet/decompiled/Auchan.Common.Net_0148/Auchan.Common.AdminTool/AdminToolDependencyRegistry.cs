using System.Net.Http;
using Auchan.Common.AdminTool.Tags;
using Auchan.Common.Extensions;
using Auchan.Common.Feedback;
using Auchan.Common.Networking;
using DryIoc;

namespace Auchan.Common.AdminTool;

public static class AdminToolDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.AddRefitClient<IAuthApi>();
		registrator.AddRefitClient<IAdminToolApi>();
		registrator.AddRefitClient<IStampsApi>();
		registrator.AddRefitClient<IPromotionsApi>((HttpMessageHandler h) => new HttpMessageAuthSchemaHandler("Token", h));
		registrator.RegisterMany<AdminToolBaseUrlProvider>();
		registrator.Register<AdminToolBaseUrlProvider>();
		registrator.Register<IAdminToolAuthorizer, AdminToolAuthorizer>(Reuse.Singleton);
		registrator.Register<IPromotionRepository, PromotionRepository>(Reuse.Singleton);
		registrator.Register<IAdminToolService, AdminToolService>(Reuse.Singleton);
		registrator.Register<IAdminContext, AdminContext>(Reuse.Singleton);
		registrator.Register<IFeedbackContactsProvider, FeedbackContactsProvider>();
		registrator.Register<IFeedbackUserDataCollector, FeedbackUserDataCollector>();
		registrator.Register<IExternalAppsLinkCreator, ExternalAppsLinkCreator>();
		registrator.Register<ITagsReplacer, TagsReplacer>(Reuse.Singleton);
	}
}
