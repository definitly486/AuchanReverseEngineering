using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;

namespace Refit;

internal class CachedRequestBuilderImplementation<T> : CachedRequestBuilderImplementation, IRequestBuilder<T>, IRequestBuilder
{
	public CachedRequestBuilderImplementation(IRequestBuilder<T> innerBuilder)
		: base(innerBuilder)
	{
	}
}
internal class CachedRequestBuilderImplementation : IRequestBuilder
{
	private readonly IRequestBuilder innerBuilder;

	internal readonly ConcurrentDictionary<MethodTableKey, Func<HttpClient, object[], object?>> MethodDictionary = new ConcurrentDictionary<MethodTableKey, Func<HttpClient, object[], object>>();

	public CachedRequestBuilderImplementation(IRequestBuilder innerBuilder)
	{
		this.innerBuilder = innerBuilder ?? throw new ArgumentNullException("innerBuilder");
	}

	public Func<HttpClient, object[], object?> BuildRestResultFuncForMethod(string methodName, Type[]? parameterTypes = null, Type[]? genericArgumentTypes = null)
	{
		MethodTableKey key = new MethodTableKey(methodName, parameterTypes ?? Array.Empty<Type>(), genericArgumentTypes ?? Array.Empty<Type>());
		if (MethodDictionary.TryGetValue(key, out Func<HttpClient, object[], object> value))
		{
			return value;
		}
		return MethodDictionary.GetOrAdd(new MethodTableKey(methodName, parameterTypes?.ToArray() ?? Array.Empty<Type>(), genericArgumentTypes?.ToArray() ?? Array.Empty<Type>()), (MethodTableKey _) => innerBuilder.BuildRestResultFuncForMethod(methodName, parameterTypes, genericArgumentTypes));
	}
}
