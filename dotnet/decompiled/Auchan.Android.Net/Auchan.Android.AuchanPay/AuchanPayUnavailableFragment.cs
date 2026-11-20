using System;
using System.Reactive;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.AuchanPay.ViewModels;
using Auchan.Common.Base;
using Google.Android.Material.Button;

namespace Auchan.Android.AuchanPay;

internal class AuchanPayUnavailableFragment : BaseBottomSheetDialogFragment<AuchanPayUnavailableViewModel>
{
	private readonly TaskCompletionSource<Unit> _tcs = new TaskCompletionSource<Unit>();

	protected override int LayoutId => 2131493450;

	public override int Theme => 2131951914;

	public AuchanPayUnavailableFragment(Func<Fragment, AuchanPayUnavailableViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298655);
		ImageView imageView = view.RequireViewById<ImageView>(2131296795);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131298780);
		textView.Text = base.ViewModel.Title;
		materialButton.Text = base.ViewModel.ButtonName;
		base.ViewModel.BindEvents(imageView.OnClick(base.ViewModel.Close), materialButton.OnClick(base.ViewModel.Close)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		_tcs.TrySetResult(Unit.Default);
	}

	public Task<Unit> Execute()
	{
		return _tcs.Task;
	}
}
