using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products;
using Google.Android.Material.Button;

namespace Auchan.Android.Ecom.Product;

internal class UnsubscribeProductFragment : BaseBottomSheetDialogFragment<UnsubscribeProductViewModel>
{
	private readonly TaskCompletionSource<AgreeState> _tcs = new TaskCompletionSource<AgreeState>();

	protected override int LayoutId => 2131493447;

	public override int Theme => 2131951914;

	public UnsubscribeProductFragment(Func<Fragment, UnsubscribeProductViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.FindViewById<TextView>(2131298649);
		ImageView imageView = view.FindViewById<ImageView>(2131296791);
		TextView? textView2 = view.FindViewById<TextView>(2131296962);
		MaterialButton materialButton = view.FindViewById<MaterialButton>(2131296459);
		AppCompatButton appCompatButton = view.FindViewById<AppCompatButton>(2131296458);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.Message;
		materialButton.Text = base.ViewModel.YesButtonText;
		appCompatButton.Text = base.ViewModel.NoButtonText;
		base.ViewModel.BindEvents(((View)imageView).OnClick((Action)delegate
		{
			OnAnswer(AgreeState.None);
		}), ((View)materialButton).OnClick((Action)delegate
		{
			OnAnswer(AgreeState.Yes);
		}), ((View)appCompatButton).OnClick((Action)delegate
		{
			OnAnswer(AgreeState.No);
		})).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
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
