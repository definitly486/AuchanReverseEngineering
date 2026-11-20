using System;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Reviews;

namespace Auchan.Android.Reviews;

internal class ReportReviewFragment : BaseBottomSheetDialogFragment<ReportReviewViewModel>
{
	private readonly FragmentFactory _fragmentFactory;

	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493489;

	public ReportReviewFragment(Func<BrokerToken, ReportReviewViewModel> newViewModel, FragmentFactory fragmentFactory)
		: base((Func<Fragment, ReportReviewViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
		_fragmentFactory = fragmentFactory;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Cancelable = true;
		Button button = view.RequireViewById<Button>(2131298208);
		Button button2 = view.RequireViewById<Button>(2131296613);
		button.Text = base.ViewModel.ReportReviewText;
		button2.Text = base.ViewModel.CancelText;
		base.ViewModel.BindEvents(button.OnClick(base.ViewModel.ReportCommand.Trigger), button2.OnClick(base.ViewModel.CancelCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CancelCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
		base.ViewModel.OpenReportReasonCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Dismiss();
			ReportReviewReasonSelectFragment reportReviewReasonSelectFragment = _fragmentFactory.Instantiate<ReportReviewReasonSelectFragment>();
			reportReviewReasonSelectFragment.Arguments = p.ToNavBundle();
			reportReviewReasonSelectFragment.Show(base.ParentFragmentManager, null);
		}, ViewLifecycleOwner);
	}
}
