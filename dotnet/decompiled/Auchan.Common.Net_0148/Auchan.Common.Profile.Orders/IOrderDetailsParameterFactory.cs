using System.Threading.Tasks;
using Auchan.Common.Profile.Orders.Models;

namespace Auchan.Common.Profile.Orders;

public interface IOrderDetailsParameterFactory
{
	public interface IPassToken
	{
	}

	Task<OrderDetailsViewModel.Parameter?> CreateAsync(IOrderModel orderModel);
}
