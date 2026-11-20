using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.View;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.DynamicFeedback;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.PersonalCabinet.Authorization;
using Google.Android.Material.TextField;
using InputMask;

namespace Auchan.Android.Authorization;

internal class DidntReceiveSmsBottomSheet : BaseBottomSheetDialogFragment<DidntReceiveSmsViewModel>
{
	protected override int LayoutId => 2131493464;

	public override int Theme => 2131951914;

	protected override int InsetsTypeMask => WindowInsetsCompat.Type.SystemBars();

	public DidntReceiveSmsBottomSheet(Func<DidntReceiveSmsViewModel.Parameter, DidntReceiveSmsViewModel> newViewModel)
		: base((Func<Fragment, DidntReceiveSmsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<DidntReceiveSmsViewModel.Parameter>())))
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.DismissCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		ConstraintLayout numberLayout = view.RequireViewById<ConstraintLayout>(2131297719);
		TextView textView = view.RequireViewById<TextView>(2131298646);
		ImageView imageView = view.RequireViewById<ImageView>(2131296795);
		TextView textView2 = view.RequireViewById<TextView>(2131296767);
		TextInputLayout textInputLayout = view.RequireViewById<TextInputLayout>(2131297878);
		TextInputEditText textInputEditText = view.RequireViewById<TextInputEditText>(2131297877);
		TextView textView3 = view.RequireViewById<TextView>(2131298574);
		RecyclerView infoTextRecyclerView = view.RequireViewById<RecyclerView>(2131297365);
		Button button = view.RequireViewById<Button>(2131296606);
		MaskedTextChangedListener.Companion.InstallOn(textInputEditText, base.ViewModel.PhoneMask, null);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.CheckYourPhoneHint;
		textInputLayout.Hint = base.ViewModel.PhoneNumberHint;
		textInputEditText.Text = base.ViewModel.PhoneNumber;
		textView3.Text = base.ViewModel.SupportHint;
		button.Text = base.ViewModel.ButtonTitle;
		ObservableRecyclerAdapter<string, CachingViewHolder> adapter = new ObservableRecyclerAdapter<string, CachingViewHolder>
		{
			CellLayoutId = 2131493237,
			DataSource = base.ViewModel.InfoText,
			BindViewHolderDelegate = OnBindProductInList
		};
		infoTextRecyclerView.SetAdapter(adapter);
		infoTextRecyclerView.AddItemDecoration(new VerticalSpaceItemDecoration(24));
		numberLayout.Visibility = ViewStates.Gone;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			infoTextRecyclerView.Visibility = (!base.ViewModel.SendLogs).ToVisibility();
			numberLayout.Visibility = base.ViewModel.SendLogs.ToVisibility();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SendLogs")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(imageView.OnClick(base.ViewModel.DismissCommand.Trigger), button.OnClick(base.ViewModel.CallSupportCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CallSupportCommand.SafeSubscribe(delegate
		{
			GoToFeedback();
		}, ViewLifecycleOwner);
	}

	private void OnBindProductInList(CachingViewHolder viewHolder, string model, int position, CompositeDisposable disposable)
	{
		viewHolder.RequireCachedView<TextView>(2131298603).Text = model;
	}

	private void GoToFeedback()
	{
		Intent intent = new Intent(Context, typeof(FeedbackActivity));
		intent.PutExtra("ForCase", 3);
		StartActivity(intent);
	}
}
