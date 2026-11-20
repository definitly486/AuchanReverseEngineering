using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.Profile.Orders;
using Google.Android.Material.Button;

namespace Auchan.Android.Profile.Orders;

public class MultiOrdersItemViewHolder : CachingViewHolder
{
	private OrdersViewModel _ordersViewModel;

	private readonly TextView _orderItemDateHeader;

	private readonly TextView _multiordersTitleTextView;

	private readonly RecyclerView _ordersView;

	private readonly TextView _getOrdersButton;

	public MultiOrdersItemViewHolder(View itemView, OrdersViewModel ordersViewModel)
		: base(itemView)
	{
		_ordersViewModel = ordersViewModel;
		_orderItemDateHeader = this.RequireCachedView<TextView>(2131297765);
		_multiordersTitleTextView = this.RequireCachedView<TextView>(2131297624);
		_ordersView = this.RequireCachedView<RecyclerView>(2131298554);
		_getOrdersButton = this.RequireCachedView<MaterialButton>(2131296593);
		_ordersViewModel = ordersViewModel;
	}

	public void DoBind(IReadOnlyList<OrderItemViewModel> orderItemViewModels, ICollection<IDisposable> disposable)
	{
		OrderItemViewModel orderItemViewModel = orderItemViewModels.First();
		_orderItemDateHeader.Text = orderItemViewModel.DateHeader;
		_orderItemDateHeader.Visibility = orderItemViewModel.IsShowHeader.ToVisibility();
		string value = GrammarHelper.DeclineNoun(orderItemViewModels.Count, new string[3] { "заказ", "заказа", "заказов" });
		string value2 = GrammarHelper.DeclineNoun(orderItemViewModels.Count, new string[3] { "готов", "готовы", "готовы" });
		_multiordersTitleTextView.Text = $"{orderItemViewModels.Count} {value} {value2} к выдаче";
		ObservableRecyclerAdapter<OrderItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<OrderItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493275,
			DataSource = orderItemViewModels,
			BindViewHolderDelegate = OnBindOrderItemViewModel
		};
		_ordersView.SetAdapter(adapter);
		_ordersViewModel.BindEvents(((View)_getOrdersButton).OnClick((Action)delegate
		{
			_ordersViewModel.OnGetOrderClick(orderItemViewModels);
		})).AddTo(disposable);
	}

	private void OnBindOrderItemViewModel(CachingViewHolder holder, OrderItemViewModel model, int index, CompositeDisposable disposable)
	{
		new OrderListCellControls(holder.RequireCachedView<View>(2131297767)).Setup(model.Order);
		holder.ItemView.OnClick((Action)delegate
		{
			_ordersViewModel.NavigateToDetailsAsync(model.Order).SafeFireAndForget((Action<Exception>)null, false);
		}).AddTo(disposable);
	}
}
