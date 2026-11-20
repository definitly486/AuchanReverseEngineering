namespace Auchan.Common.Ecom.ProducModels.Filters;

public static class ProductFilterExtensions
{
	public static bool IsCanBeDisplayed(this ProductFilter @this)
	{
		switch (@this.Type)
		{
		case ProductFilterType.MultiCheck:
		case ProductFilterType.Radio:
			if (@this.IsForActive)
			{
				return @this.Disabled == false;
			}
			return false;
		case ProductFilterType.Range:
		case ProductFilterType.Check:
			return @this.IsForActive;
		default:
			return @this.IsForActive;
		}
	}
}
