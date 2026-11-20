namespace Auchan.Common.Profile.Orders.Models;

public interface IOrderModel
{
	long Id { get; }

	bool IsAdult { get; }

	bool IsCanAddGoodsToOrder { get; }
}
