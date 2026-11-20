using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Profile.Orders;
using Java.Lang;

namespace Auchan.Android.Profile.Orders;

internal sealed class OrderCannotBeCanceledFragment : BaseBottomSheetDialogFragment<OrderCannotBeCanceledViewModel>
{
	private readonly TaskCompletionSource<AgreeState> _tcs = new TaskCompletionSource<AgreeState>();

	protected override int LayoutId => 2131493480;

	public override int Theme => 2131951914;

	public OrderCannotBeCanceledFragment(Func<Fragment, OrderCannotBeCanceledViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131297266);
		TextView textView2 = view.RequireViewById<TextView>(2131296958);
		View view2 = view.RequireViewById<View>(2131296795);
		Button button = view.RequireViewById<Button>(2131296606);
		textView.Text = base.ViewModel.ScreenTitle;
		textView2.Text = base.ViewModel.DescriptionText;
		button.SetText(GetCallSupportButtonText(), TextView.BufferType.Spannable);
		base.ViewModel.BindEvents(view2.OnClick((Action)delegate
		{
			OnAnswer(AgreeState.None);
		}), ((View)button).OnClick((Action)delegate
		{
			OnAnswer(AgreeState.Yes);
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private ICharSequence GetCallSupportButtonText()
	{
		SpannableString spannableString = new SpannableString("$    " + base.ViewModel.CallSupportButtonText);
		spannableString.SetSpan(new ImageSpan(Context, 2131231274), 0, 1, SpanTypes.ExclusiveExclusive);
		return spannableString;
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
