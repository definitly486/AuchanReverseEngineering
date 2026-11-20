using System.Runtime.CompilerServices;
using Auchan.Common.Base;
using Auchan.Common.Profile.Stores.Models;

namespace Auchan.Common.Profile.Stores;

public class StoresFilterRegionItemViewModel : BaseItemViewModel
{
	private readonly RegionModel _region;

	[CompilerGenerated]
	private bool _003CSelected_003Ek__BackingField;

	public string Name => _region.Name;

	public int Id => _region.Id;

	public string FiasId => _region.RegionFias;

	public bool Selected
	{
		[CompilerGenerated]
		get
		{
			return _003CSelected_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			if (_003CSelected_003Ek__BackingField != value)
			{
				_003CSelected_003Ek__BackingField = value;
				RaisePropertyChanged("Selected");
			}
		}
	}

	public StoresFilterRegionItemViewModel(RegionModel region)
	{
		_region = region;
	}
}
