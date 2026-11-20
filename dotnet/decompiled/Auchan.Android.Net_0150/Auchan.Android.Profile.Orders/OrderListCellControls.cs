using System.Reactive.Disposables;
using Android.Content.Res;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Android.Profile.Orders.Extensions;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Android.Profile.Orders;

internal sealed class OrderListCellControls
{
	private readonly View _view;

	private readonly TextView _orderNumber;

	private readonly TextView _changedText;

	private readonly TextView _status;

	private readonly View _withChangedTextLayout;

	private readonly TextView _statusTextWithChanged;

	private readonly TextView _dateTime;

	private readonly TextView _goodsCount;

	private readonly RecyclerView _orderItemsProducts;

	private readonly TextView _deliveryDescription;

	private readonly TextView _price;

	public OrderListCellControls(View view)
	{
		_view = view;
		_orderNumber = view.RequireViewById<TextView>(2131297768);
		_changedText = view.RequireViewById<TextView>(2131296747);
		_status = view.RequireViewById<TextView>(2131298478);
		_withChangedTextLayout = view.RequireViewById<View>(2131298835);
		_statusTextWithChanged = view.RequireViewById<TextView>(2131298480);
		_dateTime = view.RequireViewById<TextView>(2131296891);
		_goodsCount = view.RequireViewById<TextView>(2131297249);
		_orderItemsProducts = view.RequireViewById<RecyclerView>(2131297766);
		_deliveryDescription = view.RequireViewById<TextView>(2131296931);
		_price = view.RequireViewById<TextView>(2131297977);
		view.Clickable = false;
		view.Focusable = false;
	}

	public void Setup(IListOrderModel model, bool showIcons = true)
	{
		_orderNumber.Text = model.NumberText;
		_withChangedTextLayout.Visibility = model.HasChanges.ToVisibility();
		_changedText.Text = model.HasChangesText;
		_status.Visibility = model.NotChanged.ToVisibility();
		TextView statusTextWithChanged = _statusTextWithChanged;
		string text = (_status.Text = model.StatusText);
		statusTextWithChanged.Text = text;
		ColorStateList textColor = ColorStateList.ValueOf(model.Status.GetTextArgb());
		_status.SetTextColor(textColor);
		_statusTextWithChanged.SetTextColor(textColor);
		TextView statusTextWithChanged2 = _statusTextWithChanged;
		ColorStateList backgroundTintList = (_status.BackgroundTintList = ColorStateList.ValueOf(model.Status.GetBackgroundArgb()));
		statusTextWithChanged2.BackgroundTintList = backgroundTintList;
		_dateTime.Text = model.DateTimeText;
		_goodsCount.Text = model.GoodsCountText;
		_deliveryDescription.Text = model.DeliveryDescriptionText;
		_price.Text = model.PriceText;
		if (showIcons)
		{
			_orderItemsProducts.Visibility = ViewStates.Visible;
			ObservableRecyclerAdapter<ProductModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<ProductModel, CachingViewHolder>
			{
				CellLayoutId = 2131493269,
				DataSource = model.Products,
				BindViewHolderDelegate = BindProduct
			};
			_orderItemsProducts.SetAdapter(adapter);
		}
		else
		{
			_orderItemsProducts.Visibility = ViewStates.Gone;
			_orderItemsProducts.SetAdapter(null);
		}
	}

	private void BindProduct(CachingViewHolder holder, ProductModel model, int index, CompositeDisposable disposable)
	{
		ImageView imageView = holder.RequireCachedView<ImageView>(2131297319);
		if (model.ImageUrl != null)
		{
			imageView.FromUrl(model.ImageUrl);
		}
		else
		{
			imageView.SetImageResource(2131689487);
		}
	}
}
