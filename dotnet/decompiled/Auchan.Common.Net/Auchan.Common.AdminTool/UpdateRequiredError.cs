using Auchan.Common.Base.Errors.Domain;

namespace Auchan.Common.AdminTool;

public class UpdateRequiredError : DomainError
{
	public UpdateRequiredError(string message)
	{
		base.Message = message;
	}
}
