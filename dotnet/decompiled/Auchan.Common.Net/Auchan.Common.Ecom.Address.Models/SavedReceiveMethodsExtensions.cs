using System.Collections.Generic;
using System.Linq;
using Auchan.Common.Addresses;

namespace Auchan.Common.Ecom.Address.Models;

public static class SavedReceiveMethodsExtensions
{
	public static DeliveryAddress? GetCurrentAddress(this SavedReceiveMethods @this)
	{
		if (@this.CurrentAddress != null)
		{
			return @this.CurrentAddress.ToDeliveryAddress();
		}
		if (@this.CurrentRegionId.HasValue)
		{
			SavedAddress savedAddress = @this.Addresses.FirstOrDefault((SavedAddress i) => i.IsLastSaved && i.RegionId == @this.CurrentRegionId);
			if (savedAddress != null)
			{
				return savedAddress.ToDeliveryAddress();
			}
		}
		return null;
	}

	public static Store? GetCurrentShop(this SavedReceiveMethods @this, IEnumerable<IGrouping<City, Store>> allCityShops)
	{
		return (from @group in allCityShops
			let city = @group.Key
			where city.EcomId == @this.CurrentRegionId
			from shop in @group
			where shop.Id == @this.CurrentMerchantId
			select shop).FirstOrDefault();
	}

	public static Store? GetDefaultRegionShop(this SavedReceiveMethods @this, IEnumerable<IGrouping<City, Store>> allCityShops)
	{
		return (from @group in allCityShops
			let city = @group.Key
			where city.EcomId == @this.CurrentRegionId
			from shop in @group
			where shop.IsDefaultInCity
			select shop).FirstOrDefault();
	}

	public static Store? GetDefaultShopInDefaultCity(this SavedReceiveMethods @this, IEnumerable<IGrouping<City, Store>> allCityShops)
	{
		return (from @group in allCityShops
			let city = @group.Key
			where city.IsDefault
			from shop in @group
			where shop.IsDefaultInCity
			select shop).FirstOrDefault();
	}

	public static Store? GetCurrentOrDefaultShop(this SavedReceiveMethods @this, IEnumerable<IGrouping<City, Store>> allCityShops)
	{
		return @this.GetCurrentShop(allCityShops) ?? @this.GetDefaultRegionShop(allCityShops) ?? @this.GetDefaultShopInDefaultCity(allCityShops);
	}
}
