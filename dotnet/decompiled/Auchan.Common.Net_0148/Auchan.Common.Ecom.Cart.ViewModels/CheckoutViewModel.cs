using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Akavache.Sqlite3.Internal;
using AsyncAwaitBestPractices;
using Auchan.Common.AdminTool;
using Auchan.Common.Analytics;
using Auchan.Common.Analytics.YandexAppMetrica;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Controls.Accordion;
using Auchan.Common.Drive;
using Auchan.Common.Ecom.Cart.Errors;
using Auchan.Common.Ecom.Cart.Models;
using Auchan.Common.Ecom.DTO;
using Auchan.Common.Ecom.Drive;
using Auchan.Common.Extensions;
using Auchan.Common.Helpers;
using Auchan.Common.InfoPages;
using Auchan.Common.Logs;
using Auchan.Common.Navigation;
using Auchan.Common.Networking;
using Auchan.Common.PersonalCabinet;
using Auchan.Common.PersonalCabinet.Authorization;
using Auchan.Common.PersonalCabinet.DomainModels;
using Auchan.Common.PersonalCabinet.Interactors;
using Auchan.Common.Profile;
using CSharpFunctionalExtensions;
using Microsoft.Maui.ApplicationModel;

namespace Auchan.Common.Ecom.Cart.ViewModels;

[RequiresAuthorization]
public sealed class CheckoutViewModel : ScreenViewModel<CheckoutViewModel.Parameter>, IYandexMetricaScreenViewModel, IScreenViewModel
{
	public class Parameter : BrokeredParameter
	{
		public required bool DiscardStamps { get; init; }
	}

	public enum VisualState
	{
		Default,
		InProgress,
		Error
	}

	private enum RetryAction
	{
		GetData,
		Commit
	}

	private readonly ILogService _logService;

	private const string FieldRequiredText = "Обязательное поле";

	private const string FieldIncorrectText = "Удалите пробелы, цифры, символы";

	private const string FieldNotFilledText = "Поле не заполнено полностью";

	private const string PaymentMethodRequiredText = "Необходимо выбрать способ оплаты";

	private readonly IUserContext _userContext;

	private readonly IAdminContext _adminContext;

	private readonly IInfoMessageService _infoMessageService;

	private readonly DefaultErrorTranslator _errorTranslator;

	private readonly ICheckoutService _checkoutService;

	private readonly ICarsRepository _carsRepository;

	private readonly ProfileInteractor _profileInteractor;

	private readonly PaymentUrlHelper _paymentUrlHelper;

	private readonly AsyncValidator<(bool, string)> _emailValidator;

	private RetryAction _retryAction;

	private string _customName = string.Empty;

	private bool _isPhoneFilled;

	private string _customPhone = string.Empty;

	private bool _isNameValid;

	private string _profileEmail = string.Empty;

	private bool _customRecipient;

	private int _requestCounter;

	private int _overlayRequestCounter;

	private readonly AsyncLock _recalculateRequestLock = new AsyncLock();

	private readonly HashSet<string> _displayedSurgeSlots = new HashSet<string>();

	private bool _needsRecalculate;

	private bool _firstStart = true;

	private bool _goingToCheckout;

	private bool _expressDeliveryUnavailableShown;

	public const int InputMaxLength = 25;

	public const int CommentInputMaxLength = 200;

	[CompilerGenerated]
	private bool _003CTabBarVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsInProgress_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsInErrorState_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsOverlayInProgress_003Ek__BackingField;

	[CompilerGenerated]
	private Guid _003CApplyPointsRequestId_003Ek__BackingField;

	[CompilerGenerated]
	private Guid _003CApplyPointsRequestCompletedId_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CTitle_003Ek__BackingField;

	[CompilerGenerated]
	private Recipient? _003CRecipient_003Ek__BackingField;

	[CompilerGenerated]
	private DeliveryMethod? _003CDeliveryMethod_003Ek__BackingField;

	[CompilerGenerated]
	private AdditionalBenefit? _003CAdditionalBenefit_003Ek__BackingField;

	[CompilerGenerated]
	private ReadOnlyEquatableList<CheckoutProduct> _003CProducts_003Ek__BackingField;

	[CompilerGenerated]
	private ReadOnlyEquatableList<CheckoutProduct> _003CAdultProducts_003Ek__BackingField;

	[CompilerGenerated]
	private Auchan.Common.Ecom.Cart.Models.Summary? _003CSummary_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<AvailablePayment> _003CAvailablePayments_003Ek__BackingField;

	[CompilerGenerated]
	private SelectedDateTime? _003CSelectedDateTime_003Ek__BackingField;

	[CompilerGenerated]
	private int _003CSelectedDeliverySlotIndex_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<CheckoutDate> _003CDeliveryDates_003Ek__BackingField;

	[CompilerGenerated]
	private decimal? _003CMinSlotPrice_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<CheckoutSlotItemViewModel> _003CDeliverySlots_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<PaymentItemViewModel> _003CPaymentMethodItemViewModels_003Ek__BackingField;

	[CompilerGenerated]
	private AvailablePayment? _003CSelectedPaymentMethod_003Ek__BackingField;

	[CompilerGenerated]
	private Replacement? _003CSelectedReplacementMethod_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<ReplacementItemViewModel> _003CReplacements_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPaymentMethodError_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorTitle_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CDeliveryToDoor_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsExpanded_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPorch_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CFloor_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CFlat_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CIntercom_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CComment_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CDeliveryError_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCustomNameError_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CCustomPhoneError_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsSaveNewEmail_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsSaveNewEmailVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CDiscardStamps_003Ek__BackingField;

	[CompilerGenerated]
	private AccordionElementState _003CPromocodeState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPromocodeValue_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPromocodeInfo_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CPromocodeError_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CPromocodeChanged_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPromocodeErrorMessage_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPromocodeErrorLink_003Ek__BackingField;

	[CompilerGenerated]
	private AccordionElementState _003CPointsPaymentState_003Ek__BackingField;

	[CompilerGenerated]
	private long _003CPointsPaymentValue_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CEmail_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CEmailError_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsEmailValid_003Ek__BackingField;

	[CompilerGenerated]
	private UICommand _003CSendLogsCommand_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CReportProblemButtonVisible_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CIsVpnError_003Ek__BackingField;

	protected override string ScreenName => "Checkout";

