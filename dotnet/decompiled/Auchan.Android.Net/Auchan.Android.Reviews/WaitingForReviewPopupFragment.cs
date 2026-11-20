using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Reviews;
using Google.Android.Material.Button;

namespace Auchan.Android.Reviews;

internal class WaitingForReviewPopupFragment : BaseBottomSheetDialogFragment<WaitingForReviewPopupViewModel>
{
	private readonly TaskCompletionSource<bool> _tcs = new TaskCompletionSource<bool>();

	protected override int LayoutId => 2131493505;

	public override int Theme => 2131951914;

	public WaitingForReviewPopupFragment(Func<Fragment, WaitingForReviewPopupViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public Task<bool> Execute()
	{
		return _tcs.Task;
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298649);
		ImageView imageView = view.RequireViewById<ImageView>(2131296791);
		TextView textView2 = view.RequireViewById<TextView>(2131296962);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131296358);
		materialButton.Text = base.ViewModel.AddReviewButtonText;
		textView2.Text = base.ViewModel.Description;
		textView.Text = base.ViewModel.Title;
		base.ViewModel.BindEvents(imageView.OnClick(base.ViewModel.CloseCommand.Trigger), materialButton.OnClick(base.ViewModel.AddReviewCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, this);
		base.ViewModel.AddReviewCommand.SafeSubscribe(delegate
		{
			OnAddReview();
		}, this);
	}

	private void OnAddReview()
	{
		_tcs.TrySetResult(result: true);
		Dismiss();
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		_tcs.TrySetResult(result: false);
	}
}
