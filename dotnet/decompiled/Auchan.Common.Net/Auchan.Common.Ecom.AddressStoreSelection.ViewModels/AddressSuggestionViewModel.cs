using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using AsyncAwaitBestPractices;
using Auchan.Common.Addresses;
using Auchan.Common.Analytics;
using Auchan.Common.Base;
using Auchan.Common.Base.Errors.Domain;
using Auchan.Common.Common;
using Auchan.Common.Common.Binding;
using Auchan.Common.Ecom.Address;
using Auchan.Common.Ecom.Address.Models;
using Auchan.Common.Extensions;
using CSharpFunctionalExtensions;

namespace Auchan.Common.Ecom.AddressStoreSelection.ViewModels;

public class AddressSuggestionViewModel : ScreenViewModel<AddressSuggestionViewModel.Parameter>
{
	public sealed class Parameter : BrokeredParameter<Suggestion?>
	{
		public required string? OldAddress { get; init; }

		public required City SelectedRegion { get; init; }

		public Parameter()
			: base(default(CancellationToken))
		{
		}
	}

	private readonly IUserAddressService _addressService;

	private string? _lastSetAddress;

	private bool _saveChanges;

	private volatile int _requestId;

	[CompilerGenerated]
	private Suggestion? _003CSuggestion_003Ek__BackingField;

	[CompilerGenerated]
	private VisualState _003CState_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CAddress_003Ek__BackingField;

	[CompilerGenerated]
	private string? _003CAddressValidation_003Ek__BackingField;

	public string HintText => "Город, улица, дом";

	public string SaveText => "Сохранить";

	public ObservableRangeCollection<Suggestion> Suggestions { get; } = new ObservableRangeCollection<Suggestion>();

	private Suggestion? Suggestion
	{
		[CompilerGenerated]
		get
		{
			return _003CSuggestion_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!(_003CSuggestion_003Ek__BackingField == value))
			{
				_003CSuggestion_003Ek__BackingField = value;
				RaisePropertyChanged("SaveEnabled");
				RaisePropertyChanged("Suggestion");
			}
		}
	}

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
	}

	public string Address
	{
		[CompilerGenerated]
		get
		{
			return _003CAddress_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (!string.Equals(_003CAddress_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAddress_003Ek__BackingField = value;
				RaisePropertyChanged("IsEndIconVisible");
				OnAddressChanged();
				RaisePropertyChanged("Address");
			}
		}
	}

	public string? AddressValidation
	{
		[CompilerGenerated]
		get
		{
			return _003CAddressValidation_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CAddressValidation_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CAddressValidation_003Ek__BackingField = value;
				RaisePropertyChanged("IsHaveAddressValidationError");
				RaisePropertyChanged("IsEndIconVisible");
				RaisePropertyChanged("AddressValidation");
			}
		}
	}

	public bool IsHaveAddressValidationError => !string.IsNullOrEmpty(AddressValidation);

	public bool IsEndIconVisible
	{
		get
		{
			if (!IsHaveAddressValidationError)
			{
				return !string.IsNullOrEmpty(Address);
			}
			return true;
		}
	}

	public bool SaveEnabled => Suggestion?.IsFull ?? false;

	public UICommand CloseCommand { get; } = new UICommand();

	private UICommand SaveCommand { get; } = new UICommand();

	public AddressSuggestionViewModel(BrokerToken token, IUserAddressService addressService)
		: base(token)
	{
		_addressService = addressService;
		_lastSetAddress = base.Argument.OldAddress;
		Address = base.Argument.OldAddress ?? string.Empty;
		SaveCommand.Debounce().Subscribe(delegate
		{
			Save();
		}).AddTo(base.CloseDisposable);
	}

	protected override async Task Start()
	{
		await base.Start();
		AppAnalytics.AppMetrica.TrackEvent("tapDeliveryInput");
	}

	private void OnAddressChanged()
	{
		if (Address != _lastSetAddress)
		{
			_lastSetAddress = null;
			Suggestion = null;
			if (Address.Length == 0)
			{
				AddressValidation = null;
			}
			SuggestAddresses(Address).SafeFireAndForget((Action<Exception>)null, false);
		}
	}

	public void OnAddressSuggestionSelected(int position)
	{
		Address = (_lastSetAddress = Suggestions[position].Address?.AddressLine ?? "");
		Suggestion = Suggestions[position];
		AddressValidation = Suggestion.GetValidationError() ?? "";
		if (!Suggestion.IsFull)
		{
			SuggestAddresses(Address + " ").SafeFireAndForget((Action<Exception>)null, false);
		}
		else
		{
			AddressValidation = null;
		}
	}

	public void OnSaveClick()
	{
		SaveCommand.Trigger();
	}

	private void Save()
	{
		if (Suggestion == null)
		{
			throw new InvalidOperationException("Should not save is it's disabled");
		}
		_saveChanges = true;
		CloseCommand.Trigger();
	}

	private async Task SuggestAddresses(string addressQuery)
	{
		if (addressQuery.Length < 3)
		{
			return;
		}
		State = VisualState.InProgress;
		int rid = Interlocked.Increment(ref _requestId);
		await Task.Delay(500);
		if (rid == _requestId)
		{
			Result<SuggestionResult, DomainError> result = await Task.Run(() => _addressService.SuggestGeocode(base.Argument.SelectedRegion, addressQuery));
			IReadOnlyList<Suggestion> collection = Array.Empty<Suggestion>();
			string addressValidation = "Произошла ошибка. Пожалуйста, повторите попытку позже";
			if (result.TryGetValue(out var value))
			{
				collection = value.Suggestions;
				addressValidation = value.GetValidationError() ?? "";
			}
			AddressValidation = addressValidation;
			Suggestions.ReplaceRange(collection);
			State = VisualState.Default;
		}
	}

	public override void Dispose()
	{
		base.Dispose();
		base.Argument.TaskCompletionSource.TrySetResult(_saveChanges ? Suggestion : null);
	}
}
