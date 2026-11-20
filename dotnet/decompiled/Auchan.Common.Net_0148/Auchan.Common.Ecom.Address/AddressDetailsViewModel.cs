using System;
using System.Linq;
using System.Reactive;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Extensions;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.Address;

public sealed class AddressDetailsViewModel : ScreenViewModel<AddressDetailsViewModel.Parameter>
{
	public sealed class Parameter : BrokeredParameter<bool>
	{
		public required bool IsNew { get; init; }

		public required SavedAddress Address { get; init; }

		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	private IUserAddressService _userAddressService;

	private IInfoMessageService _infoMessageService;

	private IErrorTranslator _errorTranslator;

	private IDataBroker _dataBroker;

	[CompilerGenerated]
	private int _003CSelectedNameIndex_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CEnteredName_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CPorch_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CFloor_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CFlat_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CIntercom_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CComment_003Ek__BackingField;

	[CompilerGenerated]
	private SavedAddress _003CAddress_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	public override bool TabBarVisible => false;

	public string Title
	{
		get
		{
			if (!IsNew)
			{
				return "Изменение адреса доставки";
			}
			return "Точный адрес";
		}
	}

	public string StreetHouseText => "Город, улица, дом";

	public string SaveButtonText => "Сохранить";

	public string FillLaterButtonText => "Заполнить позже";

	public string DeleteButtonText => "Удалить адрес";

	public int SelectedNameIndex
	{
		[CompilerGenerated]
		get
		{
			return _003CSelectedNameIndex_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CSelectedNameIndex_003Ek__BackingField != value)
			{
				_003CSelectedNameIndex_003Ek__BackingField = value;
				RaisePropertyChanged("NameFieldVisible");
				RaisePropertyChanged("SaveButtonActive");
				RaisePropertyChanged("FillLaterButtonVisible");
				RaisePropertyChanged("SaveButtonVisible");
				RaisePropertyChanged("SelectedNameIndex");
			}
		}
	} = -1;

	public bool IsNew { get; }

	public bool NameFieldVisible => SelectedNameIndex == NameButtons.Length - 1;

