using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Profile.Orders.Dto;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Profile.Orders.Services;

public interface IOrderCancellationReasonsService
{
	Task<Result<PossibleOrderCancellationReasonsDto, DomainError>> GetOrderCancellationReasonsAsync();
}
