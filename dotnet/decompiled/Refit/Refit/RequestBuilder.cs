using System;

namespace Refit;

public static class RequestBuilder
{
	private static readonly RequestBuilderFactory PlatformRequestBuilderFactory = new RequestBuilderFactory();

	public static IRequestBuilder<T> ForType<T>(RefitSettings? settings)
	{
		return PlatformRequestBuilderFactory.Create<T>(settings);
	}

	public static IRequestBuilder<T> ForType<T>()
	{
		return PlatformRequestBuilderFactory.Create<T>();
	}

	public static IRequestBuilder ForType(Type refitInterfaceType, RefitSettings? settings)
	{
		return PlatformRequestBuilderFactory.Create(refitInterfaceType, settings);
	}

	public static IRequestBuilder ForType(Type refitInterfaceType)
	{
		return PlatformRequestBuilderFactory.Create(refitInterfaceType);
	}
}
