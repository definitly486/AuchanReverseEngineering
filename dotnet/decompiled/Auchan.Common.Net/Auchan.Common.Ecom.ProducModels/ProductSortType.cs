namespace Auchan.Common.Ecom.ProducModels;

public record ProductSortType : ProductSortSelection
{
	public int SerialNumber { get; set; }

	public string Name { get; set; } = string.Empty;
}
