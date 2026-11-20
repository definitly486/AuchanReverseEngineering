using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Android.Graphics;
using Android.OS;
using Android.Text;
using Android.Text.Style;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using Auchan.Android.Base;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products;
using Auchan.Common.Helpers;
using Google.Android.Material.Button;

namespace Auchan.Android.Ecom.Product;

internal class AskDeliveryMethodFragment : BaseBottomSheetDialogFragment<AskDeliveryTypeViewModel>
{
	private readonly TaskCompletionSource<AgreeState> _tcs = new TaskCompletionSource<AgreeState>();

	protected override int LayoutId => 2131493445;

	public override int Theme => 2131951914;

	public AskDeliveryMethodFragment(Func<AskDeliveryTypeViewModel.Parameter, AskDeliveryTypeViewModel> newViewModel)
		: base((Func<Fragment, AskDeliveryTypeViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<AskDeliveryTypeViewModel.Parameter>())))
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.OnAnswer.ObserveOn(MainThread.Scheduler).Subscribe(OnAnswer).AutoDispose(this, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView titleTextView = view.RequireViewById<TextView>(2131298649);
		ImageView imageView = view.RequireViewById<ImageView>(2131296791);
		TextView textView = view.RequireViewById<TextView>(2131296962);
		MaterialButton materialButton = view.RequireViewById<MaterialButton>(2131296459);
		AppCompatButton appCompatButton = view.RequireViewById<AppCompatButton>(2131296458);
		SnackView snackInfo = view.RequireViewById<SnackView>(2131297900);
		materialButton.Text = base.ViewModel.YesButtonText;
		appCompatButton.Text = base.ViewModel.NoButtonText;
		snackInfo.Text = base.ViewModel.AboutUpdateCartText;
		SpannableStringBuilder spannableStringBuilder = new SpannableStringBuilder(base.ViewModel.Message);
		spannableStringBuilder.SetSpan(new StyleSpan(TypefaceStyle.Bold), base.ViewModel.BoldMessageStartEnd.Item1, base.ViewModel.BoldMessageStartEnd.Item2, SpanTypes.ExclusiveExclusive);
		textView.TextFormatted = spannableStringBuilder;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				titleTextView.Text = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				snackInfo.Visibility = base.ViewModel.IsAboutUpdateCartVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAboutUpdateCartVisible"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)imageView).OnClick((Action)delegate
		{
			base.ViewModel.Reply(AgreeState.None);
		}), ((View)materialButton).OnClick((Action)delegate
		{
			base.ViewModel.Reply(AgreeState.Yes);
		}), ((View)appCompatButton).OnClick((Action)delegate
		{
			base.ViewModel.Reply(AgreeState.No);
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
