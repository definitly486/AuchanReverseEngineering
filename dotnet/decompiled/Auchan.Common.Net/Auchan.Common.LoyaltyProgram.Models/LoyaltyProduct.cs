namespace Auchan.Common.LoyaltyProgram.Models;

public class LoyaltyProduct
{
	public string? Name { get; }

	public string? Code { get; }

	public string? Domain { get; }

	public double Price { get; }

	public string? Image { get; }

	public double Quantity { get; }

	public decimal Points { get; }

	public decimal ExpressPoints { get; }

	public decimal Stamps { get; }

	public LoyaltyProduct(string? code, string? domain, decimal points, decimal expressPoints, decimal stamps, double quantity, double price, string? image, string? name)
	{
		Code = code;
		Domain = domain;
		Points = points;
		ExpressPoints = expressPoints;
		Stamps = stamps;
		Quantity = quantity;
		Price = price;
		Image = image;
		Name = name;
	}
}
