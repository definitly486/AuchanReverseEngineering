using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Profile.Orders;

namespace Auchan.Android.Profile.Orders;

internal sealed class AskDoYouWantToCancelOrderFragment : BaseBottomSheetDialogFragment<AskDoYouWantToCancelOrderViewModel>
{
	private readonly TaskCompletionSource<AgreeState> _tcs = new TaskCompletionSource<AgreeState>();

	protected override int LayoutId => 2131493446;

	public override int Theme => 2131951914;

	public AskDoYouWantToCancelOrderFragment(Func<AskDoYouWantToCancelOrderViewModel> newViewModel)
		: base((Func<Fragment, AskDoYouWantToCancelOrderViewModel>)((Fragment thisFragment) => newViewModel()))
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131297266);
		View view2 = view.RequireViewById<View>(2131296795);
		Button button = view.RequireViewById<Button>(2131296613);
		Button button2 = view.RequireViewById<Button>(2131297997);
		textView.Text = base.ViewModel.ScreenTitle;
		button.Text = base.ViewModel.CancelButtonText;
		button2.Text = base.ViewModel.ProceedButtonText;
		base.ViewModel.BindEvents(view2.OnClick((Action)delegate
		{
			OnAnswer(AgreeState.None);
		}), ((View)button2).OnClick((Action)delegate
		{
			OnAnswer(AgreeState.Yes);
		}), ((View)button).OnClick((Action)delegate
		{
			OnAnswer(AgreeState.No);
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	public Task<AgreeState> Execute()
	{
		return _tcs.Task;
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		_tcs.TrySetResult(AgreeState.None);
	}

	private void OnAnswer(AgreeState result)
	{
		_tcs.TrySetResult(result);
		Dismiss();
	}
}
