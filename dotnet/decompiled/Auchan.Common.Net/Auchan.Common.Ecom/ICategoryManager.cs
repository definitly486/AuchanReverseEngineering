using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Home;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom;

public interface ICategoryManager
{
	Task<Result<IReadOnlyList<CategoryItemViewModel>, DomainError>> GetTopCategories();
}
