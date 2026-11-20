using System.Net;

namespace Auchan.Common.Base.Errors.Service;

public interface IUnsuccessfulStatusCodeError : IServiceError
{
	HttpStatusCode StatusCode { get; }

	string? HttpMessage { get; }
}
public interface IUnsuccessfulStatusCodeError<out T> : IUnsuccessfulStatusCodeError, IServiceError where T : class
{
	T? Content { get; }
}
