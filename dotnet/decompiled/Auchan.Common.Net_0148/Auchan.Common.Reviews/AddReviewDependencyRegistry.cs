using Auchan.Common.Ecom;
using Auchan.Common.Networking;
using Auchan.Common.Reviews.Api.Ecom;
using DryIoc;
using Refit;

namespace Auchan.Common.Reviews;

internal static class AddReviewDependencyRegistry
{
	public static void Register(IRegistrator registrator)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<IReviewsEcomApi>(new EnvironmentHttpClient(resolverContext.Resolve<EcomBaseUrlProvider>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<CoreHttpMessageHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
		registrator.Register<ReviewsEcomService>();
		registrator.Register<ReviewsEcomRepository>();
		registrator.Register<ReviewCheckAddingService>();
		registrator.Register<ReviewReportService>();
	}
}
