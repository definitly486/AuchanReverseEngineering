using System.Net;

namespace Auchan.Common.Base.Errors.Service;

public class UnsuccessfulStatusCodeError : ServiceError, IUnsuccessfulStatusCodeError, IServiceError
{
	public string? HttpMessage { get; private set; }

	public HttpStatusCode StatusCode { get; }

	public UnsuccessfulStatusCodeError(HttpStatusCode statusCode, string? contentText)
	{
		StatusCode = statusCode;
		if (!string.IsNullOrWhiteSpace(contentText))
		{
			Message = contentText;
			HttpMessage = contentText;
		}
	}
}
public class UnsuccessfulStatusCodeError<T> : UnsuccessfulStatusCodeError, IUnsuccessfulStatusCodeError<T>, IUnsuccessfulStatusCodeError, IServiceError where T : class
{
	public T? Content { get; }

	public UnsuccessfulStatusCodeError(HttpStatusCode statusCode, string? contentText, T? content)
		: base(statusCode, contentText)
	{
		Content = content;
	}
}
