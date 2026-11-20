using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using CSharpFunctionalExtensions;

namespace Auchan.Common.AdminTool;

public interface IPromotionRepository
{
	Task<Result<List<Promotion>, DomainError>> Promotions(string regionFiasId, string storeId, List<string>? segments);

	Task<Result<ImmutableList<ExtraPromotion>, DomainError>> ExtraPromotions(string regionFiasId);
}
