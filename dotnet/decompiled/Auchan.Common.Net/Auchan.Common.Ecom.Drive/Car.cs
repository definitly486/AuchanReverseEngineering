namespace Auchan.Common.Ecom.Drive;

public class Car
{
	public int? Id { get; set; }

	public string CarNumber { get; set; } = string.Empty;

	public string CarMark { get; set; } = string.Empty;

	public string CarColor { get; set; } = string.Empty;

	public bool IsDefault { get; set; }
}
