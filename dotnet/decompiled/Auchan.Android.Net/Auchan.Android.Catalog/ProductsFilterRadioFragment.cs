using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using Android.App;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.Widget;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Products.ViewModels.Filters;
using Auchan.Common.Extensions;
using EBind;

namespace Auchan.Android.Catalog;

internal sealed class ProductsFilterRadioFragment : BaseDialogFragment<ProductRadioFilterViewModel>
{
	public override int Theme => 2131951914;

	protected override int LayoutId => 2131493077;

	public ProductsFilterRadioFragment(Func<BrokerToken, ProductRadioFilterViewModel> newViewModel)
		: base((Func<AndroidX.Fragment.App.Fragment, ProductRadioFilterViewModel>)((AndroidX.Fragment.App.Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override Dialog OnCreateDialog(Bundle? savedInstanceState)
	{
		Dialog dialog = base.OnCreateDialog(savedInstanceState);
		Window? window = dialog.Window;
		if (window != null)
		{
			window.SetSoftInputMode(SoftInput.AdjustResize);
			return dialog;
		}
		return dialog;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298646);
		ImageView imageView = view.RequireViewById<ImageView>(2131296490);
		TextView textView2 = view.RequireViewById<TextView>(2131298221);
		SearchView searchView = view.RequireViewById<SearchView>(2131298322);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131298188);
		Button button = view.RequireViewById<Button>(2131296454);
		EditText searchViewText = searchView.RequireViewById<EditText>(2131298321);
		TextView notFoundText = view.RequireViewById<TextView>(2131297698);
		ObservableRecyclerAdapter<ProductRadioFilterViewModel.RadioItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<ProductRadioFilterViewModel.RadioItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493334,
			DataSource = base.ViewModel.Options,
			BindViewHolderDelegate = OnBind
		};
		recyclerView.SetLayoutManager(new LinearLayoutManager(Context));
		recyclerView.SetAdapter(adapter);
		textView.Text = base.ViewModel.Title;
		textView2.Text = base.ViewModel.ResetText;
		button.Text = base.ViewModel.ApplyText;
		notFoundText.Text = base.ViewModel.NotFoundText;
		imageView.SetOnClickListener(new ViewOnClickListener(base.ViewModel.CloseCommand.Trigger).AutoDisposeOnDestroy(ViewLifecycleOwner));
		textView2.SetOnClickListener(new ViewOnClickListener(base.ViewModel.ClearOptionCommand.Trigger).AutoDisposeOnDestroy(ViewLifecycleOwner));
		button.SetOnClickListener(new ViewOnClickListener(base.ViewModel.ApplyCommand.Trigger).AutoDisposeOnDestroy(ViewLifecycleOwner));
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				adapter.DataSource = base.ViewModel.Options;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Options")),
			(delegate
			{
				notFoundText.Visibility = base.ViewModel.NotFound.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NotFound")),
			(delegate
			{
				UpdateEditTextIfNeeded(searchViewText, base.ViewModel.SearchQuery);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SearchQuery"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		searchViewText.TextChanged += new DisposableDelegate<EventHandler<TextChangedEventArgs>>(delegate
		{
			base.ViewModel.SearchQuery = searchViewText.Text ?? "";
		}, delegate(EventHandler<TextChangedEventArgs> h)
		{
			searchViewText.TextChanged -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
	}

	private void OnBind(CachingViewHolder vh, ProductRadioFilterViewModel.RadioItemViewModel vm, int position, CompositeDisposable disposable)
	{
		CheckBox checkbox = vh.RequireCachedView<CheckBox>(2131296768);
		TextView textView = vh.RequireCachedView<TextView>(2131296862);
		vh.RequireCachedView<View>(2131296541).Visibility = vm.Option.Disabled.ToVisibility();
		textView.Text = vm.Count;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				checkbox.Checked = base.ViewModel.SelectedItemCode == vm.Option.Code;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedItemCode")),
			(delegate
			{
				checkbox.SetBoldSpan(Context, vm.Title, base.ViewModel.SearchQuery);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SearchQuery"))
		})).AddTo(disposable);
		vh.ItemView.OnClick((Action)delegate
		{
			base.ViewModel.ToggleOptionCommand.Trigger(vm);
		}).AddTo(disposable);
	}
}
