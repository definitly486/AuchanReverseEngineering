using System;
using System.Globalization;
using System.Reactive.Subjects;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Stores.Models;
using Microsoft.Maui.Devices.Sensors;

namespace Auchan.Common.Profile.Stores;

public class StoreDetailsMiniViewModel : ScreenViewModel
{
	public class Parameter
	{
		public FullStoreModel FullStoreModel { get; set; }

		public Parameter(FullStoreModel model)
		{
			FullStoreModel = model;
		}
	}

	private readonly FullStoreModel _store;

	private readonly Subject<Location> _buildRouteCommand = new Subject<Location>();

	private readonly Subject<StoreDetailsViewModel.Parameter> _openStoreDetails = new Subject<StoreDetailsViewModel.Parameter>();

	public string MoreButtonText => "Подробнее о магазине";

	public string ExternalAppChooseText => "Открыть с помощью приложения";

	public string BuildRouteText => "Построить\nмаршрут";

	public string CloseButtonText => "Свернуть";

	public int Id => _store.ExternalId;

	public string NameText => _store.Name;

	public string AddressText => _store.Address;

	public string ScheduleText => _store.Schedule;

	public double Latitude => _store.Latitude;

	public double Longitude => _store.Longitude;

	public bool IsScheduleExist => !string.IsNullOrEmpty(ScheduleText);

	public bool IsDistanceExist => !string.IsNullOrEmpty(DistanceText);

	public string DistanceText { get; }

	public IObservable<Location> BuildRouteCommand => _buildRouteCommand.Debounce();

	public IObservable<StoreDetailsViewModel.Parameter> OnNavigateStoreDetails => _openStoreDetails.Debounce();

	public StoreDetailsMiniViewModel(Parameter parameter)
	{
		_store = parameter.FullStoreModel;
		DistanceText = GetDistanceText();
	}

	public void OpenStoreDetails()
	{
		_openStoreDetails.OnNext(new StoreDetailsViewModel.Parameter(Id));
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
