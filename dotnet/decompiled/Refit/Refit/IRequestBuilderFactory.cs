using System;

namespace Refit;

internal interface IRequestBuilderFactory
{
	IRequestBuilder<T> Create<T>(RefitSettings? settings);

	IRequestBuilder Create(Type refitInterfaceType, RefitSettings? settings);
}
