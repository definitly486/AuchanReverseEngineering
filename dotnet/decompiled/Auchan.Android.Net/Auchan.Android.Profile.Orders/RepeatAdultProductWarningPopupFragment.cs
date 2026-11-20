using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Profile.Orders;

namespace Auchan.Android.Profile.Orders;

internal class RepeatAdultProductWarningPopupFragment : BaseBottomSheetDialogFragment<RepeatAdultProductWarningViewModel>
{
	private readonly TaskCompletionSource<bool> _tcs = new TaskCompletionSource<bool>();

	protected override int LayoutId => 2131493442;

	public override int Theme => 2131951914;

	public RepeatAdultProductWarningPopupFragment(Func<RepeatAdultProductWarningViewModel> newViewModel)
		: base((Func<Fragment, RepeatAdultProductWarningViewModel>)((Fragment thisFragment) => newViewModel()))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView title = view.RequireViewById<TextView>(2131298646);
		ImageView imageView = view.RequireViewById<ImageView>(2131296789);
		TextView description = view.RequireViewById<TextView>(2131296958);
		SnackView warning = view.RequireViewById<SnackView>(2131298820);
		Button button = view.RequireViewById<Button>(2131296587);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				title.Text = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				description.Text = base.ViewModel.Description;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Description")),
			(delegate
			{
				warning.Text = base.ViewModel.WarningInfoText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("WarningInfoText")),
			(delegate
			{
				button.Text = base.ViewModel.ButtonText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ButtonText"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(imageView.OnClick(Dismiss), ((View)button).OnClick((Action)delegate
		{
			OnAnswer(result: true);
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	public Task<bool> Execute()
	{
		return _tcs.Task;
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		_tcs.TrySetResult(result: false);
	}

	private void OnAnswer(bool result)
	{
		_tcs.TrySetResult(result);
		Dismiss();
	}
}
