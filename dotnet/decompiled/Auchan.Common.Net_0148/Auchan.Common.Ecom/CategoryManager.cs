using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Home;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom;

public sealed class CategoryManager : ICategoryManager
{
	private readonly ICategoryRepository _categoryRepository;

	public CategoryManager(ICategoryRepository categoryRepository)
	{
		_categoryRepository = categoryRepository;
	}

	public async Task<Result<IReadOnlyList<CategoryItemViewModel>, DomainError>> GetTopCategories()
	{
		Result<List<Category>, DomainError> result = await _categoryRepository.TopCategories();
		if (result.TryGetValue(out var value))
		{
			return (Result<IReadOnlyList<CategoryItemViewModel>, DomainError>)(IReadOnlyList<CategoryItemViewModel>)value.Select((Category i) => new CategoryItemViewModel(i)).ToImmutableList();
		}
		return result.Error;
	}
}
