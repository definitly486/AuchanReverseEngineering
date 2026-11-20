using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Reviews.Model;

namespace Auchan.Common.Reviews;

public sealed class ReviewSortViewModel : OptionSelectorViewModel<SelectionItemViewModel<ReviewSortItem, ReviewSortViewModel>, ReviewSortItem>
{
	public ReviewSortViewModel(BrokerToken parameter)
		: base(parameter)
	{
		base.ApplyButtonTitle = "Применить";
		base.Title = "Сортировка";
	}

	protected override SelectionItemViewModel<ReviewSortItem, ReviewSortViewModel> NewOption(ReviewSortItem item)
	{
		return new SelectionItemViewModel<ReviewSortItem, ReviewSortViewModel>(item, this, item == base.Argument.Preselected);
	}
}