	public override bool TabBarVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CTabBarVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		protected set
		{
			if (_003CTabBarVisible_003Ek__BackingField != value)
			{
				_003CTabBarVisible_003Ek__BackingField = value;
				RaisePropertyChanged("TabBarVisible");
			}
		}
	}

	public bool IsInProgress
	{
		[CompilerGenerated]
		get
		{
			return _003CIsInProgress_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsInProgress_003Ek__BackingField != value)
			{
				_003CIsInProgress_003Ek__BackingField = value;
				RaisePropertyChanged("State");
				RaisePropertyChanged("PaymentButtonEnabled");
				RaisePropertyChanged("IsInProgress");
			}
		}
	}

	public bool IsInErrorState
	{
		[CompilerGenerated]
		get
		{
			return _003CIsInErrorState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsInErrorState_003Ek__BackingField != value)
			{
				_003CIsInErrorState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
				RaisePropertyChanged("IsInErrorState");
			}
		}
	}

	public bool IsOverlayInProgress
	{
		[CompilerGenerated]
		get
		{
			return _003CIsOverlayInProgress_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsOverlayInProgress_003Ek__BackingField != value)
			{
				_003CIsOverlayInProgress_003Ek__BackingField = value;
				RaisePropertyChanged("State");
				RaisePropertyChanged("PaymentButtonEnabled");
				RaisePropertyChanged("IsOverlayInProgress");
			}
		}
	}

	public VisualState State
	{
		get
		{
			if (!IsInProgress)
			{
				if (!IsOverlayInProgress)
				{
					if (!IsInErrorState)
					{
						return VisualState.Default;
					}
					return VisualState.Error;
				}
				return VisualState.Default;
			}
			return VisualState.InProgress;
		}
	}

	private Guid ApplyPointsRequestId
	{
		[CompilerGenerated]
		get
		{
			return _003CApplyPointsRequestId_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!(_003CApplyPointsRequestId_003Ek__BackingField == value))
			{
				_003CApplyPointsRequestId_003Ek__BackingField = value;
				RaisePropertyChanged("IsPointsRequestPending");
				RaisePropertyChanged("PaymentButtonEnabled");
				RaisePropertyChanged("ApplyPointsRequestId");
			}
		}
	}

	private Guid ApplyPointsRequestCompletedId
	{
		[CompilerGenerated]
		get
		{
			return _003CApplyPointsRequestCompletedId_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!(_003CApplyPointsRequestCompletedId_003Ek__BackingField == value))
			{
				_003CApplyPointsRequestCompletedId_003Ek__BackingField = value;
				RaisePropertyChanged("IsPointsRequestPending");
				RaisePropertyChanged("PaymentButtonEnabled");
				RaisePropertyChanged("ApplyPointsRequestCompletedId");
			}
		}
	}

	private bool IsPointsRequestPending => ApplyPointsRequestId != ApplyPointsRequestCompletedId;

	public string Title
	{
		[CompilerGenerated]
		get
		{
			return _003CTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitle_003Ek__BackingField = value;
				RaisePropertyChanged("Title");
			}
		}
	} = "Оформление заказа";

	public string DeliveryHeaderText
	{
		get
		{
			switch (DeliveryMethod?.Method)
			{
			case CheckoutReceiveMethod.Delivery:
			case CheckoutReceiveMethod.ExpressDelivery:
				return "Адрес Доставки";
			case CheckoutReceiveMethod.BySelf:
				return "Магазин для самовывоза";
			case CheckoutReceiveMethod.Drive:
				return "Информация об Авто";
			default:
				return "";
			}
		}
	}

	public bool IsDriveInfoViewVisible
	{
		get
		{
			DeliveryMethod? deliveryMethod = DeliveryMethod;
			if ((object)deliveryMethod == null)
			{
				return false;
			}
			return deliveryMethod.Method == CheckoutReceiveMethod.Drive;
		}
	}

	public string DriveZoneInfo => "Заезжайте на парковку в зону выдачи \"АШАН АВТО\" согласно схеме, указанной в вашем заказе";

	public string AddressPlaceholder => GetByDeliveryMethod(DeliveryMethod, (DeliveryMethod d) => "Улица, дом", (DeliveryMethod d) => "Адрес магазина", "");

	public string PorchPlaceholder => "Подъезд";

	public string FloorPlaceholder => "Этаж";

	public string FlatPlaceholder => "Квартира/Офис";

	public string IntercomPlaceholder => "Код домофона";

	public string CommentPlaceholder => "Комментарий к заказу";

	public string DriveHeaderText => "Автомобиль";

	public string DriveCarAddText => "Добавить автомобиль";

	public string DateHeaderText => GetByDeliveryMethod(DeliveryMethod, (DeliveryMethod d) => "Дата и время доставки", (DeliveryMethod d) => "Когда можно забрать", "");

	public string ReceiverHeaderText => "Информация о получателе";

	public string CustomReceiverText => "Получать заказ буду не я";

	public LinkedText CustomReceiverPersDataWarningText => new LinkedText("Отмечая пункт, подтверждаю, что проинформировал(а) получателя заказа о передаче его(её) персональных данных компании АШАН Ритейл Россия и партнёрам. Данные передаются исключительно в {0} исполнения заказа", "целях", ShowPrivacyPolicy);

	public string NamePlaceholder => "Имя";

	public string PhonePlaceholder => "Телефон";

	public string CustomNamePlaceholder => "Имя *";

	public string CustomPhonePlaceholder => "Телефон *";

	public string EmailPlaceholder => "E-mail *";

	public string PaymentHeaderText => "Способ оплаты";

	public string PromocodeButtonOk => "ОК";

	public string PromocodeButtonCancel => "Отмена";

	public string ProductsTitle => "Товары";

	public string ReservedProductsTitle => "Резерв в магазине";

	public Recipient? Recipient
	{
		[CompilerGenerated]
		get
		{
			return _003CRecipient_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!(_003CRecipient_003Ek__BackingField == value))
			{
				Recipient recipient = Recipient;
				_003CRecipient_003Ek__BackingField = value;
				RaisePropertyChanged("Name");
				RaisePropertyChanged("PaymentButtonEnabled");
				RaisePropertyChanged("Phone");
				Recipient recipient2 = Recipient;
				OnRecipientChanged(recipient, recipient2);
				RaisePropertyChanged("Recipient");
			}
		}
	}

	public DeliveryMethod? DeliveryMethod
	{
		[CompilerGenerated]
		get
		{
			return _003CDeliveryMethod_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!(_003CDeliveryMethod_003Ek__BackingField == value))
			{
				DeliveryMethod deliveryMethod = DeliveryMethod;
				_003CDeliveryMethod_003Ek__BackingField = value;
				RaisePropertyChanged("DeliveryHeaderText");
				RaisePropertyChanged("IsDriveInfoViewVisible");
				RaisePropertyChanged("AddressPlaceholder");
				RaisePropertyChanged("DateHeaderText");
				RaisePropertyChanged("PriceText");
				RaisePropertyChanged("HasDeliveryToDoor");
				RaisePropertyChanged("Street");
				RaisePropertyChanged("DriveCarNumber");
				RaisePropertyChanged("DriveCarDescription");
				RaisePropertyChanged("IsDriveRecevingmethod");
				RaisePropertyChanged("IsCarAvailable");
				RaisePropertyChanged("IsCarSelectionAvailable");
				RaisePropertyChanged("SelectedDeliveryDate");
				RaisePropertyChanged("IsDeliveryValid");
				RaisePropertyChanged("PaymentButtonEnabled");
				RaisePropertyChanged("IsDeliveryDateTimeSelectable");
				RaisePropertyChanged("IsDeliverySlotsVisible");
				RaisePropertyChanged("IsOtherDeliverySlotVisible");
				RaisePropertyChanged("DeliveryPrice");
				RaisePropertyChanged("ReceivingMethod");
				DeliveryMethod deliveryMethod2 = DeliveryMethod;
				OnDeliveryMethodChanged(deliveryMethod, deliveryMethod2);
				RaisePropertyChanged("DeliveryMethod");
			}
		}
	}

	public AdditionalBenefit? AdditionalBenefit
	{
		[CompilerGenerated]
		get
		{
			return _003CAdditionalBenefit_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!(_003CAdditionalBenefit_003Ek__BackingField == value))
			{
				AdditionalBenefit additionalBenefit = AdditionalBenefit;
				_003CAdditionalBenefit_003Ek__BackingField = value;
				RaisePropertyChanged("OnlyOneMechanicInformerVisible");
				RaisePropertyChanged("OnlyOneMechanicInformer");
				RaisePropertyChanged("PromocodeEntered");
				RaisePropertyChanged("PointsPaymentMaxValue");
				RaisePropertyChanged("PointsAvailableText");
				RaisePropertyChanged("PointsBurnableText");
				RaisePropertyChanged("PointsPaymentAdultText");
				RaisePropertyChanged("NoPointsText");
				AdditionalBenefit additionalBenefit2 = AdditionalBenefit;
				OnAdditionalBenefitChanged(additionalBenefit, additionalBenefit2);
				RaisePropertyChanged("AdditionalBenefit");
			}
		}
	}

	public ReadOnlyEquatableList<CheckoutProduct> Products
	{
		[CompilerGenerated]
		get
		{
			return _003CProducts_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CProducts_003Ek__BackingField == value))
			{
				_003CProducts_003Ek__BackingField = value;
				RaisePropertyChanged("AreInCartItemsExists");
				RaisePropertyChanged("CanExpand");
				RaisePropertyChanged("TotalItemsPriceText");
				RaisePropertyChanged("Products");
			}
		}
	} = new ReadOnlyEquatableList<CheckoutProduct>();

	public ReadOnlyEquatableList<CheckoutProduct> AdultProducts
	{
		[CompilerGenerated]
		get
		{
			return _003CAdultProducts_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CAdultProducts_003Ek__BackingField == value))
			{
				_003CAdultProducts_003Ek__BackingField = value;
				RaisePropertyChanged("IsAdultWarningVisible");
				RaisePropertyChanged("AreReservedItemsExists");
				RaisePropertyChanged("CanExpand");
				RaisePropertyChanged("AdultProducts");
			}
		}
	} = new ReadOnlyEquatableList<CheckoutProduct>();

	public Auchan.Common.Ecom.Cart.Models.Summary? Summary
	{
		[CompilerGenerated]
		get
		{
			return _003CSummary_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!(_003CSummary_003Ek__BackingField == value))
			{
				_003CSummary_003Ek__BackingField = value;
				RaisePropertyChanged("TotalInCartOrderPrice");
				RaisePropertyChanged("TotalReservedOrderPrice");
				RaisePropertyChanged("TotalItemsPriceText");
				RaisePropertyChanged("TotalItemsPrice");
				RaisePropertyChanged("HasDiscount");
				RaisePropertyChanged("TotalDiscount");
				RaisePropertyChanged("HasPromocodeDiscount");
				RaisePropertyChanged("PromocodeDiscount");
				RaisePropertyChanged("IsFreeDelivery");
				RaisePropertyChanged("IsDeliveryInfoIconVisible");
				RaisePropertyChanged("DeliveryPrice");
				RaisePropertyChanged("TotalOrderPrice");
				RaisePropertyChanged("TotalPrice");
				RaisePropertyChanged("IsUsedPointsVisible");
				RaisePropertyChanged("UsedPoints");
				RaisePropertyChanged("StampsWithdrawValue");
				RaisePropertyChanged("PaymentButtonEnabled");
				RaisePropertyChanged("PickingPrice");
				RaisePropertyChanged("PickingPriceText");
				RaisePropertyChanged("PickingPriceVisible");
				RaisePropertyChanged("SurgeAmount");
				RaisePropertyChanged("SurgeAmountText");
				RaisePropertyChanged("SurgeAmountVisible");
				RaisePropertyChanged("Summary");
			}
		}
	}

	public IReadOnlyList<AvailablePayment> AvailablePayments
	{
		[CompilerGenerated]
		get
		{
			return _003CAvailablePayments_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CAvailablePayments_003Ek__BackingField, value))
			{
				IReadOnlyList<AvailablePayment> availablePayments = AvailablePayments;
				_003CAvailablePayments_003Ek__BackingField = value;
				IReadOnlyList<AvailablePayment> availablePayments2 = AvailablePayments;
				OnAvailablePaymentsChanged(availablePayments, availablePayments2);
				RaisePropertyChanged("AvailablePayments");
			}
		}
	} = Array.Empty<AvailablePayment>();

	public SelectedDateTime? SelectedDateTime
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedDateTime_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CSelectedDateTime_003Ek__BackingField, value))
			{
				SelectedDateTime selectedDateTime = SelectedDateTime;
				_003CSelectedDateTime_003Ek__BackingField = value;
				RaisePropertyChanged("IsSurgeInformerVisible");
				RaisePropertyChanged("SelectedDeliveryDate");
				RaisePropertyChanged("IsDeliveryValid");
				RaisePropertyChanged("PaymentButtonEnabled");
				SelectedDateTime selectedDateTime2 = SelectedDateTime;
				OnSelectedDateTimeChanged(selectedDateTime, selectedDateTime2);
				RaisePropertyChanged("SelectedDateTime");
			}
		}
	}

	public int SelectedDeliverySlotIndex
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedDeliverySlotIndex_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CSelectedDeliverySlotIndex_003Ek__BackingField != value)
			{
				_003CSelectedDeliverySlotIndex_003Ek__BackingField = value;
				RaisePropertyChanged("SelectedDeliverySlotIndex");
			}
		}
	}

	public IReadOnlyList<CheckoutDate> DeliveryDates
	{
		[CompilerGenerated]
		get
		{
			return _003CDeliveryDates_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CDeliveryDates_003Ek__BackingField, value))
			{
				IReadOnlyList<CheckoutDate> deliveryDates = DeliveryDates;
				_003CDeliveryDates_003Ek__BackingField = value;
				RaisePropertyChanged("IsOtherDeliverySlotVisible");
				IReadOnlyList<CheckoutDate> deliveryDates2 = DeliveryDates;
				OnDeliveryDatesChanged(deliveryDates, deliveryDates2);
				RaisePropertyChanged("DeliveryDates");
			}
		}
	} = Array.Empty<CheckoutDate>();

	public decimal? MinSlotPrice
	{
		[CompilerGenerated]
		get
		{
			return _003CMinSlotPrice_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!Nullable.Equals(_003CMinSlotPrice_003Ek__BackingField, value))
			{
				_003CMinSlotPrice_003Ek__BackingField = value;
				RaisePropertyChanged("IsOtherDeliverySlotPriceVisible");
				RaisePropertyChanged("OtherDeliverySlotPriceText");
				RaisePropertyChanged("MinSlotPrice");
			}
		}
	}

	public IReadOnlyList<CheckoutSlotItemViewModel> DeliverySlots
	{
		[CompilerGenerated]
		get
		{
			return _003CDeliverySlots_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CDeliverySlots_003Ek__BackingField, value))
			{
				_003CDeliverySlots_003Ek__BackingField = value;
				RaisePropertyChanged("IsDeliverySlotsVisible");
				RaisePropertyChanged("DeliverySlots");
			}
		}
	} = Array.Empty<CheckoutSlotItemViewModel>();

	public bool IsDeliverySlotsVisible
	{
		get
		{
			if (IsDeliveryDateTimeSelectable)
			{
				return DeliverySlots.Count > 0;
			}
			return false;
		}
	}

	public string OtherDeliverySlotText => "Выбрать другую дату и время";

	public bool IsOtherDeliverySlotVisible
	{
		get
		{
			if (IsDeliveryDateTimeSelectable)
			{
				return DeliveryDates.Count > 0;
			}
			return false;
		}
	}

	public bool IsOtherDeliverySlotPriceVisible => CheckoutSlotPrice.IsVisible(MinSlotPrice);

	public string OtherDeliverySlotPriceText => $"от {MinSlotPrice:C0}";

	public bool IsSurgeInformerVisible => SelectedDateTime?.Time.HasSurge ?? false;

	public string SurgeInformerText => "В выбранное время много заказов — цена доставки выше, чем обычно. В другое время доставка может быть дешевле";

	private bool StampsEnabled => _adminContext.StampsConfig?.ShowStampsToCurrentUser == true;

	public LinkedText LoyaltyInformerText
	{
		get
		{
			if (!StampsEnabled)
			{
				return PointsInformerText;
			}
			return PointsAndStampsInformerText;
		}
	}

	private LinkedText PointsInformerText => new LinkedText("Вам будут начислены баллы согласно правилам {0}. Нажимая на \"Оплатить\", вы принимаете условия {1}", new string[2] { "Программы лояльности", "Публичной оферты" }, new Action[2] { ShowLoyaltyRules, ShowOfferta });

	private LinkedText PointsAndStampsInformerText => new LinkedText("Вам будут начислены баллы и марки согласно правилам {0}. Нажимая на \"Оплатить\", вы принимаете условия {1}", new string[2] { "Программы лояльности", "Публичной оферты" }, new Action[2] { ShowLoyaltyRules, ShowOfferta });

	public string EmailBillInfoText => "На указанный email придет квитанция об оплате";

	public string SaveNewEmailText => "Сохранить новый e-mail";

	public string PromocodeEditTextHint => "Укажите промокод";

	public IReadOnlyList<PaymentItemViewModel> PaymentMethodItemViewModels
	{
		[CompilerGenerated]
		get
		{
			return _003CPaymentMethodItemViewModels_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CPaymentMethodItemViewModels_003Ek__BackingField, value))
			{
				_003CPaymentMethodItemViewModels_003Ek__BackingField = value;
				RaisePropertyChanged("PaymentMethodItemViewModels");
			}
		}
	} = Array.Empty<PaymentItemViewModel>();

	public AvailablePayment? SelectedPaymentMethod
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedPaymentMethod_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CSelectedPaymentMethod_003Ek__BackingField == value))
			{
				_003CSelectedPaymentMethod_003Ek__BackingField = value;
				RaisePropertyChanged("IsPaymentMethodSelected");
				RaisePropertyChanged("PaymentButtonEnabled");
				RaisePropertyChanged("PaymentButtonText");
				RaisePropertyChanged("SelectedPaymentMethod");
			}
		}
	}

	public string ReplacementsHeader => "Если товара нет в наличии";

	public bool IsReplacementesVisible => Replacements.Count > 0;

	public Replacement? SelectedReplacementMethod
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedReplacementMethod_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!(_003CSelectedReplacementMethod_003Ek__BackingField == value))
			{
				Replacement selectedReplacementMethod = SelectedReplacementMethod;
				_003CSelectedReplacementMethod_003Ek__BackingField = value;
				Replacement selectedReplacementMethod2 = SelectedReplacementMethod;
				OnSelectedReplacementChanged(selectedReplacementMethod, selectedReplacementMethod2);
				RaisePropertyChanged("SelectedReplacementMethod");
			}
		}
	}

	public IReadOnlyList<ReplacementItemViewModel> Replacements
	{
		[CompilerGenerated]
		get
		{
			return _003CReplacements_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CReplacements_003Ek__BackingField, value))
			{
				_003CReplacements_003Ek__BackingField = value;
				RaisePropertyChanged("IsReplacementesVisible");
				RaisePropertyChanged("Replacements");
			}
		}
	} = Array.Empty<ReplacementItemViewModel>();

	public string PaymentMethodError
	{
		[CompilerGenerated]
		get
		{
			return _003CPaymentMethodError_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CPaymentMethodError_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CPaymentMethodError_003Ek__BackingField = value;
				RaisePropertyChanged("PaymentMethodError");
			}
		}
	} = string.Empty;

	public bool IsPaymentMethodSelected => SelectedPaymentMethod != null;

	public string TotalHeaderText => "Итого";

	public string PriceText => DeliveryMethod?.Method switch
	{
		CheckoutReceiveMethod.ExpressDelivery => "Быстрая доставка", 
		CheckoutReceiveMethod.Delivery => "Доставка", 
		CheckoutReceiveMethod.BySelf => "Самовывоз", 
		CheckoutReceiveMethod.Drive => "Авто", 
		_ => "", 
	};

	public string TotalOrderPriceText => "Сумма заказа";

	public string TotalPriceText => "Общая стоимость";

	public string ErrorTitle
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorTitle_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorTitle_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorTitle_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorTitle");
			}
		}
	} = "Упс! Что-то пошло не так.";

	public string ErrorMessage
	{
		[CompilerGenerated]
		get
		{
			return _003CErrorMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CErrorMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CErrorMessage_003Ek__BackingField = value;
				RaisePropertyChanged("ErrorMessage");
			}
		}
	} = "Небольшие технические проблемы,\nпопробуйте обновить экран.";

	public string ErrorButtonTitle => "Повторить";

	public string TotalInCartOrderPrice => $"{Summary?.NonAdultBasketCost ?? 0m:C2}";

	public string TotalReservedOrderPrice => $"{(Summary?.AdultBasketCost).GetValueOrDefault():C2}";

	public bool IsAdultWarningVisible => AdultProducts.Any();

	public string ReservedWarningText => "Зарезервированные товары необходимо оплатить внутри магазина на кассе пункта выдачи";

	public string DeliveryToDoorText => "Оставить у двери";

	public string TotalInCartTitle => "Товары в заказе";

	public string TotalReservedTitle => "Резерв в магазине";

	public bool CanExpand
	{
		get
		{
			if (AreReservedItemsExists)
			{
				return AreInCartItemsExists;
			}
			return false;
		}
	}

	public bool HasDeliveryToDoor => DeliveryMethod?.ToDoor ?? false;

	public bool DeliveryToDoor
	{
		[CompilerGenerated]
		get
		{
			return _003CDeliveryToDoor_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CDeliveryToDoor_003Ek__BackingField != value)
			{
				_003CDeliveryToDoor_003Ek__BackingField = value;
				RaisePropertyChanged("DeliveryToDoor");
			}
		}
	}

	public bool AreReservedItemsExists => AdultProducts.Any();

	public bool AreInCartItemsExists => Products.Any();

	public bool IsExpanded
	{
		[CompilerGenerated]
		get
		{
			return _003CIsExpanded_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsExpanded_003Ek__BackingField != value)
			{
				_003CIsExpanded_003Ek__BackingField = value;
				RaisePropertyChanged("IsExpanded");
			}
		}
	}

	public string Street => GetByDeliveryMethod<string>(DeliveryMethod, (DeliveryMethod m) => m.Address?.AddressText, (DeliveryMethod m) => m.Shop?.Address, "");

	public string Porch
	{
		[CompilerGenerated]
		get
		{
			return _003CPorch_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CPorch_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CPorch_003Ek__BackingField = value;
				RaisePropertyChanged("Porch");
			}
		}
	} = string.Empty;

	public string Floor
	{
		[CompilerGenerated]
		get
		{
			return _003CFloor_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CFloor_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CFloor_003Ek__BackingField = value;
				RaisePropertyChanged("Floor");
			}
		}
	} = string.Empty;

	public string Flat
	{
		[CompilerGenerated]
		get
		{
			return _003CFlat_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CFlat_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CFlat_003Ek__BackingField = value;
				RaisePropertyChanged("Flat");
			}
		}
	} = string.Empty;

	public string Intercom
	{
		[CompilerGenerated]
		get
		{
			return _003CIntercom_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CIntercom_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CIntercom_003Ek__BackingField = value;
				RaisePropertyChanged("Intercom");
			}
		}
	} = string.Empty;

	public string? Comment
	{
		[CompilerGenerated]
		get
		{
			return _003CComment_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CComment_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CComment_003Ek__BackingField = value;
				RaisePropertyChanged("Comment");
			}
		}
	}

	public string DriveCarNumber => GetByDriveMethod(DeliveryMethod, (CheckoutCar cd) => cd.Number ?? "", "");

	public string DriveCarDescription => GetByDriveMethod(DeliveryMethod, (CheckoutCar cd) => (cd.Color == null || cd.Brand == null) ? "" : (cd.Color + " " + cd.Brand), "");

	public bool IsDriveRecevingmethod
	{
		get
		{
			DeliveryMethod? deliveryMethod = DeliveryMethod;
			if ((object)deliveryMethod == null)
			{
				return false;
			}
			return deliveryMethod.Method == CheckoutReceiveMethod.Drive;
		}
	}

	public bool IsCarAvailable
	{
		get
		{
			DeliveryMethod? deliveryMethod = DeliveryMethod;
			if ((object)deliveryMethod != null && deliveryMethod.Method == CheckoutReceiveMethod.Drive)
			{
				return DeliveryMethod?.Car != null;
			}
			return false;
		}
	}

	public bool IsCarSelectionAvailable
	{
		get
		{
			DeliveryMethod? deliveryMethod = DeliveryMethod;
			if ((object)deliveryMethod != null && deliveryMethod.Method == CheckoutReceiveMethod.Drive)
			{
				return DeliveryMethod?.Car == null;
			}
			return false;
		}
	}

	public string SelectedDeliveryDate => DeliveryMethod?.DeliveryTimeHint ?? SelectedDateTime?.Time.Name ?? "";

	public bool IsDeliveryDateTimeSelectable
	{
		get
		{
			if (!(DeliveryMethod == null))
			{
				if (DeliveryMethod.Method == CheckoutReceiveMethod.ExpressDelivery)
				{
					return string.IsNullOrWhiteSpace(DeliveryMethod.DeliveryTimeHint);
				}
				return true;
			}
			return false;
		}
	}

	public string DeliveryError
	{
		[CompilerGenerated]
		get
		{
			return _003CDeliveryError_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CDeliveryError_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDeliveryError_003Ek__BackingField = value;
				RaisePropertyChanged("DeliveryError");
			}
		}
	} = string.Empty;

	public bool IsDeliveryValid
	{
		get
		{
			bool flag = (IsDeliveryDateTimeSelectable ? (SelectedDateTime != null) : (!string.IsNullOrWhiteSpace(SelectedDeliveryDate)));
			DeliveryError = (flag ? string.Empty : "Обязательное поле");
			return flag;
		}
	}

	public bool CustomRecipient
	{
		get
		{
			return _customRecipient;
		}
		set
		{
			if (_customRecipient != value)
			{
				_customRecipient = value;
				RaisePropertyChanged("CustomRecipient");
				if (_customRecipient)
				{
					IsSaveNewEmailVisible = false;
				}
				RaisePropertyChanged("IsNameValid");
				RaisePropertyChanged("PaymentButtonEnabled");
			}
		}
	}

	public string Name => Recipient?.Name ?? "";

	public string CustomName
	{
		get
		{
			return _customName;
		}
		set
		{
			if (!string.Equals(_customName, value, StringComparison.Ordinal))
			{
				SetCustomName(value);
				RaisePropertyChanged("CustomName");
			}
		}
	}

	public string CustomNameError
	{
		[CompilerGenerated]
		get
		{
			return _003CCustomNameError_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCustomNameError_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCustomNameError_003Ek__BackingField = value;
				RaisePropertyChanged("CustomNameError");
			}
		}
	} = string.Empty;

	public bool IsNameValid
	{
		get
		{
			return _isNameValid;
		}
		set
		{
			if (_isNameValid != value)
			{
				_isNameValid = value;
				RaisePropertyChanged("IsNameValid");
				RaisePropertyChanged("PaymentButtonEnabled");
			}
		}
	}

	public string Phone => Recipient?.Phone ?? "";

	public string CustomPhone
	{
		get
		{
			return _customPhone;
		}
		set
		{
			if (!string.Equals(_customPhone, value, StringComparison.Ordinal))
			{
				_customPhone = value;
				RaisePropertyChanged("CustomPhone");
				CustomPhoneError = (string.IsNullOrWhiteSpace(value) ? "Обязательное поле" : ((!IsPhoneFilled) ? "Поле не заполнено полностью" : string.Empty));
				RaisePropertyChanged("IsPhoneFilled");
				RaisePropertyChanged("PaymentButtonEnabled");
			}
		}
	}

	public string PhoneMask => "+7 ([000]) [000]-[00]-[00]";

	public string CustomPhoneError
	{
		[CompilerGenerated]
		get
		{
			return _003CCustomPhoneError_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CCustomPhoneError_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CCustomPhoneError_003Ek__BackingField = value;
				RaisePropertyChanged("CustomPhoneError");
			}
		}
	} = string.Empty;

	public bool IsPhoneFilled
	{
		get
		{
			return _isPhoneFilled;
		}
		set
		{
			if (_isPhoneFilled != value)
			{
				_isPhoneFilled = value;
				RaisePropertyChanged("IsPhoneFilled");
				CustomPhoneError = (string.IsNullOrWhiteSpace(_customPhone) ? "Обязательное поле" : ((!value) ? "Поле не заполнено полностью" : string.Empty));
				RaisePropertyChanged("PaymentButtonEnabled");
			}
		}
	}

	public string TotalItemsPriceText
	{
		get
		{
			if (!(Summary != null))
			{
				return "";
			}
			if (Products.Any())
			{
				return $"Товары ({Summary.ItemsCount})";
			}
			return $"Резерв в магазине ({Summary.ItemsCount})";
		}
	}

	public string TotalItemsPrice => $"{Summary?.BasketCost ?? 0m:C2}";

	public bool HasDiscount
	{
		get
		{
			Auchan.Common.Ecom.Cart.Models.Summary? summary = Summary;
			if ((object)summary == null)
			{
				return false;
			}
			decimal? economy = summary.Economy;
			return (economy.GetValueOrDefault() > default(decimal)) & economy.HasValue;
		}
	}

	public string TotalDiscountTitle => "Экономия";

	public string TotalDiscount => $"{(Summary?.Economy).GetValueOrDefault():C2}";

	public bool HasPromocodeDiscount
	{
		get
		{
			Auchan.Common.Ecom.Cart.Models.Summary? summary = Summary;
			if ((object)summary == null)
			{
				return false;
			}
			decimal? promocodeDiscount = summary.PromocodeDiscount;
			return (promocodeDiscount.GetValueOrDefault() > default(decimal)) & promocodeDiscount.HasValue;
		}
	}

	public string PromocodeDiscountTitle => "Промокод";

	public string PromocodeDiscount => $"-{(Summary?.PromocodeDiscount).GetValueOrDefault():C2}";

	public bool IsDeliveryInfoIconVisible => !IsFreeDelivery;

	public bool IsFreeDelivery
	{
		get
		{
			Auchan.Common.Ecom.Cart.Models.Summary? summary = Summary;
			if ((object)summary == null)
			{
				return false;
			}
			return summary.TotalDeliveryPrice == default(decimal);
		}
	}

	public string DeliveryPrice
	{
		get
		{
			if (IsFreeDelivery)
			{
				DeliveryMethod? deliveryMethod = DeliveryMethod;
				if ((object)deliveryMethod == null || !deliveryMethod.Method.IsDelivery())
				{
					return "Бесплатно";
				}
			}
			return $"{Summary?.TotalDeliveryPrice ?? 0m:C0}";
		}
	}

	public string TotalOrderPrice => $"{Summary?.BasketPrice ?? 0m:C}";

	public string TotalPrice => $"{Summary?.TotalPrice ?? 0m:C}";

	public string PaymentButtonText
	{
		get
		{
			AvailablePayment? selectedPaymentMethod = SelectedPaymentMethod;
			if ((object)selectedPaymentMethod == null || selectedPaymentMethod.Code != PaymentCode.Online)
			{
				return "Оформить заказ";
			}
			return $"Оплатить {SelectedPaymentMethod.Sum:C}";
		}
	}

	public bool IsSaveNewEmail
	{
		[CompilerGenerated]
		get
		{
			return _003CIsSaveNewEmail_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsSaveNewEmail_003Ek__BackingField != value)
			{
				_003CIsSaveNewEmail_003Ek__BackingField = value;
				RaisePropertyChanged("IsSaveNewEmail");
			}
		}
	}

	public bool IsSaveNewEmailVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CIsSaveNewEmailVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsSaveNewEmailVisible_003Ek__BackingField != value)
			{
				_003CIsSaveNewEmailVisible_003Ek__BackingField = value;
				RaisePropertyChanged("IsSaveNewEmailVisible");
			}
		}
	}

	public bool DiscardStamps
	{
		[CompilerGenerated]
		get
		{
			return _003CDiscardStamps_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CDiscardStamps_003Ek__BackingField != value)
			{
				_003CDiscardStamps_003Ek__BackingField = value;
				RaisePropertyChanged("BonusesEnabled");
				RaisePropertyChanged("DiscardStamps");
			}
		}
	}

	public bool BonusesEnabled
	{
		get
		{
			if (!DiscardStamps)
			{
				if (!PromocodeState.IsEnabled())
				{
					return PointsPaymentState.IsEnabled();
				}
				return true;
			}
			return false;
		}
	}

	public string BonusesTitle => "Дополнительная выгода";

	public bool OnlyOneMechanicInformerVisible => !string.IsNullOrEmpty(AdditionalBenefit?.Informers?.TwoMechanicInformer);

	public LinkedText OnlyOneMechanicInformer => ExtractLinkedTextBonuses(AdditionalBenefit?.Informers?.TwoMechanicInformer);

	public AccordionElementState PromocodeState
	{
		[CompilerGenerated]
		get
		{
			return _003CPromocodeState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CPromocodeState_003Ek__BackingField != value)
			{
				AccordionElementState promocodeState = PromocodeState;
				_003CPromocodeState_003Ek__BackingField = value;
				RaisePropertyChanged("BonusesEnabled");
				RaisePropertyChanged("PromocodeEntered");
				AccordionElementState promocodeState2 = PromocodeState;
				OnPromocodeStateChanged(promocodeState, promocodeState2);
				RaisePropertyChanged("PromocodeState");
			}
		}
	} = AccordionElementState.Gone;

	public string PromocodeValue
	{
		[CompilerGenerated]
		get
		{
			return _003CPromocodeValue_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CPromocodeValue_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				string promocodeValue = PromocodeValue;
				_003CPromocodeValue_003Ek__BackingField = value;
				RaisePropertyChanged("PromocodeEntered");
				string promocodeValue2 = PromocodeValue;
				OnPromocodeValueChanged(promocodeValue, promocodeValue2);
				RaisePropertyChanged("PromocodeValue");
			}
		}
	} = string.Empty;

	public string PromocodeInfo
	{
		[CompilerGenerated]
		get
		{
			return _003CPromocodeInfo_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CPromocodeInfo_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CPromocodeInfo_003Ek__BackingField = value;
				RaisePropertyChanged("PromocodeInfo");
			}
		}
	} = string.Empty;

	public bool PromocodeEntered
	{
		get
		{
			if (!PromocodeState.IsEnabled() || PromocodeChanged || string.IsNullOrEmpty(PromocodeValue) || !(AdditionalBenefit?.PromocodeCondition != null))
			{
				return false;
			}
			return AdditionalBenefit.PromocodeCondition.IsSuccess;
		}
	}

	public bool PromocodeError
	{
		[CompilerGenerated]
		get
		{
			return _003CPromocodeError_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CPromocodeError_003Ek__BackingField != value)
			{
				_003CPromocodeError_003Ek__BackingField = value;
				RaisePropertyChanged("PromocodeError");
			}
		}
	}

	public bool PromocodeChanged
	{
		[CompilerGenerated]
		get
		{
			return _003CPromocodeChanged_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CPromocodeChanged_003Ek__BackingField != value)
			{
				_003CPromocodeChanged_003Ek__BackingField = value;
				RaisePropertyChanged("PromocodeEntered");
				RaisePropertyChanged("PromocodeChanged");
			}
		}
	}

	public string PromocodeErrorMessage
	{
		[CompilerGenerated]
		get
		{
			return _003CPromocodeErrorMessage_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CPromocodeErrorMessage_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CPromocodeErrorMessage_003Ek__BackingField = value;
				RaisePropertyChanged("PromocodeErrorMessage");
			}
		}
	} = string.Empty;

	public string PromocodeErrorLink
	{
		[CompilerGenerated]
		get
		{
			return _003CPromocodeErrorLink_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CPromocodeErrorLink_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CPromocodeErrorLink_003Ek__BackingField = value;
				RaisePropertyChanged("PromocodeErrorLink");
			}
		}
	} = string.Empty;

	public UICommand PromocodeErrorCommand { get; } = new UICommand();

	public UICommand PromocodeCancelCommand { get; } = new UICommand();

	public UICommand<BrokerToken> OpenStampsNoConnectCommand { get; } = new UICommand<BrokerToken>();

	public UICommand PromocodeFocusCommand { get; } = new UICommand();

	public string PromocodeTitle => "Промокод";

	public AccordionElementState PointsPaymentState
	{
		[CompilerGenerated]
		get
		{
			return _003CPointsPaymentState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CPointsPaymentState_003Ek__BackingField != value)
			{
				AccordionElementState pointsPaymentState = PointsPaymentState;
				_003CPointsPaymentState_003Ek__BackingField = value;
				RaisePropertyChanged("BonusesEnabled");
				AccordionElementState pointsPaymentState2 = PointsPaymentState;
				OnPointsPaymentStateChaged(pointsPaymentState, pointsPaymentState2);
				RaisePropertyChanged("PointsPaymentState");
			}
		}
	} = AccordionElementState.Gone;

	public long PointsPaymentMaxValue => (AdditionalBenefit?.Points?.Available).GetValueOrDefault();

	public long PointsPaymentMinValue => 0L;

	public long PointsPaymentValue
	{
		[CompilerGenerated]
		get
		{
			return _003CPointsPaymentValue_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CPointsPaymentValue_003Ek__BackingField != value)
			{
				long pointsPaymentValue = PointsPaymentValue;
				_003CPointsPaymentValue_003Ek__BackingField = value;
				long pointsPaymentValue2 = PointsPaymentValue;
				OnPointsPaymentValueChanged(pointsPaymentValue, pointsPaymentValue2);
				RaisePropertyChanged("PointsPaymentValue");
			}
		}
	}

	public bool IsUsedPointsVisible
	{
		get
		{
			Auchan.Common.Ecom.Cart.Models.Summary? summary = Summary;
			if ((object)summary == null)
			{
				return false;
			}
			decimal? usedPoints = summary.UsedPoints;
			return (usedPoints.GetValueOrDefault() > default(decimal)) & usedPoints.HasValue;
		}
	}

	public string UsedPoints
	{
		get
		{
			Auchan.Common.Ecom.Cart.Models.Summary? summary = Summary;
			if ((object)summary != null && summary.UsedPoints.HasValue)
			{
				return $"-{Summary?.UsedPoints}";
			}
			return "";
		}
	}

	public string PointsPaymentTitle => "Списание баллов";

	public string PointsAvailableText
	{
		get
		{
			if (!(AdditionalBenefit != null))
			{
				return "";
			}
			return $"Доступно {PointsPaymentMaxValue} из {AdditionalBenefit.Points?.Total}";
		}
	}

	public string PointsBurnableText => AdditionalBenefit?.Points?.BurnablePoints ?? "";

	public decimal StampsWithdrawValue => Math.Abs((Summary?.UsedStamps).GetValueOrDefault());

	public string StampsWithdrawTitle => "Списание марок";

	public LinkedText PointsPaymentAdultText => ExtractLinkedTextBonuses(AdditionalBenefit?.Informers?.AlcoholInformer);

	public LinkedText NoPointsText => ExtractLinkedTextBonuses(AdditionalBenefit?.Informers?.PointsInformer);

	public LinkedText PointsNotAvailableText => new LinkedText("Списание баллов в настоящий момент невозможно.\nВоспользоваться своими баллами можно позднее.", "позднее", delegate
	{
	});

	public string Email
	{
		[CompilerGenerated]
		get
		{
			return _003CEmail_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CEmail_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CEmail_003Ek__BackingField = value;
				RaisePropertyChanged("PaymentButtonEnabled");
				RaisePropertyChanged("Email");
			}
		}
	} = "";

	public string EmailError
	{
		[CompilerGenerated]
		get
		{
			return _003CEmailError_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CEmailError_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CEmailError_003Ek__BackingField = value;
				RaisePropertyChanged("EmailError");
			}
		}
	} = string.Empty;

	public bool IsEmailValid
	{
		[CompilerGenerated]
		get
		{
			return _003CIsEmailValid_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsEmailValid_003Ek__BackingField != value)
			{
				_003CIsEmailValid_003Ek__BackingField = value;
				RaisePropertyChanged("PaymentButtonEnabled");
				RaisePropertyChanged("IsEmailValid");
			}
		}
	}

	public bool PaymentButtonEnabled
	{
		get
		{
			_logService.LogInfo("PaymentButtonEnabled", $"IsPointsRequestPending = {IsPointsRequestPending} IsInProgress = {IsInProgress} IsEmailValid = {IsEmailValid}({Email}) IsNameValid = {IsNameValid}({Name}) IsPhoneFilled = {IsPhoneFilled}({Phone}) IsDeliveryValid = {IsDeliveryValid}({SelectedDeliveryDate}) IsPaymentMethodSelected = {IsPaymentMethodSelected}CheckoutData received {Summary != null}", LogType.UserAction, SystemType.ECom);
			if (!IsPointsRequestPending && !IsInProgress && !IsOverlayInProgress && IsEmailValid && Summary != null && (!CustomRecipient || IsNameValid) && (!CustomRecipient || (CustomRecipient && IsPhoneFilled)) && IsDeliveryValid)
			{
				return IsPaymentMethodSelected;
			}
			return false;
		}
	}

	public CheckoutReceiveMethod ReceivingMethod => DeliveryMethod?.Method ?? CheckoutReceiveMethod.BySelf;

	public UICommand<BrokerToken> SelectDeliveryCommand { get; } = new UICommand<BrokerToken>();

	public UICommand<CheckoutWebViewModel.Parameter> GoToPaymentCommand { get; } = new UICommand<CheckoutWebViewModel.Parameter>();

	public UICommand<CheckoutSuccessViewModel.Parameter> SuccessfulPaymentCommand { get; } = new UICommand<CheckoutSuccessViewModel.Parameter>();

	public UICommand<InfoPageViewModel.Parameter> OpenInfoPageCommand { get; } = new UICommand<InfoPageViewModel.Parameter>();

	public UICommand<DeliveryInfoPopupViewModel.Parameter> OpenDeliveryInfoCommand { get; } = new UICommand<DeliveryInfoPopupViewModel.Parameter>();

	public UICommand OpenExpressDeliveryUnavailableCommand { get; } = new UICommand();

	public UICommand PopToRootCommand { get; } = new UICommand();

	public UICommand PopBackCommand { get; } = new UICommand();

	public UICommand CommitErrorCommand { get; } = new UICommand();

	public UICommand<CarFormViewModel.Parameter> OpenAddCarCommand { get; } = new UICommand<CarFormViewModel.Parameter>();

	public UICommand OpenSelectCarCommand { get; } = new UICommand();

	public UICommand<CheckoutPointsPaymentInformerViewModel.Parameter> OpenPointsInformerCommand { get; } = new UICommand<CheckoutPointsPaymentInformerViewModel.Parameter>();

	string IYandexMetricaScreenViewModel.ScreenNameForBaseEvents => "Checkout";

	string IYandexMetricaScreenViewModel.ScreenName => "Checkout";

	public UICommand CommitCommand { get; } = new UICommand();

	public UICommand<bool> LoadCommand { get; } = new UICommand<bool>();

	public UICommand SendLogsCommand
	{
		[CompilerGenerated]
		get
		{
			return _003CSendLogsCommand_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!object.Equals(_003CSendLogsCommand_003Ek__BackingField, value))
			{
				_003CSendLogsCommand_003Ek__BackingField = value;
				RaisePropertyChanged("SendLogsCommand");
			}
		}
	} = new UICommand();

	public string ReportProblemButtonTitle => "Сообщить о проблеме";

	public bool ReportProblemButtonVisible
	{
		[CompilerGenerated]
		get
		{
			return _003CReportProblemButtonVisible_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CReportProblemButtonVisible_003Ek__BackingField != value)
			{
				_003CReportProblemButtonVisible_003Ek__BackingField = value;
				RaisePropertyChanged("ReportProblemButtonVisible");
			}
		}
	}

	public bool IsVpnError
	{
		[CompilerGenerated]
		get
		{
			return _003CIsVpnError_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CIsVpnError_003Ek__BackingField != value)
			{
				_003CIsVpnError_003Ek__BackingField = value;
				RaisePropertyChanged("IsVpnError");
			}
		}
	}

	public string PickingPriceTitle => "Сервисный сбор";

	public string PickingPriceText => $"{PickingPrice:C0}";

	public decimal PickingPrice => (Summary?.PickingPrice).GetValueOrDefault();

	public bool PickingPriceVisible => PickingPrice != 0m;

	public string SurgeAmountTitle => "Повышенный спрос";

	public string SurgeAmountText => $"{SurgeAmount:C0}";

	public decimal SurgeAmount => (Summary?.SurgeAmount).GetValueOrDefault();

	public bool SurgeAmountVisible => SurgeAmount > 0m;

	public CheckoutViewModel(BrokerToken brokerToken, IUserContext userContext, IAdminContext adminContext, ICheckoutService checkoutService, ICarsRepository carsRepository, DefaultErrorTranslator errorTranslator, IInfoMessageService infoMessageService, ILogService logService, ProfileInteractor profileInteractor, Func<ProductOffer, ICartScreenViewModel, CartItemViewModel> itemFactory, PaymentUrlHelper paymentUrlFactory)
		: base(brokerToken)
	{
		_userContext = userContext;
		_adminContext = adminContext;
		_infoMessageService = infoMessageService;
		_checkoutService = checkoutService;
		_carsRepository = carsRepository;
		_errorTranslator = errorTranslator;
		_logService = logService;
		_profileInteractor = profileInteractor;
		_paymentUrlHelper = paymentUrlFactory;
		_emailValidator = new AsyncValidator<(bool, string)>(ValidateEmailAsync, delegate((bool, string) r)
		{
			(IsEmailValid, EmailError) = r;
		}).AddTo(base.CloseDisposable);
		DiscardStamps = base.Argument.DiscardStamps;
	}

	public void OnDeliveryInfoClicked()
	{
		if (!(DeliveryMethod == null) && !(Summary?.DeliveryTariff == null))
		{
			OpenDeliveryInfoCommand.Trigger(DeliveryInfoPopupViewModel.Parameter.For(DeliveryMethod, Summary.DeliveryTariff));
		}
	}

	protected override async Task Start()
	{
		await base.Start();
		CommitCommand.PerformDebouncingTask(Commit).Subscribe().AddTo(base.CloseDisposable);
		LoadCommand.StartWith(default(bool)).PerformSamplingTask(LoadData).Subscribe()
			.AddTo(base.CloseDisposable);
		_carsRepository.Cars.CollectionChangedAsObservable().ObserveOn(Auchan.Common.Helpers.MainThread.Scheduler).Subscribe(delegate
		{
			Car car = _carsRepository.Cars.FirstOrDefault((Car c) => c.IsDefault) ?? _carsRepository.Cars.FirstOrDefault();
			if (car != null)
			{
				UpdateCar(car);
			}
		})
			.AddTo(base.CloseDisposable);
		SendLogsCommand.PerformDebouncingTask(SendLogsAsync).Subscribe().AddTo(base.CloseDisposable);
		AppAnalytics.Ecom.OpenCheckoutScreen();
		this.OnPropertyChanges((CheckoutViewModel x) => x.CustomRecipient).ObserveOn(Auchan.Common.Helpers.MainThread.Scheduler).StartWith(CustomRecipient)
			.Subscribe(OnCustomRecipientChanged)
			.AddTo(base.CloseDisposable);
		PromocodeErrorCommand.Subscribe(delegate
		{
			OnPromocodeErrorCommand();
		}).AddTo(base.CloseDisposable);
		PromocodeCancelCommand.Subscribe(delegate
		{
			OnPromocodeCancelCommand();
		}).AddTo(base.CloseDisposable);
	}

	protected override async Task OnResumed()
	{
		await base.OnResumed();
		if (!_firstStart && !_goingToCheckout)
		{
			LoadCommand.Trigger(subject: true);
		}
		_logService.LogInfo("CheckoutViewModel", "Открыт экран checkout", LogType.UserAction, SystemType.MobileApp);
		_firstStart = false;
	}

	private void OnCustomRecipientChanged(bool custom)
	{
		if (!custom)
		{
			_profileEmail = Recipient?.Email ?? string.Empty;
			Email = Recipient?.Email ?? string.Empty;
			_emailValidator.ValidateAsync().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public void OnPaymentClicked()
	{
		AppAnalytics.AppMetrica.TrackEvent("checkout1ScreenButtonPay");
		CheckoutTime checkoutTime = SelectedDateTime?.Time;
		if ((object)checkoutTime != null && checkoutTime.HasSurge)
		{
			AppAnalytics.AppMetrica.SurgeSlotSelected(checkoutTime.Name, checkoutTime.Price.GetValueOrDefault());
		}
		CommitCommand.Trigger();
	}

	public void OnSelectDeliveryClicked()
	{
		if (IsDeliveryDateTimeSelectable)
		{
			DoAsync().SafeFireAndForget((Action<Exception>)null, false);
		}
		async Task DoAsync()
		{
			DeliveryDateTimeViewModel.Parameter parameter = new DeliveryDateTimeViewModel.Parameter
			{
				Dates = DeliveryDates,
				SelectedDateTime = SelectedDateTime,
				ReceiveMethod = ReceivingMethod
			};
			SelectDeliveryCommand.Trigger(base.DataBroker.Push(parameter));
			SelectedDateTime selectedDateTime = await parameter.WaitForResultAsync();
			if (selectedDateTime != null)
			{
				SelectDeliverySlot(selectedDateTime);
				ScrollToSelectedDeliverySlot();
			}
		}
	}

	private void ScrollToSelectedDeliverySlot()
	{
		for (int i = 0; i < DeliverySlots.Count; i++)
		{
			if (DeliverySlots[i].Selected)
			{
				SelectedDeliverySlotIndex = i;
				break;
			}
		}
	}

	public void OnDeliverySlotClicked(CheckoutSlotItemViewModel slot)
	{
		SelectDeliverySlot(slot.Item);
	}

	public void OnDeliverySlotDisplayed(CheckoutSlotItemViewModel slot)
	{
		if (slot.HasSurge && _displayedSurgeSlots.Add($"{slot.Item.Day.Date:yyyyMMdd}:{slot.Item.Time.Id}"))
		{
			AppAnalytics.AppMetrica.SurgeSlotDisplayed();
		}
	}

	private void SelectDeliverySlot(SelectedDateTime slot)
	{
		if (!IsSameSlot(slot, SelectedDateTime))
		{
			SelectedDateTime selectedDateTime = SelectedDateTime;
			SelectedDateTime = slot;
			DeliveryError = string.Empty;
			ScrollToSelectedDeliverySlot();
			if (_needsRecalculate)
			{
				RecalculateSlot(selectedDateTime).SafeFireAndForget((Action<Exception>)null, false);
			}
		}
	}

	public void OnPromocodeOkClicked()
	{
		ApplyPromocode().SafeFireAndForget((Action<Exception>)null, false);
	}

	private async Task ApplyPromocode()
	{
		if (string.IsNullOrEmpty(PromocodeValue))
		{
			return;
		}
		using (BeginRequest())
		{
			using (await _recalculateRequestLock.LockAsync(default(CancellationToken)))
			{
				ProcessRecalculateResult(await RecalculateAsync(PromocodeValue, null), SelectedDateTime);
			}
		}
	}

	private async Task ResetBenefits()
	{
		using (BeginRequest())
		{
			using (await _recalculateRequestLock.LockAsync(default(CancellationToken)))
			{
				ProcessRecalculateResult(await RecalculateAsync(null, null), SelectedDateTime);
			}
		}
	}

	private async Task RecalculateSlot(SelectedDateTime? previous)
	{
		using (BeginRequest())
		{
			using (await _recalculateRequestLock.LockAsync(default(CancellationToken)))
			{
				ProcessRecalculateResult(await RecalculateAsync(PromocodeEntered ? PromocodeValue : null, (PointsPaymentState == AccordionElementState.Active) ? new long?(PointsPaymentValue) : ((long?)null)), previous);
			}
		}
	}

	private Task<Result<RecalculateResult, DomainError>> RecalculateAsync(string? promocode, long? points)
	{
		return _checkoutService.RecalculateAsync(promocode, points, SelectedDateTime?.Time.Id, DiscardStamps);
	}

	private void ProcessRecalculateResult(Result<RecalculateResult, DomainError> result, SelectedDateTime? previous)
	{
		DomainError error;
		if (result.TryGetValue(out RecalculateResult value))
		{
			if (value.Dates != null)
			{
				SetDeliveryDates(value.Dates, value.MinSlotPrice, keepSelected: true);
			}
			AdditionalBenefit = value.AdditionalBenefit;
			Summary = value.Summary;
			AvailablePayments = value.AvailablePayments;
		}
		else if (result.TryGetError(out error) && !TryHandleExpressDeliveryUnavailable(error))
		{
			if (error is NoDataError)
			{
				PopRootBack();
				return;
			}
			SelectedDateTime = previous;
			ScrollToSelectedDeliverySlot();
			IsInErrorState = true;
			_retryAction = RetryAction.GetData;
			(ErrorTitle, ErrorMessage) = _errorTranslator.Translate(error);
		}
	}

	public void UpdateCar(Car car)
	{
		DeliveryMethod? deliveryMethod = DeliveryMethod;
		if ((object)deliveryMethod != null && deliveryMethod.Method == CheckoutReceiveMethod.Drive)
		{
			CheckoutCar car2 = DeliveryMethod.Car;
			if (!(car2 != null) || !(car2.Number == car.CarNumber) || !(car2.Color == car.CarColor) || !(car2.Brand == car.CarMark))
			{
				LoadCommand.Trigger(subject: true);
			}
		}
	}

	public void OnPaymentMethodSelected(PaymentItemViewModel ivm)
	{
		if (!ivm.Item.IsAvailable)
		{
			return;
		}
		foreach (PaymentItemViewModel paymentMethodItemViewModel in PaymentMethodItemViewModels)
		{
			paymentMethodItemViewModel.Selected = paymentMethodItemViewModel.Item == ivm.Item;
		}
		SelectedPaymentMethod = ivm.Item;
		PaymentMethodError = string.Empty;
	}

	public void Retry()
	{
		switch (_retryAction)
		{
		case RetryAction.GetData:
			LoadCommand.Trigger(subject: false);
			break;
		case RetryAction.Commit:
			CommitCommand.Trigger();
			break;
		}
	}

	private async Task LoadData(bool saveCurrentDateTime = false)
	{
		using (BeginRequest())
		{
			IsInErrorState = false;
			ReportProblemButtonVisible = false;
			IsVpnError = false;
			Result<CheckoutData, DomainError> result = await _checkoutService.GetDataAsync((PromocodeState == AccordionElementState.Active) ? PromocodeValue : null, (PointsPaymentState == AccordionElementState.Active) ? new long?(PointsPaymentValue) : ((long?)null), DiscardStamps);
			CheckoutData value;
			if (result.TryGetError(out var error))
			{
				AppAnalytics.AppMetrica.TrackEvent("checkOutScreenView_nievent_error");
				if (TryHandleExpressDeliveryUnavailable(error))
				{
					return;
				}
				if (!(error is DeliveryError deliveryError))
				{
					if (error is GenericCheckoutError)
					{
						_infoMessageService.ShowSnackbar("Что-то пошло не так. Повторите попытку позже");
						await Task.Delay(TimeSpan.FromSeconds(3L));
						PopRootBack();
					}
					else
					{
						IsInErrorState = true;
						_retryAction = RetryAction.GetData;
						(ErrorTitle, ErrorMessage) = _errorTranslator.Translate(error);
					}
				}
				else
				{
					_infoMessageService.ShowSnackbar(deliveryError.Message ?? "Что-то пошло не так. Повторите попытку позже");
					await Task.Delay(TimeSpan.FromSeconds(3L));
					PopRootBack();
				}
			}
			else if (result.TryGetValue(out value))
			{
				_needsRecalculate = value.NeedsRecalculate;
				bool flag = _needsRecalculate && SelectedDateTime != null && !IsSameSlot(SelectedDateTime, GetNearestDateTime(DeliveryDates));
				Recipient = value.Recipient;
				DeliveryMethod = value.DeliveryMethod;
				Products = value.Products;
				AdultProducts = value.AdultProducts;
				if (!flag)
				{
					AdditionalBenefit = value.AdditionalBenefit;
					Summary = value.Summary;
					AvailablePayments = value.AvailablePayments;
				}
				SetReplacements(value.Replacements);
				SetCustomName(_customName);
				if (value.VpnState == VpnState.Warning)
				{
					_infoMessageService.ShowSnackbar("Отключите VPN для успешной оплаты", SnackbarStyle.Warning, 5);
					AppAnalytics.AppMetrica.TrackEvent("vpnAlert", ("viewScreen", "checkout"));
				}
				SetDeliveryDates(value.DeliveryMethod.Dates, value.DeliveryMethod.MinSlotPrice, saveCurrentDateTime);
				if (flag)
				{
					RecalculateSlot(SelectedDateTime).SafeFireAndForget((Action<Exception>)null, false);
				}
			}
		}
	}

	public void OnEmailFocus(bool isFocused)
	{
		if (isFocused)
		{
			DropEmailErrorState();
		}
		_emailValidator.ValidateAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private void DropEmailErrorState()
	{
		EmailError = string.Empty;
	}

	private bool TryHandleExpressDeliveryUnavailable(DomainError? error)
	{
		if (!(error is ExpressDeliveryError))
		{
			return false;
		}
		if (!_expressDeliveryUnavailableShown)
		{
			_expressDeliveryUnavailableShown = true;
			BeginRequest();
			OpenExpressDeliveryUnavailableCommand.Trigger();
		}
		return true;
	}

	private async Task Commit()
	{
		ReportProblemButtonVisible = false;
		IsVpnError = false;
		if (!PaymentButtonEnabled)
		{
			CustomPhoneError = (string.IsNullOrWhiteSpace(_customPhone) ? "Обязательное поле" : ((!_isPhoneFilled) ? "Поле не заполнено полностью" : string.Empty));
			PaymentMethodError = (IsPaymentMethodSelected ? string.Empty : "Необходимо выбрать способ оплаты");
			CommitErrorCommand.Trigger();
			return;
		}
		using (BeginNonOverlayRequest())
		{
			IsInErrorState = false;
			Email = Email.Trim();
			bool isSuccess;
			bool isFailure;
			DomainError error;
			if (IsSaveNewEmail)
			{
				_userContext.Profile.Email = Email;
				(await _profileInteractor.UpdateProfile(_userContext.Profile)).Deconstruct(out isSuccess, out isFailure, out var _, out error);
				bool num = isSuccess;
				DomainError domainError = error;
				if (!num)
				{
					_userContext.Profile.Email = _profileEmail;
					if (domainError != null && !string.IsNullOrEmpty(domainError.Message))
					{
						_infoMessageService.ShowSnackbar(domainError.Message);
						EmailError = domainError.Message;
					}
					return;
				}
				_profileEmail = Email;
			}
			PaymentItemViewModel selectedPaymentVm = PaymentMethodItemViewModels.FirstOrDefault((PaymentItemViewModel x) => x.Selected);
			if (selectedPaymentVm == null)
			{
				(string, string) tuple = _errorTranslator.Translate(new UnknownError());
				ErrorTitle = tuple.Item1;
				ErrorMessage = tuple.Item2;
				_retryAction = RetryAction.GetData;
				IsInErrorState = true;
				return;
			}
			string paymentMethod = selectedPaymentVm.Item.Code.ToString().ToLower();
			CheckoutCommitDto checkoutCommitDto = new CheckoutCommitDto
			{
				Recipient = new CheckoutRecipient
				{
					Name = (CustomRecipient ? CustomName : Name),
					Phone = PhoneHelper.TryFix(CustomRecipient ? CustomPhone : Phone),
					Email = Email
				},
				Payment = new CheckoutPayment
				{
					ReturnUrl = _paymentUrlHelper.ReturnUrl,
					FailureUrl = _paymentUrlHelper.FailureUrl,
					PaymentMethod = paymentMethod
				}
			};
			if (DeliveryMethod.Method.IsDelivery())
			{
				checkoutCommitDto.Receive = new CheckoutReceive
				{
					Id = DeliveryMethod.Id,
					MethodId = DeliveryMethod.Method.ToDeliverMethod(),
					DeliveryAddress = new UserAddress
					{
						Porch = Porch,
						Flat = Flat,
						Floor = Floor,
						Intercom = Intercom,
						Comment = Comment
					},
					ReplacementMethodId = SelectedReplacementMethod?.Id,
					DeliveryToDoor = DeliveryToDoor,
					DeliveryDate = SelectedDateTime?.Day.Date,
					DeliveryDateTime = SelectedDateTime?.Time.Id
				};
			}
			else
			{
				checkoutCommitDto.Receive = new CheckoutReceive
				{
					Id = DeliveryMethod.Id,
					MethodId = DeliveryMethod.Method.ToDeliverMethod(),
					DeliveryAddress = null,
					DeliveryDate = null,
					DeliveryDateTime = null,
					PickupComment = (Comment ?? ""),
					PickupDate = SelectedDateTime?.Day.Date,
					PickupDateTime = SelectedDateTime?.Time.Id,
					ReplacementMethodId = SelectedReplacementMethod?.Id,
					DeliveryToDoor = DeliveryToDoor
				};
			}
			if (PointsPaymentState == AccordionElementState.Active)
			{
				checkoutCommitDto.Receive.UsedPoints = PointsPaymentValue.Clamp(PointsPaymentMinValue, PointsPaymentMaxValue);
			}
			if (PromocodeState == AccordionElementState.Active && !string.IsNullOrWhiteSpace(PromocodeValue) && PromocodeEntered)
			{
				checkoutCommitDto.Receive.Promocode = PromocodeValue;
			}
			checkoutCommitDto.Receive.DiscardStamps = DiscardStamps;
			(await _checkoutService.Commit(checkoutCommitDto)).Deconstruct(out isFailure, out isSuccess, out var value2, out error);
			bool isSuccess2 = isFailure;
			CheckoutCommitResultDto checkoutCommitResultDto = value2;
			DomainError domainError2 = error;
			if (isSuccess2)
			{
				string[] orderIds = checkoutCommitResultDto.OrderIds;
				Task.Run(() => AppAnalytics.AppMetrica.BeginCheckoutEvent(this, orderIds)).SafeFireAndForget((Action<Exception>)null, false);
				if (selectedPaymentVm.Item.Code == PaymentCode.Offline)
				{
					SuccessfulPaymentCommand.Trigger(new CheckoutSuccessViewModel.Parameter(CheckoutSuccessType.PaymentCompleted, orderIds, selectedPaymentVm.Item.Code));
					return;
				}
				string paymentUrl = checkoutCommitResultDto.PaymentUrl;
				if (string.IsNullOrWhiteSpace(paymentUrl))
				{
					_retryAction = RetryAction.Commit;
					_logService.LogError("CheckoutViewModel", "Получен пустой payment URL", LogType.ApiRequest, SystemType.ECom);
					ReportProblemButtonVisible = true;
					(string, string) tuple = _errorTranslator.Translate(new UnknownError());
					ErrorTitle = tuple.Item1;
					ErrorMessage = tuple.Item2;
					IsInErrorState = true;
					return;
				}
				Task<bool> task = WaitForPause();
				GoToPaymentCommand.Trigger(_paymentUrlHelper.GetParameter(paymentUrl, orderIds));
				await task;
				_goingToCheckout = true;
			}
			else
			{
				if (TryHandleExpressDeliveryUnavailable(domainError2))
				{
					return;
				}
				if (domainError2 is IncorrectAddressError)
				{
					_infoMessageService.ShowAlert("Адрес не соответствует выбранному магазину.", "Выберите ближайший магазин на экране корзины и повторите попытку.", new AlertButton[1]
					{
						new AlertButton
						{
							Title = "Вернуться в корзину",
							Action = PopRootBack,
							Type = ActionType.Positive
						}
					});
					return;
				}
				if (domainError2 is CheckoutNoPointsPayment)
				{
					await LoadData();
					return;
				}
				if (domainError2 is ExpiredTimeSlotError)
				{
					await LoadData();
					if (!_expressDeliveryUnavailableShown)
					{
						if (IsDeliveryDateTimeSelectable)
						{
							SelectedDateTime = null;
							DeliveryError = "Выберите удобную дату";
						}
						else
						{
							DeliveryError = string.Empty;
						}
						RaisePropertyChanged("DeliveryError");
						CommitErrorCommand.Trigger();
						_infoMessageService.ShowSnackbar("Дата и время доставки устарели, пожалуйста, выберите новые");
					}
					return;
				}
				if (domainError2 is CheckoutNoLoyaltyError)
				{
					StampsLoyaltyNoConnectViewModel.Parameter parameter = new StampsLoyaltyNoConnectViewModel.Parameter();
					OpenStampsNoConnectCommand.Trigger(base.DataBroker.Push(parameter));
					await parameter.WaitForResultAsync();
					DiscardStamps = false;
					LoadCommand.Trigger(subject: false);
					return;
				}
				ReportProblemButtonVisible = !(domainError2 is ConnectionError);
				IsVpnError = domainError2 is DisableVpnError;
				_retryAction = RetryAction.Commit;
				if (!IsVpnError)
				{
					(ErrorTitle, ErrorMessage) = _errorTranslator.Translate(domainError2);
				}
				else
				{
					string empty = string.Empty;
					ErrorTitle = empty;
					ErrorMessage = "Не удается загрузить приложение, попробуйте выключить VPN или Wi-Fi или подключитесь к другой сети Wi-Fi";
				}
			}
			IsInErrorState = !isSuccess2;
		}
	}

	public void OnBackPressed()
	{
		PopBackCommand.Trigger();
	}

	public void OnSwitchIsExpanded()
	{
		IsExpanded = CanExpand && !IsExpanded;
	}

	public void OnDriveCarChange()
	{
		OpenSelectCarCommand.Trigger();
	}

	public void OnDriveCarAdd()
	{
		OpenAddCarCommand.Trigger(new CarFormViewModel.Parameter());
	}

	public void OnPromocodeAdd()
	{
		if (PromocodeState == AccordionElementState.Inactive)
		{
			PromocodeState = AccordionElementState.Active;
			PromocodeFocusCommand.Trigger();
		}
	}

	public void OnPointsPaymentAdd()
	{
		if (PointsPaymentState == AccordionElementState.Inactive)
		{
			PointsPaymentState = AccordionElementState.Active;
			PointsPaymentValue = PointsPaymentMaxValue;
		}
	}

	public void OnPromocodeRemoveClicked()
	{
		if (PromocodeState == AccordionElementState.Active)
		{
			PromocodeState = AccordionElementState.Inactive;
		}
	}

	public void OnPointsPaymentRemove()
	{
		if (PointsPaymentState == AccordionElementState.Active)
		{
			PointsPaymentState = AccordionElementState.Inactive;
			PointsPaymentValue = PointsPaymentMaxValue;
		}
	}

	public void OnPointsPaymentInfoClick()
	{
		if (PointsPaymentAdultText != null)
		{
			OpenPointsInformerCommand.Trigger(new CheckoutPointsPaymentInformerViewModel.Parameter(PointsPaymentAdultText.Text, PointsPaymentAdultText.Highlights.FirstOrDefault() ?? ""));
		}
	}

	public void SetPointsPaymentValue(string? value)
	{
		if (string.IsNullOrEmpty(value))
		{
			ResetPointsPaymentValue();
			return;
		}
		value = string.Join("", value.Where((char c) => char.IsDigit(c)));
		if (long.TryParse(value, out var result))
		{
			PointsPaymentValue = Math.Clamp(result, 0L, PointsPaymentMaxValue);
		}
	}

	public void ResetPointsPaymentValue()
	{
		PointsPaymentValue = 0L;
	}

	private void PopRootBack()
	{
		BeginNonOverlayRequest();
		PopToRootCommand.Trigger();
	}

	private void ShowLoyaltyRules()
	{
		OpenInfoPageCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.LoyaltyPolicy)
		{
			TabBarVisible = false
		});
	}

	private void ShowPrivacyPolicy()
	{
		OpenInfoPageCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.PrivacyPolicy)
		{
			TabBarVisible = false
		});
	}

	private void ShowOfferta()
	{
		OpenInfoPageCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.Offerta)
		{
			TabBarVisible = false
		});
	}

	private void SetDeliveryDates(IReadOnlyList<CheckoutDate> dates, decimal? minSlotPrice, bool keepSelected)
	{
		MinSlotPrice = minSlotPrice;
		SelectedDateTime = (keepSelected ? FindDeliverySlot(dates, SelectedDateTime) : null) ?? GetNearestDateTime(dates);
		DeliveryDates = dates;
	}

	private void UpdateDeliverySlots()
	{
		SelectedDateTime selected = SelectedDateTime;
		List<CheckoutSlotItemViewModel> list = new List<CheckoutSlotItemViewModel>();
		list.AddRange(from i in DeliveryDates.SelectMany((CheckoutDate d) => d.Time.Select((CheckoutTime t) => new SelectedDateTime
			{
				Day = d,
				Time = t
			}))
			select new CheckoutSlotItemViewModel(i, this, IsSameSlot(i, selected)));
		DeliverySlots = new _003C_003Ez__ReadOnlyList<CheckoutSlotItemViewModel>(list);
	}

	private static SelectedDateTime? FindDeliverySlot(IReadOnlyList<CheckoutDate> dates, SelectedDateTime? slot)
	{
		CheckoutDate checkoutDate = ((slot == null) ? null : dates.FirstOrDefault((CheckoutDate i) => i.Date == slot.Day.Date));
		CheckoutTime checkoutTime = checkoutDate?.Time.FirstOrDefault((CheckoutTime t) => t.Id == slot.Time.Id && t.Slot == slot.Time.Slot);
		if (!(checkoutDate == null) && !(checkoutTime == null))
		{
			return new SelectedDateTime
			{
				Day = checkoutDate,
				Time = checkoutTime
			};
		}
		return null;
	}

	private static SelectedDateTime? GetNearestDateTime(IReadOnlyList<CheckoutDate> dates)
	{
		CheckoutDate checkoutDate = dates.FirstOrDefault();
		CheckoutTime checkoutTime = checkoutDate?.Time.FirstOrDefault();
		if (!(checkoutDate == null) && !(checkoutTime == null))
		{
			return new SelectedDateTime
			{
				Day = checkoutDate,
				Time = checkoutTime
			};
		}
		return null;
	}

	private static bool IsSameSlot(SelectedDateTime? left, SelectedDateTime? right)
	{
		if (left != null && right != null && left.Day.Date == right.Day.Date)
		{
			return left.Time.Id == right.Time.Id;
		}
		return false;
	}

	private LinkedText ExtractLinkedTextBonuses(string? html)
	{
		if (html == null)
		{
			return new LinkedText("");
		}
		return LinkedText.FromTextWithHref(html, (Action)delegate
		{
			ProfileModel? profile = _userContext.Profile;
			if (profile != null && profile.IsAuchanEmployee)
			{
				OpenInfoPageCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.EmployeesLoyaltyPolicy)
				{
					TabBarVisible = false
				});
			}
			else
			{
				OpenInfoPageCommand.Trigger(new InfoPageViewModel.Parameter(InfoType.LoyaltyPolicy)
				{
					TabBarVisible = false
				});
			}
		});
	}

	public void SetCustomName(string value)
	{
		_customName = value;
		if (CustomRecipient)
		{
			IsNameValid = AuthValidationHelper.IsValidFirstName(_customName);
		}
		else
		{
			IsNameValid = false;
		}
		CustomNameError = (string.IsNullOrWhiteSpace(_customName) ? "Обязательное поле" : ((!IsNameValid) ? "Удалите пробелы, цифры, символы" : string.Empty));
		RaisePropertyChanged("IsNameValid");
		RaisePropertyChanged("PaymentButtonEnabled");
	}

	public void SetEmail(string value)
	{
		if (!(value == Email))
		{
			Email = value ?? string.Empty;
			IsSaveNewEmailVisible = !CustomRecipient && !string.IsNullOrEmpty(Email) && Email != _profileEmail;
			if (!IsSaveNewEmailVisible)
			{
				IsSaveNewEmail = false;
			}
			RaisePropertyChanged("PaymentButtonEnabled");
			_emailValidator.ValidateAsync().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private async Task ApplyPointsAsync()
	{
		if (!Microsoft.Maui.ApplicationModel.MainThread.IsMainThread)
		{
			throw new InvalidOperationException("should be called from main thread");
		}
		if (IsInProgress || !PointsPaymentState.IsEnabled())
		{
			return;
		}
		Guid guid = (ApplyPointsRequestId = Guid.NewGuid());
		Guid rid = guid;
		await Task.Delay(TimeSpan.FromSeconds(1L));
		using (await _recalculateRequestLock.LockAsync(default(CancellationToken)))
		{
			if (rid != ApplyPointsRequestId)
			{
				return;
			}
			using (BeginRequest())
			{
				Result<RecalculateResult, DomainError> result = await RecalculateAsync(null, (PointsPaymentState == AccordionElementState.Active) ? PointsPaymentValue : 0);
				ApplyPointsRequestCompletedId = rid;
				ProcessRecalculateResult(result, SelectedDateTime);
				if (result.IsSuccess)
				{
					AppAnalytics.AppMetrica.PointsUsed(PointsPaymentValue, PointsPaymentMaxValue);
				}
			}
		}
	}

	private void OnPromocodeErrorCommand()
	{
		if (!string.IsNullOrEmpty(PromocodeErrorLink))
		{
			OpenInfoPageCommand.Trigger(new InfoPageViewModel.Parameter
			{
				Slug = (AdditionalBenefit?.PromocodeCondition?.Slug ?? InfoPagesConverter.InfoTypeToSlug(InfoType.PromocodeInfoPage)),
				TabBarVisible = false
			});
		}
	}

	private void OnPromocodeCancelCommand()
	{
		PromocodeResetState();
		ResetBenefits().SafeFireAndForget((Action<Exception>)null, false);
	}

	private void PromocodeResetState()
	{
		PromocodeValue = string.Empty;
		PromocodeChanged = false;
		PromocodeError = false;
	}

	private async Task SendLogsAsync()
	{
		using (BeginRequest())
		{
			if ((await _logService.SendLogs(ILogService.SendFrom.Checkout)).IsSuccess)
			{
				_infoMessageService.ShowSnackbar("Сообщение успешно отправлено!", SnackbarStyle.Success);
			}
			else
			{
				_infoMessageService.ShowSnackbar("Упс. Небольшие технические проблемы.");
			}
			PopBackCommand.Trigger();
		}
	}

	private async Task<(bool, string)> ValidateEmailAsync(CancellationToken cancellationToken)
	{
		string email = Email;
		if (string.IsNullOrEmpty(email))
		{
			return (false, "Обязательное поле");
		}
		if (await AuthValidationHelper.IsValidEmailAsync(email))
		{
			return (true, "");
		}
		return (false, "Не используйте кириллицу, пробелы и спецсимволы");
	}

	private static T GetByDeliveryMethod<T>(DeliveryMethod? method, Func<DeliveryMethod, T?> onDelivery, Func<DeliveryMethod, T?> onSelfOrCar, T @default)
	{
		if ((object)method != null)
		{
			_ = method.Method;
			switch (method.Method)
			{
			case CheckoutReceiveMethod.Delivery:
			case CheckoutReceiveMethod.ExpressDelivery:
			{
				T val = onDelivery(method);
				if (val == null)
				{
					return @default;
				}
				return val;
			}
			case CheckoutReceiveMethod.BySelf:
			case CheckoutReceiveMethod.Drive:
			{
				T val = onSelfOrCar(method);
				if (val == null)
				{
					return @default;
				}
				return val;
			}
			}
		}
		return @default;
	}

	private static T GetByDriveMethod<T>(DeliveryMethod? method, Func<CheckoutCar, T?> onDrive, T @default)
	{
		if ((object)method != null)
		{
			_ = method.Method;
			switch (method.Method)
			{
			case CheckoutReceiveMethod.Drive:
			{
				if (!(method.Car != null))
				{
					return @default;
				}
				T val = onDrive(method.Car);
				if (val == null)
				{
					return @default;
				}
				return val;
			}
			}
		}
		return @default;
	}

	private void SetReplacements(IReadOnlyList<Replacement> replacements)
	{
		Replacement selected = SelectedReplacementMethod;
		Replacements = replacements.Select((Replacement i) => new ReplacementItemViewModel(i, this, i.Id == selected?.Id)).ToImmutableList();
		SelectedReplacementMethod = Replacements.FirstOrDefault((ReplacementItemViewModel i) => i.Item.Id == selected?.Id)?.Item ?? Replacements.FirstOrDefault((ReplacementItemViewModel i) => i.Item.IsDefault)?.Item;
	}

	private void OnRecipientChanged(Recipient? old, Recipient? @new)
	{
		Email = @new?.Email ?? Email;
		_profileEmail = Email;
		IsSaveNewEmailVisible = false;
		_emailValidator.ValidateAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private void OnDeliveryMethodChanged(DeliveryMethod? old, DeliveryMethod? @new)
	{
		if (!(@new == null) && @new.Method.IsDelivery() && @new.Address != null)
		{
			Porch = @new.Address.Porch?.ToString() ?? Porch;
			Floor = @new.Address.Floor?.ToString() ?? Floor;
			Flat = @new.Address.Flat?.ToString() ?? Flat;
			Intercom = @new.Address.Intercom?.ToString() ?? Intercom;
		}
	}

	private void OnAdditionalBenefitChanged(AdditionalBenefit? old, AdditionalBenefit? @new)
	{
		BenefitMechanic benefitMechanic = @new?.Mechanic ?? BenefitMechanic.None;
		bool flag = !DiscardStamps && @new != null;
		AccordionElementState promocodeState = PromocodeState;
		bool isEnabled;
		if (flag)
		{
			bool flag2 = (uint)(benefitMechanic - 2) <= 1u;
			isEnabled = flag2;
		}
		else
		{
			isEnabled = false;
		}
		PromocodeState = promocodeState.SetState(isEnabled);
		if (@new?.Points == null && !string.IsNullOrEmpty(@new?.Informers?.PointsInformer))
		{
			PointsPaymentState = AccordionElementState.NoPoints;
		}
		else
		{
			PointsPaymentState = PointsPaymentState.SetState(flag && benefitMechanic == BenefitMechanic.PromocodeAndPoints);
		}
		if (PointsPaymentState != AccordionElementState.Active)
		{
			PointsPaymentValue = PointsPaymentMaxValue;
		}
		if (PromocodeState.IsEnabled())
		{
			PromocodeCondition promocodeCondition = @new?.PromocodeCondition;
			if (promocodeCondition != null)
			{
				PromocodeValue = promocodeCondition.PromoCode;
				PromocodeError = !promocodeCondition.IsSuccess;
				PromocodeInfo = (promocodeCondition.IsSuccess ? (promocodeCondition.Message ?? "") : "");
				PromocodeErrorMessage = (promocodeCondition.IsSuccess ? "" : (promocodeCondition.Message ?? ""));
				PromocodeErrorLink = (promocodeCondition.IsSuccess ? "" : ((promocodeCondition.LinkName != null) ? ("<u>" + promocodeCondition.LinkName + "</u>") : ""));
				PromocodeChanged = false;
				AppAnalytics.AppMetrica.PromocodeAttempted(promocodeCondition.PromoCode, promocodeCondition.IsSuccess);
			}
		}
	}

	private void OnSelectedDateTimeChanged(SelectedDateTime? old, SelectedDateTime? @new)
	{
		foreach (CheckoutSlotItemViewModel deliverySlot in DeliverySlots)
		{
			deliverySlot.Selected = IsSameSlot(deliverySlot.Item, @new);
		}
	}

	private void OnDeliveryDatesChanged(IReadOnlyList<CheckoutDate> old, IReadOnlyList<CheckoutDate> @new)
	{
		UpdateDeliverySlots();
	}

	private void OnSelectedReplacementChanged(Replacement? old, Replacement? @new)
	{
		foreach (ReplacementItemViewModel replacement in Replacements)
		{
			replacement.Selected = @new?.Id == replacement.Item.Id;
		}
	}

	private void OnAvailablePaymentsChanged(IReadOnlyList<AvailablePayment> old, IReadOnlyList<AvailablePayment> @new)
	{
		PaymentItemViewModel selected = PaymentMethodItemViewModels.FirstOrDefault((PaymentItemViewModel i) => i.Selected);
		ImmutableList<PaymentItemViewModel> immutableList = @new.Select((AvailablePayment i) => new PaymentItemViewModel(i, this, selected: false)).ToImmutableList();
		selected = ((selected == null) ? immutableList.FirstOrDefault() : immutableList.FirstOrDefault((PaymentItemViewModel i) => i.Item.Code == selected.Item.Code));
		PaymentMethodItemViewModels = immutableList;
		if (selected != null)
		{
			OnPaymentMethodSelected(selected);
		}
		if (immutableList.All((PaymentItemViewModel i) => !i.Item.IsAvailable))
		{
			_infoMessageService.ShowAlert(string.Empty, "В данном магазине нет доступных методов оплаты. Выберите другой магазин.", AlertButtons.OkButtons);
		}
	}

	private void OnPromocodeStateChanged(AccordionElementState old, AccordionElementState @new)
	{
		if (@new == AccordionElementState.Active && PointsPaymentState == AccordionElementState.Active)
		{
			OnPointsPaymentRemove();
		}
		if (@new == AccordionElementState.Active)
		{
			return;
		}
		bool hasPromocodeDiscount = HasPromocodeDiscount;
		PromocodeResetState();
		if (hasPromocodeDiscount)
		{
			if (PointsPaymentState.IsEnabled())
			{
				ApplyPointsAsync().SafeFireAndForget((Action<Exception>)null, false);
			}
			else
			{
				ResetBenefits().SafeFireAndForget((Action<Exception>)null, false);
			}
		}
	}

	private void OnPromocodeValueChanged(string old, string @new)
	{
		PromocodeError = false;
		PromocodeInfo = string.Empty;
		PromocodeChanged = true;
		if (string.IsNullOrEmpty(@new) && AdditionalBenefit != null)
		{
			AdditionalBenefit = AdditionalBenefit with
			{
				PromocodeCondition = null
			};
		}
	}

	private void OnPointsPaymentStateChaged(AccordionElementState old, AccordionElementState @new)
	{
		if (@new == AccordionElementState.Active && PromocodeState == AccordionElementState.Active)
		{
			OnPromocodeRemoveClicked();
		}
		ApplyPointsAsync().SafeFireAndForget((Action<Exception>)null, false);
	}

	private void OnPointsPaymentValueChanged(long old, long @new)
	{
		if (PointsPaymentState == AccordionElementState.Active)
		{
			ApplyPointsAsync().SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	private IDisposable BeginRequest()
	{
		if (_firstStart)
		{
			return BeginNonOverlayRequest();
		}
		return BeginOverlayRequest();
	}

	private IDisposable BeginNonOverlayRequest()
	{
		IsInProgress = Interlocked.Increment(ref _requestCounter) > 0;
		return Disposable.Create(delegate
		{
			IsInProgress = Interlocked.Decrement(ref _requestCounter) > 0;
		});
	}

	private IDisposable BeginOverlayRequest()
	{
		IsOverlayInProgress = Interlocked.Increment(ref _overlayRequestCounter) > 0;
		return Disposable.Create(delegate
		{
			IsOverlayInProgress = Interlocked.Decrement(ref _overlayRequestCounter) > 0;
		});
	}
}