	public string EnteredName
	{
		[CompilerGenerated]
		get
		{
			return _003CEnteredName_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CEnteredName_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CEnteredName_003Ek__BackingField = value;
				RaisePropertyChanged("SaveButtonActive");
				RaisePropertyChanged("FillLaterButtonVisible");
				RaisePropertyChanged("SaveButtonVisible");
				RaisePropertyChanged("EnteredName");
			}
		}
	}

	public string AddressNameHint => "Название адреса";

	public string[] NameButtons => new string[3] { "Дом", "Работа", "Своё название" };

	public string PorchHint => "Подъезд";

	public string FloorHint => "Этаж";

	public string FlatHint => "Кв/Офис";

	public string IntercomHint => "Домофон";

	public string CommentHint => "Комментарий к адресу";

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
				RaisePropertyChanged("SaveButtonActive");
				RaisePropertyChanged("FillLaterButtonVisible");
				RaisePropertyChanged("SaveButtonVisible");
				RaisePropertyChanged("Porch");
			}
		}
	} = "";

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
				RaisePropertyChanged("SaveButtonActive");
				RaisePropertyChanged("FillLaterButtonVisible");
				RaisePropertyChanged("SaveButtonVisible");
				RaisePropertyChanged("Floor");
			}
		}
	} = "";

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
				RaisePropertyChanged("SaveButtonActive");
				RaisePropertyChanged("FillLaterButtonVisible");
				RaisePropertyChanged("SaveButtonVisible");
				RaisePropertyChanged("Flat");
			}
		}
	} = "";

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
				RaisePropertyChanged("SaveButtonActive");
				RaisePropertyChanged("FillLaterButtonVisible");
				RaisePropertyChanged("SaveButtonVisible");
				RaisePropertyChanged("Intercom");
			}
		}
	} = "";

	public string Comment
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
				RaisePropertyChanged("CommentLength");
				RaisePropertyChanged("SaveButtonActive");
				RaisePropertyChanged("FillLaterButtonVisible");
				RaisePropertyChanged("SaveButtonVisible");
				RaisePropertyChanged("Comment");
			}
		}
	} = "";

	public string CommentLength => $"{Comment.Length} / {150}";

	public bool FillLaterButtonVisible
	{
		get
		{
			if (IsNew)
			{
				return !SaveButtonActive;
			}
			return false;
		}
	}

	public bool SaveButtonVisible
	{
		get
		{
			if (IsNew)
			{
				return SaveButtonActive;
			}
			return true;
		}
	}

	public bool DeleteButtonVisible => !IsNew;

	public bool SaveButtonActive
	{
		get
		{
			if (!(Porch != Address.Porch) && !(Floor != Address.Floor) && !(Flat != Address.Flat) && !(Intercom != Address.Intercom) && !(Comment != Address.Comment) && (!(EnteredName != Address.Name) || SelectedNameIndex != NameButtons.Length - 1) && (string.IsNullOrEmpty(Address.Name) || SelectedNameIndex >= 0))
			{
				if (SelectedNameIndex >= 0 && SelectedNameIndex < NameButtons.Length - 1)
				{
					return NameButtons[SelectedNameIndex] != Address.Name;
				}
				return false;
			}
			return true;
		}
	}

	public int MaxCommentLength => 150;

	public int MaxNameLength => 50;

	public int MaxOtherFieldLength => 25;

	public SavedAddress Address
	{
		[CompilerGenerated]
		get
		{
			return _003CAddress_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!(_003CAddress_003Ek__BackingField == value))
			{
				_003CAddress_003Ek__BackingField = value;
				RaisePropertyChanged("SaveButtonActive");
				RaisePropertyChanged("FillLaterButtonVisible");
				RaisePropertyChanged("SaveButtonVisible");
				RaisePropertyChanged("StreetHouseAddress");
				RaisePropertyChanged("Address");
			}
		}
	}

	public string StreetHouseAddress => Address.AddressLine;

	public VisualState State
	{
		[CompilerGenerated]
		get
		{
			return _003CState_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CState_003Ek__BackingField != value)
			{
				_003CState_003Ek__BackingField = value;
				RaisePropertyChanged("State");
			}
		}
	} = VisualState.Default;

	public UICommand<bool> CloseCommand { get; } = new UICommand<bool>();

	public UICommand DeleteItemCommand { get; } = new UICommand();

	public UICommand SaveCommand { get; } = new UICommand();

	public UICommand<BrokerToken> OpenAskToRemoveAddressPopupCommand { get; } = new UICommand<BrokerToken>();

	public AddressDetailsViewModel(BrokerToken token, IUserAddressService userAddressService, IInfoMessageService infoMessageService, DefaultErrorTranslator errorTranslator, IDataBroker dataBroker)
		: base(token)
	{
		_userAddressService = userAddressService;
		_infoMessageService = infoMessageService;
		_errorTranslator = errorTranslator;
		_dataBroker = dataBroker;
		Address = base.Argument.Address;
		Porch = Address.Porch;
		Floor = Address.Floor;
		Flat = Address.Flat;
		Intercom = Address.Intercom;
		Comment = Address.Comment;
		IsNew = base.Argument.IsNew;
		DeleteItemCommand.PerformDebouncingTask(OnDeleteItemCommand).Subscribe().AddTo(base.CloseDisposable);
		SaveCommand.PerformDebouncingTask(OnSaveCommand).Subscribe().AddTo(base.CloseDisposable);
		string text = NameButtons.FirstOrDefault((string n) => n.EqualsIgnoreCase(Address.Name));
		if (text != null)
		{
			SelectedNameIndex = NameButtons.IndexOf(text);
			EnteredName = text;
			return;
		}
		if (!string.IsNullOrEmpty(Address.Name))
		{
			SelectedNameIndex = NameButtons.Length - 1;
		}
		EnteredName = Address.Name;
	}

	private async Task OnDeleteItemCommand()
	{
		AskToRemoveAddressPopupViewModel.Parameter parameter = new AskToRemoveAddressPopupViewModel.Parameter
		{
			ForStore = false
		};
		OpenAskToRemoveAddressPopupCommand.Trigger(_dataBroker.Push(parameter));
		if (await parameter.TaskCompletionSource.Task)
		{
			Result<Unit, DomainError> result = await _userAddressService.RemoveSavedAddress(Address.Id);
			if (result.IsFailure)
			{
				_infoMessageService.ShowSnackbar(_errorTranslator.Translate(result.Error).description);
				return;
			}
			base.Argument.TaskCompletionSource.TrySetResult(result: true);
			CloseCommand.Trigger(IsNew);
		}
	}

	private async Task OnSaveCommand()
	{
		SavedAddress savedAddress = new SavedAddress
		{
			Id = Address.Id,
			IsLastSaved = Address.IsLastSaved,
			RegionId = Address.RegionId,
			AddressLine = Address.AddressLine,
			Coordinate = Address.Coordinate,
			Name = ((SelectedNameIndex >= 0 && SelectedNameIndex < NameButtons.Count() - 1) ? NameButtons[SelectedNameIndex] : ((SelectedNameIndex == -1) ? string.Empty : EnteredName)),
			Comment = (Comment ?? ""),
			Porch = Porch,
			Floor = Floor,
			Flat = Flat,
			Intercom = Intercom
		};
		if ((await _userAddressService.UpdateAddress(savedAddress)).IsFailure)
		{
			_infoMessageService.ShowSnackbar(IsNew ? "Не удалось сохранить адрес, попробуйте еще раз" : "Не удалось сохранить изменения, попробуйте еще раз");
			return;
		}
		base.Argument.TaskCompletionSource.TrySetResult(result: true);
		CloseCommand.Trigger(IsNew);
		if (IsNew)
		{
			_infoMessageService.ShowSnackbar("Сохранили ваш новый адрес", SnackbarStyle.Success);
		}
	}

	public override void Dispose()
	{
		base.Argument.TaskCompletionSource.TrySetResult(result: false);
		base.Dispose();
	}

	public void Close()
	{
		base.Argument.TaskCompletionSource.TrySetResult(result: true);
		CloseCommand.Trigger(IsNew);
		_infoMessageService.ShowSnackbar("Сохранили ваш новый адрес", SnackbarStyle.Success);
	}
}
