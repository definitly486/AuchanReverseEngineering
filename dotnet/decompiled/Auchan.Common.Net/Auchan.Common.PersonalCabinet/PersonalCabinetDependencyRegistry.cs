using Auchan.Common.Extensions;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet.Authorization.AuthPush;
using Auchan.Common.PersonalCabinet.Authorization.Managers;
using Auchan.Common.PersonalCabinet.Errors;
using Auchan.Common.PersonalCabinet.Interactors;
using Auchan.Common.Profile;
using DryIoc;
using Refit;

namespace Auchan.Common.PersonalCabinet;

internal static class PersonalCabinetDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IPersonalCabinetApi>(new EnvironmentHttpClient(new PersonalCabinetBaseUrlProvider(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<IPersonalCabinetService, PersonalCabinetService>();
		registrator.Register<ITokenService, TokenService>(Reuse.Singleton);
		registrator.Register<IUserContext, UserContext>(Reuse.Singleton);
		registrator.Register<IRequestExecutor, RequestExecutor>(Reuse.Singleton);
		registrator.Register<IPolicyProvider, PolicyProvider>(Reuse.Singleton);
		registrator.Register<AuthorizationCacheInteractor>();
		registrator.Register<PinInteractor>(Reuse.Singleton);
		registrator.Register<ProfileInteractor>();
		registrator.Register<LogoutInteractor>();
		registrator.Register<DefaultPersonalCabinetErrorHandler>();
		registrator.Register<PinRetryFreezeManager>(Reuse.Singleton);
		registrator.Register<SubscriptionUpdateUseCase>(Reuse.Singleton);
		registrator.Register<SubscriptionsService>(Reuse.Singleton);
		registrator.Register<AuthPushListener>(Reuse.Singleton);
		registrator.Register<IUserAccountDeletionService, UserAccountDeletionService>(Reuse.Singleton);
		registrator.RegisterMany<VkAuthBaseUrlProvider>();
		registrator.AddRefitClient<IVkAuthApi>();
		registrator.Register<IVkAuthService, VkAuthService>(Reuse.Singleton);
	}
}
