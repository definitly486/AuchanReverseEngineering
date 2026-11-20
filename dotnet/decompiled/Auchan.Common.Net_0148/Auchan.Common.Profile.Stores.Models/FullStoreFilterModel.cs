using System.Collections.Generic;

namespace Auchan.Common.Profile.Stores.Models;

public class FullStoreFilterModel
{
	public int? RegionId { get; set; }

	public string RegionName { get; set; } = string.Empty;

	public IList<int> ServiceIds { get; set; } = new List<int>();

	public StoreType? StoreType { get; set; }

	public bool IsSaved { get; private set; }

	public bool IsDefault => IsDefaultValues();

	public void Apply(FullStoreFilterModel source)
	{
		RegionId = source.RegionId;
		ServiceIds = new List<int>(source.ServiceIds);
		StoreType = source.StoreType;
		RegionName = source.RegionName;
		IsSaved = true;
	}

	public void Clear()
	{
		RegionId = null;
		ServiceIds = new List<int>();
		StoreType = null;
		RegionName = string.Empty;
		IsSaved = false;
	}

	public bool ServicesEquals(FullStoreFilterModel other)
	{
		return new HashSet<int>(ServiceIds).SetEquals(other.ServiceIds);
	}

	private bool IsDefaultValues()
	{
		if (ServiceIds.Count == 0)
		{
			return !StoreType.HasValue;
		}
		return false;
	}
}
