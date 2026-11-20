using System;
using System.Net.Http;
using Auchan.Common.Networking;
using DryIoc;
using Refit;

namespace Auchan.Common.Extensions;

internal static class IRegistratorExtensions
{
	public static void AddRefitClient<TApi, TUrlProvider, TDelegatingHandler>(this IRegistrator registrator) where TApi : class where TUrlProvider : class, IEnvironmentBaseUrlProvider, new() where TDelegatingHandler : DelegatingHandler
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<TApi>(new EnvironmentHttpClient(new TUrlProvider(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<TDelegatingHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
	}

	public static void AddRefitClient<TApi, TDelegatingHandler>(this IRegistrator registrator) where TApi : class where TDelegatingHandler : DelegatingHandler
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<TApi>(new EnvironmentHttpClient(resolverContext.Resolve<IEnvironmentBaseUrlProvider<TApi>>(), resolverContext.Resolve<IEnvironmentManager>(), resolverContext.Resolve<TDelegatingHandler>()), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
	}

	public static void AddRefitClient<TApi>(this IRegistrator registrator) where TApi : class
	{
		registrator.AddRefitClient<TApi, CoreHttpMessageHandler>();
	}

	public static void AddRefitClient<TApi>(this IRegistrator registrator, Func<HttpMessageHandler, HttpMessageHandler> handlerFactory)
	{
		registrator.RegisterDelegate((IResolverContext resolverContext) => RestService.For<TApi>(new EnvironmentHttpClient(resolverContext.Resolve<IEnvironmentBaseUrlProvider<TApi>>(), resolverContext.Resolve<IEnvironmentManager>(), handlerFactory(resolverContext.Resolve<CoreHttpMessageHandler>())), resolverContext.Resolve<RefitSettings>()), Reuse.Singleton);
	}
}
