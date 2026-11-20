using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Extensions;
using Auchan.Common.Reviews;
using Google.Android.Material.RadioButton;

namespace Auchan.Android.Reviews;

internal class ReportReviewReasonSelectFragment : BaseBottomSheetDialogFragment<ReportReviewReasonSelectViewModel>
{
	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493490;

	public ReportReviewReasonSelectFragment(Func<BrokerToken, ReportReviewReasonSelectViewModel> newViewModel)
		: base((Func<Fragment, ReportReviewReasonSelectViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131297266);
		View view2 = view.RequireViewById<View>(2131296795);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131298157);
		Button reportButton = view.RequireViewById<Button>(2131298208);
		recyclerView.SetAdapter(new ObservableRecyclerAdapter<string, CachingViewHolder>
		{
			CellLayoutId = 2131493266,
			DataSource = base.ViewModel.Reasons,
			BindViewHolderDelegate = OnBindItem
		});
		textView.Text = base.ViewModel.TitleText;
		reportButton.Text = base.ViewModel.ReportText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			SetButtonColor(reportButton, base.ViewModel.ReportAvailable);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReportAvailable")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(view2.OnClick(base.ViewModel.CloseCommand.Trigger), reportButton.OnClick(base.ViewModel.ReportCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}

	private void OnBindItem(CachingViewHolder holder, string item, int position, CompositeDisposable disposable)
	{
		MaterialRadioButton element = (MaterialRadioButton)holder.ItemView;
		element.Text = item;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			element.Checked = base.ViewModel.SelectedReason == item;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedReason")))).AddTo(disposable);
		base.ViewModel.BindEvents(holder.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.SelectReasonCommand.Trigger(item);
		})).AddTo(disposable);
	}

	private void SetButtonColor(Button button, bool enabled)
	{
		int id = (enabled ? 2131099791 : 2131100615);
		button.Enabled = enabled;
		button.BackgroundTintList = ColorStateList.ValueOf(new Color(ContextCompat.GetColor(RequireContext(), id)));
	}
}
