using Auchan.Common.Base;
using Auchan.Common.Ecom.Search.Models;

namespace Auchan.Common.Ecom.Search;

public sealed class SearchTextRecomItemViewModel : ElementViewModel
{
	private readonly SearchAutohintPopular _popular;

	public string Title => _popular.Text;

	public SearchTextRecomItemViewModel(SearchAutohintPopular popular)
	{
		_popular = popular;
	}
}
