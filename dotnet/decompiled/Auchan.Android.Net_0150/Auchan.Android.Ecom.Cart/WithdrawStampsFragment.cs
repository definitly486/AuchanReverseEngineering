using System;
using System.Reactive.Disposables;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Cart.StampsWithdrawViewModel;
using Google.Android.Material.Button;
using Microsoft.Maui.Devices;

namespace Auchan.Android.Ecom.Cart;

internal sealed class WithdrawStampsFragment : BaseBottomSheetDialogFragment<StampsWithdrawProductsViewModel>
{
	private TextView _title;

	private TextView _collectedStamps;

	private TextView _descripion;

	private MaterialButton _continueButton;

	private MaterialButton _dontApplyButton;

	private RecyclerView _productsRecyclerView;

	private ObservableRecyclerAdapter<StampsWithdrawProductItemViewModel, CachingViewHolder> _productsAdapter;

	private int MaxRows => 3;

	protected override int LayoutId => 2131493506;

	public override int Theme => 2131951914;

	public WithdrawStampsFragment(Func<BrokerToken, StampsWithdrawProductsViewModel> newViewModel)
		: base((Func<Fragment, StampsWithdrawProductsViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		InitializeViews();
		SetValues();
		DoBind();
	}

	private void InitializeViews()
	{
		_title = View.RequireViewById<TextView>(2131298646);
		_descripion = View.RequireViewById<TextView>(2131296313);
		_collectedStamps = View.RequireViewById<TextView>(2131296802);
		_continueButton = View.RequireViewById<MaterialButton>(2131296846);
		_dontApplyButton = View.RequireViewById<MaterialButton>(2131297015);
		_productsRecyclerView = View.RequireViewById<RecyclerView>(2131298039);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, this);
	}

	private void SetValues()
	{
		_title.Text = base.ViewModel.ScreenTitle;
		_collectedStamps.AddLinkedText(base.ViewModel.CollectedStampsLabel, new Color(ContextCompat.GetColor(Context, 2131099854)), underlineLinks: false);
		_descripion.Text = base.ViewModel.DetailsLabel;
		_continueButton.Text = base.ViewModel.ApplyButtonText;
		_dontApplyButton.Text = base.ViewModel.DontApplyButtonText;
	}

	private void DoBind()
	{
		base.ViewModel.BindEvents(_dontApplyButton.OnClick(base.ViewModel.OnNoTapped), _continueButton.OnClick(base.ViewModel.OnYesTapped)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		_productsAdapter = new ObservableRecyclerAdapter<StampsWithdrawProductItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493364,
			BindViewHolderDelegate = BindProduct,
			DataSource = base.ViewModel.Products
		};
		int num = 120;
		double num2 = (double)Converter.PxToDp((float)DeviceDisplay.MainDisplayInfo.Height) * 0.95 - 340.0;
		int height = Math.Min(Math.Min(3, (int)Math.Truncate(num2 / (double)num)), base.ViewModel.Products.Count) * Converter.DpToPx(num);
		_productsRecyclerView.LayoutParameters.Height = height;
		_productsRecyclerView.SetAdapter(_productsAdapter);
	}

	private void BindProduct(CachingViewHolder viewHolder, StampsWithdrawProductItemViewModel item, int index, CompositeDisposable disposable)
	{
		View view = viewHolder.RequireCachedView<View>(2131298353);
		ImageView imageView = viewHolder.RequireCachedView<ImageView>(2131298011);
		TextView textView = viewHolder.RequireCachedView<TextView>(2131298646);
		TextView textView2 = viewHolder.RequireCachedView<TextView>(2131297988);
		TextView textView3 = viewHolder.RequireCachedView<TextView>(2131297737);
		if (index == 0)
		{
			view.Visibility = ViewStates.Gone;
		}
		textView.Text = item.Title;
		textView2.Text = item.Price;
		textView3.Visibility = item.HasOldPrice.ToVisibility();
		if (item.HasOldPrice)
		{
			textView3.Text = item.OldPrice;
		}
		imageView.FromUrl(item.ImageUrl);
	}
}
