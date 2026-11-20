using System;
using System.Reactive.Subjects;
using Auchan.Common.Base;
using Auchan.Common.Extensions;
using Auchan.Common.Profile.Stores.Models;

namespace Auchan.Common.Profile.Stores;

public class StoresFilterServicesItemViewModel : BaseItemViewModel
{
	private readonly Subject<bool> _onChecked = new Subject<bool>();

	private bool _isSelected;

	private FullStoreServiceModel _service;

	public IObservable<bool> OnChecked => _onChecked.Debounce();

	public string Name => _service.Name;

	public int Id => _service.Id;

	public bool Selected
	{
		get
		{
			return _isSelected;
		}
		set
		{
			if (_isSelected != value)
			{
				_isSelected = value;
				RaisePropertyChanged("Selected");
				_onChecked.OnNext(value);
			}
		}
	}

	public StoresFilterServicesItemViewModel(FullStoreServiceModel service)
	{
		_service = service;
	}
}
