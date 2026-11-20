using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Android.Animation;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.Graphics;
using AndroidX.Core.View;
using AndroidX.Fragment.App;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Common;
using Auchan.Android.Common.UiUtils;
using Auchan.Android.Controls;
using Auchan.Android.Extensions;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Extensions;
using EBind;
using Google.Android.Material.Button;
using Google.Android.Material.Card;
using Java.Interop;
using Java.Lang;
using VisibilitySwitch;

namespace Auchan.Android.Ecom.AddressStoreSelection;

internal sealed class AddressMapFragment : BaseDialogFragment<AddressMapViewModel>
{
	private sealed class Controls
	{
		public View NavigationButton { get; } = view.RequireViewById<View>(2131296490);

		public WebView WebView { get; } = view.RequireViewById<WebView>(2131297514);

		public View WebViewContainer { get; } = view.RequireViewById<View>(2131297515);

		public View WebViewTouchInterceptor { get; } = view.RequireViewById<View>(2131298829);

		public View SaveButtonBackground { get; } = view.RequireViewById<View>(2131298285);

		public MaterialButton SaveButton { get; } = view.RequireViewById<MaterialButton>(2131298284);

		public View SelectRegionButton { get; } = view.RequireViewById<View>(2131298336);

		public View LocateButton { get; } = view.RequireViewById<View>(2131297459);

		public TextView SelectRegionText { get; } = view.RequireViewById<TextView>(2131296876);

		public View WebViewProgress { get; } = view.RequireViewById<View>(2131298828);

		public View NoMapLayout { get; } = view.RequireViewById<View>(2131297681);

		public TextView NoMapText { get; } = view.RequireViewById<TextView>(2131297682);

		public View AddressSelectorPopup { get; } = view.RequireViewById<View>(2131296404);

		public View SelectorPopupTouchInterceptor { get; } = view.RequireViewById<View>(2131298342);

		public View DefaultLayout { get; } = view.RequireViewById<View>(2131296904);

		public View ProgressLayout { get; } = view.RequireViewById<View>(2131297242);

		public ErrorLayoutControls Error { get; } = new ErrorLayoutControls(view.RequireViewById<View>(2131297108));

		public View ErrorBackButton { get; } = view.RequireViewById<View>(2131297109);

		public ScrollView DeliveryLayout { get; } = view.RequireViewById<ScrollView>(2131296951);

		public View ExtraBottomSpace { get; } = view.RequireViewById<View>(2131297135);

		public MaterialCardView AddressBorderContainer { get; } = view.RequireViewById<MaterialCardView>(2131296385);

		public TextView AddressHint { get; } = view.RequireViewById<TextView>(2131296388);

		public TextView AddressLargeHint { get; } = view.RequireViewById<TextView>(2131296389);

		public TextView AddressText { get; } = view.RequireViewById<TextView>(2131296393);

		public View AddressWarningIcon { get; } = view.RequireViewById<View>(2131296396);

		public TextView AddressWarningText { get; } = view.RequireViewById<TextView>(2131296397);

		public View DeliveryTypeLayout { get; } = view.RequireViewById<View>(2131296944);

		public DeliveryTypeButtonControls DeliveryTypeStandardButton { get; } = new DeliveryTypeButtonControls(view.RequireViewById<MaterialCardView>(2131296945));

		public DeliveryTypeButtonControls DeliveryTypeExpressButton { get; } = new DeliveryTypeButtonControls(view.RequireViewById<MaterialCardView>(2131296943));

		public View InvisibleBalanceView { get; } = view.RequireViewById<View>(2131297379);

		public ImageView DeliveryShortInfoImageView { get; } = view.RequireViewById<ImageView>(2131296938);

		public TextView DeliveryShortInfoTextView { get; } = view.RequireViewById<TextView>(2131296939);

		public TextView DeliveryMinCostTextView { get; } = view.RequireViewById<TextView>(2131296932);

		public ImageView FreeDeliveryFromImageView { get; } = view.RequireViewById<ImageView>(2131297219);

		public TextView FreeDeliveryFromTextView { get; } = view.RequireViewById<TextView>(2131297220);

		public View FreeDeliveryFromView { get; } = view.RequireViewById<View>(2131297221);

		public RecyclerView PickupStoreList { get; } = view.RequireViewById<RecyclerView>(2131297896);

		public RecyclerView CarPickupStoreList { get; } = view.RequireViewById<RecyclerView>(2131296621);

