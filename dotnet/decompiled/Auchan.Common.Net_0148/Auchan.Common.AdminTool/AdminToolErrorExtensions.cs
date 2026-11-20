using System.Linq;
using System.Net;
using Auchan.Common.AdminTool.DTO;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Base.Errors.Service;

namespace Auchan.Common.AdminTool;

public static class AdminToolErrorExtensions
{
	public static DomainError ToUpdateRequiredError(this ServiceError serviceError)
	{
		if (serviceError is UnsuccessfulStatusCodeError<AppConfigDto> unsuccessfulStatusCodeError)
		{
			AppConfigDto content = unsuccessfulStatusCodeError.Content;
			if (unsuccessfulStatusCodeError.StatusCode == HttpStatusCode.Forbidden && content != null && content.Errors.Count > 0 && content.Errors.First().Code == "update_required")
			{
				return new UpdateRequiredError(content.Errors.First().Message);
			}
		}
		return serviceError.ToBaseDomainError();
	}
}
