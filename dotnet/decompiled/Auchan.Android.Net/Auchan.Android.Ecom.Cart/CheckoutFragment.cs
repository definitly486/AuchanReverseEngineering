using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Text;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using AndroidX.Activity;
using AndroidX.AppCompat.App;
using AndroidX.AppCompat.Widget;
using AndroidX.CardView.Widget;
using AndroidX.ConstraintLayout.Widget;
using AndroidX.Core.Content;
using AndroidX.Core.Widget;
using AndroidX.Fragment.App;
using AndroidX.Lifecycle;
using AndroidX.RecyclerView.Widget;
using AsyncAwaitBestPractices;
using Auchan.Android.Base;
using Auchan.Android.Catalog;
using Auchan.Android.Common.UiExtensions;
using Auchan.Android.Controls;
using Auchan.Android.Controls.AccordionLayout;
using Auchan.Android.Drive;
using Auchan.Android.Ecom.Cart.CheckoutAccordionViews;
using Auchan.Android.Extensions;
using Auchan.Android.InfoPages;
using Auchan.Android.LoyaltyProgram;
using Auchan.Common.Base;
using Auchan.Common.Common;
using Auchan.Common.DependencyInjection;
using Auchan.Common.Drive;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.Cart.ViewModels;
using Auchan.Common.Ecom.Drive;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.InfoPages;
using DryIoc;
using EBind;
using Google.Android.Material.Button;
using Google.Android.Material.TextField;
using InputMask;
using Java.Lang;
using Microsoft.Maui.ApplicationModel;
using VisibilitySwitch;

namespace Auchan.Android.Ecom.Cart;

internal sealed class CheckoutFragment : BaseFragment<CheckoutViewModel>
{
	private const int DeliveryDialogRequestCode = 666;

	private ConstraintLayout _defaultLayout;

	private ConstraintLayout _errorLayout;

	private FrameLayout _progressLayout;

	private NestedScrollView _scrollView;

	private TextView _toolbarTitle;

	private View _backButton;

	private SnackView _auchanDriveInfoView;

	private TextView _deliveryAddressTitle;

	private TextView _deliveryTimeTitle;

	private TextInputLayout _addressInputLayout;

	private TextInputLayout _porchInputLayout;

	private TextInputLayout _floorInputLayout;

	private TextInputLayout _flatInputLayout;

	private TextInputLayout _intercomeInputLayout;

	private TextInputLayout _emailLayout;

	private TextInputLayout _nameLayout;

	private TextView _customRecipientPrivateDataWarning;

	private TextInputLayout _customNameLayout;

	private TextInputLayout _commentLayout;

	private TextInputLayout _phoneLayout;

	private TextInputLayout _customPhoneLayout;

	private TextInputEditText _streetInput;

	private TextInputEditText _porchInput;

	private TextInputEditText _floorInput;

	private TextInputEditText _flatInput;

	private TextInputEditText _intercomInput;

	private TextView _driveTitle;

	private View _driveNumberLayout;

	private TextView _driveNumber;

	private TextView _driveDescription;

	private View _driveAddCarLayout;

	private TextView _driveAddCarText;

	private TextInputEditText _commentInput;

	private View _surgeInformer;

	private TextView _surgeInformerText;

	private RecyclerView _deliverySlotsRecyclerView;

	private View _otherDeliverySlotLayout;

	private TextView _otherDeliverySlotTitle;

	private TextView _otherDeliverySlotPrice;

	private TextView _deliveryDateTimeError;

	private View _fastDeliveryDateTimeLayout;

	private TextView _fastDeliveryDateTimeText;

	private AppCompatCheckBox _customRecipientToggle;

	private TextInputEditText _nameInput;

	private TextInputEditText _phoneInput;

	private TextInputEditText _customNameInput;

	private TextInputEditText _customPhoneInput;

	private TextInputEditText _emailInput;

	private AppCompatCheckBox _newEmailSaveCheckBox;

	private SnackView _billEmailSnackView;

	private RecyclerView _replacementsRecycleView;

	private TextView _replacementsHeader;

	private RecyclerView _paymentsRecycleView;

	private TextView _paymentsErrorText;

	private TextView _totalItemsPriceText;

	private TextView _totalItemsPrice;

	private TextView _totalDiscountTitle;

	private TextView _totalDiscount;

	private TextView _promocodeDiscountTitle;

	private TextView _promocodeDiscount;

	private TextView _deliveryPriceText;

	private TextView _deliveryPrice;

	private ImageView _deliveryInfo;

	private TextView _totalOrderPriceText;

	private TextView _totalOrderPrice;

	private TextView _totalPriceText;

	private TextView _totalPrice;

	private Button _paymentButton;

	private View _loyaltyInfoView;

	private TextView _loyaltyTextView;

	private TextView? _errorTitle;

	private TextView? _errorMessage;

	private ImageView? _errorIcon;

	private AppCompatButton? _retryButton;

	private Button _showQrButton;

	private View _adultsReservedLayout;

	private TextView _totalCartItemsPriceText;

	private TextView _totalCartItemsPrice;

	private TextView _paymentsTitle;

	private SnackView _adultSnackView;

	private SnackView _adultTimeMessageSnackView;

	private OnBackPressedCallback? _backPressCallback;

	private TextView _totalReservedItemsPriceText;

	private TextView _totalReservedItemsPrice;

	private SnackView _adultPaymentsSnackView;

	private CardView _productsCardView;

	private CardView _reservedProductsCardView;

	private RecyclerView _productsRecyclerView;

	private RecyclerView _reservedProductsRecyclerView;

	private TextView _productsTitleTextView;

	private TextView _reservedProductsTitleTextView;

	private View _reservedProductsBackgroundView;

	private TextView _bonusesTitle;

	private SnackView _onlyOneMechanicInformer;

	private LinearLayout _accordionLayout;

	private View _paymentDividerView;

	private AccordionElementLayout _promocodeLayout;

	private AccordionElementLayout _pointsPaymentLayout;

	private PromocodeViewActivated _promocodeViewActive;

	private PromocodeViewDisabled _promocodeViewInactive;

	private PointsViewActivated _pointsViewActive;

	private PointsViewDisabled _pointsViewInactive;

	private PointsViewNoPoints _pointsViewNoPoints;

	private PointsViewSpendingUnavailable _pointsViewSpendingUnavailable;

	private ViewGroup _pointsPaymentTotalLayout;

	private TextView _pointsPaymentTotalLabel;

	private TextView _pointsPaymentTotalValue;

	private ViewGroup _stampsWithdrawTotalLayout;

	private TextView _stampsWithdrawTotalLabel;

	private TextView _stampsWithdrawTotalValue;

	private AppCompatCheckBox _hasDeliveryToDoorCheckBox;

	private MaterialButton _reportProblemButton;

	private TextView _pickingPriceText;

	private TextView _pickingPrice;

	private TextView _surgeAmountText;

	private TextView _surgeAmount;

	private BusyPopup _busyPopup;

	protected override bool NeedToAdjustScreenToKeyboardMoves => true;

	protected override int LayoutId => 2131493007;

	public CheckoutFragment(Func<BrokerToken, CheckoutViewModel> newViewModel)
		: base((Func<AndroidX.Fragment.App.Fragment, CheckoutViewModel>)((AndroidX.Fragment.App.Fragment thisFragment) => newViewModel(thisFragment.RequireNavToken())))
	{
	}