		public FrameLayout UnavailableInfoContainer { get; } = view.RequireViewById<FrameLayout>(2131298775);

		public SnackView UnavailableInfo { get; } = view.RequireViewById<SnackView>(2131298774);

		public Controls(View view)
		{
		}
	}

	private sealed class ListPickupHeaderControls
	{
		public View InfoHeaderLayout { get; } = holder.RequireCachedView<View>(2131297346);

		public TextView InfoHeader { get; } = holder.RequireCachedView<TextView>(2131297345);

		public TextView InfoDescription { get; } = holder.RequireCachedView<TextView>(2131297344);

		public TextView AllStoresTitle { get; } = holder.RequireCachedView<TextView>(2131296426);

		public ListPickupHeaderControls(CachingViewHolder holder)
		{
		}
	}

	private sealed class DeliveryTypeButtonControls(MaterialCardView view)
	{
		public MaterialCardView View => view;

		public TextView Title { get; } = view.RequireViewById<TextView>(2131298646);

		public TextView Subtitle { get; } = view.RequireViewById<TextView>(2131298559);
	}

	private sealed class InsetListener : Java.Lang.Object, IOnApplyWindowInsetsListener, IJavaObject, IDisposable, IJavaPeerable
	{
		private readonly AddressMapFragment _addressMapFragment;

		public InsetListener(AddressMapFragment addressMapFragment)
		{
			_addressMapFragment = addressMapFragment;
		}

		public WindowInsetsCompat OnApplyWindowInsets(View? v, WindowInsetsCompat? insets)
		{
			AndroidX.Core.Graphics.Insets insets2 = insets.GetInsets(WindowInsetsCompat.Type.NavigationBars());
			v.SetPadding(v.PaddingLeft, v.PaddingTop, v.PaddingRight, insets2.Bottom);
			return insets;
		}

		int IJavaPeerable.get_JniIdentityHashCode()
		{
			return base.JniIdentityHashCode;
		}

		JniObjectReference IJavaPeerable.get_PeerReference()
		{
			return base.PeerReference;
		}

		void IJavaPeerable.UnregisterFromRuntime()
		{
			UnregisterFromRuntime();
		}
	}

	private readonly TaskCompletionSource<bool> _tcs = new TaskCompletionSource<bool>();

	private readonly Lazy<FragmentFactory> _lazyFragmentFactory;

	private ValueAnimator? _popupAnimator;

	private bool _extended;

	private VelocityTracker? _velocityTracker;

	private ValueAnimator? _webViewAnimator;

	protected override int LayoutId => 2131492982;

	public override int Theme => 2131951957;

	public AddressMapFragment(Func<AddressMapViewModel.Parameter, AddressMapViewModel> vmFactory, Lazy<FragmentFactory> lazyFragmentFactory)
		: base((Func<Fragment, AddressMapViewModel>)((Fragment thisFragment) => vmFactory(thisFragment.RequireNavParam<AddressMapViewModel.Parameter>())))
	{
		_lazyFragmentFactory = lazyFragmentFactory;
	}

