using System.Collections.Generic;

namespace Auchan.Common.Profile.Orders.Dto;

internal interface IAdditionErrorDto
{
	IReadOnlyList<AddtionErrorDto>? Errors { get; init; }
}