	public override void OnCreate(Bundle savedInstanceState)
	{
		base.OnCreate(savedInstanceState);
		_backPressCallback = RequireActivity().OnBackPressedDispatcher.AddCallback(this, base.ViewModel.OnBackPressed);
		base.ViewModel.SelectDeliveryCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<DeliveryDateTimeDialog, BrokerToken>(p);
		}, this);
		base.ViewModel.OpenAddCarCommand.SafeSubscribe(async delegate(CarFormViewModel.Parameter _)
		{
			await ShowAddNewCarDialog(_);
		}, this);
		base.ViewModel.OpenSelectCarCommand.SafeSubscribe(async delegate(Unit _)
		{
			await OpenSelectCarScreen(_);
		}, this);
		base.ViewModel.GoToPaymentCommand.SafeSubscribe(delegate(CheckoutWebViewModel.Parameter p)
		{
			GoToPaymentAsync(p).SafeFireAndForget((Action<System.Exception>)null, false);
		}, this);
		base.ViewModel.PopToRootCommand.SafeSubscribe(delegate
		{
			OnPopToRoot();
		}, this);
		base.ViewModel.SuccessfulPaymentCommand.SafeSubscribe(ShowSuccessfulPayment, this);
		base.ViewModel.OpenInfoPageCommand.SafeSubscribe(OpenLoyaltyPolicy, this);
		base.ViewModel.PopBackCommand.SafeSubscribe(delegate
		{
			GoBackAsync().SafeFireAndForget((Action<System.Exception>)null, false);
		}, this);
		base.ViewModel.OpenPointsInformerCommand.SafeSubscribe(OpenPointsPaymentInformer, this);
	}

	private async Task OpenSelectCarScreen(Unit obj)
	{
		if (Platform.CurrentActivity is AppCompatActivity)
		{
			Car car = await Show<SelectCarFragment>().Execute();
			if (car != null)
			{
				base.ViewModel.UpdateCar(car);
			}
		}
	}

	private async Task ShowAddNewCarDialog(CarFormViewModel.Parameter parameter)
	{
		if (Platform.CurrentActivity is AppCompatActivity appCompatActivity)
		{
			AddCarPopupFragment addCarPopupFragment = DI.ResolverBecauseConstructorInjectionIsNotPossible.Resolve<FragmentFactory>().Instantiate<AddCarPopupFragment>();
			addCarPopupFragment.Arguments = new CarFormViewModel.Parameter().ToNavBundle();
			addCarPopupFragment.Show(appCompatActivity.SupportFragmentManager, string.Empty);
			await addCarPopupFragment.WaitAddingCar();
		}
	}

	public override void OnViewCreated(View view, Bundle savedInstanceState)
	{
		base.OnViewCreated(view, savedInstanceState);
		_defaultLayout = view.RequireViewById<ConstraintLayout>(2131296904);
		_errorLayout = view.RequireViewById<ConstraintLayout>(2131297111);
		_progressLayout = view.RequireViewById<FrameLayout>(2131298079);
		_scrollView = _defaultLayout.RequireViewById<NestedScrollView>(2131298303);
		_deliveryAddressTitle = _scrollView.RequireViewById<TextView>(2131296928);
		_deliveryTimeTitle = _scrollView.RequireViewById<TextView>(2131296941);
		_auchanDriveInfoView = _scrollView.RequireViewById<SnackView>(2131296464);
		_addressInputLayout = _scrollView.RequireViewById<TextInputLayout>(2131298540);
		_porchInputLayout = _scrollView.RequireViewById<TextInputLayout>(2131297972);
		_floorInputLayout = _scrollView.RequireViewById<TextInputLayout>(2131297203);
		_flatInputLayout = _scrollView.RequireViewById<TextInputLayout>(2131297194);
		_intercomeInputLayout = _scrollView.RequireViewById<TextInputLayout>(2131297376);
		_commentLayout = _scrollView.RequireViewById<TextInputLayout>(2131296817);
		_toolbarTitle = _defaultLayout.RequireViewById<TextView>(2131298679);
		_backButton = _defaultLayout.RequireViewById<ImageView>(2131296490);
		_streetInput = _addressInputLayout.RequireViewById<TextInputEditText>(2131298539);
		_porchInput = _porchInputLayout.RequireViewById<TextInputEditText>(2131297971);
		_floorInput = _floorInputLayout.RequireViewById<TextInputEditText>(2131297202);
		_flatInput = _flatInputLayout.RequireViewById<TextInputEditText>(2131297193);
		_intercomInput = _intercomeInputLayout.RequireViewById<TextInputEditText>(2131297375);
		_driveTitle = _scrollView.RequireViewById<TextView>(2131296622);
		_driveNumberLayout = _scrollView.RequireViewById<ConstraintLayout>(2131296617);
		_driveNumber = _driveNumberLayout.RequireViewById<TextView>(2131296620);
		_driveDescription = _driveNumberLayout.RequireViewById<TextView>(2131296619);
		_driveAddCarLayout = _scrollView.RequireViewById<LinearLayout>(2131296615);
		_driveAddCarText = _driveAddCarLayout.RequireViewById<TextView>(2131296616);
		_commentInput = _commentLayout.RequireViewById<TextInputEditText>(2131296816);
		_surgeInformer = _scrollView.RequireViewById<View>(2131298577);
		_surgeInformerText = _surgeInformer.RequireViewById<TextView>(2131298578);
		_deliverySlotsRecyclerView = _scrollView.RequireViewById<RecyclerView>(2131296940);
		_otherDeliverySlotLayout = _scrollView.RequireViewById<View>(2131297821);
		_otherDeliverySlotTitle = _otherDeliverySlotLayout.RequireViewById<TextView>(2131297823);
		_otherDeliverySlotPrice = _otherDeliverySlotLayout.RequireViewById<TextView>(2131297822);
		_deliveryDateTimeError = _scrollView.RequireViewById<TextView>(2131296930);
		_fastDeliveryDateTimeLayout = _scrollView.RequireViewById<View>(2131297143);
		_fastDeliveryDateTimeText = _fastDeliveryDateTimeLayout.RequireViewById<TextView>(2131297144);
		_customRecipientToggle = _scrollView.RequireViewById<AppCompatCheckBox>(2131296884);
		_hasDeliveryToDoorCheckBox = _scrollView.RequireViewById<AppCompatCheckBox>(2131297262);
		_nameLayout = _scrollView.RequireViewById<TextInputLayout>(2131297634);
		_nameInput = _nameLayout.RequireViewById<TextInputEditText>(2131297633);
		_phoneLayout = _scrollView.RequireViewById<TextInputLayout>(2131297869);
		_phoneInput = _phoneLayout.RequireViewById<TextInputEditText>(2131297868);
		_emailLayout = _scrollView.RequireViewById<TextInputLayout>(2131297051);
		_emailInput = _emailLayout.RequireViewById<TextInputEditText>(2131297050);
		_customRecipientPrivateDataWarning = _scrollView.RequireViewById<TextView>(2131296883);
		_customNameLayout = _scrollView.RequireViewById<TextInputLayout>(2131296879);
		_customNameInput = _customNameLayout.RequireViewById<TextInputEditText>(2131296878);
		_customPhoneLayout = _scrollView.RequireViewById<TextInputLayout>(2131296882);
		_customPhoneInput = _customPhoneLayout.RequireViewById<TextInputEditText>(2131296881);
		_newEmailSaveCheckBox = _scrollView.RequireViewById<AppCompatCheckBox>(2131298290);
		_billEmailSnackView = _scrollView.RequireViewById<SnackView>(2131296535);
		_replacementsHeader = _scrollView.RequireViewById<TextView>(2131298206);
		_replacementsRecycleView = _scrollView.RequireViewById<RecyclerView>(2131298207);
		_paymentsRecycleView = _scrollView.RequireViewById<RecyclerView>(2131297859);
		_paymentsErrorText = _scrollView.RequireViewById<TextView>(2131297853);
		_totalItemsPriceText = _scrollView.RequireViewById<TextView>(2131298723);
		_totalItemsPrice = _scrollView.RequireViewById<TextView>(2131298722);
		_totalDiscountTitle = _scrollView.RequireViewById<TextView>(2131298735);
		_totalDiscount = _scrollView.RequireViewById<TextView>(2131298734);
		_promocodeDiscountTitle = _scrollView.RequireViewById<TextView>(2131298101);
		_promocodeDiscount = _scrollView.RequireViewById<TextView>(2131298100);
		_scrollView.RequireViewById<View>(2131296998).Visibility = ViewStates.Gone;
		_pickingPriceText = _scrollView.RequireViewById<TextView>(2131297895);
		_pickingPrice = _scrollView.RequireViewById<TextView>(2131297894);
		_surgeAmountText = _scrollView.RequireViewById<TextView>(2131298576);
		_surgeAmount = _scrollView.RequireViewById<TextView>(2131298575);
		_deliveryPriceText = _scrollView.RequireViewById<TextView>(2131296937);
		_deliveryPrice = _scrollView.RequireViewById<TextView>(2131296934);
		_deliveryInfo = _scrollView.RequireViewById<ImageView>(2131296936);
		_totalOrderPriceText = _scrollView.RequireViewById<TextView>(2131298727);
		_totalOrderPrice = _scrollView.RequireViewById<TextView>(2131298726);
		_totalPriceText = _scrollView.RequireViewById<TextView>(2131298729);
		_totalPrice = _scrollView.RequireViewById<TextView>(2131298728);
		_paymentButton = _defaultLayout.RequireViewById<Button>(2131297852);
		_errorTitle = _errorLayout.RequireViewById<TextView>(2131298646);
		_errorMessage = _errorLayout.RequireViewById<TextView>(2131297563);
		_errorIcon = _errorLayout.RequireViewById<ImageView>(2131297308);
		_retryButton = _errorLayout.RequireViewById<AppCompatButton>(2131296325);
		_reportProblemButton = _errorLayout.RequireViewById<MaterialButton>(2131298210);
		_showQrButton = _errorLayout.RequireViewById<Button>(2131298371);
		_adultsReservedLayout = _scrollView.RequireViewById<View>(2131296410);
		_totalCartItemsPriceText = _scrollView.RequireViewById<TextView>(2131296695);
		_totalCartItemsPrice = _scrollView.RequireViewById<TextView>(2131296694);
		_totalReservedItemsPriceText = _scrollView.RequireViewById<TextView>(2131298215);
		_totalReservedItemsPrice = _scrollView.RequireViewById<TextView>(2131298214);
		_loyaltyInfoView = _scrollView.RequireViewById<LinearLayout>(2131297500);
		_loyaltyTextView = _loyaltyInfoView.RequireViewById<TextView>(2131297502);
		_paymentsTitle = _scrollView.RequireViewById<TextView>(2131297860);
		_adultSnackView = _scrollView.RequireViewById<SnackView>(2131296409);
		_adultTimeMessageSnackView = _scrollView.RequireViewById<SnackView>(2131298216);
		_adultPaymentsSnackView = _scrollView.RequireViewById<SnackView>(2131298213);
		_productsCardView = _scrollView.RequireViewById<CardView>(2131298034);
		_productsRecyclerView = _productsCardView.RequireViewById<RecyclerView>(2131298039);
		_productsTitleTextView = _productsCardView.RequireViewById<TextView>(2131298042);
		_reservedProductsBackgroundView = _scrollView.RequireViewById<View>(2131298217);
		_reservedProductsCardView = _scrollView.RequireViewById<CardView>(2131298218);
		_reservedProductsRecyclerView = _reservedProductsCardView.RequireViewById<RecyclerView>(2131298219);
		_reservedProductsTitleTextView = _reservedProductsCardView.RequireViewById<TextView>(2131298220);
		_onlyOneMechanicInformer = _scrollView.RequireViewById<SnackView>(2131297745);
		_bonusesTitle = _scrollView.RequireViewById<TextView>(2131296312);
		_accordionLayout = _scrollView.RequireViewById<LinearLayout>(2131296311);
		_paymentDividerView = _scrollView.RequireViewById<View>(2131297857);
		_promocodeLayout = _accordionLayout.RequireViewById<AccordionElementLayout>(2131298096);
		_pointsPaymentLayout = _accordionLayout.RequireViewById<AccordionElementLayout>(2131297925);
		_promocodeViewActive = _promocodeLayout.RequireViewById<PromocodeViewActivated>(2131298097);
		_promocodeViewInactive = _promocodeLayout.RequireViewById<PromocodeViewDisabled>(2131298098);
		_pointsViewActive = _pointsPaymentLayout.RequireViewById<PointsViewActivated>(2131297926);
		_pointsViewInactive = _pointsPaymentLayout.RequireViewById<PointsViewDisabled>(2131297927);
		_pointsViewNoPoints = _pointsPaymentLayout.RequireViewById<PointsViewNoPoints>(2131297929);
		_pointsViewSpendingUnavailable = _pointsPaymentLayout.RequireViewById<PointsViewSpendingUnavailable>(2131297928);
		_pointsPaymentTotalLayout = _scrollView.RequireViewById<ViewGroup>(2131297944);
		_pointsPaymentTotalLabel = _pointsPaymentTotalLayout.RequireViewById<TextView>(2131297945);
		_pointsPaymentTotalValue = _pointsPaymentTotalLayout.RequireViewById<TextView>(2131297946);
		_stampsWithdrawTotalLayout = view.RequireViewById<ViewGroup>(2131298459);
		_stampsWithdrawTotalLabel = view.RequireViewById<TextView>(2131298460);
		_stampsWithdrawTotalValue = view.RequireViewById<TextView>(2131298461);
		SetupInputRestrictions();
		SetupBindings();
	}

	public override void OnDestroyView()
	{
		base.OnDestroyView();
		_scrollView = null;
		_defaultLayout = null;
		_errorLayout = null;
		_progressLayout = null;
		_toolbarTitle = null;
		_backButton = null;
		_deliveryInfo = null;
		_streetInput = null;
		_porchInput = null;
		_floorInput = null;
		_flatInput = null;
		_intercomInput = null;
		_commentInput = null;
		_surgeInformer = null;
		_surgeInformerText = null;
		_deliverySlotsRecyclerView = null;
		_otherDeliverySlotLayout = null;
		_otherDeliverySlotTitle = null;
		_otherDeliverySlotPrice = null;
		_deliveryDateTimeError = null;
		_fastDeliveryDateTimeLayout = null;
		_fastDeliveryDateTimeText = null;
		_customRecipientToggle = null;
		_newEmailSaveCheckBox = null;
		_billEmailSnackView = null;
		_nameInput = null;
		_nameLayout = null;
		_phoneInput = null;
		_emailLayout = null;
		_emailInput = null;
		_customRecipientPrivateDataWarning = null;
		_customNameInput = null;
		_customNameLayout = null;
		_customPhoneInput = null;
		_customPhoneLayout = null;
		_hasDeliveryToDoorCheckBox = null;
		_adultsReservedLayout = null;
		_totalItemsPriceText = null;
		_totalItemsPrice = null;
		_pickingPriceText = null;
		_pickingPrice = null;
		_surgeAmountText = null;
		_surgeAmount = null;
		_deliveryPriceText = null;
		_deliveryPrice = null;
		_totalOrderPriceText = null;
		_totalOrderPrice = null;
		_totalPriceText = null;
		_totalPrice = null;
		_paymentButton = null;
		_errorTitle = null;
		_errorMessage = null;
		_errorIcon = null;
		_retryButton = null;
		_reportProblemButton = null;
		_showQrButton = null;
		_loyaltyTextView = null;
		_onlyOneMechanicInformer = null;
		_bonusesTitle = null;
		_accordionLayout = null;
		_promocodeLayout = null;
		_pointsPaymentLayout = null;
		_promocodeViewActive = null;
		_promocodeViewInactive = null;
		_pointsViewActive = null;
		_pointsViewInactive = null;
		_pointsViewNoPoints = null;
		_pointsViewSpendingUnavailable = null;
		_pointsPaymentTotalLayout = null;
		_pointsPaymentTotalLabel = null;
		_pointsPaymentTotalValue = null;
		_stampsWithdrawTotalLayout = null;
		_stampsWithdrawTotalLabel = null;
		_stampsWithdrawTotalValue = null;
	}

	public override void OnHiddenChanged(bool hidden)
	{
		base.OnHiddenChanged(hidden);
		_backPressCallback.Enabled = !hidden;
	}

	private void SetupInputRestrictions()
	{
		InputFilterLengthFilter inputFilterLengthFilter = new InputFilterLengthFilter(25);
		InputFilterLengthFilter inputFilterLengthFilter2 = new InputFilterLengthFilter(200);
		TextInputEditText customNameInput = _customNameInput;
		IInputFilter[] filters = new InputFilterLengthFilter[1] { inputFilterLengthFilter };
		customNameInput.SetFilters(filters);
		TextInputEditText porchInput = _porchInput;
		filters = new InputFilterLengthFilter[1] { inputFilterLengthFilter };
		porchInput.SetFilters(filters);
		TextInputEditText floorInput = _floorInput;
		filters = new InputFilterLengthFilter[1] { inputFilterLengthFilter };
		floorInput.SetFilters(filters);
		TextInputEditText flatInput = _flatInput;
		filters = new InputFilterLengthFilter[1] { inputFilterLengthFilter };
		flatInput.SetFilters(filters);
		TextInputEditText intercomInput = _intercomInput;
		filters = new InputFilterLengthFilter[1] { inputFilterLengthFilter };
		intercomInput.SetFilters(filters);
		TextInputEditText commentInput = _commentInput;
		filters = new InputFilterLengthFilter[1] { inputFilterLengthFilter2 };
		commentInput.SetFilters(filters);
	}

	private void SetupBindings()
	{
		_porchInput.EditorAction += new DisposableDelegate<EventHandler<TextView.EditorActionEventArgs>>(delegate(object? s, TextView.EditorActionEventArgs e)
		{
			if (e.ActionId == ImeAction.Next)
			{
				_floorInput.ForceFocusKeyboard();
			}
		}, delegate(EventHandler<TextView.EditorActionEventArgs> h)
		{
			_porchInput.EditorAction -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		_floorInput.EditorAction += new DisposableDelegate<EventHandler<TextView.EditorActionEventArgs>>(delegate(object? s, TextView.EditorActionEventArgs e)
		{
			if (e.ActionId == ImeAction.Next)
			{
				_flatInput.ForceFocusKeyboard();
			}
		}, delegate(EventHandler<TextView.EditorActionEventArgs> h)
		{
			_floorInput.EditorAction -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		_flatInput.EditorAction += new DisposableDelegate<EventHandler<TextView.EditorActionEventArgs>>(delegate(object? s, TextView.EditorActionEventArgs e)
		{
			if (e.ActionId == ImeAction.Next)
			{
				_intercomInput.ForceFocusKeyboard();
			}
		}, delegate(EventHandler<TextView.EditorActionEventArgs> h)
		{
			_flatInput.EditorAction -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		_intercomInput.EditorAction += new DisposableDelegate<EventHandler<TextView.EditorActionEventArgs>>(delegate(object? s, TextView.EditorActionEventArgs e)
		{
			if (e.ActionId == ImeAction.Next)
			{
				_commentInput.ForceFocusKeyboard();
			}
		}, delegate(EventHandler<TextView.EditorActionEventArgs> h)
		{
			_intercomInput.EditorAction -= h;
		}).AutoDisposeOnDestroy(ViewLifecycleOwner);
		_adultTimeMessageSnackView.Text = base.ViewModel.ReservedWarningText;
		_adultPaymentsSnackView.Text = base.ViewModel.ReservedWarningText;
		_adultSnackView.Visibility = ViewStates.Gone;
		_totalDiscountTitle.Text = base.ViewModel.TotalDiscountTitle;
		_promocodeDiscountTitle.Text = base.ViewModel.PromocodeDiscountTitle;
		_totalCartItemsPriceText.Text = base.ViewModel.TotalInCartTitle;
		_totalReservedItemsPriceText.Text = base.ViewModel.TotalReservedTitle;
		_productsTitleTextView.Text = base.ViewModel.ProductsTitle;
		_reservedProductsTitleTextView.Text = base.ViewModel.ReservedProductsTitle;
		_paymentsTitle.Text = base.ViewModel.PaymentHeaderText;
		ObservableRecyclerAdapter<PaymentItemViewModel, CachingViewHolder> paymentsAdapter = new ObservableRecyclerAdapter<PaymentItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493276,
			BindViewHolderDelegate = BindPaymentMethod
		};
		_paymentsRecycleView.SetAdapter(paymentsAdapter);
		_paymentsRecycleView.HasFixedSize = true;
		ObservableRecyclerAdapter<CheckoutSlotItemViewModel, CachingViewHolder> deliverySlotsAdapter = new ObservableRecyclerAdapter<CheckoutSlotItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493228,
			BindViewHolderDelegate = BindDeliverySlot
		};
		_deliverySlotsRecyclerView.SetAdapter(deliverySlotsAdapter);
		_deliverySlotsRecyclerView.AddOnScrollListener(new ProductsScrollListener(TrackVisibleDeliverySlots));
		_otherDeliverySlotTitle.Text = base.ViewModel.OtherDeliverySlotText;
		_surgeInformerText.Text = base.ViewModel.SurgeInformerText;
		_surgeAmountText.Text = base.ViewModel.SurgeAmountTitle;
		ObservableRecyclerAdapter<ReplacementItemViewModel, CachingViewHolder> replacementsAdapter = new ObservableRecyclerAdapter<ReplacementItemViewModel, CachingViewHolder>
		{
			CellLayoutId = 2131493320,
			BindViewHolderDelegate = BindReplacementMethod
		};
		_replacementsRecycleView.SetAdapter(replacementsAdapter);
		ObservableRecyclerAdapter<CheckoutProduct, CachingViewHolder> productsAdapter = new ObservableRecyclerAdapter<CheckoutProduct, CachingViewHolder>
		{
			CellLayoutId = 2131493229,
			BindViewHolderDelegate = BindProduct
		};
		_productsRecyclerView.SetAdapter(productsAdapter);
		ObservableRecyclerAdapter<CheckoutProduct, CachingViewHolder> reservedProductsAdapter = new ObservableRecyclerAdapter<CheckoutProduct, CachingViewHolder>
		{
			CellLayoutId = 2131493229,
			BindViewHolderDelegate = BindProduct
		};
		_reservedProductsRecyclerView.SetAdapter(reservedProductsAdapter);
		_billEmailSnackView.Text = base.ViewModel.EmailBillInfoText;
		_newEmailSaveCheckBox.Text = base.ViewModel.SaveNewEmailText;
		_customRecipientToggle.Text = base.ViewModel.CustomReceiverText;
		_hasDeliveryToDoorCheckBox.Text = base.ViewModel.DeliveryToDoorText;
		_nameInput.Hint = base.ViewModel.NamePlaceholder;
		_phoneInput.Hint = base.ViewModel.PhonePlaceholder;
		_customNameLayout.Hint = base.ViewModel.CustomNamePlaceholder;
		_customPhoneLayout.Hint = base.ViewModel.CustomPhonePlaceholder;
		_emailLayout.Hint = base.ViewModel.EmailPlaceholder;
		base.Activity.Window.HideKeyboardOnTouchOutside(ViewLifecycleOwner, _pointsViewActive.InputLayout, _promocodeViewActive.TextViewWithOk, _nameInput, _phoneInput, _customNameInput, _customPhoneInput, _emailInput, _streetInput, _porchInput, _floorInput, _flatInput, _intercomInput, _commentInput);
		string mask = base.ViewModel.PhoneMask + "[0]";
		_customPhoneInput.InstallMaskedListener(mask, new ValueListener(OnPhoneChanged));
		_phoneInput.InstallMaskedListener(mask, null);
		SetVisibility(_phoneInput, isVisible: false);
		_driveTitle.Text = base.ViewModel.DriveHeaderText;
		_driveAddCarText.Text = base.ViewModel.DriveCarAddText;
		_totalOrderPriceText.Text = base.ViewModel.TotalOrderPriceText;
		_totalPriceText.Text = base.ViewModel.TotalPriceText;
		_bonusesTitle.Text = base.ViewModel.BonusesTitle;
		_pointsViewActive.Setup(base.ViewModel, ViewLifecycleOwner);
		_pointsViewInactive.Setup(base.ViewModel, ViewLifecycleOwner);
		_pointsViewNoPoints.Setup(base.ViewModel, ViewLifecycleOwner);
		_pointsViewSpendingUnavailable.Setup(base.ViewModel, ViewLifecycleOwner);
		_pointsPaymentTotalLabel.Text = base.ViewModel.PointsPaymentTitle;
		_stampsWithdrawTotalLabel.Text = base.ViewModel.StampsWithdrawTitle;
		_promocodeViewActive.Setup(base.ViewModel, ViewLifecycleOwner);
		_promocodeViewInactive.Setup(base.ViewModel, ViewLifecycleOwner);
		VisibilitySwitch<CheckoutViewModel.VisualState> viewSwitch = new VisibilitySwitch<CheckoutViewModel.VisualState>(base.ViewModel.State)
		{
			{
				CheckoutViewModel.VisualState.Default,
				_defaultLayout
			},
			{
				CheckoutViewModel.VisualState.InProgress,
				_progressLayout
			},
			{
				CheckoutViewModel.VisualState.Error,
				_errorLayout
			}
		};
		SetVisibility(_nameInput, isVisible: false);
		_replacementsHeader.Text = base.ViewModel.ReplacementsHeader;
		base.ViewModel.BindProperties(new global::_003C_003Ez__ReadOnlyArray<(Action, IReadOnlyList<string>)>(new(Action, IReadOnlyList<string>)[103]
		{
			(delegate
			{
				_deliveryAddressTitle.Text = base.ViewModel.DeliveryHeaderText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryHeaderText")),
			(delegate
			{
				_deliveryTimeTitle.Text = base.ViewModel.DateHeaderText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DateHeaderText")),
			(delegate
			{
				_auchanDriveInfoView.Text = base.ViewModel.DriveZoneInfo;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DriveZoneInfo")),
			(delegate
			{
				_auchanDriveInfoView.Visibility = base.ViewModel.IsDriveInfoViewVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsDriveInfoViewVisible")),
			(delegate
			{
				_addressInputLayout.Hint = base.ViewModel.AddressPlaceholder;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AddressPlaceholder")),
			(delegate
			{
				bool value = base.ViewModel.ReceivingMethod.IsDelivery();
				_porchInputLayout.Visibility = value.ToVisibility();
				_floorInputLayout.Visibility = value.ToVisibility();
				_flatInputLayout.Visibility = value.ToVisibility();
				_intercomeInputLayout.Visibility = value.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReceivingMethod")),
			(delegate
			{
				_driveTitle.Visibility = base.ViewModel.IsDriveRecevingmethod.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsDriveRecevingmethod")),
			(delegate
			{
				_driveNumberLayout.Visibility = base.ViewModel.IsCarAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCarAvailable")),
			(delegate
			{
				_driveAddCarLayout.Visibility = base.ViewModel.IsCarSelectionAvailable.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsCarSelectionAvailable")),
			(delegate
			{
				viewSwitch.SwitchState(base.ViewModel.State);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("State")),
			(delegate
			{
				OnIsOverlayInProgressChanged(base.ViewModel.IsOverlayInProgress).SafeFireAndForget((Action<System.Exception>)null, false);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsOverlayInProgress")),
			(delegate
			{
				SetText(_streetInput, base.ViewModel.Street, state: false);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Street")),
			(delegate
			{
				_nameInput.Text = base.ViewModel.Name;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Name")),
			(delegate
			{
				_customNameInput.Text = base.ViewModel.CustomName;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CustomName")),
			(delegate
			{
				_emailInput.ApplyText(base.ViewModel.Email);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Email")),
			(delegate
			{
				base.ViewModel.IsPhoneFilled = !base.ViewModel.CustomRecipient || base.ViewModel.CustomPhone.Length == 10;
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "CustomRecipient", "CustomPhone" })),
			(delegate
			{
				_newEmailSaveCheckBox.Visibility = base.ViewModel.IsSaveNewEmailVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSaveNewEmailVisible")),
			(delegate
			{
				_newEmailSaveCheckBox.Checked = base.ViewModel.IsSaveNewEmail;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSaveNewEmail")),
			(delegate
			{
				_totalItemsPriceText.Text = base.ViewModel.TotalItemsPriceText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalItemsPriceText")),
			(delegate
			{
				_totalItemsPrice.Text = base.ViewModel.TotalItemsPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalItemsPrice")),
			(delegate
			{
				_totalDiscountTitle.Visibility = base.ViewModel.HasDiscount.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasDiscount")),
			(delegate
			{
				_totalDiscount.Visibility = base.ViewModel.HasDiscount.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasDiscount")),
			(delegate
			{
				_totalDiscount.Text = base.ViewModel.TotalDiscount;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalDiscount")),
			(delegate
			{
				_promocodeDiscountTitle.Visibility = base.ViewModel.HasPromocodeDiscount.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasPromocodeDiscount")),
			(delegate
			{
				_promocodeDiscount.Visibility = base.ViewModel.HasPromocodeDiscount.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasPromocodeDiscount")),
			(delegate
			{
				_promocodeDiscount.Text = base.ViewModel.PromocodeDiscount;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PromocodeDiscount")),
			(delegate
			{
				_deliveryPriceText.Text = base.ViewModel.PriceText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PriceText")),
			(delegate
			{
				_deliveryPrice.Text = base.ViewModel.DeliveryPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryPrice")),
			(delegate
			{
				_pickingPriceText.Text = base.ViewModel.PickingPriceTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PickingPriceTitle")),
			(delegate
			{
				_pickingPrice.Text = base.ViewModel.PickingPriceText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PickingPriceText")),
			(delegate
			{
				_pickingPriceText.Visibility = base.ViewModel.PickingPriceVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PickingPriceVisible")),
			(delegate
			{
				_pickingPrice.Visibility = base.ViewModel.PickingPriceVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PickingPriceVisible")),
			(delegate
			{
				_surgeAmount.Text = base.ViewModel.SurgeAmountText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SurgeAmountText")),
			(delegate
			{
				_surgeAmountText.Visibility = base.ViewModel.SurgeAmountVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SurgeAmountVisible")),
			(delegate
			{
				_surgeAmount.Visibility = base.ViewModel.SurgeAmountVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SurgeAmountVisible")),
			(delegate
			{
				_deliveryInfo.Visibility = base.ViewModel.IsDeliveryInfoIconVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsDeliveryInfoIconVisible")),
			(delegate
			{
				_totalOrderPrice.Text = base.ViewModel.TotalOrderPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalOrderPrice")),
			(delegate
			{
				_totalPrice.Text = base.ViewModel.TotalPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalPrice")),
			(delegate
			{
				_paymentButton.Text = base.ViewModel.PaymentButtonText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PaymentButtonText")),
			(delegate
			{
				SetButtonStyle(_paymentButton, base.ViewModel.PaymentButtonEnabled);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PaymentButtonEnabled")),
			(delegate
			{
				_surgeInformer.Visibility = base.ViewModel.IsSurgeInformerVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsSurgeInformerVisible")),
			(delegate
			{
				_deliverySlotsRecyclerView.Visibility = base.ViewModel.IsDeliverySlotsVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsDeliverySlotsVisible")),
			(delegate
			{
				deliverySlotsAdapter.DataSource = base.ViewModel.DeliverySlots;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliverySlots")),
			(delegate
			{
				_otherDeliverySlotLayout.Visibility = base.ViewModel.IsOtherDeliverySlotVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsOtherDeliverySlotVisible")),
			(delegate
			{
				_otherDeliverySlotPrice.Text = base.ViewModel.OtherDeliverySlotPriceText;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OtherDeliverySlotPriceText")),
			(delegate
			{
				_otherDeliverySlotPrice.Visibility = base.ViewModel.IsOtherDeliverySlotPriceVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsOtherDeliverySlotPriceVisible")),
			(delegate
			{
				_fastDeliveryDateTimeText.Text = base.ViewModel.SelectedDeliveryDate;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedDeliveryDate")),
			(delegate
			{
				SetDeliveryDateTimeSelectable(base.ViewModel.IsDeliveryDateTimeSelectable);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsDeliveryDateTimeSelectable")),
			(delegate
			{
				ScrollToDeliverySlot(base.ViewModel.SelectedDeliverySlotIndex);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("SelectedDeliverySlotIndex")),
			(delegate
			{
				_loyaltyTextView.AddLinkedText(base.ViewModel.LoyaltyInformerText, new Color(ContextCompat.GetColor(RequireContext(), 2131100550)), underlineLinks: true, withDots: false, new Color(ContextCompat.GetColor(RequireContext(), 2131100550)), 2131952192);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("LoyaltyInformerText")),
			(delegate
			{
				_customRecipientPrivateDataWarning.AddLinkedText(base.ViewModel.CustomReceiverPersDataWarningText, new Color(ContextCompat.GetColor(RequireContext(), 2131100550)), underlineLinks: false);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CustomReceiverPersDataWarningText")),
			(delegate
			{
				_driveNumber.Text = base.ViewModel.DriveCarNumber;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DriveCarNumber")),
			(delegate
			{
				_driveDescription.Text = base.ViewModel.DriveCarDescription;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DriveCarDescription")),
			(delegate
			{
				_customRecipientToggle.Checked = base.ViewModel.CustomRecipient;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CustomRecipient")),
			(delegate
			{
				IsDeliveryToDoorAvaliable(base.ViewModel.HasDeliveryToDoor);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("HasDeliveryToDoor")),
			(delegate
			{
				_productsCardView.Visibility = base.ViewModel.AreInCartItemsExists.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AreInCartItemsExists")),
			(delegate
			{
				_reservedProductsCardView.Visibility = base.ViewModel.AreReservedItemsExists.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AreReservedItemsExists")),
			(delegate
			{
				_reservedProductsBackgroundView.Visibility = (base.ViewModel.AreReservedItemsExists && base.ViewModel.AreInCartItemsExists).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "AreReservedItemsExists", "AreInCartItemsExists" })),
			(delegate
			{
				_bonusesTitle.Visibility = base.ViewModel.BonusesEnabled.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("BonusesEnabled")),
			(delegate
			{
				_accordionLayout.Visibility = base.ViewModel.BonusesEnabled.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("BonusesEnabled")),
			(delegate
			{
				_paymentDividerView.Visibility = base.ViewModel.BonusesEnabled.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("BonusesEnabled")),
			(delegate
			{
				_onlyOneMechanicInformer.Visibility = base.ViewModel.OnlyOneMechanicInformerVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OnlyOneMechanicInformerVisible")),
			(delegate
			{
				_onlyOneMechanicInformer.AddLinkedText(base.ViewModel.OnlyOneMechanicInformer);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("OnlyOneMechanicInformer")),
			(delegate
			{
				_promocodeLayout.SetState(base.ViewModel.PromocodeState);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PromocodeState")),
			(delegate
			{
				_pointsPaymentLayout.SetState(base.ViewModel.PointsPaymentState);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PointsPaymentState")),
			(delegate
			{
				_pointsPaymentTotalValue.Text = base.ViewModel.UsedPoints;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("UsedPoints")),
			(delegate
			{
				_pointsPaymentTotalLayout.Visibility = base.ViewModel.IsUsedPointsVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsUsedPointsVisible")),
			(delegate
			{
				_stampsWithdrawTotalValue.Text = $"-{base.ViewModel.StampsWithdrawValue}";
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("StampsWithdrawValue")),
			(delegate
			{
				_stampsWithdrawTotalLayout.Visibility = base.ViewModel.DiscardStamps.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DiscardStamps")),
			(delegate
			{
				_errorTitle.Text = base.ViewModel.ErrorTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorTitle")),
			(delegate
			{
				_errorMessage.Text = base.ViewModel.ErrorMessage;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorMessage")),
			(delegate
			{
				_retryButton.Text = base.ViewModel.ErrorButtonTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ErrorButtonTitle")),
			(delegate
			{
				_reportProblemButton.Text = base.ViewModel.ReportProblemButtonTitle;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReportProblemButtonTitle")),
			(delegate
			{
				_reportProblemButton.Visibility = base.ViewModel.ReportProblemButtonVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("ReportProblemButtonVisible")),
			(delegate
			{
				ChangeErrorIcon(base.ViewModel.IsVpnError);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsVpnError")),
			(delegate
			{
				ResetErrorStateIfNeccessary(_customNameLayout, _customNameInput, base.ViewModel.CustomNameError);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CustomNameError")),
			(delegate
			{
				ResetErrorStateIfNeccessary(_customPhoneLayout, _customPhoneInput, base.ViewModel.CustomPhoneError);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CustomPhoneError")),
			(delegate
			{
				ResetDeliveryErrorStateIfNeccessary(base.ViewModel.DeliveryError);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("DeliveryError")),
			(delegate
			{
				ResetPaymentErrorStateIfNeccessary(base.ViewModel.PaymentMethodError);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PaymentMethodError")),
			(delegate
			{
				_emailLayout.SetErrorOrCorrect(base.ViewModel.IsEmailValid, base.ViewModel.EmailError);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "IsEmailValid", "EmailError" })),
			(delegate
			{
				_porchInput.ApplyText(base.ViewModel.Porch);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Porch")),
			(delegate
			{
				_floorInput.ApplyText(base.ViewModel.Floor);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Floor")),
			(delegate
			{
				_flatInput.ApplyText(base.ViewModel.Flat);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Flat")),
			(delegate
			{
				_intercomInput.ApplyText(base.ViewModel.Intercom);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Intercom")),
			(delegate
			{
				_commentInput.ApplyText(base.ViewModel.Comment);
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Comment")),
			(delegate
			{
				_toolbarTitle.Text = base.ViewModel.Title;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Title")),
			(delegate
			{
				_phoneInput.Text = base.ViewModel.Phone;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Phone")),
			(delegate
			{
				_customPhoneInput.Text = base.ViewModel.CustomPhone;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CustomPhone")),
			(delegate
			{
				_customRecipientPrivateDataWarning.Visibility = base.ViewModel.CustomRecipient.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CustomRecipient")),
			(delegate
			{
				_customNameLayout.Visibility = base.ViewModel.CustomRecipient.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CustomRecipient")),
			(delegate
			{
				_customPhoneLayout.Visibility = base.ViewModel.CustomRecipient.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("CustomRecipient")),
			(delegate
			{
				_adultTimeMessageSnackView.Visibility = (base.ViewModel.IsAdultWarningVisible && base.ViewModel.AreInCartItemsExists).ToVisibility();
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "IsAdultWarningVisible", "AreInCartItemsExists" })),
			(delegate
			{
				_adultPaymentsSnackView.Visibility = base.ViewModel.IsAdultWarningVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsAdultWarningVisible")),
			(delegate
			{
				_totalItemsPrice.SetCompoundDrawablesWithIntrinsicBounds(0, 0, GetPriceExpandOrCollapseResourceId(base.ViewModel.CanExpand, base.ViewModel.IsExpanded), 0);
			}, new global::_003C_003Ez__ReadOnlyArray<string>(new string[2] { "CanExpand", "IsExpanded" })),
			(delegate
			{
				_totalCartItemsPrice.Text = base.ViewModel.TotalInCartOrderPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalInCartOrderPrice")),
			(delegate
			{
				_totalReservedItemsPrice.Text = base.ViewModel.TotalReservedOrderPrice;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("TotalReservedOrderPrice")),
			(delegate
			{
				_adultsReservedLayout.Visibility = base.ViewModel.IsExpanded.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsExpanded")),
			(delegate
			{
				productsAdapter.DataSource = base.ViewModel.Products;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Products")),
			(delegate
			{
				reservedProductsAdapter.DataSource = base.ViewModel.AdultProducts;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("AdultProducts")),
			(delegate
			{
				paymentsAdapter.DataSource = base.ViewModel.PaymentMethodItemViewModels;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("PaymentMethodItemViewModels")),
			(delegate
			{
				_replacementsHeader.Visibility = base.ViewModel.IsReplacementesVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsReplacementesVisible")),
			(delegate
			{
				_replacementsRecycleView.Visibility = base.ViewModel.IsReplacementesVisible.ToVisibility();
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("IsReplacementesVisible")),
			(delegate
			{
				replacementsAdapter.DataSource = base.ViewModel.Replacements;
			}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Replacements"))
		})).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.BindEvents(((View)_newEmailSaveCheckBox).OnClick((Action)delegate
		{
			base.ViewModel.IsSaveNewEmail = _newEmailSaveCheckBox.Checked;
		}), _backButton.OnClick(base.ViewModel.OnBackPressed), _deliveryInfo.OnClick(base.ViewModel.OnDeliveryInfoClicked), _driveNumberLayout.OnClick(base.ViewModel.OnDriveCarChange), _driveAddCarLayout.OnClick(base.ViewModel.OnDriveCarAdd), _totalItemsPrice.OnClick(base.ViewModel.OnSwitchIsExpanded), _paymentButton.OnClick(base.ViewModel.OnPaymentClicked), _otherDeliverySlotLayout.OnClick(base.ViewModel.OnSelectDeliveryClicked), _retryButton.OnClick(base.ViewModel.Retry), _reportProblemButton.OnClick(base.ViewModel.SendLogsCommand.Trigger), ((View)_showQrButton).OnClick((Action)delegate
		{
			Show<LoyaltyCardPdf417PortraitFragment>();
		}), ((TextView)_porchInput).OnTextChanged((Action)delegate
		{
			base.ViewModel.Porch = _porchInput.Text;
		}), ((TextView)_floorInput).OnTextChanged((Action)delegate
		{
			base.ViewModel.Floor = _floorInput.Text;
		}), ((TextView)_flatInput).OnTextChanged((Action)delegate
		{
			base.ViewModel.Flat = _flatInput.Text;
		}), ((TextView)_intercomInput).OnTextChanged((Action)delegate
		{
			base.ViewModel.Intercom = _intercomInput.Text;
		}), ((TextView)_commentInput).OnTextChanged((Action)delegate
		{
			base.ViewModel.Comment = _commentInput.Text;
		}), ((TextView)_customNameInput).OnTextChanged((Action)delegate
		{
			base.ViewModel.SetCustomName(_customNameInput.Text);
		}), ((TextView)_emailInput).OnTextChanged((Action)delegate
		{
			base.ViewModel.SetEmail(_emailInput.Text);
		}), ((CompoundButton)_customRecipientToggle).OnCheckedChange((Action)delegate
		{
			base.ViewModel.CustomRecipient = _customRecipientToggle.Checked;
		}), ((CompoundButton)_hasDeliveryToDoorCheckBox).OnCheckedChange((Action)delegate
		{
			SetDeliveryToDoor(_hasDeliveryToDoorCheckBox.Checked);
		}), _emailInput.OnFocusChange(OnEmailFocusChange)).AutoDisposeOnDestroy(ViewLifecycleOwner);
		base.ViewModel.CommitErrorCommand.SafeSubscribe(delegate
		{
			UpdateErrorStates();
		}, ViewLifecycleOwner);
		base.ViewModel.OpenDeliveryInfoCommand.SafeSubscribe(delegate(DeliveryInfoPopupViewModel.Parameter p)
		{
			Show<DeliveryInfoPopupFragment, DeliveryInfoPopupViewModel.Parameter>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenStampsNoConnectCommand.SafeSubscribe(delegate(BrokerToken p)
		{
			Show<StampsLoyaltyNoConnectFragment, BrokerToken>(p);
		}, ViewLifecycleOwner);
		base.ViewModel.OpenExpressDeliveryUnavailableCommand.SafeSubscribe(delegate
		{
			OpenExpressDeliveryUnavailable();
		}, ViewLifecycleOwner);
		_emailInput.OnFocusChange(delegate(object? o, View.FocusChangeEventArgs e)
		{
			base.ViewModel.OnEmailFocus(e.HasFocus);
			_emailLayout.EndIconVisible = e.HasFocus && !string.IsNullOrEmpty(base.ViewModel.Email);
		}).AutoDispose(ViewLifecycleOwner, AndroidX.Lifecycle.Lifecycle.Event.OnDestroy);
		_emailLayout.EndIconVisible = false;
	}

	private async Task OnIsOverlayInProgressChanged(bool isOverlayInProgress)
	{
		await RequireActivity().WaitForStateAsync(AndroidX.Lifecycle.Lifecycle.State.Resumed);
		_busyPopup?.Dismiss();
		if (isOverlayInProgress)
		{
			_busyPopup = Show<BusyPopup>();
		}
	}

	private void OpenExpressDeliveryUnavailable()
	{
		FragmentManager parentFragmentManager = base.ParentFragmentManager;
		int id = base.Id;
		parentFragmentManager.PopBackStack();
		parentFragmentManager.Replace<ExpressDeliveryUnavailableFragment>(id).AddToBackStack(typeof(ExpressDeliveryUnavailableFragment).FullName).Commit();
	}

	private void OnEmailFocusChange()
	{
		if (!_emailInput.HasFocus)
		{
			_emailInput.SetHintTextColor((!base.ViewModel.IsEmailValid) ? Color.Rgb(255, 59, 47) : Color.Rgb(150, 161, 174));
			_emailLayout.SetError(base.ViewModel.EmailError, !base.ViewModel.IsEmailValid);
		}
	}

	private void ChangeErrorIcon(bool isVpnError)
	{
		_errorIcon.SetImageResource(isVpnError ? 2131231612 : 2131231058);
		_errorMessage?.SetTextColor(new Color(ContextCompat.GetColor(Application.Context, isVpnError ? 2131099872 : 2131099704)));
	}

	private void IsDeliveryToDoorAvaliable(bool isDeliveryAvaliable)
	{
		_hasDeliveryToDoorCheckBox.Visibility = isDeliveryAvaliable.ToVisibility();
	}

	private void SetDeliveryToDoor(bool isDeliveryToDoor)
	{
		base.ViewModel.DeliveryToDoor = isDeliveryToDoor;
	}

	private int GetPriceExpandOrCollapseResourceId(bool canExpand, bool isExpanded)
	{
		if (!canExpand)
		{
			return 0;
		}
		if (!isExpanded)
		{
			return 2131231611;
		}
		return 2131231610;
	}

	private void UpdateErrorStates()
	{
		SetErrorState(_customNameLayout, _nameInput, base.ViewModel.CustomNameError);
		SetErrorState(_customPhoneLayout, _phoneInput, base.ViewModel.CustomPhoneError);
		SetErrorState(_emailLayout, _emailInput, base.ViewModel.EmailError);
		_deliveryDateTimeError.Text = base.ViewModel.DeliveryError;
		_deliveryDateTimeError.Visibility = (!string.IsNullOrEmpty(base.ViewModel.DeliveryError)).ToVisibility();
		_paymentsErrorText.Text = base.ViewModel.PaymentMethodError;
		_paymentsErrorText.Visibility = (!string.IsNullOrEmpty(base.ViewModel.PaymentMethodError)).ToVisibility();
		ScrollTo(_emailLayout.ErrorEnabled ? _emailLayout : (_customNameLayout.ErrorEnabled ? _customNameLayout : (_customPhoneLayout.ErrorEnabled ? ((View)_customPhoneLayout) : ((View)((_deliveryDateTimeError.Visibility == ViewStates.Visible) ? _deliveryTimeTitle : _paymentsTitle)))));
	}

	private void SetErrorState(TextInputLayout layout, TextInputEditText editText, string error)
	{
		layout.Error = error;
		layout.ErrorEnabled = !string.IsNullOrEmpty(error);
		editText.SetHintTextColor(layout.ErrorEnabled ? Color.Rgb(255, 59, 47) : Color.Rgb(150, 161, 174));
	}

	private void ResetErrorStateIfNeccessary(TextInputLayout layout, TextInputEditText editText, string error)
	{
		if (string.IsNullOrEmpty(error))
		{
			layout.Error = error;
			layout.ErrorEnabled = !string.IsNullOrEmpty(error);
			editText.SetHintTextColor(layout.ErrorEnabled ? Color.Rgb(255, 59, 47) : Color.Rgb(150, 161, 174));
		}
	}

	private void ResetDeliveryErrorStateIfNeccessary(string error)
	{
		if (string.IsNullOrEmpty(error))
		{
			_deliveryDateTimeError.Visibility = ViewStates.Gone;
		}
	}

	private void ResetPaymentErrorStateIfNeccessary(string error)
	{
		if (string.IsNullOrEmpty(error))
		{
			_paymentsErrorText.Visibility = ViewStates.Gone;
		}
	}

	private void ScrollTo(View view)
	{
		int topRelativeTo = view.GetTopRelativeTo(_scrollView);
		_scrollView.SmoothScrollTo(0, topRelativeTo - base.Resources.DisplayMetrics.HeightPixels / 3);
	}

	private void SetButtonStyle(Button button, bool isEnabled)
	{
		button.SetBackgroundColor(new Color(ContextCompat.GetColor(RequireContext(), isEnabled ? 2131099856 : 2131100475)));
	}

	private void BindProduct(CachingViewHolder viewHolder, CheckoutProduct item, int index, CompositeDisposable disposable)
	{
		ImageView? imageView = viewHolder.FindCachedView<ImageView>(2131298011);
		FrameLayout frameLayout = viewHolder.FindCachedView<FrameLayout>(2131296500);
		viewHolder.FindCachedView<TextView>(2131296499).Text = item.Qty.ToString();
		imageView.FromUrl(item.ImageUrl);
		frameLayout.Visibility = (item.Qty > 1m).ToVisibility();
	}

	private void ScrollToDeliverySlot(int index)
	{
		if (_deliverySlotsRecyclerView.GetLayoutManager() is LinearLayoutManager linearLayoutManager && (index < linearLayoutManager.FindFirstCompletelyVisibleItemPosition() || index > linearLayoutManager.FindLastCompletelyVisibleItemPosition()))
		{
			linearLayoutManager.ScrollToPosition(index);
		}
	}

	private void TrackVisibleDeliverySlots()
	{
		if (_deliverySlotsRecyclerView?.GetLayoutManager() is LinearLayoutManager linearLayoutManager)
		{
			IReadOnlyList<CheckoutSlotItemViewModel> deliverySlots = base.ViewModel.DeliverySlots;
			int num = System.Math.Max(linearLayoutManager.FindFirstCompletelyVisibleItemPosition(), 0);
			int num2 = linearLayoutManager.FindLastCompletelyVisibleItemPosition();
			for (int i = num; i <= num2 && i < deliverySlots.Count; i++)
			{
				base.ViewModel.OnDeliverySlotDisplayed(deliverySlots[i]);
			}
		}
	}

	private void BindDeliverySlot(CachingViewHolder viewHolder, CheckoutSlotItemViewModel item, int index, CompositeDisposable disposable)
	{
		View root = viewHolder.RequireCachedView<View>(2131298383);
		TextView textView = viewHolder.RequireCachedView<TextView>(2131298387);
		View view = viewHolder.RequireCachedView<View>(2131298386);
		ImageView imageView = viewHolder.RequireCachedView<ImageView>(2131298385);
		TextView textView2 = viewHolder.RequireCachedView<TextView>(2131298384);
		textView.Text = item.DayText + "\n" + item.TimeText;
		view.Visibility = item.IsPriceVisible.ToVisibility();
		imageView.Visibility = item.HasSurge.ToVisibility();
		textView2.Text = item.PriceText;
		textView2.SetTextColor(new Color(ContextCompat.GetColor(RequireContext(), item.HasSurge ? 2131100601 : 2131100604)));
		item.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			root.Selected = item.Selected;
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposable);
		item.BindEvents(root.OnClick((Action)delegate
		{
			base.ViewModel.OnDeliverySlotClicked(item);
		})).AddTo(disposable);
	}

	private void BindPaymentMethod(CachingViewHolder viewHolder, PaymentItemViewModel item, int index, CompositeDisposable disposable)
	{
		ConstraintLayout root = viewHolder.RequireCachedView<ConstraintLayout>(2131296493);
		TextView textView = viewHolder.RequireCachedView<TextView>(2131298038);
		TextView textView2 = viewHolder.RequireCachedView<TextView>(2131298037);
		TextView textView3 = viewHolder.RequireCachedView<TextView>(2131297855);
		root.Alpha = (item.Item.IsAvailable ? 1f : 0.5f);
		textView3.Text = item.Item.Name;
		textView.Text = item.Item.QuantityText;
		ImageView imageView = viewHolder.RequireCachedView<ImageView>(2131297854);
		switch (item.Item.Code)
		{
		case PaymentCode.Online:
			imageView.SetBackgroundResource(2131231453);
			break;
		case PaymentCode.Offline:
			imageView.SetBackgroundResource(2131231452);
			break;
		}
		textView2.Text = item.Item.Price;
		item.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			UpdateView(item.Selected, root);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposable);
		item.BindEvents(((View)root).OnClick((Action)delegate
		{
			base.ViewModel.OnPaymentMethodSelected(item);
		})).AddTo(disposable);
	}

	private void BindReplacementMethod(CachingViewHolder viewHolder, ReplacementItemViewModel item, int index, CompositeDisposable disposable)
	{
		ConstraintLayout root = viewHolder.FindCachedView<ConstraintLayout>(2131296493);
		viewHolder.FindCachedView<TextView>(2131298205).Text = item.Item.Name;
		item.BindEvents(((View)root).OnClick((Action)delegate
		{
			base.ViewModel.SelectedReplacementMethod = item.Item;
		})).AddTo(disposable);
		item.BindProperties(new global::_003C_003Ez__ReadOnlySingleElementList<(Action, IReadOnlyList<string>)>((delegate
		{
			UpdateView(item.Selected, root);
		}, new global::_003C_003Ez__ReadOnlySingleElementList<string>("Selected")))).AddTo(disposable);
	}

	private void OnPhoneChanged(bool maskFilled, string extractedValue, string formattedValue)
	{
		extractedValue = PhoneHelper.GetPhoneDigits(extractedValue);
		if (_customPhoneInput.Text.Length > 18)
		{
			_customPhoneInput.Text = _customPhoneInput.Text.Remove(18);
		}
		if (_customRecipientToggle.Checked && extractedValue.Length > 0 && extractedValue[0] != '9')
		{
			extractedValue = string.Empty;
			_customPhoneInput.Text = base.ViewModel.PhoneMask.Substring(0, 4);
		}
		if (base.ViewModel.CustomPhone != extractedValue)
		{
			base.ViewModel.CustomPhone = extractedValue;
		}
	}

	private async Task GoBackAsync()
	{
		(await this.GetParentFragmentManagerAsync()).PopBackStack();
	}

	private void SetText(TextInputEditText editText, string text, bool state)
	{
		editText.Text = text;
		SetVisibility(editText, state);
	}

	private static void SetVisibility(TextInputEditText editText, bool isVisible)
	{
		((TextInputLayout)editText.Parent.Parent).EndIconVisible = isVisible;
		editText.Enabled = isVisible;
	}

	private void SetDeliveryDateTimeSelectable(bool selectable)
	{
		_fastDeliveryDateTimeLayout.Visibility = (!selectable).ToVisibility();
	}

	private async Task GoToPaymentAsync(CheckoutWebViewModel.Parameter parameter)
	{
		(await this.GetParentFragmentManagerAsync()).BeginTransaction().AddToBackStack(null).Hide(this)
			.Replace<CheckoutWebViewFragment>(this, parameter.ToNavBundle())
			.Commit();
	}

	private void OnPopToRoot()
	{
		base.ParentFragmentManager.PopBackStack(null, 1);
	}

	private void ShowSuccessfulPayment(CheckoutSuccessViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().AddToBackStack(null).Hide(this)
			.Add<CheckoutSuccessFragment>(this, parameter.ToNavBundle())
			.Commit();
	}

	private void UpdateView(bool isSelected, View root)
	{
		root.Background = ContextCompat.GetDrawable(Context, isSelected ? 2131231544 : 2131231545);
	}

	private void OpenLoyaltyPolicy(InfoPageViewModel.Parameter parameter)
	{
		base.ParentFragmentManager.BeginTransaction().Hide(this).Add<InfoPageFragment>(this, parameter.ToNavBundle())
			.AddToBackStack(null)
			.Commit();
	}

	private void OpenPointsPaymentInformer(CheckoutPointsPaymentInformerViewModel.Parameter parameter)
	{
		CheckoutPointsPaymentInformerFragment obj = base.Activity.SupportFragmentManager.FragmentFactory.Instantiate(base.Activity.ClassLoader, Java.Lang.Class.FromType(typeof(CheckoutPointsPaymentInformerFragment)).Name) as CheckoutPointsPaymentInformerFragment;
		obj.Arguments = parameter.ToNavBundle();
		obj.Show(base.Activity.SupportFragmentManager, null);
	}
}
