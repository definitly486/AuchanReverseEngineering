using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.LoyaltyProgram.ViewModels.PointsTransfer.Points;

namespace Auchan.Android.LoyaltyProgram.PointsTransfer.Contacts;

internal class ContactsFragment : BaseBottomSheetDialogFragment<ContactsViewModel>
{
	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493461;

	protected override bool FullScreen => true;

	public ContactsFragment(Func<Fragment, ContactsViewModel> newViewModel)
		: base(newViewModel)
	{
	}

	public override void OnCreate(Bundle? savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		base.ViewModel.SetNumberAndCloseCommand.SafeSubscribe(delegate(string x)
		{
			this.ReturnResult(x);
			Dismiss();
		}, this);
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131297266);
		View view2 = view.RequireViewById<View>(2131296795);
		TextView searchTextView = view.RequireViewById<TextView>(2131298311);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131296836);
		View progressLayout = view.RequireViewById<View>(2131298079);
		ObservableRecyclerAdapter<ContactViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<ContactViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493231,
			DataSource = base.ViewModel.ContactsToDisplay,
			BindViewHolderDelegate = OnBindContact,
			ClickCallback = OnContactSelected
		};
		recyclerView.SetAdapter(adapter);
		textView.Text = base.ViewModel.ScreenTitle;
		searchTextView.Hint = base.ViewModel.SearchPlaceholder;
		base.ViewModel.ContactsToDisplay.SafeSubscribeToCollectionChanged(delegate
		{
			adapter.NotifyDataSetChanged();
		}, ViewLifecycleOwner);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			progressLayout.Visibility = base.ViewModel.InProgressState.ToVisibility();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("InProgressState")))).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(searchTextView.OnTextChanged((Action)delegate
		{
			base.ViewModel.SearchString = searchTextView.Text ?? "";
		}), view2.OnClick(Dismiss)).AutoDisposeOnDestroy(ViewLifecycleOwner);
	}

	private static void OnBindContact(CachingViewHolder holder, ContactViewModel item, int position, CompositeDisposable disposable)
	{
		TextView textView = holder.RequireCachedView<TextView>(2131297370);
		TextView textView2 = holder.RequireCachedView<TextView>(2131297228);
		TextView textView3 = holder.RequireCachedView<TextView>(2131297870);
		textView.Text = item.Initials;
		textView2.Text = item.FullName;
		textView3.Text = item.Phone;
	}

	private void OnContactSelected(CachingViewHolder cachingViewHolder, ContactViewModel contactViewModel, int position)
	{
		base.ViewModel.OnContactSelected(contactViewModel);
	}
}
