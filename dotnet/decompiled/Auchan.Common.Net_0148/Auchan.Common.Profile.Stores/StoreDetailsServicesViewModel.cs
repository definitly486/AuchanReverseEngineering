using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Common.Binding;
using Auchan.Common.Profile.Stores.Models;

namespace Auchan.Common.Profile.Stores;

public class StoreDetailsServicesViewModel : ScreenViewModel
{
	public class Parameter
	{
		public FullStoreModel Store { get; }

		public Parameter(FullStoreModel store)
		{
			Store = store;
		}
	}

	private readonly Parameter _parameter;

	private readonly Func<FullStoreServiceModel, ICollection<IDisposable>, StoreDetailsServicesItemViewModel> _viewModelFactory;

	public readonly UICommand CloseCommand = new UICommand();

	[CompilerGenerated]
	private string _003CTitleText_003Ek__BackingField;

	[CompilerGenerated]
	private IReadOnlyList<StoreDetailsServicesItemViewModel> _003CServices_003Ek__BackingField;

	public string TitleText
	{
		[CompilerGenerated]
		get
		{
			return _003CTitleText_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!string.Equals(_003CTitleText_003Ek__BackingField, value, StringComparison.Ordinal))
			{
				_003CTitleText_003Ek__BackingField = value;
				RaisePropertyChanged("TitleText");
			}
		}
	} = "Услуги";

	public string CloseButtonText => "Закрыть";

	public IReadOnlyList<StoreDetailsServicesItemViewModel> Services
	{
		[CompilerGenerated]
		get
		{
			return _003CServices_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			if (!object.Equals(_003CServices_003Ek__BackingField, value))
			{
				_003CServices_003Ek__BackingField = value;
				RaisePropertyChanged("Services");
			}
		}
	} = new List<StoreDetailsServicesItemViewModel>();

	public StoreDetailsServicesViewModel(Parameter parameter, Func<FullStoreServiceModel, ICollection<IDisposable>, StoreDetailsServicesItemViewModel> viewModelFactory)
	{
		_parameter = parameter;
		_viewModelFactory = viewModelFactory;
		FullStoreModel store = _parameter.Store;
		if (store != null)
		{
			TitleText = (string.IsNullOrEmpty(store.StoreFormat) ? "Услуги" : ("Услуги в " + store.StoreFormat.ToLower() + "е"));
			Services = store.Services.Select((FullStoreServiceModel c) => _viewModelFactory(c, base.CloseDisposable)).ToList();
			_parameter = parameter;
		}
	}

	public void Close()
	{
		CloseCommand.Trigger();
	}
}
