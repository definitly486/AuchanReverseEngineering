using System;
using System.Net.Http;

namespace Refit;

public interface IRequestBuilder
{
	Func<HttpClient, object[], object?> BuildRestResultFuncForMethod(string methodName, Type[]? parameterTypes = null, Type[]? genericArgumentTypes = null);
}
public interface IRequestBuilder<T> : IRequestBuilder
{
}
