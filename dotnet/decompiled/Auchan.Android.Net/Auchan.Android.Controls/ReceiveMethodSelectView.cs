using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using AndroidX.RecyclerView.Widget;
using Auchan.Android.Base;
using Auchan.Android.Common;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.AddressStoreSelection;
using Auchan.Common.Extensions;
using EBind;
using VisibilitySwitch;

namespace Auchan.Android.Controls;

[Register("Auchan.Android.Controls.ReceiveMethodSelectView")]
public class ReceiveMethodSelectView : BaseCustomView<ReceiveMethodSelectElementViewModel>
{
	private ViewGroup _emptyLayout;

	private TextView _emptyText;

	private Button _emptyButton;

	private ViewGroup _defaultLayout;

	private TextView _addressText;

	private ImageView _favoritesIcon;

	private ImageView _notificationsIcon;

	private TextView _notificationsBadge;

	private RecyclerView _recyclerView;

	protected override int LayoutId => 2131493178;

	public RecyclerView RecyclerView => _recyclerView;

	public View ExpressCell { get; private set; }

	public View DeliveryCell { get; private set; }

	public View SelfPickupCell { get; private set; }

	public View CarPickupCell { get; private set; }

	public event Action ExpressCellReady;

	public ReceiveMethodSelectView(nint javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	public ReceiveMethodSelectView(Context context)
		: base(context)
	{
	}

	public ReceiveMethodSelectView(Context context, IAttributeSet attrs)
		: base(context, attrs)
	{
	}

	public ReceiveMethodSelectView(Context context, IAttributeSet attrs, int defStyleAttr)
		: base(context, attrs, defStyleAttr)
	{
	}

	public ReceiveMethodSelectView(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes)
		: base(context, attrs, defStyleAttr, defStyleRes)
	{
	}

	public int? GetCellId(ReceivingMethod receivingMethod)
	{
		for (int i = 0; i < base.ViewModel.ReceiveMethods.Count; i++)
		{
			if (base.ViewModel.ReceiveMethods[i].ReceiveMethod == receivingMethod)
			{
				return i + 1;
			}
		}
		return null;
	}

	public void PrepareForHighlight()
	{
		_recyclerView?.ScrollToPosition(0);
	}

	public void ScrollToEnd(Action onScrolled = null)
	{
		int num = base.ViewModel.ReceiveMethods.Count - 1;
		if (num < 0)
		{
			onScrolled?.Invoke();
			return;
		}
		OneTimeOnGlobalLayoutListener listener = new OneTimeOnGlobalLayoutListener(_recyclerView, delegate
		{
			_recyclerView.ScrollBy(_recyclerView.Width, 0);
			if (onScrolled != null)
			{
				onScrolled();
			}
		});
		_recyclerView.ViewTreeObserver.AddOnGlobalLayoutListener(listener);
		_recyclerView.ScrollToPosition(num);
		_recyclerView.RequestLayout();
	}

	protected override void Init(Context context, IAttributeSet attrs = null)
	{
		base.Init(context, attrs);
		_emptyLayout = base.View.RequireViewById<ViewGroup>(2131297077);
		_emptyText = base.View.RequireViewById<TextView>(2131297082);
		_emptyButton = base.View.RequireViewById<Button>(2131298331);
		_defaultLayout = base.View.RequireViewById<ViewGroup>(2131296909);
		_addressText = base.View.RequireViewById<TextView>(2131296384);
		_favoritesIcon = base.View.RequireViewById<ImageView>(2131297148);
		_notificationsIcon = base.View.RequireViewById<ImageView>(2131297715);
		_notificationsBadge = base.View.RequireViewById<TextView>(2131297714);
		_recyclerView = base.View.RequireViewById<RecyclerView>(2131298185);
	}

	public void SetNotificationsCount(int count)
	{
		if (count <= 0)
		{
			_notificationsBadge.Visibility = ViewStates.Gone;
			return;
		}
		_notificationsBadge.Visibility = ViewStates.Visible;
		_notificationsBadge.Text = ((count > 9) ? "9+" : count.ToString());
	}

	public IDisposable ConnectNotificationsClick(Action onClick)
	{
		EventHandler handler = delegate
		{
			onClick();
		};
		_notificationsIcon.Click += handler;
		return Disposable.Create(delegate
		{
			_notificationsIcon.Click -= handler;
		});
	}

	protected override void DoBind()
	{
		ObservableRecyclerAdapter<ReceiveMethodSelectElementViewModel.ReceiveMethodSelectElementItemViewModel, CachingViewHolder> adapter = new ObservableRecyclerAdapter<ReceiveMethodSelectElementViewModel.ReceiveMethodSelectElementItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493313,
			DataSource = base.ViewModel.ReceiveMethods,
			BindViewHolderDelegate = Bind
		};
		_recyclerView.SetAdapter(adapter);
		_recyclerView.SetLayoutManager(new LinearLayoutManager(base.Context, 0, reverseLayout: false));
		if (_recyclerView.ItemDecorationCount == 0)
		{
			_recyclerView.AddItemDecoration(new HorizontalSpaceItemDecoration(8, 20, 20));
		}
		VisibilitySwitch<ReceiveMethodSelectElementViewModel.VisualState> visibilitySwitch = new VisibilitySwitch<ReceiveMethodSelectElementViewModel.VisualState>(ReceiveMethodSelectElementViewModel.VisualState.Default)
		{
			{
				ReceiveMethodSelectElementViewModel.VisualState.Default,
				_defaultLayout
			},
			{
				ReceiveMethodSelectElementViewModel.VisualState.Empty,
				_emptyLayout
			}
		};
		(from _ in base.ViewModel.OnPropertyChanges((ReceiveMethodSelectElementViewModel vm) => vm.SelectedReceiveMethod)
			where base.ViewModel.SelectedReceiveMethod != null
			select _).SafeSubscribe(delegate
		{
			base.View.PostDelayed(delegate
			{
				int num = base.ViewModel.ReceiveMethods.IndexOf(base.ViewModel.SelectedReceiveMethod);
				if (num >= 0)
				{
					_recyclerView.SmoothScrollToPosition(num);
				}
			}, 100L);
		}, base.Disposables);
		base.ViewModel.ShowLastReceiveMethodCommand.SafeSubscribe(delegate
		{
			ScrollToEnd();
		}, base.Disposables);
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[8]
		{
			(delegate
			{
				visibilitySwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				_emptyText.Text = base.ViewModel.EmptyText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EmptyText")),
			(delegate
			{
				_emptyButton.Text = base.ViewModel.EmptyButtonText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EmptyButtonText")),
			(delegate
			{
				_addressText.Text = base.ViewModel.AddressText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AddressText")),
			(delegate
			{
				adapter.DataSource = base.ViewModel.ReceiveMethods;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReceiveMethods")),
			(delegate
			{
				_favoritesIcon.Visibility = base.ViewModel.FavoritesIconVisible.ToInvisibleVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("FavoritesIconVisible")),
			(delegate
			{
				_notificationsIcon.Visibility = base.ViewModel.NotificationsIconVisible.ToInvisibleVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("NotificationsIconVisible")),
			(delegate
			{
				SetAddressMargin(base.ViewModel.NotificationsIconVisible, base.ViewModel.FavoritesIconVisible);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "FavoritesIconVisible", "NotificationsIconVisible" }))
		})).AddTo(base.Disposables);
		_addressText.Click += new DisposableDelegate<EventHandler>(delegate
		{
			base.ViewModel.OpenAddressSelectionDefaultCommand.Trigger();
		}, delegate(EventHandler eh)
		{
			_addressText.Click -= eh;
		}).AddTo(base.Disposables);
		_favoritesIcon.Click += new DisposableDelegate<EventHandler>(delegate
		{
			base.ViewModel.OpenFavoritesCommand.Trigger();
		}, delegate(EventHandler eh)
		{
			_favoritesIcon.Click -= eh;
		}).AddTo(base.Disposables);
		_emptyButton.Click += new DisposableDelegate<EventHandler>(delegate
		{
			base.ViewModel.OpenAddressSelectionDefaultCommand.Trigger();
		}, delegate(EventHandler eh)
		{
			_emptyButton.Click -= eh;
		}).AddTo(base.Disposables);
	}

	private void Bind(CachingViewHolder viewHolder, ReceiveMethodSelectElementViewModel.ReceiveMethodSelectElementItemViewModel viewModel, int index, CompositeDisposable disposables)
	{
		TextView title = viewHolder.RequireCachedView<TextView>(2131298646);
		TextView description = viewHolder.RequireCachedView<TextView>(2131296958);
		ImageView icon = viewHolder.RequireCachedView<ImageView>(2131297308);
		title.Text = viewModel.Title;
		description.Text = viewModel.Description;
		viewHolder.ItemView.Id = index + 1;
		switch (viewModel.ReceiveMethod)
		{
		case ReceivingMethod.ExpressDelivery:
			ExpressCell = viewHolder.ItemView;
			this.ExpressCellReady?.Invoke();
			break;
		case ReceivingMethod.Delivery:
			DeliveryCell = viewHolder.ItemView;
			break;
		case ReceivingMethod.Pickup:
			SelfPickupCell = viewHolder.ItemView;
			break;
		case ReceivingMethod.CarPickup:
			CarPickupCell = viewHolder.ItemView;
			break;
		}
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[2]
		{
			(delegate
			{
				icon.Visibility = viewModel.IconVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IconVisible")),
			(delegate
			{
				SetMethodBackground(viewHolder.ItemView, title, description, icon, viewModel, base.ViewModel.SelectedReceiveMethod);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedReceiveMethod"))
		})).AddTo(disposables);
		viewHolder.ItemView.Click += new DisposableDelegate<EventHandler>(delegate
		{
			base.ViewModel.SelectReceiveMethodCommand.Trigger(viewModel);
		}, delegate(EventHandler eh)
		{
			viewHolder.ItemView.Click -= eh;
		}).AddTo(disposables);
	}

	private void SetMethodBackground(View view, TextView title, TextView description, ImageView icon, ReceiveMethodSelectElementViewModel.ReceiveMethodSelectElementItemViewModel viewModel, ReceiveMethodSelectElementViewModel.ReceiveMethodSelectElementItemViewModel selectedViewModel)
	{
		if (!viewModel.IsAvailable)
		{
			view.SetBackgroundResource(2131230903);
			title.SetTextColor(new Color(ContextCompat.GetColor(base.Context, 2131100602)));
			description.SetTextColor(new Color(ContextCompat.GetColor(base.Context, 2131100602)));
			icon.SetImageResource(2131231159);
			icon.ImageTintList = ContextCompat.GetColorStateList(base.Context, 2131099848);
		}
		else if (viewModel.ReceiveMethod == selectedViewModel?.ReceiveMethod)
		{
			view.SetBackgroundResource(2131230904);
			title.SetTextColor(new Color(ContextCompat.GetColor(base.Context, 2131100548)));
			description.SetTextColor(new Color(ContextCompat.GetColor(base.Context, 2131100548)));
			icon.SetImageResource(2131231161);
			icon.ImageTintList = null;
		}
		else
		{
			view.SetBackgroundResource(2131230903);
			title.SetTextColor(new Color(ContextCompat.GetColor(base.Context, 2131099705)));
			description.SetTextColor(new Color(ContextCompat.GetColor(base.Context, 2131099849)));
			icon.SetImageResource(2131231159);
			icon.ImageTintList = null;
		}
	}

	private void SetAddressMargin(bool notificationsVisible, bool favoritesVisible)
	{
		if (_addressText.LayoutParameters is LayoutParams layoutParams)
		{
			if (notificationsVisible && favoritesVisible)
			{
				layoutParams.SetMargins(Converter.DpToPx(20f), Converter.DpToPx(6f), Converter.DpToPx(82f), Converter.DpToPx(0f));
			}
			else if (notificationsVisible || favoritesVisible)
			{
				layoutParams.SetMargins(Converter.DpToPx(20f), Converter.DpToPx(6f), Converter.DpToPx(52f), Converter.DpToPx(0f));
			}
			else
			{
				layoutParams.SetMargins(Converter.DpToPx(20f), Converter.DpToPx(6f), Converter.DpToPx(20f), Converter.DpToPx(0f));
			}
			_addressText.LayoutParameters = layoutParams;
		}
	}
}
