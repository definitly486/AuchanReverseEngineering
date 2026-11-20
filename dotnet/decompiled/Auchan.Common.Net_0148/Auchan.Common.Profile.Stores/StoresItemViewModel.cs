using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Stores.Models;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Profile.Stores;

public class StoresItemViewModel : BaseItemViewModel
{
	private readonly FullStoreModel _store;

	private readonly Subject<Location> _buildRouteCommand = new Subject<Location>();

	[CompilerGenerated]
	private bool _003CIsTempWorkInformerModel_003Ek__BackingField;

	[CompilerGenerated]
	private string _003CDistanceText_003Ek__BackingField;

	public bool IsTempWorkInformerModel
	{
		[CompilerGenerated]
		get
		{
			return _003CIsTempWorkInformerModel_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (_003CIsTempWorkInformerModel_003Ek__BackingField != value)
			{
				_003CIsTempWorkInformerModel_003Ek__BackingField = value;
				RaisePropertyChanged("IsTempWorkInformerModel");
			}
		}
	}

	public FullStoreModel FullStoreModel => _store;

	public string BuildRouteText => "Построить маршрут";

	public string ExternalAppChooseText => "Открыть с помощью приложения";

	public string TempWorkTitle => "Временный график";

	public int Id => _store.ExternalId;

	public string NameText => _store.Name;

	public string AddressText => _store.Address;

	public string ScheduleText => _store.Schedule;

	public double Latitude => _store.Latitude;

	public double Longitude => _store.Longitude;

	public string DistanceText
	{
		[CompilerGenerated]
		get
		{
			return _003CDistanceText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CDistanceText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CDistanceText_003Ek__BackingField = value;
				RaisePropertyChanged("DistanceExists");
				RaisePropertyChanged("DistanceText");
			}
		}
	}

	public bool IsScheduleExist => !string.IsNullOrEmpty(ScheduleText);

	public IObservable<Location> BuildRouteCommand => _buildRouteCommand.Debounce();

	public bool DistanceExists => !string.IsNullOrEmpty(DistanceText);

	public List<TempWorkHoursModel> TempWorkHours => _store.TempWorkHours;

	public bool IsOpen => _store.IsOpen;

	public string OpenStatusText => _store.OpenStatusText;

	public string OpenStatusDescription => _store.OpenStatusDescription;

	public string TempWorkDescription => _store.TempWorkDescription;

	public StoresItemViewModel(FullStoreModel store, bool isInformer = false)
	{
		_store = store;
		DistanceText = GetDistanceText();
		IsTempWorkInformerModel = isInformer;
	}

	public void BuildRoute()
	{
		_buildRouteCommand.OnNext(new Location(_store.Latitude, _store.Longitude));
	}

	private string GetDistanceText()
	{
		if (_store.DistanceFromGeo == 0.0)
		{
			return string.Empty;
		}
		if (_store.DistanceFromGeo > 5.0)
		{
			return "более 5 км";
		}
		return _store.DistanceFromGeo.ToString("0.00", CultureInfo.InvariantCulture) + " км";
	}
}
