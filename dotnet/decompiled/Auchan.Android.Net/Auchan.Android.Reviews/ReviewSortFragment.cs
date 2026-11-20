using System;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Common.Common;
using Auchan.Common.Reviews;
using Auchan.Common.Reviews.Model;

namespace Auchan.Android.Reviews;

internal sealed class ReviewSortFragment : OptionDialogFragment<ReviewSortItem, ReviewSortViewModel>
{
	public ReviewSortFragment(Func<BrokerToken, ReviewSortViewModel> newViewModel)
		: base((Func<Fragment, ReviewSortViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}
}
