using System.Collections.Generic;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom;

public interface ICategoryRepository
{
	Task<Result<Brand, DomainError>> Brand(string brandName);

	Task<Result<List<Category>, DomainError>> TopCategories(bool promoOnly = false, bool activeOnly = false, bool cashbackOnly = false, bool showHidden = false);

	Task<Result<List<Category>, DomainError>> GetCategoriesTree(string code, bool showHidden = false);

	Task<Result<List<Category>, DomainError>> GetSubCategories(string code);

	Task<Result<List<Category>, DomainError>> GetSubCategoriesSecondLevel(string code, bool isShowHidden = false);

	Task<Result<IReadOnlyList<Category>, DomainError>> GetCachedTopCategories(bool promoOnly = false, bool activeOnly = false, bool cashbackOnly = false, bool showHidden = false);
}
