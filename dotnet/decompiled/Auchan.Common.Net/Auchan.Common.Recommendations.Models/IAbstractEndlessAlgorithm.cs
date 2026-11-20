namespace Auchan.Common.Recommendations.Models;

public interface IAbstractEndlessAlgorithm : IAlgorithm
{
	int ProductsOffset { get; }

	bool LoadingFailed { get; set; }

	bool LoadedAll { get; }
}