	public override void OnViewCreated(View view, Bundle? savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		Controls controls = new Controls(view);
		controls.WebView.SetWebViewClient(new CustomWebViewClient
		{
			Finished = delegate
			{
				base.ViewModel.OnMapPageLoaded();
			},
			HttpError = delegate(WebView wv, IWebResourceRequest rq, WebResourceResponse err)
			{
				base.ViewModel.OnMapPageError(rq.Url?.ToString() ?? "unknown", err.StatusCode);
			},
			WebViewError = delegate(WebView wv, IWebResourceRequest rq, WebResourceError err)
			{
				base.ViewModel.OnMapPageError(rq.Url?.ToString() ?? "unknown", (int)err.ErrorCode);
			},
			HttpAuthCredentials = ("gs", "gs"),
			Loading = (WebView wv, string url) => base.ViewModel.ShouldOverrideUrlLoading(url)
		});
		controls.WebView.AddJavascriptInterface(new JSPostMessageInterface(base.ViewModel.OnReceiveMessage), "JSPostMessageInterface");
		controls.WebView.Settings.JavaScriptEnabled = true;
		controls.WebView.Settings.DomStorageEnabled = true;
		controls.WebView.Settings.UseWideViewPort = false;
		controls.WebView.Settings.MixedContentMode = MixedContentHandling.AlwaysAllow;
		controls.WebView.Settings.DefaultTextEncodingName = "utf-8";
		controls.WebView.Settings.UserAgentString = base.ViewModel.UserAgent;
		OnGlobalLayoutListener oneTimeOnGlobalLayoutListener = new OnGlobalLayoutListener(controls.AddressSelectorPopup, delegate
		{
			int popupHeight = GetPopupHeight(controls);
			if (!_extended && popupHeight != 0)
			{
				ConstraintLayout.LayoutParams layoutParams = (ConstraintLayout.LayoutParams)controls.WebViewContainer.LayoutParameters;
				ConstraintLayout.LayoutParams layoutParams2 = (ConstraintLayout.LayoutParams)controls.AddressSelectorPopup.LayoutParameters;
				if (layoutParams2 == null || layoutParams2.MatchConstraintPercentHeight != 0.72605f)
				{
					layoutParams2.MatchConstraintPercentHeight = (float)popupHeight / (float)View.Height;
					controls.AddressSelectorPopup.LayoutParameters = layoutParams2;
					layoutParams.MatchConstraintPercentHeight = 1f - (float)popupHeight / (float)View.Height;
					controls.WebViewContainer.LayoutParameters = layoutParams;
				}
			}
		});
		controls.AddressSelectorPopup.ViewTreeObserver?.AddOnGlobalLayoutListener(oneTimeOnGlobalLayoutListener);
		Disposable.Create(delegate
		{
			controls.AddressSelectorPopup.ViewTreeObserver?.RemoveOnGlobalLayoutListener(oneTimeOnGlobalLayoutListener);
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		VisibilitySwitch<VisualState> @switch = new VisibilitySwitch<VisualState>(VisualState.Empty)
		{
			{
				VisualState.Default,
				controls.DefaultLayout
			},
			{
				VisualState.InProgress,
				controls.ProgressLayout
			},
			{
				VisualState.Error,
				controls.Error.Layout
			}
		};
		VisibilitySwitch<VisualState> webViewSwitch = new VisibilitySwitch<VisualState>(base.ViewModel.WebViewState)
		{
			{
				VisualState.Default,
				controls.WebView
			},
			{
				VisualState.InProgress,
				controls.WebViewProgress
			},
			{
				VisualState.Error,
				controls.NoMapLayout
			}
		};
		controls.AddressHint.Text = base.ViewModel.StreetHouseText;
		controls.AddressLargeHint.Text = base.ViewModel.StreetHouseText;
		controls.DeliveryTypeExpressButton.Title.Text = base.ViewModel.DeliveryTypeExpressTitle;
		controls.DeliveryTypeStandardButton.Title.Text = base.ViewModel.DeliveryTypeStandardTitle;
		List<object> dataSource = new List<object> { base.ViewModel };
		ObservableRecyclerAdapter<object, CachingViewHolder> observableRecyclerAdapter = new ObservableRecyclerAdapter<object, CachingViewHolder>
		{
			CellLayoutId = 2131493280,
			BindViewHolderDelegate = OnBindPickupHeader,
			DataSource = dataSource
		};
		ObservableRecyclerAdapter<SelectionItemViewModel<Store>, CachingViewHolder> observableRecyclerAdapter2 = new ObservableRecyclerAdapter<SelectionItemViewModel<Store>, CachingViewHolder>
		{
			CellLayoutId = 2131493278,
			BindViewHolderDelegate = OnBindPickupStore,
			DataSource = base.ViewModel.PickupStoresOfSelectedCity
		};
		controls.PickupStoreList.SetAdapter(new ConcatAdapter(observableRecyclerAdapter, observableRecyclerAdapter2));
		ObservableRecyclerAdapter<object, CachingViewHolder> observableRecyclerAdapter3 = new ObservableRecyclerAdapter<object, CachingViewHolder>
		{
			CellLayoutId = 2131493280,
			BindViewHolderDelegate = OnBindCarPickupHeader,
			DataSource = dataSource
		};
		ObservableRecyclerAdapter<SelectionItemViewModel<Store>, CachingViewHolder> observableRecyclerAdapter4 = new ObservableRecyclerAdapter<SelectionItemViewModel<Store>, CachingViewHolder>
		{
			CellLayoutId = 2131493278,
			BindViewHolderDelegate = OnBindCarPickupStore,
			DataSource = base.ViewModel.CarPickupStoresOfSelectedCity
		};
		controls.CarPickupStoreList.SetAdapter(new ConcatAdapter(observableRecyclerAdapter3, observableRecyclerAdapter4));
		controls.NoMapText.Text = base.ViewModel.NoMapAvailableText;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[28]
		{
			(delegate
			{
				@switch.State = base.ViewModel.State;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				webViewSwitch.State = base.ViewModel.WebViewState;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("WebViewState")),
			(delegate
			{
				controls.UnavailableInfo.Text = base.ViewModel.UnavailableInfoText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("UnavailableInfoText")),
			(delegate
			{
				controls.SelectRegionText.Text = base.ViewModel.CurrentRegionName;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CurrentRegionName")),
			(delegate
			{
				controls.SaveButton.Text = base.ViewModel.SaveButtonText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SaveButtonText")),
			(delegate
			{
				controls.SaveButton.Enabled = base.ViewModel.IsSaveButtonEnabled;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSaveButtonEnabled")),
			(delegate
			{
				OnSelectedPickupStoreChanged(controls, base.ViewModel.SelectedPickupStore);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedPickupStore")),
			(delegate
			{
				OnSelectedCarPickupStoreChanged(controls, base.ViewModel.SelectedCarPickupStore);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedCarPickupStore")),
			(delegate
			{
				OnSelectAddressTextChanged(controls, base.ViewModel.SelectAddressText);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectAddressText")),
			(delegate
			{
				controls.AddressWarningText.Text = base.ViewModel.AddressValidationErrorText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AddressValidationErrorText")),
			(delegate
			{
				OnAddressWarningVisibilityChanged(controls, base.ViewModel.IsAddressValidationError);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAddressValidationError")),
			(delegate
			{
				controls.DeliveryTypeLayout.Visibility = base.ViewModel.DeliveryTypesBlockVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryTypesBlockVisible")),
			(delegate
			{
				controls.DeliveryTypeStandardButton.View.Visibility = base.ViewModel.StandardDeliveryVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StandardDeliveryVisible")),
			(delegate
			{
				controls.DeliveryTypeExpressButton.View.Visibility = base.ViewModel.ExpressDeliveryVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ExpressDeliveryVisible")),
			(delegate
			{
				controls.InvisibleBalanceView.Visibility = (base.ViewModel.StandardDeliveryVisible ^ base.ViewModel.ExpressDeliveryVisible).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "StandardDeliveryVisible", "ExpressDeliveryVisible" })),
			(delegate
			{
				controls.DeliveryTypeExpressButton.Subtitle.Text = base.ViewModel.DeliveryTypeExpressSubtitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryTypeExpressSubtitle")),
			(delegate
			{
				controls.DeliveryTypeStandardButton.Subtitle.Text = base.ViewModel.DeliveryTypeStandardSubtitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryTypeStandardSubtitle")),
			(delegate
			{
				controls.DeliveryShortInfoTextView.Text = base.ViewModel.DeliveryShortInfo;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryShortInfo")),
			(delegate
			{
				controls.DeliveryMinCostTextView.Text = base.ViewModel.DeliveryMinCost;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryMinCost")),
			(delegate
			{
				controls.FreeDeliveryFromTextView.Text = base.ViewModel.FreeDeliveryMinCostText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("FreeDeliveryMinCostText")),
			(delegate
			{
				controls.FreeDeliveryFromView.Visibility = base.ViewModel.IsFreeDeliveryMinCostVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsFreeDeliveryMinCostVisible")),
			(delegate
			{
				controls.DeliveryShortInfoImageView.SetImageResource(base.ViewModel.IsExpressDeliverySelected ? 2131231265 : 2131231277);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsExpressDeliverySelected")),
			(delegate
			{
				controls.FreeDeliveryFromImageView.SetImageResource(base.ViewModel.IsExpressDeliverySelected ? 2131231145 : 2131231373);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsExpressDeliverySelected")),
			(delegate
			{
				SetDeliverySubtypeButtonFrame(controls.DeliveryTypeExpressButton, base.ViewModel.IsExpressDeliverySelected, base.ViewModel.ExpressDeliveryAvailable);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "IsExpressDeliverySelected", "ExpressDeliveryAvailable" })),
			(delegate
			{
				SetDeliverySubtypeButtonFrame(controls.DeliveryTypeStandardButton, !base.ViewModel.IsExpressDeliverySelected, isAvailable: true);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsExpressDeliverySelected")),
			(delegate
			{
				OnErrorTitleChanged(controls, base.ViewModel.ErrorTitle);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				OnErrorMessageChaned(controls, base.ViewModel.ErrorMessage);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				SetUnavailableState(controls);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("UnavailableInfoVisible"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(controls.NavigationButton.OnClick((Action)delegate
		{
			Dismiss();
			_tcs.TrySetResult(result: false);
		}), controls.ErrorBackButton.OnClick((Action)delegate
		{
			Dismiss();
			_tcs.TrySetResult(result: false);
		}), controls.SelectRegionButton.OnClick((Action)delegate
		{
			base.ViewModel.OpenRegionSelector();
		}), controls.LocateButton.OnClick((Action)delegate
		{
			base.ViewModel.Locate().SafeFireAndForget((Action<System.Exception>)null, false);
		}), controls.SaveButtonBackground.OnClick((Action)delegate
		{
			DoNothing();
		}), ((View)controls.SaveButton).OnClick((Action)delegate
		{
			base.ViewModel.SaveCommand.Trigger();
		}), controls.AddressBorderContainer.OnClick(base.ViewModel.OpenAddressSuggestor), ((View)controls.DeliveryTypeStandardButton.View).OnClick((Action)delegate
		{
			base.ViewModel.IsExpressDeliverySelected = false;
		}), controls.DeliveryTypeExpressButton.View.OnClick(base.ViewModel.SelectExpressDelivery), controls.Error.Action.OnClick(base.ViewModel.RetryCommand.Trigger), ((View)controls.Error.ShowQrButton).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		controls.WebViewTouchInterceptor.Touch += new DisposableDelegate<EventHandler<View.TouchEventArgs>>(delegate(object? o, View.TouchEventArgs e)
		{
			e.Handled = false;
			_extended = false;
			ShrinkPopup(controls);
		}, delegate(EventHandler<View.TouchEventArgs> eh)
		{
			controls.WebViewTouchInterceptor.Touch -= eh;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		controls.SelectorPopupTouchInterceptor.SetOnTouchListener(new ViewOnTouchListener((View v, MotionEvent e) => SwipePopupOrTapSelectorButton(e, controls)));
		RequireActivity().OnBackPressedDispatcher.AddCallback(ViewLifecycleOwner, Dismiss);
		base.ViewModel.EvaluateJavascript.SafeSubscribe(delegate(string msg)
		{
			EvaluateJavascript(controls.WebView, msg);
		}, ViewLifecycleOwner);
		base.ViewModel.AddEventListenerCommand.SafeSubscribe(delegate
		{
			AddEventListener(controls.WebView);
		}, ViewLifecycleOwner);
		base.ViewModel.SelectRegionCommand.SafeSubscribe(ShowFragment<RegionSelectorFragment>, ViewLifecycleOwner);
		base.ViewModel.OpenAddressSuggestorCommand.SafeSubscribe(ShowFragment<AddressSuggestionFragment>, ViewLifecycleOwner);
		base.ViewModel.OpenPopupChangeCartItemsCommand.SafeSubscribe(ShowFragment<ChangeCartItemsPopupFragment>, ViewLifecycleOwner);
		base.ViewModel.OpenAddressDetailsCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<AddressDetailsFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.CloseCommand.SafeSubscribe(delegate
		{
			_tcs.TrySetResult(result: true);
			Dismiss();
		}, ViewLifecycleOwner);
		base.ViewModel.LoadWebViewCommand.SafeSubscribe(delegate
		{
			OnLoadWebViewCommandAsync(controls).SafeFireAndForget((Action<System.Exception>)null, false);
		}, ViewLifecycleOwner);
		base.ViewModel.ShowExpressDeliveryPopup.SafeSubscribe(delegate
		{
			ShowExpressDeliveryPopup(controls);
		}, ViewLifecycleOwner);
		Window? obj = Dialog?.Window ?? throw new InvalidOperationException("no window");
		obj.SetStatusBarColor(Color.Transparent);
		WindowCompat.SetDecorFitsSystemWindows(obj, decorFitsSystemWindows: false);
		WindowInsetsControllerCompat? insetsController = WindowCompat.GetInsetsController(obj, view);
		insetsController.Hide(WindowInsetsCompat.Type.NavigationBars());
		insetsController.SystemBarsBehavior = 1;
		OnLoadWebViewCommandAsync(controls).SafeFireAndForget((Action<System.Exception>)null, false);
		ViewCompat.SetOnApplyWindowInsetsListener(view, new InsetListener(this));
	}

	private int GetPopupHeight(Controls controls)
	{
		if (base.ViewModel.DeliveryState == AddressMapViewModel.DeliveryType.Delivery)
		{
			return controls.DeliveryLayout.Height + controls.UnavailableInfoContainer.Height + Converter.DpToPx(132f);
		}
		if (!base.ViewModel.UnavailableInfoVisible)
		{
			return Converter.DpToPx(392f);
		}
		return controls.UnavailableInfoContainer.Height + Converter.DpToPx(116f);
	}

	private void SetUnavailableState(Controls controls)
	{
		controls.DeliveryLayout.Visibility = (base.ViewModel.DeliveryState == AddressMapViewModel.DeliveryType.Delivery).ToVisibility();
		controls.PickupStoreList.Visibility = (base.ViewModel.DeliveryState == AddressMapViewModel.DeliveryType.Pickup && !base.ViewModel.UnavailableInfoVisible).ToVisibility();
		controls.CarPickupStoreList.Visibility = (base.ViewModel.DeliveryState == AddressMapViewModel.DeliveryType.CarPickup && !base.ViewModel.UnavailableInfoVisible).ToVisibility();
		controls.UnavailableInfo.Visibility = base.ViewModel.UnavailableInfoVisible.ToVisibility();
	}

	private void OnErrorTitleChanged(Controls controls, string errorTitle)
	{
		controls.Error.Title.Text = errorTitle;
	}

	private void OnErrorMessageChaned(Controls controls, string errorMessage)
	{
		controls.Error.Message.Text = errorMessage;
	}

	private async Task OnLoadWebViewCommandAsync(Controls controls)
	{
		string url = await base.ViewModel.GetMapAddressAsync();
		controls.WebView.LoadUrl(url, base.ViewModel.Headers);
	}

	private void OnSelectedPickupStoreChanged(Controls controls, Store? selectedPickupStore)
	{
		if (base.ViewModel.PickupStoresOfSelectedCity.Count > 0)
		{
			int? indexOfStore = base.ViewModel.GetIndexOfStore(base.ViewModel.PickupStoresOfSelectedCity, selectedPickupStore);
			if (!indexOfStore.HasValue)
			{
				controls.PickupStoreList.ScrollToPosition(0);
			}
			else
			{
				controls.PickupStoreList.ScrollToPosition(indexOfStore.Value + 1);
			}
		}
	}

	private void OnSelectedCarPickupStoreChanged(Controls controls, Store? selectedCarPickupStore)
	{
		if (base.ViewModel.CarPickupStoresOfSelectedCity.Count > 0)
		{
			int? indexOfStore = base.ViewModel.GetIndexOfStore(base.ViewModel.CarPickupStoresOfSelectedCity, selectedCarPickupStore);
			if (!indexOfStore.HasValue)
			{
				controls.CarPickupStoreList.ScrollToPosition(0);
			}
			else
			{
				controls.CarPickupStoreList.ScrollToPosition(indexOfStore.Value + 1);
			}
		}
	}

	private bool SwipePopupOrTapSelectorButton(MotionEvent motionEvent, Controls controls)
	{
		if (motionEvent.Action == MotionEventActions.Down)
		{
			if (_velocityTracker == null)
			{
				_velocityTracker = VelocityTracker.Obtain();
			}
			else
			{
				_velocityTracker.Clear();
			}
			_velocityTracker?.AddMovement(motionEvent);
			return true;
		}
		if (motionEvent.Action == MotionEventActions.Move)
		{
			_velocityTracker?.AddMovement(motionEvent);
			_velocityTracker?.ComputeCurrentVelocity(1, 6f);
			if (System.Math.Abs(_velocityTracker.GetYVelocity(0)) < 3f || System.Math.Abs((int)_velocityTracker.GetYVelocity(0)) == 6)
			{
				return true;
			}
			int historySize = motionEvent.HistorySize;
			float num = ((historySize == 0) ? 0f : motionEvent.GetHistoricalY(historySize - 1));
			float num2 = ((num == 0f) ? 0f : (motionEvent.GetY() - num));
			if (num2 <= 0f)
			{
				if (!_extended)
				{
					_extended = true;
					ChangePopupHeight(0.72605f, controls);
				}
				return true;
			}
			if (num2 > 0f)
			{
				if (_extended)
				{
					_extended = false;
					ShrinkPopup(controls);
				}
				return true;
			}
		}
		return false;
	}

	private void ShrinkPopup(Controls controls)
	{
		float to = (float)GetPopupHeight(controls) / (float)View.Height;
		if (base.ViewModel.DeliveryState != AddressMapViewModel.DeliveryType.Delivery)
		{
			ChangePopupHeight(to, controls);
		}
		else
		{
			ChangePopupHeight(to, controls);
		}
	}

	private void ChangePopupHeight(float to, Controls controls)
	{
		controls.ExtraBottomSpace.Visibility = (!_extended).ToVisibility();
		ViewGroup.LayoutParams layoutParameters = controls.PickupStoreList.LayoutParameters;
		layoutParameters.Height = (_extended ? (View.Height / 100 * (int)(to * 100f) - controls.SaveButtonBackground.Height) : Converter.DpToPx(260f));
		controls.PickupStoreList.LayoutParameters = layoutParameters;
		ViewGroup.LayoutParams layoutParameters2 = controls.CarPickupStoreList.LayoutParameters;
		layoutParameters2.Height = (_extended ? (View.Height / 100 * (int)(to * 100f) - controls.SaveButtonBackground.Height) : Converter.DpToPx(260f));
		controls.PickupStoreList.LayoutParameters = layoutParameters2;
		ConstraintLayout.LayoutParams pplp = (ConstraintLayout.LayoutParams)controls.AddressSelectorPopup.LayoutParameters;
		if (pplp != null && pplp.MatchConstraintPercentHeight != to && _popupAnimator == null)
		{
			_popupAnimator = ValueAnimator.OfFloat(pplp.MatchConstraintPercentHeight, to);
			_popupAnimator.Update += delegate(object? o, ValueAnimator.AnimatorUpdateEventArgs e)
			{
				float num = (float)e.Animation.AnimatedValue;
				pplp.MatchConstraintPercentHeight = num;
				controls.AddressSelectorPopup.LayoutParameters = pplp;
				if (num == to)
				{
					_popupAnimator.Dispose();
					_popupAnimator = null;
				}
			};
			_popupAnimator.SetDuration(100L);
			_popupAnimator.Start();
		}
		ConstraintLayout.LayoutParams wvlp = (ConstraintLayout.LayoutParams)controls.WebViewContainer.LayoutParameters;
		float webViewCompressedPartOfScreen = (_extended ? 0.5479f : (1f - (float)GetPopupHeight(controls) / (float)View.Height));
		if (wvlp == null || wvlp.MatchConstraintPercentHeight == webViewCompressedPartOfScreen || _webViewAnimator != null)
		{
			return;
		}
		_webViewAnimator = ValueAnimator.OfFloat(wvlp.MatchConstraintPercentHeight, webViewCompressedPartOfScreen);
		_webViewAnimator.Update += delegate(object? o, ValueAnimator.AnimatorUpdateEventArgs e)
		{
			float num = (float)e.Animation.AnimatedValue;
			wvlp.MatchConstraintPercentHeight = num;
			controls.WebViewContainer.LayoutParameters = wvlp;
			if (num == webViewCompressedPartOfScreen)
			{
				_webViewAnimator.Dispose();
				_webViewAnimator = null;
			}
		};
		_webViewAnimator.SetDuration(100L);
		_webViewAnimator.Start();
	}

	private void SetDeliverySubtypeButtonFrame(DeliveryTypeButtonControls controls, bool isSelected, bool isAvailable)
	{
		if (Context == null)
		{
			throw new InvalidOperationException("dead code");
		}
		isSelected = isSelected && isAvailable;
		controls.View.Enabled = isAvailable;
		controls.View.SetStrokeColor(ContextCompat.GetColorStateList(Context, isSelected ? 2131100611 : 2131099848));
		controls.Title.SetTextColor(ContextCompat.GetColorStateList(Context, isSelected ? 2131100550 : (isAvailable ? 2131099872 : 2131099849)));
		controls.Subtitle.SetTextColor(ContextCompat.GetColorStateList(Context, isSelected ? 2131100550 : 2131099849));
	}

	private void OnSelectAddressTextChanged(Controls controls, string selectAddressText)
	{
		controls.AddressText.Text = selectAddressText;
		if (string.IsNullOrEmpty(selectAddressText))
		{
			controls.AddressLargeHint.Visibility = ViewStates.Visible;
			TextView addressHint = controls.AddressHint;
			ViewStates visibility = (controls.AddressText.Visibility = ViewStates.Gone);
			addressHint.Visibility = visibility;
		}
		else
		{
			controls.AddressLargeHint.Visibility = ViewStates.Gone;
			TextView addressHint2 = controls.AddressHint;
			ViewStates visibility = (controls.AddressText.Visibility = ViewStates.Visible);
			addressHint2.Visibility = visibility;
		}
	}

	private void OnAddressWarningVisibilityChanged(Controls controls, bool isAddressValidationError)
	{
		ViewStates viewStates = base.ViewModel.IsAddressValidationError.ToVisibility();
		TextView addressWarningText = controls.AddressWarningText;
		ViewStates visibility = (controls.AddressWarningIcon.Visibility = viewStates);
		addressWarningText.Visibility = visibility;
		controls.AddressHint.SetTextColor(ContextCompat.GetColorStateList(Context, isAddressValidationError ? 2131100555 : 2131100600));
		controls.AddressBorderContainer.SetStrokeColor(ContextCompat.GetColorStateList(Context, isAddressValidationError ? 2131100555 : 2131099847));
	}

	private void OnBindPickupHeader(CachingViewHolder holder, object model, int position, CompositeDisposable disposable)
	{
		ListPickupHeaderControls controls = new ListPickupHeaderControls(holder);
		controls.InfoHeader.Text = base.ViewModel.PickupInfoHeader;
		controls.InfoDescription.Text = base.ViewModel.PickupInfoDescription;
		controls.AllStoresTitle.Text = base.ViewModel.AllStoresTitle;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			controls.InfoHeaderLayout.Visibility = base.ViewModel.IsPickupInfoHeaderVisible.ToVisibility();
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsPickupInfoHeaderVisible")))).AddTo(disposable);
	}

	private void OnBindCarPickupHeader(CachingViewHolder holder, object model, int position, CompositeDisposable disposable)
	{
		ListPickupHeaderControls listPickupHeaderControls = new ListPickupHeaderControls(holder);
		listPickupHeaderControls.InfoHeader.Text = base.ViewModel.CarPickupInfoHeader;
		listPickupHeaderControls.InfoDescription.Text = base.ViewModel.CarPickupInfoDescription;
		listPickupHeaderControls.AllStoresTitle.Text = base.ViewModel.AllStoresTitle;
	}

	private void OnBindPickupStore(CachingViewHolder holder, SelectionItemViewModel<Store> model, int position, CompositeDisposable disposable)
	{
		OnBindStore(holder, model, position, base.ViewModel.PickupStoresOfSelectedCity, () => base.ViewModel.SelectedPickupStore = model.Item, disposable);
	}

	private void OnBindCarPickupStore(CachingViewHolder holder, SelectionItemViewModel<Store> model, int position, CompositeDisposable disposable)
	{
		OnBindStore(holder, model, position, base.ViewModel.CarPickupStoresOfSelectedCity, () => base.ViewModel.SelectedCarPickupStore = model.Item, disposable);
	}

	private void OnBindStore(CachingViewHolder holder, SelectionItemViewModel<Store> model, int position, IReadOnlyCollection<SelectionItemViewModel<Store>> stores, Func<Store> setStore, CompositeDisposable disposable)
	{
		ListItemPickupStoreControls controls = new ListItemPickupStoreControls(holder);
		controls.Delete.Visibility = ViewStates.Gone;
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
		})).AddTo(disposable);
	}

	private void DoNothing()
	{
	}

	private void DoNothing(CachingViewHolder holder, object model, int position, CompositeDisposable disposable)
	{
	}

	private void ShowExpressDeliveryPopup(Controls controls)
	{
		if (base.IsAdded && base.IsResumed && !base.IsHidden)
		{
			ExpressDeliveryAvailablePopup.Show(base.ViewModel, base.ViewModel.ExpressDeliveryIsAvailableText, controls.AddressBorderContainer, new Point(0, 8));
		}
	}

	private void EvaluateJavascript(WebView webView, string javaScript)
	{
		webView.EvaluateJavascript(javaScript, null);
	}

	private void AddEventListener(WebView webView)
	{
		webView.EvaluateJavascript("window.addEventListener('message', event => { JSPostMessageInterface.OnPostMessage(JSON.stringify(event.data)); });", null);
	}

	private void ShowFragment<T>(BrokerToken parameter) where T : DialogFragment
	{
		T val = _lazyFragmentFactory.Value.Instantiate<T>();
		val.Arguments = parameter.ToNavBundle();
		val.Show(base.ChildFragmentManager, null);
	}

	public Task<bool> Execute()
	{
		return _tcs.Task;
	}
}
