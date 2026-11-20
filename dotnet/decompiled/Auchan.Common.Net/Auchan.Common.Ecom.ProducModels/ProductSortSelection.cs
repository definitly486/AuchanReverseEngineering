namespace Auchan.Common.Ecom.ProducModels;

public record ProductSortSelection
{
	public string Field { get; set; } = string.Empty;

	public string Direction { get; set; } = string.Empty;
}
