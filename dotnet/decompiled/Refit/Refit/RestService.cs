using System;
using System.Collections.Concurrent;
using System.Net.Http;

namespace Refit;

public static class RestService
{
	private static readonly ConcurrentDictionary<Type, Type> TypeMapping = new ConcurrentDictionary<Type, Type>();

	public static T For<T>(HttpClient client, IRequestBuilder<T> builder)
	{
		return (T)For(typeof(T), client, builder);
	}

	public static T For<T>(HttpClient client, RefitSettings? settings)
	{
		IRequestBuilder<T> builder = RequestBuilder.ForType<T>(settings);
		return For(client, builder);
	}

	public static T For<T>(HttpClient client)
	{
		return For<T>(client, (RefitSettings?)null);
	}

	public static T For<T>(string hostUrl, RefitSettings? settings)
	{
		return For<T>(CreateHttpClient(hostUrl, settings), settings);
	}

	public static T For<T>(string hostUrl)
	{
		return For<T>(hostUrl, null);
	}

	public static object For(Type refitInterfaceType, HttpClient client, IRequestBuilder builder)
	{
		return Activator.CreateInstance(TypeMapping.GetOrAdd(refitInterfaceType, GetGeneratedType), client, builder);
	}

	public static object For(Type refitInterfaceType, HttpClient client, RefitSettings? settings)
	{
		IRequestBuilder builder = RequestBuilder.ForType(refitInterfaceType, settings);
		return For(refitInterfaceType, client, builder);
	}

	public static object For(Type refitInterfaceType, HttpClient client)
	{
		return For(refitInterfaceType, client, (RefitSettings?)null);
	}

	public static object For(Type refitInterfaceType, string hostUrl, RefitSettings? settings)
	{
		HttpClient client = CreateHttpClient(hostUrl, settings);
		return For(refitInterfaceType, client, settings);
	}

	public static object For(Type refitInterfaceType, string hostUrl)
	{
		return For(refitInterfaceType, hostUrl, null);
	}

	public static HttpClient CreateHttpClient(string hostUrl, RefitSettings? settings)
	{
		if (string.IsNullOrWhiteSpace(hostUrl))
		{
			throw new ArgumentException("`hostUrl` must not be null or whitespace.", "hostUrl");
		}
		HttpMessageHandler httpMessageHandler = null;
		if (settings != null)
		{
			if (settings.HttpMessageHandlerFactory != null)
			{
				httpMessageHandler = settings.HttpMessageHandlerFactory();
			}
			if (settings.AuthorizationHeaderValueGetter != null)
			{
				httpMessageHandler = new AuthenticatedHttpClientHandler(settings.AuthorizationHeaderValueGetter, httpMessageHandler);
			}
		}
		return new HttpClient(httpMessageHandler ?? new HttpClientHandler())
		{
			BaseAddress = new Uri(hostUrl.TrimEnd('/'))
		};
	}

	private static Type GetGeneratedType(Type refitInterfaceType)
	{
		Type? type = Type.GetType(UniqueName.ForType(refitInterfaceType));
		if (type == null)
		{
			throw new InvalidOperationException(refitInterfaceType.Name + " doesn't look like a Refit interface. Make sure it has at least one method with a Refit HTTP method attribute and Refit is installed in the project.");
		}
		return type;
	}
}
