using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using AndroidX.Core.Content;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Extensions;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Extensions;
using Google.Android.Material.Button;
using Google.Android.Material.Card;
using Google.Android.Material.Shape;
using VisibilitySwitch;

namespace Auchan.Android.Ecom.AddressStoreSelection;

internal class AddressFragment : BaseDialogFragment<AddressViewModel>
{
	private readonly TaskCompletionSource _tcs = new TaskCompletionSource();

	private MaterialButton? _deliveryButton;

	private MaterialButton? _deliveryButtonInactive;

	private MaterialButton? _pickupButton;

	private MaterialButton? _pickupButtonInactive;

	private MaterialButton? _carPickupButton;

	private MaterialButton? _carPickupButtonInactive;

	private readonly Lazy<FragmentFactory> _lazyFragmentFactory;

	private int _editableItemIndex;

	public override int Theme => 2131951957;

	protected override int LayoutId => 2131492981;

	public AddressFragment(Func<AddressViewModel.Parameter, AddressViewModel> newViewModel, Lazy<FragmentFactory> lazyFragmentFactory)
		: base((Func<Fragment, AddressViewModel>)((Fragment thisFragment) => newViewModel(thisFragment.RequireNavParam<AddressViewModel.Parameter>())))
	{
		_lazyFragmentFactory = lazyFragmentFactory;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		TextView textView = view.RequireViewById<TextView>(2131298679);
		View view2 = view.RequireViewById<View>(2131296490);
		RecyclerView addressList = view.RequireViewById<RecyclerView>(2131296391);
		RecyclerView recyclerView = view.RequireViewById<RecyclerView>(2131297896);
		RecyclerView recyclerView2 = view.RequireViewById<RecyclerView>(2131296621);
		Button saveButton = view.RequireViewById<Button>(2131298284);
		Button addButton = view.RequireViewById<Button>(2131296343);
		View view3 = view.RequireViewById<View>(2131296904);
		View view4 = view.RequireViewById<View>(2131297242);
		FrameLayout addressProgressContainer = view.RequireViewById<FrameLayout>(2131296403);
		FrameLayout addressProgress = view.RequireViewById<FrameLayout>(2131296402);
		TextView emptyText = view.RequireViewById<TextView>(2131297062);
		_deliveryButton = view.RequireViewById<MaterialButton>(2131296946);
		_deliveryButtonInactive = view.RequireViewById<MaterialButton>(2131296948);
		_pickupButton = view.RequireViewById<MaterialButton>(2131297897);
		_pickupButtonInactive = view.RequireViewById<MaterialButton>(2131297899);
		_carPickupButton = view.RequireViewById<MaterialButton>(2131296630);
		_carPickupButtonInactive = view.RequireViewById<MaterialButton>(2131296632);
		SetupAddressProgressBar(addressProgress);
		textView.Text = base.ViewModel.Title;
		List<object> dataSource = new List<object> { base.ViewModel };
		ObservableRecyclerAdapter<SelectionItemViewModel<SavedAddress>, CachingViewHolder> adapter = new ObservableRecyclerAdapter<SelectionItemViewModel<SavedAddress>, CachingViewHolder>
		{
			CellLayoutId = 2131493259,
			BindViewHolderDelegate = OnBindItem,
			DataSource = base.ViewModel.AddressesOfSelectedCity,
			ClickCallback = delegate(CachingViewHolder _, SelectionItemViewModel<SavedAddress> item, int _)
			{
				base.ViewModel.SelectAddress(item.Item).SafeFireAndForget((Action<Exception>)null, false);
			}
		};
		addressList.SetAdapter(adapter);
		ObservableRecyclerAdapter<SelectionItemViewModel<SavedStore>, CachingViewHolder> adapter2 = new ObservableRecyclerAdapter<SelectionItemViewModel<SavedStore>, CachingViewHolder>
		{
			CellLayoutId = 2131493278,
			BindViewHolderDelegate = OnBindPickupStore,
			DataSource = base.ViewModel.PickupStoresOfSelectedCity
		};
		recyclerView.SetAdapter(adapter2);
		ObservableRecyclerAdapter<object, CachingViewHolder> observableRecyclerAdapter = new ObservableRecyclerAdapter<object, CachingViewHolder>
		{
			CellLayoutId = 2131493280,
			BindViewHolderDelegate = OnBindCarPickupHeader,
			DataSource = dataSource
		};
		ObservableRecyclerAdapter<SelectionItemViewModel<SavedStore>, CachingViewHolder> observableRecyclerAdapter2 = new ObservableRecyclerAdapter<SelectionItemViewModel<SavedStore>, CachingViewHolder>
		{
			CellLayoutId = 2131493278,
			BindViewHolderDelegate = OnBindCarPickupStore,
			DataSource = base.ViewModel.CarPickupStoresOfSelectedCity
		};
		recyclerView2.SetAdapter(new ConcatAdapter(observableRecyclerAdapter, observableRecyclerAdapter2));
		VisibilitySwitch<VisualState> @switch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				view3
			},
			{
				VisualState.InProgress,
				view4
			}
		};
		VisibilitySwitch<AddressViewModel.DeliveryType> layoutSwitch = new VisibilitySwitch<AddressViewModel.DeliveryType>(base.ViewModel.LayoutState)
		{
			{
				AddressViewModel.DeliveryType.Delivery,
				addressList
			},
			{
				AddressViewModel.DeliveryType.Pickup,
				recyclerView
			},
			{
				AddressViewModel.DeliveryType.CarPickup,
				recyclerView2
			},
			{
				AddressViewModel.DeliveryType.Empty,
				emptyText
			}
		};
		VisibilitySwitch<AddressViewModel.DeliveryType> buttonSwitch = new VisibilitySwitch<AddressViewModel.DeliveryType>(base.ViewModel.SelectedButtonState)
		{
			{
				AddressViewModel.DeliveryType.Delivery,
				_deliveryButton
			},
			{
				AddressViewModel.DeliveryType.Pickup,
				_pickupButton
			},
			{
				AddressViewModel.DeliveryType.CarPickup,
				_carPickupButton
			}
		};
		MaterialButton? deliveryButton = _deliveryButton;
		string text = (_deliveryButtonInactive.Text = base.ViewModel.DeliveryText);
		deliveryButton.Text = text;
		MaterialButton? pickupButton = _pickupButton;
		text = (_pickupButtonInactive.Text = base.ViewModel.PickupText);
		pickupButton.Text = text;
		MaterialButton? carPickupButton = _carPickupButton;
		text = (_carPickupButtonInactive.Text = base.ViewModel.CarPickupText);
		carPickupButton.Text = text;
		((INotifyCollectionChanged)base.ViewModel.AddressesOfSelectedCity).OnCollectionChanged((Action)delegate
		{
			if (base.ViewModel.AddressesOfSelectedCity.Count >= _editableItemIndex + 1)
			{
				addressList.ScrollToPosition(_editableItemIndex);
			}
		});
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[10]
		{
			(delegate
			{
				@switch.State = base.ViewModel.State;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				layoutSwitch.State = base.ViewModel.LayoutState;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("LayoutState")),
			(delegate
			{
				buttonSwitch.State = base.ViewModel.SelectedButtonState;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedButtonState")),
			(delegate
			{
				emptyText.Text = base.ViewModel.EmptyText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("EmptyText")),
			(delegate
			{
				saveButton.Text = base.ViewModel.SaveButtonText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SaveButtonText")),
			(delegate
			{
				saveButton.Enabled = base.ViewModel.IsSaveButtonEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSaveButtonEnabled")),
			(delegate
			{
				saveButton.Visibility = base.ViewModel.SaveButtonVisibility.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SaveButtonVisibility")),
			(delegate
			{
				addButton.Text = base.ViewModel.AddButtonText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AddButtonText")),
			(delegate
			{
				ChangeButtonStyle(addButton, base.ViewModel.AddButtonActive);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AddButtonActive")),
			(delegate
			{
				addressProgressContainer.Visibility = base.ViewModel.AddressUpdating.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AddressUpdating"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(saveButton.OnClick(base.ViewModel.SaveCommand.Trigger), addButton.OnClick(base.ViewModel.OpenMap), ((View)_deliveryButtonInactive).OnClick((Action)delegate
		{
			base.ViewModel.OnDeliveryStateChanged(AddressViewModel.DeliveryType.Delivery);
		}), ((View)_pickupButtonInactive).OnClick((Action)delegate
		{
			base.ViewModel.OnDeliveryStateChanged(AddressViewModel.DeliveryType.Pickup);
		}), ((View)_carPickupButtonInactive).OnClick((Action)delegate
		{
			base.ViewModel.OnDeliveryStateChanged(AddressViewModel.DeliveryType.CarPickup);
		}), view2.OnClick(base.ViewModel.CloseCommand.Trigger)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			Dismiss();
		}, ViewLifecycleOwner);
		base.ViewModel.OpenMapCommand.SafeSubscribe(delegate(AddressMapViewModel.Parameter p)
		{
			OpenMap(p).SafeFireAndForget((Action<Exception>)null, false);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenAskToRemoveAddressPopupCommand.SafeSubscribe(ShowFragment<AskToRemoveAddressPopupFragment>, ViewLifecycleOwner);
		base.ViewModel.OpenPopupChangeCartItemsCommand.SafeSubscribe(ShowFragment<ChangeCartItemsPopupFragment>, ViewLifecycleOwner);
		base.ViewModel.ShowExpressDeliveryPopupCommand.SafeSubscribe(delegate(int pos)
		{
			ShowExpressDeliveryPopup(addressList, pos);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenEditableItemCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<AddressDetailsFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
	}

	private async Task OpenMap(AddressMapViewModel.Parameter p)
	{
		AddressMapFragment addressMapFragment = _lazyFragmentFactory.Value.Instantiate<AddressMapFragment>();
		addressMapFragment.Arguments = p.ToNavBundle();
		addressMapFragment.Show(base.ParentFragmentManager, null);
		if (await addressMapFragment.Execute())
		{
			Dismiss();
			base.ViewModel.ShowSuccessInfo();
		}
	}

	private void ShowFragment<T>(BrokerToken parameter) where T : DialogFragment
	{
		T val = _lazyFragmentFactory.Value.Instantiate<T>();
		val.Arguments = parameter.ToNavBundle();
		val.Show(base.ChildFragmentManager, null);
	}

	private static void SetupAddressProgressBar(FrameLayout addressProgress)
	{
		ShapeAppearanceModel shapeAppearanceModel = new ShapeAppearanceModel.Builder().SetAllCornerSizes(Converter.DpToPx(12f)).Build();
		MaterialShapeDrawable materialShapeDrawable = MaterialShapeDrawable.CreateWithElevationOverlay(addressProgress.Context, Converter.DpToPx(2f), ColorStateList.ValueOf(new Color(ContextCompat.GetColor(addressProgress.Context, 2131099697))));
		materialShapeDrawable.ShadowCompatibilityMode = 2;
		materialShapeDrawable.SetShadowColor(2131099712);
		materialShapeDrawable.ShapeAppearanceModel = shapeAppearanceModel;
		addressProgress.Background = materialShapeDrawable;
	}

	private void ChangeButtonStyle(Button addButton, bool addButtonActive)
	{
		addButton.BackgroundTintList = ColorStateList.ValueOf(new Color(ContextCompat.GetColor(Context, addButtonActive ? 2131099856 : 2131099847)));
		addButton.SetTextColor(new Color(ContextCompat.GetColor(Context, addButtonActive ? 2131100630 : 2131099872)));
	}

	private void OnBindItem(CachingViewHolder holder, SelectionItemViewModel<SavedAddress> model, int position, CompositeDisposable disposable)
	{
		View view = holder.RequireCachedView<View>(2131296555);
		CompoundButton radioButton = holder.RequireCachedView<CompoundButton>(2131298135);
		View view2 = holder.RequireCachedView<View>(2131297035);
		TextView textView = holder.RequireCachedView<TextView>(2131297632);
		TextView address = holder.RequireCachedView<TextView>(2131296384);
		TextView addressValidationError = holder.RequireCachedView<TextView>(2131296397);
		LinearLayout deliveryInfoLayout = holder.RequireCachedView<LinearLayout>(2131296944);
		View invisibleBalanceView = holder.RequireCachedView<View>(2131297379);
		MaterialCardView typeStandard = holder.RequireCachedView<MaterialCardView>(2131296945);
		MaterialCardView typeExpress = holder.RequireCachedView<MaterialCardView>(2131296943);
		TextView standardTitle = typeStandard.RequireViewById<TextView>(2131298646);
		TextView standardSubtitle = typeStandard.RequireViewById<TextView>(2131298559);
		TextView expressTitle = typeExpress.RequireViewById<TextView>(2131298646);
		TextView expressSubtitle = typeExpress.RequireViewById<TextView>(2131298559);
		TextView deliveryShortInfoTextView = holder.RequireCachedView<TextView>(2131296939);
		TextView deliveryMinCostTextView = holder.RequireCachedView<TextView>(2131296932);
		TextView freeDeliveryFromTextView = holder.RequireCachedView<TextView>(2131297220);
		View freeDeliveryFromView = holder.RequireCachedView<View>(2131297221);
		ImageView deliveryShortInfoImageView = holder.RequireCachedView<ImageView>(2131296938);
		ImageView freeDeliveryFromImageView = holder.RequireCachedView<ImageView>(2131297219);
		if (model.Item.HasNameAndAddress)
		{
			textView.Text = model.Item.Name;
			address.Text = model.Item.AddressLine;
		}
		else
		{
			textView.Text = model.Item.AddressLine;
		}
		standardTitle.Text = base.ViewModel.DeliveryTypeStandardTitle;
		addressValidationError.Text = base.ViewModel.AddressValidationErrorText;
		expressTitle.Text = base.ViewModel.DeliveryTypeExpressTitle;
		view.Visibility = (position < base.ViewModel.AddressesOfSelectedCity.Count - 1).ToInvisibleVisibility();
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[13]
		{
			(delegate
			{
				typeStandard.Visibility = base.ViewModel.StandardDeliveryVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StandardDeliveryVisible")),
			(delegate
			{
				typeExpress.Visibility = base.ViewModel.ExpressDeliveryVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ExpressDeliveryVisible")),
			(delegate
			{
				invisibleBalanceView.Visibility = (base.ViewModel.StandardDeliveryVisible ^ base.ViewModel.ExpressDeliveryVisible).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "StandardDeliveryVisible", "ExpressDeliveryVisible" })),
			(delegate
			{
				standardSubtitle.Text = base.ViewModel.DeliveryTypeStandardSubtitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryTypeStandardSubtitle")),
			(delegate
			{
				expressSubtitle.Text = base.ViewModel.DeliveryTypeExpressSubtitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryTypeExpressSubtitle")),
			(delegate
			{
				deliveryShortInfoTextView.Text = base.ViewModel.DeliveryShortInfo;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryShortInfo")),
			(delegate
			{
				deliveryMinCostTextView.Text = base.ViewModel.DeliveryMinCost;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryMinCost")),
			(delegate
			{
				freeDeliveryFromTextView.Text = base.ViewModel.FreeDeliveryMinCostText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("FreeDeliveryMinCostText")),
			(delegate
			{
				freeDeliveryFromView.Visibility = base.ViewModel.IsFreeDeliveryMinCostVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsFreeDeliveryMinCostVisible")),
			(delegate
			{
				deliveryShortInfoImageView.SetImageResource(base.ViewModel.IsExpressDeliverySelected ? 2131231265 : 2131231277);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsExpressDeliverySelected")),
			(delegate
			{
				freeDeliveryFromImageView.SetImageResource(base.ViewModel.IsExpressDeliverySelected ? 2131231145 : 2131231373);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsExpressDeliverySelected")),
			(delegate
			{
				SetDeliverySubtypeButtonFrame(typeExpress, expressTitle, expressSubtitle, base.ViewModel.IsExpressDeliverySelected, base.ViewModel.ExpressDeliveryAvailable);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "IsExpressDeliverySelected", "ExpressDeliveryAvailable" })),
			(delegate
			{
				SetDeliverySubtypeButtonFrame(typeStandard, standardTitle, standardSubtitle, !base.ViewModel.IsExpressDeliverySelected, isAvailable: true);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsExpressDeliverySelected"))
		})).AddTo(disposable);
		model.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[4]
		{
			(delegate
			{
				radioButton.Checked = model.Selected;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")),
			(delegate
			{
				TextView textView2 = addressValidationError;
				int value;
				if (model != null && model.Selected)
				{
					SavedAddress item = model.Item;
					if ((object)item != null)
					{
						value = ((!item.DeliveryAvailable) ? 1 : 0);
						goto IL_0036;
					}
				}
				value = 0;
				goto IL_0036;
				IL_0036:
				textView2.Visibility = ((byte)value != 0).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")),
			(delegate
			{
				LinearLayout linearLayout = deliveryInfoLayout;
				int value;
				if (model != null && model.Selected)
				{
					SavedAddress item = model.Item;
					if ((object)item != null)
					{
						value = (item.DeliveryAvailable ? 1 : 0);
						goto IL_0033;
					}
				}
				value = 0;
				goto IL_0033;
				IL_0033:
				linearLayout.Visibility = ((byte)value != 0).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")),
			(delegate
			{
				address.Visibility = model.Item.HasNameAndAddress.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasNameAndAddress"))
		})).AddTo(disposable);
		model.BindEvents(view2.OnClick((Action)delegate
		{
			_editableItemIndex = position;
			base.ViewModel.EditItemCommand.Trigger(model.Item);
		}), ((View)typeStandard).OnClick((Action)delegate
		{
			base.ViewModel.IsExpressDeliverySelected = false;
		}), typeExpress.OnClick(base.ViewModel.SelectExpressDelivery)).AddTo(disposable);
	}

	private void OnBindCarPickupHeader(CachingViewHolder holder, object model, int position, CompositeDisposable disposable)
	{
		TextView textView = holder.RequireCachedView<TextView>(2131297344);
		TextView textView2 = holder.RequireCachedView<TextView>(2131297345);
		TextView textView3 = holder.RequireCachedView<TextView>(2131296426);
		textView2.Visibility = ViewStates.Gone;
		textView3.Visibility = ViewStates.Gone;
		textView.Text = base.ViewModel.CarPickupInfoDescription;
		textView.SetPaddingDp(0, 8, 0, 0);
	}

	private void OnBindPickupStore(CachingViewHolder holder, SelectionItemViewModel<SavedStore> model, int position, CompositeDisposable disposable)
	{
		OnBindStore(holder, model, position, base.ViewModel.PickupStoresOfSelectedCity, () => base.ViewModel.SelectedPickupStore = model.Item, disposable);
	}

	private void OnBindCarPickupStore(CachingViewHolder holder, SelectionItemViewModel<SavedStore> model, int position, CompositeDisposable disposable)
	{
		OnBindStore(holder, model, position, base.ViewModel.CarPickupStoresOfSelectedCity, () => base.ViewModel.SelectedCarPickupStore = model.Item, disposable);
	}

	private void OnBindStore(CachingViewHolder holder, SelectionItemViewModel<SavedStore> model, int position, IReadOnlyCollection<SelectionItemViewModel<SavedStore>> stores, Func<SavedStore> setStore, CompositeDisposable disposable)
	{
		ListItemPickupStoreControls controls = new ListItemPickupStoreControls(holder);
		controls.TopSeparator.Visibility = (position > 0).ToInvisibleVisibility();
		controls.BottomSeparator.Visibility = (position < stores.Count - 1).ToInvisibleVisibility();
		model.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[3]
		{
			(delegate
			{
				controls.Name.Text = model.Item.Name;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Item")),
			(delegate
			{
				controls.Address.Text = model.Item.Address;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Item")),
			(delegate
			{
				controls.RadioButton.Checked = model.Selected;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected"))
		})).AddTo(disposable);
		base.ViewModel.BindEvents(holder.ItemView.OnClick((Action)delegate
		{
			setStore();
		}), controls.Delete.OnClick((Action)delegate
		{
			base.ViewModel.RemoveItemCommand.Trigger(model);
		})).AddTo(disposable);
	}

	private void SetDeliverySubtypeButtonFrame(MaterialCardView view, TextView title, TextView subtitle, bool isSelected, bool isAvailable)
	{
		if (Context == null)
		{
			throw new InvalidOperationException("dead code");
		}
		isSelected = isSelected && isAvailable;
		view.Enabled = isAvailable;
		view.SetStrokeColor(ContextCompat.GetColorStateList(Context, isSelected ? 2131100611 : 2131099848));
		title.SetTextColor(ContextCompat.GetColorStateList(Context, isSelected ? 2131100550 : (isAvailable ? 2131099872 : 2131099849)));
		subtitle.SetTextColor(ContextCompat.GetColorStateList(Context, isSelected ? 2131100550 : 2131099849));
	}

	private void ShowExpressDeliveryPopup(RecyclerView addressList, int position)
	{
		addressList.Post(delegate
		{
			View childAt = addressList.GetChildAt(position);
			if (childAt != null)
			{
				ExpressDeliveryAvailablePopup.Show(base.ViewModel, base.ViewModel.ExpressDeliveryIsAvailableText, childAt, new Point(0, 0));
			}
		});
	}

	public Task Execute()
	{
		return _tcs.Task;
	}

	public override void OnDestroy()
	{
		base.OnDestroy();
		_tcs.TrySetResult();
	}
}
