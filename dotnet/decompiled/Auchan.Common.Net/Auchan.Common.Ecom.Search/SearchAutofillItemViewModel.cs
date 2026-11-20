using Auchan.Common.Base;
using Auchan.Common.Ecom.Search.Models;

namespace Auchan.Common.Ecom.Search;

public sealed class SearchAutofillItemViewModel : ElementViewModel
{
	private readonly SearchAutohintAutofill _item;

	public string Text => _item.Text;

	public string FullText => _item.FullText;

	public SearchAutofillItemViewModel(SearchAutohintAutofill item)
	{
		_item = item;
	}
}
