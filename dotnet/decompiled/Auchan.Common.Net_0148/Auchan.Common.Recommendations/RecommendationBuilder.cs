using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Auchan.Common.Recommendations.API.DTO;
using Auchan.Common.Recommendations.Models;
using DryIoc;

namespace Auchan.Common.Recommendations;

public sealed class RecommendationBuilder
{
	private readonly List<RecommendationSection> _blocks = new List<RecommendationSection>();

	private readonly IResolver _resolver;

	private bool _showShevronButton;

	public RecommendationBuilder(IResolver resolver)
	{
		_resolver = resolver;
	}

	private RecommendationBuilder Add(RecommendationSection block)
	{
		_blocks.Add(block);
		return this;
	}

	public RecommendationBuilder Add(IAlgorithm algorithm)
	{
		return Add(new global::_003C_003Ez__ReadOnlySingleElementList<IAlgorithm>(algorithm));
	}

	public RecommendationBuilder Add(IReadOnlyList<IAlgorithm> algorithms)
	{
		return Add(new RecommendationSection
		{
			Algorithms = algorithms
		});
	}

	public RecommendationBuilder AddRelatedWithPopularityPenalty(string title, string identifier, IReadOnlyList<string> productIds)
	{
		return Add(RelatedWithPopularityPenaltyAlgorithm.Create(_resolver, new RelatedWithPopularityPenaltyArgument
		{
			Title = title,
			BlockId = identifier,
			ProductIds = productIds
		}));
	}

	public RecommendationBuilder AddRelated(string title, string identifier, IReadOnlyList<string> productIds)
	{
		return Add(RelatedAlgorithm.Create(_resolver, new RelatedArgument
		{
			Title = title,
			ProductIds = productIds,
			BlockId = identifier
		}));
	}

	public RecommendationBuilder AddSimilar(string title, (string analogsId, string alternativeId) identifiers, IReadOnlyList<string> productIds)
	{
		IAlgorithm[] array = new IAlgorithm[2];
		IResolver resolver = _resolver;
		AnalogsOutOfStockProductsArgument obj = new AnalogsOutOfStockProductsArgument
		{
			Title = title,
			ProductIds = productIds
		};
		(obj.BlockId, _) = identifiers;
		array[0] = AnalogsOutOfStockProductsAlgorithm.Create(resolver, obj);
		array[1] = AlternativesAlgorithm.Create(_resolver, new AlternativesArgument
		{
			Title = title,
			ProductIds = productIds,
			BlockId = identifiers.alternativeId
		});
		return Add(new global::_003C_003Ez__ReadOnlyArray<IAlgorithm>(array));
	}

	public RecommendationBuilder AddAlternative(string title, string identifier, IReadOnlyList<string> productIds)
	{
		return Add(AlternativesAlgorithm.Create(_resolver, new AlternativesArgument
		{
			Title = title,
			ProductIds = productIds,
			BlockId = identifier
		}));
	}

	public RecommendationBuilder AddPopularEndless(string title, string personalizedIdentifier, string genericIdentifier)
	{
		return Add(PopularEndlessAlgorithm.Create(_resolver, new PopularEndlessArgument
		{
			Title = title,
			BlockId = "",
			PersonalizedBlockId = personalizedIdentifier,
			GenericBlockId = genericIdentifier
		}));
	}

	public RecommendationBuilder AddPopularInCategoryByPath(string title, string identifier, IReadOnlyList<string> categoryPaths)
	{
		return Add(PopularInCategoryByPathAlgorithm.Create(_resolver, new PopularInCategoryByPathArgument
		{
			Title = title,
			CategoryPaths = categoryPaths,
			BlockId = identifier
		}));
	}

	public RecommendationBuilder AddSaleByPopularInCategoryByPath(string title, string identifier, IReadOnlyList<string> categoryPaths)
	{
		return Add(SaleByPopularInCategoryByPathAlgorithm.Create(_resolver, new SaleByPopularInCategoryByPathArgument
		{
			Title = title,
			CategoryPaths = categoryPaths,
			BlockId = identifier
		}));
	}

	public RecommendationBuilder AddSearch(string title, string identifier, string searchPhrase)
	{
		return Add(SearchAlgorithm.Create(_resolver, new SearchArgument
		{
			Title = title,
			SearchPhrase = searchPhrase,
			BlockId = identifier
		}));
	}

	public RecommendationBuilder AddPersonal(string title, string identifier)
	{
		return Add(PersonalAlgorithm.Create(_resolver, new AlgorithmArgument
		{
			Title = title,
			BlockId = identifier
		}));
	}

