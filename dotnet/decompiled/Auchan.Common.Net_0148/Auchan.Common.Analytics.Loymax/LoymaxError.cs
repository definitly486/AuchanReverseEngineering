using System.Linq;
using Auchan.Common.Analytics.Loymax.DTO;
using Auchan.Common.Base.Errors.Domain;

namespace Auchan.Common.Analytics.Loymax;

public sealed class LoymaxError : DomainError
{
	public string Code { get; }

	public LoymaxError(LoymaxResponseDto? dto)
	{
		LoymaxResponseDto.ErrorDto errorDto = dto?.Errors.FirstOrDefault();
		if (errorDto != null)
		{
			base.Message = errorDto.Message;
			Code = errorDto.Code;
		}
		else
		{
			base.Message = "unknown error";
			Code = "unknown code";
		}
	}
}
