using System.Linq;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;
using Auchan.Common.Feedback.DTO;

namespace Auchan.Common.Feedback;

public static class FeedbackErrorExtensions
{
	public static DomainError ToFeedbackError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError<FeedbackResponseDto> { Content: not null } unsuccessfulStatusCodeError && unsuccessfulStatusCodeError.Content.Errors != null && unsuccessfulStatusCodeError.Content.Errors.Any())
		{
			return new FeedbackError
			{
				Message = unsuccessfulStatusCodeError.Content.Errors.First().Message
			};
		}
		return serviceError.ToBaseDomainError();
	}

	public static DomainError ToFeedbackAttachmentError(this ServiceError serviceError)
	{
		if (serviceError is IUnsuccessfulStatusCodeError<FeedbackAttachmentResponseDto> { Content: not null } unsuccessfulStatusCodeError && unsuccessfulStatusCodeError.Content.Errors != null && unsuccessfulStatusCodeError.Content.Errors.Any())
		{
			return new FeedbackError
			{
				Message = unsuccessfulStatusCodeError.Content.Errors.First().Message
			};
		}
		return serviceError.ToBaseDomainError();
	}
}