	public RecommendationBuilder AddNovelty(string title)
	{
		return Add(NoveltyAlgorithm.Create(_resolver, new AlgorithmArgument
		{
			Title = title,
			BlockId = ""
		}));
	}

	public RecommendationBuilder AddPersonalOrdered(string title, string identifier)
	{
		return Add(PersonalOrderedAlgorithm.Create(_resolver, new AlgorithmArgument
		{
			Title = title,
			BlockId = identifier
		}));
	}

	public RecommendationBuilder AddPersonalViewed(string title, string identifier)
	{
		return Add(PersonalViewedAlgorithm.Create(_resolver, new AlgorithmArgument
		{
			Title = title,
			BlockId = identifier
		}));
	}

	public RecommendationBuilder AddPersonalViewedEndless(string title, string identifier)
	{
		return Add(PersonalViewedEndlessAlgorithm.Create(_resolver, new AlgorithmArgument
		{
			Title = title,
			BlockId = identifier
		}));
	}

	public RecommendationBuilder AddAnyProductPlacement(string title, PlacementId placementId, string identifier)
	{
		return Add(AnyPlacementAlgorithm.Create(_resolver, new ProductPlacementArgument
		{
			Title = title,
			PlacementId = placementId,
			BlockId = identifier
		}));
	}

	public RecommendationBuilder AddProductGroupPlacements(string title, PlacementId placementId, IReadOnlyList<string> gimaIds, string identifier)
	{
		long t = 0L;
		ImmutableList<long> gimaIds2 = (from i in gimaIds
			where long.TryParse(i, out t)
			select t).ToImmutableList();
		return AddProductGroupPlacements(title, placementId, gimaIds2, identifier);
	}

	public RecommendationBuilder AddProductGroupPlacements(string title, PlacementId placementId, IReadOnlyList<long> gimaIds, string identifier)
	{
		return Add(ProductGroupPlacementsAlgorithm.Create(_resolver, new ProductGroupPlacementsArgument
		{
			Title = title,
			PlacementId = placementId,
			GimaIds = gimaIds,
			BlockId = identifier
		}));
	}

	public RecommendationBuilder AddProductPlacementsAndRelated(string title, PlacementId placementId, string gimaId, string identifier)
	{
		if (!long.TryParse(gimaId, out var result))
		{
			return this;
		}
		return AddProductPlacementsAndRelated(title, placementId, result, identifier);
	}

	public RecommendationBuilder AddProductPlacementsAndRelated(string title, PlacementId placementId, long gimaId, string identifier)
	{
		return Add(ProductPlacementsAndRelatedAlgorithm.Create(_resolver, new ProductPlacementsAndRelatedArgument
		{
			Title = title,
			PlacementId = placementId,
			ProductGimaId = gimaId,
			BlockId = identifier
		}));
	}

	public RecommendationBuilder AddProductPlacementsAndCrossSellForLargeBaskets(string title, PlacementId placementId, string gimaId, string identifier)
	{
		if (!long.TryParse(gimaId, out var result))
		{
			return this;
		}
		return AddProductPlacementsAndCrossSellForLargeBaskets(title, placementId, result, identifier);
	}

	public RecommendationBuilder AddProductPlacementsAndCrossSellForLargeBaskets(string title, PlacementId placementId, long gimaId, string identifier)
	{
		return Add(ProductPlacementsAndCrossSellForLargeBasketsAlgorithm.Create(_resolver, new ProductPlacementsAndCrossSellForLargeBasketsArgument
		{
			Title = title,
			PlacementId = placementId,
			ProductGimaId = gimaId,
			BlockId = identifier
		}));
	}

	public RecommendationBuilder AddCategoryPlacementsAndPopularsInCategory(string title, PlacementId placementId, string categoryPath, string identifier)
	{
		return Add(CategoryPlacementsAndPopularsInCategoryAlgorithm.Create(_resolver, new CategoryPlacementsArgument
		{
			Title = title,
			PlacementId = placementId,
			CategoryPath = categoryPath,
			BlockId = identifier
		}));
	}

	public RecommendationBuilder ShowShevronButton(bool show)
	{
		_showShevronButton = show;
		return this;
	}

	public RecommendationBuilder WithSkip(int count)
	{
		if (_blocks.Count == 0)
		{
			throw new InvalidOperationException("there no blocks yet");
		}
		List<RecommendationSection> blocks = _blocks;
		foreach (IAlgorithm algorithm in blocks[blocks.Count - 1].Algorithms)
		{
			algorithm.ToSkip = count;
		}
		return this;
	}

	public LoadRequest Build()
	{
		return new LoadRequest
		{
			Sections = _blocks.ToArray(),
			ShowShevronButton = _showShevronButton
		};
	}
}
